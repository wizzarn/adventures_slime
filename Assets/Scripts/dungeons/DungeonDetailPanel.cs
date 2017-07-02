using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
public class DungeonDetailPanel : MonoBehaviour {

	public List<GameObject> txtList = new List<GameObject> ();
	public GameObject goBtnObj;
	private DungeonModel dungeonModel;
	public static bool instanceActive = false;
	private DungeonUserController dungeonUserCtrl;
	GameManager gameManagerScript;

	bool flagError = false;
	float tmrError_ = 0;
	void Start () {
		gameManagerScript = GameObject.Find ("_GM").GetComponent<GameManager> ();
		dungeonUserCtrl = GameObject.Find ("DungeonUserController").GetComponent<DungeonUserController>();
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

		this.dungeonModel = dungeonModel;
		goBtnObj.GetComponent<Button> ().onClick.AddListener (GoDungeonBtn);
		this.gameObject.SetActive (true);
		goBtnObj.SetActive (true);
	}
	public void HideDialog(){
		this.gameObject.SetActive (false);
		instanceActive = false;
		Destroy (this.gameObject);
	}
	public void GoDungeonBtn(){
		goBtnObj.SetActive (false);
		DungeonUserModel dungeonUserModel = new DungeonUserModel ("", dungeonModel.dungeon_id, Token.GetUserId (), "", "", "active", "");
		dungeonUserCtrl.create(dungeonUserModel, GoDungeonCallback);
	}
	void GoDungeonCallback(DungeonUserModel response,string error){
		if (error != "") {
			txtList [6].GetComponent<Text> ().text = error;
			SetError (true);
		} else {
			HideDialog ();
			Token.SaveCustomField ("status", "dungeon");
			gameManagerScript.MainScene ();
		}
	}
	void Update(){
		if (flagError) {
			tmrError_ += Time.deltaTime;
			if (tmrError_ > Config.errorHandlerTime)
				SetError (false);
		}
	}
	void SetError(bool active){
		if (active) {
			tmrError_ = 0;
			flagError = true;
			txtList [6].SetActive (true);
		} else {
			tmrError_ = 0;
			flagError = false;
			txtList [6].SetActive (false);
		}
	}

}
