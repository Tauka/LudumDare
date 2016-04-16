using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {

	public Text narrator;
	public GameObject player;
	public Transform[] triggerPoints;
	public string[] phrases;
	public float speakingSpeed;
	bool coroutineEnd = false;
	bool oneUpdate = true;

	int i = 0;
	int currentlyDisplayingText = 0;

	
	// Update is called once per frame
	void Update () {


		//narrator system
		if (currentlyDisplayingText < triggerPoints.Length && player.transform.position.x >= triggerPoints [currentlyDisplayingText].transform.position.x && oneUpdate) {
				
				oneUpdate = false;
				StartCoroutine (AnimateText ());

				
			}
	}

	public void SkipToNextText(){
		StopAllCoroutines();
		currentlyDisplayingText++;

		//If we've reached the end of the array, do anything you want. I just restart the example text
		if (currentlyDisplayingText >= phrases.Length) {
			StopCoroutine(AnimateText());
		}

	}

	IEnumerator AnimateText(){

		for (int i = 0; i < (phrases[currentlyDisplayingText].Length + 1); i++)
		{
			narrator.text = phrases[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(speakingSpeed);
		}

		oneUpdate = true;
		currentlyDisplayingText++;
	}
}
