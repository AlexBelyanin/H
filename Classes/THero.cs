namespace H.Classes
{
    class THero
    {
        //Класс для героя

        public THero() { }
        public THero(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X = 10;
        public int Y = 10;
        public TArmy army = new TArmy();
        public int MoveSpeed = 10;
    }
}