using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightLogElement : MonoBehaviour {

	[SerializeField]
	private Text _text;
	private Color _textCol;
	private Color _backgroundCol; 
	private bool _doChangeColors;
	void Start () 
	{
		_textCol = Color.black;
		_backgroundCol = Color.clear;	
		_doChangeColors = false;
	}

	void OnGUI()
	{
		if(_doChangeColors)
		{
			GUI.backgroundColor = _backgroundCol;
			_text.color = _textCol;
			_doChangeColors = false;
		}
	}
	
	// Update is called once per frame
	public void setColors(Color textCol, Color bkgrndColor)
	{
		_textCol = textCol;
		_backgroundCol = bkgrndColor;
		_doChangeColors = true;
	}

	public void setText(string text)
	{
		_text.text = text;
	}
}
