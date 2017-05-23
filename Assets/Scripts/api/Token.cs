using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token : MonoBehaviour{
	public GameObject obj;
	public static void SaveToken(string token){
		PlayerPrefs.SetString("UserToken", token);
		print (PlayerPrefs.GetString ("UserToken"));
	}
	public static string GetToken(){
		return PlayerPrefs.GetString ("UserToken");
	}
	public void ClearToken(){
		PlayerPrefs.SetString ("UserToken","");
	}
	public static void SaveUser(string nickname, string password){
		PlayerPrefs.SetString ("nickname",nickname);
		PlayerPrefs.SetString ("password",password);
	}
	public static string[] GetUser(){
		string[] response = new string[2];
		response [0] = PlayerPrefs.GetString ("nickname");
		response [1] = PlayerPrefs.GetString ("password");
		return response;
	}
}
