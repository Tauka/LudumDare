using UnityEngine;
using System.Collections;

public class IgniteLight : MonoBehaviour
{
	public  Light torchLight;
	public float torchLightIntensity = 2;
	private bool isOnFire = false;
	bool isHeroInRange;

	HeroTorchInteraction scriptHT;
	GameController gc;

	// Use this for initialization
	void Start ()
	{
		scriptHT = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroTorchInteraction>();
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

		torchLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gc.isWepCirc) {
			if (!isOnFire && isHeroInRange && Input.GetKeyDown (KeyCode.LeftShift)) {
				isOnFire = true;
				torchLight.intensity = torchLightIntensity;
				scriptHT.lifeSource.intensity -= 0.5f;
			}
		}
	}

	void OnTriggerEnter2D ( Collider2D other )
	{
		if( other.tag == "Player" )
		{
			isHeroInRange = true;
		}
	}

	void OnTriggerExit2D ( Collider2D other )
	{
		if( other.tag == "Player" )
		{
			isHeroInRange = false;
		}
	}
}
