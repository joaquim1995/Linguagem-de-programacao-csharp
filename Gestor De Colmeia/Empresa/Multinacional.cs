// ***********************************************************************
// Assembly         : Empresa
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="Multinacional.cs" company="">
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

/// <summary>
/// The Empresa namespace.
/// </summary>
namespace Empresa
{
	/// <summary>
	/// Class Multinacional.
	/// </summary>
	[Serializable]
	public class Multinacional
	{
		#region Vars
		/// <summary>
		/// The tot empresas
		/// </summary>
		[NonSerialized]
		internal static int totEmpresas = 0;

		/// <summary>
		/// The multinacionais
		/// </summary>
		internal static Dictionary<long, List<Empresa>> multinacionais = new Dictionary<long, List<Empresa>>();

		#endregion

		#region Construct

		//Está bem?
		/// <summary>
		/// Initializes a new instance of the <see cref="Multinacional"/> class.
		/// </summary>
		public Multinacional()
		{									
				List<Empresa> listaEmpresas = new List<Empresa>();	
				multinacionais.Add(0, listaEmpresas);		  

			totEmpresas++;
		}

		//Está bem?
		/// <summary>
		/// Initializes a new instance of the <see cref="Multinacional"/> class.
		/// </summary>
		/// <param name="e">The e.</param>
		public Multinacional(Empresa e)
		{
			if (multinacionais.ContainsKey(e.Nif))
			{
				List<Empresa> listaEmpresas = new List<Empresa>();
				listaEmpresas = multinacionais[e.Nif];
				listaEmpresas.Add(e);
				multinacionais.Add(e.Nif, listaEmpresas);

			}

			else
			{
				List<Empresa> listaEmpresas = new List<Empresa>();
				listaEmpresas.Add(e);
				multinacionais.Add(e.Nif, listaEmpresas);
			}											 			
			
			totEmpresas++;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sees all.
		/// </summary>
		/// <param name="todasEmpresas">entra vazio sai cheio.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SeeAll(ref List<string> todasEmpresas)
		{
			string texto;
			todasEmpresas.Clear();


			try
			{
				foreach (List<Empresa> lista in Multinacional.multinacionais.Values)
				{
					foreach (Empresa empresa in lista)
					{

						texto = string.Empty;
						texto += empresa.Area.ToString() + "\n";
						texto += empresa.Localidade.ToString() + "\n";
						texto += empresa.Morada.ToString() + "\n";
						texto += empresa.Nif.ToString() + "\n";
						texto += empresa.Nome.ToString() + "\n";
						texto += empresa.Pais.ToString() + "\n";
						todasEmpresas.Add(texto);  

					} 
				}

				return true;
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

		//está
		/// <summary>
		/// Hows the much empresas.
		/// </summary>
		/// <returns>System.Int32.</returns>
		public static int HowMuchEmpresas()
        {      
            return totEmpresas;
        }

		//
		/// <summary>
		/// Adds the work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool AddEmpresa(Objecto.FichaTecnicaEmpresa e)
        {
			if (e == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e); 

				try
				{

					if (multinacionais.ContainsKey(fe.Nif))
					{

						foreach (List<Empresa> lista in multinacionais.Values)
						{

							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
									return false;
							}
						}

						multinacionais[fe.Nif].Add(fe);

					}

					else
					{
						List<Empresa> listaEmpresas = new List<Empresa>();
						listaEmpresas.Add(fe);
						multinacionais.Add(e.Nif, listaEmpresas);
					}

					totEmpresas++;

					return true;
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



		//esta
		/// <summary>
		/// Dispenses the empresa.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns>False error | True good</returns>
		public static bool DipensesEmpresa(Objecto.FichaTecnicaEmpresa e)
        {
			if (e == null)
				return false;

			else
			{
				List<Empresa> aux = new List<Empresa>();
                Empresa fe = new Empresa(e);


				if (multinacionais.ContainsKey(e.Nif))
				{
					foreach (List<Empresa> chave in multinacionais.Values)
					{						 						
						foreach (Empresa empresa in chave)
						{								
							if (fe == empresa)
							{
								aux = chave;
								aux.Remove(empresa);
								multinacionais.Remove(fe.Nif);
								multinacionais.Add(fe.Nif, aux);
								totEmpresas--;
								return true;
							}
						}
					}

				}
			}
			


			return false;
        }

		//Como vai ser ordenado
		/// <summary>
		/// Sorts the work.
		/// </summary>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SortEmpresa()
        {             
            try
			{
				foreach (KeyValuePair<long,List<Empresa>> chave in multinacionais)
				{										  
					multinacionais[chave.Key].Sort();	  
				}


				return true;
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


		/// <summary>
		/// Searches for determinate work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns>False error | True good and posicao of apiario</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SearchEmpresa(Objecto.FichaTecnicaEmpresa e)
        {
			if (e == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);

				try
				{
					if (multinacionais.ContainsKey(e.Nif))
					{
						foreach (KeyValuePair<long, List<Empresa>> chave in multinacionais)
						{
							foreach (Empresa empresa in multinacionais[chave.Key])
							{
								if (fe == empresa)
								{
									return true;
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

		//
		/// <summary>
		/// Compares the empresa.
		/// </summary>
		/// <param name="e1">The e1.</param>
		/// <param name="e2">The e2.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool CompareEmpresa(Objecto.FichaTecnicaEmpresa e1, Objecto.FichaTecnicaEmpresa e2)
        {
			if (e1 == null || e2 == null)
				return false;

			else
			{
				Empresa fe1 = new Empresa(e1);
				Empresa fe2 = new Empresa(e2);

				try
				{
					if (fe1 == fe2)
						return true;

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
		/// Guarda
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool EscreveFicheiro(string fileName = "multinacional.bin")
		{
			try
			{
				Stream strean = File.Open(fileName, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(strean, multinacionais);
				strean.Close();

				return true;
			}
			catch (Exception.MultinacionalException)
			{
				throw new Exception.MultinacionalException();
			}
			catch (IOException)
			{
				throw new IOException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}


		}

		/// <summary>
		/// Le
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LeFicheiro(string fileName = "multinacional.bin")
		{
			try
			{
				Stream strean = File.Open(fileName, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				multinacionais = (Dictionary<long,List<Empresa>>) bin.Deserialize(strean);
				strean.Close();

				return true;
			}
			catch (Exception.MultinacionalException)
			{
				throw new Exception.MultinacionalException();
			}
			catch (IOException)
			{
				throw new IOException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}


		}

		/// <summary>
		/// Limpa
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LimpaDicionario()
		{
			try
			{	  
				multinacionais.Clear();

				return true;
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

		/// <summary>
		/// Existes the empresa.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool ExisteEmpresa(Objecto.FichaTecnicaEmpresa e)
		{
			if (e == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);

				try
				{

					if (multinacionais.ContainsKey(fe.Nif))
					{		  
						foreach (List<Empresa> lista in multinacionais.Values)
						{	
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
									return true;
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
		/// Existes the apicultor.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool ExisteApicultor(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap)
		{
			if (e == null || ap == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e); 
				Apicultor apicultor = new Apicultor(ap);

				try
				{		 
					if (multinacionais.ContainsKey(fe.Nif))
					{
						foreach (List<Empresa> lista in multinacionais.Values)
						{
							foreach (Empresa empresa in lista)
							{
								if (fe == empresa)
								{
									foreach (Apicultor item in empresa.empregados)
									{
										if (apicultor == item)
										{
											return true;
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
		/// Existes the apiario.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool ExisteApiario(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
		{
			if (e == null || ap == null || a == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);
				Apiario apiario = new Apiario(a);

				try
				{
					if (multinacionais.ContainsKey(fe.Nif))
					{
						foreach (List<Empresa> lista in multinacionais.Values)
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
		/// Existes the colmeia.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool ExisteColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a,Objecto.FichaTecnicaColmeia c)
		{
			if (e == null || ap == null || a == null || c == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);
				Apiario apiario = new Apiario(a);  
				Colmeia colmeia = new Colmeia(c);

				try
				{
					if (multinacionais.ContainsKey(fe.Nif))
					{
						foreach (List<Empresa> lista in multinacionais.Values)
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
		/// Existes the accao.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <param name="ac">The ac.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.MultinacionalException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool ExisteAccao(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c, Objecto.Acao ac)
		{
			if (e == null || ap == null || a == null || c == null)
				return false;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);
				Apiario apiario = new Apiario(a);
				Colmeia colmeia = new Colmeia(c);

				try
				{
					if (multinacionais.ContainsKey(fe.Nif))
					{
						foreach (List<Empresa> lista in multinacionais.Values)
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


		#endregion

	}
}
