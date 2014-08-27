using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public float shootSpeed = 0.5f;
	public bool shootNow = false;
	public bool canShoot = true;

	void Start()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if((Input.GetButtonDown("Fire1") || shootNow) && canShoot)
		{
			Instantiate(bullet,transform.position,transform.rotation);
			canShoot = false;
			Invoke("ResetShoot",shootSpeed);
		}
		shootNow = false;
	}

	void ResetShoot()
	{
		canShoot = true;
	}
}
