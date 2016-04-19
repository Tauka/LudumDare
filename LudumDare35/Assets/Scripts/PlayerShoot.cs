using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletOffsetX;
	public float bulletLeftOffsetX;
	public float bulletOffsetY;

	public float projectileForwardForce = 50f;

	float lastShot = 0f;
	float fireRate = 1f;

	Animator anim;

	PlayerMovement pm;
	// Use this for initialization
	void Start () {
		pm = GetComponent<PlayerMovement>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire3") && Time.time > fireRate + lastShot) {
			Fire ();
			lastShot = Time.time;
			anim.SetBool ("Shoot", true);
		} else {
			anim.SetBool ("Shoot", false);
		}
	}

	void Fire()
	{
		GameObject go = null;

		if (pm.facingR)
			go = Instantiate (bullet, new Vector2 (transform.position.x + bulletOffsetX, transform.position.y + bulletOffsetY), Quaternion.identity) as GameObject ;
		else
			go = Instantiate (bullet, new Vector2 (transform.position.x - bulletLeftOffsetX, transform.position.y + bulletOffsetY), Quaternion.identity) as GameObject ;

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
