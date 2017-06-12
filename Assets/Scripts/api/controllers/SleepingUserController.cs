using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{

	public class SleepingUserController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();

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
		public void sleepUser(string id){
			httpHandlerScript.GET(Config.apiUrl+"sleepingUsers/sleepUser/"+id,CallBackSleepUser);
		}
		public void wakeUpUser(string id){
			httpHandlerScript.GET(Config.apiUrl+"sleepingUsers/wakeUpUser/"+id,CallBackWakeUpUser);
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
		}
		void CallBackWakeUpUser(string response){
			if (response == "")
				return;
			SleepingUserModel sleepingUser = JsonUtility.FromJson<SleepingUserModel>(response);
			print (sleepingUser);
		}
	}

}