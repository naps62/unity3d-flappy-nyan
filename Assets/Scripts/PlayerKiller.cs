using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	public GameObject background;
	public GameObject ground;
	public GameObject pipes;

	private bool waitingRestart;

	void Update() {
		if (waitingRestart && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) {
			Application.LoadLevel(0);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GameOver();
	}

	void GameOver() {
		gameObject.GetComponent<PlayerMovement>().enabled = false;
		gameObject.GetComponent<Animator>().enabled = false;

		background.GetComponent<InfiniteScroller>().enabled = false;
		ground.GetComponent<InfiniteScroller>().enabled = false;
		pipes.GetComponent<PipeGenerator>().enabled = false;

		foreach (GameObject pipe in GameObject.FindGameObjectsWithTag(Tags.pipe)) {
			pipe.GetComponent<PipeScroller>().enabled = false;
		}

		GameObject.FindGameObjectWithTag(Tags.music).GetComponent<AudioSource>().Stop();
		GameObject.FindGameObjectWithTag(Tags.gameOverText).GetComponent<GUIText>().enabled = true;
		waitingRestart = true;
	}
}
