using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterMaterial : MonoBehaviour {

	public static ChangeCharacterMaterial Instance;

	private string _bodyShape = "round";
	private string _colorBody = "blue";
	private string _eyesType = "type_01";

	public int type = 0;

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
			if( type == 0 )
				this.UpdateBody();
		}
	}

	public string eyesType {
		get {
			return _eyesType; 
		}
		set {
			_eyesType = value;
			if( type == 1 )
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
		Renderer rend = GetComponent<Renderer>();
		// Body
		Material newMat = Resources.Load( this.bodyDir, typeof(Material) ) as Material;
		rend.material = newMat;
	}

	private void UpdateEyes() {
		Renderer rend = GetComponent<Renderer>();
		// Eyes
		Material newMat = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
		rend.material = newMat;
	}
}
