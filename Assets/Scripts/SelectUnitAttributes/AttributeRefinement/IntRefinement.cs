using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializePrivateVariables]
public class IntRefinement : MonoBehaviour {

	private Toggle _isUnbounded;
	private InputField _minField;
	private InputField _maxField;
	
	public RangeInt getVal()
	{
		if(_isUnbounded.isOn)
			return default(RangeInt);
		else
			return new RangeInt(Convert.ToInt32(_minField.text), Convert.ToInt32(_maxField.text));
	}
}
