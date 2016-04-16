using UnityEngine;
using System.Collections;

public class Yplatform : MonoBehaviour 
{
	bool canChnage = false;

	float maxX = 5;
	float minX = 0.1f;
	float origin = 1;
	float offset = 0.0005f;

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

		if( !canChnage && transform.localScale.x != origin )
		{
			InvokeRepeating("Return", 0, 0.1f);
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
				transform.localScale = new Vector3( transform.localScale.x - offset, 1 , 1 );
			}
			else
			{
				transform.localScale = new Vector3( origin, 1 , 1 );
			}
		}

		if( transform.localScale.x < origin )
		{
			if(transform.localScale.x+offset <= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x + offset, 1 , 1 );
			}
			else
			{
				transform.localScale = new Vector3( origin, 1 , 1 );
			}
		}
	}

	void Scale()
	{
		if(Input.GetAxis("Horizontal") > 0)
		{
			if(transform.localScale.x + offset < maxX)
			{
				transform.localScale = new Vector3( transform.localScale.x + offset, 1 , 1 );
			}
		}

		if(Input.GetAxis("Horizontal") < 0)
		{
			if(transform.localScale.x - offset > minX)
			{
				transform.localScale = new Vector3( transform.localScale.x - offset, 1 , 1 );
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if( coll.gameObject.tag == "Bullet" )
		{
			canChnage = true;
		}
	}
}