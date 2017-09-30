using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    Vector3 position = new Vector3();
    float rotationSpeed;
    

    // Use this for initialization
    void Start () {

        // Gets the rotation speed from the TargetRotator script
        rotationSpeed = GetComponentInParent<TargetRotator>().GetRotationSpeed();
    }
	
	// Update is called once per frame
	void Update () {

        position = transform.position;

        // if a rotating target sphere is close engough to any collider in the scene the rotation speed is set to zero
        if (Physics.Raycast(position, -1*GetComponentInParent<Transform>().right, 5f))
        {
            GetComponentInParent<TargetRotator>().SetRotationSpeed(0);
        }
        else
        {
            GetComponentInParent<TargetRotator>().SetRotationSpeed(rotationSpeed);
        }
	}
}
