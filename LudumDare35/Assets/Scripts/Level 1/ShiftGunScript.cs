using UnityEngine;
using System.Collections;

public class ShiftGunScript : MonoBehaviour {

	public GameObject obstacle;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			obstacle.SetActive(true);
			//obstacle.enabled = true;
			collider.gameObject.GetComponent<PlayerShoot>().enabled = true;
			Destroy (this.gameObject);
		}
	}


}
