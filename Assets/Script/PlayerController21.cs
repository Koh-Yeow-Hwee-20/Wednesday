using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController21 : MonoBehaviour
{
    float boundaryLimit = 19.0f;
    float jumpForce = 8.0f;
    float moveForce = 8.0f;
    float gravityModifier = 1.2f;

    float initYPos = 5;
    float nextYPos;

    int spaceTrack = 0;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        float initYPos = 1000;

        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;

        Debug.Log(initYPos);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Prevent reverse moment out-of-bound
        if (transform.position.z < -boundaryLimit)
        {
            print("Has reached reverse Z-Axis Limit : " + transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundaryLimit);
        }
        //Prevent forward moment out-of-bound
        if (transform.position.z > boundaryLimit)
        {
            print("Has reached forward Z-Axis Limit : " + transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, boundaryLimit);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveForce * verticalInput);
        }

        //Prevent left moment out-of-bound
        if (transform.position.x < -boundaryLimit)
        {
            Debug.Log("LEFT BOUNDARY REACHED");
            transform.position = new Vector3(-boundaryLimit, transform.position.y, transform.position.z);
        }
        //Prevent right moment out-of-bound
        else if (transform.position.x > boundaryLimit)
        {
            transform.position = new Vector3(boundaryLimit, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveForce * horizontalInput);
        }

        JumpPlayer();
    }

       //From UnityEngine - Event Listener for a collision by te GameObject "Player" with another possible GameObject
       private void OnCollisionEnter(Collision collision)
       {
           if (collision.gameObject.CompareTag("Ground"))
           {
              spaceTrack = 0;
           }
       }
   
    /*
    private void JumpPlayer()
    {

        if (Input.GetKeyDown(KeyCode.Space) && spaceTrack < 2)
        {
            //Debug.Log(initYPos);

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);       
    
            //Track my jump if single jump or double jump
            spaceTrack++;

            Debug.Log(spaceTrack);
        }
        */

    //Your own method call

    private void JumpPlayer()
       {

            if (Input.GetKeyDown(KeyCode.Space))
            {
            //Track my jump if single jump or double jump
            spaceTrack++;
           
            //Debug.Log(initYPos);
            
            if (spaceTrack == 2)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

                Debug.Log(spaceTrack);
            }
       }
}
