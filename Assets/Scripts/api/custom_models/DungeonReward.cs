using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ApiController{

	[Serializable]
	public class DungeonReward {
		public string dungeonName;
		public string expReward;
		public string cashReward;
		public string itemsReward;
		public string dungeonStatus;
		public DungeonReward(){
			
		}
	}
}