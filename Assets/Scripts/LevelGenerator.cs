using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public List<GameObject> ColoredSpheres;
    public GameObject target0;
    public GameObject target1;
    public GameObject target2;

    private List<GameObject> possibleSpheres;
    private GameObject horizontalSphere;            //stores top layer sphere so that it doesn't repeat in the next top layer sphere
    private GameObject horizontalSphere1;           //stores bottom layer sphere
    private GameObject previousSphere;              //stores top layer sphere so that it doesnt repeat in middle layer
    private GameObject sphere;
    // Use this for initialization
    void Start() {
        possibleSpheres = new List<GameObject>();
        possibleSpheres.AddRange(ColoredSpheres);
        previousSphere = null;
        InvokeRepeating("InstantiateTarget0", 0.6f, 0.5f);
        InvokeRepeating("InstantiateTarget1", 0.6f, 0.5f);
        InvokeRepeating("InstantiateTarget2", 0.6f, 0.5f);
    }

    void InstantiateTarget0()
    {
        if(!Physics.Raycast(new Vector3 (0, target0.transform.position.y, 5), new Vector3 (-1,0,-0.1f), 2f))
        {
            sphere = ColoredSpheres[Random.Range(0, ColoredSpheres.Count)];

            if (horizontalSphere == sphere)
            {
                ColoredSpheres.Remove(horizontalSphere);
                sphere = ColoredSpheres[Random.Range(0, ColoredSpheres.Count)];
                horizontalSphere = sphere;
            }
            else
            {
                horizontalSphere = sphere;
                Debug.Log("Stored");
            }

            Debug.Log(sphere.name);
            previousSphere = sphere;

            Instantiate(sphere, target0.transform.position, target0.transform.rotation);
            ColoredSpheres.Add(sphere);
        }
    }

    void InstantiateTarget1()
    {
        if (!Physics.Raycast(new Vector3(0, target1.transform.position.y, 5), new Vector3(-1, 0, -0.1f), 2f))
        {
            possibleSpheres.Remove(previousSphere);
            Instantiate(possibleSpheres[Random.Range(0, possibleSpheres.Count)], target1.transform.position, target1.transform.rotation);
            possibleSpheres.Add(previousSphere);
        }
    }

    void InstantiateTarget2()
    {
        if (!Physics.Raycast(new Vector3(0, target2.transform.position.y, 5), new Vector3(-1, 0, -0.1f), 2f))
        {
            sphere = ColoredSpheres[Random.Range(0, ColoredSpheres.Count)];

            if (horizontalSphere1 == sphere)
            {
                ColoredSpheres.Remove(horizontalSphere1);
                sphere = ColoredSpheres[Random.Range(0, ColoredSpheres.Count)];
                horizontalSphere1 = sphere;
            }
            else
            {
                horizontalSphere1 = sphere;
            }

            Instantiate(sphere, target2.transform.position, target2.transform.rotation);
            ColoredSpheres.Add(sphere);
        }
    }
}
