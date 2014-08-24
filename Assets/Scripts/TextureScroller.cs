using UnityEngine;
using System.Collections;

public class TextureScroller : MonoBehaviour
{
	[System.Serializable]
	public class MaterialScrollInfo
	{
		public Material material;
		public Vector2 scrollSpeed = Vector3.one;
		public string textureName = "_MainTex";
	}
	public MaterialScrollInfo[] materialInfos;

	// Update is called once per frame
	void Update ()
	{
		foreach(MaterialScrollInfo materialInfo in materialInfos)
		{
			Vector2 oldPosition = materialInfo.material.GetTextureOffset(materialInfo.textureName);
			materialInfo.material.SetTextureOffset(materialInfo.textureName,oldPosition + materialInfo.scrollSpeed*Time.deltaTime);
		}
	}
}
