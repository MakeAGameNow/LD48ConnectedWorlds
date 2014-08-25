using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour {

	void OnTriggerEnter()
	{
		Destroy (gameObject);
	}
}
