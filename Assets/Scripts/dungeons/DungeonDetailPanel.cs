using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
public class DungeonDetailPanel : MonoBehaviour {

	public List<GameObject> txtList = new List<GameObject> ();
	bool hasLength = false;
	public static bool instanceActive = false;
	void Start () {
		if (txtList.Count > 0)
			hasLength = true;
	}

	public void ShowDialog(DungeonModel dungeonModel){
		if (txtList.Count < 1)
			return;
		txtList [0].GetComponent<Text> ().text = dungeonModel.level_required;
		txtList [1].GetComponent<Text> ().text = dungeonModel.durability;
		txtList [2].GetComponent<Text> ().text = dungeonModel.name;
		txtList [3].GetComponent<Text> ().text = dungeonModel.status;
		txtList [4].GetComponent<Text> ().text = dungeonModel.exp_reward_range;
		txtList [5].GetComponent<Text> ().text = dungeonModel.cash_reward_range;
		this.gameObject.SetActive (true);
	}
	public void HideDialog(){
		this.gameObject.SetActive (false);
		instanceActive = false;
		Destroy (this.gameObject);
	}
	void Update () {
	}
}
