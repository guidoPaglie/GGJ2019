using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour {
	public SpriteRenderer SpriteRenderer;
	public Animator Animator;
	public void HighlightItem(string itemResourceName) {
		var itemSprite = Resources.Load<Sprite>("Sprites/" + itemResourceName);
		SpriteRenderer.sprite = itemSprite;
		Animator.SetTrigger("Play");
	}
}
