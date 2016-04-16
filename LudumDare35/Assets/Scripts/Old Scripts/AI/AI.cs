using UnityEngine;
using System.Collections;

[System.Serializable]
public class Config {

	public Transform[] walkPoints;
	public float patrolForce;
	public float distanceToTurnPatrol;
	public float rangeOfAlertPoints;
	public float alertSpeed;
	public float distanceToTurnAlert;
	public float alertTime;
	public float raycastOffset;
	public float raycastLength;
	public float chaseSpeed;
	public float chaseTime;
	public float attackRange;
	public float attackSpeed;
	public float obstacleRange;
	[HideInInspector] public Vector3[] alertPoints = new Vector3[2];
	[HideInInspector] public Transform[] patrolPoints = new Transform[2];
}

public class AI : MonoBehaviour {

	public Config fields;

	[HideInInspector] public IStates currentState;
	[HideInInspector] public Rigidbody2D rb;

	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public Collider2D savedPlayerCollider;
	[HideInInspector] public Collider2D savedObstacleCollider;
	[HideInInspector] public bool hitPlayerCollider = false;
	[HideInInspector] public bool hitObstacleCollider = false;
	[HideInInspector] public bool raycast = false;
	[HideInInspector] public Vector2 dir = Vector2.zero;

	// Use this for initialization

	void Awake() 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start () {

		patrolState = new PatrolState (this);
		alertState = new AlertState (this);
		attackState = new AttackState (this);
		chaseState = new ChaseState (this);

		fields.patrolPoints [0] = fields.walkPoints [0];
		fields.patrolPoints [1] = fields.walkPoints [1];

		currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () {
		currentState.UpdateState ();
		Raycast ();

		//Debug.Log (rb.velocity.x);

		if (savedObstacleCollider != null) 
		{
			Debug.Log ("DO SEE OBSTACLE ");
		} 
		else 
		{
			Debug.Log ("DON'T SEE OBSTACLE");
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		currentState.OnTriggerEnter (other);
	}

	void Raycast()
	{
		//Vector2 direction = Vector2.zero;

		if (rb.velocity.x > 0.1) {
			dir = Vector2.right;
		} else if (rb.velocity.x < -0.1) {
			dir = Vector2.left;
		}

		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (transform.position.x + fields.raycastOffset * dir.x, transform.position.y), dir, fields.raycastLength, LayerMask.GetMask ("Player"));


		if (hit.collider != null) {
			raycast = true;
			if (hit.collider.CompareTag ("Player")) {
				savedPlayerCollider = hit.collider;
				savedObstacleCollider = null;
				hitPlayerCollider = true;
			} else if (hit.collider.CompareTag ("Obstacle")) {
				savedObstacleCollider = hit.collider;
				savedPlayerCollider = null;
				hitObstacleCollider = true;
			} 
			else {
				savedPlayerCollider = null;
				savedObstacleCollider = null;
			}

		} 
		else 
		{
			savedPlayerCollider = null;
			savedObstacleCollider = null;
			hitPlayerCollider = false;
			hitObstacleCollider = false;
		}
	}

	void OnDrawGizmos ()
	{
		//float direction = rb.velocity.x > 0 ? 1 : -1;
		
		Gizmos.DrawLine(new Vector3(transform.position.x + fields.raycastOffset * dir.x, transform.position.y, transform.position.z), new Vector3(transform.position.x + fields.raycastOffset * dir.x + fields.raycastLength * dir.x, transform.position.y, transform.position.z));
	}
}
