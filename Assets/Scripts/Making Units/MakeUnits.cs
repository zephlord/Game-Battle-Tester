using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeUnits : MonoBehaviour {

	[SerializeField]
	private ScrollRect _unitTypeContainer;

	public void makeUnits()
	{
		List<Unit> unitTypes = new List<Unit>();
		foreach(Transform unitTypeTrans in _unitTypeContainer.content)
		{
			if(unitTypeTrans.gameObject.GetComponent<UnitField>().Name != null && 
				unitTypeTrans.gameObject.GetComponent<UnitField>().Name != "")
				unitTypes.Add(unitTypeTrans.gameObject.GetComponent<UnitMaker>().makeUnit());
		}
		UnitDict.Instance.makeNewUnitTypes(unitTypes);
	}
}
