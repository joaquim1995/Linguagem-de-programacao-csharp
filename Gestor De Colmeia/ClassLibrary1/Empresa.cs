// ***********************************************************************
// Assembly         : ClassLibrary1
// Author           : Utilizador
// Created          : 05-22-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Empresa.cs" company="">
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
	/// Class EmpresaException.
	/// </summary>
	public class EmpresaException : ApplicationException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="EmpresaException"/> class.
		/// </summary>
		public EmpresaException() : base("Erro Empresa") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="EmpresaException"/> class.
		/// </summary>
		/// <param name="s">The s.</param>
		public EmpresaException(string s) : base(s) { }

	}
}
