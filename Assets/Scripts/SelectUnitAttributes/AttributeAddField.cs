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
	private List<GameObject> _attributeRefinementFields;
	//private List<AttributeCreationRefinementView> _attributeRefinementFields;

	private bool hasUpdated;

	void Start()
	{
		OnValueChanged(_typeSelect.value);

	}

	void Update()
	{
		if(!hasUpdated)
		{
			List<Dropdown.OptionData> displayData = new List<Dropdown.OptionData>();
		foreach(Type type in GlobalConstants.POSSIBLE_ATTRIBUTE_TYPES)
		{
			displayData.Add(new Dropdown.OptionData(GlobalConstants.ATTRIBUTE_DISPLAY_TYPES[type]));
		}
		_typeSelect.options = displayData;
		_typeSelect.onValueChanged.AddListener(OnValueChanged);
		}
		hasUpdated = true;
	}


	void OnValueChanged(int value)
	{
		for(int i = 0; i < _attributeRefinementFields.Count; i++)
		{
			_attributeRefinementFields[i].SetActive(i == value);
		}
		// Type selectedType = GlobalConstants.POSSIBLE_ATTRIBUTE_TYPES[value];
		// foreach(AttributeCreationRefinementView view in _attributeRefinementFields)
		// {
		// 	if(view.GetViewType == selectedType)
		// 		view.View.SetActive(true);
		// 	else
		// 		view.View.SetActive(false);
		// }
	}
}
