using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	public GameObject background;
	public GameObject pipes;
	public float gameOverUpForce;

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

		background.GetComponent<InfiniteScroller>().enabled = false;
		pipes.GetComponent<WaveGenerator>().enabled = false;

		foreach (GameObject pipe in GameObject.FindGameObjectsWithTag(Tags.pipe)) {
			pipe.GetComponent<WaveScroller>().enabled = false;
		}

		GameObject.FindGameObjectWithTag(Tags.music).GetComponent<AudioSource>().Stop();
		GameObject.FindGameObjectWithTag(Tags.gameOverText).GetComponent<GUIText>().enabled = true;
		waitingRestart = true;

		collider2D.enabled = false;
		rigidbody2D.AddForce(Vector3.up * gameOverUpForce);
		transform.Rotate(0f, 0f, 30f);
		GetComponent<Animator>().SetBool(HashIDs.dead, true);
	}
}
