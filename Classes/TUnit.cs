using System.Collections.Generic;

namespace H.Classes
{
    public class TUnit
    {
        //Класс, хранящий "статическую" информацию о юните

        public TUnit() { GetUnit("Peasant"); }
        public TUnit(int id)
        {
            GetUnit(FromIDtoName(id));
        }
        public TUnit(string name)
        {
            GetUnit(name);
        }

        static public string FromIDtoName(int inp)
        {
            switch (inp)
            {
                case 1: return "Militia";
                case 2: return "Archer";
                case 3: return "Pikeman";
                case 4: return "Cavalry";
                case 5: return "Knight";

                case 6: return "Skeleton";
                case 7: return "Zombie";
                case 8: return "Ghost";
                case 9: return "Vampire";
                case 10: return "Demon";

                case 11: return "Sprite";
                case 12: return "Elf";
                case 13: return "Troll";
                case 14: return "Druid";
                case 15: return "Dragon";

                case 16: return "Nomad";
                case 17: return "Barbarian";
                case 18: return "Ogre";
                case 19: return "Giant";
                case 20: return "Prophet";

                default: return "Peasant";
            }
        }

        public void GetUnit(string name)
        {
            if (name == "Militia") Ini(name, 15, 4, 8, 3, 3, 1);
            if (name == "Archer") Ini(name, 10, 3, 5, 2, 4, 2);
            if (name == "Pikeman") Ini(name, 30, 10, 12, 3, 1, 3);
            if (name == "Cavalry") Ini(name, 40, 15, 20, 5, 4, 4);
            if (name == "Knight") Ini(name, 80, 30, 50, 3, 5, 3);

            if (name == "Skeleton") Ini(name, 15, 4, 8, 3, 5, 1);
            if (name == "Zombie") Ini(name, 10, 3, 5, 2, 1, 2);
            if (name == "Ghost") Ini(name, 30, 10, 12, 3, 4, 3);
            if (name == "Vampire") Ini(name, 40, 15, 20, 5, 2, 5);
            if (name == "Demon") Ini(name, 80, 30, 50, 3, 4, 5);

            if (name == "Sprite") Ini(name, 15, 4, 8, 3, 2, 1);
            if (name == "Elf") Ini(name, 10, 3, 5, 2, 5, 2);
            if (name == "Troll") Ini(name, 30, 10, 12, 3, 3, 4);
            if (name == "Druid") Ini(name, 40, 15, 20, 5, 5, 4);
            if (name == "Dragon") Ini(name, 80, 30, 50, 3, 5, 5);

            if (name == "Nomad") Ini(name, 15, 4, 8, 3, 2, 3);
            if (name == "Barbarian") Ini(name, 10, 3, 5, 2, 2, 4);
            if (name == "Ogre") Ini(name, 30, 10, 12, 3, 1, 4);
            if (name == "Giant") Ini(name, 40, 15, 20, 5, 3, 5);
            if (name == "Prophet") Ini(name, 80, 30, 50, 3, 2, 2);

            if (name == "Peasant") Ini(name, 3, 1, 2, 2, 1, 1);
        }

        public void Ini(string name_inp, int hp_inp, int min_dam_inp, int max_dam_inp, int movespeed_inp, int Draw_X_inp, int Draw_Y_inp)
        {
            Name = name_inp;
            HP = hp_inp;
            MinDam = min_dam_inp;
            MaxDam = max_dam_inp;
            movespeed = movespeed_inp;
            Draw_X = Draw_X_inp;
            Draw_Y = Draw_Y_inp;

            //Здесь указываются дополнительные способности юнитов
            if (name_inp == "Archer") Special_abilities.Add("Ranged");
        }

        public int HP;
        public string Name;
        public int MinDam;
        public int MaxDam;
        public int Draw_X;
        public int Draw_Y;
        public int movespeed;
        public List<string> Special_abilities = new List<string>();

        public override string ToString()
        {
            return Name;
        }
    }
}