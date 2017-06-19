using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token : MonoBehaviour{
	public GameObject obj;

	public static string GetToken(){
		return PlayerPrefs.GetString ("userToken");
	}
	public static string GetNickname(){
		return PlayerPrefs.GetString ("nickname");
	}
	public static string GetUserId(){
		return PlayerPrefs.GetString ("user_id");
	}
	public static void ClearToken(){
		PlayerPrefs.SetString ("userToken","");
		PlayerPrefs.SetString ("user_id", "");
		PlayerPrefs.SetString ("nickname","");
	}
	public static void SaveUser(string nickname, string user_id, string remember_token){
		PlayerPrefs.SetString ("user_id", user_id);
		PlayerPrefs.SetString ("nickname",nickname);
		PlayerPrefs.SetString("userToken", remember_token);
	}
	public static void SaveCustomField(string field, string value){
		PlayerPrefs.SetString (field,value);
	}
	public static string GetCustomField(string field){
		return PlayerPrefs.GetString(field);
	}
}
