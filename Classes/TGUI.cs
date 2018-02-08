using System;
using System.Drawing;
using System.Windows.Forms;

namespace H.Classes
{
    class TGUI
    {
        //Набор методов для автоматизации создания элементов интерфейса

        static public void SetButton(ref Button inp, string name, int x, int y, EventHandler on_click)
        {
            inp.Location = new Point(x, y);
            inp.Width = 161;
            inp.Height = 50;
            inp.Font = new Font("Segoe Print", 14);
            inp.Text = name;
            inp.Click += on_click;
        }

        static public Button GetButton(string name, int x, int y, EventHandler on_click)
        {
            Button btn = new Button();
            SetButton(ref (btn), name, x, y, on_click);
            return btn;
        }
    }
}
