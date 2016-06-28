// ***********************************************************************
// Assembly         : RegrasNegocio
// Author           : Utilizador
// Created          : 05-27-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="RegrasApiario.cs" company="">
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
	/// Class RegrasApiario.
	/// </summary>
	class RegrasApiario
	{
		/// <summary>
		/// Validas the apiario.
		/// </summary>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="comecoApiario">The comeco apiario.</param>
		/// <param name="funcionarioAtribuido">The funcionario atribuido.</param>
		/// <param name="latitude">The latitude.</param>
		/// <param name="longitude">The longitude.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool ValidaApiario(int numeroApiario, DateTime comecoApiario, string funcionarioAtribuido, int latitude, int longitude)
		{
			if (numeroApiario >= 0 &&
				comecoApiario <= DateTime.Now &&
				funcionarioAtribuido != string.Empty)
				return true;

			return false;
		}


		/// <summary>
		/// Crias the acao.
		/// </summary>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="comecoApiario">The comeco apiario.</param>
		/// <param name="funcionarioAtribuido">The funcionario atribuido.</param>
		/// <param name="latitude">The latitude.</param>
		/// <param name="longitude">The longitude.</param>
		/// <param name="f">The f.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool MandaParaForaApiario(int numeroApiario, DateTime comecoApiario, string funcionarioAtribuido, int latitude, int longitude, out FichaTecnicaApiario f)
		{
			if (!ValidaApiario(numeroApiario, comecoApiario, funcionarioAtribuido, latitude, longitude))
			{
				f = null;
				return false;
			}

			else
			{
				f = new FichaTecnicaApiario(numeroApiario, comecoApiario, funcionarioAtribuido, latitude, longitude);
				return true;
			}

		}

		/// <summary>
		/// Recebes the ficha cria objecto apiario.
		/// </summary>
		/// <param name="fe">The fe.</param>
		/// <returns>Objecto.FichaTecnicaApiario.</returns>
		public static Objecto.FichaTecnicaApiario RecebeFichaCriaObjectoApiario(FichaTecnicaApiario fe)
		{
			if (fe != null)
			{
				return (fe);
			}

			return null;
		}


		/// <summary>
		/// Inseres the apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool InsereApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			try
			{
				if (Empresa.Apicultor.AddWork(e, ap, a))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Eliminars the apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool EliminarApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			try
			{
				if (Empresa.Apicultor.DipensesWork(e, ap, a))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Searches the apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SearchApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			try
			{
				if (Empresa.Apicultor.SearchWork(e, ap, a))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sorts the apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SortApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
		{
			try
			{
				if (Empresa.Apicultor.SortWork(e, ap))
					return true;

				return false;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Hows the much apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
		{
			try
			{
				return Empresa.Apicultor.HowMuchWork(e, ap);
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Sees all apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SeeAllApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, ref List<string> a)
		{
			try
			{
				if (Empresa.Apicultor.SeeAll(e, ap, ref a))
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
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LimpaColmeiasApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			try
			{
				Empresa.Apiario.LimpaColmeias(e, ap, a);

				return true;
			}
			catch (System.Exception)
			{
				throw;
			}
		}

	}
}
