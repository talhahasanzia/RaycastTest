using UnityEngine;
using System.Collections;

public class Switching : MonoBehaviour {
	public Camera[] cameras; 
	public string[] shortcuts;
	public bool  changeAudioListener = true;
	void  Update (){   
		int i = 0;  
		for(i=0; i<cameras.Length; i++){ 
			if (Input.GetKeyUp(shortcuts[i])) 
				SwitchCamera(i);   
		}  
	}
	void  SwitchCamera ( int index  ){
		int i = 0;   
		for(i=0; i<cameras.Length; i++){ 
					if(i != index){  
						
				cameras[i].enabled=false;
				//cameras[i].GetComponent<AudioListener>().enabled=false;


			} else {
				cameras[i].enabled=true;
				//cameras[i].GetComponent<AudioListener>().enabled=true;
			}     
		}    
	} 
}

