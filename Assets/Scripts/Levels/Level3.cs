namespace Levels
{
    public class Level3 : LevelController
    {
        /*
         * baúl (chest_left), mesita de luz (drawer_left), auto1 (car1_left), auto2 (car2_left), 
auto3 (car3_left), biblioteca (library_left), tv (tv_left), llave (key_left)

         */
        public Item chest_left;
        public Item drawer_left;
        public Item car1_left;
        public Item car2_left;
        public Item car3_left;
        public Item library_left;
        public Item tv_left;
        public Item key_left;

        public Item chest_right;
        public Item drawer_right;
        public Item car1_right;
        public Item car2_right;
        public Item car3_right;
        public Item library_right;
        public Item tv_right;
        public Item key_right;

        protected override void OnStart()
        {
            GridManager.InsertItemIn(chest_left);
            GridManager.InsertItemIn(drawer_left);
            GridManager.InsertItemIn(car1_left);
            GridManager.InsertItemIn(car2_left);
            GridManager.InsertItemIn(car3_left);
            GridManager.InsertItemIn(library_left);
            GridManager.InsertItemIn(tv_left);
            GridManager.InsertItemIn(key_left);

            GridManager.InsertItemIn(chest_right);
            GridManager.InsertItemIn(drawer_right);
            GridManager.InsertItemIn(car1_right);
            GridManager.InsertItemIn(car2_right);
            GridManager.InsertItemIn(car3_right);
            GridManager.InsertItemIn(library_right);
            GridManager.InsertItemIn(tv_right);
            GridManager.InsertItemIn(key_right);
        }
    }
}