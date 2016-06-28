// ***********************************************************************
// Assembly         : Trab1
// Author           : Utilizador
// Created          : 12-11-2015
//
// Last Modified By : Utilizador
// Last Modified On : 12-31-2015
// ***********************************************************************
// <copyright file="Conferencia.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;


namespace Trab1
{
    /// <summary>
    /// Class Conferencia.
    /// </summary>
    [Serializable]
    public class Conferencia
    {
        #region Vars
                         
        DateTime inicio;  
        DateTime fim;    
        string nome;     
        [NonSerialized]
        internal int totSessoes; 
        public const int QUANTIDADESESSOES = 3;  
        internal Sessao[] sessoes;        
        internal string[] listaSessoes; 

        #endregion

        #region Propriedades

        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        /// <value>The nome.</value>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Gets or sets the inicio.
        /// </summary>
        /// <value>The inicio.</value>
        public DateTime Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }
        /// <summary>
        /// Gets or sets the fim.
        /// </summary>
        /// <value>The fim.</value>
        public DateTime Fim
        {
            get { return fim; }
            set { fim = value; }
        }

        /// <summary>
        /// Gets or sets the lista sessoes.
        /// </summary>
        /// <value>The lista sessoes.</value>
        public string[] ListaSessoes
        {
            get { return listaSessoes; }
            set { listaSessoes = value; }
        }

        /// <summary>
        /// Gets or sets the sessoes.
        /// </summary>
        /// <value>The sessoes.</value>
        public Sessao[] Sessoes
        {
            get { return sessoes; }
            set { sessoes = value; }
        }

        #endregion

        #region Construct


