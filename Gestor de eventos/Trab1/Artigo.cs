// ***********************************************************************
// Assembly         : Trab1
// Author           : Utilizador
// Created          : 12-11-2015
//
// Last Modified By : Utilizador
// Last Modified On : 12-31-2015
// ***********************************************************************
// <copyright file="Artigo.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;



namespace Trab1
{
    /// <summary>
    /// Class Artigo.
    /// </summary>
    [Serializable]
    public class Artigo
    {
        #region Vars

        [NonSerialized]
        internal int totPessoas;    
        public const int QUANTIDADEPESSOAS = 10;   
        internal Pessoa[] pessoas;       
        internal string[] listaPessoas;   
        string nome;

        #endregion

        #region GetSet
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
        /// Gets or sets the lista pessoas.
        /// </summary>
        /// <value>The lista pessoas.</value>
        public string[] ListaPessoas
        {
            get { return listaPessoas; }
            set { listaPessoas = value; }
        }

        /// <summary>
        /// Gets or sets the pessoas.
        /// </summary>
        /// <value>The pessoas.</value>
        public Pessoa[] Pessoas
        {
            get { return pessoas; }
            set { pessoas = value; }
        }



        #endregion

        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="Artigo" /> class.
        /// </summary>
        public Artigo ()
        {
            nome = string.Empty;
            pessoas = new Pessoa[QUANTIDADEPESSOAS];
            listaPessoas = new string[QUANTIDADEPESSOAS];
            totPessoas = 0;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Artigo" /> class.
        /// </summary>
        /// <param name="nome">The nome.</param>
        public Artigo (string nome)
        {
            this.nome = nome;
            pessoas = new Pessoa[QUANTIDADEPESSOAS];
            listaPessoas = new string[QUANTIDADEPESSOAS];
            totPessoas = 0;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Escreves the artigo.
        /// </summary>
        /// <param name="a">a.</param>
        public void EscreveArtigo (Artigo a)
        {
            Console.WriteLine(a.ToString());
        }

        /// <summary>
        /// Escreves the proprio.
        /// </summary>
        public void EscreveProprio ()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Sees all pessoas.
        /// </summary>
        /// <param name="todosPessoas">The todos pessoas.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SeeAllPessoas (out Pessoa[] todosPessoas)
        {
            int lenght = Artigo.QUANTIDADEPESSOAS;
            todosPessoas = new Pessoa[lenght];

            if ( lenght == 0 )
                return false;


            for ( int i = 0; i < lenght; i++ )
            {
                todosPessoas[i] = pessoas[i];
            }
            return true;

        }

        /// <summary>
        /// Sees all pessoas.
        /// </summary>
        /// <param name="todosPessoas">The todos pessoas.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SeeAllPessoasAutor (out Pessoa[] todosPessoas)
        {
            int lenght = Artigo.QUANTIDADEPESSOAS;
            todosPessoas = new Pessoa[lenght];

            if ( lenght == 0 )
                return false;


            int x = 0;
            for ( int i = 0; i < lenght; i++ )
            {
                if ( pessoas[i].Tipo == TipoPessoa.autor )
                    todosPessoas[x++] = pessoas[i];

            }
            return true;

        }

        /// <summary>
        /// Sees all pessoas.
        /// </summary>
        /// <param name="todosPessoas">The todos pessoas.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SeeAllPessoasConvidado (out Pessoa[] todosPessoas)
        {
            int lenght = Artigo.QUANTIDADEPESSOAS;
            todosPessoas = new Pessoa[lenght];

            if ( lenght == 0 )
                return false;

            int x = 0;
            for ( int i = 0; i < lenght; i++ )
            {
                if ( pessoas[i].Tipo == TipoPessoa.convidado )
                    todosPessoas[x++] = pessoas[i];

            }
            return true;

        }

        /// <summary>
        /// Hows the much pessoas.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int HowMuchPessoas ()
        {
            return totPessoas;
        }

        /// <summary>
        /// Adds the pessoa.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddPessoa (Pessoa p)
        {
            if ( p == null )
                return false;
                                             
            if ( totPessoas == Artigo.QUANTIDADEPESSOAS )
                return false;

            if ( NaoRepetiuId(p) )
            {
                if ( pessoas.Contains(p) )
                    return false;

                pessoas[totPessoas] = p;
                listaPessoas[totPessoas] = p.Nome;
                totPessoas++;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Naoes the repetiu identifier.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool NaoRepetiuId (Pessoa p)
        {
            if ( p == null )
                return false;
                          
            int length = totPessoas;

            for ( int i = 0; i < length; i++ )
            {
                if ( p.NumeroPessoa == this.pessoas[i].NumeroPessoa )
                    return false;
            }    
            return true;
        }

        /// <summary>
        /// Dipenseses the pessoa.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DipensesPessoa (Pessoa p)
        {
            if ( p == null )
                return false;

            if ( 0 == totPessoas )
                return false;

            int posicao;

            if ( SearchPessoa(p, out posicao) )
            {
                pessoas[posicao] = null;
                listaPessoas[totPessoas] = null;
                totPessoas--;
                SortAll();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sorts the pessoas.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SortAll ()
        {
            Array.Sort(listaPessoas);
            Array.Sort(pessoas);
            return true;
        }

        /// <summary>
        /// Sorts the pessoas.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SortPessoas ()
        {
            //não precisa de ser organizado pois não existe nada para organizar
            if ( totPessoas == 0 )
                return false;

            int lenght = totPessoas;
            int i = 0;
            bool erro = true;
            int quantas = 0;


            while ( erro == true )
            {
                erro = false;

                if ( pessoas[i] == null
                    || pessoas[i] == pessoas[i + 1] )
                {
                    if ( quantas == 1 )
                        pessoas[i + 1] = null;

                    else
                    {
                        pessoas[i] = pessoas[i + 1];
                        quantas = 1;
                    }

                    erro = true;
                }

                else if ( i > 0 )
                    if ( pessoas[i - 1] == pessoas[i] )
                    {
                        erro = true;
                        pessoas[i] = pessoas[i + 1];

                    }

                i++;
                if ( i == (lenght) && erro == true )
                    i = 0;

            }

            //remove duplicados
            for ( i = 0; i < lenght; i++ )
            {
                if ( pessoas[i] == pessoas[i + 1] )
                    pessoas[i + 1] = null;
            }

            return true;


        }

        /// <summary>
        /// Searches the pessoa.
        /// </summary>
        /// <param name="ac">The ac.</param>
        /// <param name="posicaoPessoa">The posicao pessoa.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchPessoa (Pessoa ac, out int posicaoPessoa)
        {
            int tamanho = this.totPessoas;

            posicaoPessoa = -1;


            if ( tamanho == 0 || ac == null )
                return false;

            for ( int k = 0; k < tamanho; k++ )
            {
                if ( ac == pessoas[k] )
                {
                    //se tudo for verificado envia a posição do pessoa
                    posicaoPessoa = k;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Searches the name of the pessoa by.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="nomePessoa">The nome pessoa.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchPessoaByName (out Pessoa s, string nomePessoa)
        {
            int lenght = totPessoas;
            s = new Pessoa();

            if ( nomePessoa == null || lenght == 0 )
                return false;

            for ( int i = 0; i <= lenght; i++ )
            {
                if ( nomePessoa == this.pessoas[i].Nome )
                {
                    s = pessoas[i];
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Limpas the pessoas.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LimpaPessoas ()
        {
            totPessoas = 0;
            for ( int i = 0; i < QUANTIDADEPESSOAS; i++ )
            {
                pessoas[i] = null;
                listaPessoas[i] = null;    
            }

            return true;

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return ("Nome : " + Nome.ToString());
        }

        /// <summary>
        /// Compares the artigo.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CompareArtigo (Artigo pU, Artigo pD)
        {

            return (pU == pD);


        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Artigo pU, Artigo pD)
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
        public static bool operator !=(Artigo pU, Artigo pD)
        {
            if ( pU == null || pD == null )
                return false;

            return !(pU.nome == pD.nome);
        }


        #endregion

        #region Methods static

        /*
        public static bool SeeAllPessoas (Conferencia c, Sessao s, Artigo a, out Pessoa[] todosPessoas)
        {
            int lenght = Artigo.QUANTIDADEPESSOAS;
            todosPessoas = new Pessoa[lenght];
            int x = c.Inicio.DayOfYear - 1;
            int posicaoSessao, posicaoArtigo;

            if ( c == null || s == null || a == null || lenght == 0 )
                return false;

            if ( Sessao.SearchArtigo(c,s,a, out posicaoSessao, out posicaoArtigo) )
            {
                for ( int i = 0; i < lenght; i++ )
                {
                    todosPessoas[i] = OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i];
                }
                return true;
            }

            return false;
           
        }
                                            
        public static int HowMuchPessoas (Conferencia c, Sessao s, Artigo a)
        {
            if ( s == null || c == null || a == null )
                return 0;

            int posicaoSessao, posicaoArtigo;
            if ( Sessao.SearchArtigo(c, s, a, out posicaoSessao, out posicaoArtigo) )
            {

                if ( posicaoSessao == -1 || posicaoArtigo == -1 )
                    return 0;

                return OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].totPessoas;
            }

            else
                return 0;
        }

        public static bool AddPessoa (Conferencia c, Sessao s, Artigo a, Pessoa p)
        {       
            if ( c == null || a == null || s == null || p == null )
                return false;

            int length = Artigo.QUANTIDADEPESSOAS;
            int posicaoSessao, posicaoArtigo;

            if ( Sessao.SearchArtigo(c,s,a, out posicaoSessao, out posicaoArtigo) )
            {
                if ( length == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].totPessoas )
                    return false;

                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].totPessoas++;
                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[HowMuchPessoas(c,s,a) - 1] = p;

                return true;
            }
            return false;              
        }

                                                                                                                                                                
        public static bool DipensesPessoa (Conferencia c, Sessao s, Artigo a, Pessoa p)
        {
            if ( c == null || a == null || s == null || p == null )
                return false;
                                                    
            int posicaoSessao, posicaoArtigo, posicaoPessoa;

            if ( SearchPessoa(c, s, a, p, out posicaoSessao, out posicaoArtigo , out posicaoPessoa) )
            {
                if ( 0 == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].totPessoas )
                    return false;

                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[posicaoPessoa] = null;
                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].totPessoas--;
               
                return true;
            }
            return false;
        }
                          
        public static bool SortPessoas (Conferencia c, Sessao s, Artigo a)
        {
            if ( c == null || s == null || a == null )
                return false;

            int posicaoSessao, posicaoArtigo;
            Sessao.SearchArtigo(c, s, a, out posicaoSessao, out posicaoArtigo);

            if ( posicaoSessao == -1 )
                return false;

            //não precisa de ser organizado pois não existe nada para organizar
            if ( OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].totPessoas == 0 )
                return false;

            int lenght = HowMuchPessoas(c, s, a);
            int i = 0;
            bool erro = true;
            int quantas = 0;
            int x = c.Inicio.DayOfYear - 1;


            while ( erro == true )
            {
                erro = false;

                if ( OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i] == null
                    || OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i] == OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i+1] )
                {
                    if ( quantas == 1 )
                        OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i+1] = null;

                    else
                    {
                        OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i] = OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i+1];
                        quantas = 1;
                    }

                    erro = true;
                }

                else if ( i > 0 )
                    if ( OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i-1] == OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i] )
                    {
                        erro = true;
                        OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i] = OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i+1];

                    }

                i++;
                if ( i == (lenght) && erro == true )
                    i = 0;

            }

            //remove duplicados
            for ( i = 0; i < lenght; i++ )
            {
                if ( OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i] == OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[i+1] )
                    OrganizadorConferencias.conferenciasAno[x].sessoes[posicaoSessao].artigos[i + 1] = null;
            }

            return true;


        }    

        public static bool SearchPessoa (Conferencia c, Sessao s, Artigo a, Pessoa ac, out int posicaoSessao, out int posicaoArtigo, out int posicaoPessoa )
        {
            int tamanho = HowMuchPessoas(c,s,a);
            posicaoSessao = -1;
            posicaoArtigo = -1;
            posicaoPessoa = -1;

            if ( Sessao.SearchArtigo(c, s, a, out posicaoSessao, out posicaoArtigo) )
            {
                if ( c == null || s == null || a == null || tamanho == 0 || ac == null )
                    return false;

                for ( int k = 0; k < tamanho; k++ )
                {
                    if ( ac == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[posicaoSessao].artigos[posicaoArtigo].pessoas[k] )
                    {
                        //se tudo for verificado envia a posição do pessoa
                        posicaoPessoa = k;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool LimpaPessoas (Conferencia c,Sessao s, Artigo a)
        {
             if ( s == null || a == null )
                return false;

            else
            {
                int length = Conferencia.QUANTIDADESESSOES;

                for ( int i = 0; i < length; i++ )
                {
                    if ( s == c.sessoes[i] )
                    {             
                        int leng = Sessao.QUANTIDADEARTIGOS;

                        for ( int x = 0; x < leng; x++ )
                        {
                            if ( a == OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear -1].sessoes[i].artigos[x] )
                            {
                                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i].artigos[x].totPessoas = 0;
                                OrganizadorConferencias.conferenciasAno[c.Inicio.DayOfYear - 1].sessoes[i].artigos[x] = null;
                                Sessao.SortArtigo(c, s);
                                return true;
                            }
                        }
                        break;
                    }
                    
                }
                return false;
            }     
            
        }

        public override string ToString ()
        {
            return ("Nome : " + Nome.ToString());
        }

        public static bool CompareArtigo (Artigo pU, Artigo pD)
        {

            return (pU == pD);  


        }

        public static bool operator ==(Artigo pU, Artigo pD)
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

        public static bool operator !=(Artigo pU, Artigo pD)
        {
            if ( pU == null || pD == null )
                return false;

            return !(pU.nome == pD.nome);
        }       

               */
        #endregion
    }
}
