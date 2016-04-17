using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	float distTravelled = 0;
	float lastPos;
	Rigidbody2D rb;
	int count = 0;

	public float deathHeight = 8;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( rb.velocity.y < 0  && count == 0 )
		{
			count ++ ;
			lastPos = transform.position.y;
		}

		if( rb.velocity.y == 0 && count == 1 )
		{
			count -- ;
			distTravelled = lastPos - transform.position.y;
		}

		if( distTravelled >= deathHeight )
		{
			Debug.Log("Dead");
			Destroy(this.gameObject);
		}
	}
}
