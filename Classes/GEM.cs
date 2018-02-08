using System.Drawing;
using System.Windows.Forms;

namespace H.Classes
{
    public class GEM
    {
        //Графический модуль для отрисовки карты в боевом и глобальном режиме

        public class TField
        {
            public TField()
            {
                pic.Width = CL.Field_Width;
                pic.Height = CL.Field_Height;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                backGround_pic.Width = CL.Field_Width + 10;
                backGround_pic.Height = CL.Field_Height + 10;
                backGround_pic.SizeMode = PictureBoxSizeMode.StretchImage;

                lbl.Width = 35;
                lbl.Height = 18;
                lbl.Text = "150";
                lbl.Visible = false;
            }
            public PictureBox pic = new PictureBox();
            public PictureBox backGround_pic = new PictureBox();
            public Label lbl = new Label();
        }

        public TField[,] fields;
        public Image[,,] anim;

        public GEM()
        {
            anim = TGUI.ExtractUnitImages();
            Image bp = Properties.Resources.BlackPixel;

            fields = new TField[CL.Map_Width, CL.Map_Height];

            for (int x = 0; x < CL.Map_Width; x++)
            {
                for (int y = 0; y < CL.Map_Height; y++)
                {
                    fields[x, y] = new TField();
                    fields[x, y].pic.Left = 20 + x * (CL.Field_Width + 5);
                    fields[x, y].pic.Top = 20 + y * (CL.Field_Height + 5);
                    fields[x, y].backGround_pic.Left = fields[x, y].pic.Left - 5;
                    fields[x, y].backGround_pic.Top = fields[x, y].pic.Top - 5;

                    fields[x, y].lbl.Left = fields[x, y].pic.Left + CL.Field_Width - 50;
                    fields[x, y].lbl.Top = fields[x, y].pic.Top + CL.Field_Height - 30;

                    fields[x, y].pic.Image = anim[x % 5, y % 5, 0];
                    fields[x, y].backGround_pic.Image = bp;
                }
            }
        }

        public void SwapTiles(int x1, int y1, int x2, int y2)
        {
            //fields[x1, y1].pic.Image = null;
            Image field1_img = fields[x1, y1].pic.Image;
            fields[x1, y1].pic.Image = fields[x2, y2].pic.Image;
            fields[x2, y2].pic.Image = field1_img;

            Image field1_backImg = fields[x1, y1].backGround_pic.Image;
            fields[x1, y1].backGround_pic.Image = fields[x2, y2].backGround_pic.Image;
            fields[x2, y2].backGround_pic.Image = field1_backImg;

            string field1_label = fields[x1, y1].lbl.Text;
            fields[x1, y1].lbl.Text = fields[x2, y2].lbl.Text;
            fields[x2, y2].lbl.Text = field1_label;
        }
    }
}