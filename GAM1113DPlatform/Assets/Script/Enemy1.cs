using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    public GameObject Player;

    public int enemyDamage;
    private PlayerMovement ScriptMovement;

    public GameObject targetOne, targetTwo,Target;
   

	// Use this for initialization
	void Start () {

        ScriptMovement = Player.GetComponent<PlayerMovement>();
        Target = targetOne;
	}


    private void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "PickUp") 

       {

            ScriptMovement.TakeDamage(enemyDamage);

        }






      }
    
    // Update is called once per frame
    void FixedUpdate () {


        gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position, Target.transform.position,0.1f);
       if(gameObject.transform.position == targetOne.transform.position)
        {
            Target = targetTwo;
        }
        if (gameObject.transform.position == targetTwo.transform.position)
        {
            Target = targetOne;
        }
    }
}
