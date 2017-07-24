using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightLog : MonoBehaviour {

	[SerializeField]
	private ScrollRect _textLog;
	[SerializeField]
	private GameObject _logElement;

	private Color[] _armyTextColors;
	private Color[] _armyBkgrndColors;
	void Awake () 
	{
		if(_armyBkgrndColors == null)
			_armyBkgrndColors = new Color[0];
		if(_armyTextColors == null)
			_armyTextColors = new Color[0];
	}
	
	public void setupArmyColors(List<Color> textColors, List<Color> bkgrndColors)
	{
		if(textColors.Count != bkgrndColors.Count)
			return;

		_armyTextColors = new Color[textColors.Count];
		_armyBkgrndColors = new Color[bkgrndColors.Count];
		for(int i = 0; i < textColors.Count; i++)
		{
			_armyBkgrndColors[i] = bkgrndColors[i];
			_armyTextColors[i] = bkgrndColors[i];
		}
	}

	public void setupArmyColors(int armyCount)
	{
		List<Color> backgroundColors = new List<Color>();
		List<Color> textColors = new List<Color>();
		for(int i = 0; i < armyCount; i++)
		{
			backgroundColors.Add(Random.ColorHSV());
			textColors.Add(Random.ColorHSV());
		}
		setupArmyColors(textColors, backgroundColors);
	}

	public void addText(int army, string text)
	{
		GameObject textElem = Instantiate(_logElement, _textLog.content);
		textElem.GetComponent<FightLogElement>().setColors(_armyTextColors[army], _armyBkgrndColors[army]);
		textElem.GetComponent<FightLogElement>().setText(text);
	}
}
