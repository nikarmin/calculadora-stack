using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pilhaCalculadora
{
    /*
        Estrutura de Dados II - Projeto Calculadora em Pilha

        Julia Flausino da Silva - 21241
        Nicoli Ferreira - 21689
        Professor: Francisco da Fonseca Rodrigues
     */

    public partial class frmCalculadora : Form
    {
        List<double> numeros;          // lista dos operadores da expressão
        PilhaLista<char> umaPilha;     // pilha que auxilia a formar a expressão posfixa
        PilhaLista<double> pilhaValor; // pilha para calcular o valor da expressão

        public frmCalculadora()
        {
            InitializeComponent();
        }

        // método para limpar a tela, tirar todas as alterações
        void Limpar()
        {
            lbSequencias.Text = "Infixa/Pósfixa: ";
            txtVisor.Clear();
            txtResultado.Clear();
        }

        // verifica se o simbolo passado como parâmetro é um operador
        bool EhOperador(char simbolo)
        {
            // se o simbolo está contido na string "/*-+()^@#", ele é operador
            if ("/*-+()^@#".Contains(simbolo))
                return true; // então, retornamos true
            else // se não está contido
                return false; // retornamos false
        }

        // verifica se a expressão está balanceada
        bool Balanceada()
        {
            // criamos uma pilha para poder verificar o balanceamento
            PilhaLista<char> pilhaBalanceamento = new PilhaLista<char>();
            string expressao = txtVisor.Text;
            bool estaBalanceada = true;

            // percorremos a expressão, pegando cada caractere
            for (int i = 0; i < expressao.Length && estaBalanceada; i++)
            {
                char caracterLido = expressao[i];

                // se for uma abertura, empilhamos
                if (caracterLido == '(')
                    pilhaBalanceamento.Empilhar(caracterLido);

                else if (caracterLido == ')')
                {

                    // se for um fechamento, e a pilha está vazia, indica que não temos a abertura deste fechamento,
                    // portanto, indica que não está balanceada
                    if (pilhaBalanceamento.EstaVazia)
                        estaBalanceada = false;
                    else
                    {
                        char aberturaAnterior = ' ';

                        try
                        {
                            // se não, tiramos o '(' da pilha, indicando que 'combinou'
                            aberturaAnterior = pilhaBalanceamento.Desempilhar();
                        }
                        catch (Exception ex)
                        {
                            estaBalanceada = false;
                        }
                    }
                }
                else
                    estaBalanceada = true;
            }

            // se a pilha não estiver vazia, significa que algum caractere sobrou, indicando que não está balanceada
            if (!pilhaBalanceamento.EstaVazia)
                estaBalanceada = false;

            // se está balanceada e a pilha está vazia, a expressão está balanceada
            if (estaBalanceada && pilhaBalanceamento.EstaVazia)
                estaBalanceada = true;

            return estaBalanceada;
        }

        // define o valor de precedência do símbolo passado como parâmetro
        byte VerificarValorDePrecedencia(char simbolo)
        {
            byte precedencia = 0;

            switch (simbolo)
            {
                case '(':
                    precedencia = 0;
                    break;
                case '@': // @ é o - unário
                case '#': // # é o + unário
                    precedencia = 1;
                    break;
                case '^':
                    precedencia = 2;
                    break;
                case '*':
                case '/':
                    precedencia = 3;
                    break;
                case '+':
                case '-':
                    precedencia = 4;
                    break;
                case ')':
                    precedencia = 5;
                    break;
            }

            return precedencia;
        }

        // verifica se o primeiro simbolo tem precedencia sobre o segundo
        bool TemPrecedencia(char topo, char simboloLido)
        {
            byte pTopo = VerificarValorDePrecedencia(topo);               // pTopo recebe o valor de precedencia do simbolo do topo da pilha
            byte pSimboloLido = VerificarValorDePrecedencia(simboloLido); // pSimboloLido recebe o valor de precedencia do simbolo lido

            // se o valor de precedencia do simbolo do topo for menor que o do simbolo lido, o simbolo do topo tem maior precedência
            if (pTopo < pSimboloLido)
                return true;
            // se os dois simbolos tem o mesmo valor de precedencia, o simbolo que vem primeiro na expressao tem maior precedencia, ou seja,
            // o simbolo do topo da pilha (pois ele foi lido antes). isso só não acontece com os unários (precedencia 1) e com o operador de
            // potenciação (precedencia = 2)
            else if (pTopo == pSimboloLido && pTopo != 1 && pTopo != 2)
                return true;

            return false;
        }

        double ValorDaSubExpressao(double op1, char simbol, double op2)
        {
            double resultado = 0;

            // o simbolo é o operador, que determina qual a operação a ser feita
            switch (simbol)
            {
                case '+':
                    resultado = op1 + op2;
                    break;

                case '-':
                    resultado = op1 - op2;
                    break;

                case '*':
                    resultado = op1 * op2;
                    break;

                case '/':
                    resultado = op1 / op2;
                    break;

                case '^':
                    if (op1 > 0) 
                        resultado = Math.Pow(op1, op2);
                    else
                        resultado = -1 * Math.Pow(-op1, op2);
                    break;
            }

            return resultado;
        }

        double ValorDaExpressaoPosfixa(string cadeiaPosfixa)
        {
            pilhaValor = new PilhaLista<double>(); // pilha que vai guardar o valor da expressão

            // percorremos a expressao posfixa
            for (int i = 0; i < cadeiaPosfixa.Length; i++)
            {
                char simbol = cadeiaPosfixa[i];

                // se for não for operador, empilhamos na pilha de valor
                if (!EhOperador(simbol))
                   pilhaValor.Empilhar(numeros[(int)(simbol - 'A')]);           
                else
                {
                    // se o simbolo for @ (menos unário), a pilha deverá guardar o valor oposto ao que ela está guardando
                    if (simbol == '@')
                        pilhaValor.Empilhar(-pilhaValor.Desempilhar());
                    // se o simbolo for + (mais unário), nada deverá ser alterado
                    else if (simbol == '#')
                        continue;
                    // se tivermos um operador binário
                    else
                    {
                        // pegamos os dois operandos guardados na pilha
                        double operando2 = pilhaValor.Desempilhar();
                        double operando1 = pilhaValor.Desempilhar();
                        double valor = ValorDaSubExpressao(operando1, simbol, operando2); // realizamos a operação indicada pelo operador binário
                        pilhaValor.Empilhar(valor); // empilhamos o resultado na pilhaValor
                    }
                }
            }

            return pilhaValor.Desempilhar(); // retornamos o resultado, guardado na pilhaValor
        }

        string ConverterInfixaParaPosfixa(string cadeiaLida)
        {
            string resultado = "";
            umaPilha = new PilhaLista<char>();
            char operadorComMaiorPrecedencia = ' ';

            for (int x = 0; x < cadeiaLida.Length; x++)
            {
                char simboloLido = cadeiaLida[x];
                // operando
                if (!EhOperador(simboloLido))
                    resultado += simboloLido;
                // operador
                else
                {
                    bool parar = false;

                    while (!parar && !umaPilha.EstaVazia && TemPrecedencia(umaPilha.OTopo(), simboloLido))
                    {
                        // se o topo da pilha é "mais importante" que o simboloLido, desempilhamos o topo,
                        // colocando ele na expressão pós-fixa e empilhamos o simbolo lido
                         operadorComMaiorPrecedencia = umaPilha.Desempilhar();

                        if (operadorComMaiorPrecedencia != '(')
                            resultado += operadorComMaiorPrecedencia;
                        else
                        {
                            parar = true;
                            umaPilha.Empilhar(operadorComMaiorPrecedencia);
                        }
                    }

                    if (simboloLido != ')')
                        umaPilha.Empilhar(simboloLido);
                    else // fará isso QUANDO o Pilha[TOPO] = ‘(‘
                        operadorComMaiorPrecedencia = umaPilha.Desempilhar();

                }
            }

            while (!umaPilha.EstaVazia) // descarrega a pilha para a saída
            {
                operadorComMaiorPrecedencia = umaPilha.Desempilhar();
                if (operadorComMaiorPrecedencia != '(')
                    resultado += operadorComMaiorPrecedencia;
            }

            return resultado;
        }

        private string FormarExpressaoInfixa(string expressao)
        {
            string expInfx = "";          // string que será retornada, contendo a expressão infixa com números ao invés de letras
            numeros = new List<double>(); // vetor de doubles que vai guardar os operandos da expressão

            // percorre a expressão passada como parâmetro
            for (byte i = 0; i < expressao.Length; i++)
            {
                // se o caracter analisado é operador
                if (EhOperador(expressao[i]))
                { 
                    bool ehUnario = false;
                    // se o char for - ou +, vamos analisar se ele é unário
                    if (expressao[i] != '(' && expressao[i] != ')')
                    {
                        // se o char analisado é o primeiro a aparecer na string 
                        if (i == 0) 
                            // é unário
                            ehUnario = true;
                        // se ele for o último a aparecer na string, a expressão é inválida
                        else if (i == expressao.Length - 1)
                            throw new Exception("Expressao inválida");
                        // se o char que vem antes não é um operando 
                        else if (expressao[i-1] != ')' && !char.IsNumber(expressao[i - 1]))
                            // é unario
                            ehUnario = true;
                    }

                    // se for unário
                    if (ehUnario)
                    {
                        // verificamos se é o menos ou o mais unários e substituimos eles por caracteres especiais para
                        // identificá-los mais tarde, na hora de realizar a conta
                        if (expressao[i] == '-')
                            expInfx += '@';
                        else if (expressao[i] == '+')
                            expInfx += '#';
                        else
                            throw new Exception("Expressao inválida");
                    }
                    else // se não for unário
                        expInfx += expressao[i]; // apenas adicionamos na expressão
                }
                else // número ou ponto
                {
                    string operando = ""; // a string operando começa vazia, vamos verificar os chars que vem depois do número encontrado
                                          // pois o operando pode ser composto por mais de um número (ex: 134), também podendo ser um decimal
                                          // (ex: 12.45) então, temos que verificar se temos mais números depois desse, números que vão compor
                                          // esse operando

                    // vamos percorrer a expressão a partir de onde paramos até achar um operador, 
                    // quando acharmos um operador quer dizer que o 'operando' acabou 
                    byte c = i;

                    while (c != expressao.Length && !EhOperador(expressao[c]))
                    {
                        if (expressao[c] == '.')
                            operando += ',';

                        else
                            operando += (char)expressao[c];

                        c++;
                    }

                    // se o operando tiver um índice maior que 1, ou seja, é composto por +1 número
                    // temos que fazer com que o for continue a percorrer até onde ele pegou os números
                    if (operando.Length > 1)
                        i = --c;

                    double numero = double.Parse(operando); // transformamos a string operando em double

                    // se esse operando ainda não foi guardado na lista de operandos, guardamos ele lá
                    // (não guardamos operandos repetidos para que cada operanod tenha uma letra exclusiva)
                    if (!numeros.Contains(numero))
                        numeros.Add(numero);

                    // adicionamos a letra correspondente ao operando na expInfx
                    expInfx += (char)(65 + numeros.IndexOf(numero));
                }
            }

            return expInfx;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            string expressaoLida = txtVisor.Text; // pegamos a expressao digitada no txtVisor

            // verifica se a expressão está balanceada e contém pelo menos um operador
            if (Balanceada() && expressaoLida.IndexOfAny("+-/*^".ToCharArray()) != -1)
            {
                try
                {
                    string expInfixLetras = FormarExpressaoInfixa(expressaoLida);       // formamos a expressão infixa com letras ao invés de números
                    string expPosfixLetras = ConverterInfixaParaPosfixa(expInfixLetras); // formamos a expressão posfixa a partir da infixa

                    txtResultado.Text = ValorDaExpressaoPosfixa(expPosfixLetras) + "";   // calculamos o valor da expressão e exibimos ele no txtResultado

                    // substituimos os "@" e "#", que representam o mais e o menos unários, por "-" e "+"
                    var expInfx = expInfixLetras.Replace('@', '-').Replace('#', '+');
                    var expPosfx = expPosfixLetras.Replace('@', '-').Replace('#', '+');

                    lbSequencias.Text = "Infixa/Pósfixa: " + expInfx + " | " + expPosfx;  // exibimos as expressões no lbSequencias  
                }
                catch (Exception expressaoInvalida)
                {
                    // limpamos a tela e alertamos o usuário
                    Limpar();
                    MessageBox.Show("Verifique os parenteses e se há pelo menos um operador!", "Expressão incorreta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else // se a expressão está incorreta
            {
                // limpamos a tela e alertamos o usuário
                Limpar();
                MessageBox.Show("Verifique os parênteses e se há pelo menos um operador!", "Expressão incorreta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExpo_Click_1(object sender, EventArgs e)
        {
            char button = (sender as Button).Text[0];
            txtVisor.Text += button;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void txtVisor_KeyDown(object sender, KeyEventArgs e)
        {
            // impede o usuário de utilizar a tecla 'space'
            if (e.KeyCode == Keys.Space)
                e.SuppressKeyPress = true;
        }

        private void txtVisor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permite que o usuário digite apenas números, operadores e teclas de controle
            if(!char.IsNumber(e.KeyChar) && !"+-*/.()^".Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractere inválido!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == 13)
            {
                btnIgual.PerformClick();
                e.Handled = true; 
            }
        }

        private void txtVisor_DoubleClick(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}