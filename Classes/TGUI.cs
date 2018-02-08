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

        /// <summary>
        /// Извлекает из screenshot'ов анимацию для юнитов
        /// Также является причиной длительной загрузки
        /// </summary>
        /// <returns></returns>
        static public Image[,,] ExtractUnitImages()
        {
            int x = 0;
            int y = 0;
            Image[,,] res = new Image[5, 5, 4];

            Bitmap cur_anim = Properties.Resources.Animation_0;

            for (int a = 0; a < 4; a++)
            {
                for (int cx = 0; cx < 5; cx++)
                {
                    for (int cy = 0; cy < 5; cy++)
                    {
                        switch (cy + 1)
                        {
                            case 1: y = 205; break;
                            case 2: y = 338; break;
                            case 3: y = 476; break;
                            case 4: y = 612; break;
                            case 5: y = 745; break;
                        }
                        switch (cx + 1)
                        {
                            case 1: x = 65; break;
                            case 2: x = 263; break;
                            case 3: x = 452; break;
                            case 4: x = 635; break;
                            case 5: x = 1022; break;
                        }
                        Rectangle pos = new Rectangle(x, y, CL.Image_Width, CL.Image_Height);

                        res[cx, cy, a] = (cur_anim.Clone(pos, cur_anim.PixelFormat));
                        if (x == 1022)
                        {
                            res[cx, cy, a].RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                    }
                }
                switch (a)
                {
                    case 0: cur_anim = Properties.Resources.Animation_1; break;
                    case 1: cur_anim = Properties.Resources.Animation_2; break;
                    case 2: cur_anim = Properties.Resources.Animation_3; break;
                }
            }
            return res;
        }
    }
}