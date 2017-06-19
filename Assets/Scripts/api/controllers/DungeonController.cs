using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class DungeonController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public DungeonController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"dungeons/delete/"+id,CallBackDelete,form);
		}
		public void update_(DungeonModel dungeonModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("level_required",dungeonModel.level_required);
			form.AddField("durability",dungeonModel.durability);
			form.AddField("name",dungeonModel.name);
			form.AddField("status",dungeonModel.status);
			form.AddField("exp_reward_range",dungeonModel.exp_reward_range);
			form.AddField("cash_reward_range",dungeonModel.cash_reward_range);
			form.AddField("tired_cost_range",dungeonModel.tired_cost_range);
			form.AddField("hungry_cost_range",dungeonModel.hungry_cost_range);
			httpHandlerScript.POST(Config.apiUrl+"dungeons/update/"+id,CallBackUpdate,form);
		}
		public void create(DungeonModel dungeonModel){
			WWWForm form = new WWWForm();
			form.AddField("level_required",dungeonModel.level_required);
			form.AddField("durability",dungeonModel.durability);
			form.AddField("name",dungeonModel.name);
			form.AddField("status",dungeonModel.status);
			form.AddField("exp_reward_range",dungeonModel.exp_reward_range);
			form.AddField("cash_reward_range",dungeonModel.cash_reward_range);
			form.AddField("tired_cost_range",dungeonModel.tired_cost_range);
			form.AddField("hungry_cost_range",dungeonModel.hungry_cost_range);
			httpHandlerScript.POST(Config.apiUrl+"dungeons/store",CallBackCreate,form);
		}
		public void getById(string id){
			httpHandlerScript.GET(Config.apiUrl+"dungeons/getById/"+id,CallBackGetById);
		}
		public void getAll(){
			httpHandlerScript.GET(Config.apiUrl+"dungeons/getAll",CallBackGetAll);
		}
		public void getByName(string name){
			httpHandlerScript.GET(Config.apiUrl+"dungeons/getByName/"+name,CallBackGetByName);
		}
		public void getByStatus(string status){
			httpHandlerScript.GET(Config.apiUrl+"dungeons/getByStatus/"+status,CallBackGetByStatus);
		}
		/* * * * * * * 
		 *  CALLBACKS 
		 * * * * * * */
		void CallBackDelete(string response){
			if (response == "") return;
			DungeonModel dungeonModel = JsonUtility.FromJson<DungeonModel>(response);
			print (dungeonModel);
		}
		void CallBackUpdate(string response){
			if (response == "") return;
			DungeonModel dungeonModel = JsonUtility.FromJson<DungeonModel>(response);
			print (dungeonModel);
		}
		void CallBackCreate(string response){
			if (response == "") return;
			DungeonModel dungeonModel = JsonUtility.FromJson<DungeonModel>(response);
			print (dungeonModel);
		}
		void CallBackGetById(string response){
			if (response == "") return;
			DungeonModel dungeonModel = JsonUtility.FromJson<DungeonModel>(response);
			print (dungeonModel);
		}
		void CallBackGetAll(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DungeonModel[] dungeonModels = JsonHelper.FromJson<DungeonModel> (response);
			print (dungeonModels);
		}
		void CallBackGetByName(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DungeonModel[] dungeonModels = JsonHelper.FromJson<DungeonModel> (response);
			print (dungeonModels);
		}
		void CallBackGetByStatus(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DungeonModel[] dungeonModels = JsonHelper.FromJson<DungeonModel> (response);
			print (dungeonModels);
		}
	}
}