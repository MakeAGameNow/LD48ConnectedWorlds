using UnityEngine;
using System.Collections;

public class SpherePopulator : MonoBehaviour
{
	public GameObject[] gameObjects;
	public float number = 100;
	public float radius = 150;
	public LayerMask layerMask = -1;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < number; i++)
		{
			GameObject obj = (GameObject)Instantiate(gameObjects[Random.Range(0,gameObjects.Length)],transform.position+Random.onUnitSphere*radius,Quaternion.identity);

			RaycastHit hit;
			Vector3 newUp = transform.position-obj.transform.position;
			if(Physics.Raycast(obj.transform.position,newUp,out hit, Mathf.Infinity, layerMask))
			{
				obj.transform.position = hit.point-newUp.normalized;
				obj.transform.rotation = Quaternion.LookRotation(Vector3.Cross(obj.transform.right,newUp),newUp);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
