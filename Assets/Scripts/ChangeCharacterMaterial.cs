using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterMaterial : MonoBehaviour {

	public static ChangeCharacterMaterial Instance;

	private string _bodyShape = "round";
	private string _colorBody = "blue";
	private string _eyesType = "type_01";

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
			this.UpdateMaterials();
		}
	}

	public string colorBody {
		get {
			return _colorBody; 
		}
		set {
			_colorBody = value;
			this.UpdateMaterials();
		}
	}

	public string eyesType {
		get {
			return _eyesType; 
		}
		set {
			_eyesType = value;
			this.UpdateMaterials();
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

	private void UpdateMaterials() {
		Renderer rend = GetComponent<Renderer>();
		Material[] newMat = new Material[4];
		// Body
		newMat[0] = Resources.Load( this.bodyDir, typeof(Material) ) as Material;
		// Eyes
		newMat[1] = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
		newMat[2] = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
		newMat[3] = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
		rend.materials = newMat;
	}
}
