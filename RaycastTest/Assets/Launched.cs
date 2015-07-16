using UnityEngine;
using System.Collections;

public class Launched : MonoBehaviour {
	public GameObject StartPosition;
    Rigidbody PhysicsComponent;
	// Use this for initialization
	void Start () {

        PhysicsComponent = gameObject.GetComponent<Rigidbody>();


	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnCollisionEnter(Collision col)
	{

     
            

        if (col.gameObject.tag == "missile" || col.gameObject.tag == "terrain" || col.gameObject.tag == "plane")
		   {
              gameObject.transform.position = StartPosition.transform.position;
              PhysicsComponent.useGravity = false;
              PhysicsComponent.velocity = Vector3.zero;
              PhysicsComponent.angularVelocity = Vector3.zero;

		}



	}
}
