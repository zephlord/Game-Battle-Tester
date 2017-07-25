using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiToggle : MonoBehaviour {

	public void SetActive(bool notActive)
	{
		gameObject.SetActive(!notActive);
	}
}
