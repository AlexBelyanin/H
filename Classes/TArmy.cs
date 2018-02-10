namespace H.Classes
{
    public class TArmy
    {
        //Класс "Армии"- как в подчинении героя, так и без него
        public class TUnitInArmy
        {
            public bool exists = false;
            public TUnit type;
            public int amount;

            public TUnitInArmy() { }
            public TUnitInArmy(int id, int number)
            {
                exists = true;
                type = new TUnit(id);
                amount = number;
            }
        }

        public TUnitInArmy[] units = new TUnitInArmy[CL.MaxStacks];

        public TArmy()
        {
            for (int i = 0; i < CL.MaxStacks; i++)
            {
                units[i] = new TUnitInArmy();
            }
            units[0] = new TUnitInArmy(21, 1);
        }
    }
}