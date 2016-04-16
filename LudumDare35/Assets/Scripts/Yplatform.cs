using UnityEngine;
using System.Collections;

public class Yplatform : MonoBehaviour 
{
	bool canChnage = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKey(KeyCode.K) )
		{
			canChnage = false;
		}

		if( canChnage )
		{
			
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
