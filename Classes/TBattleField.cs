namespace H.Classes
{
    public class TBattleField
    {
        //Класс для обработки событий и хранения данных о поле боя

        public class TBTile
        {
            public TBTile()
            {
                id = 0;
            }

            public int id;
            public TUnit unit;
            public int owner;
            public int hp;
            public int amount;

            static public string Id_to_name(int inp)
            {
                string res = "Error";
                if ((inp > 0) && (inp <= 25)) res = TUnit.FromIDtoName(inp);
                switch(inp)
                {
                    case 0: res = "Grass"; break;
                    case -1: res = "Tree"; break;
                    case -2: res = "Water"; break;
                }
                return res;
            }
        }

        public  TBattleField()
        {
            tiles = new TBTile[CL.Map_Width, CL.Map_Height];
            for(int x = 0; x < CL.Map_Width; x++)
            {
                for (int y = 0; y < CL.Map_Height; y++)
                {
                    tiles[x, y] = new TBTile();
                }
            }
        }

        public void Ini(TArmy army1, TArmy army2)
        {
            for (int x = 0; x < CL.Map_Width; x++)
            {
                for (int y = 0; y < CL.Map_Height; y++)
                {
                    tiles[x, y].id = 0;
                }
            }
            TArmy cur_army = army1;
            for(int i = 0; i < 2; i++)
            {
                for(int y = 0; y < CL.MaxStacks; y++)
                {
                    if (cur_army.units[y].exists == true)
                    {
                        tiles[(CL.Map_Width - 1) * i, y].unit = cur_army.units[y].type;
                        tiles[(CL.Map_Width - 1) * i, y].amount = cur_army.units[y].amount;
                        tiles[(CL.Map_Width - 1) * i, y].owner = i + 1;
                        tiles[(CL.Map_Width - 1) * i, y].hp = cur_army.units[y].type.HP;
                        tiles[(CL.Map_Width - 1) * i, y].id = i + 2;
                    }
                }
                cur_army = army2;
            }
        }

        public TBTile[,] tiles;
    }
}
