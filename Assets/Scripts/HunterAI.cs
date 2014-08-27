using UnityEngine;
using System.Collections;

public class HunterAI : MonoBehaviour
{
	public float rotationSpeed = 20.0f;
	public float shootAngle = 10.0f;

	private GameObject[] enemies;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		float closest = Mathf.Infinity;
		GameObject closestObj = null;

		foreach(GameObject enemy in enemies)
		{
			Vector3 direction = enemy.transform.position-transform.position;

			float distance = direction.sqrMagnitude;

			if(distance < closest && Vector3.Dot(transform.forward,direction) > 0.0f)
			{
				closest = distance;
				closestObj = enemy;
			}
		}

		if(closestObj != null)
		{

			Quaternion previousRotation = transform.rotation;

			Quaternion goalRotation = Quaternion.LookRotation(closestObj.transform.position-transform.position,transform.up);

			transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed*Time.deltaTime);

			if(Quaternion.Angle(goalRotation,transform.rotation) < shootAngle)
			{
				Shoot shooter = GetComponentInChildren<Shoot>();
				shooter.shootNow = true;
			}
		}
	}
}
