using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class DungeonUserModel {

		public string dungeon_user_id;
		public string dungeon_id;
		public string user_id;
		public string init_date;
		public string end_date;
		public string status;
		public string created_date;
		public DungeonUserModel(){
		
		}
		public DungeonUserModel(string dungeon_user_id, string dungeon_id, string user_id, string init_date, string end_date, string status, string created_date){
			this.dungeon_user_id = dungeon_user_id;
			this.dungeon_id = dungeon_id;
			this.user_id = user_id;
			this.init_date = init_date;
			this.end_date = end_date;
			this.status = status;
			this.created_date = created_date;
		}
	}
}