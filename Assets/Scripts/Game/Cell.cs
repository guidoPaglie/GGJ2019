using UnityEngine;

public class Cell
{
    private bool _walkable;
    private Item _item;

    public Cell() {
        _walkable = true;
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
        if (item == null && _item != null)
            _item.DestroyItem();
        
        _item = item;
    }
}