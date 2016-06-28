// ***********************************************************************
// Assembly         : Objecto
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 04-16-2015
// ***********************************************************************
// <copyright file="FichaTecnicaApiario.cs" company="">
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
	/// Class FichaTecnicaApiario.
	/// </summary>
	public class FichaTecnicaApiario
    {
		#region Vars

		/// <summary>
		/// The tot slot
		/// </summary>
		public static int totSlot;

		/// <summary>
		/// The numero apiario
		/// </summary>
		int numeroApiario;
		/// <summary>
		/// The comeco apiario
		/// </summary>
		DateTime comecoApiario;
		/// <summary>
		/// The funcionario atribuido
		/// </summary>
		string funcionarioAtribuido;
		/// <summary>
		/// The latitude
		/// </summary>
		int latitude;
		/// <summary>
		/// The longitude
		/// </summary>
		int longitude;

		#endregion

		#region GetSet

		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		public int Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public int Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

		/// <summary>
		/// Gets or sets the funcionario atribuido.
		/// </summary>
		/// <value>The funcionario atribuido.</value>
		public string FuncionarioAtribuido
	    {
		    get { return funcionarioAtribuido;}
            set { funcionarioAtribuido = value; }
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
		/// Gets or sets the comeco apiario.
		/// </summary>
		/// <value>The comeco apiario.</value>
		public DateTime ComecoApiario
        {
            get { return comecoApiario; }
            set { comecoApiario = value; }
        }


		#endregion

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="Apiario" /> class.
		/// </summary>
		public FichaTecnicaApiario()
        {
            numeroApiario = -1;
            comecoApiario = DateTime.MinValue;
            funcionarioAtribuido = String.Empty;
            latitude = 0;
            longitude = 0;

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Apiario" /> class.
		/// </summary>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="comecoApiario">The comeco apiario.</param>
		/// <param name="funcionarioAtribuido">The funcionario atribuido.</param>
		/// <param name="latitude">The latitude.</param>
		/// <param name="longitude">The longitude.</param>
		public FichaTecnicaApiario(int numeroApiario, DateTime comecoApiario, string funcionarioAtribuido, int latitude, int longitude)
        {
            this.numeroApiario = numeroApiario;
            this.comecoApiario = comecoApiario;
            this.funcionarioAtribuido = funcionarioAtribuido;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        #endregion
    }
}
