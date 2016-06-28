// ***********************************************************************
// Assembly         : Empresa
// Author           : Utilizador
// Created          : 05-18-2015
//
// Last Modified By : Utilizador
// Last Modified On : 05-26-2015
// ***********************************************************************
// <copyright file="Apiario.cs" company="">
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
	/// Class Apiario.
	/// </summary>
	[Serializable]
	public class Apiario
    {
		#region Vars

		/// <summary>
		/// The numero apiario
		/// </summary>
		int numeroApiario;
		/// <summary>
		/// The comeco apiario
		/// </summary>
		DateTime comecoApiario;
		/// <summary>
		/// The funcionario atribuido
		/// </summary>
		string funcionarioAtribuido;
		/// <summary>
		/// The latitude
		/// </summary>
		int latitude;
		/// <summary>
		/// The longitude
		/// </summary>
		int longitude;

		/// <summary>
		/// The tot colmeias
		/// </summary>
		[NonSerialized]
		internal int totColmeias = 0;

		/// <summary>
		/// The colmeias
		/// </summary>
		internal List<Colmeia> colmeias = new List<Colmeia>();
		#endregion

		#region GetSet

		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		public int Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public int Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

		/// <summary>
		/// Gets or sets the funcionario atribuido.
		/// </summary>
		/// <value>The funcionario atribuido.</value>
		public string FuncionarioAtribuido
	    {
		    get { return funcionarioAtribuido;}
            set { funcionarioAtribuido = value; }
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
		/// Gets or sets the comeco apiario.
		/// </summary>
		/// <value>The comeco apiario.</value>
		public DateTime ComecoApiario
        {
            get { return comecoApiario; }
            set { comecoApiario = value; }
        }


		#endregion

		#region Construct

		/// <summary>
		/// Initializes a new instance of the <see cref="Apiario" /> class.
		/// </summary>
		public Apiario()
        {
            numeroApiario = -1;
            comecoApiario = DateTime.MinValue;
            funcionarioAtribuido = String.Empty;
            latitude = 0;
            longitude = 0;
			colmeias = new List<Colmeia>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Apiario" /> class.
		/// </summary>
		/// <param name="numeroApiario">The numero apiario.</param>
		/// <param name="comecoApiario">The comeco apiario.</param>
		/// <param name="funcionarioAtribuido">The funcionario atribuido.</param>
		/// <param name="latitude">The latitude.</param>
		/// <param name="longitude">The longitude.</param>
		public Apiario(int numeroApiario,DateTime comecoApiario, string funcionarioAtribuido, int latitude, int longitude)
        {
            this.numeroApiario = numeroApiario;
            this.comecoApiario = comecoApiario;
            this.funcionarioAtribuido = funcionarioAtribuido;
            this.latitude = latitude;
            this.longitude = longitude;
			colmeias = new List<Colmeia>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Apiario"/> class.
		/// </summary>
		/// <param name="f">The f.</param>
		public Apiario(FichaTecnicaApiario f)
        {
            this.numeroApiario = f.NumeroApiario;
            this.comecoApiario = f.ComecoApiario;
            this.funcionarioAtribuido = f.FuncionarioAtribuido;
            this.latitude = f.Latitude;
            this.longitude = f.Longitude;
			colmeias = new List<Colmeia>();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sees all.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="todosColmeias">The todos colmeias.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="System.Exception"></exception>
		public static bool SeeAll(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a,ref List<string> todosColmeias)
		{
			string texto;
			if (e == null || ap == null || a == null )
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
											foreach (Apiario value in item.apiarios)
											{
												if (value == apiario)
												{
													foreach (Colmeia cc in value.colmeias)
													{
														texto = string.Empty;
														texto += cc.DataConstrucao.ToString() + "\n";
														texto += cc.NumeroApiario.ToString() + "\n";
														texto += cc.NumeroComeia.ToString() + "\n";
														todosColmeias.Add(texto);
													}
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
		/// Hows the much colmeias.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns>System.Int32.</returns>
		public static int HowMuchColmeias(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
        {
			if (e == null|| ap == null || a == null)
				return 0;

			else
			{
				Empresa fe = new Empresa(e);
				Apicultor apicultor = new Apicultor(ap);
				Apiario apiario = new Apiario(a);

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
												return value.totColmeias;
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
		/// Adds the work.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <param name="c">The c.</param>
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ApiarioException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool AddColmeias(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
        {
			if (e == null || a == null || ap == null)
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
						Colmeia cc = new Colmeia(c);

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
													value.colmeias.Add(cc);
													value.totColmeias++;
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

					else
						return false;
				}
				catch (Exception.ApiarioException)
				{
					throw new Exception.ApiarioException();
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
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ApiarioException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool DipensesColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
		{

			if (e == null || a == null || ap == null || c == null)
				return false;

			else
			{
				try
				{
					if (Multinacional.ExisteColmeia(e, ap, a,c))
					{
						Empresa fe = new Empresa(e);
						Apicultor apicultor = new Apicultor(ap);
						Apiario apiario = new Apiario(a);
						Colmeia cc = new Colmeia(c);


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
													value.colmeias.Remove(cc);
													value.totColmeias--;
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

					else
						return false;
				}
				catch (Exception.ApiarioException)
				{
					throw new Exception.ApiarioException();
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
		/// <returns>False error | True good</returns>
		/// <exception cref="Exception.ApiarioException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SortColmeias(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
        {									 
            try
            {
				if (e == null || ap == null || a == null)
					return false;

				else
				{
					if (Multinacional.ExisteApiario(e, ap,a))
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
													value.colmeias.Sort();	
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

					else
						return false;
				}
			}
			catch (Exception.ApiarioException)
			{
				throw new Exception.ApiarioException();
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
		/// <returns>False error | True good and posicao of apiario</returns>
		/// <exception cref="Exception.ApiarioException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool SearchColmeia(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a, Objecto.FichaTecnicaColmeia c)
        {
			try
			{
				if (e == null || a == null || ap == null || c == null)
					return false;

				else
				{
					if (Multinacional.ExisteColmeia(e, ap, a,c))
						return true;

					else
						return false;
				}

			}
			catch (Exception.ApiarioException)
			{
				throw new Exception.ApiarioException();
			}
			catch (System.Exception)
			{
				throw new System.Exception();
			}
		}


		/// <summary>
		/// Limpas the colmeias.
		/// </summary>
		/// <param name="e">The e.</param>
		/// <param name="ap">The ap.</param>
		/// <param name="a">a.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="Exception.ApiarioException"></exception>
		/// <exception cref="System.Exception"></exception>
		public static bool LimpaColmeias(Objecto.FichaTecnicaEmpresa e, Objecto.FichaTecnicaApicultor ap, Objecto.FichaTecnicaApiario a)
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
												value.colmeias.Clear();
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
				catch (Exception.ApiarioException)
				{
					throw new Exception.ApiarioException();
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
		public static bool operator ==(Apiario p1, Apiario p2)
        {
            return (p1.Latitude == p2.Latitude && p1.Longitude == p2.Longitude);
        }

		/// <summary>
		/// Implements the !=.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Apiario p1, Apiario p2)
        {
            return !(p1.Latitude == p2.Latitude && p1.Longitude == p2.Longitude);
        }

        #endregion
    }
}
