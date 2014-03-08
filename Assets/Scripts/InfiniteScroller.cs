using UnityEngine;
using System.Collections;

public class InfiniteScroller : MonoBehaviour {

	public float speed;

	void Update() {
		renderer.material.mainTextureOffset = new Vector2((Time.time * speed / transform.localScale.x) % 1, 0f);
	}
}
