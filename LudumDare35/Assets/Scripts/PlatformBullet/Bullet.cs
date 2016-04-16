﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rb;
	float speed = 5f;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.velocity = new Vector2( speed, 0 );
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if( coll.gameObject.tag == "Platform" )
		{
			Destroy(this.gameObject, 0);
		}
	}
}