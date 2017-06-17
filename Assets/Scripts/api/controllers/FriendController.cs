using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{
	public class FriendController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public FriendController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"friends/delete/"+id,CallBackDelete,form);
		}
		public void update_(FriendModel friendModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("friend_id",friendModel.friend_id);
			form.AddField("friend_from",friendModel.friend_from);
			form.AddField("friend_to",friendModel.friend_to);
			form.AddField("status",friendModel.status);
			httpHandlerScript.POST(Config.apiUrl+"friends/update/"+id,CallBackUpdate,form);
		}
		public void create(FriendModel friendModel){
			WWWForm form = new WWWForm();
			form.AddField("friend_id",friendModel.friend_id);
			form.AddField("friend_from",friendModel.friend_from);
			form.AddField("friend_to",friendModel.friend_to);
			form.AddField("status",friendModel.status);
			httpHandlerScript.POST(Config.apiUrl+"friends/store",CallBackCreate,form);
		}
		public void getAllFriendsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"friends/getAllFriendsByUserId/"+id,CallBackGetAllFriendsByUserId);
		}
		public void getAcceptedFriendsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"friends/getAcceptedFriendsByUserId/"+id,CallBackGetAcceptedFriendsByUserId);
		}
		public void getPendingFriendsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"friends/getPendingFriendsByUserId/"+id,CallBackGetPendingFriendsByUserId);
		}
		public void getDeclinedFriendsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"friends/getDeclinedFriendsByUserId/"+id,CallBackGetDeclinedFriendsByUserId);
		}
		public void removeFriend(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"friends/removeFriend/"+id,CallBackDelete,form);
		}
		/* * * * * * * *  
		 * CALLBACKS
		 * * * * * * * */
		void CallBackGetAllFriendsByUserId(string response){
			if (response == "")
				return;
			UserProfileModel userProfile = JsonUtility.FromJson<UserProfileModel>(response);
			print (userProfile);
		}
		void CallBackGetAcceptedFriendsByUserId(string response){
			if (response == "")
				return;
			UserProfileModel userProfile = JsonUtility.FromJson<UserProfileModel>(response);
			print (userProfile);
		}
		void CallBackGetPendingFriendsByUserId(string response){
			if (response == "")
				return;
			UserProfileModel userProfile = JsonUtility.FromJson<UserProfileModel>(response);
			print (userProfile);
		}
		void CallBackGetDeclinedFriendsByUserId(string response){
			if (response == "")
				return;
			UserProfileModel userProfile = JsonUtility.FromJson<UserProfileModel>(response);
			print (userProfile);
		}
		void CallBackCreate(string response){
			print (response);
			if (response == "")
				return;
			FriendModel friend = JsonUtility.FromJson<FriendModel>(response);
			print (friend);
		}
		void CallBackUpdate(string response){
			if (response == "")
				return;
			FriendModel friend = JsonUtility.FromJson<FriendModel>(response);
			print (friend);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			FriendModel friend = JsonUtility.FromJson<FriendModel>(response);
			print (friend);
		}

	}
}