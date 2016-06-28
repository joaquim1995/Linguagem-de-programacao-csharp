// ***********************************************************************
// Assembly         : Objecto
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-20-2015
// ***********************************************************************
// <copyright file="FichaTecnicaApicultor.cs" company="">
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
using System.IO;


/// <summary>
/// The Objecto namespace.
/// </summary>
namespace Objecto
{
	/// <summary>
	/// Class FichaTecnicaApicultor.
	/// </summary>
	public class FichaTecnicaApicultor 
    {
		#region Vars
		/// <summary>
		/// The nome
		/// </summary>
		string nome;
		/// <summary>
		/// The numero apicultor
		/// </summary>
		int numeroApicultor;
		/// <summary>
		/// The comeco
		/// </summary>
		DateTime comeco;
		/// <summary>
		/// The associacao
		/// </summary>
		string associacao;
		/// <summary>
		/// The numero contacto
		/// </summary>
		int numeroContacto;
		/// <summary>
		/// The foto
		/// </summary>
		FileStream foto;


		#endregion

		#region GetSet

		/// <summary>
		/// Gets or sets the nome.
		/// </summary>
		/// <value>The nome.</value>
		public string Nome
	    {
		    get { return nome;}
		    set { nome = value;}
	    }

		/// <summary>
		/// Gets or sets the numero contacto.
		/// </summary>
		/// <value>The numero contacto.</value>
		public int NumeroContacto
        {
            get { return numeroContacto; }
            set { numeroContacto = value; }
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
		/// Gets or sets the associacao.
		/// </summary>
		/// <value>The associacao.</value>
		public string Associacao
        {
            get { return associacao; }
            set { associacao = value; }
        }

		/// <summary>
		/// Gets or sets the foto.
		/// </summary>
		/// <value>The foto.</value>
		public FileStream Foto
        {
            get { return foto; }
            set { foto = value; }
        }

		/// <summary>
		/// Gets or sets the comeco.
		/// </summary>
		/// <value>The comeco.</value>
		public DateTime Comeco
        {
            get { return comeco; }
            set { comeco = value; }
        }


		#endregion

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="Apicultor" /> class.
		/// </summary>
		public FichaTecnicaApicultor()
        {
            try
            {
                nome = String.Empty;
                numeroApicultor = -1;
                comeco = DateTime.MinValue;
                associacao = String.Empty;
                numeroContacto = -1;
                foto = (FileStream)Stream.Null;

            }
            catch (Exception)
            {                
                System.Console.Beep(1,100);
				throw;
			}
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Apicultor" /> class.
		/// </summary>
		/// <param name="nome">The nome.</param>
		/// <param name="numeroApicultor">The numero apicultor.</param>
		/// <param name="comeco">The comeco.</param>
		/// <param name="associacao">The associacao.</param>
		/// <param name="numeroContacto">The numero contacto.</param>
		/// <param name="foto">The foto.</param>
		public FichaTecnicaApicultor(string nome, int numeroApicultor, DateTime comeco, string associacao, int numeroContacto, FileStream foto)
        {
            this.nome = nome;
            this.numeroApicultor = numeroApicultor;
            this.comeco = comeco;
            this.associacao = associacao;
            this.numeroContacto = numeroContacto;
            this.foto = foto;
        }

        #endregion

        
    }
}
