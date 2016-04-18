using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletOffsetX;
	public float bulletOffsetY;

	public float projectileForwardForce = 50f;

	float lastShot = 0f;
	float fireRate = 1f;

	PlayerMovement pm;
	// Use this for initialization
	void Start () {
		pm = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire3"))
		{
			Fire ();
		}
	}

	void Fire()
	{
		GameObject go = null;
		if( Time.time > fireRate + lastShot )
		{		
			go = Instantiate (bullet, new Vector2 (transform.position.x + bulletOffsetX, transform.position.y + bulletOffsetY), Quaternion.identity) as GameObject ;
			lastShot = Time.time;
		}

		if( pm.facingR )
		{
			go.GetComponent<Rigidbody2D>().AddForce(transform.right*projectileForwardForce, ForceMode2D.Impulse);
		}
		else
		{
			go.GetComponent<Rigidbody2D>().AddForce(-transform.right*projectileForwardForce, ForceMode2D.Impulse);
		}
	}
}
