using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Tripple_Power : MonoBehaviour 
{
	public float Speed=1/4f;
	void FixedUpdate () 
	{
		transform.Translate (new Vector3 (0, transform.position.y, 1 * Time.deltaTime * Speed));

		if (transform.position.z < -12)
		{
			transform.position = new Vector3 (Random.Range(-23,23),0,12);
		}
	}
}
