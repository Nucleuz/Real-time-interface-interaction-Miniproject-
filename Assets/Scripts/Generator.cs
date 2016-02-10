using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public GameObject walls;
    int score = 0;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 1f);
    }

    void Update()
    {

    }

    void CreateObstacle()
    {
        Instantiate(walls);
        score++;
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUILayout.Label(" Score: " + score.ToString());

    }

    void OnBecameInvisible()
    {
        Destroy(GameObject.FindWithTag("Walls"));
    }
}
