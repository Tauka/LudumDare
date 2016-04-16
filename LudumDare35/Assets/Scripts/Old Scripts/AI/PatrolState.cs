using UnityEngine;
using System.Collections;

public class PatrolState : IStates {

	AI enemy;
	int next = 0;
	bool init = false;
	Helper help = new Helper();

	public PatrolState (AI ai)
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

		Debug.Log ("IN PATROL!");
		Patrol ();
		//Debug.Log (Patrol ());
	}

	public void ToPatrol()
	{
		
	}

	public void ToAlert ()
	{
		init = false;
		enemy.currentState = enemy.alertState;
	}

	public void ToChase ()
	{
		
	}

	public void ToAttack ()
	{
	}

	public void OnTriggerEnter (Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			help.UpdateArrayOfPoints (enemy.fields.alertPoints, enemy.fields.rangeOfAlertPoints, collider.transform.position, WalkPointsSetup.center, enemy.rb);
		
			ToAlert ();
		}
	}

	/*void Patrol()
	{
		movement.Move (enemy.transform.position, enemy.walkPoints[next % 2].position, enemy.rb, enemy.speed);

		if (Mathf.Abs(enemy.walkPoints[next % 2].position.x - enemy.transform.position.x) <= enemy.distanceToTurnPatrol) 
		{
			next++;
		}
	}*/

	void Patrol()
	{
		 help.Patrol (enemy.transform.position, enemy.fields.patrolPoints, enemy.rb, enemy.fields.patrolForce, enemy.fields.distanceToTurnPatrol);
	}

	void Initializer()
	{
		help.ResetNext ();
	}
}
