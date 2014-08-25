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
		if(enemyCount <= 0)
		{
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	void OnGUI()
	{
		if(enemyCount > 0)
		{
			GUILayout.Label("Terminate remaining GlitchCubes: " + enemyCount.ToString());
		}
		else
		{
			GUILayout.Label("Server clear of GlitchCubes, press any key to connect to next server!");
		}
	}
}
