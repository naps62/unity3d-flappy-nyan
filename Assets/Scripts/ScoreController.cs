using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText bestScoreText;
	private int score;
	private static int best = 0;

	void Awake() {
		score = 0;
	}

	public void Score() {
		score++;
		if (score > best) {
			best = score;
		}
		audio.Play();
	}

	public void Update() {
		scoreText.text = "Score: " + score;
		bestScoreText.text = "Best: " + best;
	}

	public int GetCurrentHighscore() {
		return best;
	}
}
