using UnityEngine;

public class ClickableCells : MonoBehaviour
{
    public SpriteRenderer sprite;
    private bool alreadyClicked;

    private void OnMouseDown()
    {
        if (!alreadyClicked)
        {
            GridManager.AddCell(transform.position.x, transform.position.y);
            sprite.color = Color.red;
        }
        else
        {
            GridManager.RemoveCell(transform.position.x, transform.position.y);
            sprite.color = Color.white;
        }

        alreadyClicked = !alreadyClicked;
    }
}