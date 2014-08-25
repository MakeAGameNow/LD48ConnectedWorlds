using UnityEngine;
using System.Collections;

public class SphereOrienter : MonoBehaviour
{
	public float height = 2.0f;
	public LayerMask layerMask = -1;

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
