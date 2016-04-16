using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{


	public delegate void BaseFormHandler();
	public event BaseFormHandler BaseUpdateEvent;
	public event BaseFormHandler BaseStartEvent;

	public delegate void ColliderHandler(Collider2D o);
	public event ColliderHandler ColliderEnter;
	public event ColliderHandler ColliderExit;

	BaseMovement baseMove;
	BaseHealth baseHealth;
	BaseAttack baseAttack;
	// Use this for initialization

	void Awake()
	{
		baseMove = new BaseMovement();
		baseHealth = new BaseHealth();
		baseAttack = new BaseAttack();

		BaseStartEvent += baseMove.MoveStart;
		BaseStartEvent += baseHealth.HealthStart;
		BaseStartEvent += baseAttack.AttackStart;

		BaseUpdateEvent += baseMove.MoveUpdate;
		BaseUpdateEvent += baseHealth.HealthUpdate;
		BaseUpdateEvent += baseAttack.AtackUpdate;

		ColliderEnter += baseMove.MoveTriggerEnter;
		ColliderEnter += baseAttack.AttackTriggerEnter;

		ColliderExit += baseMove.MoveTriggerExit;
		ColliderExit += baseAttack.AttackTriggerExit;
	}

	void Start () 
	{
		BaseStartEvent();
	}

	// Update is called once per frame
	void Update () 
	{
		BaseUpdateEvent();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		ColliderEnter(other);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		ColliderExit(other);
	}
}