using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	public GameObject levelAnn;
	public float speed = 0.1f;

	void Update()
	{
		Vector3 zero = Vector3.zero;
		Vector3 orig = levelAnn.transform.localScale;
		levelAnn.transform.localScale = Vector3.Lerp(orig, zero, speed);

		if( levelAnn.transform.localScale == Vector3.zero )
		{
			levelAnn.SetActive(false);
		}
	}
}
