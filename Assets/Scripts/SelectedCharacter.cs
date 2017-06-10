using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCharacter : MonoBehaviour {
	public string strEye = "";
	public string strShape = "";
	public string strColor = "";

	public GameObject objEye;
	public GameObject objShape;
	public GameObject objColor;

	public void setEye(string strEye){
		this.strEye = strEye;
		objEye.GetComponentInChildren<Text> ().text = strEye;
	}
	public void setColor(string strColor){
		this.strColor = strColor;
		objColor.GetComponentInChildren<Text> ().text = strColor;
	}
	public void setShape(string strShape){
		this.strShape = strShape;
		objShape.GetComponentInChildren<Text> ().text = strShape;
	}
}
