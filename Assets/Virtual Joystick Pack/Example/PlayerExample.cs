using UnityEngine;

public class PlayerExample : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;

	void Update () 
	{
        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);

        if (transform.position.z > 15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
        }
        else if (transform.position.z < -6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6);
        }
        if (transform.position.x > 15)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

    }
}