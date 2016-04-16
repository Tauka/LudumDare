using UnityEngine;
using System.Collections;

public class AlertState : IStates {

	AI enemy;
	Helper help = new Helper();
	bool init = false;

	public AlertState (AI ai)
	{
		enemy = ai;
	}

	public void UpdateState()
	{
		if (!init) 
		{
			Initializer ();
			init = true;
		}
		
		Debug.Log(Alert ());

		if (help.Timer (enemy.fields.alertTime)) 
		{
			ToPatrol ();
		}

		Debug.Log ("IN ALERT");

	}

	public void ToPatrol ()
	{
		init = false;
		enemy.currentState = enemy.patrolState;
		help.UpdatePointsOrder (enemy.fields.patrolPoints, enemy.fields.walkPoints, enemy.rb);
	}

	public void ToAlert ()
	{
	}

	public void ToChase ()
	{
		enemy.currentState = enemy.chaseState;
	}

	public void ToAttack ()
	{
	}

	public void OnTriggerEnter (Collider2D collider)
	{

	}

	bool Alert()
	{
		if (enemy.savedPlayerCollider != null)
		{
			ToChase ();
		}

		help.Patrol (enemy.transform.position, enemy.fields.alertPoints, enemy.rb, enemy.fields.alertSpeed, enemy.fields.distanceToTurnAlert);

		bool toReturn = Obstacle ();
		return toReturn;
	}

	void Initializer()
	{
		help.ResetNext ();
		help.ResetTimer ();
	}

	bool Obstacle()
	{
		if (enemy.savedObstacleCollider != null && Mathf.Abs(enemy.transform.position.x - enemy.savedObstacleCollider.transform.position.x) <= enemy.fields.obstacleRange) {
			if (enemy.savedObstacleCollider.transform.position.x < enemy.transform.position.x) {
				help.UpdateArrayOfPoints (enemy.fields.alertPoints, enemy.fields.rangeOfAlertPoints, enemy.savedObstacleCollider.transform.position, WalkPointsSetup.left, enemy.rb);
				return true;
			} 
			else 
			{
				help.UpdateArrayOfPoints (enemy.fields.alertPoints, enemy.fields.rangeOfAlertPoints, enemy.savedObstacleCollider.transform.position, WalkPointsSetup.right, enemy.rb);
				return true;
			}
		}

		return false;
	}
}
