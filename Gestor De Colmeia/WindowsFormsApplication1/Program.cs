// ***********************************************************************
// Assembly         : WindowsFormsApplication1
// Author           : Utilizador
// Created          : 05-25-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// The WindowsFormsApplication1 namespace.
/// </summary>
namespace WindowsFormsApplication1
{				   /*   Duvidas no metodo SEE ALL*/
				   /// <summary>
				   /// Class Program.
				   /// </summary>
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Multinacional());
		}
	}
}
