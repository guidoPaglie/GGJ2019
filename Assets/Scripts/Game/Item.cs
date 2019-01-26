using UnityEngine;

//[ExecuteInEditMode]
public class Item : MonoBehaviour {
	public Vector2Int itemPosition;
	public bool isPickable;
	public bool isWalkable;
	public string message;

	void Update() {
#if UNITY_EDITOR
		if(itemPosition != null)
			transform.position = new Vector2(itemPosition.x, itemPosition.y);
#endif
	}
	
	public void DestroyItem()
	{
		Debug.Log("Culo");
		Destroy(this.gameObject);
	}
}