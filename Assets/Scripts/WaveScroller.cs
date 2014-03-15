using UnityEngine;
using System.Collections;

public class WaveScroller : MonoBehaviour {

	public float speed;
	public float destroyPosition;

	void Update() {
		transform.Translate(Vector3.left * Time.deltaTime * speed);

		if (transform.position.x <= destroyPosition) {
			Destroy(gameObject);
		}
	}
}
