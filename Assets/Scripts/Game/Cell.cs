using UnityEngine;

public class Cell
{
    private readonly int _x;
    private readonly int _y;
    private bool _walkable;
    private Item _item;

    public Cell(int x, int y) {
        _x = x;
        _y = y;
        _walkable = true;
    }

    public Vector2 Position() {
        return new Vector2(_x, _y);
    }

    public void DisableWalk() {
        _walkable = false;
    }
    
    public void EnableWalk() {
        _walkable = true;
    }

    public bool IsWalkable() {
        return _walkable && (_item == null || _item.isWalkable);
    }

    public Item GetItem()
    {
        return _item;
    }

    public void SetItem(Item item)
    {
        if (item == null && _item != null && _item.isPickable)
            _item.DestroyItem();

        if (item != null) {
            item.SetPosition(Position());
        }

        _item = item;
    }
}