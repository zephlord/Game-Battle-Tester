using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFieldClick : MonoBehaviour {

	public UnitFieldClicked _clickedFunction;
	void Awake () {
		_clickedFunction = new UnitFieldClicked(nullClick);
	}
	
	public void OnMouseClick()
	{
		_clickedFunction(GetComponent<UnitField>().toUnit());
	}

	void nullClick(Unit unit)
	{
		return;
	}
}
