using UnityEngine;
using System.Collections;

public class Xplatform : MonoBehaviour 
{
	bool canChnage = false;
	bool canMove = true;

	float maxX = 3;
	float minX = 0.3f;
	float origin = 1;
	float offset = 0.0001f;

	// Use this for initialization
	void Start () 
	{
		
		maxX = transform.localScale.x + 3;
		origin = transform.localScale.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( Input.GetKey(KeyCode.K) )
		{
			CancelInvoke();
			canChnage = false;
		}

		if( !canChnage && transform.localScale.x != origin )
		{
			InvokeRepeating("Return", 0, 0.05f);
		}

		if( !canChnage && transform.localScale.x == origin )
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
		if( transform.localScale.x > origin )
		{
			if(transform.localScale.x-offset >= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x - offset, transform.localScale.y , 1 );
			}
			else
			{
				transform.localScale = new Vector3( origin, transform.localScale.y , 1 );
			}
		}

		if( transform.localScale.x < origin )
		{
			if(transform.localScale.x+offset <= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x + offset,  transform.localScale.y , 1 );
			}
			else
			{
				transform.localScale = new Vector3( origin,  transform.localScale.y , 1 );
			}
		}
	}

	void Scale()
	{
		if(Input.GetAxis("Horizontal") > 0)
		{
			if(transform.localScale.x + offset < maxX && canMove)
			{
				transform.localScale = new Vector3( transform.localScale.x + offset,  transform.localScale.y , 1 );
			}
		}

		if(Input.GetAxis("Horizontal") < 0)
		{
			if(transform.localScale.x - offset > minX)
			{
				transform.localScale = new Vector3( transform.localScale.x - offset, transform.localScale.y , 1 );
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.tag == "Bullet" )
		{
			canChnage = true;
		}

		if( coll.tag == "Platform" )
		{
			canMove = false;
			Debug.Log("Platform");
		}
		Debug.Log("CollissionEnter");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if( coll.tag == "Platform" )
		{
			canMove = true;
		}
	}
}