using UnityEngine;

public class Shooter : MonoBehaviour {
	// Public fields
	public GameObject bulletPrefab;
	public float bulletDamage;
	public float bulletKnockback;
	public float bulletSpeed;
	public float repeatTime;
	public int maxNumberOfBullets;
	
	protected BulletPool bulletPool;
	protected float timeSinceLastAttack;
	
	void Start () {
		bulletPool = ScriptableObject.CreateInstance ("BulletPool") as BulletPool;
		bulletPool.Initialize(maxNumberOfBullets, bulletPrefab, bulletDamage, bulletKnockback, bulletSpeed);
		timeSinceLastAttack = 0;
	} // void Start () {
	
	void Update () {
		timeSinceLastAttack += Time.deltaTime;
		Shoot ();
	}// void Update ()

	protected virtual void Shoot(){
		if (GetComponent<Turret>().target != null && GetComponent<Turret>().target.IsAlive()
		    	&& timeSinceLastAttack > repeatTime) {
			bulletPool.ActivateBullet (transform.position, GetComponent<Turret>().target.transform.position );
			timeSinceLastAttack = 0;
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	}

	protected virtual void VStart () {
		Start();
	} // protected virtual void VStart () {
} // public class MouseShooter : MonoBehaviour