        /// <summary>
        /// Initializes a new instance of the <see cref="Conferencia" /> class.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fim">The fim.</param>
        /// <param name="nome">The nome.</param>
        public Conferencia (DateTime inicio, DateTime fim, string nome)
        {
            sessoes = new Sessao[QUANTIDADESESSOES];
            listaSessoes = new string[QUANTIDADESESSOES];
            totSessoes = 0;

            if ( fim < inicio )
            {
                inicio = fim - TimeSpan.Parse("1");
            }


            this.inicio = inicio;
            this.fim = fim;
            this.nome = nome;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Conferencia" /> class.
        /// </summary>
        public Conferencia ()
        {
            sessoes = new Sessao[QUANTIDADESESSOES];
            listaSessoes = new string[QUANTIDADESESSOES];
            inicio = DateTime.MinValue;
            fim = DateTime.MaxValue;
            nome = string.Empty;
            totSessoes = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Escreves the conferencia.
        /// </summary>
        /// <param name="c">The c.</param>
        public void EscreveConferencia (Conferencia c)
        {
            Console.WriteLine(c.ToString());
        }

        /// <summary>
        /// Escreves the proprio.
        /// </summary>
        public void EscreveProprio ()
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Sees all sessoes.
        /// </summary>
        /// <param name="todasSessao">The todas sessao.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SeeAllSessoes (out Sessao[] todasSessao)
        {
            int lenght = this.totSessoes;
            todasSessao = new Sessao[lenght];

            for ( int i = 0; i < lenght; i++ )
                todasSessao[i] = sessoes[i];

            return true;


        }

        /// <summary>
        /// Hows the much sessoes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int HowMuchSessoes ()
        {
            return totSessoes;
        }

        /// <summary>
        /// Adds the sessoes.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddSessoes (Sessao s)
        {
            if ( s == null || this.inicio > s.Inicio || this.fim < s.Fim)
                return false;

                      
            if ( totSessoes == QUANTIDADESESSOES )
                return false;

            if ( sessoes.Contains(s) )
                return false;

            sessoes[totSessoes] = s;
            listaSessoes[totSessoes] = s.Assunto;
            totSessoes++;

            return true;
        }

        /// <summary>
        /// Dipenseses the sessoes.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DipensesSessoes (Sessao s)
        {
            if ( s == null )
                return false;

            int posicaoSessao;

            if ( SearchSessoes(s, out posicaoSessao) )
            {
                sessoes[posicaoSessao] = null;
                listaSessoes[totSessoes] = null;
                totSessoes--;
                //Tapa aqueles buracos onde é null
                SortAll();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Limpas the artigos.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LimpaSessoes ()
        {
            if ( totSessoes == 0 )
                return false;

            int length = QUANTIDADESESSOES;
            totSessoes = 0;
            for ( int i = 0; i < length; i++ )
            {
                sessoes[i] = null;
                listaSessoes = null; 
            }

            return true;
        }

        /// <summary>
        /// Sorts the sessoes.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SortSessoes ()
        {
            //não precisa de ser organizado pois não existe nada para organizar
            if ( totSessoes == 0 )
                return false;

            int lenght = totSessoes;
            int i = 0;
            bool erro = true;
            int quantas = 0;


            while ( erro == true )
            {
                erro = false;

                if ( sessoes[i] == null || sessoes[i] == sessoes[i + 1] )
                {
                    if ( quantas == 1 )
                        sessoes[i + 1] = null;

                    else
                    {
                        sessoes[i] = sessoes[i + 1];
                        quantas = 1;
                    }

                    erro = true;
                }

                else if ( i > 0 )
                    if ( sessoes[i - 1] == sessoes[i] )
                    {
                        erro = true;
                        sessoes[i] = sessoes[i + 1];

                    }

                i++;
                if ( i == (lenght) && erro == true )
                    i = 0;

            }

            //remove duplicados
            for ( i = 0; i < lenght; i++ )
            {
                if ( sessoes[i] == sessoes[i + 1] )
                    sessoes[i + 1] = null;
            }

            return true;

        }

        /// <summary>
        /// Sorts the sessoes.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SortAll ()
        {
            Array.Sort(this.sessoes);
            Array.Sort(this.listaSessoes);
            return true;

        }

        /// <summary>
        /// Searches the name of the sessoes by.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="nomeSessao">The nome sessao.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchSessoesByName (out Sessao s, string nomeSessao)
        {
            int lenght = totSessoes;
            s = new Sessao();

            if ( nomeSessao == null || lenght == 0 )
                return false;

            for ( int i = 0; i <= lenght; i++ )
            {
                if ( nomeSessao == sessoes[i].Assunto )
                {
                    s = sessoes[i];
                    return true;
                }
            }

            return false;
        }   

        /// <summary>
        /// Searches the sessoes.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="posicaoSessao">The posicao sessao.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchSessoes (Sessao s, out int posicaoSessao)
        {
            int lenght = totSessoes;
            posicaoSessao = -1;

            if ( s == null || lenght == 0 )
                return false;

            for ( int i = 0; i <= lenght; i++ )
            {
                if ( s == sessoes[i] )
                {
                    //se true vai retornar a posição da sessão
                    posicaoSessao = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return ("Inicio : " + Inicio.ToString() + "\nFim : " + Fim.ToString() + "\nNome : " + Nome.ToString());
        }

        /// <summary>
        /// Compares the conferencia.
        /// </summary>
        /// <param name="sU">The s u.</param>
        /// <param name="sD">The s d.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CompareConferencia (Conferencia sU, Conferencia sD)
        {
            return (sU == sD);

        }       

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Conferencia pU, Conferencia pD)
        {
            // If left hand side is null...
            if ( System.Object.ReferenceEquals(pU, null) )
            {
                // ...and right hand side is null...
                if ( System.Object.ReferenceEquals(pD, null) )
                {
                    //...both are null and are Equal.
                    return true;
                }

                // ...right hand side is not null, therefore not Equal.
                return false;
            }

            // Return true if the fields match:
            return pU.Equals(pD);
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Conferencia pU, Conferencia pD)
        {
            if ( pU == null || pD == null )
                return false;
            return !(pU.nome == pD.nome && pD.inicio == pU.inicio);
        }

        #endregion

        #region Methods static
        /*
       public static bool SeeAllSessoes (Conferencia c, out Sessao[] todasSessao )
       {        
           int lenght = HowMuchSessoes(OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1]);
           todasSessao = new Sessao[lenght];

           if ( c == null || lenght == 0)
               return false;            


           for ( int i = 0; i < lenght; i++ )
               todasSessao[i] = OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i];

           return true;


       }

       public static int HowMuchSessoes(Conferencia c)
       {
           if ( c == null )
               return 0;

           return OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].totSessoes;
       }

       public static bool AddSessoes (Conferencia c,Sessao s)
       {      
           if (c == null || s == null ||OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].totSessoes == QUANTIDADESESSOES )
               return false;


           OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[HowMuchSessoes(c)] = s;
           OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].totSessoes++;

           return true;
       }

       public static bool DipensesSessoes (Conferencia c, Sessao s)
       {
           if ( c == null || s == null )
               return false;

           int posicaoSessao;

           if ( SearchSessoes(c,s, out posicaoSessao) )
           {
               OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[posicaoSessao] = null;
               OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].totSessoes--;
               //Tapa aqueles buracos onde é null
               SortSessoes(c);
               return true;
           }

           return false;
       }

       public static bool SortSessoes (Conferencia c)
       {
           if ( c == null )
               return false;

           //não precisa de ser organizado pois não existe nada para organizar
           if ( OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].totSessoes == 0 )
               return false;

           int lenght = HowMuchSessoes(c);
           int i = 0;
           bool erro = true;
           int quantas = 0;


           while (  erro == true )
           {
               erro = false;

               if ( OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] == null || OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] == OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i + 1] )
               {
                   if ( quantas == 1 )
                       OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i + 1] = null;

                   else
                   {
                       OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] = OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i + 1];
                       quantas = 1;
                   }

                   erro = true;
               }

               else if(i > 0)
                   if (  OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i - 1] == OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] )
                   {
                       erro = true;
                       OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] = OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i + 1];

                   }

               i++;
               if ( i == (lenght ) && erro == true )
                   i = 0;

           }

           //remove duplicados
           for ( i = 0; i < lenght; i++ )
           {
               if ( OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] == OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i + 1] )
                   OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i + 1] = null;
           }

           return true;

       }

       public static bool SearchSessoes (Conferencia c, Sessao s, out int posicaoSessao)
       {               
           int lenght = HowMuchSessoes(c);
           posicaoSessao = -1;

           if ( c == null || s == null || lenght == 0 )
               return false;

           for ( int i = 0; i <= lenght; i++ )
           {
               if ( s == OrganizadorConferencias.conferenciasAno[c.inicio.DayOfYear - 1].sessoes[i] )
               {
                   //se true vai retornar a posição da sessão
                   posicaoSessao = i;
                   return true;
               }
           }

           return false;  
       }

       public override string ToString ()
       {
           return ("Inicio : " + Inicio.ToString() + "\nFim : " + Fim.ToString() + "\nNome : " + Nome.ToString());
       }

       public static bool CompareConferencia (Conferencia sU, Conferencia sD)
       {
           return (sU  == sD);

       }


       public static bool operator ==(Conferencia pU, Conferencia pD)
       {
           // If left hand side is null...
           if ( System.Object.ReferenceEquals(pU, null) )
           {
               // ...and right hand side is null...
               if ( System.Object.ReferenceEquals(pD, null) )
               {
                   //...both are null and are Equal.
                   return true;
               }

               // ...right hand side is not null, therefore not Equal.
               return false;
           }

           // Return true if the fields match:
           return pU.Equals(pD);                                                                           
       }

       public static bool operator !=(Conferencia pU, Conferencia pD)
       {
           if ( pU == null || pD == null )
               return false;
           return !(pU.nome == pD.nome && pD.inicio == pU.inicio);
       }


          */
        #endregion

    }
}
