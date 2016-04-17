using UnityEngine;
using System.Collections;

public class CheckDeath : MonoBehaviour 
{
	public GameObject over;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject pl = GameObject.FindGameObjectWithTag("Player");
		if( pl == null )
		{
			over.SetActive(true);
		}
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
