using UnityEngine;
using System.Collections;

public class Splatform : MonoBehaviour 
{
	bool canChnage = false;
	bool canMoveR = true;
	bool canMoveL = true;
	bool fastChange = false;

	bool playerIn = false;
	bool setUp = false;
	bool flyPos = false;
	bool flyNeg = false;

	float origin = 0f;
	float offset = 0.5f;

	public float force = 8;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( Input.GetKey(KeyCode.LeftShift) )
		{
			CancelInvoke();
			canChnage = false;
		}

		if( !canChnage && transform.localEulerAngles.z != origin )
		{
			InvokeRepeating("Return", 0f, 0.05f);
		}

		if( Input.GetKey(KeyCode.LeftControl) )
		{
			CancelInvoke();
			fastChange = true;
			canChnage = false;
		}

		if( playerIn )
		{
			GameObject p = GameObject.FindGameObjectWithTag("Player");

			if( p.transform.position.x - transform.position.x < 0  && transform.rotation.z > 0 && transform.rotation.z < 90 )
			{
				flyPos = true;
				flyNeg = false;
			}

			if(p.transform.position.x - transform.position.x > 0 && transform.rotation.z > -90 && transform.rotation.z < 0)
			{
				flyNeg = true;
				flyPos = false;
			}
		}

		if( fastChange && !canChnage && transform.localScale.y != origin )
		{
			Debug.Log("Ctrl");
			InvokeRepeating("Return", 0, 0.0001f);
		}

		if( !canChnage && transform.localEulerAngles.z == origin )
		{
			if(!fastChange)
			{
				CancelInvoke();
			}
			else
			{
				CancelInvoke();
				fastChange = false;
				Fly();
			}
		}


		if( canChnage )
		{
			InvokeRepeating("Scale", 0f, 0.05f);
		}
	}

	void Fly()
	{

		if( playerIn && (transform.localEulerAngles.z%360) == origin )
		{
			Debug.Log("FlyPos = " + flyPos);
			Debug.Log("FlyNeg = " + flyNeg);

			Rigidbody2D pRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
			if( flyPos )
			{
				pRB.AddForce(new Vector2(force, force), ForceMode2D.Impulse );
			}

			if( flyNeg )
			{
				pRB.AddForce(new Vector2((-1)*force, force), ForceMode2D.Impulse );
			}

			setUp = false;
			flyNeg = false;
			flyPos = false;
			Debug.Log("AddForce");
		}
	}

	void Return()
	{
		float ch = offset;
		if( fastChange )
		{
			ch = 50 * offset;
		}

		if( ((transform.eulerAngles.z % 360) / 180) <= 1 )
		{
			if(((transform.eulerAngles.z - ch)%360) >= origin)
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, transform.localEulerAngles.z - ch*Time.deltaTime );
			}
			else
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, origin);
			}
		}

		if( ((transform.eulerAngles.z % 360) / 180) > 1 )
		{
			if(((transform.eulerAngles.z + ch)%360) >= origin)
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, transform.localEulerAngles.z + ch*Time.deltaTime  );
			}
			else
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, origin);
			}
		}
	}

	void Scale()
	{
		if(Input.GetKey(KeyCode.LeftArrow) && canMoveR )
		{
			transform.localEulerAngles = new Vector3( 0f, 0f, transform.localEulerAngles.z + offset*Time.deltaTime );
		}

		if(Input.GetKey(KeyCode.RightArrow) && canMoveL )
		{
			transform.localEulerAngles = new Vector3( 0f, 0f,  transform.localEulerAngles.z - offset*Time.deltaTime );
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.tag == "Bullet" )
		{
			canChnage = true;
		}

		if( coll.tag == "Platform" && Input.GetKey(KeyCode.RightArrow))
		{
			canMoveL = false;
			Debug.Log("Left");
		}

		if( coll.tag == "Platform" && Input.GetKey(KeyCode.LeftArrow))
		{
			canMoveR = false;
			Debug.Log("Right");
		}

		if( coll.tag == "Player" )
		{
			playerIn = true;
			Debug.Log("See player");
		}
		Debug.Log("Z-CollissionEnter");

		Debug.Log("CollissionEnter");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if( coll.tag == "Platform" )
		{
			canMoveL = true;
			canMoveR = true;
		}
		if( coll.tag == "Player" )
		{
			playerIn = false;
		}
	}
}