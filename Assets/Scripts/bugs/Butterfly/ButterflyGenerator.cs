using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyGenerator : MonoBehaviour {

	public float tmr = 0;
	public float tmrLoop,min,max;
	public bool active;
	public GameObject objPrefab;
	int rangeValue = 5;
	void Start () {
		tmrLoop = Random.Range (4, 8);
		min = 2;
		max = 10;
		active = true;
	}

	void Update () {
		if (!active) return;
		tmr += Time.deltaTime;
		if (tmr > tmrLoop) {
			tmr = 0;
			tmrLoop = Random.Range ( (min/rangeValue), (max/rangeValue) );
			GameObject butterfly = (GameObject)Instantiate(objPrefab);
			float sizeY = this.gameObject.GetComponent<BoxCollider2D> ().size.y;
			float offsetY = this.gameObject.GetComponent<BoxCollider2D> ().offset.y;
			float sizeX = this.gameObject.GetComponent<BoxCollider2D> ().size.x;
			butterfly.GetComponent<Butterfly> ().Init (Random.Range(0,sizeX/2), Random.Range(0,sizeY/2));
			butterfly.transform.parent = this.gameObject.transform;
		}
	}
}
