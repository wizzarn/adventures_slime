using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ApiController;

public class OnLoadScene : MonoBehaviour {
	
	public UserProfileController userProfileCtrl;
	void Start () {
		if (Token.GetUserId() != "" && userProfileCtrl)
			userProfileCtrl.getByUserId (Token.GetUserId(),GetByUseIdCallback);
	}

	void GetByUseIdCallback(UserProfileModel response){
		Token.SaveCustomField ("shape",response.shape);
		Token.SaveCustomField ("eye",response.eye);
		Token.SaveCustomField ("color",response.color);
	}

}
