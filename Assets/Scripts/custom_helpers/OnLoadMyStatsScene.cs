using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ApiController;
using UnityEngine.UI;

public class OnLoadMyStatsScene : MonoBehaviour {

	public List<GameObject> txtObjets;
	private bool hasLength = false;
	public UserProfileController userProfileCtrl;

	void Start () {
		if (txtObjets.Count > 0)
			hasLength = true;
		if (Token.GetUserId() != "" && userProfileCtrl)
			userProfileCtrl.getByUserId (Token.GetUserId(),GetByUseIdCallback);
	}
	void GetByUseIdCallback(UserProfileModel response){
		txtObjets [0].GetComponent<Text> ().text = response.phys_dmg;
		txtObjets [1].GetComponent<Text> ().text = response.inte;
		txtObjets [2].GetComponent<Text> ().text = response.str;
		txtObjets [3].GetComponent<Text> ().text = response.agi;
		txtObjets [4].GetComponent<Text> ().text = response.experience;
		txtObjets [5].GetComponent<Text> ().text = response.level;
		txtObjets [6].GetComponent<Text> ().text = response.tired_points;
		txtObjets [7].GetComponent<Text> ().text = response.hungry_points;
		txtObjets [8].GetComponent<Text> ().text = response.status;
		txtObjets [9].GetComponent<Text> ().text = response.hp;
		txtObjets [10].GetComponent<Text> ().text = response.armor;
		print (response);
	}

}
