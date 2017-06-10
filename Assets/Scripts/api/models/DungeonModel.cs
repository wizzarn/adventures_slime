using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class DungeonModel {

		public string dungeon_id;
		public string level_required;
		public string durability;
		public string name;
		public string status;
		public string exp_reward_range;
		public string cash_reward_range;
		public string tired_cost_range;
		public string hungry_cost_range;
		public string created_date;

		public DungeonModel(string dungeon_id, string level_required, string durability, string name, string status, string exp_reward_range,
			string cash_reward_range, string tired_cost_range, string hungry_cost_range, string created_date)
		{
			this.dungeon_id = dungeon_id;
			this.level_required = level_required;
			this.durability = durability;
			this.name = name;
			this.status = status;
			this.exp_reward_range = exp_reward_range;
			this.cash_reward_range = cash_reward_range;
			this.tired_cost_range = tired_cost_range;
			this.hungry_cost_range = hungry_cost_range;
			this.created_date = created_date;
		}
		public DungeonModel(){
		
		}
	}
}