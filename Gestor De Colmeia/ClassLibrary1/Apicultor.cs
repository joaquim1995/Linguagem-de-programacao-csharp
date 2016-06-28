// ***********************************************************************
// Assembly         : ClassLibrary1
// Author           : Utilizador
// Created          : 05-22-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Apicultor.cs" company="">
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
	/// Class ApicultorException.
	/// </summary>
	public class ApicultorException : ApplicationException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="ApicultorException"/> class.
		/// </summary>
		public ApicultorException() : base("Erro apicultor") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ApicultorException"/> class.
		/// </summary>
		/// <param name="s">The s.</param>
		public ApicultorException(string s) : base(s) { }

	}
}
