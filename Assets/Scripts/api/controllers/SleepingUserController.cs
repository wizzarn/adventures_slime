using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{

	public class SleepingUserController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public GameObject gameManagerOBJ;
		OnLoadMainScene loadMainSceneScript;
		public void Start(){
			gameManagerOBJ = GameObject.Find ("_GM");
			loadMainSceneScript = GameObject.Find ("OnLoadScene").GetComponent<OnLoadMainScene>();
		}
		public void getByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"sleepingUsers/getByUserId/"+id,CallBackGetByUserId);
		}
		public void deleteSleepingUser(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"sleepingUsers/delete/"+id,CallBackDelete,form);
		}
		public void getByUserIds(string ids){
			httpHandlerScript.GET(Config.apiUrl+"sleepingUsers/getByUserIds/"+ids,CallBackGetByUserIds);
		}
		public void sleepUser(string session, string id){
			WWWForm form = new WWWForm();
			form.AddField ("session",session);
			form.AddField ("id",id);
			httpHandlerScript.POST(Config.apiUrl+"sleepingUsers/sleepUser",CallBackSleepUser,form);
		}
		public void wakeUpUser(string session, string id){
			WWWForm form = new WWWForm();
			form.AddField ("session",session);
			form.AddField ("id",id);
			httpHandlerScript.POST(Config.apiUrl+"sleepingUsers/wakeUpUser",CallBackWakeUpUser, form);
		}
		 
		//CALLBACKS

		void CallBackGetByUserId(string response){
			if (response == "")
				return;
			SleepingUserModel sleepingUser = JsonUtility.FromJson<SleepingUserModel>(response);
			print (sleepingUser);
		}
		void CallBackGetByUserIds(string response){
			if (response == "")
				return;
			response = JsonHelper.fixJson (response);
			SleepingUserModel[] sleepingUser = JsonHelper.FromJson<SleepingUserModel> (response);
			print (sleepingUser);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			SleepingUserModel sleepingUser = JsonUtility.FromJson<SleepingUserModel>(response);
			print (sleepingUser);
		}
		void CallBackSleepUser(string response){
			if (response == "")
				return;
			SleepingUserModel sleepingUser = JsonUtility.FromJson<SleepingUserModel>(response);
			print (sleepingUser);
			Token.SaveCustomField ("sleeping","1");
			gameManagerOBJ.GetComponent<GameManager>().InGameSleep ();
			loadMainSceneScript.SetDark ();
		}
		void CallBackWakeUpUser(string response){
			if (response == "")
				return;
			SleepingUserModel sleepingUser = JsonUtility.FromJson<SleepingUserModel>(response);
			print (sleepingUser);
			Token.SaveCustomField ("sleeping","0");
			gameManagerOBJ.GetComponent<GameManager>().InGameWakeup ();
			loadMainSceneScript.SetBright ();
		}
	}

}