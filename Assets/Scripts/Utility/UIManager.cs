using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private GameObject[] _UIs;
	private int _index;
	void Start () {
		foreach(GameObject ui in _UIs)
			ui.SetActive(false);
		_index = 0;
		_UIs[_index].SetActive(true);
	}
	
	public void nextUI()
	{
		_UIs[_index].SetActive(false);
		_index = Mathf.Min( _index +1, _UIs.Length - 1);
		_UIs[_index].SetActive(true);
	}

	public void previousUI()
	{
		_UIs[_index].SetActive(false);
		_index = Mathf.Max( _index - 1, 0);
		_UIs[_index].SetActive(true);
	}
}
