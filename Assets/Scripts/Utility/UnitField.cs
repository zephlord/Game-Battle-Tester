using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitField : MonoBehaviour {

	[SerializeField]
	private Dropdown _factionSelect;
	private Constants.Faction _faction;
	public Constants.Faction Faction
	{ 
		get{ return _faction;} 
		set{ _faction = (Constants.Faction) value;}
	}

	[SerializeField]
	private Dropdown _typeSelect;
	private Constants.Type _type;
	public Constants.Type Type
	{ 
		get{return _type;} 
		set{ _type = (Constants.Type) value;}
	}

	[SerializeField]
	private Dropdown _sizeSelect;
	private Constants.Size _size;
	public Constants.Size Size
	{ 
		get{return _size;} 
		set{ _size = (Constants.Size) value;}
	}

	[SerializeField]
	private InputField _nameField;
	private string _name;
	public string Name
	{ 
		get{return _name;} 
		set{_name = value;}
	}

	[SerializeField]
	private InputField _hpField;
	private int _hp;
	public int HP
	{ 
		get{return _hp;} 
		set{_hp = Convert.ToInt32(value);}
	}

	[SerializeField]
	private Dropdown _spdSelect;
	private int _spd;
	public int SPD
	{ 
		get{return _spd;} 
		set{_spd = value;}
	}

	[SerializeField]
	private Dropdown _armrSelect;
	private int _armr;
	public int ARMR
	{ 
		get{return _armr;} 
		set{_armr = value;}
	}

	[SerializeField]
	private Dropdown _atkSelect;
	private int _atk;
	public int ATK
	{ 
		get{return _atk;} 
		set{_atk = value;}
	}

	[SerializeField]
	private Toggle _canAtkLand;
	[SerializeField]
	private Toggle _canAtkAir;
	[SerializeField]
	private Toggle _canAtkSea;
	private List<Constants.Type> _canAtkList;
	public List<Constants.Type> CanAttackList
	{ get{return _canAtkList;} }

	void Start()
	{
		_canAtkList = new List<Constants.Type>();
		_factionSelect.onValueChanged.AddListener(delegate 
			{OnFactionDropdownValueChanged(_factionSelect, ref _faction);});
		_typeSelect.onValueChanged.AddListener(delegate
			{OnTypeDropdownValueChanged(_typeSelect, ref _type);});
		_sizeSelect.onValueChanged.AddListener(delegate
			{OnSizeDropdownValueChanged(_sizeSelect, ref _size);});
		
		_armrSelect.onValueChanged.AddListener(delegate 
			{OnIntDropdownValueChanged(_armrSelect, ref _armr);});
		_atkSelect.onValueChanged.AddListener(delegate
			{OnIntDropdownValueChanged(_atkSelect, ref _atk);});
		_spdSelect.onValueChanged.AddListener(delegate
			{OnIntDropdownValueChanged(_spdSelect, ref _spd);});
		_hpField.onValueChange.AddListener(delegate
			{OnSelectUnboundedIntValueChanged(_hpField, ref _hp);});
		_nameField.onValueChange.AddListener(delegate
			{OnSelectTextValueChanged(_nameField, ref _name);});
		
		_canAtkLand.onValueChanged.AddListener(delegate
			{OnToggleCanAttkChanged(_canAtkLand, ref _canAtkList, (int)Constants.Type.LAND);});
		_canAtkAir.onValueChanged.AddListener(delegate
			{OnToggleCanAttkChanged(_canAtkAir, ref _canAtkList, (int) Constants.Type.AIR);});
		_canAtkSea.onValueChanged.AddListener(delegate
			{OnToggleCanAttkChanged(_canAtkSea, ref _canAtkList, (int) Constants.Type.SEA);});
		if(_canAtkLand.isOn)
			_canAtkList.Add(Constants.Type.LAND);
		if(_canAtkAir.isOn)
			_canAtkList.Add(Constants.Type.AIR);
		if(_canAtkSea.isOn)
			_canAtkList.Add(Constants.Type.SEA);
			

	}

	public void OnFactionDropdownValueChanged(Dropdown field, ref Constants.Faction value)
	{
        value = (Constants.Faction) field.value;
	}

	public void OnSizeDropdownValueChanged(Dropdown field, ref Constants.Size value)
	{
        value = (Constants.Size) field.value;
	}

	public void OnTypeDropdownValueChanged(Dropdown field, ref Constants.Type value)
	{
        value = (Constants.Type) field.value;
	}

	public void OnIntDropdownValueChanged(Dropdown field, ref int value)
	{
		value = field.value;
	}

	public void OnSelectTextValueChanged(InputField field, ref string value)
	{
		value = field.text;
	}

	public void OnSelectUnboundedIntValueChanged(InputField field, ref int value)
	{
		value = Convert.ToInt32(field.text);
	}

	public void OnToggleCanAttkChanged(Toggle field, ref List<Constants.Type> canAttk, int index)
	{
		Constants.Type type = (Constants.Type) index;
		if(field.isOn)
			canAttk.Add(type);
		else
			canAttk.Remove(type);
	}

	public void reset()
	{
		setValues();
	}

	public void setValues(Constants.Faction faction = (Constants.Faction) 0, 
				Constants.Type type = (Constants.Type) 0,
				Constants.Size size = (Constants.Size) 0 ,
				int hp = 0,
				string name = "",
				int armr = 0,
				int spd = 0,
				int atk = 0,
				Dictionary<Constants.Type, bool> canAttk = null)
	{
		_factionSelect.value = (int) faction;
		_typeSelect.value = (int) type;
		_sizeSelect.value = (int) size;
		
		_nameField.text = name;
		_hpField.text = hp.ToString();
		_atkSelect.value = atk;
		_armrSelect.value = armr;
		_spdSelect.value = spd;

		if(canAttk == null)
			canAttk = new Dictionary<Constants.Type, bool>();
		_canAtkLand.isOn = canAttk.ContainsKey(Constants.Type.LAND) && canAttk[Constants.Type.LAND];
		_canAtkAir.isOn = canAttk.ContainsKey(Constants.Type.AIR) && canAttk[Constants.Type.AIR];
		_canAtkSea.isOn = canAttk.ContainsKey(Constants.Type.SEA) && canAttk[Constants.Type.SEA];
	}

	public void setValues(Unit unit)
	{
		_factionSelect.value = (int) unit._faction;
		_typeSelect.value = (int) unit._type;
		_sizeSelect.value = (int) unit._size;
		
		_nameField.text = unit._name;
		_hpField.text = unit._hp.ToString();
		_atkSelect.value = unit._atk;
		_armrSelect.value = unit._armr;
		_spdSelect.value = unit._spd;

		_canAtkLand.isOn = unit._canAttack.ContainsKey(Constants.Type.LAND) && unit._canAttack[Constants.Type.LAND];
		_canAtkAir.isOn = unit._canAttack.ContainsKey(Constants.Type.AIR) && unit._canAttack[Constants.Type.AIR];
		_canAtkSea.isOn =unit._canAttack.ContainsKey(Constants.Type.SEA) && unit._canAttack[Constants.Type.SEA];
	}

	public Unit toUnit()
	{
		List<Constants.Type> canAttack = new List<Constants.Type>();
		if(_canAtkLand.isOn)
			canAttack.Add(Constants.Type.LAND);
		if(_canAtkAir.isOn)
			canAttack.Add(Constants.Type.AIR);
		if(_canAtkSea.isOn)
			canAttack.Add(Constants.Type.SEA);
		return new Unit((Constants.Faction) _factionSelect.value,
						(Constants.Type) _typeSelect.value,
						(Constants.Size) _sizeSelect.value,
						_nameField.text,
						_atkSelect.value,
						_armrSelect.value,
						_spdSelect.value,
						Convert.ToInt32(_hpField.text),
						canAttack);

	}

	public void DeleteGameObj()
	{
		Destroy(gameObject);
	}
}
