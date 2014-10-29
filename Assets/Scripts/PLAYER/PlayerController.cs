using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int lives;
	public int ammo;
	public int metal;
	public int wood;
	public int copper;

	public float speed = 3.0f;

	public Weapon weapon;
	public GameMode gameMode;

	public enum GameMode {COMBAT, CONSTRUCT}
	public enum Weapon {Pistol, MachineGun}

	void Awake()
	{
		gameMode = GameMode.COMBAT;
	}

	void FixedUpdate()
	{
		HandleAnimation ();
		HandleRotation ();
		HandleMovement ();
	}

	void HandleAnimation()
	{
		Animator anim = GetComponent<Animator> ();
		// anim.SetBool ("IsMoving", rigidbody2D.velocity != Vector2.zero);
	}

	void HandleMovement()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rigidbody2D.velocity = new Vector2 (moveHorizontal * speed, moveVertical * speed);
	}

	void HandleRotation()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();
		
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rotZ-90);
	}

	public GameMode CurrentMode
	{
		get { return gameMode; }
		set { gameMode = value; }
	}

}
