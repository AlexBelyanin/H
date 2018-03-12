using System;
using System.Collections.Generic;
using System.Drawing;

namespace H.Classes
{
    [Serializable]
    class Player
    {
        public Color color;
        public List<Castle> pCastles;
        public List<THero> pHeroes;
        public List<Factory> pFactories;
        public Bitmap SuperDinamicLayer;
        public int[] Resourses;
        public bool[,] Visible;
        //gold stone wood

        public Player(int pNumber,Castle castle,int size)
        {
            pCastles = new List<Castle>();
            pCastles.Add(castle);
            pHeroes = new List<THero>();
            pFactories = new List<Factory>();
            Resourses = new int[] { 1000, 10, 10 };
            SuperDinamicLayer = new Bitmap(size * 32 + 256, size * 32 + 256);
            Graphics gS = Graphics.FromImage(SuperDinamicLayer);
            NewVisible(size);
            for (int i = 0; i < size + 8; i++)
                for (int j = 0; j < size + 8; j++)
                {
                    if (i < 4 || j < 4 || i > size + 3 || j > size + 3) gS.DrawImage(H.Properties.Resources.H_Cell_White, 32 * i, 32 * j);
                    else if(Visible[i - 4, j - 4] == true) gS.DrawImage(H.Properties.Resources.H_Cell_White, 32 * i, 32 * j);
                    else gS.DrawImage(H.Properties.Resources.H_Cell_Dirt, 32 * i, 32 * j);
                }
            SuperDinamicLayer.MakeTransparent(SuperDinamicLayer.GetPixel(1, 1));
            switch (pNumber)
            {
                case (0):
                    color = Color.Red;
                    break;
                case (1):
                    color = Color.Blue;
                    break;
                case (2):
                    color = Color.Green;
                    break;
                case (3):
                    color = Color.Pink;
                    break;
                case (4):
                    color = Color.Orange;
                    break;
                case (5):
                    color = Color.Yellow;
                    break;
                case (6):
                    color = Color.Chocolate;
                    break;
                case (7):
                    color = Color.Cyan;
                    break;
            }

        }

        public Player(int pNumber, int size)
        {
            pCastles = new List<Castle>();
            pHeroes = new List<THero>();
            pFactories = new List<Factory>();
            Resourses = new int[] { 1000, 10, 10 };
            SuperDinamicLayer = new Bitmap(size * 32 + 256, size * 32 + 256);
            Graphics gS = Graphics.FromImage(SuperDinamicLayer);
            NewVisible(size);
            for (int i = 0; i < size + 8; i++)
                for (int j = 0; j < size + 8; j++)
                {
                    if (i < 4 || j < 4 || i > size + 3 || j > size + 3) gS.DrawImage(H.Properties.Resources.H_Cell_White, 32 * i, 32 * j);
                    else if (Visible[i - 4, j - 4] == true) gS.DrawImage(H.Properties.Resources.H_Cell_White, 32 * i, 32 * j);
                    else gS.DrawImage(H.Properties.Resources.H_Cell_Dirt, 32 * i, 32 * j);
                }
            SuperDinamicLayer.MakeTransparent(SuperDinamicLayer.GetPixel(1, 1));
            switch (pNumber)
            {
                case (0):
                    color = Color.Red;
                    break;
                case (1):
                    color = Color.Blue;
                    break;
                case (2):
                    color = Color.Green;
                    break;
                case (3):
                    color = Color.Pink;
                    break;
                case (4):
                    color = Color.Orange;
                    break;
                case (5):
                    color = Color.Yellow;
                    break;
                case (6):
                    color = Color.Chocolate;
                    break;
                case (7):
                    color = Color.Cyan;
                    break;
            }

        }

        void NewVisible(int size)
        {
            Visible = new bool[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Visible[i, j] = false;
            foreach (Castle c in pCastles)
            {
                for (int i = -4; i < 5; i++)
                    for (int j = -4; j < 3; j++)
                    {
                        int X = c.x + i, Y = c.y + j;
                        if (X >= 0 && Y >= 0 && X < size && Y < size) Visible[X, Y] = true;
                    }
            }
            foreach(THero h in pHeroes)
            {
                int r = h.VisionR;
                for (int i = 0; i < r; i++)
                    for (int j = 0; j <= i; j++)
                    {
                        if ((j - 1) * (j - 1) <= (r - 1) * r + 1 - i * i)
                        {
                            if (h.x + i < size && h.y + j < size) Visible[h.x + i, h.y + j] = true;
                            if (h.x - i > 0 && h.y + j < size) Visible[h.x - i, h.y + j] = true;
                            if (h.y - j > 0 && h.x + i < size) Visible[h.x + i, h.y - j] = true;
                            if (h.x - i > 0 && h.y - j > 0) Visible[h.x - i, h.y - j] = true;
                        }
                        else break;
                    }
                
                    
            }
        }

    }



