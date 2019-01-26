using UnityEngine;

public class ClickableCells : MonoBehaviour
{
    public SpriteRenderer sprite;
    private bool alreadyClicked;

    private void OnMouseDown()
    {
        if (!alreadyClicked)
        {
           Click();
            
        }
        else
        {
            DesClick();
            
        }
    }

    public void Click() {
        GridManagerTool.AddCell(transform.position.x, transform.position.y);
        sprite.color = Color.red;
        alreadyClicked = !alreadyClicked;
    }

    public void DesClick() {
        GridManagerTool.RemoveCell(transform.position.x, transform.position.y);
        sprite.color = Color.white;
    }
}