using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperties : Singleton<UnitProperties> 
{
	private Dictionary<string, Type> _attributes;
	private Dictionary<Type, Dictionary<string, object>> _variables;
	private Dictionary<string, RangeInt> _intRanges;


	public void createDicts(List<KeyValuePair<string, Type>> attributes)
	{
		_attributes = new Dictionary<string, Type>();
		foreach(KeyValuePair<string, Type> var in attributes)
		{
			_attributes.Add(var.Key, var.Value);
			if(!_variables.ContainsKey(var.Value))
				_variables.Add(var.Value, new Dictionary<string, object>());
			_variables[var.Value].Add(var.Key, Activator.CreateInstance(var.Value));
		}
	}

	public Type getVarType(string varName)
	{
		return _attributes[varName];
	}

	public T getVar<T>(string objName)
	{
		return (T) _variables[typeof(T)][objName];
	}


}
