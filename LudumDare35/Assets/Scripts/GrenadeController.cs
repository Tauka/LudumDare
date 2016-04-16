using UnityEngine;
using System.Collections;

public class GrenadeController : MonoBehaviour {

	public PlayerGrenade grenadeScript;
	public float throwForce;
	Rigidbody2D rb;

	bool once = true;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (once) {
			rb.AddForce (new Vector2(Mathf.Cos (Mathf.Deg2Rad * grenadeScript.throwAngle) * throwForce, Mathf.Sin (Mathf.Deg2Rad * grenadeScript.throwAngle) * throwForce));
			once = false;
		}

	}
}
