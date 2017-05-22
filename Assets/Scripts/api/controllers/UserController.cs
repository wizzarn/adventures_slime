using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApiController{
	public class UserController : MonoBehaviour {
		public HttpHandler httpHandlerScript = new HttpHandler();
		public void GetAll(){
			httpHandlerScript.GET(Config.apiUrl+"user/getAll",CallBackGetAll);
		}
		//public void GetById(int user_id){
		public void GetById(){
			int user_id = 1;
			httpHandlerScript.GET(Config.apiUrl+"user/getById/"+user_id.ToString(),CallBackGetById);
		}
		//public void Create(UserModel user){
		public void Create(){
			WWWForm form = new WWWForm();
			int rnd = Random.Range (1, 3000);
			string nickname = "ASDFG"+ rnd.ToString();
			UserModel newUser = new UserModel (0, nickname, "123456789", "83764555", "wizzarn@gmail.com", "");
			form.AddField("nickname",newUser.nickname);
			form.AddField("device_id",newUser.device_id);
			form.AddField("phone",newUser.phone);
			form.AddField("email",newUser.email);
			httpHandlerScript.POST(Config.apiUrl+"user/store",CallBackCreate,form);
		}
		//public void Update(int user_id, UserModel user){
		public void UpdateUser(){
			int user_id = 1;
			WWWForm form = new WWWForm();
			int rnd = Random.Range (1, 3000);
			string nickname = "ASDFG"+ rnd.ToString();
			UserModel newUser = new UserModel (0, nickname, "000000", "111111", "wizzarn@gmail.com", "");
			form.AddField("nickname",newUser.nickname);
			form.AddField("device_id",newUser.device_id);
			form.AddField("phone",newUser.phone);
			form.AddField("email",newUser.email);
			httpHandlerScript.POST(Config.apiUrl+"user/update/"+user_id.ToString(),CallBackUpdate,form);
		}
		public void Delete(){
		}


		void CallBackGetAll(string response){
			if (response == "")
				return;
			response = JsonHelper.fixJson (response);
			UserModel[] users = JsonHelper.FromJson<UserModel> (response);
			print (users);
		}
		void CallBackCreate(string response){
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
		void CallBackUpdate(string response){
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
		void CallBackGetById(string response){
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
	}
}