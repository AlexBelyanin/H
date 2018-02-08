using System;
using System.Drawing;
using System.Windows.Forms;

namespace H.Classes
{
    class TGUI
    {
        //Набор методов для автоматизации создания элементов интерфейса

        static private void SetButton(ref Button inp, string name, int w, int h, int x, int y, EventHandler on_click)
        {
            inp.Location = new Point(x, y);
            inp.Width = w;
            inp.Height = h;
            inp.Font = new Font("Segoe Print", 14);
            inp.Text = name;
            inp.Click += on_click;
        }

        static private void SetButton(ref Button inp, string name, int x, int y, EventHandler on_click)
        {
            SetButton(ref inp, name, 161, 50, x, y, on_click);
        }

        /// <summary>
        /// Возвращает кнопку с указанными параметрами
        /// </summary>
        /// <param name="name">Текст на кнопке</param>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        /// <param name="on_click">Обработчик нажатия</param>
        /// <returns></returns>
        static public Button GetButton(string name, int x, int y, EventHandler on_click)
        {
            Button btn = new Button();
            SetButton(ref (btn), name, x, y, on_click);
            return btn;
        }
    }
}
