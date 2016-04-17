using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	bool groundCollision = false;

	public float speed;
	public float jumpForce;
	public float raycastLength;

	[HideInInspector]public bool facingR = true;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		//float h = Input.GetAxis ("Horizontal");

		float side = 0;
		if (Input.GetKey (KeyCode.A)) {
			side = -1;
		} 
		else if (Input.GetKey (KeyCode.D)){
			side = 1;
		}

		Flip(side);
		Movement (side);
		Jump ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void Flip(float h)
	{
		if( h>0 )
		{
			transform.localScale = new Vector3(1,1,1);
			facingR = true;
		}
		if( h<0 )
		{
			transform.localScale = new Vector3(-1,1,1);
			facingR = false;
		}
	}

	void Movement(float s)
	{

		/*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
			rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y); 
		}*/

		if (!CheckGround ()) {

			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);

			if (Input.GetAxisRaw ("Horizontal") != 0) {
				rb.velocity = new Vector2 (s * speed, rb.velocity.y); 
			}

		} else {
			rb.velocity = new Vector2 (s * speed, rb.velocity.y); 
		}

	}

	void Jump()
	{
		if (CheckGround()) {
			rb.AddForce(new Vector2(rb.velocity.x, Input.GetAxis ("Jump") * jumpForce));
		}
	}

	bool CheckGround()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, raycastLength, LayerMask.GetMask("Ground"));

		if (hit.collider != null) 
		{
			//Debug.Log (hit);
				return true;

		}

		return false;
	}

	/*void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
			groundCollision = true;
	}*/
}
