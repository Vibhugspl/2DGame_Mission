using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy_AI : MonoBehaviour 
{
	public float EnemySpeed=110;

    public Transform player;
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
        transform.DOMove(player.position, 7);
    }
    void FixedUpdate () 
	{
		transform.Translate (new Vector3 (0, 0, 1 * Time.deltaTime * EnemySpeed));
		 
		if (transform.position.z < -12)
		{
			transform.position = new Vector3 (Random.Range(-23,23),0,12);
		}
	}

	private void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.name == "Player")
		{
			GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount = GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount - .20f;
            cam.DOShakePosition(1.0f, 1, 10, 90, false, true);
//
			if (GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount <= .5f)
			{
				GameManager.instance.HealthBar.GetComponent<Image> ().color = Color.red;
			} 

		


			gameObject.SetActive (false);
			if (GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount <= 0) 
			{
                
				GameOver ();
			}

		}
	}

	public 	void GameOver()
	{
		Time.timeScale = 0;
        if (PlayerPrefs.GetInt("score") < Laser.Score) PlayerPrefs.SetInt("score", Laser.Score);
        GameManager.instance.Score.text = "High Score:- " + PlayerPrefs.GetInt("score");
        for (int i = 0; i < Spawn_Manager.instance.TurnoffonGameover.Count; i++) Spawn_Manager.instance.TurnoffonGameover[i].SetActive(false);

       
        GameManager.instance.Gameover_Pannel.SetActive (true);
		
	}
}
