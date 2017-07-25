using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {

	private string _name;
	public string Name
	{
		get {return _name;}
	}

	private bool _toBeRemoved;
	public bool HasStateEnded
	{
		get {return _toBeRemoved;}
	}

	public State(string name)
	{
		_name = name;
		_toBeRemoved = false;
	}

	public abstract void nextTurn(Unit u);

}
