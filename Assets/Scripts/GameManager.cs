using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public IEnumerator ChangeScene(int SceneIndex){
		float fadeTime = GameObject.Find ("_GM").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (SceneIndex);
	}
	public void MyStatsScene(){
		StartCoroutine(ChangeScene(1));
	}
	public void DungeonScene(){
		StartCoroutine(ChangeScene(2));
	}
	public void MainScene(){
		StartCoroutine(ChangeScene(0));
	}
}
