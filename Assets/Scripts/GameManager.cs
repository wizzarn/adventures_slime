using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
public class GameManager : MonoBehaviour {
	public GameObject NicknameOBJ;
	public GameObject PasswordOBJ;
	public UserController userController;
	public SleepingUserController sleepUser;
	public GameObject mainButtonsOBJ;
	public GameObject wakeUpButtonOBJ;

	public IEnumerator ChangeScene(int SceneIndex){
		float fadeTime = GameObject.Find ("_GM").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (SceneIndex);
	}
	public void MyStatsScene(){
		StartCoroutine(ChangeScene(2));
	}
	public void DungeonScene(){
		StartCoroutine(ChangeScene(3));
	}
	public void MainScene(){
		StartCoroutine(ChangeScene(1));
	}
	public void LoginScene(){
		StartCoroutine(ChangeScene(6));
	}
	public void RegisterScene(){
		StartCoroutine(ChangeScene(7));
	}
	public void Logout(){
		userController.Logout (Token.GetToken(),Token.GetUserId());
	}
	public void Login(){
		userController.Login (NicknameOBJ.GetComponent<Text>().text,PasswordOBJ.GetComponent<Text>().text);
	}
	public void SleepUser(){
		sleepUser.sleepUser (Token.GetToken(),Token.GetUserId());
	}
	public void WakeUpUser(){
		sleepUser.wakeUpUser (Token.GetToken(),Token.GetUserId());
	}
	public void InGameSleep(){
		if (mainButtonsOBJ && wakeUpButtonOBJ) {
			mainButtonsOBJ.SetActive (false);
			wakeUpButtonOBJ.SetActive (true);
		}
	}
	public void InGameWakeup(){
		if (mainButtonsOBJ && wakeUpButtonOBJ) {
			mainButtonsOBJ.SetActive (true);
			wakeUpButtonOBJ.SetActive (false);
		}
	}		

}
