// ***********************************************************************
// Assembly         : Empresa
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="Colmeia.cs" company="">
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

//externas
using Objecto;

/// <summary>
/// The Empresa namespace.
/// </summary>
namespace Empresa
{
	/// <summary>
	/// Class Colmeia.
	/// </summary>
	[Serializable]
	public class Colmeia
	{
		#region Vars

		/// <summary>
		/// The tot acoes
		/// </summary>
		[NonSerialized]
		internal int totAcoes = 0;

		/// <summary>
		/// The acoes
		/// </summary>
		internal List<Objecto.Acao> acoes = new List<Objecto.Acao>();

		/// <summary>
		/// The numero colmeia
		/// </summary>
		int numeroColmeia;
		/// <summary>
		/// The numero apiario
		/// </summary>
		int numeroApiario;
		/// <summary>
		/// The data construcao
		/// </summary>
		DateTime dataConstrucao;

		#endregion

		#region GetSet
		/// <summary>
		/// Gets or sets the data construcao.
		/// </summary>
		/// <value>The data construcao.</value>
		public DateTime DataConstrucao
		{
			get { return dataConstrucao; }
			set { dataConstrucao = value; }
		}

		/// <summary>
		/// Gets or sets the numero apiario.
		/// </summary>
		/// <value>The numero apiario.</value>
		public int NumeroApiario
		{
			get { return numeroApiario; }
			set { numeroApiario = value; }
		}

		/// <summary>
		/// Gets or sets the numero comeia.
		/// </summary>
		/// <value>The numero comeia.</value>
		public int NumeroComeia
		{
			get { return numeroColmeia; }
			set { numeroColmeia = value; }
		}

