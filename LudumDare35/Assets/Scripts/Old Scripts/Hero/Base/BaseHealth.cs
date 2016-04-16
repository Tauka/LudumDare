using UnityEngine;
using System.Collections;

public class BaseHealth : Object
{

	GameObject[] torcheObjects;
	GameObject player;
	bool torchInRange;

	int count=0;
	// Use this for initialization
	public void HealthStart () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		torcheObjects = GameObject.FindGameObjectsWithTag("Torch");
	}
	
	// Update is called once per frame
	public void HealthUpdate () 
	{		
		int indexTorch = 0;
		for( int i=0; i < torcheObjects.Length; i++ )
		{
			if( Mathf.Abs(torcheObjects[i].transform.position.x - 
						player.transform.position.x) < 1 )
			{
				torchInRange = true;
				indexTorch = i;
				break;		
			}
			else
			{
				torchInRange = false;
			}
		}

		if( Input.GetKeyDown(KeyCode.LeftShift) && torchInRange )
		{
			TorchOnOff(indexTorch);
		}


		if( player.GetComponent<Light>().intensity <= 0 )
		{
			Death();
		}
	}

	public void TorchOnOff( int index )
	{
		if(torcheObjects[index].GetComponent<Light>().intensity == 0)
		{
			torcheObjects[index].GetComponent<Light>().intensity += 2;
			player.GetComponent<Light>().intensity -= 0.5f;
		}
		else
		{
			torcheObjects[index].GetComponent<Light>().intensity = 0;
			player.GetComponent<Light>().intensity += 0.5f;
		}
	}

	public void TakeDamage( int damage )
	{
		player.GetComponent<Light>().intensity -= damage;
	}

	public void Death()
	{
		player.GetComponent<Light>().intensity = 6;
		player.GetComponent<Light>().color = Color.Lerp(Color.white, Color.red, 2f);
		player.GetComponent<Light>().spotAngle = 100; 
		Destroy(player, 2f);
	}
}
