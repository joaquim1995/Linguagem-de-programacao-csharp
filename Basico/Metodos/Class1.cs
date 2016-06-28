using System;

namespace Metodos
{
    public class Class1
    {
        /// <summary>
        /// Menu principal
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("1 - Arrays");
            Console.WriteLine("2 - Polinómio de grau 2");
            Console.WriteLine("3 - Funções Matemáticas");
            Console.WriteLine("4 - Funções Estatisticas");
            Console.WriteLine("5 - Conversor de unidades");
            Console.WriteLine("6 - Paginas Amarelas");
            Console.WriteLine("0 - Sair");
        }

        /// <summary>
        /// Este metodo vai enviar os numeros maiores que x ,e com o out v vai dar a quantidade dos numeros maiores que x
        /// </summary>
        /// <param name="numeros">Uma array com 4 numeros aleatórios</param>
        /// <param name="x">Um valor introduzido para a verificação de condiçoes</param>
        /// <param name="mx">Array com os numeros maiores que x</param>
        /// <param name="v">Dimensão da array dos numeros maiores que x</param>
        /// <returns>array com os numeros maiores que x</returns>
        public static int[] Maiores(int[] numeros, int x, int[] mx, out int v)
        {
            //variavel que dará o tamanho da array dos numeros maiores que x
            v = 0;
            // variavel para a organização da array dos numeros maiores que x
            int j = 0;

            //verificar quantos numeros são maiores que x
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] > x)
                {
                    v++;
                }
            }

            // dar o tamanho a variavel que irá ter os numeros maiores que x
            mx = new int[v];

            //atribuir os valores maiores que x a uma variavel
            for (int i = 0; i < numeros.Length; i++)
            {

                if (numeros[i] > x)
                {
                    mx[j++] = numeros[i];
                }
            }
            return (mx);
        }

        /// <summary>
        /// Ler os valores da array
        /// </summary>
        /// <param name="numeros">Array com numeros aleatórios</param>
        public static void Foreach(int[] numeros)
        {
            foreach (int value in numeros)
            {
                Console.WriteLine(value);
            }
        }

        /// <summary>
        /// Este metodo vai enviar os numeros menores que x ,e com o out v vai dar a quantidade dos numeros menores que x
        /// </summary>
        /// <param name="numeros">Uma array com 4 numeros aleatórios</param>
        /// <param name="x">Um valor introduzido para a verificação de condiçoes</param>
        /// <param name="mx">Array com os numeros menores que x</param>
        /// <param name="v">Dimensão da array dos numeros menores que x</param>
        /// <returns>array com os numeros menores que x</returns>
        public static int[] Menores(int[] numeros, int x, int[] mx, out int v)
        {
            //variavel que dará o tamanho da array dos numeros maiores que x
            v = 0;
            // variavel para a organização da array dos numeros maiores que x
            int j = 0;

            //verificar quantos numeros são maiores que x
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] < x)
                {
                    v++;
                }
            }

            // dar o tamanho a variavel que irá ter os numeros maiores que x
            mx = new int[v];

            //atribuir os valores maiores que x a uma variavel
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] < x)
                {
                    mx[j++] = numeros[i];
                }
            }
            return (mx);
        }

        /// <summary>
        /// Este metodo vai contar quantas vezes a array tem um numero procurado
        /// </summary>
        /// <param name="numeros">Array com numeros aleatório</param>
        /// <param name="x">numero procurado</param>
        /// <returns>a quantidade de numeros procurado</returns>
        public static int Quantos(int[] numeros, int x)
        {
            int quantos = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                //se o numero procurado estiver na array ira ser incrementado uma variavel afim de contar quantos numeros procurado existem na array
                if (numeros[i] == x)
                {
                    quantos++;
                }
            }
            return quantos;
        }

        /// <summary>
        /// Este metodo irá verificar se existe ou nao um determinado numero e returna a existencia (true or false)
        /// De padrao ele recebe um false
        /// </summary>
        /// <param name="numeros">Array com numeros aleatórios</param>
        /// <param name="procura">Numero introduzido pelo utilizador que irá ser procurado na array</param>
        /// <param name="caso">verificação boleana</param>
        /// <returns>True or false dependendo da existencia do numero procurado</returns>
        public static bool OndeEstaVerFal(int[] numeros, int procura, bool caso)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                //se numero que procura pertencer á array return true
                if (numeros[i] == procura)
                {
                    caso = true;
                }
            }
            return caso;
        }

        /// <summary>
        /// Este metodo vai verificar em que posições se encontra o numero procurado
        /// </summary>
        /// <param name="numeros">Array com numeros aleatórios</param>
        /// <param name="procura">numero procurado</param>
        /// <param name="posicao">posição do numero procurado na array</param>
        /// <returns>a posição onde se encontra o numero procurado</returns>
        public static void OndeEsta(int[] numeros, int procura)
        {
            //contador
            int cont=1;

            //escrever os valores que sejam iguais ao numero procurado que é : 3
            foreach (var value in numeros)
            {
                if (value == procura)
                {
                    Console.WriteLine("\nO nº {0} encontrasse na {1}ª posição ", procura,cont);                    
                }
                cont++;
            }                
        }

        /// <summary>
        /// Este metodo faz a media aritmética dos valores de uma array
        /// </summary>
        /// <param name="valores">array com valores</param>
        /// <param name="contador">contador para fazer a divisao</param>
        /// <param name="media">valor da media</param>
        /// <returns>a media dos valores da array</returns>
        public static double Media(double[] valores, double media)
        {
            int contador = 0;
            //saber quantos valores tem a array
            for (int i = 0; i < valores.Length; i++)
            {
                media += valores[i];
                contador++;
            }
            media = media / contador;
            return media;
        }

        /// <summary>
        /// Este metodo recebe valores e define a moda
        /// </summary>
        /// <param name="valores">Array com valores aleatorios</param>        
        /// <returns>returna a moda</returns>
        public static double[] Moda(double[] valores)
        {
            double aux;
            double[,] contador;

            //ordena a array
            for (int k = 0; k <= valores.Length - 2; k++)
            {
                for (int i = 0; i <= valores.Length - 2; i++)
                {
                    if (valores[i] > valores[i + 1])
                    {
                        aux = valores[i];
                        valores[i] = valores[i + 1];
                        valores[i + 1] = aux;
                    }
                }
            }

            //dar os quem se repete em [x,0] e quantas vezes se repete [x,1]
            int j = 0, l = 0, h = 2;
            contador = new double[6, 2];
            
            for (int i = 1; i < valores.Length; i++)
            {
                if (i == 1)
                {
                    contador[j, l] = valores[0];
                }
                else
                {
                    if (valores[i] != valores[i - 1])
                    {
                        j++;
                        contador[j, l] = valores[i];

                        h = 1;
                    }

                    else
                    {
                        if (valores[i] == valores[i - 1])
                        {
                            contador[j, l + 1] = ++h;
                        }
                        else
                        {
                        }
                    }
                }
            }

            //bug do codigo aparecem numeros com repetiçoes = 0 entao colocamos as repetiçoes em 1
            for (int i = 0; i < (contador.Length / 2); i++)
            {
                if (contador[i, 1] == 0)
                {
                    contador[i, 1] = 1;
                }
            }
            

            //organizar de forma decrescente os numeros da moda
            //2 vezes pois é bidimencional
            int tmp;
            for (int i = 0; i < 2; i++)
            {
                //fazer por linhas
                for (int o = 0; o < contador.Length / 2; o++)
                {
                    //fazer por colunas
                    for (int p = 0; p < contador.Length / 2; p++)
                    {
                        if (contador[o, 1] > contador[p, 1])
                        {
                            tmp = (int)contador[p, 1];
                            contador[p, 1] = contador[o, 1];
                            contador[o, 1] = tmp;

                            tmp = (int)contador[p, 0];
                            contador[p, 0] = contador[o, 0];
                            contador[o, 0] = tmp;
                        }

                    }

                }

            }


            //saber quantos são numeros são a moda
            int cont = 1;
            int[] contaPosicao = new int[1] { 0 };

            for (int i = 0; i < (contador.Length / 2) - 1; i++)
            {
                if (i == 0 && contador[i + 1, 1] < contador[i, 1])
                {
                    cont = 1;
                    break;
                }

                if ((contador[i, 1] == contador[i + 1, 1]) && contaPosicao[0] == 0)
                {
                    cont++;
                }
                else
                {
                    contaPosicao[0] = 1;
                }

            }
            double[] moda = new double[cont];

            //dizer quem sao os numeros da moda
            int b = 0;
            int conta = 0;
            for (int i = 0; i < (contador.Length / 2) - 1; i++)
            {
                if (i == 0)
                {
                    moda[b] = contador[i, 0];
                    b++;
                    conta++;
                }

                if (contador[i, 1] <= contador[i + 1, 1])
                {
                    if (contador[conta - 1, 1] == contador[conta, 1])
                    {
                        moda[b] = contador[conta, 0];
                        b++;
                        conta++;
                    }
                }
            }
            return moda;
        }           

        /// <summary>
        /// Este metodo calcula o desvio padrao
        /// </summary>
        /// <param name="valores">Array com valores aleatórios</param>
        /// <returns>desvio padrao</returns>
        public static double CalculoDp(double[] valores)
        {
            //Tira a média
            double media = SomaMatrix(valores) / valores.Length;

            // cálculo do (x - xMedio)^2
            double[] aux = new double[valores.Length]; //variavel que armazena (x - xMedio)^2

            for (int i = 0; i < valores.Length; i++)
            {
                aux[i] = (media - valores[i]) * (media - valores[i]);// Calcula e armazena (x - xMedio)^2;
            }

            double desvioPadrao = Math.Sqrt(SomaMatrix(aux) / aux.Length);//Extrai a raiz quadrada da somatória de (x - xMedio)^2 dividido por N

            return desvioPadrao;
        }

        /// <summary>
        /// Procedimento para realizar somatória de matrizes 
        /// </summary>
        /// <param name="valores">Array de valores aleatorios</param>
        /// <returns>somatorio da matriz</returns>
        public static double SomaMatrix(double[] valores)
        {
            double soma = 0;//variável temporaria
            for (int i = 0; i < valores.Length; i++)
            {
                soma = soma + valores[i];
            }
            return soma;
        }

        /// <summary>
        /// Este metodo retorna a mediana
        /// </summary>
        /// <param name="valores">Array com valores aleatorios</param>
        /// <returns>mediana</returns>
        public static double Mediana(double[] valores)
        {
            double aux, mediana;

            //ordena a array
            for (int k = 0; k <= valores.Length - 2; k++)
            {
                for (int i = 0; i <= valores.Length - 2; i++)
                {
                    if (valores[i] > valores[i + 1])
                    {
                        aux = valores[i];
                        valores[i] = valores[i + 1];
                        valores[i + 1] = aux;
                    }
                }
            }
            aux = valores.Length;
            //se comprimento da array = par
            if (aux % 2 == 0)
            {
                aux = aux / 2;
                aux = aux - 0.5;
                mediana = (valores[(int)aux] + valores[(int)aux + 1]) / 2;
                return mediana;
            }
            else
            {
                // se comprimento da array = impar
                aux = (aux + 1) / 2;
                mediana = valores[(int)aux];
                return mediana;

            }

        }

        /// <summary>
        /// Este metodo devolve o maior numero na array
        /// </summary>
        /// <param name="valores">Array com valores aleatorios</param>
        /// <returns>maior</returns>
        public static double Maior(double[] valores)
        {
            double maior = -9999999999999999;
            //verificar o maior
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] > maior)
                {
                    maior = valores[i];
                }
            }

            return maior;
        }

        /// <summary>
        /// Este metodo devolve o menor numero na array
        /// </summary>
        /// <param name="valores">Array com valores aleatorios</param>
        /// <returns>menor</returns>
        public static double Menor(double[] valores)
        {
            double menor = 9999999999999999;
            //verificar o maior
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] < menor)
                {
                    menor = valores[i];
                }
            }

            return menor;
        }

        /// <summary>
        /// Este metodo returna o somatorio dada uma formula
        /// </summary>
        /// <param name="limiteInferior">Limite inferior </param>
        /// <param name="limiteSuperior">Limite superior</param>
        /// <returns>somatorio</returns>
        public static double Somatorio(int limiteInferior, int limiteSuperior)
        {
            double soma = 0;
            for (int i = limiteInferior; i <= limiteSuperior; i++)
            {
                soma += (i * i) + 1;
            }

            return soma;
        }

        /// <summary>
        /// Este metodo vai returnar o factorial segundo uma formula
        /// </summary>
        /// <param name="valor">valor para o calculo do facturial</param>
        /// <returns>factorial</returns>
        public static decimal Factorial(int valor)
        {
            int aux = 0;
            decimal factorial = 1;

            if (valor == 0)
            {
                factorial = 1;
                return factorial;

            }
            else if (valor > 0)
            {
                aux = valor * (valor - 1);
                for (int i = 1; i <= aux; i++)
                {
                    factorial *= i;

                }

                return factorial;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Este metodo vai returnar a potencia segundo uma formula
        /// </summary>
        /// <param name="valor">valor de x</param>
        /// <param name="valorElevado">valor do elevado</param>
        /// <returns>a potencia</returns>
        public static decimal Potencia(int valor, int valorElevado)
        {
            decimal resultado;
            double aux = 1;

            if (valorElevado == 0)
            {
                resultado = 1;
                return resultado;

            }
            else if (valorElevado > 0)
            {
                for (int i = 1; i <= valorElevado - 1; i++)//achar o valor entre parenteses da formula
                {
                    aux *= valor;
                }
                resultado = valor * (decimal)aux;
                return resultado;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// O metodo recebe um nome e returna uma string ordenada segundo uma regra
        /// </summary>
        /// <param name="nome">Um nome de uma pessoa</param>
        /// <returns>O nome tal e qual como as páginas amarelas</returns>
        public static string OrganizaNomeSplit(string nome)
        {
            //declarar string vazia
            string resultado = "";

            // Separa os nomes
            string[] nomes = nome.Split(' ');

            // fica com o ultimo nome
            resultado = nomes[nomes.Length - 1];

            // ultimo nome em maiusculas
            resultado = resultado.ToUpper();

            // adiciona o primeiro nome          
            resultado += ", " + nomes[0] + ", ";

            // adiciona iniciais dos nomes restantes , começa na posiçao 1 e acaba na penultima
            for (int i = 1; i < nomes.Length - 1; i++)
            {
                //nomes na posição i da strind e 0 do char
                resultado += nomes[i][0] + ". ";
            }

            return resultado;

        }

        public static string OrganizaNome(string nome)
        {
            char [] nomes;
            char[] reverso;
            string resultado="";
            string resultadoSegundo = "";
            char[] resultadoSegundoNome;
            int ultimoNome = 0;

            ////se mais que um espaço colocar apenas um espaço
            //nome = nome.Replace("  "," ");            

            //colocar o nome numa array de char
            nomes = nome.ToCharArray();

            //Receber o apelido ao contrário
            for (int i = nomes.Length-1; i > 0; i--)
            {
                if (nomes[i] != ' ') resultado += nomes[i]; //recebe o ultimo nome ao contrário
               
                if (nomes[i] == ' ') break;
            }

            //colocar o nome ao contrario
            reverso = resultado.ToCharArray();
            resultado = "";
            for (int i = reverso.Length-1; i >= 0; i--)
            {
                resultado += reverso[i];                                
            }

            //dar o ultimo nome para uma array de char
            resultadoSegundoNome = resultado.ToCharArray();

            //zerar o ultimo nome e adicionar a primeira letra            
            resultadoSegundo = resultadoSegundo.ToUpper();// colocar a letra em grande
                        
            // adicionar o primeiro nome
            for (int i = 0; i < nomes.Length-1; i++)
            {
                if (nomes[i] != ' ') //recebe o 1o nome
                {
                    if (i == 0) //recebe o 1o nome
                    {                           
                        resultado += ", ";//formalidade
                        resultadoSegundo += nomes[i];
                        resultado = resultado.ToUpper() + resultadoSegundo.ToUpper() ;// ultimo nome em maiusculas e a 1a letra do 2o nome
                    }

                    else resultado += nomes[i];
                }

                if (nomes[i] == ' ')
                {
                    break;
                } 
            }

            //formalidade
            resultado += ", ";

            //saber quantas letras tem o ultimo nome 
            ultimoNome = reverso.Length;

            // adiciona iniciais dos nomes restantes , começa na posiçao 1 e acaba na penultima
            for (int i = 0; i < nomes.Length - 1; i++)
            {
                if (resultadoSegundoNome[0] == nomes[i+1] && ultimoNome+i+1 == nomes.Length) break;

                if (nomes[i] == ' ') resultado += nomes[i + 1] + ". ";  //se tiver um espaço adiciona a procima letra                 
            }

            return resultado;
        }

        /// <summary>
        /// Este metodo vai atraver da formula dar o resultado aplicando a formula resolvente de 3 numeros 
        /// </summary>
        /// <param name="a">valor a</param>
        /// <param name="b">valor b</param>
        /// <param name="c">valor c</param>
        /// <param name="resultadoUm">resultado um</param>
        /// <param name="resultadoDois">resultado dois</param>
        /// <param name="delta">valor para a raiz quadrada</param>
        /// <returns>nada ou 0</returns>
        public static double Resultado(int a, int b, int c, out double resultadoUm, out double resultadoDois,out double delta)
        {   
            delta = (b*b) - (4 * a * c); 
              
            resultadoUm = (-b + Math.Sqrt(delta)) / (2 * a);          
            resultadoDois = (-b - Math.Sqrt(delta)) / (2 * a); 
             
            return 0;
            
        }

        /// <summary>
        /// Este metodo recebe valores e deriva a funçao de grau 2
        /// </summary>
        /// <param name="a">Valor dado pelo utilizador</param>
        /// <param name="b">Valor dado pelo utilizador</param>
        /// <param name="c">Valor dado pelo utilizador</param>
        /// <returns>Uma string com a derivada</returns>
        public static double Derivada(int a, int b, int c, int x)
        {
            int resultadoDerivada=0;
            // f(x) = (ax^2 + bx + c) <=> f'(x)= (a*2)x + b + 0
            resultadoDerivada = (((a*2) * x) + (b)); 

            return resultadoDerivada;
        }

        /// <summary>
        /// Menu das Unidades, ou seja um submenu se a 5ª opção for escolhida no menu
        /// </summary>
        public static void SubMenu()
        {
            Console.WriteLine("1 - Unidades de comprimento");
            Console.WriteLine("2 - Unidades de energia");
            Console.WriteLine("3 - Unidades de temperatura");
            Console.WriteLine("4 - Unidades de velocidade");
            Console.WriteLine("0 - Sair");
        }

        /// <summary>
        /// Este metodo vai ser fruto da escolha do utilizador apos entrar na 5ª opcao do menu.
        /// A escolha do utilizador no submenu vai dar a um outro menu detalhado com a ação que quer executar
        /// Apos a escolha da ação é chamado o devido metodo.
        /// </summary>
        /// <param name="escolhaSubMenu">Valor dado pelo utilizador para a escolha do submenu</param>
        /// <param name="escolhaDetalhe">Valor dado pelo utilizador para a escolha do menu das converçoes</param>
        /// <param name="valorUm">Valor pedido ao utilizador</param>
        /// <param name="valorDois">Valor pedido ao utilizador</param>
        /// <param name="valorTres">Valor pedido ao utilizador</param>
        /// <param name="resultado">resultado apos realizar a formula</param>
        public static void SubMenuUnidades(int escolhaSubMenu,int escolhaDetalhe, double valorUm, double valorDois, int valorTres, double resultado)
        {
            bool boleano;
            string aux;            

            switch (escolhaSubMenu)
            {
                case 1://Comprimento                        
                    do
                    {
                        do
                        {                  
                            Console.WriteLine("1 - Metros para Milimetros");
                            Console.WriteLine("2 - Milimetros para Metros ");
                            Console.WriteLine("0 - Sair ");                            
                            aux = Console.ReadLine();

                            boleano = int.TryParse(aux, out escolhaDetalhe);
                            if (boleano == true) escolhaDetalhe = int.Parse(aux);//string é um numero

                            else escolhaDetalhe = 9999;// dar um valor para entrar no default do switch
                            Console.Clear();//limpa ecra

                        } while (escolhaDetalhe == 9999);

                        Console.Clear(); //limpar ecra

                        EscolhaDetalheC(escolhaDetalhe, valorUm, valorDois, valorTres, resultado);

                    } while (escolhaDetalhe != 0);

                    break;

                case 2://Energia

                    do
                    {
                        do
                        {
                            Console.WriteLine("1 - Watt para Joule");
                            Console.WriteLine("2 - Joule para Watt ");
                            Console.WriteLine("0 - Sair ");
                            aux = Console.ReadLine();
                                
                            boleano = int.TryParse(aux, out escolhaDetalhe);                                
                            if (boleano == true) escolhaDetalhe = int.Parse(aux);//string é um numero
                               
                            else escolhaDetalhe = 9999;// dar um valor para entrar no default do switch                               
                            Console.Clear();//limpa ecra

                        } while (escolhaDetalhe == 9999);

                        Console.Clear(); //limpar ecra

                        EscolhaDetalheE(escolhaDetalhe, valorUm, valorDois, valorTres, resultado);

                    } while (escolhaDetalhe != 0);

                    break;

                case 3://Temperatura

                    do
                    {
                        do
                        {
                            Console.WriteLine("1 - Fahrenheit para Celcius");
                            Console.WriteLine("2 - Celcius para Fahrenheit  ");
                            Console.WriteLine("0 - Sair ");
                            aux = Console.ReadLine();

                            boleano = int.TryParse(aux, out escolhaDetalhe);
                            if (boleano == true) escolhaDetalhe = int.Parse(aux);//string é um numero

                            else escolhaDetalhe = 9999;// dar um valor para entrar no default do switch
                            Console.Clear();//limpa ecra

                        } while (escolhaDetalhe == 9999);

                        Console.Clear(); //limpar ecra

                        EscolhaDetalheT(escolhaDetalhe, valorUm, valorDois, valorTres, resultado);

                    } while (escolhaDetalhe != 0);

                    break;

                case 4://Velocidade

                    do
                    {
                        do
                        {
                            Console.WriteLine("1 - Kilometros/h para Milhas/h");
                            Console.WriteLine("2 - Milhas/h para Kilometros/h ");
                            Console.WriteLine("0 - Sair ");
                            aux = Console.ReadLine();

                            boleano = int.TryParse(aux, out escolhaDetalhe);
                            if (boleano == true) escolhaDetalhe = int.Parse(aux);//string é um numero

                            else escolhaDetalhe = 9999;// dar um valor para entrar no default do switch
                            Console.Clear();//limpa ecra

                        } while (escolhaDetalhe == 9999);

                        Console.Clear(); //limpar ecra

                        EscolhaDetalheV(escolhaDetalhe, valorUm, valorDois, valorTres, resultado);

                    } while (escolhaDetalhe != 0);

                    break;

                case 0://sair
                    Console.Clear();//Limpar ecra
                    break;

                default:
                    Console.WriteLine("Valor nao conhecido. Error");
                    break;
            }
        }

        /// <summary>
        /// Quando escolhi a unidade metrica entra no Menu da conversão metrica que lê a escolha do utilizador aplica a formula correcta e apresenta os valores
        /// </summary>
        /// <param name="escolhaDetalhe">Valor dado pelo utilizador pela escolha do menu da conversão</param>
        /// <param name="valorUm">Valor dado pelo utilizador</param>
        /// <param name="valorDois">Valor dado pelo utilizador</param>
        /// <param name="valorTres">Não usado neste metodo</param>
        /// <param name="resultado">Resultado da formula</param>
        public static void EscolhaDetalheC(int escolhaDetalhe, double valorUm, double valorDois, int valorTres, double resultado)
        {
            bool teste;
            string tmp;
            switch (escolhaDetalhe)
            {
                case 1://metros para milimetros
                    Console.Clear(); //limpar ecra
                    do
                    {            
                        Console.WriteLine("Quantos metros ?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorUm);
                        if (teste == true) valorUm = double.Parse(tmp);//string é um numero

                        else valorUm = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorUm== -1);

                    resultado = valorUm * 1000;
                    Console.WriteLine("Milimetros : {0}", resultado.ToString("0.#######"));//apresentar o resultado com duas casas decimais

                    break;

                case 2://milimetros para metros
                    Console.Clear(); //limpar ecra

                    do
                    {
                        Console.WriteLine("Quantos milimetros ?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorDois);
                        if (teste == true) valorDois = double.Parse(tmp);//string é um numero

                        else valorDois = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorDois == -1);

                    resultado = valorDois / 1000;
                    Console.WriteLine("Metros : {0}", resultado.ToString("0.#######"));//apresentar o resultado com duas casas decimais

                    break;

                case 0://sair                        
                    Console.Clear(); //limpar ecra
                    break;

                default:
                    Console.WriteLine("Valor nao conhecido . Erro");
                    break;
            }
            Console.WriteLine("\n");//dar um espaço            
        }

        /// <summary>
        /// Quando escolhi a unidade de energia entra no Menu da conversão da energia que lê a escolha do utilizador aplica a formula correcta e apresenta os valores
        /// </summary>
        /// <param name="escolhaDetalhe">Valor dado pelo utilizador pela escolha do menu da conversão</param>
        /// <param name="valorUm">Valor dado pelo utilizador</param>
        /// <param name="valorDois">Valor dado pelo utilizador</param>
        /// <param name="valorTres">Valor dado pelo utilizador</param>
        /// <param name="resultado">Resultado da formula</param>
        public static void EscolhaDetalheE(int escolhaDetalhe, double valorUm, double valorDois, int valorTres, double resultado)
        {
            bool teste;
            string tmp;

            switch (escolhaDetalhe)
            {
                case 1://watt para joule
                    Console.Clear(); //limpar ecra

                    do
                    {
                        Console.WriteLine("Quantos Watts?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorUm);
                        if (teste == true) valorUm = double.Parse(tmp);//string é um numero

                        else valorUm = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorUm == -1);
                    
                    do
                    {
                        Console.WriteLine("\nQuantos segundos?");
                        tmp = Console.ReadLine();

                        teste = int.TryParse(tmp, out valorTres);
                        if (teste == true) valorTres = int.Parse(tmp);//string é um numero

                        else valorTres = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorTres == -1);

                    resultado = valorUm * valorTres;
                    Console.WriteLine("Joules : {0}", resultado.ToString("0.##"));//apresentar o resultado com duas casas decimais

                    break;

                case 2://joule para watt
                    Console.Clear(); //limpar ecra

                    do
                    {
                        Console.WriteLine("Quantos joules?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorDois);
                        if (teste == true) valorDois = double.Parse(tmp);//string é um numero

                        else valorDois = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorDois == -1);

                    do
                    {
                        Console.WriteLine("\nQuantos segundos?");
                        tmp = Console.ReadLine();

                        teste = int.TryParse(tmp, out valorTres);
                        if (teste == true) valorTres = int.Parse(tmp);//string é um numero

                        else valorTres = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorTres == -1);

                    resultado = valorDois / valorTres;
                    Console.WriteLine("Watts : {0}", resultado.ToString("0.##"));//apresentar o resultado com duas casas decimais

                    break;

                case 0://sair
                    Console.Clear(); //limpar ecra
                    break;

                default:
                    Console.WriteLine("Valor nao conhecido . Erro");
                    break;
            }
            Console.WriteLine("\n");//dar um espaço

        }

        /// <summary>
        /// Quando escolhi a unidade da temperatura entra no Menu da conversão da temperatura que lê a escolha do utilizador aplica a formula correcta e apresenta os valores
        /// </summary>
        /// <param name="escolhaDetalhe">Valor dado pelo utilizador pela escolha do menu da conversão</param>
        /// <param name="valorUm">Valor dado pelo utilizador</param>
        /// <param name="valorDois">Valor dado pelo utilizador</param>
        /// <param name="valorTres">Não usado neste metodo</param>
        /// <param name="resultado">Resultado da formula</param>
        public static void EscolhaDetalheT(int escolhaDetalhe, double valorUm, double valorDois, int valorTres, double resultado)
        {
            bool teste;
            string tmp;

            switch (escolhaDetalhe)  
            {
                case 1://fah para celcius
                               
                    Console.Clear(); //limpar ecra
              
                    do
                    {
                        Console.WriteLine("Quantos graus Fahrenheit ?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorUm);
                        if (teste == true) valorUm = double.Parse(tmp);//string é um numero

                        else valorUm = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorUm == -1);            
                    resultado = (valorUm - 32) * 5 / 9;
              
                    Console.WriteLine("Celcios : {0}", resultado.ToString("0.##"));//apresentar o resultado com duas casas decimais
                          
                    break;                   

                case 2://Cel para fah   
                
                    Console.Clear(); //limpar ecra               
                  
                    do
                    {
                        Console.WriteLine("Quantos Celcius ?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorDois);
                        if (teste == true) valorDois = double.Parse(tmp);//string é um numero

                        else valorDois = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorDois == -1);                   
                    resultado = 9 * valorDois / 5 + 32;
                    
                    Console.WriteLine("Fahrenheit {0}", resultado.ToString("0.##"));//apresentar o resultado com duas casas decimais
           
                    break;
             
                case 0://sair
                
                    Console.Clear(); //limpar ecra                    
                    break;
              
                default:                
                    Console.WriteLine("Valor nao conhecido . Erro");                    
                    break;                
            }    
            Console.WriteLine("\n");//dar um espaço
        }

        /// <summary>
        /// Quando escolhi a unidade da velocidade entra no Menu da conversão da velocidade que lê a escolha do utilizador aplica a formula correcta e apresenta os valores
        /// </summary>
        /// <param name="escolhaDetalhe">Valor dado pelo utilizador pela escolha do menu da conversão</param>
        /// <param name="valorUm">Valor dado pelo utilizador</param>
        /// <param name="valorDois">Valor dado pelo utilizador</param>
        /// <param name="valorTres">Não usado neste metodo</param>
        /// <param name="resultado">Resultado da formula</param>
        public static void EscolhaDetalheV(int escolhaDetalhe, double valorUm, double valorDois, int valorTres, double resultado)
        {
            bool teste;
            string tmp;
                
            switch (escolhaDetalhe)            
            {            
                case 1://kph para mph
                
                    Console.Clear(); //limpar ecra

                    do
                    {
                        Console.WriteLine("Quantos Kilometros por hora ?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorUm);
                        if (teste == true) valorUm = double.Parse(tmp);//string é um numero

                        else valorUm = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorUm == -1);                         
                    resultado = valorUm * 0.62137119;
                    
                    Console.WriteLine("MPH : {0}", resultado.ToString("0.##"));//apresentar o resultado com duas casas decimais                    
                    break;
                    
                case 2://mph para kph
                
                    Console.Clear(); //limpar ecra

                    do
                    {
                        Console.WriteLine("Quantas Milhas por hora ?");
                        tmp = Console.ReadLine();

                        teste = double.TryParse(tmp, out valorDois);
                        if (teste == true) valorDois = double.Parse(tmp);//string é um numero

                        else valorDois = -1;// dar um valor para entrar no default do switch
                        Console.Clear();//limpa ecra
                    } while (valorDois == -1);
                
                    resultado = valorDois / 0.62137119;
                    
                    Console.WriteLine("KPH : {0}", resultado.ToString("0.##"));//apresentar o resultado com duas casas decimais      
              
                    break;
                    
                case 0://sair
                
                    Console.Clear(); //limpar ecra                    
                    break;
                    
                default:
                
                    Console.WriteLine("Valor nao conhecido . Erro");                    
                    break;
                }      
            Console.WriteLine("\n");//dar um espaço
        }
    }
}
