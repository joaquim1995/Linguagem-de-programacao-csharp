// ***********************************************************************
// Assembly         : Objecto
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 04-16-2015
// ***********************************************************************
// <copyright file="FichaTecnicaColmeia.cs" company="">
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
/// The Objecto namespace.
/// </summary>
namespace Objecto
{
	/// <summary>
	/// Class FichaTecnicaColmeia.
	/// </summary>
	public class FichaTecnicaColmeia
    {
		#region Vars


		/// <summary>
		/// The numero colmeia
		/// </summary>
		int numeroColmeia;
		/// <summary>
		/// The numero apiario
		/// </summary>
		int numeroApiario;
		/// <summary>
		/// The data construcao
		/// </summary>
		DateTime dataConstrucao;

		#endregion

		#region GetSet
		/// <summary>
		/// Gets or sets the data construcao.
		/// </summary>
		/// <value>The data construcao.</value>
		public DateTime DataConstrucao
        {
            get { return dataConstrucao; }
            set { dataConstrucao = value; }
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
		/// Gets or sets the numero colmeia.
		/// </summary>
		/// <value>The numero colmeia.</value>
		public int NumeroColmeia
        {
            get { return numeroColmeia; }
            set { numeroColmeia = value; }
        }

		#endregion

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="FichaTecnicaColmeia"/> class.
		/// </summary>
		public FichaTecnicaColmeia()
        {
            numeroColmeia = -1;
            numeroApiario = -1;
            dataConstrucao = DateTime.MinValue;

        }
		/// <summary>
		/// Initializes a new instance of the <see cref="FichaTecnicaColmeia"/> class.
		/// </summary>
		/// <param name="numeroColmeia">The numero colmeia.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="dataConstrucao">The data construcao.</param>
		public FichaTecnicaColmeia(int numeroColmeia, int numeroApiario, DateTime dataConstrucao)
        {
            this.numeroApiario = numeroApiario;
            this.numeroColmeia = numeroColmeia;
            this.dataConstrucao = dataConstrucao;

        }

        #endregion
    }
}
