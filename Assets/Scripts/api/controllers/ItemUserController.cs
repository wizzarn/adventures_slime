using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class ItemUserController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();

		public void getByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"itemsUsers/getByUserId/"+id,CallBackGetByUserId);
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"itemsUsers/destroy/"+id,CallBackDelete,form);
		}
		public void getByUserIds(string ids){
			httpHandlerScript.GET(Config.apiUrl+"itemsUsers/getByUserIds/"+ids,CallBackGetByUserIds);
		}
		public void createUserItem(ItemUserModel userItem){
			WWWForm form = new WWWForm();
			form.AddField("user_id",userItem.user_id);
			form.AddField("item_id",userItem.item_id);
			form.AddField("status",userItem.status);
			httpHandlerScript.POST(Config.apiUrl+"itemsUsers/store",CallBackCreate,form);
		}
		public void setBroken(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"itemsUsers/setBroken/"+id,CallBackSetBroken,form);
		}
		void CallBackCreate(string response){
			print (response);
			if (response == "")
				return;
			ItemUserModel itemUser = JsonUtility.FromJson<ItemUserModel>(response);
			print (itemUser);
		}
		void CallBackGetByUserId(string response){
			if (response == "")
				return;
			ItemUserModel userItem = JsonUtility.FromJson<ItemUserModel>(response);
			print (userItem);
		}
		void CallBackGetByUserIds(string response){
			if (response == "")
				return;
			response = JsonHelper.fixJson (response);
			ItemUserModel[] userItem = JsonHelper.FromJson<ItemUserModel> (response);
			print (userItem);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			ItemUserModel userItem = JsonUtility.FromJson<ItemUserModel>(response);
			print (userItem);
		}
		void CallBackSetBroken(string response){
			if (response == "")
				return;
			ItemUserModel userItem = JsonUtility.FromJson<ItemUserModel>(response);
			print (userItem);
		}

	}
}