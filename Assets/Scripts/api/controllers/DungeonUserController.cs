using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	namespace ApiController{
	public class DungeonUserController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public delegate void CallBackCreate(DungeonUserModel result, string errorResult);
		public delegate void CallBackGetActive(DungeonUserModel result, string errorResult);
		CallBackCreate createCallback;
		CallBackGetActive getActiveCallback;
		public DungeonUserController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"dungeonsUsers/delete/"+id,CallBackDelete,form);
		}
		public void update_(ItemDungeonDropModel itemDungeonDropModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("item_dungeon_drop_id",itemDungeonDropModel.item_dungeon_drop_id);
			form.AddField("dungeon_id",itemDungeonDropModel.dungeon_id);
			form.AddField("user_id",itemDungeonDropModel.item_id);
			form.AddField("drop_chance",itemDungeonDropModel.drop_chance);
			httpHandlerScript.POST(Config.apiUrl+"dungeonsUsers/update/"+id,CallBackUpdate,form);
		}
		public void create(DungeonUserModel dungeonUserModel,CallBackCreate callback){
			this.createCallback = callback;
			WWWForm form = new WWWForm();
			form.AddField("dungeon_id",dungeonUserModel.dungeon_id);
			form.AddField("user_id",Token.GetUserId());
			form.AddField("session",Token.GetToken());
			httpHandlerScript.POST(Config.apiUrl+"dungeonsUsers/store",CallBackCreateDungeonUser,form);
		}
		public void getAllDungeonsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"dungeonsUsers/getAllDungeonsByUserId/"+id,CallBackGetAllDungeonsByUserId);
		}
		public void getActiveDungeonByUserId(CallBackGetActive callback){
			this.getActiveCallback = callback;
			WWWForm form = new WWWForm ();
			form.AddField ("session",Token.GetToken());
			form.AddField ("user_id",Token.GetUserId());
			httpHandlerScript.POST(Config.apiUrl+"dungeonsUsers/getActiveDungeonByUserId",CallBackGetActiveDungeonByUserId,form);
		}
		public void getLostDungeonsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"dungeonsUsers/getLostDungeonsByUserId/"+id,CallBackGetLostDungeonsByUserId);
		}
		public void getCompleteDungeonsByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"dungeonsUsers/getCompleteDungeonsByUserId/"+id,CallBackGetCompleteDungeonsByUserId);
		}
		public void setCompleted(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"dungeonsUsers/setCompleted/"+id,CallBackSetCompleted,form);
		}
		public void setLost(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"dungeonsUsers/setLost/"+id,CallBackSetLost,form);
		}
		void CallBackUpdate(string response){
			if (response == "") return;
			DungeonUserModel dungeonUserModel = JsonUtility.FromJson<DungeonUserModel>(response);
			print (dungeonUserModel);
		}
		void CallBackCreateDungeonUser(string response){
			/* Error Enum Pending */
			if (response == "invalid_session" || response == "invalid_dungeon" || response == "invalid_user_profile" || response == "insufficient_level" || response == "already_in_dungeon")
				createCallback (new DungeonUserModel (), response);
			else {
				DungeonUserModel dungeonUserModel = JsonUtility.FromJson<DungeonUserModel>(response);
				print (dungeonUserModel);
				createCallback (dungeonUserModel,"");
			}

		}
		void CallBackGetAllDungeonsByUserId(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DungeonUserModel[] dungeonsUserModel = JsonHelper.FromJson<DungeonUserModel> (response);
			print (dungeonsUserModel);
		}
		void CallBackGetActiveDungeonByUserId(string response){
			if (response == "")
				return;
			DungeonUserModel dungeonUserModel = JsonUtility.FromJson<DungeonUserModel>(response);
			print (dungeonUserModel);
			getActiveCallback (dungeonUserModel,"");
		}
		void CallBackGetLostDungeonsByUserId(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DungeonUserModel[] dungeonsUserModel = JsonHelper.FromJson<DungeonUserModel> (response);
			print (dungeonsUserModel);
		}
		void CallBackGetCompleteDungeonsByUserId(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			DungeonUserModel[] dungeonsUserModel = JsonHelper.FromJson<DungeonUserModel> (response);
			print (dungeonsUserModel);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			DungeonUserModel dungeonUserModel = JsonUtility.FromJson<DungeonUserModel>(response);
			print (dungeonUserModel);
		}
		void CallBackSetLost(string response){
			if (response == "") return;
			DungeonUserModel dungeonUserModel = JsonUtility.FromJson<DungeonUserModel>(response);
			print (dungeonUserModel);
		}
		void CallBackSetCompleted(string response){
			if (response == "") return;
			DungeonUserModel dungeonUserModel = JsonUtility.FromJson<DungeonUserModel>(response);
			print (dungeonUserModel);
		}
	}
}