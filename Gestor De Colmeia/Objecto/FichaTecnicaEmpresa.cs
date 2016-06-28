// ***********************************************************************
// Assembly         : Objecto
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="FichaTecnicaEmpresa.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// The Objecto namespace.
/// </summary>
namespace Objecto
{
	/// <summary>
	/// Class FichaTecnicaEmpresa.
	/// </summary>
	public class FichaTecnicaEmpresa
    {
		#region Vars

		/// <summary>
		/// The nome
		/// </summary>
		string nome;
		/// <summary>
		/// The pais
		/// </summary>
		string pais;
		/// <summary>
		/// The localidade
		/// </summary>
		string localidade;
		/// <summary>
		/// The nif
		/// </summary>
		long nif;
		/// <summary>
		/// The morada
		/// </summary>
		string morada;
		/// <summary>
		/// The area comercio
		/// </summary>
		string areaComercio;

		#endregion

		#region GetSet

		/// <summary>
		/// Gets or sets the area.
		/// </summary>
		/// <value>The area.</value>
		public string Area
        {
            get { return areaComercio; }
            set { areaComercio = value; }
        }

		/// <summary>
		/// Gets or sets the morada.
		/// </summary>
		/// <value>The morada.</value>
		public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

		/// <summary>
		/// Gets or sets the nif.
		/// </summary>
		/// <value>The nif.</value>
		public long Nif
        {
            get { return nif; }
            set { nif = value; }
        }

		/// <summary>
		/// Gets or sets the pais.
		/// </summary>
		/// <value>The pais.</value>
		public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

		/// <summary>
		/// Gets or sets the localidade.
		/// </summary>
		/// <value>The localidade.</value>
		public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

		/// <summary>
		/// Gets or sets the nome.
		/// </summary>
		/// <value>The nome.</value>
		public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

		#endregion

		#region Construct
		/// <summary>
		/// Initializes a new instance of the <see cref="FichaTecnicaEmpresa"/> class.
		/// </summary>
		public FichaTecnicaEmpresa()
        {
            this.pais = String.Empty;
            this.nome = String.Empty;
            this.localidade = String.Empty;
            this.nif = long.MinValue;
            this.morada = String.Empty;
            this.areaComercio = String.Empty;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="FichaTecnicaEmpresa"/> class.
		/// </summary>
		/// <param name="nome">The nome.</param>
		/// <param name="pais">The pais.</param>
		/// <param name="localidade">The localidade.</param>
		/// <param name="nif">The nif.</param>
		/// <param name="morada">The morada.</param>
		/// <param name="areaComercio">The area comercio.</param>
		public FichaTecnicaEmpresa(string nome, string pais, string localidade, long nif, string morada, string areaComercio)
        {
            this.pais = pais;
            this.nome = nome;
            this.localidade = localidade;
            this.nif = nif;
            this.morada = morada;
            this.areaComercio = areaComercio;
            
        }

			

		#endregion
	}
}
