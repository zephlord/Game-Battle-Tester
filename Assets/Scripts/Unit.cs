using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{
	public Constants.Faction _faction;
	public Constants.Type _type;
	public Constants.Size _size;


	public int _atk;
	public int _armr;
	public int _spd;
	public int _hp;
	
	public string _name;

	public Dictionary<Constants.Type, bool> _canAttack;
	public Dictionary<KeyValuePair<Constants.Type, Constants.Size>, float> _strengths;
	public Dictionary<KeyValuePair<Constants.Type, Constants.Size>, float> _resistances;

	private int _currentArmr;
	private int _currentSpd;
	private int _currentAtk;
	public int _currentHp;
	public bool _isStunned;

	public bool _isDead;

	private int _numAttacks;

	public Unit(Constants.Faction faction, Constants.Type type, Constants.Size size, 
			string name,
			int atk, int armr, int spd, int hp, 
			List<Constants.Type> canAttack)
	{
		_faction = faction;
		_type = type;
		_size = size;
		_name = name;
		_atk = atk;
		_armr = armr;
		_spd = spd;
		_hp = hp;
		_canAttack = new Dictionary<Constants.Type, bool>();
		if(canAttack != null)
		{
			foreach(Constants.Type t in Enum.GetValues(typeof(Constants.Type)))
				_canAttack.Add(t, canAttack.Contains(t));
		}
		_currentArmr = _armr;
		_currentAtk = _atk;
		_currentHp = _hp;
		_currentSpd = _spd;

		_isDead = false;
		_numAttacks = 0;
	}

	public Unit(Unit unit)
	{
		_faction = unit._faction;
		_type = unit._type;
		_size = unit._size;
		_name = unit._name;
		_atk = unit._atk;
		_armr = unit._armr;
		_spd = unit._spd;
		_hp =unit._hp;
		_canAttack = unit._canAttack;
		_currentArmr = _armr;
		_currentAtk = _atk;
		_currentHp = _hp;
		_currentSpd = _spd;
		_numAttacks = 0;
		_isDead = false;
	}

	// public int attack_1()
	// {
	// 	if(_isDead)
	// 		return 0;
	// 	int roll = UnityEngine.Random.Range(0, Constants.SPEED_ROLL_NUMBER);
	// 	if(roll <= _currentSpd)
	// 		return _currentAtk;
	// 	else 
	// 		return 0; 
	// }

	public int attack()
	{
		if(_isDead || _numAttacks >= _currentSpd)
			return 0;
		int roll = UnityEngine.Random.Range(0, Constants.SPEED_ROLL_NUMBER);

		if(Constants.TURNS_IN_ROUND - TurnTracker.Instance._turnInRound > _currentSpd - _numAttacks )
		{
			if(roll <= _currentSpd)
			{
				_numAttacks++;
				return _currentAtk;
			}

			else return 0;
		}
			
		else 
		{
			_numAttacks++;
			return _currentAtk;
		} 
	}

	public Unit getUnitToAttack(List<Unit> units)
	{
		Unit toAttack = null;

		foreach(Unit unit in units)
		{
			if(_canAttack[unit._type] && !unit._isDead && (toAttack == null || unit._currentHp < toAttack._currentHp))
				toAttack = unit;
		}
		return toAttack;
	}



	public bool canAttack(Constants.Type type)
	{
		return _canAttack[type];
	}

	// public void damage_1(int dmg)
	// {
	// 	if(_currentArmr == 0)
	// 		_currentHp -= dmg;
	// 	else
	// 		_currentArmr = Mathf.Max(0, _currentArmr - dmg);

	// 	if(_currentHp <= 0)
	// 		_isDead = true;
	// }

	public int damage(int dmg)
	{
		int totaldmg = _currentHp;
		int roll = UnityEngine.Random.Range(0, _currentArmr);
		_currentHp -= Mathf.Max(0, dmg - roll);

		return totaldmg - _currentHp;
	}

	public void setDead()
	{
		if(_currentHp <= 0)
			_isDead = true;
	}

	public void nextRound()
	{
		_numAttacks = 0;
	}
}
