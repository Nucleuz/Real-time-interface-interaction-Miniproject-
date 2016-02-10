using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public GameObject walls;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 1f);
    }

    void CreateObstacle()
    {
        GameObject g = Instantiate(walls);
        g.transform.parent = transform;
    }
}
