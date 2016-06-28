// ***********************************************************************
// Assembly         : Trab1
// Author           : Utilizador
// Created          : 12-11-2015
//
// Last Modified By : Utilizador
// Last Modified On : 12-31-2015
// ***********************************************************************
// <copyright file="Sessao.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;


namespace Trab1
{
    /// <summary>
    /// Class Sessao.
    /// </summary>
    [Serializable]
    public class Sessao
    {

        #region Vars
                       
        string assunto; 
        string local;   
        string area;    
        int idSessao; 
        DateTime inicio;
        DateTime fim;   
        [NonSerialized]
        internal int totArtigos;
        public const int QUANTIDADEARTIGOS = 2; 
        internal Artigo[] artigos;      
        internal string[] listaArtigos;  

        #endregion

        #region Propriedades

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        public string Area
        {
            get { return area; }
            set { area = value; }
        }


        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>The local.</value>
        public string Local
        {
            get { return local; }
            set { local = value; }
        }

        /// <summary>
        /// Gets or sets the assunto.
        /// </summary>
        /// <value>The assunto.</value>
        public string Assunto
        {
            get { return assunto; }
            set { assunto = value; }
        }

        /// <summary>
        /// Gets or sets the identifier sessao.
        /// </summary>
        /// <value>The identifier sessao.</value>
        public int IdSessao
        {
            get { return idSessao; }
            set { idSessao = value; }
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
        /// Gets or sets the lista artigos.
        /// </summary>
        /// <value>The lista artigos.</value>
        public string[] ListaArtigos
        {
            get { return listaArtigos; }
            set { listaArtigos = value; }
        }


        /// <summary>
        /// Gets or sets the artigos.
        /// </summary>
        /// <value>The artigos.</value>
        public Artigo[] Artigos
        {
            get { return artigos; }
            set { artigos = value; }
        }

        #endregion

        #region Construct  

        /// <summary>
        /// Initializes a new instance of the <see cref="Sessao" /> class.
        /// </summary>
        public Sessao ()
        {
            assunto = String.Empty;
            local = String.Empty;
            area = String.Empty;
            inicio = DateTime.MinValue;
            fim = DateTime.MaxValue;
            artigos = new Artigo[QUANTIDADEARTIGOS];
            listaArtigos = new string[QUANTIDADEARTIGOS];
            idSessao = -1;
            totArtigos = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sessao" /> class.
        /// </summary>
        /// <param name="s">The s.</param>
        public Sessao (Sessao s)
        {
            if ( fim < inicio )
            {
                inicio = fim - TimeSpan.Parse("1");
            }
            this.inicio = s.inicio;
            this.fim = s.fim;
            this.area = s.area;
            this.local = s.local;
            this.assunto = s.assunto;
            this.idSessao = s.idSessao;
            totArtigos = s.totArtigos;
            listaArtigos = s.listaArtigos;
            artigos = s.artigos;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sessao" /> class.
        /// </summary>
        /// <param name="idSessao">The identifier sessao.</param>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fim">The fim.</param>
        /// <param name="local">The local.</param>
        /// <param name="assunto">The assunto.</param>
        /// <param name="area">The area.</param>
        public Sessao (int idSessao, DateTime inicio, DateTime fim, string local = "Barcelos", string assunto = "Medical health", string area = "Saude")
        {
            if ( fim < inicio )
            {
                inicio = fim - TimeSpan.Parse("1");
            }
            this.inicio = inicio;
            this.fim = fim;
            this.area = area;
            this.local = local;
            this.assunto = assunto;
            this.idSessao = idSessao;
            totArtigos = 0;
            listaArtigos = new string[QUANTIDADEARTIGOS];
            artigos = new Artigo[QUANTIDADEARTIGOS];


        }


        #endregion

        #region Methods

        /// <summary>
        /// Escreves the sessao.
        /// </summary>
        /// <param name="s">The s.</param>
        public void EscreveSessao (Sessao s)
        {
            Console.WriteLine(s.ToString());
        }

        /// <summary>
        /// Escreves the proprio.
        /// </summary>
        public void EscreveProprio ()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Sees all.
        /// </summary>
        /// <param name="todosartigos">The todosartigos.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SeeAll (out Artigo[] todosartigos)
        {
            int lenght = totArtigos;
            todosartigos = new Artigo[lenght];

            if ( lenght == 0 )
                return false;

            for ( int i = 0; i < QUANTIDADEARTIGOS; i++ )
            {
                if ( artigos[i] == null )
                    continue;

                todosartigos[i] = artigos[i];

            }
            return true;

        }

        /// <summary>
        /// Hows the much artigo.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int HowMuchArtigo ()
        {
            return totArtigos;
        }

        /// <summary>
        /// Adds the artigo.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddArtigo (Artigo a)
        {
            if (a == null )
                return false;

            if ( totArtigos == QUANTIDADEARTIGOS )
                return false;
         
                if ( artigos.Contains(a) )
                    return false;

                artigos[totArtigos] = a;
                listaArtigos[totArtigos] = a.Nome;
                totArtigos++;

                return true;                              
        }

        /// <summary>
        /// Dipenseses the artigo.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DipensesArtigo (Artigo a)
        {
            if ( a == null )
                return false;

            int posicaoArtigo;

            if ( SearchArtigo(a, out posicaoArtigo) )
            {
                artigos[posicaoArtigo] = null;
                listaArtigos[posicaoArtigo] = null;
                totArtigos--;
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
        public bool LimpaArtigos ()
        {
            if ( totArtigos == 0 )
                return false;

            int length = QUANTIDADEARTIGOS;
            totArtigos = 0;
            for ( int i = 0; i < length; i++ )
            {
                artigos[i] = null;
                listaArtigos[i] = null;  
            }

            return true;
        }

        /// <summary>
        /// Searches the artigo.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="posicaoArtigo">The posicao artigo.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchArtigo (Artigo a, out int posicaoArtigo)
        {
            int tamanho = totArtigos;
            posicaoArtigo = -1;



            if ( a == null || tamanho == 0 )
                return false;

            for ( int k = 0; k < tamanho; k++ )
            {
                if ( a == artigos[k] )
                {
                    //se tudo for verificado envia a posição do trabalhador
                    posicaoArtigo = k;
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Searches the name of the artigo by.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="nomeArtigo">The nome artigo.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchArtigoByName (out Artigo s, string nomeArtigo)
        {
            int lenght = totArtigos;
            s = new Artigo();

            if ( nomeArtigo == null || lenght == 0 )
                return false;

            for ( int i = 0; i <= lenght; i++ )
            {
                if ( nomeArtigo == this.artigos[i].Nome )
                {
                    s = artigos[i];
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sorts all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SortAll ()
        {
            Array.Sort(artigos);
            Array.Sort(listaArtigos);
            return true;
        }

        /// <summary>
        /// Sorts the artigo.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SortArtigo ()
        {
            //não precisa de ser organizado pois não existe nada para organizar
            if ( totArtigos == 0 )
                return false;

            int lenght = totArtigos;
            int i = 0;
            bool erro = true;
            int quantas = 0;


            while ( erro == true )
            {
                erro = false;

                if ( artigos[i] == null
                    || artigos[i] == artigos[i + 1] )
                {
                    if ( quantas == 1 )
                        artigos[i + 1] = null;

                    else
                    {
                        artigos[i] = artigos[i + 1];
                        quantas = 1;
                    }

                    erro = true;
                }

                else if ( i > 0 )
                    if ( artigos[i - 1] == artigos[i] )
                    {
                        erro = true;
                        artigos[i] = artigos[i + 1];

                    }

                i++;
                if ( i == (lenght) && erro == true )
                    i = 0;

            }

            //remove duplicados
            for ( i = 0; i < lenght; i++ )
            {
                if ( artigos[i] == artigos[i + 1] )
                    artigos[i + 1] = null;
            }

            return true;


        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return ("Assunto : " + Assunto.ToString() + "\nLocal : " + Local.ToString() + "\nArea : " + Area.ToString() + "\nIDSessao : " + IdSessao.ToString() + "\nInicio : " + Inicio.ToString() + "\nFim : " + Fim.ToString());
        }

        /// <summary>
        /// Compares the sessoes.
        /// </summary>
        /// <param name="sU">The s u.</param>
        /// <param name="sD">The s d.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CompareSessoes (Sessao sU, Sessao sD)
        {
            return (sU == sD);
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Sessao pU, Sessao pD)
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
        public static bool operator !=(Sessao pU, Sessao pD)
        {
            if ( pU == null || pD == null )
                return false;
            return !(pU.IdSessao == pD.IdSessao);
        }

        #endregion

        #region Methods static

        /*
        public static bool SeeAll (Conferencia c, Sessao e, out Artigo[] todosartigos)
        {
            int lenght = HowMuchArtigo(c, e);
            todosartigos = new Artigo[lenght];

            if ( c == null || e == null || lenght == 0 )
                return false;

            int tamanho = Conferencia.HowMuchSessoes(c);
            int posicaoSessao;

            if ( Conferencia.SearchSessoes(c, e, out posicaoSessao) )
            {
                for ( int i = 0; i < tamanho; i++ )
                {

                    todosartigos[i] = OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[i];

                }
                return true;
            }
            return false;
        }
                                               
        public static int HowMuchArtigo (Conferencia c,Sessao e)
        {
            if (  e == null || c == null)
                return 0;

            int posicao;
            Conferencia.SearchSessoes(c,e,out posicao);

            if ( posicao == -1 )
                return 0;

            return OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicao].totArtigos ;  
        }

        public static bool AddArtigo (Conferencia c, Sessao e, Artigo a)
        {
            if ( c == null || e == null || a == null )
                return false;

            int length = Conferencia.QUANTIDADESESSOES;

            if ( length == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].totSessoes )
                return false;

            for ( int i = 0; i < length; i++ )
            {
                if ( e == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i] )
                {
                    //aumentamos a quantidade de artigos
                    OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i].totArtigos++;

                    //adiciona o artigo
                    OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i].artigos[HowMuchArtigo(c, e) - 1] = a;

                    return true;
                }
            }
            return false;

        }

        public static bool DipensesArtigo (Conferencia c, Sessao e, Artigo a)
        {
            if ( c == null || e == null || a == null )
                return false;                         

            if ( OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].totSessoes == 0 )
                return false;

            int posicaoSessao, posicaoArtigo;

            if ( SearchArtigo(c, e, a, out posicaoSessao, out posicaoArtigo) )
            {
                //diminuimos os trabalhadores
                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].totArtigos--;

                //eliminamos o trabalhador
                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo] = null;
                return true;
            }

            return false;

        }

        public static bool LimpaArtigos (Conferencia c, Sessao s)
        {
            if ( s == null || c == null)
                return false;

            else
            {
                int length = Conferencia.QUANTIDADESESSOES;

                for ( int i = 0; i < length; i++ )
                {
                    if ( s == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i] )
                    {

                        OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i].totArtigos = 0;
                        OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i] = null;
                        Conferencia.SortSessoes(c);

                        return true;
                    }
                }
                return false;
            }
        }

        public static bool SearchArtigo (Conferencia c,Sessao e, Artigo a, out int posicaoSessao , out int posicaoArtigo)
        {   
            int tamanho = HowMuchArtigo(c,e);
            posicaoArtigo = -1;
                                            

            if ( Conferencia.SearchSessoes(c, e, out posicaoSessao) )
            {
                if ( c == null || e == null || a == null || tamanho == 0 || posicaoSessao == -1 )
                    return false;   

                for ( int k = 0; k < tamanho; k++ )
                {
                    if ( a == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[k] )
                    {
                        //se tudo for verificado envia a posição do trabalhador
                        posicaoArtigo = k;
                        return true;
                    }
                }
            }
            return false;

        }
         
        public static bool SortArtigo (Conferencia c,Sessao e)
        {
            if ( c == null || e == null)
                return false;

            int posicaoSessao;
            Conferencia.SearchSessoes(c, e, out posicaoSessao);

            if ( posicaoSessao == -1 )
                return false;

            //não precisa de ser organizado pois não existe nada para organizar
            if ( OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].totArtigos == 0 )
                return false;

            int lenght = HowMuchArtigo(c,e);
            int i = 0;
            bool erro = true;
            int quantas = 0;
            int x = c.Inicio.DayOfYear - 1;


            while ( erro == true )
            {
                erro = false;

                if ( OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i] == null 
                    || OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i] == OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1] )
                {
                    if ( quantas == 1 )
                        OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1] = null;

                    else
                    {
                        OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i] = OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1];
                        quantas = 1;
                    }

                    erro = true;
                }

                else if ( i > 0 )
                    if ( OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i - 1] == OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i] )
                    {
                        erro = true;
                        OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i] = OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1];

                    }

                i++;
                if ( i == (lenght) && erro == true )
                    i = 0;

            }

            //remove duplicados
            for ( i = 0; i < lenght; i++ )
            {
                if ( OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i] == OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1] )
                    OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1] = null;
            }

            return true;


        }

        public override string ToString ()
        {               
            return ("Assunto : "+ Assunto.ToString()+ "\nLocal : " + Local.ToString() + "\nArea : " + Area.ToString() + "\nIDSessao : " + IdSessao.ToString() + "\nInicio : " + Inicio.ToString() + "\nFim : " + Fim.ToString()); 
        }

        public static bool CompareSessoes (Sessao sU, Sessao sD)
        {
            return (sU == sD);   
        }

        public static bool operator ==(Sessao pU, Sessao pD)
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

        public static bool operator !=(Sessao pU, Sessao pD)
        {
            if ( pU == null || pD == null )
                return false;
            return !(pU.IdSessao == pD.IdSessao);
        }
            */
        #endregion

    }
}
