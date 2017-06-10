using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class ItemUserModel{
		public string item_user_id;
		public string user_id;
		public string item_id;
		public string status;
		public string created_date;
		public ItemUserModel(){
			
		}
		public ItemUserModel(string item_user_id, string user_id, string item_id, string status,string created_date){
			this.item_user_id = item_user_id;
			this.user_id = user_id;
			this.item_id = item_id;
			this.status = status;
			this.created_date = created_date;
		}
	}
}