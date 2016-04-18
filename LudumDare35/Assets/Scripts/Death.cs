using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	SpriteRenderer[] bodyPartsSprites;
	GameObject[] bodyParts;
	//Vector3[] bodyPartsPositions;
	bool alive = true;
	public float maxForce;
	public float minForce;

	// Use this for initialization
	void Awake () {
		bodyPartsSprites = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		//Debug.Log ("Body parts sprites number: " + bodyPartsSprites.Length);
		bodyParts = new GameObject[bodyPartsSprites.Length];
		//bodyPartsPositions = new Vector3[bodyPartsSprites.Length];


	}

	void Start()
	{

		//turn off all components
		transform.GetComponent<PlayerMovement> ().enabled = false;
		transform.GetComponent<BoxCollider2D> ().enabled = false;
		transform.GetComponent<Animator> ().enabled = false;


		Debug.Log ("In Start");
		//get gameObjects
		for (int i = 0; i < bodyPartsSprites.Length; i++)
		{
			bodyParts [i] = bodyPartsSprites [i].gameObject;
			//bodyPartsPositions [i] = bodyParts [i].transform.localPosition;
		}

		//Debug.Log ("Body parts number: " + bodyParts);

		//attach rigidbody and collider to each and unchild
		for (int i = 0; i < bodyParts.Length; i++) {
			bodyParts [i].AddComponent<Rigidbody2D> ();
			bodyParts [i].GetComponent<Rigidbody2D> ().gravityScale = 4;
			bodyParts [i].AddComponent<CircleCollider2D> ();
			bodyParts [i].GetComponent<CircleCollider2D> ().radius = 0.5f;
			bodyParts [i].transform.parent = null;
			//bodyParts [i].transform.position = bodyPartsPositions [i];
		}


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (alive) {

			//Apply random force between minForce and maxForce to each and random direction
			for (int i = 0; i < bodyParts.Length; i++) {
				bodyParts[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Random.Range(Mathf.PI / 12,  Mathf.PI - Mathf.PI / 12)) * Random.Range(minForce, maxForce), Mathf.Sin(Random.Range(Mathf.PI / 12,  Mathf.PI - Mathf.PI / 12)) * Random.Range(minForce, maxForce)));
			} 

			alive = false;
		}
		
	}
}
