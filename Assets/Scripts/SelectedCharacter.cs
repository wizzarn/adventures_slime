using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;

public class SelectedCharacter : MonoBehaviour {

	public string strEye = "";
	public string strShape = "";
	public string strColor = "";

	private UserProfileController userProfileController;

	void Start() {
		userProfileController = this.gameObject.GetComponent<UserProfileController> ();
	}

	public void setEye( string strEye ) {
		this.strEye = strEye;
		ChangeCharacterMaterial.Instance.eyesType = strEye;
	}

	public void setColor( string strColor ) {
		this.strColor = strColor;
		ChangeCharacterMaterial.Instance.colorBody = strColor;
	}

	public void setShape( string strShape ) {
		this.strShape = strShape;
		ChangeCharacterMaterial.Instance.bodyShape = strShape;
	}

	public void CreateCharacter() {
		if (strEye == "" || strColor == "" || strShape == "") {
			/* Show warning label*/
			return;
		}
		userProfileController.create_character(strShape,strEye,strColor,Token.GetUserId());
	}

}
