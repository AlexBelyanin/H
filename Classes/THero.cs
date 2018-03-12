using System;

namespace H.Classes
{
    [Serializable]
    class THero
    {
        //Класс для героя

        public THero() { }
        public THero(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public int VisionR = 3;
        public int x = 10;
        public int y = 10;
        public TArmy army = new TArmy();
        public int MoveSpeed = 10;
    }
}