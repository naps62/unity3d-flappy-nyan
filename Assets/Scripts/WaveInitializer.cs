using UnityEngine;
using System.Collections;

public class WaveInitializer : MonoBehaviour {

	public static int lastRemovedIndex = 4;

	public int amountToRemove;
	public GameObject[] asteroids;

	void Awake() {
		int toRemoveIndex = 100;
		while (Mathf.Abs(lastRemovedIndex - toRemoveIndex) > transform.childCount - 2) {
			toRemoveIndex = Random.Range(0, transform.childCount - 1);
		}
		lastRemovedIndex = toRemoveIndex;
		Debug.Log(toRemoveIndex);
		

		while (amountToRemove > 0) {
			Destroy(asteroids[toRemoveIndex + amountToRemove - 1]);
			amountToRemove--;
		}
	}
}
