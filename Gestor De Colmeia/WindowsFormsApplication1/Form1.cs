// ***********************************************************************
// Assembly         : WindowsFormsApplication1
// Author           : Utilizador
// Created          : 05-25-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="Form1.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

/// <summary>
/// The WindowsFormsApplication1 namespace.
/// </summary>
namespace WindowsFormsApplication1
{
	/// <summary>
	/// Class Multinacional.
	/// </summary>
	public partial class Multinacional : Form
	{
		//inicializzar
		/// <summary>
		/// Initializes a new instance of the <see cref="Multinacional"/> class.
		/// </summary>
		public Multinacional()
		{					  
			InitializeComponent();
		}

		//cria empresa
		/// <summary>
		/// Handles the Click event of the button1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button1_Click(object sender, EventArgs e)
		{
			Objecto.FichaTecnicaEmpresa empresa1 = new Objecto.FichaTecnicaEmpresa();

			//Validar os dados	
			if (RegrasNegocio.Regras.MandaParaForaEmpresa("BarcelosMel", "Barcelos", "Aldão", 00000000001, "Rua Ipca", "Mel", out empresa1))
			{
				if (RegrasNegocio.Regras.InsereEmpresa(RegrasNegocio.Regras.RecebeFichaCriaObjectoEmpresa(empresa1)))		
					toolStripStatusLabel1.Text = "Criou uma empresa";
				else
					toolStripStatusLabel1.Text = "Erro";
			}
		}

		//sair
		/// <summary>
		/// Handles the Click event of the button17 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button17_Click(object sender, EventArgs e)
		{										  
			this.Close();
		}

		//elimina empresa
		/// <summary>
		/// Handles the Click event of the button2 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button2_Click(object sender, EventArgs e)
		{
			Objecto.FichaTecnicaEmpresa empresa1 = new Objecto.FichaTecnicaEmpresa();

			//Validar os dados	
			if (RegrasNegocio.Regras.MandaParaForaEmpresa("BarcelosMel", "Barcelos", "Aldão", 00000000001, "Rua Ipca", "Mel", out empresa1))
			{
				if (RegrasNegocio.Regras.EliminarEmpresa(RegrasNegocio.Regras.RecebeFichaCriaObjectoEmpresa(empresa1)))
					toolStripStatusLabel1.Text = "Eliminou uma empresa";
				else
					toolStripStatusLabel1.Text = "Empresa não existente";
			}

		}

		//quantas empresas
		/// <summary>
		/// Handles the Click event of the button3 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button3_Click(object sender, EventArgs e)
		{			
			textBox1.Text = RegrasNegocio.Regras.HowMuchEmpresa().ToString();	
		}

		/// <summary>
		/// Handles the Click event of the button4 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button4_Click(object sender, EventArgs e)
		{
			List<string> lista = new List<string>();

			if (RegrasNegocio.Regras.SeeAllEmpresa(ref lista))
			{
				Form2 novo = new Form2();

				novo.Lista(lista);
				novo.ShowDialog();



				novo.Close();
			}

		}
	}
}
