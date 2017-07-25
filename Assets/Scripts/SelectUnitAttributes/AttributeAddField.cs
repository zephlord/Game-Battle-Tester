using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AttributeAddField : MonoBehaviour {

	[SerializeField]
	private Dropdown _typeSelect;
	private Type _type;
	[SerializeField]
	private List<AttributeCreationRefinementView> _attributeRefinementFields;

	void Start()
	{
		List<Dropdown.OptionData> displayData = new List<Dropdown.OptionData>();
		foreach(KeyValuePair<Type, string> val in GlobalConstants.ATTRIBUTE_DISPLAY_TYPES)
		{
			displayData.Add(new Dropdown.OptionData(val.Value));
		}
		_typeSelect.options = displayData;
		_typeSelect.onValueChanged.AddListener(OnValueChanged);

	}


	void OnValueChanged(int value)
	{
		Type selectedType = GlobalConstants.ATTRIBUTE_DISPLAY_TYPES[value].Key;
		foreach(AttributeCreationRefinementView view in _attributeRefinementFields)
		{
			if(view.GetViewType == selectedType)
				view.View.SetActive(true);
			else
				view.View.SetActive(false);
		}
	}
}
