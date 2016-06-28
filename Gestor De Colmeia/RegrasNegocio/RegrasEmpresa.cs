// ***********************************************************************
// Assembly         : RegrasNegocio
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="RegrasEmpresa.cs" company="">
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
using Empresa; //Data laywer


/// <summary>
/// The RegrasNegocio namespace.
/// </summary>
namespace RegrasNegocio
{
	/// <summary>
	/// Class Regras.
	/// </summary>
	public class Regras
    {
		#region Validacoes

		/// <summary>
		/// Validas the empresa.
		/// </summary>
		/// <param name="nome">The nome.</param>
		/// <param name="pais">The pais.</param>
		/// <param name="localidade">The localidade.</param>
		/// <param name="nif">The nif.</param>
		/// <param name="morada">The morada.</param>
		/// <param name="areaComercio">The area comercio.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool ValidaEmpresa(string nome, string pais, string localidade, long nif, string morada, string areaComercio)
        {
            if (nome != string.Empty &&
                pais != string.Empty &&
                localidade != string.Empty &&
                nif >= 0 &&
                morada != string.Empty &&
                areaComercio != string.Empty)
                return true;

            return false;
        }


		#endregion

		#region Chama o Valida e Cria Objectos Ficha tecnica 


		//done
		/// <summary>
		/// Crias the acao.
		/// </summary>
		/// <param name="nome">The nome.</param>
		/// <param name="pais">The pais.</param>
		/// <param name="localidade">The localidade.</param>
		/// <param name="nif">The nif.</param>
		/// <param name="morada">The morada.</param>
		/// <param name="areaComercio">The area comercio.</param>
		/// <param name="a">Instaciar uma accao. e mantela nula</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool MandaParaForaEmpresa(string nome, string pais, string localidade, long nif, string morada, string areaComercio, out FichaTecnicaEmpresa a)
        {
            if (!ValidaEmpresa(nome, pais, localidade, nif, morada, areaComercio))
            {
                a = null;
                return false;
            }

            else
            {
                a = new FichaTecnicaEmpresa(nome, pais, localidade, nif, morada, areaComercio);
                return true;
            }

        }


		#endregion

		#region Cria Objectos da DL

		/// <summary>
		/// Recebes the ficha cria objecto empresa.
		/// </summary>
		/// <param name="fe">The fe.</param>
		/// <returns>Cuidado pode returnar null.</returns>
		public static Objecto.FichaTecnicaEmpresa RecebeFichaCriaObjectoEmpresa(FichaTecnicaEmpresa fe)
        {
            if (fe != null)
            {	 
                return (fe);
            }

            return null;
        }

		#endregion

		#region Inserir

		/// <summary>
		/// Inseres the empresa.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool InsereEmpresa(Objecto.FichaTecnicaEmpresa e)
        {
            try
            {
                if(Empresa.Multinacional.AddEmpresa(e))
                    return true;

                return false;
            }
            catch (System.Exception)
            {
				throw;
            }
        }

		#endregion

		#region Eliminar

		/// <summary>
		/// Eliminars the empresa.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool EliminarEmpresa(Objecto.FichaTecnicaEmpresa e)
        {
            try
            {
                if(Empresa.Multinacional.DipensesEmpresa(e))
                    return true;

                return false;
            }
            catch (System.Exception)
            {
				throw;
			}
        }

		#endregion

		#region Search

		/// <summary>
		/// Searches the empresa.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SearchEmpresa(Objecto.FichaTecnicaEmpresa e)
        {
            try
            {
                if (Empresa.Multinacional.SearchEmpresa(e))
                    return true;

                return false;

            }
            catch (System.Exception)
            {
				throw;
			}
        }

		#endregion

		#region Sort

		/// <summary>
		/// Sorts the empresa.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SortEmpresa()
        {
            try
            {
                if (Empresa.Multinacional.SortEmpresa())
                    return true;

                return false;

            }
            catch (System.Exception)
            {
				throw;
			}
        }

		#endregion

		#region How Mucth

		/// <summary>
		/// Hows the much empresa.
		/// </summary>
		/// <returns>System.Int32.</returns>
		public static int HowMuchEmpresa()
        {
            try
            {
                return Empresa.Multinacional.HowMuchEmpresas();
            }
            catch (System.Exception)
            {
				throw;
			}
        }

		#endregion

		#region SeeAll

		/// <summary>
		/// Sees all empresa.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SeeAllEmpresa(ref List<string> e)
        {
            try
            {																 
				if (Empresa.Multinacional.SeeAll(ref e))
				{
					
					return true;
				}

                return false;

            }
            catch (System.Exception)
            {
				throw;
            }
        }

		#endregion

		#region Limpa

		/// <summary>
		/// Limpa
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LimpaDicionarioMultinacional()
		{
			try
			{
				Empresa.Multinacional.LimpaDicionario();

				return true;
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
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LimpaEmpregadosEmpresa(Objecto.FichaTecnicaEmpresa e)
		{
			try
			{
				Empresa.Empresa.LimpaEmpregados(e);

				return true;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		/// <summary>
		/// Limpa
		/// </summary>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool LimpaAccoesAno(Empresa.Ano a)
		{
			try
			{
				Empresa.Ano.LimpaCalendario(a);

				return true;
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		#endregion

		#region Ficheiros

		/// <summary>
		/// Guarda
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="System.Exception"></exception>
		public static bool EscreveFicheiroMultinacional(string fileName = "multinacional.bin")
		{
			try
			{
				Empresa.Multinacional.EscreveFicheiro();

				return true;
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}

		/// <summary>
		/// Le
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="System.Exception"></exception>
		public static bool LeFicheiroMultinacional(string fileName = "multinacional.bin")
		{
			try
			{
				Empresa.Multinacional.LeFicheiro();

				return true;
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}
		


		#endregion

	}
}
				   