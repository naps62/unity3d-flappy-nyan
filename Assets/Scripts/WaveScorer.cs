using UnityEngine;
using System.Collections;

public class WaveScorer : MonoBehaviour {

	private ScoreController scoreController;

	void Awake() {
		scoreController = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ScoreController>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == Tags.player) {
			scoreController.Score();
			collider2D.enabled = false;
		}
	}

}
