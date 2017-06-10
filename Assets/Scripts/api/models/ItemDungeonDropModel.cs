using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]

	public class ItemDungeonDropModel {
		public string item_dungeon_drop_id;
		public string dungeon_id;
		public string item_id;
		public string drop_chance;
		public string created_date;

		public ItemDungeonDropModel(string item_dungeon_drop_id, string dungeon_id, string item_id, string drop_chance, string created_date){
			this.item_dungeon_drop_id = item_dungeon_drop_id;
			this.dungeon_id = dungeon_id;
			this.item_id = item_id;
			this.drop_chance = drop_chance;
			this.created_date = created_date;
		}
		public ItemDungeonDropModel(){
		
		}
	}
}