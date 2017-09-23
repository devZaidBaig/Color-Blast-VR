using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereActions : MonoBehaviour {

    /*
     * Don't mind this script
     * This is just for selecting and deselecting object
     * Also swaping the objects
     * But I was not able to complete the swapping function
     * Anyways this script isn't important for the project
     * */

    private bool isSelected = false;
    private Color tempColor;
    private sphereActions previousSelect = null;


    public void Select()
    {
        if (isSelected)
        {
            Deselect();
        }
        else if (previousSelect != null)
        {
            Debug.Log("swapping position");
            swapObject(previousSelect.gameObject);
            previousSelect.Deselect();
        }
        else
        {
            tempColor = gameObject.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = new Color(.5f, .5f, .5f, 1f);

            previousSelect = gameObject.GetComponent<sphereActions>();
            isSelected = true;
        }
    }

    private void swapObject(GameObject previousGameObject)
    {
        if (previousGameObject == gameObject)
            return;
        else
        {
            GameObject temp = previousGameObject;
            previousGameObject.transform.position = gameObject.transform.position;
            gameObject.transform.position = temp.transform.position;
        }
    }

    public void Deselect()
    {
        gameObject.GetComponent<Renderer>().material.color = tempColor;
        isSelected = false;
        previousSelect = null;
    }
}
