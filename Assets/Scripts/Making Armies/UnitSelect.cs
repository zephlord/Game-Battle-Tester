using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public delegate void UnitFieldClicked(Unit unit);
public class UnitSelect : MonoBehaviour {

	[SerializeField]
	private ScrollRect _scrollContainer;
	[SerializeField]
	private UnitField _searchField;
	[SerializeField]
	private GameObject _unitFieldPrefab;
	private List<UnitField> _units;
	private Dictionary<string, Unit> _unitDict;
	public int _armyIndex;
	private bool _hasStarted;

	void Start()
	{
		_units = new List<UnitField>();
		_unitDict = new Dictionary<string, Unit>();
		createUnitInfoList();
		_hasStarted = true;
	}
	void OnEnable()
	{
		if(_hasStarted)
			createUnitInfoList();
	}

	private void createUnitInfoList()
	{

		Dictionary<string, Unit> units = UnitDict.Instance.getUnitTypes();
		if(_unitDict != units)
		{
			foreach(UnitField unitField in _units)
			{
				_units.Remove(unitField);
				Destroy(unitField.gameObject);
			}
			_unitDict = units;

			foreach(Unit unit in _unitDict.Values)
			{
				GameObject obj = Instantiate(_unitFieldPrefab, _scrollContainer.content);
				UnitField unitField = obj.GetComponent<UnitField>();
				unitField.setValues(unit._faction,
					unit._type, unit._size, unit._hp, unit._name,
					unit._armr, unit._spd, unit._atk, unit._canAttack);
				_units.Add(unitField);
				obj.GetComponent<UnitFieldClick>()._clickedFunction = new UnitFieldClicked(selectUnit);
			}
		}
	}
	
	public void sortByAtk(int atk)
	{
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.ATK == atk);
	}

		public void sortByAtk(Dropdown atk)
	{
		sortByAtk(atk.value);
	}

	public void sortByArmr(int armr)
	{
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.ARMR == armr);
	}

	public void sortByArmr(Dropdown armr)
	{
		sortByArmr(armr.value);
	}

	public void sortBySpd(int spd)
	{
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.SPD == spd);
	}

	public void sortBySpd(Dropdown spd)
	{
		sortBySpd(spd.value);
	}

	public void sortByName(string name)
	{
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.Name.Contains(name));
	}

	public void sortByName(InputField name)
	{
		sortByName(name.text);
	}

	public void sortByHp(int hp)
	{
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.HP == hp);
	}

	public void sortByHp(InputField hp)
	{
		sortByHp(Convert.ToInt32(hp.text));
	}

	public void sortByFaction(int faction)
	{
		if(faction >= Enum.GetValues(typeof(Constants.Faction)).Length)
		{
			foreach(UnitField unit in _units)
				unit.gameObject.SetActive(true);
		}
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.Faction == (Constants.Faction) faction);
	}

	public void sortBySize(int size)
	{
		if(size >= Enum.GetValues(typeof(Constants.Size)).Length)
		{
			foreach(UnitField unit in _units)
				unit.gameObject.SetActive(true);
		}
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.Size == (Constants.Size) size);
	}

	public void sortByType(int type)
	{
		if(type >= Enum.GetValues(typeof(Constants.Type)).Length)
		{
			foreach(UnitField unit in _units)
				unit.gameObject.SetActive(true);
		}
		foreach(UnitField unit in _units)
			unit.gameObject.SetActive(unit.Type == (Constants.Type) type);
	}

	public void selectUnit(Unit selected)
	{
		transform.parent.gameObject.GetComponent<ArmyCreator>().addUnitToArmy(selected, _armyIndex);
	}

}
