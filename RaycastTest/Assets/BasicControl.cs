using UnityEngine;
using System.Collections;

public class BasicControl : MonoBehaviour {

    public float x = 10, y = 0, z = 0; // angles
    
    
    
    public GameObject AirCraft;
	public GameObject rayCastOrigin;
	
    RaycastHit RayHit;
    
	
	
	
	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update ()
    {



        if (Physics.Raycast(rayCastOrigin.transform.position, Quaternion.Euler(x, y, z) * transform.forward, out RayHit, Mathf.Infinity))
        {

            Debug.DrawLine(rayCastOrigin.transform.position, RayHit.point, Color.red);
        
        }

       
		
		
	
		
	}



   


}
