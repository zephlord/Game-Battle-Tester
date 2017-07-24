using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTracker : Singleton<TurnTracker> {

	private int _currentTurn;
	public int _turnInRound;

	public void nextTurn()
	{
		_currentTurn ++;
		_currentTurn = _currentTurn % Constants.TURNS_IN_ROUND;
	}
}
