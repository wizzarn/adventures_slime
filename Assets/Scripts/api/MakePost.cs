using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace ApiController{
	public class MakePost : MonoBehaviour {

		// Use this for initialization
		public HttpHandler httpHandlerScript;
		void Start () {
			
		}
		
		void Update(){
			if (Input.GetKeyDown(KeyCode.A)){
				WWWForm form = new WWWForm();
				form.AddField("title", "titulo1");
				form.AddField("body", "cuerpo1");
				form.AddField("userId", 1);
				httpHandlerScript.POST("http://jsonplaceholder.typicode.com/posts",CallBackResponsePost,form);
			}
			if (Input.GetKeyDown(KeyCode.B)){
				httpHandlerScript.GET("http://jsonplaceholder.typicode.com/posts",CallBackResponseGet);
			}
		}

		void CallBackResponsePost(string response){
			print (response);
		}
		void CallBackResponseGet(string response){
			print (response);
		}
	}
}
