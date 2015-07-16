using UnityEngine;
using System.Collections;

public class MapCreation : MonoBehaviour {

	public Transform target;
	public Camera cam;

	private Texture2D marker;
	public float camHeight = 1.0f;
	public bool freezeRotation = true;
	public float camDistance = 2.0f;
	public enum ha {left, center, right};
	public enum va {top, middle, bottom};
	public ha horizontalAlignment = ha.left;
	public va verticalAlignment = va.top; 
	public enum sd {pixels, screen_percentage};
	public sd dimensionsIn = sd.pixels;
	public int width = 50;
	public int heigth = 50;
	public float xOffset = 0f;
	public float yOffset = 0f; 

	void Start(){      
		Vector3 angles = transform.eulerAngles;
		angles.x = 90; 
		angles.y = target.transform.eulerAngles.y; 
		transform.eulerAngles = angles;


		Draw();
	}
	void Update(){ 

		transform.position = new Vector3(target.transform. position.x, target.transform.position.y + camHeight, target. transform.position.z);
		cam.orthographicSize = camDistance;

		if (freezeRotation){ 

			Vector3 angles = transform.eulerAngles; 
			angles.y = target.transform.eulerAngles.y; 
			transform.eulerAngles = angles; 
		}  
	}   

	void Draw(){
		 
			int hsize = Mathf.RoundToInt(width * 0.01f * Screen. width);
			int vsize = Mathf.RoundToInt(heigth * 0.01f * Screen. height);
			int hloc = Mathf.RoundToInt(xOffset * 0.01f * Screen. width);;
			int vloc = Mathf.RoundToInt((Screen.height - vsize) - (yOffset * 0.01f * Screen.height));
			
			if(dimensionsIn == sd.screen_percentage){ 
			hsize = Mathf.RoundToInt(width * 0.01f * Screen. width);
			vsize = Mathf.RoundToInt(heigth * 0.01f * Screen. height);
			} else {
			hsize = width; 
			vsize = heigth;  
			}   
			
			switch(horizontalAlignment){ 
			case ha.left:       hloc = Mathf.RoundToInt(xOffset * 0.01f * Screen.width);
			break;  
			case ha.right:       hloc = Mathf.RoundToInt((Screen.width - hsize) - (xOffset * 0.01f * Screen.width)); 
			break;
			case ha.center:       hloc = Mathf.RoundToInt(((Screen.width * 0.5f) - (hsize * 0.5f)) - (xOffset * 0.01f * Screen.height));
			break;
			}  
			switch(verticalAlignment){
			case va.top:       vloc = Mathf.RoundToInt((Screen.height - vsize) - (yOffset * 0.01f * Screen.height));
			break;
			case va.bottom:       vloc = Mathf.RoundToInt(yOffset * 0.01f * Screen.height);
			break;    
			case va.middle:       vloc = Mathf.RoundToInt(((Screen.height * 0.5f) - (vsize * 0.5f)) - (yOffset * 0.01f * Screen.height));
			break; 
		}
		cam.pixelRect = new Rect(hloc,vloc,hsize,vsize);
	}

	void OnGUI(){
		try{
		Vector3 markerPos = cam.WorldToViewportPoint  (target.position);
		int pointX =  Mathf.RoundToInt((cam.pixelRect.xMin + cam.pixelRect.xMax) * markerPos.x);


		int pointY =  Mathf.RoundToInt(Screen.height - (cam. pixelRect.yMin + cam.pixelRect.yMax) * markerPos.y);
		marker=new Texture2D (cam.targetTexture.width, cam.targetTexture.height);

		GUI.DrawTexture( new Rect(pointX-(marker.width * 0.5f),pointY-(marker.height * 0.5f),marker.width,marker.height), marker, ScaleMode.StretchToFill, true, 0.0f);
		}
		catch(System.NullReferenceException ex)
		{
			ex.ToString();
		}
	
	
	}
}
