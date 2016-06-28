// ***********************************************************************
// Assembly         : Trab1
// Author           : Utilizador
// Created          : 12-11-2015
//
// Last Modified By : Utilizador
// Last Modified On : 12-31-2015
// ***********************************************************************
// <copyright file="Pessoa.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;


namespace Trab1
{
    /// <summary>
    /// Class Pessoa.
    /// </summary>
    [Serializable]
    public class Pessoa
    {
        #region Vars
                         
        int numeroPessoa;  
        TipoPessoa tipo;  
        int idade;  
        string nome;


        #endregion

        #region GetSet

        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        /// <value>The nome.</value>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Gets or sets the idade.
        /// </summary>
        /// <value>The idade.</value>
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        /// <summary>
        /// Gets or sets the numero pessoa.
        /// </summary>
        /// <value>The numero pessoa.</value>
        public int NumeroPessoa
        {
            get { return numeroPessoa; }
            set { numeroPessoa = value; }
        }

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        /// <value>The tipo.</value>
        public TipoPessoa Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        #endregion

        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="Pessoa" /> class.
        /// </summary>
        public Pessoa ()
        {
            numeroPessoa = -1;
            nome = string.Empty;
            tipo = TipoPessoa.convidado;
            idade = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pessoa" /> class.
        /// </summary>
        /// <param name="idade">The idade.</param>
        /// <param name="nome">The nome.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="numeroPessoa">The numero pessoa.</param>
        public Pessoa (int idade, string nome, TipoPessoa tipo, int numeroPessoa)
        {
            this.numeroPessoa = numeroPessoa;
            this.nome = nome;
            this.idade = idade;
            this.tipo = tipo;
            this.numeroPessoa = numeroPessoa;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Escreves the pessoa.
        /// </summary>
        /// <param name="p">The p.</param>
        public void EscrevePessoa (Pessoa p)
        {
            Console.WriteLine(p.ToString());
        }

        /// <summary>
        /// Escreves the proprio.
        /// </summary>
        public void EscreveProprio ()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return ("Nº Pessoa : " + NumeroPessoa.ToString() + "\nTipo Pessoa : " + Tipo.ToString() + "\nIdade : " + Idade.ToString() + "\nNome : " + Nome.ToString());
        }

        /// <summary>
        /// Compares the pessoa.
        /// </summary>
        /// <param name="eU">The e u.</param>
        /// <param name="eD">The e d.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ComparePessoa (Pessoa eU, Pessoa eD)
        {

            return (eU == eD);


        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Pessoa pU, Pessoa pD)
        {

            //http://stackoverflow.com/questions/4219261/overriding-operator-how-to-compare-to-null
            // If left hand side is null...
            if ( System.Object.ReferenceEquals(pU, null) )
            {
                // ...and right hand side is null...
                if ( System.Object.ReferenceEquals(pD, null) )
                {
                    //...both are null and are Equal.
                    return true;
                }

                // ...right hand side is not null, therefore not Equal.
                return false;
            }

            // Return true if the fields match:
            return pU.Equals(pD);
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Pessoa pU, Pessoa pD)
        {
            if ( pU == null || pD == null )
                return false;
            return !(pU.nome == pD.nome && pU.idade == pD.idade);
        }

        #endregion
    }
}
