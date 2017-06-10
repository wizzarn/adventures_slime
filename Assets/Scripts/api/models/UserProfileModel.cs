using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class UserProfileModel{
		public string user_id;
		public string level;
		public string experience;
		public string hp;
		public string mana;
		public string agi;
		public string str;
		public string inte;
		public string phys_dmg;
		public string magic_dmg;
		public string armor;
		public string status;
		public string last_action_date;
		public string hungry_points;
		public string tired_points;
		public string cash_points;
		public string longitude;
		public string latitude;
		public string shape;
		public string color;
		public string eye;
		public string created_date;
		public UserProfileModel(){
		}

		public UserProfileModel(
			 string user_id,
			 string level,
			 string experience,
			 string hp,
			 string mana,
			 string agi,
			 string str,
			 string inte,
			 string phys_dmg,
			 string magic_dmg,
			 string armor,
			 string status,
			 string last_action_date,
			 string hungry_points,
			 string tired_points,
			 string cash_points,
			 string longitude,
			 string latitude,
			 string shape,
			 string color,
			 string eye,
			 string created_date)
		{
			this.user_id = user_id;
			this.level=level;
			this.experience=experience;
			this.hp=hp;
			this.mana=mana;
			this.agi=agi;
			this.str=str;
			this.inte=inte;
			this.phys_dmg=phys_dmg;
			this.magic_dmg=magic_dmg;
			this.armor=armor;
			this.status=status;
			this.last_action_date=last_action_date;
			this.hungry_points=hungry_points;
			this.tired_points=tired_points;
			this.cash_points=cash_points;
			this.longitude=longitude;
			this.latitude=latitude;
			this.shape=shape;
			this.color=color;
			this.eye=eye;
			this.created_date = created_date;
		}

	}
}
