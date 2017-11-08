using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWarp : MonoBehaviour {

	public static CameraWarp singleton;

	public GameObject portal = null;

	private Material mat;

	private Camera cam;

	// Use this for initialization
	void Start () {
		singleton = this;
		mat = new Material (Shader.Find ("Portal/WarpEffect"));

		cam = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if(portal == null)
		{
			Graphics.Blit (source, destination);
			return;
		}
		//Debug.Log (cam.WorldToScreenPoint(portal.transform.position));
		Vector3 screenPos = cam.WorldToScreenPoint (portal.transform.position);
		screenPos.x /= Screen.width;
		screenPos.y /= Screen.height;

		mat.SetVector ("_portalCenter", screenPos);
		Graphics.Blit (source, destination, mat);

		GUI.Label (Rect.MinMaxRect (0, 0, 500, 500), "Working");
	}
}
