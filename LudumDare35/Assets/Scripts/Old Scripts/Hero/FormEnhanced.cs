using UnityEngine;
using System.Collections;

public class FormEnhanced : MonoBehaviour {

	GameObject hero;
	GameController gc;
	HeroTorchInteraction hm ;
	// Use this for initialization
	void Start () 
	{
		hero = GameObject.FindGameObjectWithTag("Player");
		gc  = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		hm = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroTorchInteraction>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( !gc.isWepCirc && hm.isAlive ) {
			if (Input.GetButton ("Fire1")) {
				hero.transform.localScale = new Vector3 (2, 2, 1);
			} else {
				hero.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}
}
