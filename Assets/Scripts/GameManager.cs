using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ApiController;
public class GameManager : MonoBehaviour {
	public GameObject NicknameOBJ;
	public GameObject PasswordOBJ;
	public UserController UserController;
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
		Token.SaveToken ("");
	}
	public void Login(){
		UserController.Login (NicknameOBJ.GetComponent<Text>().text,PasswordOBJ.GetComponent<Text>().text);
	}
}
