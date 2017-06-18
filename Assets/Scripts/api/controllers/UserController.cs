using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ApiController{

	public class UserController : MonoBehaviour {
		public HttpHandler httpHandlerScript = new HttpHandler();
		public GameManager gameManager;

		public Text txtNickname;
		public Text txtPassword;
		public Text txtEmail;
		public void GetAll(){
			httpHandlerScript.GET(Config.apiUrl+"user/getAll",CallBackGetAll);
		}
		public void GetById(){
			int user_id = 1;
			httpHandlerScript.GET(Config.apiUrl+"user/getById/"+user_id.ToString(),CallBackGetById);
		}
		public void Login(string nickname, string password){
			WWWForm form = new WWWForm();
			form.AddField("nickname",nickname);
			form.AddField("password",password);
			httpHandlerScript.POST(Config.apiUrl+"user/login",CallBackLogin,form);
		}
		public void Create(){
			WWWForm form = new WWWForm();
			UserModel newUser = new UserModel ("0", txtNickname.text, txtPassword.text, SystemInfo.deviceUniqueIdentifier, "83764555", txtEmail.text, "","", "");
			form.AddField("nickname",newUser.nickname);
			form.AddField("password",newUser.password);
			form.AddField("device_id",newUser.device_id);
			form.AddField("phone",newUser.phone);
			form.AddField("email",newUser.email);
			form.AddField("remember_token",newUser.remember_token);
			httpHandlerScript.POST(Config.apiUrl+"user/store",CallBackCreate,form);
		}
		public void UpdateUser(){
			int user_id = 1;
			WWWForm form = new WWWForm();
			int rnd = Random.Range (1, 3000);
			string nickname = "ASDFG"+ rnd.ToString();
			UserModel newUser = new UserModel ("0", nickname, "abc123","000000", "111111", "wizzarn@gmail.com","", "","");
			form.AddField("nickname",newUser.nickname);
			form.AddField("password",newUser.password);
			form.AddField("device_id",newUser.device_id);
			form.AddField("phone",newUser.phone);
			form.AddField("email",newUser.email);
			form.AddField("remember_token",newUser.remember_token);
			httpHandlerScript.POST(Config.apiUrl+"user/update/"+user_id.ToString(),CallBackUpdate,form);
		}
		public void Logout(string session, string id){
			httpHandlerScript.GET(Config.apiUrl+"user/logout/"+session + "/"+id,CallBackLogout);
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
			print (response);
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			Login (user.nickname,txtPassword.text);
			print (user);
		}
		void CallBackUpdate(string response){
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
		void CallBackGetById(string response){
			if (response == "") return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			UserModel user = JsonUtility.FromJson<UserModel>(response);
			print (user);
		}
		void CallBackLogin(string response){
			if (response != "wrong"){
				UserModel user = JsonUtility.FromJson<UserModel>(response);
				Token.SaveUser(user.nickname,user.user_id,user.remember_token);
				Token.SaveCustomField ("sleeping",user.sleeping);
				print (response);
				gameManager.MainScene ();
			}
		}
		void CallBackLogout(string response){
			if (response == "ok"){
				Token.ClearToken ();
				print (response);
				gameManager.LoginScene();
			}

		}
	}
}