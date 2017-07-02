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
}