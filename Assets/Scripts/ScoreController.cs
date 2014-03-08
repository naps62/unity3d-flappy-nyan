using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public GUIText scoreText;
	private int score;

	void Awake() {
		score = 0;
		scoreText.text = score.ToString();
	}

	public void Score() {
		score++;
		scoreText.text = score.ToString();
		audio.Play();
	}
}
