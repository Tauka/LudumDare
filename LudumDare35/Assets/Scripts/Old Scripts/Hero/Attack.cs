using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour 
{
	HeroTransformation hTrans;
	// Use this for initialization
	void Start () 
	{
		hTrans = GetComponent<HeroTransformation>();
	}
	
	// Update is called once per frame
	void Update ()
	{
//		string tag = hTrans.forms[hTrans.formIndex].tag;
//
//		if( tag != null )
//		{
//			hTrans.forms[hTrans.formIndex].GetComponent(tag).;
//		}
	}
}
