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

    public void SetItem(Item item) {
        _item = item;
    }
}