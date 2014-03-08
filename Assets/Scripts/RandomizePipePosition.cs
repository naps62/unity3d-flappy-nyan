using UnityEngine;
using System.Collections;

public class RandomizePipePosition : MonoBehaviour {

	public float min;
	public float max;

	void Awake() {
		transform.position = Vector3.up * Random.Range(min, max);
	}
}
