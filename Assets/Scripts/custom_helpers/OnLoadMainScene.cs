using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
public class OnLoadMainScene : MonoBehaviour {

	public GameObject gameManagerOBJ;

	float tmrDirectionalLight = 0;
	float tmrDelay = .02f;
	public GameObject directionalLightOBJ;
	string flagLightEffect = "done";
	public GameObject objStatusUser;

	public DungeonUserController dungeonUserCtrl;
	public float tmr_ = 0;
	float tmrUpdateDungeonStat = 60;
	/*Dungeon Panel Stats Panel */
	public GameObject txtDungeonName;
	public GameObject txtDungeonMinutes;
	public GameObject panelDungeon;

	public GameObject dungeonRewardObj;
	public GameObject dungeonRewardStatus;
	public GameObject dungeonRewardExp;
	public GameObject dungeonRewardCash;
	public GameObject dungeonRewardItems;
	public GameObject dungeonRewardDungeonName;

	void Start () {
		directionalLightOBJ = GameObject.Find ("Directional light");
		gameManagerOBJ = GameObject.Find ("_GM");
		if (Token.GetCustomField ("sleeping") == "1") { 
			gameManagerOBJ.GetComponent<GameManager> ().InGameSleep ();
			flagLightEffect = "dark";
			objStatusUser.GetComponent<Text>().text = "Sleeping";
			objStatusUser.GetComponent<Text> ().color = Color.blue;
		} else if (Token.GetCustomField ("sleeping") == "0") {
			gameManagerOBJ.GetComponent<GameManager> ().InGameWakeup ();
			flagLightEffect = "bright";
			objStatusUser.GetComponent<Text>().text = "Active";
			objStatusUser.GetComponent<Text> ().color = Color.green;
		}
		if (Token.GetCustomField ("status") == "dungeon") {
			objStatusUser.GetComponent<Text>().text = "In Dungeon";
			objStatusUser.GetComponent<Text> ().color = Color.red;
			gameManagerOBJ.GetComponent<GameManager> ().SetMainButtons (false);
			dungeonUserCtrl.getActiveDungeonByUserId (getActiveDungeonCallback);
		}
	}
	void getActiveDungeonCallback(DungeonUserModel result, string error){
		panelDungeon.SetActive (true);
		if (float.Parse(result.minutes) <= 0) 
			txtDungeonMinutes.GetComponent<Text> ().text = "less than 1 minute";
		else
			txtDungeonMinutes.GetComponent<Text> ().text = result.minutes + " minutes";
		txtDungeonName.GetComponent<Text> ().text = result.name;
		if (float.Parse(result.minutes) < 0) {
			Token.SaveCustomField ("status","active");
			panelDungeon.SetActive (false);
			objStatusUser.GetComponent<Text>().text = "Active";
			objStatusUser.GetComponent<Text> ().color = Color.green;
			txtDungeonMinutes.GetComponent<Text> ().text = " ";
			txtDungeonName.GetComponent<Text> ().text = " ";
			gameManagerOBJ.GetComponent<GameManager> ().SetMainButtons (true);
			EnableRewardsPanel (result);
		}
	}
	void EnableRewardsPanel(DungeonUserModel data){
		if (data.rewards.itemsReward != "")
			data.rewards.itemsReward = data.rewards.itemsReward.Replace(",", "\n");
		dungeonRewardObj.SetActive(true);
		dungeonRewardStatus.GetComponent<Text>().text = data.rewards.dungeonStatus;
		dungeonRewardExp.GetComponent<Text>().text = data.rewards.expReward;
		dungeonRewardCash.GetComponent<Text>().text = data.rewards.cashReward;
		dungeonRewardItems.GetComponent<Text>().text = data.rewards.itemsReward;
		dungeonRewardDungeonName.GetComponent<Text> ().text = data.rewards.dungeonName;

		if (data.rewards.dungeonStatus == "COMPLETE"){
			dungeonRewardStatus.GetComponent<Text> ().color = Color.green;
		}else
			dungeonRewardStatus.GetComponent<Text> ().color = Color.red;
	}
	public void HideRewardsPanel(){
		dungeonRewardObj.SetActive (false);
	}
	public void SetDark(){
		flagLightEffect = "dark";
	}
	public void SetBright(){
		flagLightEffect = "bright";
	}
	void Update(){
		if (Token.GetCustomField ("status") == "dungeon") {
			tmr_ += Time.deltaTime;
			print (tmr_);
			if (tmr_ > tmrUpdateDungeonStat) {
				tmr_ = 0;
				dungeonUserCtrl.getActiveDungeonByUserId (getActiveDungeonCallback);
			}
		}
		if (flagLightEffect == "done")
			return;
		if (flagLightEffect == "dark") {
			tmrDirectionalLight += Time.deltaTime;
			if (tmrDirectionalLight > tmrDelay) {
				tmrDirectionalLight = 0;
				if (directionalLightOBJ.GetComponent<Light> ().intensity > 0)
					directionalLightOBJ.GetComponent<Light> ().intensity -= .05f;
				else
					flagLightEffect = "done";
			} 
		}else if (flagLightEffect == "bright") {
			tmrDirectionalLight += Time.deltaTime;
			if (tmrDirectionalLight > tmrDelay) {
				tmrDirectionalLight = 0;
				if (directionalLightOBJ.GetComponent<Light> ().intensity < 1)
					directionalLightOBJ.GetComponent<Light> ().intensity += .05f;
				else
					flagLightEffect = "done";
			} 
		}
	}
}
