using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class ItemModel {

		public string item_id;
		public string name;
		public string phys_atk_range;
		public string magic_atk_range;
		public string armor;
		public string level_required;
		public string class_required;
		public string bonus_hp;
		public string bonus_mana;
		public string bonus_agi;
		public string bonus_str;
		public string bonus_int;
		public string bonus_level;
		public string durability;
		public string type;
		public string slot;
		public string status;
		public string created_date;

		public ItemModel(
			string item_id,
			string name,
			string phys_atk_range,
			string magic_atk_range,
			string armor,
			string level_required,
			string class_required,
			string bonus_hp,
			string bonus_mana,
			string bonus_agi,
			string bonus_str,
			string bonus_int,
			string bonus_level,
			string durability,
			string type,
			string slot,
			string status,
			string created_date
		){
			this.item_id=item_id;
			this.name=name;
			this.phys_atk_range=phys_atk_range;
			this.magic_atk_range=magic_atk_range;
			this.armor=armor;
			this.level_required=level_required;
			this.class_required=class_required;
			this.bonus_hp=bonus_hp;
			this.bonus_mana=bonus_mana;
			this.bonus_agi=bonus_agi;
			this.bonus_str=bonus_str;
			this.bonus_int=bonus_int;
			this.bonus_level=bonus_level;
			this.durability=durability;
			this.type=type;
			this.slot=slot;
			this.status=status;
			this.created_date=created_date;
		}
		public ItemModel(){
			
		}
	}
}
