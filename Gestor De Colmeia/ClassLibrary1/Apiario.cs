// ***********************************************************************
// Assembly         : ClassLibrary1
// Author           : Utilizador
// Created          : 05-22-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Apiario.cs" company="">
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
	/// Class ApiarioException.
	/// </summary>
	public class ApiarioException : ApplicationException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiarioException"/> class.
		/// </summary>
		public ApiarioException() : base("Erro apiario") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiarioException"/> class.
		/// </summary>
		/// <param name="s">The s.</param>
		public ApiarioException(string s) : base(s) { }

	}
}
