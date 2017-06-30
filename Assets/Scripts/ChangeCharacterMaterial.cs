using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterMaterial : MonoBehaviour {

	public static ChangeCharacterMaterial Instance;

	private string _bodyShape = "round";
	private string _colorBody = "blue";
	private string _eyesType = "type_01";

	public Transform Body;
	public Transform Eyes;
	public Transform Eyebrows;
	public Transform Pupils;

	void Awake() {
		if (Instance != null) {
			Debug.LogError("Multiple instances of ChangeCharacterMaterial!");
		}		
		Instance = this;
	}

	public string bodyShape {
		get {
			return _bodyShape;
		}
		set {
			_bodyShape = value;
			this.UpdateBody();
		}
	}

	public string colorBody {
		get {
			return _colorBody;
		}
		set {
			_colorBody = value;
			this.UpdateBody();
		}
	}

	public string eyesType {
		get {
			return _eyesType; 
		}
		set {
			_eyesType = value;
			this.UpdateEyes();
		}
	}

	public string bodyDir {
		get {
			return "Slimes/Bodies/" + this.colorBody + "/" + this.bodyShape;
		}
		private set {}
	}

	public string eyesDir {
		get {
			return "Slimes/Eyes/" + this.eyesType;
		}
		private set {}
	}

	private void UpdateBody() {
		Renderer rend = this.Body.GetComponent<Renderer>();
		// Body
		Material newMat = Resources.Load( this.bodyDir, typeof(Material) ) as Material;
		rend.material = newMat;
	}

	private void UpdateEyes() {
		Renderer rend_eye1 = this.Eyes.GetComponent<Renderer>();
		Renderer rend_eye2 = this.Eyebrows.GetComponent<Renderer>();
		Renderer rend_eye3 = this.Pupils.GetComponent<Renderer>();
		// Eyes
		Material newMat = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
		rend_eye1.material = newMat;
		rend_eye2.material = newMat;
		rend_eye3.material = newMat;

	}
}
