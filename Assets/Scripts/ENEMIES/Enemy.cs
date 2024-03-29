﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject[] drop;
	public float health;
	public GameObject player;

	protected float speed;
	void Awake()
	{
		player = GameObject.Find("Player");
	} // void Awake()

	// Is called by Animation Event at end of ZombieDead animation
	protected void DeleteObject()
	{
		//drop an item.
		GameObject item = Instantiate(drop[Random.Range(0,drop.Length)], transform.position, Quaternion.identity) as GameObject;
		item.GetComponent<ItemController>().Amount = 10;


		Destroy (this.gameObject);
	} // void DeleteObject()
	
	void Die()
	{
		GetComponent<Animator> ().SetBool ("IsDead", true);
	} // void Die()

	void FixedUpdate()
	{
		if (IsAlive()) {
			HandleMovement ();
		}
	} // void FixedUpdate()

	void HandleMovement()
	{
		float rotz = Mathf.Atan2 ((player.transform.position.y - transform.position.y),
		                          (player.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		
		transform.eulerAngles = new Vector3(0, 0, rotz);
		rigidbody2D.AddForce(gameObject.transform.up * speed);
	}

	public bool IsAlive()
	{
		return health > 0;
	} // public bool IsAlive()

	protected virtual void Knockback(BulletController other)
	{
		float rotz = Mathf.Atan2 ((other.transform.position.y - transform.position.y),
		                          (other.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		
		transform.eulerAngles = new Vector3(0, 0, rotz);
		rigidbody2D.AddForce(gameObject.transform.up * (-other.Knockback * 10));
			// Debug.Log("knockedback!");
		
	} // void Knockback(BulletController other)
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet" && IsAlive()) {
			BulletController bullet = other.gameObject.GetComponent<BulletController>();
			GetHit(bullet);
		} // if (other.tag == "Bullet") {

	} // void OnTriggerEnter2D(Collider2D other)
	
	protected virtual void GetHit(BulletController bullet) {
		if ((health -= bullet.Damage) <= 0)
		{
			Die ();
		}//if ((health -= bullet.Damage) <= 0)
		else
		{
			Knockback(bullet);
		} // else
		bullet.Deactivate();
	}

	protected virtual void VAwake () {
		Awake ();
	}

	protected virtual void VFixedUpdate() {
		FixedUpdate ();
	}


}
