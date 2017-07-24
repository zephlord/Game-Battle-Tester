using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour {

	[SerializeField]
	private UIManager _ui;
	private List<List<Unit>> _armies;
	[SerializeField]
	private FightLog _fightLog;
	[SerializeField]
	private ButtonClick _closeButton;
	private bool _isFightOver;
	private int _currentRound;
	void Awake () {
	}

	void reset()
	{
		_armies = new List<List<Unit>>();
		_isFightOver = false;
		_currentRound = 0;
		_closeButton._clickFunction = new buttonClicked(delegate{_ui.previousUI();});
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!_isFightOver)
		{
			executeRound();
			_isFightOver = checkIfWinner();
			_currentRound ++;
			if(_currentRound % 10 == 0)
				nextRound();
		}
	}

	public void setArmies(List<List<Unit>> armies)
	{
		reset();
		_fightLog.setupArmyColors(armies.Count);
		foreach(List<Unit> army in armies)
		{
			Dictionary<string, int> unitCt = new Dictionary<string, int>();
			List<Unit> setArmy = new List<Unit>();
			foreach(Unit unit in army)
			{
				int count;
				if(!unitCt.ContainsKey(unit._name))
				{
					count = 0;
					unitCt.Add(unit._name, 1);
				}
				else
				{
					count = unitCt[unit._name];
					unitCt[unit._name]++;
				}
				Unit toAdd = new Unit(unit);
				toAdd._name = unit._name + count;
				setArmy.Add(toAdd);
			}
			_armies.Add(setArmy);
		}
	}

	public void executeRound()
	{
		for(int i = 0; i < _armies.Count; i++)
		{
			List<Unit> enemies = getEnemies(i);
			foreach(Unit unit in _armies[i])
			{
				Unit defender = unit.getUnitToAttack(enemies);
				if(defender == null)
					continue;
				int attackDamage = unit.attack();
				if(attackDamage == 0)
					continue;
				
				string attackMessage = unit._name + " attacked " + defender._name + " for " + defender.damage(attackDamage) + " damage.";
				_fightLog.addText(i, attackMessage);
			}
		}

		for(int i = 0; i < _armies.Count; i++)
		{
			foreach(Unit unit in _armies[i])
			{
				if(!unit._isDead)
				{
					unit.setDead();
					if(unit._isDead)
						_fightLog.addText(i, unit._name + " has died.");
				}
			}
		}
	}

	private List<Unit> getEnemies(int armyIndex)
	{
		List<Unit> enemies = new List<Unit>();
		for(int i = 0; i < _armies.Count; i++)
		{
			if(armyIndex == i)
				continue;
			foreach(Unit unit in _armies[i])
				enemies.Add(unit);
		}

		return enemies;
	}

	bool checkIfWinner()
	{
		int winningArmy = -1;
		for(int i = 0; i < _armies.Count; i++)
		{
			int survivors = getSurvivorCount(i);
			if(survivors > 0)
			{
				if(winningArmy > -1)
					return false;
				winningArmy = i;
			}
		}
		if(winningArmy == -1)
			_fightLog.addText(0, "everyone is dead.");
		else
			_fightLog.addText(winningArmy, winningArmy + " wins.");
		return true;
	}

	int getSurvivorCount(int armyIndex)
	{
		int count = 0;
		foreach(Unit unit in _armies[armyIndex])
		{
			if(!unit._isDead)
				count ++;
		}
		return count;
	}

	public void redoFight()
	{
		setArmies(new List<List<Unit>>(_armies));
	}

	public void nextRound()
	{
		foreach(List<Unit> army in _armies)
		{
			foreach(Unit unit in army)
				unit.nextRound();
		}
	}
}
