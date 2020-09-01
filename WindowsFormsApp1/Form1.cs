using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Board Board = new Board();
        List<List<ComboBox>> comboBoxes2DList = new List<List<ComboBox>>();
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Board.Solve();
            DrawSolvedBoard();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Solve";
            button2.Text = "Select .SDK file";
            Draw();

        }
        private void DrawSolvedBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    comboBoxes2DList[i][j].Items.Clear();
                    comboBoxes2DList[i][j].Items.Add(Board.board[i, j]);
                    comboBoxes2DList[i][j].Text = Board.board[i, j].ToString();

                }

            }
        }

        private void Draw()
        {

            for (int i = 0; i < 9; i++)
            {
                List<ComboBox> comboBoxes = new List<ComboBox>();
                comboBoxes2DList.Add(comboBoxes);
                for (int j = 0; j < 9; j++)
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.Location = new Point(j * 30, i * 30);
                    if (Board.board[i, j] == 0)
                    {
                        string[] data = Board.ComboBoxData(i, j);
                        comboBox.Items.AddRange(data);
                    }
                    else
                        comboBox.Items.Add(Board.board[i, j]);
                    comboBox.Width = 30;
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Text = Board.board[i, j].ToString();
                    comboBoxes2DList[i].Add(comboBox);
                    Controls.Add(comboBox);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string address = openFileDialog1.FileName;

                string[] Lines = File.ReadAllLines(address);
                string[] Puzzle = new string[9];
                int i = 0;
             
                while (i < Lines.Length)
                {
                    if (Lines[i] == "[Puzzle]")
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            richTextBox1.Text += Lines[i + j + 1].Replace('.', '0') + "\n";
                            Puzzle[j] = (Lines[i + j + 1].Replace('.', '0'));
                           
                        }
                        break;
                    }
                    i++;
                }
                for (int a = 0; a < 9; a++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Board.board[a, j] = Convert.ToInt32( Puzzle[a][j]-48);
                    }
                }
                DrawSolvedBoard();
            }

        }
    }
}
