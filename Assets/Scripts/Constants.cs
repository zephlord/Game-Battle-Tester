using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants 
{

	public enum Faction
	{
		RANGERS,
		CITY
	}

	public enum Type
	{
		LAND,
		AIR,
		SEA
	};

	public enum Size
	{
		SMALL,
		MEDIUM,
		LARGE
	};

	public static List<KeyValuePair<Type, Size>> STARTING_UNIT_LIST = new List<KeyValuePair<Type, Size>>()
	{ 
		{new KeyValuePair<Type, Size>(Type.LAND, Size.SMALL)},
		{new KeyValuePair<Type, Size>(Type.LAND, Size.MEDIUM)},
		{new KeyValuePair<Type, Size>(Type.LAND, Size.LARGE)},
		{new KeyValuePair<Type, Size>(Type.AIR, Size.SMALL)},
		{new KeyValuePair<Type, Size>(Type.AIR, Size.MEDIUM)},
		{new KeyValuePair<Type, Size>(Type.AIR, Size.LARGE)},
		{new KeyValuePair<Type, Size>(Type.SEA, Size.SMALL)},
		{new KeyValuePair<Type, Size>(Type.SEA, Size.MEDIUM)},
		{new KeyValuePair<Type, Size>(Type.SEA, Size.LARGE)},

	};

	public static int SPEED_ROLL_NUMBER = 10;
	public static int TURNS_IN_ROUND = 10;


}
