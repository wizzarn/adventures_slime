using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ApiController;
using UnityEngine.UI;

public class OnLoadTrainScene : MonoBehaviour {

	public List<GameObject> txtObjets;
	private bool hasLength = false;
	public UserProfileController userProfileCtrl;

	int intPoints = 0;
	int agiPoints = 0;
	int hpPoints = 0;
	int strPoints = 0;
	int spendingPoints = 0;
	UserProfileModel userProfileModel;
	public GameObject saveBtnObj;
	public GameObject userProfileObj;
	public GameObject gameManagerObj;
	void Start () {
		if (txtObjets.Count > 0)
			hasLength = true;
		if (Token.GetUserId() != "" && userProfileCtrl)
			userProfileCtrl.getByUserId (Token.GetUserId(),GetByUseIdCallback);
	}
	void GetByUseIdCallback(UserProfileModel response){
		if (!hasLength)
			return;
		userProfileModel = response;
		txtObjets [0].GetComponent<Text> ().text = response.phys_dmg;
		txtObjets [1].GetComponent<Text> ().text = response.inte;
		txtObjets [2].GetComponent<Text> ().text = response.str;
		txtObjets [3].GetComponent<Text> ().text = response.agi;
		txtObjets [4].GetComponent<Text> ().text = response.experience;
		txtObjets [5].GetComponent<Text> ().text = response.level;
		txtObjets [6].GetComponent<Text> ().text = response.tired_points;
		txtObjets [7].GetComponent<Text> ().text = response.hungry_points;
		txtObjets [8].GetComponent<Text> ().text = response.max_hp;
		txtObjets [9].GetComponent<Text> ().text = response.armor;
		txtObjets [10].GetComponent<Text> ().text = response.spending_points;
		spendingPoints = int.Parse(response.spending_points);
		print (response);
		if (spendingPoints < 1)
			saveBtnObj.SetActive(false);
	}
	void UpdateSpendingPointsTxt(){
		txtObjets [10].GetComponent<Text> ().text = spendingPoints.ToString();
	}
	public void IncreaseHP(){
		if (spendingPoints < 1)
			return;
		hpPoints++;
		spendingPoints--;
		UpdateSpendingPointsTxt ();
		txtObjets [8].GetComponent<Text> ().text = (int.Parse(txtObjets [8].GetComponent<Text> ().text) + 1).ToString();

	}
	public void IncreaseAGI(){
		if (spendingPoints < 1)
			return;
		agiPoints++;
		spendingPoints--;
		UpdateSpendingPointsTxt ();
		txtObjets [3].GetComponent<Text> ().text = (int.Parse(txtObjets [3].GetComponent<Text> ().text) + 1).ToString();
	}
	public void IncreaseSTR(){
		if (spendingPoints < 1)
			return;
		strPoints++;
		spendingPoints--;
		UpdateSpendingPointsTxt ();
		txtObjets [2].GetComponent<Text> ().text = (int.Parse(txtObjets [2].GetComponent<Text> ().text) + 1).ToString();
	}
	public void IncreaseINT(){
		if (spendingPoints < 1)
			return;
		agiPoints++;
		spendingPoints--;
		UpdateSpendingPointsTxt ();
		txtObjets [1].GetComponent<Text> ().text = (int.Parse(txtObjets [1].GetComponent<Text> ().text) + 1).ToString();
	}
	public void ResetPoints(){
		txtObjets [1].GetComponent<Text> ().text = userProfileModel.inte;
		txtObjets [2].GetComponent<Text> ().text = userProfileModel.str;
		txtObjets [3].GetComponent<Text> ().text = userProfileModel.agi;
		txtObjets [8].GetComponent<Text> ().text = userProfileModel.max_hp;
		txtObjets [10].GetComponent<Text> ().text = userProfileModel.spending_points;
		spendingPoints = int.Parse(userProfileModel.spending_points);
		intPoints = 0;
		agiPoints = 0;
		hpPoints = 0;
		strPoints = 0;
		UpdateSpendingPointsTxt ();
	}
	public void UpdateStats(){
		UserProfileModel userProfileModel = new UserProfileModel ();
		userProfileModel.inte = txtObjets [1].GetComponent<Text> ().text;
		userProfileModel.str = txtObjets [2].GetComponent<Text> ().text;
		userProfileModel.agi = txtObjets [3].GetComponent<Text> ().text;
		userProfileModel.spending_points = txtObjets [10].GetComponent<Text> ().text;
		userProfileModel.max_hp = txtObjets [8].GetComponent<Text> ().text;
		userProfileObj.GetComponent<UserProfileController>().updateStats (userProfileModel, CallBackUpdateStats);
		saveBtnObj.SetActive(false);

	}
	void CallBackUpdateStats(UserProfileModel userProfileModel, string errorString){
		print (userProfileModel);
		gameManagerObj.GetComponent<GameManager> ().MainScene ();
	}
}
