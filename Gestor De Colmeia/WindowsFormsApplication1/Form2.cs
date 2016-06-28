using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public bool Lista(List<string> lista)
		{
			this.dataGridView1.ClearSelection();
			int l = 0;
			int i = 0;
			int k=0;	 

			string  aux = string.Empty;
			this.dataGridView1.RowHeadersVisible = false;

			foreach (string value in lista)
			{
				for (k = 0; k < 6; k++)
				{				 
					aux = string.Empty;
					while (value[i] != '\n')
					{
						aux += value[i];
						i++;
					}
					i++;

					this.dataGridView1.Rows[l].Cells[k].Value = aux;
				}
				l++;					
            }

			return true;
		}
	}
}
