using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    public float speed = 1f;

    private int direction = 1;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);


		
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            if (direction == 1)
                direction = -1;

            else
                direction = 1;
        }
        if (other.tag == "Player")
        {
            other.transform.parent = transform;

        }
  
        

    }
}
