using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{

	private static Laser Instance;
	public static Laser instance
	{
		get
		{
			if (Instance == null)
			{
				GameObject go = new GameObject ();
				go.name = "Gamemnager";
				go.AddComponent<Laser> ();
				DontDestroyOnLoad (go);
			}
			return Instance;
		}
	}

	void Start()
	{
		Instance = this;
	}

	public int bulletSpeed = 5;

	[HideInInspector]
	public static int Score=0;


	void FixedUpdate ()
	{
		transform.Translate (new Vector3(0,-1,0)*Time.deltaTime*bulletSpeed);
		if (transform.position.z > 13)
		{
			Destroy (this.gameObject);

		}
		GameManager.instance.CurrentScore.text = "Your Score:  "+Score;


	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			col.gameObject.SetActive (false);
			transform.position = new Vector3 (Random.Range(-23,23),0,12);
			GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount = GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount +.1f;
			Score++;
			if (Score == 20)
				Time.timeScale = 1.1f;

			else if (Score == 35)
				Time.timeScale = 1.2f;

			else if(Score==50)Time.timeScale = 1.4f;

			if(GameManager.instance.HealthBar.GetComponent<Image> ().fillAmount >= .5f) 
			{
				GameManager.instance.HealthBar.GetComponent<Image> ().color = Color.green;
			}
		}
	}
}
