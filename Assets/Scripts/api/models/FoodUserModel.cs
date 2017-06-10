using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class FoodUserModel {

		public string food_user_id;
		public string user_id;
		public string food_id;
		public string status;
		public string created_date;

		public FoodUserModel(string food_user_id, string user_id, string food_id, string status, string created_date){
			this.food_user_id = food_user_id;
			this.user_id = user_id;
			this.food_id = food_id;
			this.status = status;
			this.created_date = created_date;
		}
		public FoodUserModel(){
			
		}
	}
}