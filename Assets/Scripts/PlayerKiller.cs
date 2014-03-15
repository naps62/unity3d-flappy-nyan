using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	public GameObject background;
	public GameObject pipes;
	public float gameOverUpForce;


	void OnCollisionEnter2D(Collision2D collision) {
		GameOver();
	}

	void GameOver() {
		gameObject.GetComponent<PlayerMovement>().enabled = false;

		pipes.GetComponent<WaveGenerator>().enabled = false;

		foreach (GameObject wave in GameObject.FindGameObjectsWithTag(Tags.wave)) {
			wave.GetComponent<WaveScroller>().enabled = false;
		}

		GameObject.FindGameObjectWithTag(Tags.music).GetComponent<AudioSource>().Stop();
		GameObject.FindGameObjectWithTag(Tags.gameOverText).GetComponent<GUIText>().enabled = true;
		GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GUIControls>().gameOver = true;

		collider2D.enabled = false;
		rigidbody2D.AddForce(Vector3.up * gameOverUpForce);
		transform.Rotate(0f, 0f, 30f);
		GetComponent<Animator>().SetBool(HashIDs.dead, true);
	}
}
