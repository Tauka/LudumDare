using UnityEngine;
using System.Collections;

public class ParticleMovement : MonoBehaviour {

	BasicForm toGetData;
	HeroMevement toGetDest;
	HeroTorchInteraction hTI;
	Rigidbody2D rb;
	float life;
	float timer = 0;
	float speed = 0;


	void Start () 
	{
		toGetData = GameObject.FindGameObjectWithTag("FormBasic").GetComponent<BasicForm>();
		toGetDest = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroMevement>();
		hTI = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroTorchInteraction>();
		rb = GetComponent<Rigidbody2D>();
		life = toGetData.timeOfBullLife;
		speed = toGetData.speedOfABullet;

		if( toGetDest.h > 0 )
		{
			rb.velocity += new Vector2( speed, 0 );
			toGetDest.facingR = true;
		}
		else if( toGetDest.h < 0 )
		{
			rb.velocity -= new Vector2( speed, 0 );
			toGetDest.facingR = false;
		}
		else if( toGetDest.facingR == true )
		{
			rb.velocity += new Vector2( speed, 0 );
		}
		else if( toGetDest.facingR == false )
		{
			rb.velocity -= new Vector2( speed, 0 );
		}

	}

	void Update () 
	{
		timer += Time.deltaTime;
		if( timer >= life )
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D( Collider2D c )
	{
		if( c.tag == "Surface" )
		{
			if( hTI.lvl > 1 )
			{
				rb.velocity = Vector3.zero;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
		if( c.tag == "Enemy" )
		{
			c.GetComponent<Rigidbody2D>().AddForce( new Vector2(0, speed*10));
		}
	}


}
