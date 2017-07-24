using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void buttonClicked();
public class ButtonClick : MonoBehaviour {

	public buttonClicked _clickFunction;
	void Awake () {
		if(_clickFunction == null)
			_clickFunction = new buttonClicked(nullClick);
		
	}

	void nullClick()
	{
		return;
	}
	
	public void OnClicked()
	{
		_clickFunction();
	}
}
