// ***********************************************************************
// Assembly         : Objecto
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-25-2015
// ***********************************************************************
// <copyright file="Acao.cs" company="">
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


//BO é um mero objecto ele nao pode saber da 
//existencia de nenhuma camada
//cada camada é que o usa como desejar
//pois no final de contas no final da aplicacao
//o BO vai ser eliminado

/// <summary>
/// The Objecto namespace.
/// </summary>
namespace Objecto
{
	/// <summary>
	/// Class Acao.
	/// </summary>
	[Serializable]
	public class Acao 
    {
		#region Vars

		/// <summary>
		/// The data
		/// </summary>
		DateTime data;
		/// <summary>
		/// The acontecimento
		/// </summary>
		string acontecimento;
		/// <summary>
		/// The numero apicultor
		/// </summary>
		int numeroApicultor;
		/// <summary>
		/// The numero apiario
		/// </summary>
		int numeroApiario;

		#endregion

		#region GetSet

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

		/// <summary>
		/// Gets or sets the numero apiario.
		/// </summary>
		/// <value>The numero apiario.</value>
		public int NumeroApiario
        {
            get { return numeroApiario; }
            set { numeroApiario = value; }
        }

		/// <summary>
		/// Gets or sets the numero apicultor.
		/// </summary>
		/// <value>The numero apicultor.</value>
		public int NumeroApicultor
        {
            get { return numeroApicultor; }
            set { numeroApicultor = value; }
        }

		/// <summary>
		/// Gets or sets the acontecimento.
		/// </summary>
		/// <value>The acontecimento.</value>
		public string Acontecimento
        {
            get { return acontecimento; }
            set { acontecimento = value; }
        }

		#endregion

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="Acao"/> class.
		/// </summary>
		public Acao()
        {
            data = DateTime.Now;
            acontecimento = string.Empty;
            numeroApicultor = -1;
            numeroApiario = -1;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Acao"/> class.
		/// </summary>
		/// <param name="numeroApicultor">The numero apicultor.</param>
		/// <param name="data">The data.</param>
		/// <param name="acontecimento">The acontecimento.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		public Acao(int numeroApicultor, DateTime data, string acontecimento, int numeroApiario)
        {
            this.data = data;
            this.numeroApicultor = numeroApicultor;
            this.acontecimento = acontecimento;
            this.numeroApiario = numeroApiario;
        }

		#endregion

		#region Methods

		/// <summary>
		/// Compares the acao.
		/// </summary>
		/// <param name="e1">The e1.</param>
		/// <param name="e2">The e2.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool CompareAcao(Acao e1, Acao e2)
        {
            try
            {
                if (e1 == e2)
                    return true;

                return false;
            }
            catch (System.Exception)
            {
				throw;
			}


        }

		/// <summary>
		/// Implements the ==.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Acao p1, Acao p2)
        {
            return (p1.numeroApicultor == p2.numeroApicultor && p1.NumeroApiario == p2.NumeroApiario);
        }

		/// <summary>
		/// Implements the !=.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Acao p1, Acao p2)
        {
            return !(p1.numeroApiario == p2.numeroApiario 
                && p1.numeroApiario == p2.numeroApiario);
        }

        #endregion
    }
}
