using UnityEngine;
using System.Collections;

public class RightMissile : MonoBehaviour {

    


	// Use this for initialization
	void Start () {

        gameObject.transform.rotation = Quaternion.Euler(0, 0, 100);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "box" || col.gameObject.tag == "terrain" || col.gameObject.tag == "plane")
        {
            Destroy(this.gameObject);


        }

        if (col.gameObject.tag == "missile")
        {

            Debug.Log("Collided with each other");


        }
    }
}
