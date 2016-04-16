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

=======
>>>>>>> 781d0469121715fae20752f370603b809079a5c6
	void Throwing()
	{
		Instantiate (grenadePrefab, new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), Quaternion.identity);
	}
}
