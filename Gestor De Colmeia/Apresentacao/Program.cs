// ***********************************************************************
// Assembly         : Apresentacao
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-25-2015
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * Made By : Joaquim Cardoso
 * Day : 16/04/2015
 * For : LP
 * Language : c#
 * Descricion : TP1
 * Number : 10201
 * Contact : joaquimcardoso12@hotmail.com
 */

using System;


/// <summary>
/// The Apresentacao namespace.
/// </summary>
namespace Apresentacao
{
	/// <summary>
	/// Class Program.
	/// </summary>
	class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		static void Main(string[] args)
		{

			Objecto.FichaTecnicaEmpresa empresa1 = new Objecto.FichaTecnicaEmpresa();

			//Validar os dados


			if (RegrasNegocio.Regras.MandaParaForaEmpresa("BarcelosMel", "Barcelos", "Aldão", 00000000001, "Rua Ipca", "Mel", out empresa1))
			{
				if (RegrasNegocio.Regras.InsereEmpresa(RegrasNegocio.Regras.RecebeFichaCriaObjectoEmpresa(empresa1)))
					Console.WriteLine("Criou uma empresa.");
			}
			Console.ReadKey();
		}
	}
}
