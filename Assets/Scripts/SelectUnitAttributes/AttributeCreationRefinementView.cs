using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AttributeCreationRefinementView
{
	[SerializeField]
	private GameObject _view;
	public GameObject View
	{get{return _view;}}
	[SerializeField]
	private SerializableSystemType _viewType;
	public Type GetViewType
	{get{return _viewType.SystemType;}}
}
