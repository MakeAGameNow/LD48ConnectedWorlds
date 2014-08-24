using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 1.0f;
	public float height = 2.0f;
	
	void Update ()
	{
		transform.position += (transform.forward*Input.GetAxis("Vertical")+transform.right*Input.GetAxis("Horizontal"))*speed*Time.deltaTime;
		//rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical")*thrustForce), ForceMode.Acceleration);
	}

	void LateUpdate()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position-transform.up*height*2.0f,transform.up,out hit))
		{
			transform.position = hit.point+transform.up*height;
			Vector3 newUp = hit.transform.position-transform.position;
			transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right,newUp),newUp);
		}
	}
}
