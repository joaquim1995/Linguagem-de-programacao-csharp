/* Nome : Joaquim Cardoso
 * Numero : 10201
 * Contacto : joaquimcardoso12@hotmail.com
 * Disciplina : LP 1
 * Data de fabrico : 7/12/2014
 * 
 * Descrever : Este Projecto resolve a ficha de trabalho prático proposta pelo professor de LP1.
 *             
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metodos; //Dll com metoddos

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variaveis
            int subOpcao;
            string escolhaOp;
            int escolhaMenu;
            bool escolhaSubOpcao;            
            bool escolhaMenuBoleano;
            string escolhaMenuTexto;
            int escolhaSubMenu = 0;            
            string nomeFinal;
            int escolhaDetalhe = 0; // variavel para a escolha do sub menu na converçao de unidades

            #endregion
            
            do //repetição do programa enquando a opção nao for 0
            {
                #region Menu Principal

                //Metodo menu e ler a escolha
                Class1.Menu();                
                escolhaMenuTexto = Console.ReadLine();

                escolhaMenuBoleano = int.TryParse(escolhaMenuTexto, out escolhaMenu);//se for possivel transformar o numero
                if (escolhaMenuBoleano == true) escolhaMenu = int.Parse(escolhaMenuTexto);//transformar a string num numero

                else escolhaMenu = 9999;// dar um valor para entrar no default do switch

                #endregion

                #region Switch

                //Casos possiveis da escolha
                switch (escolhaMenu)
                {
                    case 1: // Array
                        Console.Clear(); //limpar ecra

                        #region Array

                            #region Vars                            
                        do
                        {
                            // variaveis
                            int[] numeros = { 10, 2, 3, 20 ,3};
                            int x = 3;
                            int[] quemMaior = { };
                            int[] quemMenor = { };
                            int tamanhoArray = 0;
                            int quantos = 0;
                            int procura = 3;                        
                            bool caso = false;
                            #endregion

                            #region Maior e Menor

                            //apresentar os valores do array
                            foreach (var value in numeros)
                            {
                                Console.Write("{0} ", value);                         
                            }

                            quemMaior = Class1.Maiores(numeros, x, quemMaior, out tamanhoArray);//chama o metodo para ver quem sao os maiores que x
                            Console.WriteLine("\nQuantos sao maior que {0} : {1}", x, tamanhoArray);
                            Console.WriteLine("Os numeros maiores que {0} são : ", x);
                            Class1.Foreach(quemMaior);// mosta quem são os maiores


                            quemMenor = Class1.Menores(numeros, x, quemMaior, out tamanhoArray);//chama o metodo para ver quem sao os menores que x
                            Console.WriteLine("\nQuantos sao menores que {0} : {1}", x, tamanhoArray);
                            Console.WriteLine("Os numeros menores que {0} são : ", x);
                            Class1.Foreach(quemMenor);// mosta quem são os menores

                        

                            #endregion

                            #region Quantos e Procurar numero

                            quantos = Class1.Quantos(numeros, x);//chama o metodo para ver quantos x existe
                            Console.WriteLine("\nQuantos nº {0} tem nossa array com numeros ? Tem : {1}", x, quantos);

                            Console.WriteLine("\nVai procurar o nº {0} no array.",procura);
                            caso = Class1.OndeEstaVerFal(numeros, procura, caso);//verifica se um numero procurado existe

                            if (caso == false)Console.WriteLine(caso);//se não houver o numero R: False
                            
                            else Class1.OndeEsta(numeros, procura);//chama o metodo para dizer a localização
                            
                            #endregion

                            #region Menu

                            //menu                            
                            Console.WriteLine("\n\n[1] - Voltar");
                            Console.WriteLine("[2] - Sair");
                            escolhaOp = Console.ReadLine();
                            escolhaSubOpcao = int.TryParse(escolhaOp,out subOpcao);

                            if (escolhaSubOpcao == true) subOpcao = int.Parse(escolhaOp);//transforma a string em numero

                            else escolhaOp = "não";//atribui uma palavra para a manipulação do "do while"

                            if (subOpcao == 1)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (subOpcao == 2) System.Environment.Exit(0);//sair

                            else escolhaOp = "não";

                            Console.Clear();
                        } while (escolhaOp == "não");

                        #endregion

                        #endregion
                        break;

                    case 2:  // Polinómo de grau 2
                        Console.Clear(); //limpar ecra

                        #region Polinómio de grau 2

                            #region Vars
                        do
                        {
                            //variaveis
                            int a = -2, b = 6, c = 20, xis = 3;
                            double resultadoEquacao, resultadoUm, resultadoDois, delta;
                            double resultadoDerivada;
                            #endregion

                            #region Formula resolvente e derivada

                            //Informar o  utilizador
                            Console.WriteLine("Para equação de grau 2 : A= {0} B= {1} C= {2}", a, b, c);
                            Console.WriteLine("Para Derivada : A= {0} B= {1} C= {2} X= {3}\n",a,b,c,xis);

                            //chamar o metodo
                            resultadoEquacao = Class1.Resultado(a, b, c, out resultadoUm, out resultadoDois, out delta);

                            //resultado
                            if (a != 0 && delta >= 0)
                            {                            
                                Console.WriteLine("Resultado um : {0}", resultadoUm);
                                Console.WriteLine("Resultado dois : {0}\n", resultadoDois);
                            }

                            //Mensagem de erro
                            else Console.WriteLine("Desculpe o numero A tem que ser diferente de 0 e o delta nao pode ser negativo");
                            
                            //chamar metodo
                            resultadoDerivada = Class1.Derivada(a, b, c, xis);

                            //resultado
                            Console.WriteLine("A derivada de '' {0}x^2 + {1}x + {2} '' = {3}", a,b,c,resultadoDerivada);

                            #endregion

                            #region Menu

                            //menu
                            Console.WriteLine("\n\n[1] - Voltar");
                            Console.WriteLine("[2] - Sair");
                            escolhaOp = Console.ReadLine();
                            escolhaSubOpcao = int.TryParse(escolhaOp, out subOpcao);

                            if (escolhaSubOpcao == true) subOpcao = int.Parse(escolhaOp);

                            else escolhaOp = "não";

                            if (subOpcao == 1)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (subOpcao == 2)
                            {
                                System.Environment.Exit(0);
                            }

                            Console.Clear();
                        } while (escolhaOp == "não");

                        #endregion

                        #endregion
                        break;

                    case 3:
                        Console.Clear(); //limpar ecra

                        #region Funções matemáticas

                            #region Vars

                        do
                        {
                            double somatorio = 0;
                            decimal factorial = 0, potencia = 0;
                            int limiteInferior = 1, limiteSuperior = 20, valor = 5, valorElevado = 3;
                        #endregion
                             
                            #region Resultados

                            //chama metodo e dá resultado
                            somatorio = Class1.Somatorio(limiteInferior, limiteSuperior);
                            Console.WriteLine("O somatorio é : {0}", somatorio);

                            //chama metodo e dá resultado
                            factorial = Class1.Factorial(valor);
                            Console.WriteLine("O factorial é : {0}", factorial);

                            //chama metodo e dá resultado
                            potencia = Class1.Potencia(valor, valorElevado);
                            Console.WriteLine("A potencia é : {0}", potencia);

                            #endregion

                            #region Menu

                            //menu
                            Console.WriteLine("\n\n[1] - Voltar");
                            Console.WriteLine("[2] - Sair");
                            escolhaOp = Console.ReadLine();
                            escolhaSubOpcao = int.TryParse(escolhaOp, out subOpcao);

                            if (escolhaSubOpcao == true) subOpcao = int.Parse(escolhaOp);

                            else escolhaOp = "não";

                            if (subOpcao == 1)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (subOpcao == 2)
                            {
                                System.Environment.Exit(0);
                            }

                            Console.Clear();
                        } while (escolhaOp == "não");

                            #endregion

                        #endregion
                        break;

                    case 4:
                        Console.Clear(); //limpar ecra  
                      
                        #region funções estatisticas

                            #region Vars
                        do
                        {
                            //variaveis
                            double[] valores = { 10, 20, 10, 2, 5, 2, 2, 2, 3, 3, 3, 4, 10, 10 };
                            double media = 0, desvio = 0, mediana = 0, maior = 0, menor = 0;
                            double[] moda;
                            int q = 0;

                        #endregion

                            #region Resultados

                            //chama metodo e apresenta valores
                            media = Class1.Media(valores, media);
                            Console.WriteLine("A média é : {0}", media.ToString("0.##"));//valor com duas casas decimais

                            //chama metodo
                            moda = Class1.Moda(valores);
                            
                            //apresentar os resultados de forma agradavel para o utilizador
                            foreach (var value in moda)
                            {
                                if (moda.Length > 1 && q >= 1)
                                {
                                    Console.Write(" e {0}", value);
                                    q++;
                                }  

                                if (moda.Length>1 && q == 0)
                                {
                                    Console.Write("A moda é : {0}", value);
                                    q++;
                                }

                                else if (moda.Length == 1)
                                {
                                    Console.WriteLine("A moda é : {0}", value);
                                }
                            }

                            //chama metodo e apresenta valores
                            desvio = Class1.CalculoDp(valores);
                            Console.WriteLine("\nO desvio padrão é : {0}", desvio.ToString("0.##"));

                            //chama metodo e apresenta valores
                            mediana = Class1.Mediana(valores);
                            Console.WriteLine("A mediana é : {0}", mediana.ToString("0.##"));

                            //chama metodo e apresenta valores
                            maior = Class1.Maior(valores);
                            Console.WriteLine("O maior é : {0}", maior.ToString("0.##"));

                            //chama metodo e apresenta valores
                            menor = Class1.Menor(valores);
                            Console.WriteLine("O menor é : {0}", menor.ToString("0.##"));

                            #endregion

                            #region Menu

                            //menu
                            Console.WriteLine("\n\n[1] - Voltar");
                            Console.WriteLine("[2] - Sair");
                            escolhaOp = Console.ReadLine();
                            escolhaSubOpcao = int.TryParse(escolhaOp, out subOpcao);

                            if (escolhaSubOpcao == true) subOpcao = int.Parse(escolhaOp);

                            else escolhaOp = "não";

                            if (subOpcao == 1)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (subOpcao == 2)
                            {
                                System.Environment.Exit(0);
                            }

                            Console.Clear();
                        } while (escolhaOp == "não");

                            #endregion

                        #endregion
                        break;

                    case 5:
                        Console.Clear(); //limpar ecra  
 
                        #region Conversor de unidades

                            #region Vars

                        //variaveis
                            double valorUm = 0, valorDois = 0, resultado = 0;
                            int valorTres = 0;
                            bool bole;
                            string temp;

                        #endregion

                            #region Resultado

                            do
                            {                            
                                do
                                {
                                    //ir buscas o menu das unidades  e ler o seu valor
                                    Class1.SubMenu();
                                    temp = Console.ReadLine();

                                    bole = int.TryParse(temp, out escolhaSubMenu);
                                    if (bole == true) escolhaSubMenu = int.Parse(temp);//string é um numero

                                    else escolhaSubMenu = 9999;// dar um valor para entrar no default do switch
                                    Console.Clear();//limpa ecra

                                } while (escolhaSubMenu == 9999);

                                Console.Clear();//Limpar ecra
                                do
                                {
                                    // vai buscar o menu do detalhe que queremos                    
                                    Class1.SubMenuUnidades(escolhaSubMenu, escolhaDetalhe, valorUm, valorDois, valorTres, resultado);
                                
                                } while (escolhaDetalhe != 0);  //abandona se o detalhe for sair (0)                        

                            } while (escolhaSubMenu != 0); //abandona se no menu unidades for sair (0)

                            #endregion

                        #endregion
                            break;


                    case 6: //paginas amarelas                      
                        Console.Clear(); //limpar ecra

                        #region Paginas amarelas

                            #region Vars
                        do
                        {
                            //variaveis
                            string nome = "Luis Mendonca Alberto Carvalho";

                        #endregion

                            #region Resultado

                            Console.WriteLine("Nome : {0}", nome);
                            nomeFinal = Class1.OrganizaNome(nome);
                            Console.WriteLine(nomeFinal);

                            #endregion

                            #region Menu

                            //menu
                            Console.WriteLine("\n\n[1] - Voltar");
                            Console.WriteLine("[2] - Sair");
                            escolhaOp = Console.ReadLine();
                            escolhaSubOpcao = int.TryParse(escolhaOp, out subOpcao);

                            if (escolhaSubOpcao == true) subOpcao = int.Parse(escolhaOp);

                            else escolhaOp = "não";

                            if (subOpcao == 1)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (subOpcao == 2)
                            {
                                System.Environment.Exit(0);
                            }

                            Console.Clear();
                        } while (escolhaOp == "não");

                            #endregion

                        #endregion
                        break;

                    //sair
                    case 0:
                        break;

                    // qualquer valor diferente dos de cima
                    default:
                        Console.Write("Valor nao conhecido.");
                        System.Threading.Thread.Sleep(350);//Espera meio segundo
                        Console.Clear();//limpa ecra
                        break;
                }
                #endregion

            } while (escolhaMenu != 0);
        }
    }
}