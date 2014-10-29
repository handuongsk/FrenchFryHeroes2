using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public int health;
	float speed = 3.0f;
	public GameObject player;
	
	void Awake()
	{
		player = GameObject.Find("Player");
	}
	
	void FixedUpdate()
	{
		HandleMovement();
		
	}
	
	void HandleMovement()
	{
		float rotz = Mathf.Atan2 ((player.transform.position.y - transform.position.y),
		                          (player.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		
		transform.eulerAngles = new Vector3(0, 0, rotz);
		rigidbody2D.AddForce(gameObject.transform.up * speed);
	}

	void Die()
	{
		//Perform death animations and play death throes.
		Destroy (this.gameObject);
	}

	void Knockback(Transform other)
	{
		float rotz = Mathf.Atan2 ((other.transform.position.y - transform.position.y),
		                          (other.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		
		transform.eulerAngles = new Vector3(0, 0, rotz);
		rigidbody2D.AddForce(gameObject.transform.up * -300);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			other.gameObject.GetComponent<BulletController>().Deactivate();
			
			if (--health <= 0)
			{
				Die ();
			}
			else
			{
				Knockback(other.transform);
			}
		}
	}
}
