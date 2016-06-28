// ***********************************************************************
// Assembly         : RegrasNegocio
// Author           : Utilizador
// Created          : 05-27-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="RegrasColmeia.cs" company="">
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
using System.Collections.Generic;


//Externas
using Objecto; //BO

/// <summary>
/// The RegrasNegocio namespace.
/// </summary>
namespace RegrasNegocio
{
	/// <summary>
	/// Class RegrasColmeia.
	/// </summary>
	class RegrasColmeia
    {
		/// <summary>
		/// Validar a acao.
		/// </summary>
		/// <param name="numeroColmeia">The numero colmeia.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="dataConstrucaoo">The data construcaoo.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool ValidaColmeia(int numeroColmeia, int numeroApiario, DateTime dataConstrucaoo)
		{
			if (numeroColmeia >= 0 &&
				dataConstrucaoo <= DateTime.Now &&
				numeroApiario >= 0)
				return true;

			return false;
		}


		/// <summary>
		/// Crias the acao.
		/// </summary>
		/// <param name="numeroColmeia">The numero colmeia.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="dataConstrucao">The data construcao.</param>
		/// <param name="a">Instaciar uma accao. e mantela nula</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool MandaParaForaColmeia(int numeroColmeia, int numeroApiario, DateTime dataConstrucao, out FichaTecnicaColmeia a)
		{
			if (!ValidaColmeia(numeroColmeia, numeroApiario, dataConstrucao))
			{
				a = null;
				return false;
			}

			else
			{
				a = new FichaTecnicaColmeia(numeroColmeia, numeroApiario, dataConstrucao);
				return true;
			}

		}


		/// <summary>
		/// Recebes the ficha cria objecto colmeia.
		/// </summary>
		/// <param name="fe">The fe.</param>
		/// <returns>Objecto.FichaTecnicaColmeia.</returns>
		public static Objecto.FichaTecnicaColmeia RecebeFichaCriaObjectoColmeia(FichaTecnicaColmeia fe)
		{
			if (fe != null)
			{
				return (fe);
			}

			return null;
		}


		/// <summary>
		/// Inseres the colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool InsereColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				if (Empresa.Apiario.AddColmeias(e, ap, a, c))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Eliminars the colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool EliminarColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				if (Empresa.Apiario.DipensesColmeia(e, ap, a, c))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Searches the colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SearchColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				if (Empresa.Apiario.SearchColmeia(e, ap, a, c))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sorts the colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SortColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			try
			{
				if (Empresa.Apiario.SortColmeias(e, ap, a))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Hows the much colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			try
			{
				return Empresa.Apiario.HowMuchColmeias(e, ap, a);
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sees all colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SeeAllColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, ref List<string> c)
		{
			try
			{
				if (Empresa.Apiario.SeeAll(e, ap, a, ref c))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Limpa
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LimpaAccoesColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				Empresa.Colmeia.LimpaAccoes(e, ap, a, c);

				return true;
			}
			catch (System.Exception)
			{
				throw;
			}
		}

	}
}
