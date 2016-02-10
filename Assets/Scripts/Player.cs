using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float moveForce = 365f;
	public float moveSpeed = 25f;
    public Vector2 jumpForce = new Vector2(0, 200);
	private Rigidbody2D rb2d;

    public GameObject projectile;

    public int healthPoints = 5;

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

        // Move the player by calculating with moveSpeed
		rb2d.velocity = new Vector2 (h * moveSpeed, v * moveSpeed);

        // Shoot if key is pressed
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    public void Jump()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(jumpForce);
    }

    public void Shoot()
    {
        GameObject g = (GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        
        g.transform.parent = GameObject.Find("ProjectileContainer").transform;
    }

    public int DecreaseHealthPoints()
    {
        healthPoints--;
        return healthPoints;
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
