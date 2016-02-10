using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float moveForce = 365f;
	public float moveSpeed = 25f;
    public Vector2 jumpForce = new Vector2(0, 200);
	private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		rb2d.velocity = new Vector2 (h * moveSpeed, v * moveSpeed);
		/*
		if(h*rb2d.velocity.x < maxSpeed){
			rb2d.AddForce(Vector2.right * h * moveForce);
		}

		if(Mathf.Abs(rb2d.velocity.x) > maxSpeed){
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}*/
    }

    public void Jump()
    {
		rb2d.velocity = Vector2.zero;
        rb2d.AddForce(jumpForce);
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
