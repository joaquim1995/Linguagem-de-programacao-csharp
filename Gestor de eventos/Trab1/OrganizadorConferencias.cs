// ***********************************************************************
// Assembly         : Trab1
// Author           : Utilizador
// Created          : 12-11-2015
//
// Last Modified By : Utilizador
// Last Modified On : 12-31-2015
// ***********************************************************************
// <copyright file="OrganizadorConferencias.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;



namespace Trab1
{

    /// <summary>
    /// Class OrganizadorConferencias.
    /// </summary>
    [Serializable]
    public class OrganizadorConferencias
    {
        #region Vars                                      
                         
        internal const int MAXSIZE = 366;  
        internal const int ZERO = 0;     
        internal const int MAXHIGH = 4;  
        string nome;                    
        internal int totConferencias;   
        internal Conferencia[,] conferenciasAno;   
        internal string[] listaNomesConferencias;

        #endregion

        #region Propriedades

        /// <summary>
        /// Gets or sets the lista nomes conferencias.
        /// </summary>
        /// <value>The lista nomes conferencias.</value>
        public string[] ListaNomesConferencias
        {
            get { return listaNomesConferencias; }
            set { listaNomesConferencias = value; }
        }

        /// <summary>
        /// Gets or sets the conferencias ano.
        /// </summary>
        /// <value>The conferencias ano.</value>
        public Conferencia[,] ConferenciasAno
        {
            get { return conferenciasAno; }
            set { conferenciasAno = value; }
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

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizadorConferencias" /> class.
        /// </summary>
        public OrganizadorConferencias ()
        {
            this.conferenciasAno = new Conferencia[MAXSIZE, MAXHIGH];
            this.totConferencias = ZERO;
            this.listaNomesConferencias = new string[MAXSIZE* MAXHIGH];
            this.nome = "Organizador de eventos - IPCA";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizadorConferencias" /> class.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="nome">The nome.</param>
        public OrganizadorConferencias (Conferencia c, string  nome = "Investe")
        {
            this.conferenciasAno = new Conferencia[MAXSIZE, MAXHIGH];
            this.totConferencias = ZERO;
            this.listaNomesConferencias = new string[MAXSIZE * MAXHIGH];
            this.nome = nome;
            listaNomesConferencias[this.totConferencias++] = c.Nome;
            conferenciasAno[c.Inicio.DayOfYear - 1, ZERO] = c;
        }


        #endregion

        #region Methods 

        /// <summary>
        /// Sees all sessoes.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SeeAllConferencias( )
        {
            int lenght = 0 ;
            Conferencia[] todasConferencia = new Conferencia[totConferencias];

            for ( int i = 0; i < MAXSIZE; i++ )
            {
                for ( int x = 0; x < MAXHIGH; x++ )
                {
                    if ( this.conferenciasAno[i, x] == null ) ;     
                    else
                    {
                        if ( todasConferencia.Contains(conferenciasAno[i, x]) ) ;

                        else todasConferencia[lenght++] = conferenciasAno[i, x]; } 
                    }
            }

            return true;


        }

        /// <summary>
        /// Escreves the organizador.
        /// </summary>
        /// <param name="o">The o.</param>
        public void EscreveOrganizador (OrganizadorConferencias o)
        {
            Console.WriteLine(o.ToString());
        }

        /// <summary>
        /// Escreves the proprio.
        /// </summary>
        public void EscreveProprio ()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Inseres the conferenciao ano.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool InsereConferenciaoAno (Conferencia c)
        {
            int erro = 0;
            int colocadaPrimeira = 0;
            int x = ZERO;

            if ( c == null )
                return false;

            else
            {
                int limiteSup = c.Fim.DayOfYear - 1;
                int limiteInf = c.Inicio.DayOfYear - 1;
                int primeiraPosicao = -1;

                erro = Calculo(c);

                //existe um ou mais dias que acontece o evento
                if ( erro == (limiteSup - limiteInf) || erro >= 1 )
                {
                    erro = 0;
                    for ( int i = limiteInf; i <= limiteSup; i++ )
                    {
                        for ( x = ZERO; x < MAXHIGH; x++ )
                        {
                            //é o limite superior
                            if ( i == limiteSup )
                            {
                                //é a primeira vez que passa aqui?
                                if ( primeiraPosicao == -1 )
                                    primeiraPosicao = x;

                                //é nulo a posicao onde estamos ?
                                if ( null == conferenciasAno[i, x] )
                                {
                                    erro = 1;
                                    conferenciasAno[i, x] = c;
                                    break;
                                }

                                // é a ultima vez que vai passar aqui?
                                if ( erro == 0 && (x + 1 == MAXHIGH) )
                                {
                                    Conferencia newC = c;
                                    newC.Fim -= TimeSpan.Parse("1");
                                    if ( newC.Inicio > newC.Fim )
                                    {
                                        ApagaConferencia(c);
                                        break;
                                    }

                                    ApagaConferencia(c);
                                    if(InsereConferenciaoAno(newC))
                                    return true;
                                }

                            }
                            else
                            {
                                
                                //é nulo a posicao onde estamos ?
                                if ( null == conferenciasAno[i, x] )
                                { 
                                    //já foi inserida a conferencia nesse dia?
                                    if ( TemEstaConferenciaNoArray(c,i) )
                                        break;

                                    else
                                    {      
                                        if ( primeiraPosicao == -1 )
                                            primeiraPosicao = x;

                                        conferenciasAno[i, x] = c;
                                        break;
                                    }
                                }

                                if ( i == limiteInf && x + 1 == MAXHIGH && colocadaPrimeira == 0 )
                                {
                                    Conferencia newC = c;
                                    newC.Inicio += TimeSpan.Parse("1");
                                    if ( newC.Inicio > newC.Fim )
                                    {
                                        ApagaConferencia(c);
                                        break;
                                    }

                                    ApagaConferencia(c);
                                    if(InsereConferenciaoAno(newC))
                                    return true;
                                }
                            }
                        }
                    }
                    listaNomesConferencias[totConferencias++] = conferenciasAno[c.Inicio.DayOfYear - 1, primeiraPosicao].Nome;

                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Calculoes the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>System.Int32.</returns>
        private int Calculo (Conferencia c)
        {
            int erro = 0;
            int x = ZERO;
            int limiteSup = c.Fim.DayOfYear - 1;
            int limiteInf = c.Inicio.DayOfYear - 1;   

            //senao coloca a conferencia no seu devido lugar
            for ( int i = limiteInf; i <= limiteSup; i++ )
            {
                for ( x = ZERO; x < MAXHIGH; x++ )
                {
                    if ( TemEstaConferenciaNoArray(c, i) )
                        break;
                    if ( null == conferenciasAno[i, x] )
                    {   //a variavel erro está a funcionar como contador                        
                        erro++;
                        break;
                    }
                }
            }
            return erro;
        }

        /// <summary>
        /// Tems the conferencia number dia.
        /// </summary>
        /// <param name="dia">The dia.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TemConferenciaNumDia (DateTime dia)
         {
             if ( null != conferenciasAno[dia.DayOfYear - 1,ZERO])
                 return true;

             return false;
         }

        /// <summary>
        /// Tems the conferencia number dia.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TemEstaConferencia (Conferencia c)
        {
            if ( totConferencias == ZERO ) ;
            else if ( null == conferenciasAno[c.Inicio.DayOfYear - 1, ZERO] ) ;

            else
            {
                for ( int i = 0; i < MAXHIGH; i++ )
                {
                    if ( conferenciasAno[c.Inicio.DayOfYear - 1, i] == c )
                        return true;
                }
            }                 
            return false;
        }

        /// <summary>
        /// Tems the conferencia number dia.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="valor">The valor.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TemEstaConferenciaNoArray (Conferencia c, int valor)
        {
           
                for ( int i = 0; i < MAXHIGH; i++ )
                {
                    if ( conferenciasAno[valor, i] == c )
                        return true;
                }
           

            return false;
        }

        /// <summary>
        /// Apagas the conferencia.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ApagaConferencia (Conferencia c)
        {
            if ( ProcuraNaLista(c) )
            {
                int posicao;
             int diaIni = c.Inicio.DayOfYear -1;
             int diaFim = c.Fim.DayOfYear - 1;

            for ( int i = diaIni; i <= diaFim; i++ )
                for ( int x = 0; x < MAXHIGH; x++ )
                {
                    if ( Search(c, out posicao) )
                    {
                        if ( x + 1 == MAXHIGH )
                            conferenciasAno[i, x] = null;
                        else
                            conferenciasAno[i, x] = conferenciasAno[i, x + 1];                            
                    }
                }

                SortAll();
                for ( int i = 0; i < MAXHIGH * MAXSIZE; i++ )
                {
                    if ( this.listaNomesConferencias[i] == c.Nome  || this.listaNomesConferencias[i] == null )
                    {
                        if ( this.listaNomesConferencias[i] == null )
                            break;

                        this.totConferencias--;
                        break;
                    }
                }   
            
                return true;
            }

            return false;
        }

        /// <summary>
        /// Searches the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="posicao">The posicao.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Search (Conferencia c, out int posicao)
        {
            // Ou podemos fazer um simples for na lista.
            posicao = -1;
            int diaIni = c.Inicio.DayOfYear - 1;
            int diaFim = c.Fim.DayOfYear - 1;

            for (int i = diaIni; i <= diaFim; i++ )
                for ( int x = 0; x < MAXHIGH; x++ )
                {
                    if ( conferenciasAno[i, x] == c )
                    {
                        posicao = x;
                        return true;
                    }
                }

            return false;
        }

        /// <summary>
        /// Searches the name of the conferencia by.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="nomeConferencia">The nome conferencia.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SearchConferenciaByName (out Conferencia s, string nomeConferencia)
        {
            s = new Conferencia();

            if ( nomeConferencia == null || totConferencias == 0 )
                return false;

            for ( int i = 0; i < MAXSIZE; i++ )
            {
                for ( int x = 0; x < MAXHIGH; x++ )
                {                     
                    if ( this.conferenciasAno[i, x] != null && nomeConferencia == this.conferenciasAno[i, x].Nome )
                    {
                        s = conferenciasAno[i, x];
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Procuras the na lista.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ProcuraNaLista (Conferencia c)
        {
            int comp =  listaNomesConferencias.Length;
            for ( int i = 0; i < comp; i++ )
            {
                if ( listaNomesConferencias[i] == c.Nome )
                    return true;
            }
                     
            return false;
        }

        /// <summary>
        /// Procuras the na lista.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool  SortAll()
        {
            Array.Sort(listaNomesConferencias);
            return true;
        }

        /// <summary>
        /// Limpas the organizador.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LimpaOrganizador ()
        {
            if ( totConferencias == 0 )
                return false;
                                           
              conferenciasAno = null;
              listaNomesConferencias = null;
              totConferencias = 0;
               

            return true;
        }

        /// <summary>
        /// Les the ficheiro.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LeFicheiro (string fileName = "organizador.bin")
         {

             Stream strean = File.Open(fileName, FileMode.Open);
             BinaryFormatter bin = new BinaryFormatter();
             conferenciasAno = (Conferencia[,])bin.Deserialize(strean);
             strean.Close();

             return true;
         }

        /// <summary>
        /// Escreves the ficheiro.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool EscreveFicheiro (string fileName = "organizador.bin")
        {
            Stream strean = File.Open(fileName, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(strean, conferenciasAno);
            strean.Close();

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
        public static bool CompareArtigo (OrganizadorConferencias pU, OrganizadorConferencias pD)
        {

            return (pU == pD);


        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="pU">The p u.</param>
        /// <param name="pD">The p d.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(OrganizadorConferencias pU, OrganizadorConferencias pD)
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
        public static bool operator !=(OrganizadorConferencias pU, OrganizadorConferencias pD)
        {
            if ( pU == null || pD == null )
                return false;

            return !(pU.nome == pD.nome);
        }


        #endregion

        #region Methods Static
        /*
         public static bool InsereConferenciaoAno (Conferencia c)
         {
             if ( c == null )
                 return false;

             else
             {
                 int erro = 0;
                 int limiteSup = c.Fim.DayOfYear - 1;
                 int limiteInf = c.Inicio.DayOfYear - 1;

                 for ( int x = limiteInf; x <= limiteSup; x++ )
                 {
                     if ( conferenciasAno[x] == null )
                         continue;

                     else
                     {
                         erro = 2; //existe alguma conferencia nesse espaço de tempo.
                         break;
                     }
                 }

                 //se existe algum erro return false
                 if ( erro != 0 )
                     return false;

                 //senao coloca a conferencia no seu devido lugar
                 for ( int i = limiteInf; i <= limiteSup; i++ )
                     conferenciasAno[i] = c;
             }

             return true;
         }


         public static bool TemConferenciaNumDia (DateTime dia)
         {
             if ( null != conferenciasAno[dia.DayOfYear - 1])
                 return true;

             return false;
         }


         public static bool ApagaConferencia (Conferencia c)
         {
             int diaIni = c.Inicio.DayOfYear -1;
             int diaFim = c.Fim.DayOfYear - 1;

             for ( int i = diaIni; i <= diaFim; i++ )    
                 conferenciasAno[i] = null;

             OrganizadorConferencias.totConferencias--;
             return true;
         }


         public static bool EscreveFicheiro (string fileName = "organizador.bin")
         {
             Stream strean = File.Open(fileName, FileMode.Create);
             BinaryFormatter bin = new BinaryFormatter();
             bin.Serialize(strean, conferenciasAno);
             strean.Close();

             return true;

         }


         public static bool LeFicheiro (string fileName = "organizador.bin")
         {

             Stream strean = File.Open(fileName, FileMode.Open);
             BinaryFormatter bin = new BinaryFormatter();
             conferenciasAno = (Conferencia[])bin.Deserialize(strean);
             strean.Close();

             return true;
         }


          */

        #endregion
    }
}
