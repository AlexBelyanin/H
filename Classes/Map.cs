using System;
using H.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Classes
{
    class Cell
    {
        public bool[] ISvisible;
        public bool IStouchable;
        //0 - no
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
            IStouchable = true;
            ISusable = 0;
            passability = 1;
            Ground = new Bitmap(H.Properties.Resources.H_Cell_Grass1);
        }
    }

    class Map
    {
        public int size;
        public Cell[,] Cells;
        public int turn;
        public Bitmap LayerStatic;
        public Bitmap LayerDinamic;
        public Bitmap LayerSuperDinamic;
        //public List<Castle> Castles;
        //public List<Factory> Factories;
        public List<THero> Heroes;
        public List<Resource> Resourses;

        //Graphics g;

        public Map()
        {
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

            DrawMap();
            //Bitmap bitmap = new Bitmap(size * 32 + 64, size * 32 + 64);
            //g = Graphics.FromImage(bitmap);
        }

        public void DrawMap()
        {
            DrawDinamic(0,0);
            DrawStatic(0,0);
            //LayerStatic = new Bitmap(H.Properties.Resources.H_Cell_Black, size * 32 + 64, size * 32 + 64);
            //LayerDinamic = new Bitmap(H.Properties.Resources.H_Cell_White, size * 32 + 64, size * 32 + 64);
            //LayerDinamic.MakeTransparent(LayerDinamic.GetPixel(1, 1));
            //Graphics gS = Graphics.FromImage(LayerStatic), gD = Graphics.FromImage(LayerDinamic);
            //for (int i = 0; i < size + 2; i++)
            //    for (int j = 0; j < size + 2; j++)
            //    {
            //        if (i == 0 || j == 0 || i == size + 1 || j == size + 1) gS.DrawImage(H.Properties.Resources.H_Cell_Black, 32 * i, 32 * j);
            //        else
            //            gS.DrawImage(Cells[i - 1, j - 1].Ground, 32 * i, 32 * j);
            //    }
            //foreach(Resource res in Resourses)
            //{
            //    gD.DrawImage(res.Image, res.x * 32 + 32, res.y * 32 + 32);
            //    Cells[res.x, res.y].ISusable = 1;
            //}
        }

        public void DrawStatic(int mx, int my)
        {
            LayerStatic = new Bitmap(H.Properties.Resources.H_Cell_Black, size * 32 + 64 - mx, size * 32 + 64 - my);
            Graphics gS = Graphics.FromImage(LayerStatic);
            for (int i = 0; i < size + 2; i++)
                for (int j = 0; j < size + 2; j++)
                {
                    if (i == 0 || j == 0 || i == size + 1 || j == size + 1) gS.DrawImage(H.Properties.Resources.H_Cell_Black, 32 * i - mx, 32 * j - my);
                    else
                        gS.DrawImage(Cells[i - 1, j - 1].Ground, 32 * i - mx, 32 * j - my);
                }
        }

        public void DrawDinamic(int mx,int my)
        {
            LayerDinamic = new Bitmap(H.Properties.Resources.H_Cell_White, size * 32 + 64-mx, size * 32 + 64-my);
            LayerDinamic.MakeTransparent(LayerDinamic.GetPixel(1, 1));
            Graphics gD = Graphics.FromImage(LayerDinamic);
            foreach (Resource res in Resourses)
            {
                gD.DrawImage(res.Image, res.x * 32 + 32-mx, res.y * 32 + 32-my);
                Cells[res.x, res.y].ISusable = 1;
            }
        }
    }
}
