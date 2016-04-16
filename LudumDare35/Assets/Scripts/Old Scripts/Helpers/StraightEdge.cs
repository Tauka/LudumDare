using UnityEngine;
using System.Collections;

public class StraightEdge : MonoBehaviour {

	public float platformLength;

	EdgeCollider2D edge;
	Vector2[] arrayPoints;

	// Use this for initialization
	void Awake () {
		edge = GetComponent<EdgeCollider2D> ();
	}
	
	// Update is called once per frame
	void Start () {
		SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer> ();
		Debug.Log ("Length of children" + children.Length);
		arrayPoints = new Vector2[2];
		arrayPoints [0] = new Vector2 (0, 0);
		arrayPoints [1] = new Vector2 (children.Length * platformLength, 0);
		edge.points = arrayPoints;
	}
}
