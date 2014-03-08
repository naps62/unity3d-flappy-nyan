using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float jumpForce;
	public float tilt;
	public float jumpVelocity;
	public float fallVelocity;

	private bool jumping;

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
		jumping = true;
	}

	void StartGame() {
		rigidbody2D.isKinematic = false;
		GameObject.FindGameObjectWithTag(Tags.pipeGenerator).GetComponent<PipeGenerator>().Enable();
		Destroy(GameObject.FindGameObjectWithTag(Tags.callToAction));
	}
}
