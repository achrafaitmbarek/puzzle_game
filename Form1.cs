using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle_game_2
{
	public partial class puzzle : Form
	{

		int i;
		static private int[,] buttons = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
		private int ar, ac;
		private int Number_mouvement = 0;
		public puzzle()
		{
			InitializeComponent();
		}
		public void r_andom()
		{
			ar = 2;
			ac = 2;
			btnBlank.Location = new Point(200, 200);
			btnBlank.Size = new Size(90, 90);
			lblNumber_mouvement.Font = new Font("bigger", 19);
			lblNumber_mouvement.Size = new Size(350, 40);
			//lblNumber_mouvement.Location = new Point(0, 1150);
			this.MouseDown += new MouseEventHandler(Click_win);
			this.KeyDown += new KeyEventHandler(KeyDown_win);
			PlaceRandom();
		}


		private void puzzle_Load(object sender, EventArgs e)
		{
			r_andom();
			_Stop.Enabled=false;
			New_try.Enabled=false;

		}
		private void Click_win(Object sender, MouseEventArgs e)
		{
			Random rnd = new Random();

			MessageBox.Show(rnd.Next(8).ToString());
			MessageBox.Show("press out of the area ");
		}


		private void KeyDown_win(Object sender, KeyEventArgs k)
		{
			int help;
			switch (k.KeyCode)
			{
	case Keys.Down:
					if (ar > 0)
					{
						help = buttons[ar, ac];
						buttons[ar, ac] = buttons[ar - 1, ac];
						buttons[ar - 1, ac] = help;
						Swap(buttons[ar, ac], help);
						ar--;
						Number_mouvement++;
					}
					break;

	case Keys.Left:
					if (ac < 2)
					{
						help = buttons[ar, ac];
						buttons[ar, ac] = buttons[ar, ac + 1];
						buttons[ar, ac + 1] = help;
						Swap(buttons[ar, ac], help);
						ac++;
						Number_mouvement++;
					}
					break;
	case Keys.Up:


					if (ar < 2)
					{
						help = buttons[ar, ac];
						buttons[ar, ac] = buttons[ar + 1, ac];
						buttons[ar + 1, ac] = help;
						Swap(buttons[ar, ac], help);
						ar++;
						Number_mouvement++;
					}

					break;
	case Keys.Right:
					if (ac > 0)
					{	help = buttons[ar, ac];
						buttons[ar, ac] = buttons[ar, ac - 1];
						buttons[ar, ac - 1] = help;
						Swap(buttons[ar, ac], help);
						ac--;
						Number_mouvement++;}
					break;

			}
			lblNumber_mouvement.Text = "Number of mouvement  " + Number_mouvement.ToString();
			Boolean same = true;
			String empty = "";
			for (int ctr = 1, i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++, ctr++)
				{
					if (buttons[i, j] != ctr)
					{
						same = false;
						break;
					}
					empty = empty + "\t" + buttons[i, j];

				}
				empty = empty + "\n";
			}

			if (same && i<=300)
			{
				timer1.Stop();
				MessageBox.Show("Great ! you've done in  " + i + " and Number_mouvement" + Number_mouvement);
			}
			else{
				if (!same && i>300)
	{
					MessageBox.Show("you lose");
					New_try.Enabled = true;
					
					i=0;
					
	}
			}



		}

		private void Swap(int rotat_nm, int blank)
		{
			Point help;


			switch (rotat_nm)
			{
				case 1:
					help = btn1.Location;
					btn1.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 2:
					help = btn2.Location;
					btn2.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 3:
					help = btn3.Location;
					btn3.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 4:
					help = btn4.Location;
					btn4.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 5:
					help = btn5.Location;
					btn5.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 6:
					help = btn6.Location;
					btn6.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 7:
					help = btn7.Location;
					btn7.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
				case 8:
					help = btn8.Location;
					btn8.Location = btnBlank.Location;
					btnBlank.Location = help;
					break;
			}

		}

		private void PlaceRandom()
		{
			int r, c;
			r = 10; c = 10;
			int i = 0;
			ar = 0;
			ac = 0;
			Random rnd = new Random();
			int val;
			while (i < 8)
			{
				val = rnd.Next(9);
				if (if_Exists(val) == true && val > 0)
				{
					buttons[ar, ac] = val;

					switch (val)
					{
						case 1:
							btn1.Location = new Point(c, r);

							break;
						case 2:
							btn2.Location = new Point(c, r);

							break;
						case 3:
							btn3.Location = new Point(c, r);

							break;
						case 4:
							btn4.Location = new Point(c, r);

							break;
						case 5:
							btn5.Location = new Point(c, r);

							break;
						case 6:
							btn6.Location = new Point(c, r);

							break;
						case 7:
							btn7.Location = new Point(c, r);

							break;
						case 8:
							btn8.Location = new Point(c, r);

							break;


					}
					c += 100;
					ac++;
					if (ac > 2)
					{
						ac = 0;
						ar++;
					}
					if (c > 300)
					{
						c = 10;
						r += 100;
					}
					i++;
				}
				else
					continue;
			}
			btnBlank.Location = new Point(c, r);
			buttons[2, 2] = 9;
			
		}

        private void New_try_Click(object sender, EventArgs e)
        {
			New_try.Enabled = false;
			_Stop.Enabled = true;
		}

        private void _Stop_Click(object sender, EventArgs e)
        {
			New_try.Enabled = true;
			_Stop.Enabled = false;
			
            if (timer1.Enabled)
            {
                timer1.Stop();
                Time_viewer.Text = "00:00";
            }
		}

        private void Time_viewer_Click(object sender, EventArgs e)
        {
			

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			i++;
			Time_viewer.Text = i.ToString() + " Seconds";
        }

        private Boolean if_Exists(int Num)
		{
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
				{

					if (buttons[i, j] == Num)
						return false;
				}

			return true;
		}
	}
}
