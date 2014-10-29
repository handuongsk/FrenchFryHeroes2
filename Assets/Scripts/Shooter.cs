using UnityEngine;

public class Shooter : MonoBehaviour {
	// Public fields
	public GameObject bulletPrefab;
	public float bulletSpeed;
	public float repeatTime;
	public int maxNumberOfBullets;
	
	private BulletPool bulletPool;
	private float timeSinceLastAttack;
	
	void Start () {
		bulletPool = ScriptableObject.CreateInstance ("BulletPool") as BulletPool;
		bulletPool.Initialize(maxNumberOfBullets, bulletPrefab, bulletSpeed);
		timeSinceLastAttack = 0;


	} // void Start () {
	
	void Update () {
		timeSinceLastAttack += Time.deltaTime;
		if (GetComponent<Turret>().target != null && timeSinceLastAttack > repeatTime) {
			bulletPool.ActivateBullet (transform.position, GetComponent<Turret>().target.transform.position );
			timeSinceLastAttack = 0;
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	}// void Update ()
} // public class MouseShooter : MonoBehaviour
