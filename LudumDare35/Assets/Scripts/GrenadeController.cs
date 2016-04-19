using UnityEngine;
using System.Collections;

public class GrenadeController : MonoBehaviour {

	PlayerGrenade grenadeScript;
	//public float throwForce;
	public float velocity;
	public float explosionRadius;
	//public float explosionTime;
	Rigidbody2D rb;
	CircleCollider2D[] explosion;
	GameObject player;
	LineRenderer traj;
	DrawTrajectory trajScript;
	float currentTime = 0;

	bool once = true;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find("Professor!_withComponents");
		grenadeScript = player.GetComponent<PlayerGrenade> ();

		Debug.Log (player);
		//traj = player.GetComponent<LineRenderer> ();
		//trajScript = player.GetComponent<DrawTrajectory> ();
		explosion = GetComponents<CircleCollider2D> ();
	}

	void Start()
	{
		if (player == null)
		{
			player = GameObject.Find("Professor!_withComponents(Clone)");
			grenadeScript = player.GetComponent<PlayerGrenade> ();
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (once) {

			//Debug.Log (grenadeScript.throwAngle);

			//rb.AddForce (new Vector2(Mathf.Cos (Mathf.Deg2Rad * grenadeScript.throwAngle) * throwForce, Mathf.Sin (Mathf.Deg2Rad * grenadeScript.throwAngle) * throwForce));

			rb.velocity = new Vector2 (Mathf.Cos (Mathf.Deg2Rad * grenadeScript.throwAngle) * grenadeScript.vel * grenadeScript.side, Mathf.Sin (Mathf.Deg2Rad * grenadeScript.throwAngle) * grenadeScript.vel);
			once = false;
		}



	}

	void Update()
	{
		if (grenadeScript.explosionTime > currentTime) {
			currentTime += Time.deltaTime;
		} else {
			foreach (CircleCollider2D expl in explosion) {
				if (expl.isTrigger) {

					currentTime = 0;
					//change tag
					this.gameObject.tag = "Bullet";

					expl.radius = explosionRadius;


					//Destroy(this.gameObject);
				}
			}
		}
	}
}
