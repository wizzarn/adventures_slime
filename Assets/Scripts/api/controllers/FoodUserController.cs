using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ApiController{
	public class FoodUserController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public FoodUserController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"foodUsers/delete/"+id,CallBackDelete,form);
		}
		public void update_(FoodUserModel foodUser, string id){
			WWWForm form = new WWWForm();
			form.AddField("user_id",foodUser.user_id);
			form.AddField("food_id",foodUser.food_id);
			form.AddField("status",foodUser.status);
			httpHandlerScript.POST(Config.apiUrl+"foodUsers/update/"+id,CallBackUpdate,form);
		}
		public void create(FoodUserModel foodUser){
			WWWForm form = new WWWForm();
			form.AddField("user_id",foodUser.user_id);
			form.AddField("food_id",foodUser.food_id);
			form.AddField("status",foodUser.status);
			httpHandlerScript.POST(Config.apiUrl+"foodUsers/store",CallBackCreate,form);
		}
		public void getByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"foodUsers/getByUserId/"+id,CallBackGetByUserId);
		}
		public void setExpired(string id){
			httpHandlerScript.GET(Config.apiUrl+"foodUsers/setExpired/"+id,CallBackSetExpired);
		}
		public void setBad(string id){
			httpHandlerScript.GET(Config.apiUrl+"foodUsers/setBad/"+id,CallBackSetBad);
		}
		void CallBackCreate(string response){
			print (response);
			if (response == "")
				return;
			FoodUserModel foodUser = JsonUtility.FromJson<FoodUserModel>(response);
			print (foodUser);
		}
		void CallBackUpdate(string response){
			if (response == "")
				return;
			FoodUserModel foodUser = JsonUtility.FromJson<FoodUserModel>(response);
			print (foodUser);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			FoodUserModel foodUser = JsonUtility.FromJson<FoodUserModel>(response);
			print (foodUser);
		}
		void CallBackGetByUserId(string response){
			if (response == "")
				return;
			FoodUserModel foodUser = JsonUtility.FromJson<FoodUserModel>(response);
			print (foodUser);
		}
		void CallBackSetExpired(string response){
			if (response == "")
				return;
			FoodUserModel foodUser = JsonUtility.FromJson<FoodUserModel>(response);
			print (foodUser);
		}
		void CallBackSetBad(string response){
			if (response == "")
				return;
			FoodUserModel foodUser = JsonUtility.FromJson<FoodUserModel>(response);
			print (foodUser);
		}
	}
}