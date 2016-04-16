using UnityEngine;
using System.Collections;

public class HeroTransformation : MonoBehaviour 
{
	public GameObject[] forms;
	[HideInInspector] public int formIndex;
	// Use this for initialization
	void Start () 
	{
		formIndex = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i=0; i < forms.Length; i++)
		{
			if( i == formIndex )
			{
				forms[i].SetActive(true);
			}
			else
			{
				forms[i].SetActive(false);
			}
		}
	}
}
