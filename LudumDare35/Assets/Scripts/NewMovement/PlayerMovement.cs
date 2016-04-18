using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	bool groundCollision = false;

	public float speed;
	public float jumpForce;
	public float raycastLength;
	//public Transform pointTrans;
	public float weirdXOffset;
	public float vertSpeed;
	public float maxVertSpeed = 0;
	public float minVertSpeed = 0;
	public bool grounded;
	public float groundY;
	public bool isThereGround;
	public float preGroundLength;
	//Transform[] children;
	Animator anim;
	//float side = 0;
	//float vert;

	public bool facingR = true;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		//children = gameObject.GetComponentsInChildren<Transform>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{

		if (rb.velocity.y != 0)
			vertSpeed = rb.velocity.y;
		
		//vertSpeed = rb.velocity.y;

		if (maxVertSpeed < rb.velocity.y) {
			maxVertSpeed = rb.velocity.y;
		}



		if (minVertSpeed > rb.velocity.y) {
			minVertSpeed = rb.velocity.y;
		}

		anim.SetFloat ("Speed", vertSpeed);

		anim.SetBool ("Grounded", CheckGround ());
		grounded = CheckGround ();

		anim.SetFloat ("DistanceToGround", transform.position.y - groundY);
		Debug.Log (transform.position.y - groundY);

		Debug.Log (anim.GetCurrentAnimatorStateInfo(0).ToString());

		isThereGround = IsThereGroundAfterLength (preGroundLength);

		//

		Debug.DrawLine (transform.GetChild(6).position, new Vector3(transform.GetChild(6).position.x, -1 * raycastLength, 0));

		//change side

	}

	void FixedUpdate()
	{
		//float h = Input.GetAxis ("Horizontal");

		if (rb.velocity.x != 0) {
			anim.SetBool ("IsWalking", true);
		} else {
			anim.SetBool ("IsWalking", false);
		}


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

	void Flip(float h)
	{


		if( h>0 && !facingR)
		{
			transform.localScale = new Vector3 (1, 1, 1);
			transform.position = new Vector3 (transform.position.x + weirdXOffset, transform.position.y, transform.position.z);


			//foreach
			facingR = true;
		}
		if( h<0 && facingR)
		{

			transform.localScale = new Vector3 (-1, 1, 1);
			transform.position = new Vector3 (transform.position.x - weirdXOffset, transform.position.y, transform.position.z);
			//Rescale (pointTrans.position.x);
		//	transform.localScale = new Vector3(-1,1,1);
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
		RaycastHit2D hit = Physics2D.Raycast (transform.GetChild(6).position, Vector2.down, raycastLength, LayerMask.GetMask("Ground"));

		if (hit.collider != null) 
		{
			//Debug.Log (hit);
				return true;

		}

		return false;
	}

	bool IsThereGroundAfterLength(float length)
	{
		if (transform.position.y - length <= 0)
		{
			return true;
		}

		return false;
	}

	/*void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
			groundCollision = true;
	}*/
}
