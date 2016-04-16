using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	public Transform target;
	private Camera mC;
	private Vector3 velocity = Vector3.zero;

	GameController gC;

	void Start()
	{
		mC = GetComponent<Camera>();	
		gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	// Update is called once per frame
	void Update () 
	{
			Vector3 point = mC.WorldToViewportPoint (target.position);
			Vector3 delta = target.position - mC.ViewportToWorldPoint (
				                new Vector3 (0.5f, 0.5f, point.z));
			Vector3 dest = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, dest, ref velocity, dampTime);
	}
}
