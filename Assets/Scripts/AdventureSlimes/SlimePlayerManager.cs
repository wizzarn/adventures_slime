using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureSlimes {
	public class SlimePlayerManager : MonoBehaviour {

		public Transform [] slime_bodies;
		public RuntimeAnimatorController slime_animatorController;
		public Transform slime_spawnPosition;

		private string _bodyShape = "round";
		private string _colorBody = "blue";
		private string _eyesType = "type_01";

		public string bodyShape {
			get {
				return _bodyShape;
			}
			set {
				_bodyShape = value;
				this.UpdateSlimeModel();
			}
		}

		public string colorBody {
			get {
				return _colorBody;
			}
			set {
				_colorBody = value;
				this.UpdateSlimeModel();
			}
		}

		public string eyesType {
			get {
				return _eyesType; 
			}
			set {
				_eyesType = value;
				this.UpdateSlimeModel();
			}
		}

		public string bodyDir {
			get {
				return SlimeTypes.slimeBodiesDir + this.bodyShape + "/" + this.bodyShape + "_" + this.colorBody;
			}
			private set {}
		}

		public string eyesDir {
			get {
				return SlimeTypes.slimeEyesDir + this.eyesType;
			}
			private set {}
		}

		void Start () {

			// Check if all components required are set
			this.checkComponents();
			if( !this.checkComponents() ) {
				Debug.LogError( this.GetType() + ": missing components" );
				return;
			}

			_bodyShape = Token.GetCustomField("shape");
			_colorBody = Token.GetCustomField("color");
			_eyesType = Token.GetCustomField("eye");
			this.UpdateSlimeModel();

		}

		private bool checkComponents() {
			bool isValid = true;

			if( slime_bodies.Length < 1 ) {
				Debug.LogError( this.GetType() + ": slime_bodies array empty" );
				isValid = false;
			}

			if( slime_animatorController == null ) {
				Debug.LogError( this.GetType() + ": slime_animatorController is null" );
				isValid = false;
			}

			return isValid;
		}

		public void UpdateSlimeModel() {
			if( !this.checkComponents() ) {
				Debug.LogError( this.GetType() + ": missing components" );
				return;
			}

			GameObject slime_player = GameObject.Find ("player_slime");
			if( slime_player != null ) {
				Destroy( slime_player );
			}

			Vector3 slime_position = new Vector3( 0, 0, 0 );
			// Check if spawn position is set
			if( slime_spawnPosition != null ) {
				slime_position = slime_spawnPosition.position;
			}

			// Initialization of player object
			int slime_index = SlimeTypes.SlimeTypeIndex( this.bodyShape );
			slime_player = new GameObject( "player_slime" );
			Transform slime_prefab = Instantiate( slime_bodies[slime_index],
												  slime_position,
												  Quaternion.identity
			                                    );
			slime_prefab.name = "slime_transform";
			slime_prefab.SetParent( slime_player.transform );

			// Update fbx models
			Transform slime_fbx = slime_prefab.FindChild( "fbx" );
			if( slime_fbx ) {
				// Set animator controller
				Animator slime_animator = slime_fbx.GetComponent<Animator>();
				if( slime_animator ) {
					slime_animator.runtimeAnimatorController = this.slime_animatorController;
				} else {
					Debug.LogError( this.GetType() + ": slime prefab does not have animator in the children fbx" );
				}
				// Set eyes and body textures
				Transform slime_body = slime_fbx.FindChild( "slime_body" );
				Transform slime_eyebrows = slime_fbx.FindChild( "slime_eyebrows" );
				Transform slime_eyes = slime_fbx.FindChild( "slime_eyes" );
				Transform slime_pupils = slime_fbx.FindChild( "slime_pupils" );

				// Body
				if( slime_body != null ) {
					Renderer rend = slime_body.GetComponent<Renderer>();
					Material newMat = Resources.Load( this.bodyDir, typeof( Material ) ) as Material;
					newMat.renderQueue = newMat.renderQueue - 20;
					rend.material = newMat;
				} else {
					Debug.LogError( this.GetType() + ": slime prefab does not have slime_body child in fbx child" );
				}

				// Eyes
				if( slime_eyes != null ) {
					Renderer rend = slime_eyes.GetComponent<Renderer>();
					Material newMat = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
					newMat.renderQueue = newMat.renderQueue + 10;
					rend.material = newMat;
				} else {
					Debug.LogError( this.GetType() + ": slime prefab does not have slime_eyes child in fbx child" );
				}

				// Eyebrows
				if( slime_eyebrows != null ) {
					Renderer rend = slime_eyebrows.GetComponent<Renderer>();
					Material newMat = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
					newMat.renderQueue = newMat.renderQueue + 10;
					rend.material = newMat;
				} else {
					Debug.LogError( this.GetType() + ": slime prefab does not have slime_eyebrows child in fbx child" );
				}

				// Pupils
				if( slime_pupils != null ) {
					Renderer rend = slime_pupils.GetComponent<Renderer>();
					Material newMat = Resources.Load( this.eyesDir, typeof(Material) ) as Material;
					newMat.renderQueue = newMat.renderQueue + 15;
					rend.material = newMat;
				} else {
					Debug.LogError( this.GetType() + ": slime prefab does not have slime_pupils child in fbx child" );
				}
			} else {
				Debug.LogError( this.GetType() + ": slime prefab does not have fbx children" );
			}
		}
	}

}