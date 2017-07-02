using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
using AdventureSlimes;

public class SelectedCharacter : MonoBehaviour {

	public string strEye = "";
	public string strShape = "";
	public string strColor = "";

	private UserProfileController userProfileController;
	private GameObject slimePlayerManagerObject;

	void Start() {
		userProfileController = this.gameObject.GetComponent<UserProfileController> ();
		this.slimePlayerManagerObject = GameObject.Find( "SlimePlayerManager" );
		if( slimePlayerManagerObject == null ) {
			Debug.LogError( "SlimePlayerManager GameObject not found in scene." );
		}
	}

	public void setEye( string strEye ) {
		this.strEye = strEye;
		//ChangeCharacterMaterial.Instance.eyesType = strEye;
		if( this.slimePlayerManagerObject != null ) {
			SlimePlayerManager slimePlayerManager = slimePlayerManagerObject.GetComponent( typeof( SlimePlayerManager ) ) as SlimePlayerManager;
			if( slimePlayerManager != null ) {
				slimePlayerManager.eyesType = strEye;
			} else {
				Debug.LogError( "slimePlayerManager not found in SlimePlayerManager GameObject" );
			}
		} else {
			Debug.LogError( "player_slime GameObject not found in scene. The GameObject need to be created by SlimePlayerManager class" );
		}
	}

	public void setColor( string strColor ) {
		this.strColor = strColor;
		//ChangeCharacterMaterial.Instance.colorBody = strColor;
		if( this.slimePlayerManagerObject != null ) {
			SlimePlayerManager slimePlayerManager = slimePlayerManagerObject.GetComponent( typeof( SlimePlayerManager ) ) as SlimePlayerManager;
			if( slimePlayerManager != null ) {
				slimePlayerManager.colorBody = strColor;
			} else {
				Debug.LogError( "slimePlayerManager not found in SlimePlayerManager GameObject" );
			}
		} else {
			Debug.LogError( "player_slime GameObject not found in scene. The GameObject need to be created by SlimePlayerManager class" );
		}
	}

	public void setShape( string strShape ) {
		this.strShape = strShape;
		//ChangeCharacterMaterial.Instance.bodyShape = strShape;
		if( this.slimePlayerManagerObject != null ) {
			SlimePlayerManager slimePlayerManager = slimePlayerManagerObject.GetComponent( typeof( SlimePlayerManager ) ) as SlimePlayerManager;
			if( slimePlayerManager != null ) {
				slimePlayerManager.bodyShape = strShape;
			} else {
				Debug.LogError( "slimePlayerManager not found in SlimePlayerManager GameObject" );
			}
		} else {
			Debug.LogError( "player_slime GameObject not found in scene. The GameObject need to be created by SlimePlayerManager class" );
		}
	}

	public void CreateCharacter() {
		if (strEye == "" || strColor == "" || strShape == "") {
			/* Show warning label*/
			return;
		}
		userProfileController.create_character(strShape,strEye,strColor,Token.GetUserId());
	}

}
