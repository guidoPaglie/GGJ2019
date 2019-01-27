using UnityEngine;

[ExecuteInEditMode]
public class Item : MonoBehaviour {
	public string id;
	public Vector2Int itemPosition;
	public bool isPickable;
	public bool isWalkable;
	public string message;
	public bool isDoor;
	public bool isTrigger;
	public Animator Animator;

	void Update() {
		if (itemPosition != null)
			transform.position = new Vector2(itemPosition.x, itemPosition.y);
	}

	public void DestroyItem() {
		Destroy(gameObject);
	}

	public void SetPosition(Vector2 position) {
		itemPosition.x = (int) position.x;
		itemPosition.y = (int) position.y;
	}

	public void Animate() {
		if (Animator == null) return;
		Animator.enabled = true;
		Animator.SetTrigger("Play");
	}

	public void StopAnimation() {
		if (Animator != null) {
			Animator.enabled = false;
		}
	}
}