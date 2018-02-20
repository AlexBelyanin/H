using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            EditorComboBox.Items.AddRange(EditorsSelect);
            Draw();
        }

        public enum State { MainMenu, Options, GameSetup, Game, Battle, MapEditor }

        static BinaryFormatter binFormatter = new BinaryFormatter();
        Map map;
        int mapX=0, mapY=0;
        public State state;
        public State previous_state;
        public GEM ge;
        public TBattleField bf;
        public static System.Object[] EditorCastles = { "Castle" },
            EditorFactories = { "Gold" },
            EditorsResourses = { "Gold", "Cobble", "Wood" },
            EditorsGround = { "Grass", "Dirt" },
            EditorsTools = { "Edit", "Delete" },
            EditorsSelect = { "Castles", "Factories", "Resourses", "Heroes", "Ground", "EditTools" };
        string[] MapsDir;

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
                        Controls.Add(TGUI.GetButton("Map Editor", 810, 177, Editor_bt_Click));

                        //Тестовая кнопка открывает экран, на котором будет происходить перемещение героя по глобальной карте
                        //Такой же экран можно будет увидеть в сражениях- GEM одинаково применяется для отрисовки в обоих случах
                        //При изменение обстановки (Смещении героя или отряда) соответствующий модуль передаёт GEM'у указания
                        //  касательно того, как должно измениться изображение на экране
                        Controls.Add(TGUI.GetButton("Test", 810, 232, Test_bt_Click));
                        break;
                    case (State.Options):
                        Controls.Add(main_pb);
                        main_pb.Image = H.Properties.Resources.Hop;
                        Controls.Add(TGUI.GetButton("Back", 810, 122, Backtomm_bt_Click));
                        break;
                    case (State.MapEditor):
                        Controls.Add(DinamicLayer_pb);
                        map = new Map();
                        map.DrawMap();
                        DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                        DinamicLayer_pb.Image = map.LayerDinamic;
                        DinamicLayer_pb.BringToFront();
                        Controls.Add(EditorComboBox);
                        Controls.Add(EditorListBox);
                        Controls.Add(MapNameTextBox);
                        Controls.Add(TGUI.GetButton("Back", 810, 397, Backtomm_bt_Click));
                        Controls.Add(TGUI.GetButton("Save", 810, 342, SaveEdit_bt_Click));
                        MapNameTextBox.Text = map.name;
                        mapY = 0; mapX = 0;
                        break;
                    case (State.Game):
                        Controls.Add(DinamicLayer_pb);
                        Controls.Add(TGUI.GetButton("Exit", 810, 122, Exit_bt_Click));
                        map.DrawMap();
                        DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                        DinamicLayer_pb.Image = map.LayerDinamic;
                        DinamicLayer_pb.BringToFront();
                        break;
                    case (State.GameSetup):
                        Controls.Add(main_pb);
                        main_pb.Image = H.Properties.Resources.Hsg;
                        Controls.Add(TGUI.GetButton("Back", 810, 287, Backtomm_bt_Click));
                        Controls.Add(TGUI.GetButton("Load", 810, 342, Load_bt_Click));
                        Controls.Add(EditorListBox);
                        MapsDir = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.hmap");
                        foreach(string s in MapsDir)
                        {
                            EditorListBox.Items.Add(Path.GetFileName(s));
                        }
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

        private void Go_bt_Click(object sender, EventArgs e)
        {
            state = State.Game;
            Draw();
        }

        private void Load_bt_Click(object sender, EventArgs e)
        {
            if (EditorListBox.SelectedIndex >= 0)
            {
                FileStream f = File.OpenRead(MapsDir[EditorListBox.SelectedIndex]);
                map = (Map)binFormatter.Deserialize(f);
                f.Close();
                state = State.Game;
                Draw();
            }
        }

        private void SaveEdit_bt_Click(object sender, EventArgs e)
        {
            map.name = MapNameTextBox.Text;
            FileStream f = new FileStream(map.name, FileMode.Create, FileAccess.Write, FileShare.None);
            binFormatter.Serialize(f, map);
            f.Close();
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

        private void Editor_bt_Click(object sender, EventArgs e)
        {
            state = State.MapEditor;
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

            DinamicLayer_pb.Width = 800;
            DinamicLayer_pb.Height = 600;

            SuperDinamicLayer_pb.Width = 800;
            SuperDinamicLayer_pb.Height = 600;

            Left = 0;
            Top = 0;

            ge = new GEM();
            bf = new TBattleField();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (state == State.Game || state == State.MapEditor)
            {
                switch (e.KeyCode)
                {
                    case (Keys.D):
                        if (mapX < map.size * 32 - DinamicLayer_pb.Width + 240)
                        {
                            mapX += 8;
                            map.DrawStatic(mapX, mapY);
                            map.DrawDinamic(mapX, mapY);
                            DinamicLayer_pb.Image = map.LayerDinamic;
                            DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                        }
                        break;
                    case (Keys.A):
                        if (mapX > 0)
                        {
                            mapX -= 8;
                            map.DrawStatic(mapX, mapY);
                            map.DrawDinamic(mapX, mapY);
                            DinamicLayer_pb.Image = map.LayerDinamic;
                            DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                        }
                        break;
                    case (Keys.S):
                        if (mapY < map.size * 32 - DinamicLayer_pb.Height + 240)
                        {
                            mapY += 8;
                            map.DrawStatic(mapX, mapY);
                            map.DrawDinamic(mapX, mapY);
                            DinamicLayer_pb.Image = map.LayerDinamic;
                            DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                        }
                        break;
                    case (Keys.W):
                        if (mapY > 0)
                        {
                            mapY -= 8;
                            map.DrawStatic(mapX, mapY);
                            map.DrawDinamic(mapX, mapY);
                            DinamicLayer_pb.Image = map.LayerDinamic;
                            DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                        }
                        break;
                }
            }
        }

        private void EditorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (EditorComboBox.SelectedIndex)
            {
                case (0):
                    EditorListBox.Items.Clear();
                    EditorListBox.Items.AddRange(EditorCastles);
                    break;
                case (1):
                    EditorListBox.Items.Clear();
                    EditorListBox.Items.AddRange(EditorFactories);
                    break;
                case (2):
                    EditorListBox.Items.Clear();
                    EditorListBox.Items.AddRange(EditorsResourses);
                    break;
                case (3):
                    EditorListBox.Items.Clear();
                    break;
                case (4):
                    EditorListBox.Items.Clear();
                    EditorListBox.Items.AddRange(EditorsGround);
                    break;
                case (5):
                    EditorListBox.Items.Clear();
                    EditorListBox.Items.AddRange(EditorsTools);
                    break;
                default:
                    EditorListBox.Items.Clear();
                    break;
            }
        }

        private void DinamicLayer_MouseClick(object sender, MouseEventArgs e)
        {
            if (state == State.Game)
            {
                if (e.X > 128 - mapX && e.Y > 128 - mapY && e.X < map.size * 32 + 128 - mapX && e.Y < map.size * 32 + 128 - mapY)
                {
                    if (map.Cells[(e.X + mapX) / 32 - 4, (e.Y + mapY) / 32 - 4].ISusable == 0)
                    {
                        map.Resourses.Add(new Resource(0, 10, (e.X + mapX) / 32 - 4, (e.Y + mapY) / 32 - 4));
                        map.DrawDinamic(mapX, mapY);
                        DinamicLayer_pb.Image = map.LayerDinamic;
                    }
                }
            }
            if(state == State.MapEditor)
            {
                if (e.X > 128 - mapX && e.Y > 128 - mapY && e.X < map.size * 32 + 128 - mapX && e.Y < map.size * 32 + 128 - mapY)
                {
                    int X = (e.X + mapX) / 32 - 4, Y = (e.Y + mapY) / 32 - 4;
                    if (map.Cells[X, Y].ISusable == 0)
                    {
                        switch (EditorComboBox.SelectedIndex)
                        {
                            case (0):
                                if (X - 2 > -1 && X + 2 < map.size && Y - 2 > -1)
                                    if (map.Cells[X - 2, Y - 2].ISusable == 0 && map.Cells[X - 2, Y - 1].ISusable == 0 && map.Cells[X - 2, Y].ISusable == 0 && map.Cells[X - 1, Y - 2].ISusable == 0 && map.Cells[X - 1, Y - 1].ISusable == 0 && map.Cells[X - 1, Y].ISusable == 0 && map.Cells[X, Y - 2].ISusable == 0 && map.Cells[X, Y - 1].ISusable == 0 && map.Cells[X + 1, Y - 2].ISusable == 0 && map.Cells[X + 1, Y - 1].ISusable == 0 && map.Cells[X + 1, Y].ISusable == 0 && map.Cells[X + 2, Y - 2].ISusable == 0 && map.Cells[X + 2, Y - 1].ISusable == 0 && map.Cells[X + 2, Y].ISusable == 0)
                                    {
                                        map.AddCastle(EditorListBox.SelectedIndex, X, Y);
                                    }
                                break;
                            case (1):
                                if (X - 1 > -1 && X + 1 < map.size && Y - 1 > -1)
                                    if (map.Cells[X - 1, Y - 1].ISusable == 0 && map.Cells[X - 1, Y].ISusable == 0 && map.Cells[X, Y - 1].ISusable == 0 && map.Cells[X + 1, Y - 1].ISusable == 0 && map.Cells[X + 1, Y].ISusable == 0)
                                    {
                                        map.AddFactory(EditorListBox.SelectedIndex, X, Y);
                                    }
                                break;
                            case (2):
                                map.Resourses.Add(new Resource(EditorListBox.SelectedIndex, 0, X, Y));
                                break;
                            case (3):
                                break;
                            case (4):
                                switch (EditorListBox.SelectedIndex)
                                {
                                    case (0):
                                        map.Cells[X, Y].Ground = new Bitmap(H.Properties.Resources.H_Cell_Grass1);
                                        break;
                                    case (1):
                                        map.Cells[X, Y].Ground = new Bitmap(H.Properties.Resources.H_Cell_Dirt);
                                        break;
                                }
                                break;
                            case (5):
                                break;
                            default:
                                break;
                        }
                        map.DrawStatic(mapX, mapY);
                        map.DrawDinamic(mapX, mapY);
                        DinamicLayer_pb.Image = map.LayerDinamic;
                        DinamicLayer_pb.BackgroundImage = map.LayerStatic;
                    }
                }
            }
        }


    }
}