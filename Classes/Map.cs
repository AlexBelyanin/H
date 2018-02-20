using System;
using System.Collections.Generic;
using System.Drawing;

namespace H.Classes
{
    [Serializable]
    class Cell
    {
        public bool[] ISvisible;
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
            ISvisible = new bool[4];
            for (int i = 0; i < 4; i++) ISvisible[i] = true;
            //IStouchable = true;
            ISusable = 0;
            passability = 1;
            Ground = new Bitmap(H.Properties.Resources.H_Cell_Grass1);
        }
    }

    [Serializable]
    class Map
    {
        public string name;
        public int size;
        public Cell[,] Cells;
        public int turn;
        public Bitmap LayerStatic;
        public Bitmap LayerDinamic;
        public Bitmap LayerSuperDinamic;
        public List<Castle> Castles;
        public List<Factory> Factories;
        public List<THero> Heroes;
        public List<Resource> Resourses;

        //Graphics g;

        public Map()
        {
            name = "Standart Map";
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

            DrawMap();
            //Bitmap bitmap = new Bitmap(size * 32 + 64, size * 32 + 64);
            //g = Graphics.FromImage(bitmap);
        }

        public void DrawMap()
        {
            DrawDinamic(0,0);
            DrawStatic(0,0);
        }

        public void DrawStatic(int mx, int my)
        {
            LayerStatic = new Bitmap(size * 32 + 256 - mx, size * 32 + 256 - my);
            Graphics gS = Graphics.FromImage(LayerStatic);
            for (int i = 0; i < size + 8; i++)
                for (int j = 0; j < size + 8; j++)
                {
                    if (i < 4 || j < 4 || i > size + 3 || j > size + 3) gS.DrawImage(H.Properties.Resources.H_Cell_Black, 32 * i - mx, 32 * j - my);
                    else
                        gS.DrawImage(Cells[i - 4, j - 4].Ground, 32 * i - mx, 32 * j - my);
                }
            foreach(Factory f in Factories)
            {
                gS.DrawImage(f.Image, f.x * 32 + 96 - mx, f.y * 32 + 96 - my);
            }
            foreach (Castle f in Castles)
            {
                gS.DrawImage(f.Image, f.x * 32 + 64 - mx, f.y * 32 + 64 - my);
            }
        }

        public void DrawDinamic(int mx, int my)
        {
            LayerDinamic = new Bitmap(size * 32 + 256 - mx, size * 32 + 256 - my);
            LayerDinamic.MakeTransparent(LayerDinamic.GetPixel(1, 1));
            Graphics gD = Graphics.FromImage(LayerDinamic);
            foreach (Resource res in Resourses)
            {
                gD.DrawImage(res.Image, res.x * 32 + 128 - mx, res.y * 32 + 128 - my);
                Cells[res.x, res.y].ISusable = 1;
            }
        }

        public void AddFactory(int what, int x, int y)
        {
            Factories.Add(new Factory(what, x, y));
            Cells[x, y].ISusable = 3;
            Cells[x - 1, y - 1].ISusable = -1;
            Cells[x - 1, y].ISusable = -1;
            Cells[x, y - 1].ISusable = -1;
            Cells[x + 1, y].ISusable = -1;
            Cells[x + 1, y - 1].ISusable = -1;
        }

        public void AddCastle(int what,int x,int y)
        {
            Castles.Add(new Castle(what, x, y));
            Cells[x, y].ISusable = 2;
            Cells[x - 2, y - 2].ISusable = -1;
            Cells[x - 2, y - 1].ISusable = -1;
            Cells[x - 2, y].ISusable = -1;
            Cells[x - 1, y - 2].ISusable = -1;
            Cells[x - 1, y - 1].ISusable = -1;
            Cells[x - 1, y].ISusable = -1;
            Cells[x, y - 2].ISusable = -1;
            Cells[x, y - 1].ISusable = -1;
            Cells[x + 1, y - 2].ISusable = -1;
            Cells[x + 1, y - 1].ISusable = -1;
            Cells[x + 1, y].ISusable = -1;
            Cells[x + 2, y - 2].ISusable = -1;
            Cells[x + 2, y - 1].ISusable = -1;
            Cells[x + 2, y].ISusable = -1;
        }
    }
}
