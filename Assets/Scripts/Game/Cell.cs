public class Cell
{
    public bool _walkable;

    public Cell() {
        _walkable = true;
    }

    public void DisableWalk() {
        _walkable = false;
    }
    
    public void EnableWalk() {
        _walkable = true;
    }
}