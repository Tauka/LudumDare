using UnityEngine;
using System.Collections;

public class ShiftGunScript : MonoBehaviour {

	public GameObject obstacle;
	public GameObject newProf;
	public float instantiateOffset;
	public GameObject hiddenText;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			obstacle.SetActive(true);
			hiddenText.SetActive(true);
			//obstacle.enabled = true;
			Destroy(collider.gameObject);
			Instantiate(newProf, new Vector3(transform.position.x + instantiateOffset, transform.position.y, transform.position.z) , Quaternion.identity);
			Destroy (this.gameObject);
		}
	}


}
