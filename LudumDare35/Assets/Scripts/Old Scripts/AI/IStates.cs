using UnityEngine;
using System.Collections;

public interface IStates {

	void UpdateState();

	void ToPatrol ();

	void ToAlert ();

	void ToChase ();

	void ToAttack ();

	void OnTriggerEnter (Collider2D collider);

}
