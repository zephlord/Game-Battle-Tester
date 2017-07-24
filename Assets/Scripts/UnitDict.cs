using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDict : Singleton<UnitDict> {

	private Dictionary<string, Unit> _unitTypes;
	

	public Dictionary<string, Unit> getUnitTypes()
	{
		return _unitTypes;
	}

	public void makeNewUnitTypes(List<Unit> unitTypes)
	{
		_unitTypes = new Dictionary<string, Unit>();
		foreach(Unit unit in unitTypes)
			_unitTypes.Add(unit._name, unit);
	}
}
