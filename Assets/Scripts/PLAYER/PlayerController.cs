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
	public enum Weapon {PISTOL, MACHINEGUN}

	void Awake()
	{
		gameMode = GameMode.COMBAT;
	}

    void Update()
    {
        HandleInput();
    }

	void FixedUpdate()
	{
		HandleAnimation ();
		HandleRotation ();
		HandleMovement ();
	}

	void HandleAnimation()
	{
		//Animator anim = GetComponent<Animator> ();
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

    void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CurrentMode == GameMode.COMBAT)
            {
                CurrentMode = GameMode.CONSTRUCT;
                Debug.Log("CONSTRUCT MODE ENABLED");
            }
            else
            {
                CurrentMode = GameMode.COMBAT;
                Debug.Log("COMBAT MODE ENABLED");
            }
        }
    }

	public GameMode CurrentMode
	{
		get { return gameMode; }
		set { gameMode = value; }
	}

    public int Lives { get { return lives; } } 
    public int Ammo { get { return ammo; } }
    public int Metal { get { return metal; } }
    public int Wood { get { return wood; } }
    public int Copper { get { return copper; } }

}
