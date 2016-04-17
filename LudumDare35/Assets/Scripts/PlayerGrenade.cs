using UnityEngine;
using System.Collections;

public class PlayerGrenade : MonoBehaviour {

	public float maxAngle;
	public float minAngle;
	public float angleChangeSpeed;
	public float throwAngle;
	public float xOffset;
	public float yOffset;

	Rigidbody2D rb;
	//DrawTrajectory trajectory;
	LineRenderer line;
	PlayerMovement movement;

	public GameObject grenadePrefab;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		//trajectory = GetComponent<DrawTrajectory> ();
		line = GetComponent<LineRenderer> ();
		movement = GetComponent<PlayerMovement> ();
	}

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

			//enable trajectory line
			line.enabled = true;

			//disable movement
			rb.velocity = Vector2.zero;
			movement.enabled = false;

			if (Input.GetKey (KeyCode.A)) {
				throwAngle = (throwAngle + angleChangeSpeed) % maxAngle;
			} else if (Input.GetKey (KeyCode.D)) {
				throwAngle = (throwAngle - angleChangeSpeed) % minAngle;
			}
		} else if (Input.GetKeyUp (KeyCode.E)) {

			//disable trajectory
			line.enabled = false;

			//enable movement
			movement.enabled = true;

			Throwing ();
			//throwAngle = 0;
		}
	}

	void Throwing()
	{
		Instantiate (grenadePrefab, new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), Quaternion.identity);
	}

	/*void DrawTraject(Vector2 startPos, Vector2 startVelocity, float angle, float force){

		int verts = 20;
		LineRenderer line = this.gameObject.GetComponent(LineRenderer);
		line.SetVertexCount(verts);

		Vector2 pos = startPos;
		Vector2  vel= startVelocity;
		Vector2 grav = Vector2(Physics.gravity.x, Physics.gravity.y);
		for(var i = 0; i < verts; i++)
		{
			line.SetPosition(i, Vector3(pos.x, pos.y, 0));
			vel = vel + grav * Time.fixedDeltaTime;
			pos = pos + vel * Time.fixedDeltaTime;
		}

	}*/
}
