using UnityEngine;
using System.Collections;

public class PipeGenerator : MonoBehaviour {

	public float startAt;
	public float spawnInterval;
	public float spawnPosition;
	public GameObject pipeTemplate;

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
		GameObject pipe = Instantiate(pipeTemplate) as GameObject;
		pipe.transform.parent = transform;
		pipe.transform.Translate(spawnPosition, 0f, 0f);
		lastSpawnAt = Time.time;
	}

	public void Enable() {
		enabled = true;
		startAt += Time.time;
	}
}
