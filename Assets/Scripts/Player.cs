using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Vector2 jumpForce = new Vector2(0, 200);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    Die();
    //}

    //void Die()
    //{
    //    Application.LoadLevel(Application.loadedLevel);
    //}
}
