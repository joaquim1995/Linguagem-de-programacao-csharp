// ***********************************************************************
// Assembly         : Empresa
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="Apicultor.cs" company="">
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
using Objecto;

using System.Collections.Generic;


/// <summary>
/// The Empresa namespace.
/// </summary>
namespace Empresa
{
	/// <summary>
	/// Class Apicultor.
	/// </summary>
	[Serializable]
	public class Apicultor
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

		/// <summary>
		/// The tot apiarios
		/// </summary>
		[NonSerialized]
		internal int totApiarios = 0;

		/// <summary>
		/// The apiarios
		/// </summary>
		internal List<Apiario> apiarios = new List<Apiario>();

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
		/// Gets or sets the numero apicutor.
		/// </summary>
		/// <value>The numero apicutor.</value>
		public int NumeroApicutor
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
		/// <exception cref="Exception.ApicultorException"></exception>
		/// <exception cref="System.Exception"></exception>
		public Apicultor()
        {
            try
            {
                nome = String.Empty;
                numeroApicultor = -1;
                comeco = DateTime.MinValue;
                associacao = String.Empty;
                numeroContacto = -1;
                foto = (FileStream)Stream.Null;
                apiarios = new List<Apiario>();

            }
			catch (Exception.ApicultorException)
			{
				throw new Exception.ApicultorException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
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
		public Apicultor(string nome, int numeroApicultor,DateTime comeco, string associacao, int numeroContacto, FileStream foto )
        {
            this.nome = nome;
            this.numeroApicultor = numeroApicultor;
            this.comeco = comeco;
            this.associacao = associacao;
            this.numeroContacto = numeroContacto;
            this.foto = foto;
            apiarios = new List<Apiario>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Apicultor"/> class.
		/// </summary>
		/// <param name="f">The f.</param>
		public Apicultor(FichaTecnicaApicultor f)
        {
            this.nome = f.Nome;
            this.numeroApicultor = f.NumeroApicultor;
            this.comeco = f.Comeco;
            this.associacao = f.Associacao;
            this.numeroContacto = f.NumeroContacto;
            this.foto = f.Foto;
            apiarios = new List<Apiario>();

		}

		#endregion

		#region Methods

		/// <summary>
		/// Sees all.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">a.</param>
		/// <param name="todosApiarios">The todos apiarios.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="System.Exception"></exception>
		public static bool SeeAll(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor a,ref List<string> todosApiarios)
		{
			string texto;
			if (e == null ||  a == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteApicultor(e,a))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(a);	   

						foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									foreach (Apicultor item in empresa.empregados)
									{
										if (apicultor == item)
										{
											foreach (Apiario value in item.apiarios)
											{
												texto = string.Empty;
												texto += value.ComecoApiario.ToString() + "\n";
												texto += value.FuncionarioAtribuido.ToString() + "\n";
												texto += value.Latitude.ToString() + "\n";
												texto += value.Longitude.ToString() + "\n";
												texto += value.NumeroApiario.ToString() + "\n";
												todosApiarios.Add(texto);  
											}

											return true;
										}
									}
								}
							}
						}
						return false;
					}

