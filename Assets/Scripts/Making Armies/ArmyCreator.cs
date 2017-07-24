using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyCreator : MonoBehaviour {

	[SerializeField]
	private UIManager _ui;
	[SerializeField]
	private UnitSelect _unitSelector;
	[SerializeField]
	private ScrollRect[] _armyViews; 
	[SerializeField]
	private GameObject _unitFieldPrefab;
	[SerializeField]
	private GameObject _deleteButtonPrefab;
	[SerializeField]
	private Fight _fight;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addUnitToArmy(Unit toAdd, int armyIndex)
	{
		GameObject unitField = Instantiate(_unitFieldPrefab, _armyViews[armyIndex].content);
		unitField.GetComponent<UnitField>().setValues(toAdd);
		GameObject deleteButton = Instantiate(_deleteButtonPrefab, unitField.transform);
		deleteButton.GetComponent<ButtonClick>()._clickFunction = new buttonClicked(unitField.GetComponent<UnitField>().DeleteGameObj);
		_unitSelector.enabled = false;
		_unitSelector.gameObject.SetActive(false);
		hideArmies(false);
	}

	public void addUnitSelect(int armyIndex)
	{
		hideArmies(true);
		_unitSelector.gameObject.SetActive(true);
		_unitSelector.enabled = true;
		_unitSelector._armyIndex = armyIndex;
	}

	void hideArmies(bool toHide)
	{
		foreach(ScrollRect armyView in _armyViews)
			armyView.gameObject.SetActive(!toHide);
	}

	public void fight()
	{
		List<List<Unit>> armies = new List<List<Unit>>();
		foreach(ScrollRect armyView in _armyViews)
		{
			List<Unit> units = new List<Unit>();
			foreach(Transform unitView in armyView.content)
				units.Add(unitView.GetComponent<UnitField>().toUnit());
			armies.Add(units);
		}

		_fight.setArmies(armies);
		_ui.nextUI();
	}
}
