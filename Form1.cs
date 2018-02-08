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
            Draw();
        }

        public enum State { MainMenu, Options, GameSetup, Game, Battle }

        public State state;

        public void Draw()
        {
            //deleting buttons
            while(this.Controls.Count>1)
                this.Controls.RemoveAt(1);

            switch (state)
            {
                case(State.MainMenu):
                    main_pb.Image = H.Properties.Resources.Hmm;
                    Controls.Add(TGUI.GetButton("Start", 810, 12, Start_bt_Click));
                    Controls.Add(TGUI.GetButton("Options", 810, 67, Options_bt_Click));
                    Controls.Add(TGUI.GetButton("Exit", 810, 122, Exit_bt_Click));
                    break;
                case (State.Options):
                    main_pb.Image = H.Properties.Resources.Hop;
                    Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                    break;
                case (State.Game):
                    break;
                case (State.GameSetup):
                    main_pb.Image = H.Properties.Resources.Hsg;
                    Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                    break;
                case (State.Battle):
                    break;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 1000;
            Height = 800;

            main_pb.Width = 800;
            main_pb.Height = 600;
            main_pb.SizeMode = PictureBoxSizeMode.StretchImage;

            Left = 0;
            Top = 0;
        }
    }
}
