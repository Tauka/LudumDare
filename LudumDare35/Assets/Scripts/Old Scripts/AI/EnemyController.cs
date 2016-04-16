using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[HideInInspector] public int health;

	public int decreaseFactor;

	AI enemyAI;
	bool inShade;

	void Awake()
	{
		enemyAI = GetComponent<AI> ();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Torch")) {
			inShade = true;
		} 
		else {
			inShade = false;
		}
	}

	void Update()
	{
		if (inShade) {
			DecreaseSpeed ();
		} 
		else {
			NormalizeSpeed ();
		}
	}

	void DecreaseSpeed() 
	{
		enemyAI.fields.alertSpeed /= decreaseFactor;
		enemyAI.fields.attackSpeed /= decreaseFactor;
		enemyAI.fields.chaseSpeed /= decreaseFactor;
	}

	void NormalizeSpeed()
	{
		enemyAI.fields.alertSpeed *= decreaseFactor;
		enemyAI.fields.attackSpeed *= decreaseFactor;
		enemyAI.fields.chaseSpeed *= decreaseFactor;
	}
}
