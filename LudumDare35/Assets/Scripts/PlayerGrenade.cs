using UnityEngine;
using System.Collections;

public class PlayerGrenade : MonoBehaviour {

	public float maxAngle;
	public float minAngle;
	public float angleChangeSpeed;
	public float throwAngle;
	public float xOffset;
	public float yOffset;

	public GameObject grenadePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Aim ();
	}

	void Aim ()
	{
		if (Input.GetKey (KeyCode.E)) {
			if (Input.GetKey (KeyCode.A)) {
				throwAngle = (throwAngle + angleChangeSpeed) % maxAngle;
			} else if (Input.GetKey (KeyCode.D)) {
				throwAngle = (throwAngle - angleChangeSpeed) % minAngle;
			}
		} else if (Input.GetKeyUp (KeyCode.E)) {
			Throwing ();
			//throwAngle = 0;
		}
	}
<<<<<<< HEAD

	void Throwing()
	{
		Instantiate (grenadePrefab, new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), Quaternion.identity);
	}
=======
//
//	void Throw ()
//	{
//		if (Input.
//	}
>>>>>>> 6c98074d6af10818ebff0f3e2c8b637aae924fb6
}
