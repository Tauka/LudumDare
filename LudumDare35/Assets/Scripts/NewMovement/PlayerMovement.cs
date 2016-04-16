using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	bool groundCollision = false;

	public float speed;
	public float jumpForce;
	public float raycastLength;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		Movement ();
		Jump ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Movement()
	{

		/*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
			rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y); 
		}*/


		if (!CheckGround ()) {

			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);

			if (Input.GetAxisRaw ("Horizontal") != 0) {
				rb.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, rb.velocity.y); 
			}

		} else {
			rb.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, rb.velocity.y); 
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
