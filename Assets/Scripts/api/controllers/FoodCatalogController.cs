using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class FoodCatalogController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();
		public FoodCatalogController(){
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"foodCatalog/delete/"+id,CallBackDelete,form);
		}
		public void update_(FoodCatalogModel foodCatalogModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("food_id",foodCatalogModel.food_id);
			form.AddField("name",foodCatalogModel.name);
			form.AddField("hungry_recovery",foodCatalogModel.hungry_recovery);
			form.AddField("type",foodCatalogModel.type);
			form.AddField("percentage_effect",foodCatalogModel.percentage_effect);
			form.AddField("due_date",foodCatalogModel.due_date);
			httpHandlerScript.POST(Config.apiUrl+"foodCatalog/update/"+id,CallBackUpdate,form);
		}
		public void create(FoodCatalogModel foodCatalogModel){
			WWWForm form = new WWWForm();
			form.AddField("food_id",foodCatalogModel.food_id);
			form.AddField("name",foodCatalogModel.name);
			form.AddField("hungry_recovery",foodCatalogModel.hungry_recovery);
			form.AddField("type",foodCatalogModel.type);
			form.AddField("percentage_effect",foodCatalogModel.percentage_effect);
			form.AddField("due_date",foodCatalogModel.due_date);
			httpHandlerScript.POST(Config.apiUrl+"foodCatalog/store",CallBackCreate,form);
		}
		public void GetAll(){
			httpHandlerScript.GET(Config.apiUrl+"foodCatalog/getAll",CallBackGetAll);
		}
		public void GetByName(string name){
			httpHandlerScript.GET(Config.apiUrl+"foodCatalog/getByName/"+name.ToString(),CallBackGetByName);
		}
		/* * * * * * * 
		 *  CALLBACKS 
		 * * * * * * */
		void CallBackDelete(string response){
			if (response == "") return;
			FoodCatalogModel foodCatalog = JsonUtility.FromJson<FoodCatalogModel>(response);
			print (foodCatalog);
		}
		void CallBackUpdate(string response){
			if (response == "") return;
			FoodCatalogModel foodCatalog = JsonUtility.FromJson<FoodCatalogModel>(response);
			print (foodCatalog);
		}
		void CallBackCreate(string response){
			if (response == "") return;
			FoodCatalogModel foodCatalog = JsonUtility.FromJson<FoodCatalogModel>(response);
			print (foodCatalog);
		}
		void CallBackGetByName(string response){
			if (response == "") return;
			FoodCatalogModel foodCatalog = JsonUtility.FromJson<FoodCatalogModel>(response);
			print (foodCatalog);
		}
		void CallBackGetAll(string response){
			if (response == "")
				return;
			response = JsonHelper.fixJson (response);
			FoodCatalogModel[] foodCatalogs = JsonHelper.FromJson<FoodCatalogModel> (response);
			print (foodCatalogs);
		}
	}
}