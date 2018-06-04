using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyship;
	[SerializeField]
	private GameObject[] PowerUps;

	private IEnumerator cor1;

	[Space]
	[Header("Enemylist")]
	public List<GameObject> EnemyPool;
	public int EnemyPoolCount = 10;

	public bool willgrow;

    public List<GameObject> TurnoffonGameover;

    private static Spawn_Manager Instance;
    public static Spawn_Manager instance
    {
        get
        {
            if (Instance == null)
            {
                GameObject obj = new GameObject("player");
                obj.AddComponent<Spawn_Manager>();
            }
            return Instance;
        }
    }

	void Awake()
	{
        if (Instance == null)
        {
            Instance = this;
        }

		MakeEnemypool ();
	}

	void Start()
	{
		cor1 = EnemySpawn (2f);
		//StartCoroutine (cor1);

		InvokeRepeating ("GenerateEnemy", 1, 2f);
	}

	IEnumerator EnemySpawn(float i)
	{
		while (true)
		{
			Instantiate (enemyship, new Vector3 (Random.Range (-23, 23), 0, 12), Quaternion.identity);
			yield return new WaitForSeconds (i);

		}
	}

	void MakeEnemypool()
	{
		for (int i = 0; i < EnemyPoolCount; i++) 
		{
			GameObject go = Instantiate (enemyship);
			go.SetActive (false);
			EnemyPool.Add (go);
		}
	}


	public GameObject _FunGenerateEnemy()
	{
		for (int j = 0; j < EnemyPool.Count; j++)
		{
			if (!(EnemyPool [j].activeInHierarchy)) 
			{
				return EnemyPool [j];
			}
		}

		if (willgrow)
		{
			GameObject obj = (GameObject)Instantiate (enemyship);
			EnemyPool.Add (obj);
			return obj;
		}

		return null;
	}


	public void GenerateEnemy()
	{
		GameObject Enemyobj = _FunGenerateEnemy ();

		if (Enemyobj == null)
			return;

		Enemyobj.transform.position = new Vector3(Random.Range(-20, 20), 0, 12);
        Enemyobj.transform.rotation = enemyship.transform.rotation;
		Enemyobj.SetActive (true);
	}
}
