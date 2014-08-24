using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 1.0f;
	public float rotateSpeed = 30.0f;
	public float height = 2.0f;
	public LayerMask layerMask = -1;

	void Update ()
	{
		transform.position += transform.forward*speed*Time.deltaTime;
		transform.RotateAround(transform.up,Random.Range(-rotateSpeed,rotateSpeed)*Mathf.Deg2Rad*Time.deltaTime);
		//rigidbody.AddForce((transform.forward*Input.GetAxis("Vertical")+transform.right*Input.GetAxis("Horizontal"))*speed, ForceMode.Acceleration);
	}

	void LateUpdate()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position-transform.up*height*2.0f,transform.up,out hit, Mathf.Infinity, layerMask))
		{
			transform.position = hit.point+transform.up*height;
			Vector3 newUp = hit.transform.position-transform.position;
			transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right,newUp),newUp);
		}
	}
}
