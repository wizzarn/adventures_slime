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
		public GameObject objErrorHandler;


		public void GetAll(){
			httpHandlerScript.GET(Config.apiUrl+"user/getAll",CallBackGetAll);
		}
		public void GetById(){
			int user_id = 1;
			httpHandlerScript.GET(Config.apiUrl+"user/getById/"+user_id.ToString(),CallBackGetById);
		}
		public void Login(string nickname, string password){
			string error = "";
			if (nickname == "" || nickname.Length < 5 || nickname.Length > 15)
				error+= "Please specify a valid nickname";
			if (password == "" || password.Length < 5 || password.Length > 15)
				error+= "\nPlease specify a valid password";
			if (error != "") {
				objErrorHandler.GetComponent<ErrorHandler> ().SetFontSize (27);
				objErrorHandler.GetComponent<ErrorHandler> ().EnableError (error);
				return;
			}
			WWWForm form = new WWWForm();
			form.AddField("nickname",nickname);
			form.AddField("password",password);
			httpHandlerScript.POST(Config.apiUrl+"user/login",CallBackLogin,form);
		}
		public void Create(){
			string error = "";
			if (txtNickname.text == "" || txtNickname.text.Length < 5 || txtNickname.text.Length > 15)
				error+= "Please specify a valid nickname";
			if (txtPassword.text == "" || txtPassword.text.Length < 5 || txtPassword.text.Length > 15)
				error+= "\nPlease specify a valid password";
			
			if (error != "") {
				objErrorHandler.GetComponent<ErrorHandler> ().SetFontSize (27);
				objErrorHandler.GetComponent<ErrorHandler> ().EnableError (error);
				return;
			}
			WWWForm form = new WWWForm();
			UserModel newUser = new UserModel ("0", txtNickname.text, txtPassword.text, SystemInfo.deviceUniqueIdentifier, "83764555", txtEmail.text, "","", "","","","");
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
			UserModel newUser = new UserModel ("0", nickname, "abc123","000000", "111111", "wizzarn@gmail.com","", "","","","","");
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
			if (response == "nickname_taken") {
				objErrorHandler.GetComponent<ErrorHandler> ().SetFontSize (30);
				objErrorHandler.GetComponent<ErrorHandler> ().EnableError ("Nickname already taken");
				return;
			}
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
			if (response != "wrong") {
				UserModel user = JsonUtility.FromJson<UserModel> (response);
				Token.SaveUser (user.nickname, user.user_id, user.remember_token);
				Token.SaveCustomField ("sleeping", user.sleeping);
				print (response);
				if (user.shape == null || user.shape == "") {
					gameManager.CreateCharacterScene ();
				} else
					gameManager.MainScene ();
			} else {
				objErrorHandler.GetComponent<ErrorHandler> ().EnableError ("Incorrect, please try again");
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