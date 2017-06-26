using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ApiController;
using UnityEngine.UI;
public class InstanceDungeon : MonoBehaviour {

	public GameObject titleObj;
	public GameObject difficultyObj;
	DungeonModel dungeonModel; 
	public GameObject viewDetailsBtnObj;
	public GameObject dungeonDetailPanelObj;

	public void Instance(DungeonModel dungeonModel){
		titleObj.GetComponent<Text> ().text = dungeonModel.name;
		difficultyObj.GetComponent<Text> ().text = dungeonModel.status;
		this.dungeonModel = dungeonModel;
		viewDetailsBtnObj.GetComponent<Button> ().onClick.AddListener (OpenDetailPanel);
	}

	void OpenDetailPanel(){
		GameObject newModalInstance = (GameObject)Instantiate (dungeonDetailPanelObj);
		newModalInstance.transform.parent = this.transform.parent;
		newModalInstance.transform.localScale = new Vector3 (1, 1, 1);
		newModalInstance.transform.localPosition = new Vector3 (17, 5, 0);
		newModalInstance.GetComponent<DungeonDetailPanel> ().ShowDialog (dungeonModel);
		newModalInstance.SetActive (true);
		//dungeonDetailPanelObj.GetComponent<DungeonDetailPanel> ().ShowDialog (dungeonModel);
	}
}
