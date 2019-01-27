using UnityEngine;

namespace Levels
{
    public class Level3 : LevelController
    {
        public Item chest_left;
        public Item drawer_left;
        public Item car1_left;
        public Item car2_left;
        public Item library_left;
        public Item tv_left;
        public Item key_left;

        public Item chest_right;
        public Item drawer_right;
        public Item car1_right;
        public Item car2_right;
        public Item library_right;
        public Item tv_right;
        public Item key_right;

        public Item LibraryLeftBlock;
        public Item LibraryRightBlock;
        
        private bool _car1Activated;
        private bool _car2Activated;
        private bool _alreadyDropped;
        
        protected override void OnStart()
        {
            GridManager.InsertItemIn(chest_left);
            GridManager.InsertItemIn(drawer_left);
            GridManager.InsertItemIn(car1_left);
            GridManager.InsertItemIn(car2_left);
            GridManager.InsertItemIn(library_left);
            GridManager.InsertItemIn(tv_left);

            GridManager.InsertItemIn(chest_right);
            GridManager.InsertItemIn(drawer_right);
            GridManager.InsertItemIn(car1_right);
            GridManager.InsertItemIn(car2_right);
            GridManager.InsertItemIn(library_right);
            GridManager.InsertItemIn(tv_right);
        }

        public override void OnTriggerEvent(string item)
        {
            switch (item)
            {
                case "car1_right":
                    _car1Activated = true;
                    _gameManager.AnimateItemTo(car1_left, Direction.Up, 4, () =>
                    {
                        if (_car2Activated)
                        {
                            DropKey();
                        }
                        _car1Activated = false;
                        _gameManager.AnimateItemTo(car1_left, Direction.Down, 4, () => { });
                    });
                    break;
                case "car2_left":
                    _car2Activated = true;
                    _gameManager.AnimateItemTo(car2_left, Direction.Right, 2, () =>
                    {
                        if (_car1Activated)
                        {
                            DropKey();
                        }
                        _car2Activated = false;
                        _gameManager.AnimateItemTo(car2_left, Direction.Left, 2, () => { });
                    });
                    break;
            }
        }

        private void DropKey()
        {
            if (_alreadyDropped)
                return;
            
            _alreadyDropped = true;
            GridManager.RemoveItemIn(key_left.itemPosition.x, key_left.itemPosition.y);
            key_left.SetPosition(new Vector2(key_left.itemPosition.x, key_left.itemPosition.y - 2));
            GridManager.InsertItemIn(key_left);
        }
    }
}