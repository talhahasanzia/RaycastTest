using UnityEngine;
using System.Collections;

public class AntiAircraft : MonoBehaviour {

	Rigidbody rg_obj;
    public GameObject StartPosition;
    
    float calculatedDistance, HitDistance = 80;

    public GameObject PlayerAircraft;

	int randomX,randomZ;
	// Use this for initialization
	void Start () {


       
        rg_obj = gameObject.GetComponent<Rigidbody>();


        rg_obj.useGravity = false;
        
        
            
        
	}
	
	// Update is called once per frame
	void Update () {

        if (rg_obj.velocity.y < 0)
        {


            rg_obj.useGravity = false;
            gameObject.transform.position = StartPosition.transform.position;
            
        
        }

        if ( canHit())
        {
            rg_obj = gameObject.GetComponent<Rigidbody>();
            rg_obj.velocity = Vector3.zero;
            rg_obj.angularVelocity = Vector3.zero;
            randomX = Random.Range(-120, 120);
            randomZ = Random.Range(-300, 300);
            rg_obj.AddForce(randomX, 300, randomZ);
            rg_obj.useGravity = true;
        }          



        
        
      




			}




    bool canHit()
    {


        calculatedDistance = (PlayerAircraft.transform.position - StartPosition.transform.position).magnitude;



        if (calculatedDistance < HitDistance)
        {



            return true;

        }
        else
        {


            return false;

        }


    }
	void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.tag == "terrain" || col.gameObject.tag == "plane" || gameObject.transform.position.y>20)
        {
            rg_obj.useGravity = false;
            gameObject.transform.position = StartPosition.transform.position;
            
            //Destroy(gameObject);

           
        }


	}
}
