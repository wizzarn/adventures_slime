using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ApiController;
using UnityEngine.UI;
public class OnLoadDungeonScene : MonoBehaviour {

	public Transform panelDungeonPrefab;
	private GameObject canvasObj;
	public DungeonController dungeonCtrl;
	Vector3 lastPosition;

	List<GameObject> listDungeons = new List<GameObject> ();

	float fixY = 0;
	void Start () {
		canvasObj = GameObject.Find ("Canvas");
		if (Token.GetUserId () != "" && dungeonCtrl)
			dungeonCtrl.getAll (GetAllCallback);
		lastPosition.y = 140;
	}
	void GetAllCallback(DungeonModel[] response){
		
		for (int i = 0; i < response.Length; i++){
			GameObject obj = (GameObject)Instantiate (panelDungeonPrefab.gameObject, canvasObj.transform,false);
			obj.GetComponent<InstanceDungeon> ().Instance (response[i]);
			listDungeons.Add (obj);
			lastPosition = listDungeons [i].transform.position;
			lastPosition.y -= fixY;
			listDungeons [i].transform.position = lastPosition;
			fixY += 240;

		}

	}

}
