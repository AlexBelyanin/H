using System;
using System.Windows.Forms;
using System.Drawing;

using H.Classes;

namespace H
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            state = State.MainMenu;
            previous_state = State.Battle;
            Draw();
        }

        public enum State { MainMenu, Options, GameSetup, Game, Battle }

        Map map;
        int mapX=0, mapY=0;
        public State state;
        public State previous_state;
        public GEM ge;

        public void Draw()
        {
            //deleting buttons
            //while(this.Controls.Count>1)
            //    this.Controls.RemoveAt(1);
            if (previous_state != state)
            {
                Controls.Clear();
                previous_state = state;

                switch (state)
                {
                    case (State.MainMenu):
                        Controls.Add(main_pb);
                        main_pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        main_pb.Image = H.Properties.Resources.Hmm;
                        Controls.Add(TGUI.GetButton("Start", 810, 12, Start_bt_Click));
                        Controls.Add(TGUI.GetButton("Options", 810, 67, Options_bt_Click));
                        Controls.Add(TGUI.GetButton("Exit", 810, 122, Exit_bt_Click));

                        //Тестовая кнопка открывает экран, на котором будет происходить перемещение героя по глобальной карте
                        //Такой же экран можно будет увидеть в сражениях- GEM одинаково применяется для отрисовки в обоих случах
                        //При изменение обстановки (Смещении героя или отряда) соответствующий модуль передаёт GEM'у указания
                        //  касательно того, как должно измениться изображение на экране
                        Controls.Add(TGUI.GetButton("Test", 810, 177, Test_bt_Click));
                        break;
                    case (State.Options):
                        Controls.Add(main_pb);
                        main_pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        main_pb.Image = H.Properties.Resources.Hop;
                        Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                        break;
                    case (State.Game):
                        Controls.Add(main_pb);
                        //Controls.Add(DinamicLayer_pb);
                        //Controls.Add(SuperDinamicLayer_pb);
                        main_pb.SizeMode = PictureBoxSizeMode.Normal;
                        Controls.Add(TGUI.GetButton("Exit", 810, 122, Exit_bt_Click));
                        map = new Map();
                        map.Resourses.Add(new Resource(0, 10, 2, 2));
                        map.Resourses.Add(new Resource(1, 10, 3, 4));
                        map.Resourses.Add(new Resource(2, 10, 4, 5));
                        map.DrawMap();
                        main_pb.BackgroundImage = map.LayerStatic;
                        main_pb.Image = map.LayerDinamic;
                        main_pb.BringToFront();
                        //DinamicLayer_pb.Image = map.LayerDinamic;
                        //DinamicLayer_pb.BringToFront();
                        //main_pb.Invalidate();
                        //SuperDinamicLayer_pb.Image = map.LayerSuperDinamic;
                        break;
                    case (State.GameSetup):
                        Controls.Add(main_pb);
                        main_pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        main_pb.Image = H.Properties.Resources.Hsg;
                        Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                        Controls.Add(TGUI.GetButton("GO", 810, 67, Go_bt_Click));
                        break;
                    case (State.Battle):
                        main_pb.Image = null;
                        foreach (GEM.TField field in ge.fields)
                        {
                            Controls.Add(field.pic);
                            Controls.Add(field.backGround_pic);
                            Controls.Add(field.lbl);
                        }
                        Controls.Add(TGUI.GetButton("Back", 100, 700, Backtomm_bt_Click));
                        break;
                }
            }
            main_pb.Invalidate();
        }

        private void Go_bt_Click(object sender, EventArgs e)
        {
            state = State.Game;
            Draw();
        }

        private void Backtomm_bt_Click(object sender, EventArgs e)
        {
            state = State.MainMenu;
            Draw();
        }

        private void Exit_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Options_bt_Click(object sender, EventArgs e)
        {
            state = State.Options;
            Draw();
        }

        private void Start_bt_Click(object sender, EventArgs e)
        {
            state = State.GameSetup;
            Draw();
        }

        private void Test_bt_Click(object sender, EventArgs e)
        {
            state = State.Battle;
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 1000;
            Height = 800;

            main_pb.Width = 800;
            main_pb.Height = 600;
            main_pb.SizeMode = PictureBoxSizeMode.StretchImage;

            DinamicLayer_pb.Width = 600;
            DinamicLayer_pb.Height = 400;

            SuperDinamicLayer_pb.Width = 800;
            SuperDinamicLayer_pb.Height = 600;

            Left = 0;
            Top = 0;

            ge = new GEM();
        }

        private void main_pb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 32 && e.Y > 32)
            {
                map.Resourses.Add(new Resource(0, 10, (e.X + mapX) / 32 - 1, (e.Y + mapY) / 32 - 1));
                map.DrawDinamic(mapX, mapY);
                main_pb.Image = map.LayerDinamic;
            }
        }

        private void main_pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 32 && mapX < map.size * 32 - main_pb.Width + 56)
            {
                mapX += 8;
                map.DrawStatic(mapX, mapY);
                map.DrawDinamic(mapX, mapY);
                main_pb.Image = map.LayerDinamic;
                main_pb.BackgroundImage = map.LayerStatic;
            }
            if (e.X > main_pb.Width - 32 && mapX > 0)
            {
                mapX -= 8;
                map.DrawStatic(mapX, mapY);
                map.DrawDinamic(mapX, mapY);
                main_pb.Image = map.LayerDinamic;
                main_pb.BackgroundImage = map.LayerStatic;
            }
            if (e.Y < 32 && mapX < map.size * 32 - main_pb.Height + 56)
            {
                mapY += 8;
                map.DrawStatic(mapX, mapY);
                map.DrawDinamic(mapX, mapY);
                main_pb.Image = map.LayerDinamic;
                main_pb.BackgroundImage = map.LayerStatic;
            }
            if (e.X > main_pb.Height - 32 && mapX > 0)
            {
                mapY -= 8;
                map.DrawStatic(mapX, mapY);
                map.DrawDinamic(mapX, mapY);
                main_pb.Image = map.LayerDinamic;
                main_pb.BackgroundImage = map.LayerStatic;
            }
        }
    }
}