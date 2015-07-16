using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {


    public Texture2D crosshairImage;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = ((Screen.height / 2) - (crosshairImage.height / 2))*(0.6f);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }
}
