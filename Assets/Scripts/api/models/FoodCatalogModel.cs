using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class FoodCatalogModel {
		public string food_id;
		public string name;
		public string hungry_recovery;
		public string type;
		public string percentage_effect;
		public string due_date;
		public string created_date;

		public FoodCatalogModel(){
		}
		public FoodCatalogModel(string food_id, string name, string hungry_recovery, string type, string percentage_effect, string due_date, string created_date){
			this.food_id = food_id;
			this.name = name;
			this.hungry_recovery = hungry_recovery;
			this.type = type;
			this.percentage_effect = percentage_effect;
			this.due_date = due_date;
			this.created_date = created_date;
		}
	}
}