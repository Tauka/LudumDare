using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	GameObject weaponCircle;
	[HideInInspector] public  bool isWepCirc = false;
	float flow = 1;
	[HideInInspector] public int weaponId = 0;
	Camera cameraMain;

	HeroTransformation heroT;
	// Use this for initialization
	void Start () 
	{
		weaponCircle = GameObject.FindGameObjectWithTag("WeaponCircle");
		if(weaponCircle != null)
		{
			weaponCircle.SetActive(isWepCirc);
		}
		cameraMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		heroT = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroTransformation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown(KeyCode.I) && isWepCirc == false )
		{
			isWepCirc = true;
			flow = 0;
		}
		else if( Input.GetKeyDown(KeyCode.I) && isWepCirc == true )
		{
			isWepCirc = false;
			flow = 1;
		}
		Time.timeScale = flow;
		if(weaponCircle != null)
		{
			weaponCircle.SetActive(isWepCirc);
		}

		Tranformation();

		Debug.Log("Weapon ID: " + weaponId);
	}

	public void Tranformation()
	{
		if( Input.GetKeyDown(KeyCode.Q) )
		{
			heroT.formIndex = (heroT.formIndex + 1) % heroT.forms.Length;	
		}
	}

	public void GetWeapon( Button button )
	{
		print( "BUTTON: " + button.name );

		if( button.name == "WeaponChoice1" )
		{
			weaponId = 0;
		}
		if( button.name == "WeaponChoice2" )
		{
			weaponId = 1;
		}
		if( button.name == "WeaponChoice3" )
		{
			weaponId = 2;
		}
		if( button.name == "WeaponChoice4" )
		{
			weaponId = 3;
		}
		isWepCirc = false;
		flow = 1;
	}
}
