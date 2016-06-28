// ***********************************************************************
// Assembly         : ClassLibrary1
// Author           : Utilizador
// Created          : 05-22-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Colmeia.cs" company="">
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
	/// Class ColmeiaException.
	/// </summary>
	public class ColmeiaException : ApplicationException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="ColmeiaException"/> class.
		/// </summary>
		public ColmeiaException() : base("Erro colmeia") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ColmeiaException"/> class.
		/// </summary>
		/// <param name="s">The s.</param>
		public ColmeiaException(string s) : base(s) { }

	}
}
