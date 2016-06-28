// ***********************************************************************
// Assembly         : Trab1
// Author           : Utilizador
// Created          : 12-11-2015
//
// Last Modified By : Utilizador
// Last Modified On : 12-31-2015
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;


namespace Trab1
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        //Uma conferencia pode ter uma pausa. Exemplo começa dia 1 - 12 - 2015 e acaba dia 5 - 12 -2015 no dia 4 pode não haver eventos.                                                                                           
        /*              
            Todos os ciclos serão aqui colocados                         
        */

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main (string[] args)
        {

            #region Vars  

            int opcaoMenu = -1;
            int opcaoSubMenu = -1;


            OrganizadorConferencias organizador = new OrganizadorConferencias();
            Conferencia conferencia = new Conferencia(DateTime.Parse("29-12-2015"), DateTime.Parse("30-12-2015"), "Work");
            Conferencia conferenciaU = new Conferencia(DateTime.Parse("29-12-2015"), DateTime.Parse("30-12-2015"), "Work1");
            Conferencia conferenciaI = new Conferencia(DateTime.Parse("29-12-2015"), DateTime.Parse("30-12-2015"), "Work2");
            Conferencia conferenciaO = new Conferencia(DateTime.Parse("29-12-2015"), DateTime.Parse("30-12-2015"), "Work3");
            Conferencia conferenciaP = new Conferencia(DateTime.Parse("29-12-2015"), DateTime.Parse("31-12-2015"), "Work4");   
            Sessao sessao = new Sessao(1, DateTime.Parse("30-12-2015"), DateTime.Parse("30-12-2015"));
            Artigo artigo = new Artigo("Programar");
            Pessoa pessoa = new Pessoa(34,"Luis",TipoPessoa.autor,1);
            Pessoa pessoaU = new Pessoa(21, "Parente", TipoPessoa.convidado,2);
            Pessoa pessoaI = new Pessoa(70, "Patente", TipoPessoa.convidado, 3);
            Pessoa pessoaP = new Pessoa(70, "Patente", TipoPessoa.convidado, 3);

            #endregion

            #region Body    

            do
            {
                RecebeOpcaoMenu(out opcaoMenu);

                switch ( opcaoMenu )
                {

                    #region 1

                    case 1:
                    do
                    {
                        Console.Clear();
                        organizador.EscreveProprio();

                        RecebeOpcaoSubMenu(out opcaoSubMenu);
                    } while ( opcaoSubMenu != 0 );

                    break;

                    #endregion

                    #region 2

                    case 2:
                    do
                    {
                        Console.Clear();
                        conferencia.EscreveProprio();
                        ComoCorreu(organizador.InsereConferenciaoAno(conferencia));
                        ComoCorreu(organizador.InsereConferenciaoAno(conferenciaU));
                        ComoCorreu(organizador.InsereConferenciaoAno(conferenciaI));
                        ComoCorreu(organizador.InsereConferenciaoAno(conferenciaO));
                        ComoCorreu(organizador.InsereConferenciaoAno(conferenciaP));
                        organizador.SeeAllConferencias();
                                                 

                        RecebeOpcaoSubMenu(out opcaoSubMenu);
                    } while ( opcaoSubMenu != 0 );

                    break;

                    #endregion

                    #region 3

                    case 3:
                    do
                    {
                        Console.Clear();
                        sessao.EscreveProprio();
                        ComoCorreu(conferencia.AddSessoes(sessao));

                        RecebeOpcaoSubMenu(out opcaoSubMenu);
                    } while ( opcaoSubMenu != 0 );

                    break;

                    #endregion

                    #region 4

                    case 4:
                    do
                    {
                        Console.Clear();
                        artigo.EscreveProprio();
                        ComoCorreu(sessao.AddArtigo(artigo));

                        RecebeOpcaoSubMenu(out opcaoSubMenu);
                    } while ( opcaoSubMenu != 0 );

                    break;

                    #endregion

                    #region 5

                    case 5:
                    do
                    {
                        Console.Clear();
                        ComoCorreu(artigo.AddPessoa(pessoa));
                        ComoCorreu(artigo.AddPessoa(pessoaU)); 
                        ComoCorreu(artigo.AddPessoa(pessoaI)); 
                        ComoCorreu(artigo.AddPessoa(pessoaP));
                        pessoa.EscreveProprio();

                        RecebeOpcaoSubMenu(out opcaoSubMenu);
                    } while ( opcaoSubMenu != 0 );

                    break;

                    #endregion

                    #region 0                     

                    case 0:
                    Environment.Exit(0);

                    break;

                    #endregion

                    #region Default

                    default:
                    Console.WriteLine("\nNot Found ");

                    break;

                    #endregion
                }

            } while ( true );

            #endregion

        }

        /*
        Atribuição genérica de valores estão em metodos

            Metodos:
        Recebe opcao do menu e submenu          

         */

        #region Methods          

        /// <summary>
        /// Comoes the correu.
        /// </summary>
        /// <param name="estado">if set to <c>true</c> [estado].</param>
        static void ComoCorreu (bool estado)
        {
            if ( estado == true )
                Console.WriteLine("Tudo bem");
            else
                Console.WriteLine("Tudo mal");

        }

        // Texto
        /// <summary>
        /// Menus this instance.
        /// </summary>
        static void Menu ()
        {
            Console.WriteLine("# 1 - Adicionar um organizador");
            Console.WriteLine("# 2 - Adicionar uma conferencia");
            Console.WriteLine("# 3 - Adicionar uma sessao");
            Console.WriteLine("# 4 - Adicionar um artigo");
            Console.WriteLine("# 5 - Adicionar uma pessoa");
            Console.WriteLine("# 0 - Sair");

        }

        //Mecanismo de recepção da opção
        /// <summary>
        /// Recebes the opcao menu.
        /// </summary>
        /// <param name="opcao">The opcao.</param>
        static void RecebeOpcaoMenu (out int opcao)
        {
            bool boleano;


            opcao = -1;
            boleano = false;
            Console.Clear();
            Menu();

            do
            {
                boleano = int.TryParse(Console.ReadLine(), out opcao);
            } while ( boleano != true );


        }

        //Texto
        /// <summary>
        /// Repetir | Sair
        /// </summary>
        static void SubMenu ()
        {
            Console.WriteLine("# 1 - Repetir");
            Console.WriteLine("# 0 - Sair");

        }

        //Mecanismo de recepção da sub opção
        /// <summary>
        /// Receive the sub opcao menu.
        /// </summary>
        /// <param name="opcaoSubMenu">The opcao sub menu.</param>
        static void RecebeOpcaoSubMenu (out int opcaoSubMenu)
        {
            bool boleano;

            opcaoSubMenu = -1;
            boleano = false;
           
            SubMenu();

            do
            {

                boleano = int.TryParse(Console.ReadLine(), out opcaoSubMenu);

            } while ( boleano != true );
            Console.Clear();
        }

        #endregion
    }
}
