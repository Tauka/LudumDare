using UnityEngine;
using System.Collections;

public class DrawTrajectory : MonoBehaviour {


	PlayerGrenade grenade;
	public float velocity;
	Rigidbody2D rb;
	LineRenderer line;
	Renderer rend;
	[HideInInspector] public Vector2[] positions;

	//Draw texture for circlic trajectory
	public Texture texture;

	// Use this for initialization
	void Awake () {
		grenade = GetComponent<PlayerGrenade> ();
		rb = GetComponent<Rigidbody2D> ();
		line = this.gameObject.GetComponent<LineRenderer>();
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		DrawTraject (new Vector2 (transform.position.x + grenade.xOffset, transform.position.y + grenade.yOffset), new Vector2(Mathf.Cos (Mathf.Deg2Rad * grenade.throwAngle) * velocity * transform.localScale.x, Mathf.Sin (Mathf.Deg2Rad * grenade.throwAngle) * velocity));
	}

	void DrawTraject(Vector2 startPos, Vector2 velocity){

		Vector2 a = new Vector2(rb.gravityScale * Physics.gravity.x, rb.gravityScale * Physics.gravity.y);

		//quite inefficient
		//check how many vertices we need
		float checkLineY = startPos.y;
		int numOfVert = 0;
		Vector2 velTemp = velocity;
		while (checkLineY >= 0) 
		{
			numOfVert++;
			velTemp += a * Time.fixedDeltaTime;
			checkLineY += velTemp.y * Time.fixedDeltaTime;
		}

		int verts = numOfVert;
		line.SetVertexCount(verts);
		positions = new Vector2[verts];

		Vector2 pos = startPos;
		Vector2 vel = velocity;

		for(int i = 0; i < verts; i++)
		{
			line.SetPosition(i, new Vector3(pos.x, pos.y, 0));
			positions [i] = new Vector2 (pos.x, pos.y);

			rend.material.mainTextureScale = new Vector2((int)Vector2.Distance(positions[i], positions[(i + 1) % positions.Length]), 1);

			//Rect rect = new Rect (pos.x, pos.y, 100, 100);
			//rect.width = 2;
			//rect.height = 2;
			//rect.center = new Vector2 (pos.x, pos.y);

			//Graphics.DrawTexture (rect, texture);

			vel = vel + a * Time.fixedDeltaTime;
			pos = pos + vel * Time.fixedDeltaTime;
		}



	}
}
