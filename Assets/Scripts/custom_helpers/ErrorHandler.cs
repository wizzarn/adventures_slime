using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorHandler : MonoBehaviour {

	private GameObject objErrorHandler;
	private float 	tmrLive_ 	= 0;
	private bool 	flagLive 	= false; 

	void Start () {
		objErrorHandler = this.gameObject;
		objErrorHandler.SetActive (false);
	}

	public void SetFontSize(int fontSize){
		objErrorHandler.GetComponentInChildren<Text> ().fontSize = fontSize;
	}
	public void EnableError(string errorText){
		if (flagLive)
			return;
		objErrorHandler.GetComponentInChildren<Text> ().text = errorText;
		flagLive = true;
		tmrLive_ = 0;
		objErrorHandler.SetActive (true);
	}
	private void DisableError(){
		flagLive = false;
		tmrLive_ = 0;
		objErrorHandler.SetActive (false);
	}
	void Update () {
		if (!flagLive)
			return;
		tmrLive_ += Time.deltaTime;
		if (tmrLive_ > Config.errorHandlerTime) {
			DisableError ();
		}
	}

}
