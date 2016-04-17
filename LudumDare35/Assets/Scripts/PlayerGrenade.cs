using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGrenade : MonoBehaviour {

	public float maxAngle;
	//public float minAngle;
	public float angleChangeSpeed;
	public float velocityChangeSpeed;
	public float maxVelocity;
	public float maxExplosionTime;
	//public float minVelocity;
	 public float throwAngle;
	 public float side;
 public float vel = 5;
	public float explosionTime = 1;
	[HideInInspector] public float timerAppearTime = 2;
	public float xOffset;
	public float yOffset;

	Rigidbody2D rb;
	//DrawTrajectory trajectory;
	LineRenderer line;
	PlayerMovement movement;
	Text timerText;

	bool coroutineFinish = true;

	public GameObject grenadePrefab;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		//trajectory = GetComponent<DrawTrajectory> ();
		line = GetComponent<LineRenderer> ();
		movement = GetComponent<PlayerMovement> ();

		//we can do this, since there's only one child, and only on grandchild
		timerText = this.transform.GetChild(0).GetComponentInChildren<Text>();

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

			
			TimerChange (timerText, timerAppearTime);

			//if (Input.GetKey (KeyCode.A)) {
			throwAngle = (throwAngle + angleChangeSpeed * Input.GetAxis("Horizontal") * transform.localScale.x * -1) % maxAngle;
			vel = Mathf.Abs((vel + velocityChangeSpeed * Input.GetAxis ("Vertical")) % maxVelocity);

			//change explosion time


			//} else if (Input.GetKey (KeyCode.D)) {
			//	throwAngle = (throwAngle - angleChangeSpeed) % minAngle;
			//}
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
		//this prevents glitches with throwing at other direction, when in GrenadeController I directly use localScale.x
		side = transform.localScale.x;
		Instantiate (grenadePrefab, new Vector2(transform.position.x + xOffset * transform.localScale.x, transform.position.y + yOffset), Quaternion.identity);
	}

	void TimerChange(Text timerTex, float timerApp)
	{
		if (Input.GetKeyDown (KeyCode.Q)) {
			explosionTime = ((explosionTime + 1) % maxExplosionTime);

			timerTex.text = explosionTime.ToString ();
			coroutineFinish = false;
		}

		//if time is expired text, disappears


		if (!coroutineFinish)
			StartCoroutine (TextEraser (timerTex, timerApp));
		else
			StopCoroutine (TextEraser(timerTex, timerApp));
	}

	IEnumerator TextEraser(Text textuwka, float time)
	{
		yield return new WaitForSeconds(time);

		textuwka.text = "";
		coroutineFinish = true;
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
