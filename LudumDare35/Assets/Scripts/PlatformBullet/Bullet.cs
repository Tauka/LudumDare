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
		Destroy(this.gameObject, 3);
	}

	void OnColliderEnter2D(Collider2D coll)
	{
		if( coll.tag == "Platform" )
		{
			Destroy(this.gameObject);
		}
	}
}
