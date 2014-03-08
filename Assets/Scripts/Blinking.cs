using UnityEngine;
using System.Collections;

public class Blinking : MonoBehaviour {

	public float interval;

	private float lastBlink;

	void Awake() {
		lastBlink = Time.time;
	}

	void Update() {
		if (Time.time - lastBlink > interval) {
			gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
			lastBlink = Time.time;
		}
	}
}
