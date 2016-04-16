
using UnityEngine;
using System.Collections;

public class FrameRateCap : MonoBehaviour {
	void Awake()
	{
		Application.targetFrameRate = 60;
	}
}
