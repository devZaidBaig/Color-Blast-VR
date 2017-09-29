using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public GameObject target;

    public void DestroyScriptInstance()
    {
        // Destroys the target sphere when targeted by the player
        Destroy(target);
        Debug.Log("destruction attempted");
    }
}
