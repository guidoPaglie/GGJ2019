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

	void Update() {
		if (itemPosition != null)
			transform.position = new Vector2(itemPosition.x, itemPosition.y);
	}

	public void DestroyItem() {
		Debug.Log("Culo");
		Destroy(this.gameObject);
	}

	public void SetPosition(Vector2 position) {
		itemPosition.x = (int) position.x;
		itemPosition.y = (int) position.y;
	}
}