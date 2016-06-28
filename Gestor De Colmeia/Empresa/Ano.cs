// ***********************************************************************
// Assembly         : Empresa
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Ano.cs" company="">
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

/// <summary>
/// The Empresa namespace.
/// </summary>
namespace Empresa
{
	/// <summary>
	/// Class Ano.
	/// </summary>
	[Serializable]
	public class Ano
    {
		/// <summary>
		/// The maxsize
		/// </summary>
		public const int MAXSIZE = 366;
		/// <summary>
		/// The acoes
		/// </summary>
		internal List<Objecto.Acao> acoes = new List<Objecto.Acao>();

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="Ano"/> class.
		/// </summary>
		public Ano()
		{				   
			acoes = new List<Objecto.Acao>();

		}

		#endregion

		#region methods
		// duvida pode estar assim 
		/// <summary>
		/// Inseres the acao ano.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.AnoException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool InsereAcaoAno(Empresa e, Objecto.Acao ac)
        {
			try
			{
				int diaAno = ac.Data.DayOfYear - 1;

				if (e.calendarioAcoes.acoes[diaAno] == null)
					e.calendarioAcoes.acoes[diaAno] = ac;

				else
					return false;

				return true;
			}
			catch (Exception.AnoException)
			{
				throw new Exception.AnoException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}							
        }

		//feito
		/// <summary>
		/// Tems the eventos number dia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.AnoException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool TemEventosNumDia(Empresa e,Objecto.Acao ac)
        {
			try
			{
				if (e.calendarioAcoes.acoes.Contains(ac))
					return true;

				return false;
			}
			catch (Exception.AnoException)
			{
				throw new Exception.AnoException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}			
        }

		//feito
		/// <summary>
		/// Apagas the evento.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.AnoException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool ApagaEvento(Empresa e,Objecto.Acao ac)
        {
			try
			{
				if (TemEventosNumDia(e, ac))
				{
					e.calendarioAcoes.acoes.Remove(ac);
					return true;
				}

				return false;
			}
			catch (Exception.AnoException)
			{
				throw new Exception.AnoException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}

		/// <summary>
		/// Limpas the calendario.
		/// </summary>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.AnoException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LimpaCalendario(Ano a)
		{
			try
			{
				a.acoes.Clear();

				return true;
			}
			catch (Exception.AnoException)
			{
				throw new Exception.AnoException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}

		#endregion
	}
}
