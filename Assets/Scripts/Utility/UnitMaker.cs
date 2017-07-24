using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnitField))]
public class UnitMaker : MonoBehaviour 
{
	private UnitField _unit;

	void Start()
	{
		_unit = GetComponent<UnitField>();
	}

	public Unit makeUnit()
	{
		if(_unit.Name == "")
			return null;


		return new Unit(_unit.Faction,
			_unit.Type,
			_unit.Size,
			_unit.Name,
			_unit.ATK,
			_unit.ARMR,
			_unit.SPD,
			_unit.HP,
			_unit.CanAttackList);
	}

	public void reset()
	{
		_unit.reset();
	}
	
}
