using UnityEngine;
using System.Collections;

public class EnemyMovement {

	public void Move(Vector3 enemyPos, Vector3 target, Rigidbody2D rb, float speed)
	{
		float direction = enemyPos.x < target.x ? 1 : -1;

		/*if (enemyPos.x - target.x <= float.Epsilon) 
		{
			rb.velocity = new Vector2 (0, rb.velocity.y);
		} 
		else 
		{*/
		rb.velocity = new Vector2 (speed * direction, rb.velocity.y);
		//}
	}
}
