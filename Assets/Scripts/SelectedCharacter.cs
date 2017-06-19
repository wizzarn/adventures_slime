using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
public class SelectedCharacter : MonoBehaviour {
	public string strEye = "";
	public string strShape = "";
	public string strColor = "";

	public GameObject objEye;
	public GameObject objShape;
	public GameObject objColor;
	private UserProfileController userProfileController;
	void Start(){
		userProfileController = this.gameObject.GetComponent<UserProfileController> ();
	}
	public void setEye(string strEye){
		this.strEye = strEye;
		objEye.GetComponentInChildren<Text> ().text = strEye;
	}
	public void setColor(string strColor){
		this.strColor = strColor;
		objColor.GetComponentInChildren<Text> ().text = strColor;
	}
	public void setShape(string strShape){
		this.strShape = strShape;
		objShape.GetComponentInChildren<Text> ().text = strShape;
	}
	public void CreateCharacter(){
		if (strEye == "" || strColor == "" || strShape == ""){
			/* Show warning label*/
			return;
		}
		userProfileController.create_character(strShape,strEye,strColor,Token.GetUserId());
	}

}
