using UnityEngine;
using System.Collections;

public class GUIControls : MonoBehaviour {

	public bool gameOver = false;

	void OnGUI() {
		if (!gameOver)
			return;
		
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50), "Share highscore on Facebook")) {
			FB.Init(OnInitComplete);
		}

		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 50), "Try again")) {
			Application.LoadLevel(0);
		}
	}

	void OnInitComplete() {
		FB.Login("email,publish_actions", LoginCallback);
	}

	void LoginCallback(FBResult result) {
		if (result.Error != null) {
			ShareOnFacebook();
		}
	}

	void ShareOnFacebook() {
		int score = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ScoreController>().GetCurrentHighscore();
		WWWForm data = new WWWForm();
		data.AddField("score", score);
		FB.API(FB.UserId + "/scores", Facebook.HttpMethod.POST, ShareCallback, data);
	}

	void ShareCallback(FBResult result) {
	}
}
