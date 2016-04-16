using UnityEngine;
using System.Collections;

public class BaseAttack
{
	bool enemyInRange = false;
	int damage = 2;
	// Use this for initialization
	public void AttackStart ()
	{
		Debug.Log("Ready for war!");
	}
	
	// Update is called once per frame
	public void AtackUpdate ()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Attack();
		}
	}

	public void Attack()
	{
		Debug.Log("Hero made a strike.");

		if(enemyInRange)
		{
			Debug.Log("Enemy in range. Ready to take damage! = " + damage);
		}
	}

	public void AttackTriggerEnter( Collider2D c )
	{
		if( c.tag == "Enemy" )
		{
			enemyInRange = true;
		}
	}

	public void AttackTriggerExit( Collider2D c )
	{
		if( c.tag == "Enemy" )
		{
			enemyInRange = false;
		}
	}
}
