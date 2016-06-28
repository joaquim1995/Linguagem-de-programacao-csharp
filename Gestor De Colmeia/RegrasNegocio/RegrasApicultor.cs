// ***********************************************************************
// Assembly         : RegrasNegocio
// Author           : Utilizador
// Created          : 05-27-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="RegrasApicultor.cs" company="">
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
using System.IO;

//Externas
using Objecto; //BO
using Empresa;

/// <summary>
/// The RegrasNegocio namespace.
/// </summary>
namespace RegrasNegocio
{
	/// <summary>
	/// Class RegrasApicultor.
	/// </summary>
	class RegrasApicultor
	{
		/// <summary>
		/// Validas the apicultor.
		/// </summary>
		/// <param name="nome">The nome.</param>
		/// <param name="numeroApicultor">The numero apicultor.</param>
		/// <param name="comeco">The comeco.</param>
		/// <param name="associacao">The associacao.</param>
		/// <param name="numeroContacto">The numero contacto.</param>
		/// <param name="foto">The foto.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool ValidaApicultor(string nome, int numeroApicultor, DateTime comeco, string associacao, int numeroContacto, FileStream foto)
		{
			if (numeroApicultor >= 0 &&
				comeco <= DateTime.Now &&
				nome != string.Empty &&
				numeroApicultor >= 0 &&
				associacao != string.Empty &&
				numeroContacto >= 0 &&
				foto != null)
				return true;

			return false;
		}


		/// <summary>
		/// Recebes the ficha cria objecto apicultor.
		/// </summary>
		/// <param name="fe">The fe.</param>
		/// <returns>Objecto.FichaTecnicaApicultor.</returns>
		public static Objecto.FichaTecnicaApicultor RecebeFichaCriaObjectoApicultor(FichaTecnicaApicultor fe)
		{
			if (fe != null)
			{
				return (fe);
			}

			return null;
		}


		/// <summary>
		/// Crias the acao.
		/// </summary>
		/// <param name="nome">The nome.</param>
		/// <param name="numeroApicultor">The numero apicultor.</param>
		/// <param name="comeco">The comeco.</param>
		/// <param name="associacao">The associacao.</param>
		/// <param name="numeroContacto">The numero contacto.</param>
		/// <param name="foto">The foto.</param>
		/// <param name="f">The f.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool MandaParaForaApicultor(string nome, int numeroApicultor, DateTime comeco, string associacao, int numeroContacto, FileStream foto, out FichaTecnicaApicultor f)
		{
			if (!ValidaApicultor(nome, numeroApicultor, comeco, associacao, numeroContacto, foto))
			{
				f = null;
				return false;
			}

			else
			{
				f = new FichaTecnicaApicultor(nome, numeroApicultor, comeco, associacao, numeroContacto, foto);
				return true;
			}

		}


		/// <summary>
		/// Inseres the apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool InsereApicultor(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor a)
		{
			try
			{
				if (Empresa.Empresa.AddWorker(e, a))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Eliminars the apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool EliminarApicultor(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
		{
			try
			{
				if (Empresa.Empresa.DipensesWorker(e, ap))
					return true;

				return false;

			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Localizas the apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="lat">The lat.</param>
		/// <param name="lon">The lon.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LocalizaApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, int lat, int lon)
		{
			try
			{
				if (Apicultor.LocalizacaoApiario(e, ap, lat, lon))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Searches the apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SearchApicultor(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor a)
		{
			try
			{
				if (Empresa.Empresa.SearchWorker(e, a))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sorts the apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SortApicultor(Objecto.FichaTecnicaEmpresa e)
		{
			try
			{
				if (Empresa.Empresa.SortWorker(e))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Hows the much apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchApicultor(Objecto.FichaTecnicaEmpresa e)
		{
			try
			{
				return Empresa.Empresa.HowMuchWorker(e);
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sees all apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SeeAllApicultor(Objecto.FichaTecnicaEmpresa e, ref List<string> a)
		{
			try
			{
				if (Empresa.Empresa.SeeAll(e, ref a))
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
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LimpaApiariosApicultor(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
		{
			try
			{
				Empresa.Apicultor.LimpaApiarios(e, ap);

				return true;
			}
			catch (System.Exception)
			{
				throw;
			}
		}
	}
}
