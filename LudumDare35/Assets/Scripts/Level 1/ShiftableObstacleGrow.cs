using UnityEngine;
using System.Collections;

public class ShiftableObstacleGrow : MonoBehaviour {

	public float growRate;
	public float growLimit;
	float y = 0;

	// Update is called once per frame
	void Update () {

		if (y < growLimit)
		y = transform.localScale.y + growRate;


		transform.localScale = new Vector3 (transform.localScale.x, y, transform.localScale.z);
	}
}
