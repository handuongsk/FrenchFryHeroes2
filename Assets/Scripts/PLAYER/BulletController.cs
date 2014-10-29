using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	// Private fields
	private bool isActive;
	private float moveSpeed;

	protected void Start () {
		isActive = false;
		renderer.enabled = false;
	} // void Start () {
	
	void Update () {
	}// void Update ()

	public void Activate(Vector3 startingPosition, Vector3 targetPosition) {
		transform.position = startingPosition;
		Vector3 target = (targetPosition - startingPosition);
		Vector2 speed = new Vector2 (target.x, target.y);
		rigidbody2D.velocity = speed.normalized * moveSpeed;
		
		float targetAngle = Mathf.Atan2 (targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, targetAngle - 90);

		isActive = true;
		renderer.enabled = true;
	}// public void ActivateBullet(Vector3 startingPosition, Vector3 targetPosition)

	public void OnBecameInvisible() {
		//Debug.Log ("I am disabled!");
		Deactivate();
	}// public void OnBecameInvisible()

	public void Deactivate() {
		isActive = false;
		renderer.enabled = false;
		rigidbody2D.velocity = Vector2.zero;
	}// public DeactivateBullet(

	public bool IsActive { 
		get {return isActive;}
	}// public bool IsActive{

	public void SetSpeed(float speed) {
		moveSpeed = speed;
	}// public void SetSpeed(float speed)
} //public class BulletController : MonoBehaviour {
