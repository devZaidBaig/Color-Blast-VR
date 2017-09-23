using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    /*
     * This Script mainly focuses on the shooting,
     * collision with the objects present on the board
     * and instantiating the objects on the board
     */


    public Camera cameraPlayer;
    public Manager manager;
    public int RightColorCollision = 0;

    private Vector3 tempPosition;

    //The lines in the start is to search for these GameObjects without the use of drag and drop
    private void Start()
    {
        //Getting Access to the Manager script for the FireObject
        manager = GameObject.Find("GameManager").GetComponent<Manager>();

        //Access to the camera for the transform components
        cameraPlayer = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Disable gravity to avoid falling of object
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update () {
        //Just for the prototype testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.isHolding = false;

            //Adding force to the FireObject so that it moves like in space with no gravity
            gameObject.GetComponent<Rigidbody>().AddForce(cameraPlayer.transform.forward * 200f);

            //Destroying the object in 3 seconds
            Destroy(gameObject, 3f);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the FireObject is equal to the BoardObject
        if(collision.gameObject.tag == gameObject.tag)
        {
            //Return 1 to increment the player score
            RightColorCollision = 1;
            manager.ScoreUpdate(RightColorCollision);

            //Save the position of the BoardObject before it is destroyed
            tempPosition = collision.gameObject.transform.position;

            //Destroying both the FireObject and BoardObject
            Destroy(collision.gameObject);
            Destroy(gameObject);

            UpdateItems();
        }
        else
        {
            //Decrement the score for mismatch collision
            manager.ScoreUpdate(0);
            Destroy(gameObject);
        }
    }

    //This meathod is to instantiate a object to the destroyed BoardObject
    void UpdateItems()
    {
        //Instantiating a random object from the list and place it on the tempPosition
        GameObject item = Instantiate(manager.BoardObjects[Random.Range(0, manager.FireObjects.Count)]);

        item.transform.position = tempPosition;
    }
}
