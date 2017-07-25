using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalConstants
{

	public static List<Type> POSSIBLE_ATTRIBUTE_TYPES = new List<Type>()
	{
		typeof(int), typeof(string), typeof(Enum)
	};
	public static Map<Type, string> ATTRIBUTE_DISPLAY_TYPES = new Map<Type, string>()
	{
		{typeof(int), "int"},
		{typeof(string), "string"},
		{typeof(Enum), "property"},
	};

}
