using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    /*
     * Hello everyone, this is a very basic prototype scripting of this project
     * I'm only done with the shooting of objects instantiated randomly
     * Also a very basic scoring system for now
     * Do contact me if you have any doubts with the code
     * And feel free to make changes to the script :)
     * */

    public GameObject Player;

    //List of objects for the player to shoot on the board
    public List<GameObject> FireObjects = new List<GameObject>();

    //List of objects for the board to instantiate after it gets destroyed
    public List<GameObject> BoardObjects = new List<GameObject>();
    public GameObject BallHolder;
    public Text scoreCounter;

    private int score = 0;
    private GameObject FireObject;

    public bool isHolding = false;
    public int increase_score = 10;

    void Update()
    {
        //To check if the player is holding the FireObject or not
        if (isHolding == false)
        {
            //To call the function after 2 seconds after this line is compiled
            Invoke("InstantiateFireObject", 2);
            //Now the user is holding the FireObject
            isHolding = true;
        }
    }

    //This meathod helps to instantiate a object from the FireObject list
    public void InstantiateFireObject()
    {
        //Instantiate a random object from the list
        FireObject = Instantiate(FireObjects[Random.Range(0,FireObjects.Count)]);
        //Place the object on the ball holder gameobject position
        FireObject.transform.position =  BallHolder.transform.position;
        isHolding = true;
    }

    public void ScoreUpdate(int result)
    {
        //Checking if collision is a match or not
        switch (result)
        {
            case 1:
                //For a normal match, incrementing the score
                score += increase_score;
                break;

            case 2:
                //For the 3 match situation
                break;

            default:
                //For a mismatch, decrementing the score
                score -= increase_score;
                break;
        }

        //Display the score
        scoreCounter.text = score.ToString();
    }

}
