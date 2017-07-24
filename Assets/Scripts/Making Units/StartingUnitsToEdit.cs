using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingUnitsToEdit : MonoBehaviour {

	[SerializeField]
	private ScrollRect _scrollContainer;
	[SerializeField]
	private GameObject _unitMakerPrefab;
	void Start () 
	{
		Constants.Faction[] factions = Enum.GetValues(typeof(Constants.Faction)) as Constants.Faction[];
		Constants.Type[] types  = Enum.GetValues(typeof(Constants.Type)) as Constants.Type[];
		Constants.Size[] sizes = Enum.GetValues(typeof(Constants.Size)) as Constants.Size[];

		foreach(Constants.Faction faction in factions)
		{
			foreach(Constants.Type type in types)
			{
				foreach(Constants.Size size in sizes)
				{
					GameObject obj = Instantiate(_unitMakerPrefab, _scrollContainer.content);
					obj.GetComponent<SetupUnitField>().setValues(faction, type, size);
					obj.AddComponent<UnitMaker>();
				}
			}
		}
	}

	public void addUnit()
	{
		GameObject obj = Instantiate(_unitMakerPrefab, _scrollContainer.content);
	}
	
}
