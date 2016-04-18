using UnityEngine;
using System.Collections;

public class Xplatform : MonoBehaviour 
{
	bool canChnage = false;
	bool canMove = true;

	public float maxX = 3;
	float minX = 0.3f;
	float origin = 1;
	float offset = 0.01f;

	// Use this for initialization
	void Start () 
	{
		maxX = transform.localScale.x + maxX;
		origin = transform.localScale.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( Input.GetKey(KeyCode.LeftShift) )
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
			InvokeRepeating("Scale", 0, 0.005f);
		}
	}

	void Return()
	{
		if( transform.localScale.x > origin )
		{
			if(transform.localScale.x-offset >= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x - offset*Time.deltaTime, transform.localScale.y , 1 );
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
				transform.localScale = new Vector3( transform.localScale.x + offset*Time.deltaTime,  transform.localScale.y , 1 );
			}
			else
			{
				transform.localScale = new Vector3( origin,  transform.localScale.y , 1 );
			}
		}
	}

	void Scale()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(transform.localScale.x + offset < maxX && canMove)
			{
				transform.localScale = new Vector3( transform.localScale.x + offset*Time.deltaTime,  transform.localScale.y , 1 );
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(transform.localScale.x - offset > minX)
			{
				transform.localScale = new Vector3( transform.localScale.x - offset*Time.deltaTime, transform.localScale.y , 1 );
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.tag == "Bullet" )
		{
			canChnage = true;
			Destroy(coll.gameObject);
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