					return false;
				}
				catch (System.Exception)
				{
					throw new System.Exception();
				}
			}

		}

		//esta
		/// <summary>
		/// Hows the much work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchWork(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
        {
			if (e == null || ap == null)
				return 0;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);

				if (Multinacional.multinacionais.ContainsKey(fe.Nif))
				{
					foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
					{
						foreach (Empresa empresa in lista)
						{
							if (fe == empresa)
							{
								foreach (Apicultor item in empresa.empregados)
								{
									if (apicultor == item)
										return item.totApiarios;
								}
							}
						}
					}
				}
				return 0;
			}
		}

		//esta 
		/// <summary>
		/// Adds the work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ApicultorException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool AddWork(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
        {
			if (e == null || a == null || ap == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteApiario(e, ap, a))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);

						foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									foreach (Apicultor item in empresa.empregados)
									{
										if (apicultor == item)
										{
											item.apiarios.Add(apiario);
											return true;
										}
									}
								}
							}
						}
						return false;
					}

					else
						return false;
				}
				catch (Exception.ApicultorException)
				{
					throw new Exception.ApicultorException();
				}
				catch (System.Exception)
				{
					throw new System.Exception();
				}
			}

		}

		//esta
		/// <summary>
		/// Dispenses the work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">apiario</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ApicultorException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool DipensesWork(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
        {

			if (e == null || a == null || ap ==null)
				return false;

			else
			{
				try
				{
					if (Multinacional.ExisteApiario(e, ap, a))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);

						foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									foreach (Apicultor item in empresa.empregados)
									{
										if (apicultor == item)
										{
											item.apiarios.Remove(apiario);
											item.totApiarios--;
											return true;
										}
									}	
								}
							}
						}
						return false;
					}

					else
						return false;
				}
				catch (Exception.ApicultorException)
				{
					throw new Exception.ApicultorException();
				}
				catch (System.Exception)
				{
					throw new System.Exception();
				}
			}			 
        }

		//esta
		/// <summary>
		/// Sorts the work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns>False error | True good</returns>
		public static bool SortWork(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
        {
			if (e == null || ap == null)
				return false;

			else
			{
				if (Multinacional.ExisteApicultor(e,ap))
				{
					Empresa fe = new Empresa(e);
					Apicultor apicultor = new Apicultor(ap);

					foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
					{
						foreach (Empresa empresa in lista)
						{
							if (fe == empresa)
							{
								foreach (Apicultor item in empresa.empregados)
								{
									if (apicultor == item)
									{
										item.apiarios.Sort();
										return true;
									}
								}
							}
						}
					}
					return false;
				}

				else
					return false;
			}							            
		}

		//esta
		/// <summary>
		/// Searches for determinate work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">apiario</param>
		/// <returns>False error | True good and posicao of apiario</returns>
		/// <exception cref="Exception.ApicultorException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SearchWork(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
        {             
            try
            {
				if (e == null || a == null || ap == null)
					return false;

				else
				{
					if (Multinacional.ExisteApiario(e, ap , a))
						return true;

					else
						return false;
				}

			}
			catch (Exception.ApicultorException)
			{
				throw new Exception.ApicultorException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}

		//encontra uma apiario  com determinada lat e lon
		/// <summary>
		/// Localizacaoes the colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="lat">The lat.</param>
		/// <param name="lon">The lon.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LocalizacaoApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap,int lat, int lon)
        {
			if (e == null || ap == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);   

				try
				{
					if (Multinacional.multinacionais.ContainsKey(fe.Nif))
					{
						foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									foreach (Apicultor item in empresa.empregados)
									{
										if (apicultor == item)
										{
											foreach (Apiario value in item.apiarios)
											{	  
												// considero que as colmeias estam na mesma localizaçao dentro de um apiario
												if (value.Longitude == lon && value.Latitude == lat)
													return true;   
											}
										}
									}
								}
							}
						}
					}
					return false;
				}
				catch (Exception.MultinacionalException)
				{
					throw new Exception.MultinacionalException();
				}
				catch (System.Exception)
				{
					throw new System.Exception();
				}
			}	 			 
        }


		/// <summary>
		/// Limpa
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.ApicultorException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LimpaApiarios(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
		{
			if (e == null|| ap == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);

				try
				{
					foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
					{
						foreach (Empresa empresa in lista)
						{
							if (fe == empresa)
							{
								foreach (Apicultor item in empresa.empregados)
								{
									if (apicultor == item)
									{
										item.apiarios.Clear();
										return true;
									}
								}
							}
						}
					}
					return false; 

				}
				catch (Exception.ApicultorException)
				{
					throw new Exception.ApicultorException();
				}
				catch (System.Exception)
				{
					throw new System.Exception();
				}
			}
		}


		/// <summary>
		/// Implements the ==.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Apicultor p1, Apicultor p2)
		{
			return (p1.NumeroApicutor == p2.NumeroApicutor && p1.NumeroContacto == p2.NumeroContacto);
		}

		/// <summary>
		/// Implements the !=.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Apicultor p1, Apicultor p2)
		{
			return !(p1.NumeroApicutor == p2.NumeroApicutor && p1.NumeroContacto == p2.NumeroContacto);
		}

		#endregion

	}
}
