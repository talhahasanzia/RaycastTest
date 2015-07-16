using UnityEngine;
using System.Collections;

public class GroundVisual : MonoBehaviour {

	public Camera cam;
  
	// Use this for initialization
	public enum HorizontalAlignment{left, center, right}; 
	public enum VerticalAlignment{top, middle, bottom}; 
	//public HorizontalAlignment horizontalAlignment = HorizontalAlignment.right;
	//public VerticalAlignment verticalAlignment = VerticalAlignment.top; 
	public enum ScreenDimensions{pixels, screen_percentage};
	public ScreenDimensions dimensionsIn = ScreenDimensions. pixels; 
	public int width = 100; 
	public int height= 100;
	public float xOffset = 0f;  
	public float yOffset = 0f;
	public bool  update = true;
	public int hsize, vsize, hloc, vloc;  
	void Start (){ 
		AdjustCamera ();  
	}

	void Update (){

		if(update)  
			AdjustCamera ();
	}
	void AdjustCamera(){  

		hsize = 100;
		vsize = 100;
		xOffset = 2.0f;
		yOffset = 1.0f;
		//hloc = 610;
		//vloc = 250;

		if(dimensionsIn == ScreenDimensions.screen_percentage){
			 Mathf.RoundToInt(width * 0.01f * Screen. width);
			 Mathf.RoundToInt(height * 0.01f * Screen. height);
		} 

		//horizontalAlignment = HorizontalAlignment.right;
		//verticalAlignment = VerticalAlignment.top; 
			hloc = Mathf.RoundToInt((Screen.width - hsize) - (xOffset * 0.01f * Screen.width));
		 
		  

			vloc = Mathf.RoundToInt((Screen.height - vsize) - (yOffset * 0.01f * Screen.height)); 
		        

		cam.pixelRect = new Rect(hloc,vloc,hsize,vsize);  
	}
    
 
}
