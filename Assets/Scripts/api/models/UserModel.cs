using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ApiController{

	[Serializable]
	public class UserModel{
		public string user_id;
		public string nickname;
		public string password;
		public string device_id;
		public string phone;
		public string email;
		public string remember_token;
		public string sleeping;
		public string created_date;
		public string shape;
		public string eye;
		public string color;
		public UserModel(){
		}

		public UserModel(string user_id, string nickname, string password, string device_id, string phone, string email, string remember_token, string sleeping, string created_date, string shape, string eye, string color){
			this.user_id = user_id;
			this.nickname = nickname;
			this.password = password;
			this.device_id = device_id;
			this.phone = phone;
			this.email = email;
			this.remember_token = remember_token;
			this.sleeping = sleeping;
			this.created_date = created_date;
			this.shape = shape;
			this.eye = eye;
			this.color = color;
		}

	}
}
