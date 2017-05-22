using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ApiController{

	[Serializable]
	public class UserModel{
		public int user_id;
		public string nickname;
		public string device_id;
		public string phone;
		public string email;
		public string created_date;
		public UserModel(){
		}

		public UserModel(int user_id, string nickname, string device_id, string phone, string email, string created_date){
			this.user_id = user_id;
			this.nickname = nickname;
			this.device_id = device_id;
			this.phone = phone;
			this.email = email;
			this.created_date = created_date;
		}

	}
}
