using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour{
	public void SaveToken(){
		PlayerPrefs.SetString("UserToken", "aaaaaa");
		print (PlayerPrefs.GetString("UserToken"));
	}
	public void GetToken(){
		print (PlayerPrefs.GetString("UserToken"));

	}
}
