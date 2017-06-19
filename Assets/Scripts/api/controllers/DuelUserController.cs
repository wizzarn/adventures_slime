using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class DuelUserController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public DuelUserController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"duelsUsers/delete/"+id,CallBackDelete,form);
		}
		public void update_(DuelUserModel duelUserModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("user_from_id",duelUserModel.user_from_id);
			form.AddField("user_to_id",duelUserModel.user_to_id);
			form.AddField("status",duelUserModel.status);
			form.AddField("init_date",duelUserModel.init_date);
			form.AddField("end_date",duelUserModel.end_date);
			form.AddField("user_won",duelUserModel.user_won);
			form.AddField("durability_lost",duelUserModel.durability_lost);
			form.AddField("cash_lost",duelUserModel.cash_lost);
			form.AddField("hungry_cost",duelUserModel.hungry_cost);
			form.AddField("tired_cost",duelUserModel.tired_cost);
			httpHandlerScript.POST(Config.apiUrl+"duelsUsers/update/"+id,CallBackUpdate,form);
		}
		public void create(DuelUserModel duelUserModel){
			WWWForm form = new WWWForm();
			form.AddField("user_from_id",duelUserModel.user_from_id);
			form.AddField("user_to_id",duelUserModel.user_to_id);
			form.AddField("status",duelUserModel.status);
			form.AddField("init_date",duelUserModel.init_date);
			form.AddField("end_date",duelUserModel.end_date);
			form.AddField("user_won",duelUserModel.user_won);
			form.AddField("durability_lost",duelUserModel.durability_lost);
			form.AddField("cash_lost",duelUserModel.cash_lost);
			form.AddField("hungry_cost",duelUserModel.hungry_cost);
			form.AddField("tired_cost",duelUserModel.tired_cost);
			httpHandlerScript.POST(Config.apiUrl+"duelsUsers/store",CallBackCreate,form);
		}
		public void getById(string id){
			httpHandlerScript.GET(Config.apiUrl+"duelsUsers/getById/"+id,CallBackGetById);
		}
		public void getAllDuelsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"duelsUsers/getAllDuelsByUserId/"+id,CallBackGetAllDuelsByUserId);
		}
		public void getWonDuelsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"duelsUsers/getWonDuelsByUserId/"+id,CallBackGetWonDuelsByUserId);
		}
		public void setCompleted(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"duelsUsers/setCompleted/"+id,CallBackSetCompleted,form);
		}
		public void setDeclined(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"duelsUsers/setDeclined/"+id,CallBackSetDeclined,form);
		}
		/* * * * * * * 
		 *  CALLBACKS 
		 * * * * * * */
		void CallBackDelete(string response){
			if (response == "") return;
			DuelUserModel duelUserModel = JsonUtility.FromJson<DuelUserModel>(response);
			print (duelUserModel);
		}
		void CallBackUpdate(string response){
			if (response == "") return;
			DuelUserModel duelUserModel = JsonUtility.FromJson<DuelUserModel>(response);
			print (duelUserModel);
		}
		void CallBackCreate(string response){
			if (response == "") return;
			DuelUserModel duelUserModel = JsonUtility.FromJson<DuelUserModel>(response);
			print (duelUserModel);
		}
		void CallBackGetWonDuelsByUserId(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DuelUserModel[] duelUserModel = JsonHelper.FromJson<DuelUserModel> (response);
			print (duelUserModel);
		}
		void CallBackGetAllDuelsByUserId(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DuelUserModel[] duelUserModel = JsonHelper.FromJson<DuelUserModel> (response);
			print (duelUserModel);
		}
		void CallBackGetById(string response){
			if (response == "") return;
			DuelUserModel duelUserModel = JsonUtility.FromJson<DuelUserModel>(response);
			print (duelUserModel);
		}
		void CallBackSetCompleted(string response){
			if (response == "") return;
			DuelUserModel duelUserModel = JsonUtility.FromJson<DuelUserModel>(response);
			print (duelUserModel);
		}
		void CallBackSetDeclined(string response){
			if (response == "") return;
			DuelUserModel duelUserModel = JsonUtility.FromJson<DuelUserModel>(response);
			print (duelUserModel);
		}
	}
}