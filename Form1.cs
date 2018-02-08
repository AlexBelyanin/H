using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public enum State
        {
            MainMenu,
            Options,
            GameSetup,
            Game,
            Battle
        }

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

                    Button start_bt = new Button();
                    start_bt.Location = new Point(488, 12);
                    start_bt.Width = 161;
                    start_bt.Height = 50;
                    start_bt.Font = new Font("Segoe Print", 14);
                    start_bt.Text = "Start";
                    this.Controls.Add(start_bt);
                    start_bt.Click += Start_bt_Click;

                    Button options_bt = new Button();
                    options_bt.Location = new Point(488, 67);
                    options_bt.Width = 161;
                    options_bt.Height = 50;
                    options_bt.Font = new Font("Segoe Print", 14);
                    options_bt.Text = "Options";
                    this.Controls.Add(options_bt);
                    options_bt.Click += Options_bt_Click;

                    Button exit_bt = new Button();
                    exit_bt.Location = new Point(488, 122);
                    exit_bt.Width = 161;
                    exit_bt.Height = 50;
                    exit_bt.Font = new Font("Segoe Print", 14);
                    exit_bt.Text = "Exit";
                    this.Controls.Add(exit_bt);
                    exit_bt.Click += Exit_bt_Click;

                    break;
                case (State.Options):
                    main_pb.Image = H.Properties.Resources.Hop;

                    Button backtomm_bt = new Button();
                    backtomm_bt.Location = new Point(488, 122);
                    backtomm_bt.Width = 161;
                    backtomm_bt.Height = 50;
                    backtomm_bt.Font = new Font("Segoe Print", 14);
                    backtomm_bt.Text = "Back";
                    this.Controls.Add(backtomm_bt);
                    backtomm_bt.Click += Backtomm_bt_Click;

                    break;
                case (State.Game):
                    break;
                case (State.GameSetup):
                    main_pb.Image = H.Properties.Resources.Hsg;

                    Button backtomm1_bt = new Button();
                    backtomm1_bt.Location = new Point(488, 122);
                    backtomm1_bt.Width = 161;
                    backtomm1_bt.Height = 50;
                    backtomm1_bt.Font = new Font("Segoe Print", 14);
                    backtomm1_bt.Text = "Back";
                    this.Controls.Add(backtomm1_bt);
                    backtomm1_bt.Click += Backtomm_bt_Click;

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
    }
}
