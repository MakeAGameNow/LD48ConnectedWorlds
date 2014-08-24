using UnityEngine;
using System.Collections;

public class EnemyCounter : MonoBehaviour
{
	[HideInInspector]
	public int enemyCount;

	// Update is called once per frame
	void Update()
	{
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
	}
	
	void OnGUI()
	{
		GUILayout.Label(enemyCount.ToString());
	}
}
