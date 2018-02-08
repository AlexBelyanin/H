namespace H.Classes
{
    class TArmy
    {
        //Класс "Армии"- как в подчинении героя, так и без него
        public class TUnitInArmy
        {
            bool exists = false;
            TUnit type;
            int amount;

            public TUnitInArmy() { }
            public TUnitInArmy(int id, int number)
            {
                exists = true;
                type = new TUnit(id);
                amount = number;
            }
        }

        TUnitInArmy[] units = new TUnitInArmy[CL.MaxStacks];

        public TArmy()
        {
            for (int i = 0; i < CL.MaxStacks; i++)
            {
                units[i] = new TUnitInArmy();
            }
            units[0] = new TUnitInArmy(1, 1);
        }
    }
}