// ***********************************************************************
// Assembly         : Empresa
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="Empresa.cs" company="">
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
using System.Collections.Generic;


/// <summary>
/// The Empresa namespace.
/// </summary>
namespace Empresa
{
	/// <summary>
	/// Class Empresa.
	/// </summary>
	[Serializable]
	public class Empresa
    {
		//por cada empresa criada irá ter dois funcionario. o chefe e o emplastro

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
		/// <summary>
		/// The calendario acoes
		/// </summary>
		public Ano calendarioAcoes;

		/// <summary>
		/// The tot empregados
		/// </summary>
		[NonSerialized]
		internal int totEmpregados = 0;

		/// <summary>
		/// The empregados
		/// </summary>
		internal List<Apicultor> empregados = new List<Apicultor>();


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

		//duvida 
		/// <summary>
		/// Initializes a new instance of the <see cref="Empresa"/> class.
		/// </summary>
		public Empresa()
        {
            pais = String.Empty;
            nome = String.Empty;
            localidade = String.Empty;
            empregados = new List<Apicultor>();
            nif = long.MinValue;
            morada = String.Empty;
            areaComercio = String.Empty;
            calendarioAcoes = new Ano();
			empregados = new List<Apicultor>();

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Empresa"/> class.
		/// </summary>
		/// <param name="morada">The morada.</param>
		/// <param name="localidade">The localidade.</param>
		/// <param name="nome">The nome.</param>
		/// <param name="pais">The pais.</param>
		/// <param name="nif">The nif.</param>
		/// <param name="areaComercio">The area comercio.</param>
		public Empresa(string morada,string localidade, string nome = "Associação Do Mel", string pais = "Portugal", long nif = 000000000, string areaComercio = "Mel")
        {
            this.pais = pais;
            this.localidade = localidade;
            this.nome = nome;
			this.morada = morada;
			this.nif = nif;
			this.areaComercio = areaComercio;
			empregados = new List<Apicultor>();
			        
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Empresa"/> class.
		/// </summary>
		/// <param name="f">The f.</param>
		public Empresa(Objecto.FichaTecnicaEmpresa f)
        {
            this.nome = f.Nome;
            this.pais = f.Pais;
            this.localidade = f.Localidade;
            this.nif = f.Nif;
            this.morada = f.Morada;
            this.areaComercio = f.Area;
			empregados = new List<Apicultor>();

		}
		#endregion


		#region Methods

		/// <summary>
		/// Sees all.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="todosEmpregados">The todos empregados.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool SeeAll(Objecto.FichaTecnicaEmpresa e, ref List<string> todosEmpregados)
        {
			string texto;
			todosEmpregados.Clear();

			if (e == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);

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
									texto = string.Empty;
									texto += item.Associacao.ToString() + "\n";
									texto += item.Comeco.ToString() + "\n";
									texto += item.Nome.ToString() + "\n";
									texto += item.NumeroApicutor.ToString() + "\n";	 
									texto += item.NumeroContacto.ToString() + "\n";
									todosEmpregados.Add(texto);
								}
								return true;
							}								  
						}
					}
				}
				return false;	   
			} 			
        }

		//esta
		/// <summary>
		/// Hows the much worker.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchWorker(Objecto.FichaTecnicaEmpresa e)
		{
			if (e == null)
				return 0;

			else
			{
				Empresa fe = new Empresa(e);

				if (Multinacional.multinacionais.ContainsKey(fe.Nif))
				{
					foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
					{
						foreach (Empresa empresa in lista)
						{
							if (fe == empresa)
								return empresa.totEmpregados;
						}
					}
				}
				return 0;
			}
		}

		//esta
		/// <summary>
		/// Adds the worker.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">a.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.EmpresaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool AddWorker(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor a)
        {
			if (e == null || a == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteApicultor(e, a))
					{		 
						Empresa fe = new Empresa(e);
						Apicultor ap = new Apicultor(a);

						foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									empresa.empregados.Add(ap);	
									empresa.totEmpregados++;
									return true;
								}
							}
						}		  
						return false;
					}

					else
						return false;
				}
				catch (Exception.EmpresaException)
				{
					throw new Exception.EmpresaException();
				}
				catch (System.Exception)
				{
					throw new System.Exception();
				}
			}
		}

		//esta
		/// <summary>
		/// Dispenses the worker.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">a.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.EmpresaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool DipensesWorker(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor a)
        {
			if (e == null || a == null)
				return false;

			else
			{
				try
				{
					if (Multinacional.ExisteApicultor(e, a))
					{
						Empresa fe = new Empresa(e);
						Apicultor ap = new Apicultor(a);

						foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									empresa.empregados.Remove(ap);
									empresa.totEmpregados--;
									return true;
								}
							}
						}
						return false;
					}

					else
						return false;
				}

				catch (Exception.EmpresaException)
				{
					throw new Exception.EmpresaException();
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
		/// <returns>False error | True good</returns>
		public static bool SortWorker(Objecto.FichaTecnicaEmpresa e)
        {
			if (e == null)
				return false;

			else
			{
				if (Multinacional.ExisteEmpresa(e))
				{
					Empresa fe = new Empresa(e);	  

					foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
					{
						foreach (Empresa empresa in lista)
						{
							if (fe == empresa)
							{
								empresa.empregados.Sort();
								return true;
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
		/// Searches for determinate worker.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="a">apicultur</param>
		/// <returns>False error | True good and posicao of apicultor</returns>
		public static bool SearchWorker(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor a)
        {
			if (e == null || a == null)
				return false;

			else
			{
				if (Multinacional.ExisteApicultor(e, a))						
					return true;					 

				else
					return false;
			}
        }


		// tá
		/// <summary>
		/// Agendars the acao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.EmpresaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool AgendarAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
		{
			int dia = ac.Data.DayOfYear - 1;
			int k = 0;

			if (e == null || ap == null || c == null || a == null || ac == null)
				return false;

			else  
			{
				try
				{		 
					if (!Multinacional.ExisteAccao(e, ap, a, c, ac))
					{
						Empresa fe = new Empresa(e);

						if (Ano.TemEventosNumDia(fe, ac))
							return false;

						else
						{
							foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
							{
								foreach (Empresa empresa in lista)
								{
									if (fe == empresa)
									{	  
										Ano.InsereAcaoAno(empresa,ac);	
									}
								}
							}							
						}

						if (Colmeia.Intervention(e, ap, a, c, ac) && k == 1)
							return true;

						return false;
					}

					else
						return false;
				}

				catch (Exception.EmpresaException)
				{
					throw new Exception.EmpresaException();
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
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.EmpresaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LimpaEmpregados(Objecto.FichaTecnicaEmpresa e)
		{
			if (e == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);

				try
				{
					foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
					{
						foreach (Empresa empresa in lista)
						{
							if (fe == empresa)
							{
								empresa.empregados.Clear();	 
								return true;
							}
						}
					}
					return false;


				}
				catch (Exception.EmpresaException)
				{
					throw new Exception.EmpresaException();
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
		/// <param name="pU">The p u.</param>
		/// <param name="pD">The p d.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Empresa pU,Empresa pD)
		{
										   
				return (pU.Nif == pD.Nif);	
		}

		/// <summary>
		/// Implements the !=.
		/// </summary>
		/// <param name="pU">The p u.</param>
		/// <param name="pD">The p d.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Empresa pU, Empresa pD)
		{
			if (pU == null || pD == null)
				return false;

			else
			{										

				return !(pU.Nif == pD.Nif);
			}
		}



		#endregion
	}
}
