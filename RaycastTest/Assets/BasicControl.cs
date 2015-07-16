using UnityEngine;
using System.Collections;

public class BasicControl : MonoBehaviour {

    public float x = 10, y = -90, z = 0;
    
    
    
    public GameObject AirCraft;
	public GameObject rayCastOrigin;
	public GameObject LMissile;
    public GameObject RMissile;
    RaycastHit RayHit;
    bool SwitchMissile;
	bool Launch=false;
    public bool BothMissiles = false;
	public GameObject LeftMissilePos;
    public GameObject RightMissilePos;
	//public float AngleX,AngleY,AngleZ;
	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update ()
    {



        if (Physics.Raycast(rayCastOrigin.transform.position, Quaternion.Euler(10, -90, z) * transform.forward, out RayHit, Mathf.Infinity))
        {

            Debug.DrawLine(rayCastOrigin.transform.position, RayHit.point, Color.red);
        
        }

        if((Input.GetKey(KeyCode.UpArrow)))
        {

            gameObject.transform.Translate(-transform.right * 0.8f);
        
        }
        if ((Input.GetKey(KeyCode.DownArrow)))
        {

            gameObject.transform.Translate(-transform.right * 0.3f);

        }
        else
        {
           // gameObject.transform.Translate(-transform.right * 0.5f);
        }
		if (Input.GetKeyUp (KeyCode.Space)) {
			Launch=true;		
		
		}
		
			if(Launch)
			{



                MissileLaunch();
                Launch = false;

			}
			

		
		
	if(Input.GetKey(KeyCode.LeftArrow))
		   {

			AirCraft.transform.position=new Vector3(AirCraft.transform.position.x,AirCraft.transform.position.y,AirCraft.transform.position.z-1);
		}
		if(Input.GetKey(KeyCode.RightArrow))
            
		   {
			
			AirCraft.transform.position=new Vector3(AirCraft.transform.position.x,AirCraft.transform.position.y,AirCraft.transform.position.z+1);
		}
		
	}



    void MissileLaunch()
    {


        if (BothMissiles)
        {



            GameObject missileLeft;
            missileLeft = (GameObject)Instantiate(LMissile, LeftMissilePos.transform.position, LMissile.transform.rotation);

            Rigidbody rgLeft = missileLeft.GetComponent<Rigidbody>();


            // left missile
            rgLeft.AddForce(-6500, -1200, 250);



            GameObject missileRight;
            missileRight = (GameObject)Instantiate(RMissile, RightMissilePos.transform.position, RMissile.transform.rotation);

            Rigidbody rgRight = missileRight.GetComponent<Rigidbody>();
            // right missile
            rgRight.AddForce(-6500, -1200, -250);




            BothMissiles = false;

        }
        else
        {
            if (SwitchMissile)
            {
                //LeftMissileLaunch();


                GameObject missileLeft;
                missileLeft = (GameObject)Instantiate(LMissile, LeftMissilePos.transform.position, LMissile.transform.rotation);

                Rigidbody rgLeft = missileLeft.GetComponent<Rigidbody>();


                // left missile
                rgLeft.AddForce(-6500, -1200, 250);

                SwitchMissile = false;
            }
            else
            {
                GameObject missileRight;
                missileRight = (GameObject)Instantiate(RMissile, RightMissilePos.transform.position, RMissile.transform.rotation);

                Rigidbody rgRight = missileRight.GetComponent<Rigidbody>();
                // right missile
                rgRight.AddForce(-6500, -1200, -250);
                SwitchMissile = true;
            }
        }
        
    
    }


}
