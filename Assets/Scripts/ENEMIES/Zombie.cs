using UnityEngine;
using System.Collections;

public class Zombie : Enemy {
	void Awake()
	{
		VAwake ();
		speed = 3.0f;
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()
} // public class Zombie : Enemy {
