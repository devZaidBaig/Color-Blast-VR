using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotator : MonoBehaviour {
    public float rotationSpeed = 1f;
    
    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        // Rotates the target sphere prefab with a defined rotationSpeed
        transform.Rotate(0, -(rotationSpeed * Time.deltaTime), 0);
	}

    
}
