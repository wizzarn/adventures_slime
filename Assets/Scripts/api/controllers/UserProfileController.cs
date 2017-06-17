using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApiController{
	public class UserProfileController : MonoBehaviour
	{
		public HttpHandler httpHandlerScript = new HttpHandler();

		public UserProfileController ()
		{
		}
		public void getByUserId(string id){
			httpHandlerScript.GET(Config.apiUrl+"usersProfiles/getByUserId/"+id,CallBackGetByUserId);
		}
		public void getByUserIds(string ids){
			httpHandlerScript.GET(Config.apiUrl+"usersProfiles/getByUserIds/"+ids,CallBackGetByUserIds);
		}
		public void create(UserProfileModel userProfileModel){
			WWWForm form = new WWWForm();
			form.AddField("user_id",userProfileModel.user_id);
			form.AddField("level",userProfileModel.level);
			form.AddField("experience",userProfileModel.experience);
			form.AddField("hp",userProfileModel.hp);
			form.AddField("mana",userProfileModel.mana);
			form.AddField("agi",userProfileModel.agi);
			form.AddField("str",userProfileModel.str);
			form.AddField("inte",userProfileModel.inte);
			form.AddField("phys_dmg",userProfileModel.phys_dmg);
			form.AddField("magic_dmg",userProfileModel.magic_dmg);
			form.AddField("armor",userProfileModel.armor);
			form.AddField("status",userProfileModel.status);
			form.AddField("last_action_date",userProfileModel.last_action_date);
			form.AddField("hungry_points",userProfileModel.hungry_points);
			form.AddField("tired_points",userProfileModel.tired_points);
			form.AddField("cash_points",userProfileModel.cash_points);
			form.AddField("longitude",userProfileModel.longitude);
			form.AddField("latitude",userProfileModel.latitude);
			form.AddField("shape",userProfileModel.shape);
			form.AddField("color",userProfileModel.color);
			form.AddField("eye",userProfileModel.eye);
			form.AddField("created_date",userProfileModel.created_date);

			httpHandlerScript.POST(Config.apiUrl+"usersProfiles/store",CallBackCreate,form);
		}
		public void update_(UserProfileModel userProfileModel, string id){
			WWWForm form = new WWWForm();
			form.AddField("user_id",userProfileModel.user_id);
			form.AddField("level",userProfileModel.level);
			form.AddField("experience",userProfileModel.experience);
			form.AddField("hp",userProfileModel.hp);
			form.AddField("mana",userProfileModel.mana);
			form.AddField("agi",userProfileModel.agi);
			form.AddField("str",userProfileModel.str);
			form.AddField("inte",userProfileModel.inte);
			form.AddField("phys_dmg",userProfileModel.phys_dmg);
			form.AddField("magic_dmg",userProfileModel.magic_dmg);
			form.AddField("armor",userProfileModel.armor);
			form.AddField("status",userProfileModel.status);
			form.AddField("last_action_date",userProfileModel.last_action_date);
			form.AddField("hungry_points",userProfileModel.hungry_points);
			form.AddField("tired_points",userProfileModel.tired_points);
			form.AddField("cash_points",userProfileModel.cash_points);
			form.AddField("longitude",userProfileModel.longitude);
			form.AddField("latitude",userProfileModel.latitude);
			form.AddField("shape",userProfileModel.shape);
			form.AddField("color",userProfileModel.color);
			form.AddField("eye",userProfileModel.eye);
			form.AddField("created_date",userProfileModel.created_date);

			httpHandlerScript.POST(Config.apiUrl+"usersProfiles/update/"+id,CallBackUpdate,form);
		}
		public void delete(string id){
			WWWForm form = new WWWForm();
			httpHandlerScript.POST(Config.apiUrl+"usersProfiles/delete/"+id,CallBackDelete,form);
		}
		void CallBackGetByUserId(string response){
			if (response == "")
				return;
			UserProfileModel userProfile = JsonUtility.FromJson<UserProfileModel>(response);
			print (userProfile);
		}
		void CallBackGetByUserIds(string response){
			if (response == "")
				return;
			response = JsonHelper.fixJson (response);
			UserProfileModel[] userProfiles = JsonHelper.FromJson<UserProfileModel> (response);
			print (userProfiles);
		}
		void CallBackCreate(string response){
			print (response);
			if (response == "")
				return;
			UserProfileModel userProfile = JsonUtility.FromJson<UserProfileModel>(response);
			print (userProfile);
		}
		void CallBackUpdate(string response){
			if (response == "")
				return;
			UserProfileModel user = JsonUtility.FromJson<UserProfileModel>(response);
			print (user);
		}
		void CallBackDelete(string response){
			if (response == "")
				return;
			UserProfileModel user = JsonUtility.FromJson<UserProfileModel>(response);
			print (user);
		}
	}
}