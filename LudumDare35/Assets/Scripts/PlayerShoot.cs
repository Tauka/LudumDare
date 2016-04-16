using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletOffsetX;
	public float bulletOffsetY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Fire3") != 0)
		{
			Fire ();
		}
	}

	void Fire()
	{
		Instantiate (bullet, new Vector2 (transform.position.x + bulletOffsetX, transform.position.y + bulletOffsetY), Quaternion.identity);
	}
}
