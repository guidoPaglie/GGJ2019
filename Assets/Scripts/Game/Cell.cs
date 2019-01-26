public class Cell
{
    public bool _walkable;
    public Item _item;

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
        return _walkable && _item;
    }

    public void SetItem(Item item) {
        _item = item;
    }
}