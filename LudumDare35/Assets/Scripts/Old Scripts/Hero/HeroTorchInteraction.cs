using UnityEngine;
using System.Collections;

public class HeroTorchInteraction : MonoBehaviour 
{
	public Light lifeSource;
	bool isTorchInRange = false;
	public bool isAlive = true;

	public int lvl = 1;

	GameController gc;


	// Use this for initialization
	void Start () 
	{
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gc.isWepCirc) {
			if (lifeSource.intensity == 0) {
				isAlive = false;
				Death ();
			}
		}
	}

	void Death()
	{
		lifeSource.intensity = 3;
		lifeSource.color = Color.red;

	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if(other.tag == "Torch" )
		{
			isTorchInRange = true;
		}

		if(other.tag == "IntensityPill")
		{
			Debug.Log("Here are We!");
			if( lifeSource.intensity <= 2.5f )
			{
				lifeSource.intensity += 0.5f;
			}
			else
			{
				lifeSource.intensity = 3;
			}
			lvl ++;
			other.gameObject.SetActive(false);
		}
	}
	void OnTriggerExit2D( Collider2D other )
	{
		if(other.tag == "Torch" )
		{
			isTorchInRange = false;
		}
	}
}
