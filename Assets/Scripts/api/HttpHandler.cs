using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace ApiController{
	public class HttpHandler : MonoBehaviour {

		public delegate void CallBack(string result);

		// ************************************
		// POST METHOD
		// ************************************
		public void POST(string urlRequest, CallBack callBack,WWWForm form){
			StartCoroutine(__POST (urlRequest,callBack,form));
		} 
		IEnumerator __POST(string urlRequest, CallBack callBack, WWWForm form){
			UnityWebRequest www = UnityWebRequest.Post(urlRequest, form);
			yield return www.Send();
			if(www.isError) Debug.Log(www.error);
			else callBack(www.downloadHandler.text);
		}
		// ************************************
		// GET METHOD
		// ************************************
		public void GET(string urlRequest, CallBack callBack){
			StartCoroutine (__GET(urlRequest,callBack));
		}
		IEnumerator __GET(string urlRequest, CallBack callBack){
			UnityWebRequest www = UnityWebRequest.Get(urlRequest);
			yield return www.Send();
			if(www.isError) Debug.Log(www.error);
			else callBack(www.downloadHandler.text);
		}
	}
}

