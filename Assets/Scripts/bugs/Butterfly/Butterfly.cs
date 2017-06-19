using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour {

	public float livingTime = 10;
	public float tmrLive = 0;
	public bool diyingFlag;

	float tmrMove;
	Vector3 inverseMove;

	float amplitudeX = .7f;
	float amplitudeY = .5f;
	float omegaX = 5.0f;
	float omegaY = 10.0f;
	float index;
	Vector3 movement;
	float lastX = 0;
	public List<Color> colors = new List<Color>();

	float tmrInit= 0;
	float tmrEnd=0;
	Color initColor;
	bool flagEndInit = false; 
	bool flagEndEnd = false; 

	float inversed = 0;
	bool initialized = false;
	float initY = 0;
	float initX = 0;
	public void Init(float initX_, float initY_){
		initY = initY_;
		initX = initX_;
		inverseMove = new Vector3 (1, 1, 1);

		colors.Add (new Color(40,255,0));
		colors.Add (new Color(255,0,142));
		colors.Add (new Color(0,233,255));
		colors.Add (new Color(93,0,255));
		colors.Add (new Color(241,255,0));
		colors.Add (new Color(255,146,8));

		int rnd = Random.Range (1, 60);
		if (Random.Range (1, 50) > 25) {
			inversed = -1;
		} else
			inversed = 1;

		if (rnd > 0 && rnd < 10) {
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [0];
			livingTime = 5;
		} else if (rnd >= 10 && rnd < 20) {
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [1];
			livingTime = 7;
		} else if (rnd >= 20 && rnd < 30) {
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [2];
			livingTime = 9;
		} else if (rnd >= 30 && rnd < 40) {
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [3];
			livingTime = 11;
		} else if (rnd >= 40 && rnd < 50) {
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [4];
		} else if (rnd >= 50) {
			livingTime = 13;
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [5];
		} else {
			this.gameObject.gameObject.GetComponent<SpriteRenderer> ().color = colors [0];
			livingTime = 5;
		}
		initColor = this.gameObject.GetComponent<SpriteRenderer> ().color;
		initColor.a = 0;
		this.gameObject.GetComponent<SpriteRenderer> ().color = initColor;
		initialized = true;


		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
		movement.x = x*inversed;
		movement.y = y;
		movement.z = 0;
		if (x > lastX) 
			inverseMove.x = 1 * inversed;
		else
			inverseMove.x = -1 * inversed;
		lastX = x;
		transform.localPosition= movement;
		this.gameObject.transform.localScale = inverseMove;
	}
	void Start () {
		
	}
	

	void Update () {
		if (!initialized)
			return;
		tmrLive += Time.deltaTime;
		tmrMove += Time.deltaTime;
		tmrInit += Time.deltaTime;
		tmrEnd += Time.deltaTime;

		if (!flagEndInit) {
			if (tmrInit > .1f){
				tmrInit = 0;
				if (initColor.a > 1)
					flagEndInit = true;
				initColor = this.GetComponent<SpriteRenderer> ().color;
				initColor.a += .03f;
				this.GetComponent<SpriteRenderer> ().color = initColor;
			}
		}
		if (flagEndEnd){
			if (tmrEnd > .1f){
				tmrEnd = 0;
				if (initColor.a < 0)
					Destroy (this.gameObject);
				else {
					initColor.a -= .03f;
					this.GetComponent<SpriteRenderer> ().color = initColor;
				}

			}
		}

		if (tmrMove > .1f) {
			tmrMove = 0;
			index += Time.deltaTime;
			float x = amplitudeX*Mathf.Cos (omegaX*index);
			float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
			y += initY;
			x += initX;
			movement.x = x*inversed;
			movement.y = y;
			movement.z = 0;
			if (x > lastX) inverseMove.x = 1 * inversed;
			else inverseMove.x = -1 * inversed;
			lastX = x;
		}
		if (tmrLive > livingTime){
			flagEndEnd = true;
			//Destroy (this.gameObject);
		}
	}
	void FixedUpdate(){
		transform.localPosition= movement;
		this.gameObject.transform.localScale = inverseMove;
	}
}
