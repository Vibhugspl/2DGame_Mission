using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour 
{
	[SerializeField]
	protected float speed=55.0f;

	private float verticalInput;
	private float horizontalInput;

	private Rigidbody rb;

	public Text dummy;

	Vector3 acceleration;

	public bool up, down, left, right;

	private void Start()
	{

		rb = GetComponent<Rigidbody> ();
	}

	private void FixedUpdate()
	{
		
		Player_Movement ();
	}

	private void Player_Movement()
	{
		#if UNITY_EDITOR
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");
	
		#else
		acceleration = Input.acceleration;
		horizontalInput = acceleration.x;
		verticalInput = (acceleration.y);


		#endif
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");
		transform.Translate (new Vector3(horizontalInput,0,0)*Time.deltaTime*speed);
		transform.Translate (new Vector3(0,-1*verticalInput,0)*Time.deltaTime*speed);


		if (transform.position.z > 11)
		{
			transform.position = new Vector3 (transform.position.x,transform.position.y,11);
		}
		else if (transform.position.z < -11)
		{
			transform.position = new Vector3 (transform.position.x,transform.position.y,-11);
		}
		if (transform.position.x > 23)
		{
			transform.position = new Vector3 (23, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < -23)
		{
			transform.position = new Vector3 (-23, transform.position.y, transform.position.z);
		}
			

		if (left)
			moveLeft ();

		else	if (right)
			moveRight ();


		else	if (up)
			moveup ();

		else if (down)
			moveDown ();
	}


	public	void moveLeft()
	{
		transform.Translate (Vector3.left*Time.deltaTime*speed);
	}
	public void moveRight()
	{
		transform.Translate(Vector3.right*Time.deltaTime*speed);
	}
	public	void moveup()
	{
		transform.Translate (Vector3.down*Time.deltaTime*speed);
	}
	public	void moveDown()
	{
		transform.Translate (Vector3.up*Time.deltaTime*speed);
	}



	public void PointerEnter_Left()
	{
		left = true;

//		if (left)
//			moveLeft ();
	}

	public void PointerExit_Left()
	{
		left = false;

	}

	public void pointerEnter_Right()
	{
		right = true;
//		if (right)
//			moveRight ();
	}

	public void pointerExit_Right()
	{
		right = false;
	}
	public void pointernter_up()
	{
		up = true;
//		if (up)
//			moveup ();

	}

	public void pointerExit_up()
	{
		up = false;
	}

	public void pointernter_Down()
	{
		down = true;
//		if (down)
//			moveDown ();
	}

	public void pointerExit_Down()
	{
		down = false;
	}



}
