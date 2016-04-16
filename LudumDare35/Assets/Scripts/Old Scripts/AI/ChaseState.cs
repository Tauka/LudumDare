using UnityEngine;
using System.Collections;

public class ChaseState : IStates {

	AI enemy;
	Helper help = new Helper ();


	public ChaseState(AI ai)
	{
		enemy = ai;
	}

	public void UpdateState()
	{
		Chase ();

		Debug.Log ("IN CHASE!");
	}

	public void ToPatrol ()
	{
	}

	public void ToAlert ()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChase ()
	{
		
	}

	public void ToAttack ()
	{
		enemy.currentState = enemy.attackState;
	}

	public void OnTriggerEnter (Collider2D collider)
	{
		
	}

	void Chase()
	{

		help.Move (enemy.transform.position, enemy.rb, enemy.fields.chaseSpeed, enemy.savedPlayerCollider);


		if (enemy.savedPlayerCollider == null) {
			if (help.Timer (enemy.fields.chaseTime)) {
				ToAlert ();
			}
		} else if (Mathf.Abs (enemy.savedPlayerCollider.transform.position.x - enemy.transform.position.x) <= enemy.fields.attackRange) {
			help.StopMove (enemy.rb);
			ToAttack ();
		} 
		else 
		{
			help.ResetTimer ();
		}

		//Goes into Alert if faces obstacle
		if (Obstacle ()) 
		{
			ToAlert ();
		}
	}

	bool Obstacle()
	{
		if (enemy.savedObstacleCollider != null && Mathf.Abs(enemy.transform.position.x - enemy.savedObstacleCollider.transform.position.x) <= enemy.fields.obstacleRange) {
			//if (enemy.savedObstacleCollider.transform.position.x < enemy.transform.position.x) {
				//help.UpdateArrayOfPoints (enemy.fields.alertPoints, enemy.fields.rangeOfAlertPoints, enemy.savedObstacleCollider.transform.position, WalkPointsSetup.left, enemy.rb);
				return true;
			//} 
			//else 
			//{
				//help.UpdateArrayOfPoints (enemy.fields.alertPoints, enemy.fields.rangeOfAlertPoints, enemy.savedObstacleCollider.transform.position, WalkPointsSetup.right, enemy.rb);
				//return true;
			//}
		}

		return false;
	}
					
}
