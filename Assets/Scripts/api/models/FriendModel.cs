using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class FriendModel {

		public string friend_id;
		public string friend_from;
		public string friend_to;
		public string status;
		public string created_date;
		public FriendModel(){
		
		}
		public FriendModel(string friend_id, string friend_from, string friend_to, string status,string created_date){
			this.friend_id = friend_id;
			this.friend_from = friend_from;
			this.friend_to = friend_to;
			this.status = status;
			this.created_date = created_date;
		}
	}
}