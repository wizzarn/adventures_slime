using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandler : MonoBehaviour {

	// Use this for initialization
	public float  x=0;
	public float  y=0;
	public float  z=0;
	private 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (x,y,z);
	}
}
