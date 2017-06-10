using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class DuelUserModel {

		public string duel_user_id;
		public string user_from_id;
		public string user_to_id;
		public string status;
		public string init_date;
		public string end_date;
		public string user_won;
		public string durability_lost;
		public string cash_lost;
		public string hungry_cost;
		public string tired_cost;
		public string created_date;

		public DuelUserModel(
			string duel_user_id,
			string user_from_id,
			string user_to_id,
			string status,
			string init_date,
			string end_date,
			string user_won,
			string durability_lost,
			string cash_lost,
			string hungry_cost,
			string tired_cost,
			string created_date
		){
			this.duel_user_id = duel_user_id;
			this.user_from_id = user_from_id;
			this.user_to_id = user_to_id;
			this.status = status;
			this.init_date = init_date;
			this.end_date = end_date;
			this.user_won = user_won;
			this.durability_lost = durability_lost;
			this.cash_lost = cash_lost;
			this.hungry_cost=hungry_cost;
			this.tired_cost = tired_cost;
			this.created_date = created_date;
		}
		public DuelUserModel(){
		
		}
	}
}