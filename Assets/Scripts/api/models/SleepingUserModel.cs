using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class SleepingUserModel {
		public string sleeping_user_id;
		public string user_id;
		public string init_date;
		public string end_date;
		public string tired_recovery;
		public string hungry_cost;
		public string status;
		public string created_date;
		public SleepingUserModel(){
		}
		public SleepingUserModel(
			string sleeping_user_id,
			string user_id,
			string init_date,
			string end_date,
			string tired_recovery,
			string hungry_cost,
			string status,
			string created_date)
		{

			this.sleeping_user_id = sleeping_user_id;
			this.user_id = user_id;
			this.init_date = init_date;
			this.end_date = end_date;
			this.tired_recovery = tired_recovery;
			this.hungry_cost = hungry_cost;
			this.status = status;
			this.created_date = created_date;
			
		}
	}
}