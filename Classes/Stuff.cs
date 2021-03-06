﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Classes
{
    [Serializable]
    class Castle
    {
        public Bitmap Image;
        public int ISwhat;
        public int x, y;

        public Castle()
        {
            ISwhat = 0;
            Image = new Bitmap(H.Properties.Resources.H_Factory_Gold);
            Image.MakeTransparent(Image.GetPixel(1, 1));
            x = 0;
            y = 0;
        }

        public Castle(int what, int X, int Y)
        {
            x = X;
            y = Y;
            if (what < 1) ISwhat = what;
            else ISwhat = 0;
            switch (what)
            {
                case (0):
                    Image = new Bitmap(H.Properties.Resources.H_Castle_Castle);
                    break;
            }
            Image.MakeTransparent(Image.GetPixel(1, 1));
        }

    }

    [Serializable]
    class Factory
    {
        public Bitmap Image;
        public int ISwhat;
        public int x, y;

        public Factory()
        {
            ISwhat = 0;
            Image = new Bitmap(H.Properties.Resources.H_Factory_Gold);
            Image.MakeTransparent(Image.GetPixel(1, 1));
            x = 0;
            y = 0;
        }

        public Factory(int what, int X, int Y)
        {
            x = X;
            y = Y;
            if (what < 1) ISwhat = what;
            else ISwhat = 0;
            switch (what)
            {
                case (0):
                    Image = new Bitmap(H.Properties.Resources.H_Factory_Gold);
                    break;
            }
            Image.MakeTransparent(Image.GetPixel(1, 1));
        }
    }

    [Serializable]
    class Resource
    {
        public Bitmap Image;
        public int ISwhat;
        public int amount;
        public int x, y;

        public Resource()
        {
            Image = new Bitmap(H.Properties.Resources.H_Resource_Gold);
            ISwhat = 0;
            amount = 1;
            x = 0;
            y = 0;
            Image.MakeTransparent(Image.GetPixel(1, 1));
        }

        public Resource(int what,int number,int X,int Y)
        {
            x = X;
            y = Y;
            if (what < 3) ISwhat = what;
            else ISwhat = 0;
            amount = number;
            switch (what)
            {
                case(0):
                    Image = new Bitmap(H.Properties.Resources.H_Resource_Gold);
                    break;
                case (1):
                    Image = new Bitmap(H.Properties.Resources.H_Resource_Stone);
                    break;
                case (2):
                    Image = new Bitmap(H.Properties.Resources.H_Resource_Wood);
                    break;
            }
            Image.MakeTransparent(Image.GetPixel(1, 1));
        }

    }
}
