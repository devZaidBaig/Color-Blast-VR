using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject target0;
    public GameObject target1;
    public GameObject target2;

    // Use this for initialization
    void Start() {
        InvokeRepeating("InstantiateTarget0", 0.5f, 0.5f);
        InvokeRepeating("InstantiateTarget1", 0.6f, 0.5f);
        InvokeRepeating("InstantiateTarget2", 0.7f, 0.5f);
    }

    void InstantiateTarget0()
    {
        if(!Physics.Raycast(new Vector3 (0, target0.transform.position.y, 5), new Vector3 (-1,0,-0.1f), 2f))
        {
            Instantiate(target0, target0.transform.position, target0.transform.rotation);
            Debug.Log("hello from the target1 method");
        }
    }

    void InstantiateTarget1()
    {
        if (!Physics.Raycast(new Vector3(0, target1.transform.position.y, 5), new Vector3(-1, 0, -0.1f), 2f))
        {
            Instantiate(target1, target1.transform.position, target1.transform.rotation);
        }
    }

    void InstantiateTarget2()
    {
        if (!Physics.Raycast(new Vector3(0, target2.transform.position.y, 5), new Vector3(-1, 0, -0.1f), 2f))
        {
            Instantiate(target2, target2.transform.position, target2.transform.rotation);
        }
    }
}
