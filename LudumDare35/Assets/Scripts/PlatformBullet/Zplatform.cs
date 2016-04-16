using UnityEngine;
using System.Collections;

public class Zplatform : MonoBehaviour 
{
	bool canChnage = false;
	bool canMoveR = true;
	bool canMoveL = true;

	float origin = 0f;
	float offset = 0.01f;

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

		if( !canChnage && transform.localEulerAngles.z != origin )
		{
			InvokeRepeating("Return", 0f, 0.05f);
		}

		if( !canChnage && transform.localEulerAngles.z == origin )
		{
			CancelInvoke();
		}

		if( canChnage )
		{
			InvokeRepeating("Scale", 0f, 0.05f);
		}
	}

	void Return()
	{
		if( ((transform.eulerAngles.z % 360) / 180) <= 1 )
		{
			if(((transform.eulerAngles.z - offset)%360) >= origin)
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, transform.localEulerAngles.z - offset );
			}
			else
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, origin);
			}
		}

		if( ((transform.eulerAngles.z % 360) / 180) > 1 )
		{
			if(((transform.eulerAngles.z + offset)%360) >= origin)
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, transform.localEulerAngles.z + offset );
			}
			else
			{
				transform.localEulerAngles = new Vector3( 0f, 0f, origin);
			}
		}
	}

	void Scale()
	{
		if(Input.GetAxis("Horizontal") > 0 && canMoveR )
		{
			transform.localEulerAngles = new Vector3( 0f, 0f, transform.localEulerAngles.z + offset);
		}

		if(Input.GetAxis("Horizontal") < 0 && canMoveL )
		{
			transform.localEulerAngles = new Vector3( 0f, 0f,  transform.localEulerAngles.z - offset);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.tag == "Bullet" )
		{
			canChnage = true;
		}

		if( coll.tag == "Platform" && Input.GetAxis("Horizontal") < 0)
		{
			canMoveL = false;
			Debug.Log("Left");
		}

		if( coll.tag == "Platform" && Input.GetAxis("Horizontal") > 0)
		{
			canMoveR = false;
			Debug.Log("Right");
		}

		Debug.Log("CollissionEnter");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if( coll.tag == "Platform" )
		{
			canMoveL = true;
			canMoveR = true;
		}
	}
}