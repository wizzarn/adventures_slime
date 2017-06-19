using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class ItemController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public ItemController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"items/delete/"+id,CallBackDelete,form);
		}
		public void update_(ItemModel item, string id){
			WWWForm form = new WWWForm();
			form.AddField("name",item.name);
			form.AddField("phys_atk_range",item.phys_atk_range);
			form.AddField("magic_atk_range",item.magic_atk_range);
			form.AddField("armor",item.armor);
			form.AddField("level_required",item.level_required);
			form.AddField("class_required",item.class_required);
			form.AddField("bonus_hp",item.bonus_hp);
			form.AddField("bonus_mana",item.bonus_mana);
			form.AddField("bonus_agi",item.bonus_agi);
			form.AddField("bonus_str",item.bonus_str);
			form.AddField("bonus_int",item.bonus_int);
			form.AddField("bonus_level",item.bonus_level);
			form.AddField("durability",item.durability);
			form.AddField("type",item.type);
			form.AddField("slot",item.slot);
			form.AddField("status",item.status);
			httpHandlerScript.POST(Config.apiUrl+"items/update/"+id,CallBackUpdate,form);
		}
		public void create(ItemModel item){
			WWWForm form = new WWWForm();
			form.AddField("name",item.name);
			form.AddField("phys_atk_range",item.phys_atk_range);
			form.AddField("magic_atk_range",item.magic_atk_range);
			form.AddField("armor",item.armor);
			form.AddField("level_required",item.level_required);
			form.AddField("class_required",item.class_required);
			form.AddField("bonus_hp",item.bonus_hp);
			form.AddField("bonus_mana",item.bonus_mana);
			form.AddField("bonus_agi",item.bonus_agi);
			form.AddField("bonus_str",item.bonus_str);
			form.AddField("bonus_int",item.bonus_int);
			form.AddField("bonus_level",item.bonus_level);
			form.AddField("durability",item.durability);
			form.AddField("type",item.type);
			form.AddField("slot",item.slot);
			form.AddField("status",item.status);
			httpHandlerScript.POST(Config.apiUrl+"items/store",CallBackCreate,form);
		}
		public void getById(string id){
			httpHandlerScript.GET(Config.apiUrl+"items/getById/"+id,CallBackGetById);
		}
		public void getAll(string id){
			httpHandlerScript.GET(Config.apiUrl+"items/getAll",CallBackGetAll);
		}
		public void getByName(string name){
			httpHandlerScript.GET(Config.apiUrl+"items/getByName/"+name,CallBackGetByName);
		}
		public void getByType(string name){
			httpHandlerScript.GET(Config.apiUrl+"items/getByType/"+name,CallBackGetByType);
		}
		/* * * * * * * 
		 *  CALLBACKS 
		 * * * * * * */
		void CallBackDelete(string response){
			if (response == "") return;
			ItemModel itemModel = JsonUtility.FromJson<ItemModel>(response);
			print (itemModel);
		}
		void CallBackUpdate(string response){
			if (response == "") return;
			ItemModel itemModel = JsonUtility.FromJson<ItemModel>(response);
			print (itemModel);
		}
		void CallBackCreate(string response){
			if (response == "") return;
			ItemModel itemModel = JsonUtility.FromJson<ItemModel>(response);
			print (itemModel);
		}
		void CallBackGetById(string response){
			if (response == "") return;
			ItemModel itemModel = JsonUtility.FromJson<ItemModel>(response);
			print (itemModel);
		}
		void CallBackGetAll(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			ItemModel[] itemModel = JsonHelper.FromJson<ItemModel> (response);
			print (itemModel);
		}
		void CallBackGetByName(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			ItemModel[] itemModel = JsonHelper.FromJson<ItemModel> (response);
			print (itemModel);
		}
		void CallBackGetByType(string response){
			if (response == "") return;
			response = JsonHelper.fixJson (response);
			ItemModel[] itemModel = JsonHelper.FromJson<ItemModel> (response);
			print (itemModel);
		}
	}
}