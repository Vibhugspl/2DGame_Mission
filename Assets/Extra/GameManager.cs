using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
	private static GameManager Instance;
	public static GameManager instance 
	{
		get
		{
			if (Instance == null) {
				GameObject go = new GameObject ();
				go.name = "Player";
				Instance = go.AddComponent<GameManager> ();
				DontDestroyOnLoad (go);
			}

			return Instance;
		}
	}



	[SerializeField]
	private GameObject Bullet,Enemy;

	[Header("Bullet_Properties")]
	public int BulletAmount=10;
	public GameObject BulletParent;

	[Tooltip("Fighter_SpaceShip")]
	public GameObject _Player;

	public List<GameObject> BulletPool;
	Player boby;
	protected float fireRate = .15f;
	protected float CanFire = 0.0f;

	public bool Enable_PowerUp;
    
	[Header("PowerUp")]
	private IEnumerator power_up_cor;

	private int bool_int;
	public bool triPPleFire;

	[Header("UI")]
	public GameObject Gameover_Pannel;
	public Image HealthBar;
	public Text Score;
	public Text CurrentScore;



	[Header("VFX")]
	public GameObject[] vfx;


	void Awake()
	{
		if(Instance==null)Instance = this;
		power_up_cor = Powerup ();

	}

	void FixedUpdate ()
	{
		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > CanFire)
		{
			
		

		}
	//	Vector3 pos = new Vector3 (Random.Range (-23, 23), 0, 12);
	//	Instantiate(Enemy,pos,Quaternion.identity);

	}

	 void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Tripple_Power" )
		{
			triPPleFire = true;
			col.gameObject.SetActive (false);
		}
	}


	public void Fire()
	{
		if (triPPleFire)
		{

			TrippleShoot ();
		}
		else if(Enable_PowerUp)
		{
			StartCoroutine (power_up_cor);
		}
		else
		{
			Shoot ();
		}
	}



	private void Shoot()
	{
		CanFire = Time.time + fireRate;
		Instantiate (Bullet,BulletParent.transform.position,BulletParent.transform.rotation);
	}

	int a = 0;
	void TrippleShoot()
	{
		CanFire = Time.time + fireRate;
		Instantiate (Bullet,BulletParent.transform.position,BulletParent.transform.rotation);
		Instantiate (Bullet,BulletParent.transform.position-new Vector3(1,0,0),BulletParent.transform.rotation);
		Instantiate (Bullet,BulletParent.transform.position+new Vector3(1,0,0),BulletParent.transform.rotation);

		a++;
		print (a);
		if(a>=25)triPPleFire = false;


	}

	IEnumerator Powerup()
	{
		transform.localScale = (Bullet.transform.localScale == new Vector3 (2, .3f, .3f))?Bullet.transform.localScale = new Vector3 (.3f, .3f, .3f):Bullet.transform.localScale = new Vector3 (2, .3f, .3f);
		yield return new WaitForSeconds (5);
		transform.localScale = (Bullet.transform.localScale == new Vector3 (2, .3f, .3f))?Bullet.transform.localScale = new Vector3 (.3f, .3f, .3f):Bullet.transform.localScale = new Vector3 (2, .3f, .3f);

	}


}
