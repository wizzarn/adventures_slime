using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadMainScene : MonoBehaviour {

	public GameObject gameManagerOBJ;

	float tmrDirectionalLight = 0;
	float tmrDelay = .02f;
	public GameObject directionalLightOBJ;
	string flagLightEffect = "done";
	void Start () {
		directionalLightOBJ = GameObject.Find ("Directional light");
		gameManagerOBJ = GameObject.Find ("_GM");
		if (Token.GetCustomField ("sleeping") == "1") { 
			gameManagerOBJ.GetComponent<GameManager> ().InGameSleep ();
			flagLightEffect = "dark";
		} else if (Token.GetCustomField ("sleeping") == "0") {
			gameManagerOBJ.GetComponent<GameManager> ().InGameWakeup ();
			flagLightEffect = "bright";
		}
	}
	public void SetDark(){
		flagLightEffect = "dark";
	}
	public void SetBright(){
		flagLightEffect = "bright";
	}
	void Update(){
		if (flagLightEffect == "done")
			return;
		if (flagLightEffect == "dark") {
			tmrDirectionalLight += Time.deltaTime;
			if (tmrDirectionalLight > tmrDelay) {
				tmrDirectionalLight = 0;
				if (directionalLightOBJ.GetComponent<Light> ().intensity > 0)
					directionalLightOBJ.GetComponent<Light> ().intensity -= .05f;
				else
					flagLightEffect = "done";
			} 
		}else if (flagLightEffect == "bright") {
			tmrDirectionalLight += Time.deltaTime;
			if (tmrDirectionalLight > tmrDelay) {
				tmrDirectionalLight = 0;
				if (directionalLightOBJ.GetComponent<Light> ().intensity < 1)
					directionalLightOBJ.GetComponent<Light> ().intensity += .05f;
				else
					flagLightEffect = "done";
			} 
		}
	}
}
