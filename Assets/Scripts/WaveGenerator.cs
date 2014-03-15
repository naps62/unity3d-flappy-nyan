using UnityEngine;
using System.Collections;

public class WaveGenerator : MonoBehaviour {

	public float startAt;
	public float spawnInterval;
	public float spawnPosition;
	public GameObject waveTemplate;

	private float lastSpawnAt = 0f;

	void Update() {
		if (CanSpawn()) {
			Spawn();
		}
	}

	bool CanSpawn() {
		return Time.time > startAt && (Time.time - lastSpawnAt > spawnInterval);
	}

	void Spawn() {
		GameObject wave = Instantiate(waveTemplate) as GameObject;
		wave.transform.parent = transform;
		wave.transform.Translate(spawnPosition, 0f, 0f);
		lastSpawnAt = Time.time;
	}

	public void Enable() {
		enabled = true;
		startAt += Time.time;
	}
}
