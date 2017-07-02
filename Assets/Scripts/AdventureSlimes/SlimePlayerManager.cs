
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureSlimes {

	static public class SlimeTypes {
		public const int Banana = 0;
		public const int Big_round = 1;
		public const int Bunny = 2;
		public const int Double = 3;
		public const int Fan = 4;
		public const int Flan = 5;
		public const int Griddle = 6;
		public const int Heart = 7;
		public const int Monster = 8;
		public const int Round = 9;
		public const int Snowman = 10;
		public const int Spade = 11;
		public const int Square = 12;
		public const int Triangle = 13;

		public const string slimeBodiesDir = "Slimes/Bodies/";
		public const string slimeEyesDir = "Slimes/Eyes/";

		public static int SlimeTypeIndex( string name ) {
			if( name.Equals( "banana" ) ) {
				return SlimeTypes.Banana;
			}
			if( name.Equals( "big_round" ) ) {
				return SlimeTypes.Big_round;
			}
			if( name.Equals( "bunny" ) ) {
				return SlimeTypes.Bunny;
			}
			if( name.Equals( "double" ) ) {
				return SlimeTypes.Double;
			}
			if( name.Equals( "fan" ) ) {
				return SlimeTypes.Fan;
			}
			if( name.Equals( "flan" ) ) {
				return SlimeTypes.Flan;
			}
			if( name.Equals( "griddle" ) ) {
				return SlimeTypes.Griddle;
			}
			if( name.Equals( "heart" ) ) {
				return SlimeTypes.Heart;
			}
			if( name.Equals( "monster" ) ) {
				return SlimeTypes.Monster;
			}
			if( name.Equals( "round" ) ) {
				return SlimeTypes.Round;
			}
			if( name.Equals( "snowman" ) ) {
				return SlimeTypes.Snowman;
			}
			if( name.Equals( "spade" ) ) {
				return SlimeTypes.Spade;
			}
			if( name.Equals( "square" ) ) {
				return SlimeTypes.Square;
			}
			if( name.Equals( "triangle" ) ) {
				return SlimeTypes.Triangle;
			}

			return SlimeTypes.Round;
		}
	}

	public class SlimePlayerManager : MonoBehaviour {

		public Transform [] slime_bodies;
		public RuntimeAnimatorController slime_animatorController;

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

			// Initialization of player object
			int slime_index = SlimeTypes.SlimeTypeIndex( this.bodyShape );
			slime_player = new GameObject( "player_slime" );
			Transform slime_prefab = Instantiate( slime_bodies[slime_index],
												  new Vector3( 0, 0, 0 ),
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