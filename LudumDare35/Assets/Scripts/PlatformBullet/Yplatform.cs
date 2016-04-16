using UnityEngine;
using System.Collections;

public class Yplatform : MonoBehaviour 
{
	bool canChnage = false;
	bool canMove = true;

	float maxY = 5;
	float minY = 0.1f;
	float origin = 1;
	float offset = 0.0001f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( Input.GetKey(KeyCode.K) )
		{
			CancelInvoke();
			canChnage = false;
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
				transform.localScale = new Vector3( 1, transform.localScale.y - offset, 1 );
			}
			else
			{
				transform.localScale = new Vector3( 1, origin, 1 );
			}
		}

		if( transform.localScale.y < origin )
		{
			if(transform.localScale.y+offset <= origin)
			{
				transform.localScale = new Vector3( 1, transform.localScale.y + offset , 1 );
			}
			else
			{
				transform.localScale = new Vector3( 1, origin, 1 );
			}
		}
	}

	void Scale()
	{
		if(Input.GetAxis("Horizontal") > 0 && canMove)
		{
			if(transform.localScale.y + offset < maxY)
			{
				transform.localScale = new Vector3( 1, transform.localScale.y + offset , 1 );
			}
		}

		if(Input.GetAxis("Horizontal") < 0 )
		{
			if(transform.localScale.y - offset > minY)
			{
				transform.localScale = new Vector3( 1, transform.localScale.y - offset , 1 );
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