using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializePrivateVariables]
public class PropertyFieldView : MonoBehaviour {


	private InputField _name;
	public string GetName
	{get {return _name.text;}}
	private ButtonClick _deleteButton;
	
	void Start()
	{
		_deleteButton._clickFunction = new buttonClicked(destroySelf);
	}
	
	void destroySelf()
	{
		Destroy(gameObject);
	}


}
