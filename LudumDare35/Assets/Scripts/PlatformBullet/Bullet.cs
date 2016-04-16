using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rb;
	float speed = 10f;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(Input.GetAxisRaw("Horizontal") > 0)
//		{
//			rb.velocity = new Vector2( speed, 0 );
//		}
//		else if(Input.GetAxisRaw("Horizontal") < 0)
//		{
//			rb.velocity = new Vector2( -speed, 0 );
//		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if( coll.gameObject.tag == "Platform" )
		{
//			Destroy(this.gameObject, 0);
		}
	}
}
