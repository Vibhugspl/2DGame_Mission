using UnityEngine;
using System.Collections;
public class New_Layout : MonoBehaviour {
 
	public GameObject cp;
	//public GameObject calp;
	private float dist,dist1;
    private float leftBorder;
    private float rightBorder;
      public Camera main;
 
	 void Start()
    {
 		dist = (cp.transform.position - main.transform.position).z;
  		leftBorder = main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
		//rightBorder = main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
		cp.transform.localPosition = new Vector3(leftBorder, cp.transform.localPosition.y,cp.transform.localPosition.z);
      //  if (calp != null)
           // calp.transform.localPosition = new Vector3(rightBorder, calp.transform.localPosition.y, 215);
    	
	}
}
