using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float jumpForce;
	public float tilt;

	void Update() {
		if (JumpTriggered()) {
			if (rigidbody2D.isKinematic) {
				StartGame();
			}
			Jump();
		}
	}

	bool JumpTriggered(){
		return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
	}

	void Jump() {
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(Vector2.up * jumpForce);
	}

	void StartGame() {
		rigidbody2D.isKinematic = false;
		GameObject.FindGameObjectWithTag(Tags.waveGenerator).GetComponent<WaveGenerator>().Enable();
		Destroy(GameObject.FindGameObjectWithTag(Tags.callToAction));
	}
}
