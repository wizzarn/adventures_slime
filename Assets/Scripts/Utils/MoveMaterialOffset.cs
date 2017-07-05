using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterialOffset : MonoBehaviour {
	public float scrollSpeedX = 0.5F;
	public float scrollSpeedY = 0.5F;
    private Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update() {
    	if( rend != null ){
	        float offsetX = Time.time * scrollSpeedX;
			float offsetY = Time.time * scrollSpeedY;
	        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
        }
    }
}