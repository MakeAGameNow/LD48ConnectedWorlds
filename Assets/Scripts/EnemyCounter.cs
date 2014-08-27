using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour
{
	[HideInInspector]
	public int enemyCount;

	public Material[] randomizeColorsOnThese;

	public List<Color> originalColors = new List<Color>();

	public static EnemyCounter Instance = null;

	void Start()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		foreach(Material mat in randomizeColorsOnThese)
		{
			originalColors.Add(mat.GetColor ("_ReflectColor"));
		}
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if(enemyCount <= 0)
		{
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(Application.loadedLevel);
				foreach(Material mat in randomizeColorsOnThese)
				{
					mat.SetColor("_ReflectColor",new HSBColor(Random.value,1.0f,1.0f).ToColor());
				}
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

	void OnApplicationQuit()
	{
		int i = 0;
		foreach(Material mat in randomizeColorsOnThese)
		{
			mat.SetColor("_ReflectColor",originalColors[i]);
			i++;
		}
	}
}
