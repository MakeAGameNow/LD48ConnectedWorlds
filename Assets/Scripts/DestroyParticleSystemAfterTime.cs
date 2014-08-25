using UnityEngine;
using System.Collections;

public class DestroyParticleSystemAfterTime : MonoBehaviour
{
	public float time = 1.0f;

	// Use this for initialization
	void Start ()
	{
		Invoke("DestroyParticle", time);
	}

	void Update()
	{
		if(!particleSystem.IsAlive())
		{
			Destroy(gameObject);
		}
	}
	
	void DestroyParticle()
	{
		particleSystem.Stop();
		collider.enabled = false;
	}
}