		#endregion

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="Colmeia"/> class.
		/// </summary>
		public Colmeia()
		{
			numeroColmeia = -1;
			numeroApiario = -1;
			dataConstrucao = DateTime.MinValue;
			acoes = new List<Objecto.Acao>();

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Colmeia"/> class.
		/// </summary>
		/// <param name="numeroColmeia">The numero colmeia.</param>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="dataConstrucao">The data construcao.</param>
		public Colmeia(int numeroColmeia, int numeroApiario, DateTime dataConstrucao)
		{
			this.numeroApiario = numeroApiario;
			this.numeroColmeia = numeroColmeia;
			this.dataConstrucao = dataConstrucao;
			acoes = new List<Objecto.Acao>();

		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Colmeia"/> class.
		/// </summary>
		/// <param name="f">The f.</param>
		public Colmeia(FichaTecnicaColmeia f)
		{
			this.numeroApiario = f.NumeroApiario;
			this.numeroColmeia = f.NumeroColmeia;
			this.dataConstrucao = f.DataConstrucao;
			acoes = new List<Objecto.Acao>();

		}
		#endregion

		#region Methods

		/// <summary>
		/// Sees all.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="todosAcoes">The todos acoes.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="System.Exception"></exception>
		public static bool SeeAll(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, ref List<Objecto.Acao> todosAcoes)
		{
			if (e == null || ap == null || c == null || a == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteColmeia(e, ap, a, c))
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
											foreach (Apiario value in item.apiarios)
											{
												if (value == apiario)
												{
													foreach (Colmeia cc in value.colmeias)
													{
														todosAcoes = cc.acoes;
														return true; ;
													}
												}
											}
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
		/// Interventions the specified e.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="System.Exception"></exception>
		public static bool Intervention(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
		{
			if (e == null || ap == null || c == null || a == null || ac == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteAccao(e, ap, a, c, ac))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);
						Colmeia colmeia = new Colmeia(c);

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
												if (value == apiario)
												{
													foreach (Colmeia cc in value.colmeias)
													{
														if (cc == colmeia)
														{
															foreach (Objecto.Acao acao in cc.acoes)
															{
																if (acao == ac)
																	return false;

															}
															cc.acoes.Add(ac);
															return true;
														}
													}
												}
											}
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
		/// Hows the much Acoes.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchAcoes(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a,Objecto.FichaTecnicaColmeia c)
        {
			if (e == null || ap == null || a == null ||c==null)
				return 0;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);
				Apiario apiario = new Apiario(a); 
				Colmeia colmeia = new Colmeia(c);

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
											if (value == apiario)
											{
												foreach (Colmeia cc in value.colmeias)
												{
													if (cc == colmeia)
														return colmeia.totAcoes;
												}
											}
										}
									}
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
		/// Dispenses the work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">apiario</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ColmeiaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool AddAccao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
        {
			if (e == null || a == null || ap == null|| ac == null || c == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteAccao(e, ap, a, c,ac))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);
						Colmeia colmeia = new Colmeia(c);

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
												if (value == apiario)
												{
													foreach (Colmeia cc in value.colmeias)
													{
														if (cc == colmeia)
														{
															cc.acoes.Add(ac);
															cc.totAcoes++;
															return true;
														}
													}
												}		   												
											}
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
				catch (Exception.ColmeiaException)
				{
					throw new Exception.ColmeiaException();
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
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ColmeiaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool DipensesAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
        {
			if (e == null || a == null || ap == null || ac == null || c == null)
				return false;

			else
			{
				try
				{
					if (!Multinacional.ExisteAccao(e, ap, a, c, ac))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);
						Colmeia colmeia = new Colmeia(c);

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
												if (value == apiario)
												{
													foreach (Colmeia cc in value.colmeias)
													{
														if (cc == colmeia)
														{
															cc.acoes.Remove(ac);
															cc.totAcoes--;
															if (Ano.ApagaEvento(empresa,ac))  
																return true;
														}
													}
												}
											}
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
				catch (Exception.ColmeiaException)
				{
					throw new Exception.ColmeiaException();
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
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ColmeiaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SortAcoes(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			try
			{
				if (e == null || ap == null || a == null || c == null)
					return false;

				else
				{
					if (Multinacional.ExisteColmeia(e, ap, a,c))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);
						Colmeia colmeia = new Colmeia();

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
												if (value == apiario)
												{
													foreach (Colmeia cc in value.colmeias)
													{
														if (cc == colmeia)
														{
															cc.acoes.Sort();
															return true;
														}
													}	 															
												}
											}
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
			catch (Exception.ColmeiaException)
			{
				throw new Exception.ColmeiaException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}

		//esta
		/// <summary>
		/// Searches for determinate work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">apiario</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns>False error | True good and posicao of apiario</returns>
		/// <exception cref="Exception.ColmeiaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SearchAcao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
        {
			try
			{
				if (e == null || a == null || ap == null || c == null|| ac == null)
					return false;

				else
				{
					if (Multinacional.ExisteAccao(e, ap, a, c,ac))
						return true;

					else
						return false;
				}

			}
			catch (Exception.ColmeiaException)
			{
				throw new Exception.ColmeiaException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}

		/// <summary>
		/// Limpa
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.ColmeiaException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LimpaAccoes(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{
			if (e == null || ap == null || a == null|| c == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);
				Apiario apiario = new Apiario(a);
				Colmeia colmeia = new Colmeia();

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
										foreach (Apiario value in item.apiarios)
										{
											if (value == apiario)
											{
												foreach (Colmeia cc in value.colmeias)
												{
													if (cc == colmeia)
													{
														cc.acoes.Clear();  
														return true;
													}
												}	 														
											}
										}
									}
								}
							}
						}
					}
					return false;

				}
				catch (Exception.ColmeiaException)
				{
					throw new Exception.ColmeiaException();
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
		public static bool operator ==(Colmeia p1, Colmeia p2)
        {
            return (p1.NumeroComeia == p2.NumeroComeia && p1.NumeroApiario == p2.NumeroApiario);
        }

		/// <summary>
		/// Implements the !=.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Colmeia p1, Colmeia p2)
        {
            return !(p1.NumeroComeia == p2.NumeroComeia && p1.NumeroApiario == p2.NumeroApiario);
        }


        #endregion
    }
}