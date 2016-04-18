using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
	public GameObject pauseMenu;

	void Update()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			pauseMenu.SetActive(true);
			GameObject go = GameObject.FindGameObjectWithTag("Player");
			if (go != null) {
				go.GetComponent<PlayerMovement> ().enabled = false;
				go.GetComponent<PlayerGrenade> ().enabled = false;
				go.GetComponent<PlayerShoot> ().enabled = false;
			}
			Time.timeScale = 0;
		}
	}

	public void Unpause()
	{
		pauseMenu.SetActive(false);
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		if (go != null) {
			go.GetComponent<PlayerMovement> ().enabled = true;
			go.GetComponent<PlayerGrenade> ().enabled = true;
			go.GetComponent<PlayerShoot> ().enabled = true;
		}
		Time.timeScale = 1;
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
