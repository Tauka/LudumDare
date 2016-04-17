using UnityEngine;
using System.Collections;

public class Yplatform : MonoBehaviour 
{
	bool canChnage = false;
	bool canMove = true;
	bool fastChange = false;

	bool playerIn = false;
	bool setUp = false;

	public float force = 0.001f;
	public float maxY = 3;
	public float minY = 0.3f;
	float origin = 1;
	float offset = 0.01f;


	// Use this for initialization
	void Start () 
	{
		maxY = transform.localScale.y + maxY;
		origin = transform.localScale.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( Input.GetKey(KeyCode.LeftShift) )
		{
			CancelInvoke();
			canChnage = false;
		}

		if( !canChnage && transform.localScale.y != origin )
		{
			InvokeRepeating("Return", 0, 0.05f);
		}

		if( Input.GetKey(KeyCode.LeftControl) )
		{
			CancelInvoke();
			fastChange = true;
			canChnage = false;

			if( transform.localScale.y < origin )
			{
				Debug.Log("Ready to throw");
				setUp = true;
			}
		}

		if( fastChange && !canChnage && transform.localScale.y != origin )
		{
			InvokeRepeating("Return", 0, 0.0001f);
		}

		if( !canChnage && transform.localScale.y == origin )
		{
			CancelInvoke();
			Debug.Log("Before AddForce");
		}

		if( playerIn && setUp && transform.localScale.y == origin )
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force), ForceMode2D.Impulse );
			setUp = false;
			Debug.Log("AddForce");
		}

		if( canChnage )
		{
			InvokeRepeating("Scale", 0, 0.05f);
		}
	}

	void Return()
	{
		float ch = offset;
		if( fastChange )
		{
			ch = 100 * offset;
		}
		if( transform.localScale.y > origin )
		{
			if(transform.localScale.y-ch >= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y - ch*Time.deltaTime, 1 );
			}
			else
			{
				transform.localScale = new Vector3( transform.localScale.x, origin, 1 );
			}
		}

		if( transform.localScale.y < origin )
		{
			if(transform.localScale.y+ch <= origin)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y + ch*Time.deltaTime , 1 );
			}
			else
			{
				transform.localScale = new Vector3( transform.localScale.x, origin, 1 );
			}
		}
	}

	void Scale()
	{
		if(Input.GetKey(KeyCode.RightArrow) && canMove)
		{
			if(transform.localScale.y + offset < maxY)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y + offset*Time.deltaTime, 1 );
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(transform.localScale.y - offset > minY)
			{
				transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y - offset*Time.deltaTime , 1 );
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

		if( coll.tag == "Player" )
		{
			playerIn = true;
			Debug.Log("See player");
		}
		Debug.Log("Y-CollissionEnter");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if( coll.tag == "Platform" )
		{
			canMove = true;
		}
		if( coll.tag == "Player" )
		{
			playerIn = false;
		}
	}
}