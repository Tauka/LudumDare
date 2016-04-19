using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour 
{
	public GameObject win;
	// Use this for initialization
//	void Start () 
//	{
//		
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//		
//	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if( other.tag == "Player" )
		{
			win.SetActive(true);
		}
	}

	public void Next()
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}

	public void Retry()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu()
	{
		Application.LoadLevel(0);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
