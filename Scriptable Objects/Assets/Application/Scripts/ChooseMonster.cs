using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;

[DisallowMultipleComponent]
public class ChooseMonster : MonoBehaviour {
	Dropdown MonsterList;
	[Tooltip("List monsters here")]
	public string[] monsterList;
	Dropdown.OptionData newData;
	List<Dropdown.OptionData> newMonsterToAdd = new List<Dropdown.OptionData>();
	int ArrayLength;

	UnityEngine.Object[] Assets;

	[Header("To manage related GameObjects")]
	public GameObject RefChooseMonsterMenu;
	public GameObject RefMonsterBoard;
	public GameObject RefMonsterManager;

	void Start() {
		MonsterList = GetComponent<Dropdown> ();

		Assets = Resources.LoadAll ("Monsters", typeof(Monster));
		/*foreach(var a in Assets) {
			print (a.name);
		}*/
		ArrayLength = Assets.Length;
		monsterList = new string[ArrayLength];

		NewDropdown();

		MonsterList.onValueChanged.AddListener (delegate {
			DropDownValueChanged(MonsterList);
		});
	}

	void NewDropdown() {
		for (int i=0; i<ArrayLength; i++) {
			monsterList [i] = Assets[i].ToString ().Replace(" (Monster)", "");
			//monsterList [i] = Assets[i].ToString ().Replace(" (Monster)", "");

			//print (monsterList [i]);
			newData = new Dropdown.OptionData ();
			newData.text = monsterList[i];
			newMonsterToAdd.Add (newData);
		}
			
		foreach(Dropdown.OptionData message in newMonsterToAdd) {
			MonsterList.options.Add (message);
		}
	}

	void DropDownValueChanged(Dropdown dropdown) {
		int dropDownValue = dropdown.value;
		RefMonsterBoard.GetComponent<MonsterDisplay>().monster = Resources.Load ("Monsters/" + dropdown.options[dropDownValue].text) as Monster;
		RefMonsterBoard.GetComponent<MonsterDisplay> ().DisplayMonster ();
		RefMonsterManager.GetComponent<MonsterManager> ().SetWheelsPosition ();
		GameObject ToDestroy = GameObject.Find ("Dropdown List").gameObject;
		Destroy (ToDestroy);
		RefChooseMonsterMenu.SetActive (false);
	}
}
