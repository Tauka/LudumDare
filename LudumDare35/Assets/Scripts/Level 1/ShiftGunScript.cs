using UnityEngine;
using System.Collections;

public class ShiftGunScript : MonoBehaviour {

	public ShiftableObstacleGrow obstacle;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			collider.gameObject.GetComponent<PlayerShoot> ().enabled = true;
			obstacle.enabled = true;

			Destroy (this.gameObject);
		}
	}


}
