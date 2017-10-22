using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {





    public Text gameOverText;

 
    
    public float speed;

    private Rigidbody rb;

    public Text CountText;

    public Text Life;

    private int Count;

    public int Health, maxHealth;

    private Animator Anim;

    public float rotateSpeed;

    public Text youWin;

    public GameObject homeButton;
    


	// Use this for initialization
	void Start () {

        

        gameOverText.enabled = false;
        youWin.enabled = false;
        homeButton.SetActive(false);
        Health = maxHealth;

        rb = GetComponent<Rigidbody>();

        Anim = gameObject.GetComponent<Animator>();

        


	}

    // Update is called once per frame
    void FixedUpdate() {



        Life.text = Health.ToString();




        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float heading = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg;    

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

      

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10f);

    

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 250f);
        }
        transform.Rotate(0, moveHorizontal, 0);

        // based on the input from the player, we change the value of the boolean in the animator controller that takes care of the transitions of the animation.

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            Anim.SetBool("isWalking", false);
        } 
        else
        {
            Anim.SetBool("isWalking", true);
        }

        // rotates the player based on his velocity

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            rb.rotation = Quaternion.Euler(0, heading, 0);
        }

    }


    

    //PICKUP OBJECT  &&  EndGame object
    void OnTriggerEnter(Collider other)

        {

        if (other.gameObject.CompareTag("End"))

        {              
            youWin.enabled = true;
            homeButton.SetActive(true);
            Time.timeScale = 0;
        }
        


            if (other.gameObject.CompareTag ("PickUp"))
            {

            other.gameObject.SetActive(false);

            Count = Count + 1;
            SetCountText();

            }
     
        }

    // UPDATE THE TEXT FOR BOTH LIFE AND SCORE IN GAME 


    void SetCountText ()
    {
        CountText.text = "Count :" + Count.ToString();
    }

    // this function is to get input from the enemies to apply how much damage they want.
    public void TakeDamage  (int Damage)
    {
        Health -= Damage;
        if (Health <= -1)
        {

            gameOverText.text = "Game Over";
            gameOverText.enabled = true;
            Time.timeScale = 0;
        }




    }

}
