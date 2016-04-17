using UnityEngine;
using System.Collections;

public class ShiftGunScript : MonoBehaviour {

	public GameObject obstacle;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			collider.gameObject.SetActive(true);
			//obstacle.enabled = true;

			Destroy (this.gameObject);
		}
	}


}
