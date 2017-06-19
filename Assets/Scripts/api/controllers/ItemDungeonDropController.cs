using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class ItemDungeonDropController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public ItemDungeonDropController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"itemsDungeonsDrops/delete/"+id,CallBackDelete,form);
		}
		public void update_(ItemDungeonDropModel itemDungeonDropModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("item_dungeon_drop_id",itemDungeonDropModel.item_dungeon_drop_id);
			form.AddField("dungeon_id",itemDungeonDropModel.dungeon_id);
			form.AddField("item_id",itemDungeonDropModel.item_id);
			form.AddField("drop_chance",itemDungeonDropModel.drop_chance);
			httpHandlerScript.POST(Config.apiUrl+"itemsDungeonsDrops/update/"+id,CallBackUpdate,form);
		}
		public void create(ItemDungeonDropModel itemDungeonDropModel){
			WWWForm form = new WWWForm();
			form.AddField("dungeon_id",itemDungeonDropModel.dungeon_id);
			form.AddField("item_id",itemDungeonDropModel.item_id);
			form.AddField("drop_chance",itemDungeonDropModel.drop_chance);
			httpHandlerScript.POST(Config.apiUrl+"itemsDungeonsDrops/store",CallBackCreate,form);
		}
		public void getItemsByDungeon(string id){
			httpHandlerScript.GET(Config.apiUrl+"itemsDungeonsDrops/getItemsByDungeon/"+id,CallBackGetItemsByDungeon);
		}
		public void getItemsByDungeonsIds(string ids){
			httpHandlerScript.GET(Config.apiUrl+"itemsDungeonsDrops/getItemsByDungeonsIds/"+ids,CallBackGetItemsByDungeonsIds);
		}
		/* * * * * * * 
		 *  CALLBACKS 
		 * * * * * * */
		void CallBackDelete(string response){
			if (response == "") return;
			ItemDungeonDropModel itemDungeonDropModel = JsonUtility.FromJson<ItemDungeonDropModel>(response);
			print (itemDungeonDropModel);
		}
		void CallBackUpdate(string response){
			if (response == "") return;
			ItemDungeonDropModel itemDungeonDropModel = JsonUtility.FromJson<ItemDungeonDropModel>(response);
			print (itemDungeonDropModel);
		}
		void CallBackCreate(string response){
			if (response == "") return;
			ItemDungeonDropModel itemDungeonDropModel = JsonUtility.FromJson<ItemDungeonDropModel>(response);
			print (itemDungeonDropModel);
		}
		void CallBackGetItemsByDungeon(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			ItemDungeonDropModel[] items = JsonHelper.FromJson<ItemDungeonDropModel> (response);
			print (items);
		}
		void CallBackGetItemsByDungeonsIds(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			ItemDungeonDropModel[] items = JsonHelper.FromJson<ItemDungeonDropModel> (response);
			print (items);
		}
	}
}