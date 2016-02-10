using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{

    public Vector2 velocity = new Vector2(-4, 0);
	public float range;
    // Use this for initialization
    void Start()
    {
		range = Random.Range(-5f,5f);
        GetComponent<Rigidbody2D>().velocity = velocity;
        transform.position = new Vector3(transform.position.x+10, transform.position.y + range, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.x < -10) {
			Destroy (this.gameObject);
		}
    }

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}
}
