using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupUnitField : MonoBehaviour {

	[SerializeField]
	private Dropdown factionDropdown;
	[SerializeField]
	private Dropdown typeDropdown;
	[SerializeField]
	private Dropdown sizeDropdown;
	
	public void setValues(Constants.Faction faction, 
				Constants.Type type, Constants.Size size)
	{
		factionDropdown.value = (int)faction;
		typeDropdown.value = (int)type;
		sizeDropdown.value = (int)size;
	}
}
