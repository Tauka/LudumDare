using UnityEngine;
using System.Collections;

public class AttackState : IStates {

	AI enemy;
	Helper help = new Helper();

	public AttackState(AI ai)
	{
		enemy = ai;
	}

	public void UpdateState()
	{
		Attack ();
		Debug.Log ("IN ATTACK!");


	}

	public void ToPatrol ()
	{
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

	void Attack()
	{
		//help.Move (enemy.transform.position, enemy.rb, enemy.fields.attackSpeed, enemy.savedPlayerCollider);

		if (enemy.savedPlayerCollider != null) {
			if (Mathf.Abs (enemy.transform.position.x - enemy.savedPlayerCollider.transform.position.x) > enemy.fields.attackRange) {
				ToChase ();
			}
		} 
		else 
		{
			ToChase ();
		}
	}
}
