// ***********************************************************************
// Assembly         : ClassLibrary1
// Author           : Utilizador
// Created          : 05-22-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Ano.cs" company="">
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
	/// Class AnoException.
	/// </summary>
	public class AnoException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AnoException"/> class.
		/// </summary>
		public AnoException() : base("Erro calendario") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="AnoException"/> class.
		/// </summary>
		/// <param name="s">The s.</param>
		public AnoException(string s) : base(s) { }

	}
}
