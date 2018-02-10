using System;
using System.Windows.Forms;

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

        public State state;
        public State previous_state;
        public GEM ge;
        public TBattleField bf;

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
                        main_pb.Image = H.Properties.Resources.Hop;
                        Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                        break;
                    case (State.Game):
                        break;
                    case (State.GameSetup):
                        Controls.Add(main_pb);
                        main_pb.Image = H.Properties.Resources.Hsg;
                        Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                        break;
                    case (State.Battle):
                        main_pb.Image = null;
                        bf.Ini(new TArmy(), new TArmy());
                        for(int x = 0; x < CL.Map_Width; x++)
                        {
                            for (int y = 0; y < CL.Map_Height; y++)
                            {
                                Controls.Add(ge.fields[x, y].pic);
                                Controls.Add(ge.fields[x, y].backGround_pic);
                                Controls.Add(ge.fields[x, y].lbl);
                                ge.fields[x, y].lbl.Text = "13";
                                ge.fields[x, y].lbl.BringToFront();
                            }
                        }
                        ge.DrawBattleField(ref bf);
                        Controls.Add(TGUI.GetButton("Back", 100, 700, Backtomm_bt_Click));
                        break;
                }
            }
            else
            {
                switch(state)
                {
                    case (State.Battle):

                        break;
                }
            }
            main_pb.Invalidate();
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

            Left = 0;
            Top = 0;

            ge = new GEM();
            bf = new TBattleField();
        }
    }
}