using UnityEngine;
using System.Collections;

public class BaseMovement
{
	public float speed = 5;
	public float jumpForce = 300;

	int amountOfJumps = 2;
	int currentJumps = 0;
	bool canJump = true;
	bool inAir = false;

	[HideInInspector]public bool facingR = true;
	[HideInInspector]public float h = 0;

	private Rigidbody2D rb;
	private GameObject player;

	public BaseMovement()
	{
//		speed = 10;
//		jumpForce = 15;
//		amountOfJumps = 1;
//		currentJumps = 0;
//		canJump = true;
//		inAir = false;
//		facingR = true;
//		h = 0;
	}

	public void MoveStart()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void MoveUpdate()
	{
		h = Input.GetAxisRaw ("Horizontal");
		Move (h);
		Flip (h);

		if (currentJumps >= amountOfJumps) {
			canJump = false;
		}

		if (canJump && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) && currentJumps < amountOfJumps) {
			currentJumps++;
			Jump ();
			inAir = true;
		}
	}

	public void Move(float h)
	{
//		if(!inAir)
//		{
//			player.GetComponent<Rigidbody2D>().velocity = new Vector2(h*speed, player.GetComponent<Rigidbody2D>().velocity.y);
//		}
//		else
//		{
//			player.GetComponent<Rigidbody2D>().velocity = new Vector2(h*speed/2f, player.GetComponent<Rigidbody2D>().velocity.y);
//		}
		if( !inAir )
		{
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(h*speed, player.GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			player.GetComponent<Rigidbody2D>().AddForce( new Vector2( h*speed, 0 ) );
		}
	}

	public void Flip(float h)
	{
		if( h>0 )
		{
			player.transform.localScale = new Vector3(1,1,1);
			facingR = true;
		}
		if( h<0 )
		{
			player.transform.localScale = new Vector3(-1,1,1);
			facingR = false;
		}
	}

	public void Jump()
	{
		if( currentJumps > 1 )
		{
			player.GetComponent<Rigidbody2D>().AddForce( new Vector2(h*speed/1.25f, jumpForce/1.25f));
		}
		else
		{
			player.GetComponent<Rigidbody2D>().AddForce( new Vector2( h*speed, jumpForce));
		}
	}

	public void MoveTriggerEnter(Collider2D other)
	{
		if(other.tag == "Surface")
		{
			currentJumps = 0;
			inAir = false;
			canJump = true;
		}
	}

	public void MoveTriggerStay(Collider2D other)
	{
		if(other.tag == "Surface")
		{
			currentJumps = 0;
			canJump = true;
		}
	}

	public void MoveTriggerExit(Collider2D other)
	{
		if(other.tag == "Surface")
		{
			inAir = true;
		}
	}
}
