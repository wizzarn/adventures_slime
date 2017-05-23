using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingApp : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		if (Token.GetToken () != "") {
			gameManager.MainScene ();
		} else {
			gameManager.LoginScene ();
		}
	}
}
