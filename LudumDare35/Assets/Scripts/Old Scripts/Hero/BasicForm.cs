using UnityEngine;
using System.Collections;

public class BasicForm : MonoBehaviour 
{
	public GameObject[] weapons;
	public float cooldawnFire = 1;
	public float timeOfBullLife = 2;
	public float speedOfABullet = 4;

	private float timer = 0;

	GameController gameCtrl;
	// Use this for initialization
	void Start ()
	{
		gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	public void Update () 
	{
		if (!gameCtrl.isWepCirc) {
			timer += Time.deltaTime;
			
			if (Input.GetButtonDown ("Fire1") && timer > cooldawnFire) {
				timer = 0;
				Vector3 pos = transform.position;
				Debug.Log ("Shot from weapon N: " + gameCtrl.weaponId);
				Instantiate (weapons [gameCtrl.weaponId], pos, Quaternion.identity);
			}
		}
	}
}
