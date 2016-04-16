using UnityEngine;
using System.Collections;

public class Yplatform : MonoBehaviour 
{
	GameObject player;

	bool canChnage = false;
	bool canMove = true;

	float maxY = 3;
	float minY = 0.3f;
	float origin = 1;
	float offset = 0.0005f;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		maxY = transform.localScale.y + 3;
		origin = transform.localScale.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( Input.GetKey(KeyCode.K) )
		{
			CancelInvoke();
			canChnage = false;

			player.GetComponent<PlayerMovement>().enabled = true;
			player.GetComponent<PlayerGrenade>().enabled = true;
			player.GetComponent<PlayerShoot>().enabled = true;
		}

		if( !canChnage && transform.localScale.y != origin )
		{
			InvokeRepeating("Return", 0, 0.05f);
		}

		if( !canChnage && transform.localScale.y == origin )
		{
			CancelInvoke();
		}

		if( canChnage )
		{
			InvokeRepeating("Scale", 0, 0.05f);
		}
	}

	void Return()
	{
		if( transform.localScale.y > origin )
		{
			if(transform.localScale.y-offset >= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y - offset, 1 );
			}
			else
			{
				transform.localScale = new Vector3( transform.localScale.x, origin, 1 );
			}
		}

		if( transform.localScale.y < origin )
		{
			if(transform.localScale.y+offset <= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y + offset , 1 );
			}
			else
			{
				transform.localScale = new Vector3( transform.localScale.x, origin, 1 );
			}
		}
	}

	void Scale()
	{
		if(Input.GetAxis("Horizontal") > 0 && canMove)
		{
			if(transform.localScale.y + offset < maxY)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y + offset , 1 );
			}
		}

		if(Input.GetAxis("Horizontal") < 0 )
		{
			if(transform.localScale.y - offset > minY)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y - offset , 1 );
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.tag == "Bullet" )
		{
			canChnage = true;

			player.GetComponent<PlayerMovement>().enabled = false;
			player.GetComponent<PlayerGrenade>().enabled = false;
			player.GetComponent<PlayerShoot>().enabled = false;
		}

		if( coll.tag == "Platform" )
		{
			canMove = false;
			Debug.Log("Y-Platform");
		}
		Debug.Log("Y-CollissionEnter");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if( coll.tag == "Platform" )
		{
			canMove = true;
		}
	}
}