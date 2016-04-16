using UnityEngine;
using System.Collections;

public class HeroMevement : MonoBehaviour
{
	public float speed;
	public float jumpForce;

	int amountOfJumps = 1;
	int currentJumps = 0;
	bool canJump = true;
	bool inAir = false;

	[HideInInspector]public bool facingR = true;
	[HideInInspector]public float h = 0;

	private HeroTorchInteraction scriptHT;
	private GameController gCtrl;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start ()
	{
		scriptHT = GetComponent<HeroTorchInteraction>();
		rb = GetComponent<Rigidbody2D>();
		gCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!gCtrl.isWepCirc) 
		{
			if (scriptHT.isAlive) {
				h = Input.GetAxisRaw ("Horizontal");
			
				Move (h);
				Flip (h);
			} else {
				rb.velocity = new Vector2 (0, 0);
				Debug.Log ("You are dead! Congratulations!");
			}
			
			if (currentJumps >= amountOfJumps) {
				canJump = false;
			}
			
			if (canJump && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) && currentJumps < amountOfJumps) {
				currentJumps++;
				Jump ();
				inAir = true;
			}
		}

	}

	void Move(float h)
	{
		if(!inAir)
		{
				rb.AddForce( new Vector2(h*speed, 0) );
		}
		else
		{

			if( !inAir && rb.velocity.y < 0 )
			{
				rb.velocity = new Vector2( rb.velocity.x, speed ) ;
			}

				rb.AddForce( new Vector2(h*speed/1.5f, 0) );
		}
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

	void Jump()
	{
		if( currentJumps > 1 )
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		else
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce/2);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if( other.tag == "Surface" )
		{
			canJump = true;
			inAir = false;
			currentJumps = 0;
		}
	}
	void OnTriggerStay2D (Collider2D other)
	{
		if( other.tag == "Surface" )
		{
			canJump = true;
			inAir = false;
			currentJumps = 0;
		}
	}
}
