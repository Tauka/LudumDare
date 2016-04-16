using UnityEngine;
using System.Collections;

public class GrenadeController : MonoBehaviour {

	PlayerGrenade grenadeScript;
	public float throwForce;
	Rigidbody2D rb;

	bool once = true;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		grenadeScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerGrenade>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (once) {

			Debug.Log (grenadeScript.throwAngle);

			rb.AddForce (new Vector2(Mathf.Cos (Mathf.Deg2Rad * grenadeScript.throwAngle) * throwForce, Mathf.Sin (Mathf.Deg2Rad * grenadeScript.throwAngle) * throwForce));
			once = false;
		}

	}
}