    [Serializable]
    class Cell
    {
        //public bool[] ISvisible;
        //public bool IStouchable;
        //-1 - rock or something
        //0 - nothing
        //1 - resource
        //2 - castle
        //3 - factory
        //4 - hero
        public int ISusable;
        public int passability;
        public Bitmap Ground;


        public Cell()
        {
            //ISvisible = new bool[4];
            //for (int i = 0; i < 4; i++) ISvisible[i] = true;
            //IStouchable = true;
            ISusable = 0;
            passability = 1;
            Ground = new Bitmap(H.Properties.Resources.H_Cell_Grass1);
        }
    }

    [Serializable]
    class Map
    {
        public List<Player> Players;
        public string name;
        public int size;
        public Cell[,] Cells;
        public int turn;
        public Bitmap LayerStatic;
        public List<Castle> Castles;
        public List<Factory> Factories;
        public List<THero> Heroes;
        public List<Resource> Resourses;

        public Map()
        {
            name = "StandartMap.hmap";
            size = 32;
            Cells = new Cell[32, 32];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Cells[i,j] = new Cell();
                }
            turn = 0;
            Resourses = new List<Resource>();
            Heroes = new List<THero>();
            Factories = new List<Factory>();
            Castles = new List<Castle>();
            Players = new List<Player>();
            for (int i = 0; i < 2; i++) Players.Add(new Player(i, size));
            DrawMap();
        }

        public void DrawMap()
        {
            DrawStatic();
        }

        public void DrawStatic()
        {
            LayerStatic = new Bitmap(size * 32 + 256, size * 32 + 256);
            Graphics gS = Graphics.FromImage(LayerStatic);
            for (int i = 0; i < size + 8; i++)
                for (int j = 0; j < size + 8; j++)
                {
                    if (i < 4 || j < 4 || i > size + 3 || j > size + 3) gS.DrawImage(H.Properties.Resources.H_Cell_Black, 32 * i, 32 * j);
                    else
                        gS.DrawImage(Cells[i - 4, j - 4].Ground, 32 * i, 32 * j);
                }
            foreach(Factory f in Factories)
            {
                gS.DrawImage(f.Image, f.x * 32 + 96, f.y * 32 + 96);
            }
            foreach (Castle f in Castles)
            {
                gS.DrawImage(f.Image, f.x * 32 + 64, f.y * 32 + 64);
            }
        }

        public void AddFactory(int what, int x, int y)
        {
            Factories.Add(new Factory(what, x, y));
            Cells[x, y].ISusable = 3;
            Cells[x - 1, y - 1].ISusable = -3;
            Cells[x - 1, y].ISusable = -3;
            Cells[x, y - 1].ISusable = -3;
            Cells[x + 1, y].ISusable = -3;
            Cells[x + 1, y - 1].ISusable = -3;
        }

        public void AddCastle(int what,int x,int y)
        {
            Castles.Add(new Castle(what, x, y));
            Cells[x, y].ISusable = 2;
            Cells[x - 2, y - 2].ISusable = -2;
            Cells[x - 2, y - 1].ISusable = -2;
            Cells[x - 2, y].ISusable = -2;
            Cells[x - 1, y - 2].ISusable = -2;
            Cells[x - 1, y - 1].ISusable = -2;
            Cells[x - 1, y].ISusable = -2;
            Cells[x, y - 2].ISusable = -2;
            Cells[x, y - 1].ISusable = -2;
            Cells[x + 1, y - 2].ISusable = -2;
            Cells[x + 1, y - 1].ISusable = -2;
            Cells[x + 1, y].ISusable = -2;
            Cells[x + 2, y - 2].ISusable = -2;
            Cells[x + 2, y - 1].ISusable = -2;
            Cells[x + 2, y].ISusable = -2;
        }
    }
}
