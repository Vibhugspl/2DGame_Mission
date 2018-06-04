using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {


	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButton (0)) {
			DrawRaycast ();
		}


	}


	void DrawRaycast()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		if (Physics.Raycast (ray.origin, ray.direction, out hit, 100)) 
		{
			print (hit.collider.gameObject.name);
		}
	}


}
