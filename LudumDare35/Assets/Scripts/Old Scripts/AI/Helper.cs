using UnityEngine;
using System.Collections;

public class Helper {

	int next = 0;
	float timer = 0;
	float currentDir = 0;

	public void Move(Vector3 enemyPos, Vector3 target, Rigidbody2D rb, float force)
	{
		Vector2 direction;

//		if (target != null || target != Vector2.zero) {
		direction = enemyPos.x < target.x ? Vector2.right : Vector2.left;
//			currentDir = direction;
//		} 

		/*if (enemyPos.x - target.x <= float.Epsilon) 
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		} 
		else 
		{*/

		//Movement based on velocity, less physics based
		//rb.velocity = new Vector2 (force * direction.x, rb.velocity.y);

		//Movement based on force
		rb.AddForce(direction * force);

		//}
	}

	public void Move(Vector3 enemyPos, float direction, Rigidbody2D rb, float speed)
	{
		if (direction != null || direction != 0) 
		{
			currentDir = direction;
		}

		/*if (enemyPos.x - target.x <= float.Epsilon) 
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		} 
		else 
		{*/
		rb.velocity = new Vector2 (speed * currentDir, rb.velocity.y);
		//}
	}

	public void Move(Vector3 enemyPos, Rigidbody2D rb, float speed, Collider2D collider)
	{
		float direction;

		//When collider is null, it goes in last direction
		if (collider != null) 
		{
			direction = enemyPos.x < collider.transform.position.x ? 1 : -1;
			currentDir = direction;
		}
		/*if (enemyPos.x - target.x <= float.Epsilon) 
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		} 
		else 
		{*/
		rb.velocity = new Vector2 (speed * currentDir, rb.velocity.y);
		//}
	}

	//Function for reassignation of array of transforms
	//Works only for array of 2 items
	public void UpdateArrayOfPoints(Vector3[] walkPoints, float range, Vector3 targetPos, WalkPointsSetup setup, Rigidbody2D rb)
	{
		int i, j;
		
		if (rb.velocity.x > 0) 
		{
			i = 0;
			j = 1;
		} 
		else 
		{
			i = 1;
			j = 0;
		}

		//Left and Right are for facing obstacle
		if (setup == WalkPointsSetup.center) {
			walkPoints [i] = new Vector3 (targetPos.x + range, walkPoints [i].y, walkPoints [i].z);
			walkPoints [j] = new Vector3 (targetPos.x - range, walkPoints [i].y, walkPoints [i].z);
		} 
		else if (setup == WalkPointsSetup.right) {
			walkPoints [0] = new Vector3 (targetPos.x, walkPoints [i].y, walkPoints [i].z);
			walkPoints [1] = new Vector3 (targetPos.x - 2 * range, walkPoints [i].y, walkPoints [i].z);
		} 
		else 
		{
			walkPoints [0] = new Vector3 (targetPos.x, walkPoints [i].y, walkPoints [i].z);
			walkPoints [1] = new Vector3 (targetPos.x + 2 * range, walkPoints [i].y, walkPoints [i].z);
		}
	}

	public void Patrol(Vector3 position, Transform[] walkPoints, Rigidbody2D rb, float speed, float distanceToTurn)
	{
		Move (position, walkPoints[next % 2].position, rb, speed);

		if (Mathf.Abs (walkPoints [next % 2].position.x - position.x) <= distanceToTurn) {
			rb.velocity = Vector2.zero; //Stops when reaches the point
			next++;
		}
			
	}

	public void Patrol(Vector3 position, Vector3[] walkPoints, Rigidbody2D rb, float force, float distanceToTurn)
	{
		Move (position, walkPoints[next % 2], rb, force);

			if (Mathf.Abs (walkPoints [next % 2].x - position.x) <= distanceToTurn) {
				next++;
			}

	}

	public void ResetNext()
	{
		next = 0;
	}

	public void UpdatePointsOrder(Transform[] patrolPoints, Transform[] walkPoints, Rigidbody2D rb)
	{
		if (rb.velocity.x > 0) 
		{
			patrolPoints [0] = walkPoints [1];
			patrolPoints [1] = walkPoints [0];
		} 
		else 
		{
			patrolPoints [0] = walkPoints [0];
			patrolPoints [1] = walkPoints [1];
		}
	}

	public bool Timer(float time)
	{
		
		timer += Time.deltaTime;

		if (timer >= time) {
			timer = 0;
			return true;
		} 
		else 
		{
			return false;
		}
	}

//	public void Obstacle(Vector3[] arrayPoints, float range, Vector3 target, WalkPointsSetup set, Rigidbody2D rb)
//	{
//		UpdateArrayOfPoints()
//	}

	public void ResetTimer()
	{
		timer = 0;
	}

	public void StopMove(Rigidbody2D rb)
	{
		rb.velocity = Vector2.zero;
	}
}
