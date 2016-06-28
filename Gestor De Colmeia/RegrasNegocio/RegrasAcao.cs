// ***********************************************************************
// Assembly         : RegrasNegocio
// Author           : Utilizador
// Created          : 05-27-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="RegrasAcao.cs" company="">
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
	/// Class RegrasAcao.
	/// </summary>
	class RegrasAcao
	{
		/// <summary>
		/// Validar a acao.
		/// </summary>
		/// <param name="numeroApicultor">The numero apicultor.</param>
		/// <param name="data">The data.</param>
		/// <param name="acontecimento">The acontecimento.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool ValidaAcao(int numeroApicultor, DateTime data, string acontecimento, int numeroApiario)
		{
			if (numeroApicultor >= 0 &&
				data <= DateTime.Now &&
				acontecimento != string.Empty &&
				numeroApiario >= 0)
				return true;

			return false;
		}

		/// <summary>
		/// Crias the acao.
		/// </summary>
		/// <param name="numeroApicultor">The numero apicultor.</param>
		/// <param name="data">The data.</param>
		/// <param name="acontecimento">The acontecimento.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="a">Instaciar uma accao. e mantela nula</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool MandaParaForaAcao(int numeroApicultor, DateTime data, string acontecimento, int numeroApiario, out Acao a)
		{
			if (!ValidaAcao(numeroApicultor, data, acontecimento, numeroApiario))
			{
				a = null;
				return false;
			}

			else
			{
				a = new Acao(numeroApicultor, data, acontecimento, numeroApiario);
				return true;
			}

		}

		/// <summary>
		/// Inseres the acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool InsereAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
		{
			try
			{
				if (Empresa.Colmeia.Intervention(e, ap, a, c, ac))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Eliminars the acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool EliminarAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
		{
			try
			{
				if (Empresa.Colmeia.DipensesAcao(e, ap, a, c, ac))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Searches the acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SearchAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
		{
			try
			{
				if (Empresa.Colmeia.SearchAcao(e, ap, a, c, ac))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sorts the acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SortAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				if (Empresa.Colmeia.SortAcoes(e, ap, a, c))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Hows the much acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				return Empresa.Colmeia.HowMuchAcoes(e, ap, a, c);
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sees all acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SeeAllAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, ref List<Objecto.Acao> ac)
		{
			try
			{
				if (Empresa.Colmeia.SeeAll(e, ap, a, c, ref ac))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}



	}
}
