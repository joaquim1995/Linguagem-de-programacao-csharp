// ***********************************************************************
// Assembly         : ClassLibrary1
// Author           : Utilizador
// Created          : 05-22-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Multnacional.cs" company="">
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
/// The Exception namespace.
/// </summary>
namespace Exception
{
	/// <summary>
	/// Class MultinacionalException.
	/// </summary>
	public class MultinacionalException : ApplicationException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="MultinacionalException"/> class.
		/// </summary>
		public MultinacionalException() : base("Erro Multinacional") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MultinacionalException"/> class.
		/// </summary>
		/// <param name="s">The s.</param>
		public MultinacionalException(string s) : base(s) { }

	}
}
