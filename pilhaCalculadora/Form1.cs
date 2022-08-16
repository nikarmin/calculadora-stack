using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
        List<double> numeros;
        PilhaLista<char> umaPilha;
        PilhaLista<double> pilhaValor;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {
            //if (txtVisor.Text.Length > 0)
            //{
            //    if (!"1234567890-+*/.()^".Contains(txtVisor.Text[txtVisor.TextLength-1]))
            //    {
            //        MessageBox.Show("Caractere inválido!", "Erro",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            //for (byte z = 0; z < txtVisor.TextLength; z++)
            //{
            //    if (!"1234567890-+*/.()^".Contains(txtVisor.Text[z]))
            //    {
            //        MessageBox.Show("Caractere inválido!", "Erro",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        Limpar();
            //    }
            //}

            //Regex regex = new Regex("[0123456879()^+*/.-]");

            //if (txtVisor.Text.Length != 0)
            //{
            //}

            //char ultimaLetra = ' ';

            //if (txtVisor.Text.Length != 0)
            //{
            //    ultimaLetra = txtVisor.Text[txtVisor.TextLength - 1];

            //    if (!"1234567890-+*/.()^".Contains(ultimaLetra))
            //    {
            //        txtVisor.Text = txtVisor.Text.Substring(0, txtVisor.Text.Length - 1);
            //        MessageBox.Show("Caractere inválido!", "Erro",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        void Limpar()
        {
            lbSequencias.Text = "Infixa/Pósfixa: ";
            txtVisor.Clear();
            txtResultado.Clear();
        }

        bool EhOperador(char simbolo)
        {
            if ("/*-+()^".Contains(simbolo))
                return true;
            else
                return false;
        }

        bool Balanceada()
        {
            // Criamos uma pilha para poder verificar o balanceamento
            PilhaLista<char> pilhaBalanceamento = new PilhaLista<char>();
            string expressao = txtVisor.Text;
            bool estaBalanceada = true;

            // Percorremos a expressão, pegando cada caractere
            for (int i = 0; i < expressao.Length && estaBalanceada; i++)
            {
                char caracterLido = expressao[i];

                // Se for uma abertura, empilhamos
                if (caracterLido == '(')
                    pilhaBalanceamento.Empilhar(caracterLido);

                else if (caracterLido == ')')
                {

                    // Se for um fechamento, e a pilha está vazia, indica que não temos a abertura deste fechamento,
                    // portanto, indica que não está balanceada
                    if (pilhaBalanceamento.EstaVazia)
                        estaBalanceada = false;
                    else
                    {
                        char aberturaAnterior = ' ';

                        try
                        {
                            // Se não, tiramos o '(' da pilha, indicando que 'combinou'
                            aberturaAnterior = pilhaBalanceamento.Desempilhar();
                        }
                        catch (Exception ex)
                        {
                            estaBalanceada = false;
                        }
                    }
                }

                // SE NUM FOR PARÊNTESES TÁ TUDO OK, AFINAL, ELE DISSE PRA BALANCEAR SÓ OS (((((((())))))))))))
                else
                    estaBalanceada = true;
            }

            // Se a pilha não estiver vazia, significa que algum caractere sobrou, indicando que não está balanceada
            if (!pilhaBalanceamento.EstaVazia)
                estaBalanceada = false;

            // Se está balanceada e a pilha está vazia, a expressão está balanceada
            if (estaBalanceada && pilhaBalanceamento.EstaVazia)
                estaBalanceada = true;

            return estaBalanceada;
        }

        byte VerificarValorDePrecedencia(char simbolo)
        {
            byte precedencia = 0;

            switch (simbolo)
            {
                case '(':
                    precedencia = 0;
                    break;
                case '^':
                    precedencia = 1;
                    break;
                case '*':
                case '/':
                    precedencia = 2;
                    break;
                case '+':
                case '-':
                //case '@':
                    precedencia = 3;
                    break;
                case ')':
                    precedencia = 4;
                    break;
            }

            return precedencia;
        }
        bool ehUnario()
        {
            return false;
        }
        bool TemPrecedencia(char topo, char simboloLido)
        {
            byte pTopo = VerificarValorDePrecedencia(topo);
            byte pSimboloLido = VerificarValorDePrecedencia(simboloLido);

            if (pTopo < pSimboloLido)
                return true;

            else if (pTopo == pSimboloLido && pTopo != 1)
                return true;

            return false;
        }

        double ValorDaSubExpressao(double op1, char simbol, double op2)
        {
            double resultado = 0;

            switch (simbol)
            {
                // Talvez fazer uma classe calculadora?

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
                    resultado = Math.Pow(op1, op2);
                    break;
            }

            return resultado;
        }

        double ValorDaExpressaoPosfixa(string cadeiaPosfixa)
        {
            pilhaValor = new PilhaLista<double>();

            for (int i = 0; i < cadeiaPosfixa.Length; i++)
            {
                char simbol = cadeiaPosfixa[i];

                if (!EhOperador(simbol))
                    pilhaValor.Empilhar(numeros[(int)(simbol - 'A')]);
                else
                {
                    double operando2 = pilhaValor.Desempilhar();
                    double operando1 = pilhaValor.Desempilhar();
                    double valor = ValorDaSubExpressao(operando1, simbol, operando2);
                    pilhaValor.Empilhar(valor);
                }
            }

            return pilhaValor.Desempilhar();
        }

        string ConverterInfixaParaPosfixa(string cadeiaLida)
        {
            string resultado = "";
            umaPilha = new PilhaLista<char>();
            char operadorComMaiorPrecedencia = ' ';

            for (int x = 0; x < cadeiaLida.Length; x++)
            {
                char simboloLido = cadeiaLida[x];
                // OPERANDO
                if (!EhOperador(simboloLido))
                    resultado += simboloLido;
                // OPERADOR
                /*else if (simboloLido == '@')
                {
                    resultado += simboloLido;
                }*/
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
                            //if (operadorComMaiorPrecedencia != '^')
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

            while (!umaPilha.EstaVazia) // Descarrega a Pilha Para a Saída
            {
                operadorComMaiorPrecedencia = umaPilha.Desempilhar();
                if (operadorComMaiorPrecedencia != '(')
                    resultado += operadorComMaiorPrecedencia;
            }

            return resultado;
        }

        private string FormarExpressaoInfixa(string expressao)
        {
            string expInfx = "";                      // string que será retornada, contendo a expressão infixa com números ao invés de letras
            numeros = new List<double>(); // vetor de doubles que vai guardar os operandos da expressão

            string operando = "";

            // percorre a expressão passada como parâmetro
            for (byte i = 0; i < expressao.Length; i++)
            {
                

                // se o caracter analisado é operador
                if (EhOperador(expressao[i]))
                {
                    //if (expressao[i] != 0)
                    //{
                    //    if (expressao[i-1])
                    //}

                    // CORINGUEIIIIIIIIIIIIIIIIIII AQUIIIIIIIIIIIIIIIIIIIIIIIIIIIIII

                    /*if (i == 0 && (expressao[i] == '-'))
                        operando += expressao[0];

                    else if (expressao[i] == '(')
                    {
                        expInfx += expressao[i];

                        byte contador = i;

                        if (expressao[++contador] == '-')
                        {
                            while (!EhOperador(expressao[++contador]))
                            {
                                operando += expressao[contador];
                                //contador++;
                            }
                            i = --contador;
                        }*/
                            //operando += expressao[contador];

                        /*else
                        {
                            while (expressao[contador] != ')')
                            {

                                contador++;
                            }

                        }

                    }
                    else*/
                        expInfx += expressao[i]; // adicionamos ele na expressão infixa
                }
                else // número ou ponto
                {
                    //string operando = ""; // a string operando começa vazia, vamos verificar os chars que vem depois do número encontrado
                                          // pois o operando pode ser composto por mais de um número (ex: 134) ou pode ser um decimal
                                          // (ex: 12.45) então, temos que verificar se temos mais números depois desse que vão compor
                                          // esse operando

                    // vamos percorrer a expressão a partir de onde paramos até achar um operador, 
                    // quando acharmos um operador quer dizer que o 'operando' acabou --- problema: mas e se for o último número da expressão? - até achar o operando ou até terminar a string
                    // ai n vamos ter um último operador, e se a expressão acabar com um operador? (um parenteses) - só copia
                    // e se a expressão tiver um operador unário?
                    byte c = i;

                    while (c != expressao.Length && !EhOperador(expressao[c]))
                    {
                        if (expressao[c] == '.')
                            operando += ',';

                        else
                            operando += (char)expressao[c];

                        c++;
                    }

                    // Se o operando tiver um índice maior que 1, ou seja, é composto por +1 número
                    // Temos que fazer com que o for continue a percorrer até onde ele pegou os números
                    if (operando.Length > 1)
                        i = --c;

                    double numero = double.Parse(operando);

                    if ("-".Contains(numero.ToString()))
                        expInfx += '@';

                    if (!numeros.Contains(numero))
                        numeros.Add(numero);

                     expInfx += (char)(65 + numeros.IndexOf(numero));

                    operando = "";
                }
            }

            return expInfx;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            // Verifica se a expressão está balanceada
            if (Balanceada())
            {
                string expressaoLetras = FormarExpressaoInfixa(txtVisor.Text);
                string expressaoPosfixa = ConverterInfixaParaPosfixa(expressaoLetras);

                txtResultado.Text += ValorDaExpressaoPosfixa(expressaoPosfixa);

                lbSequencias.Text += txtVisor.Text + " | " + expressaoPosfixa;
            }
            else
            {
                Limpar();

                MessageBox.Show("A equação não está correta! Verifique os parênteses e os números", "Erro",
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
            // Não deixar o usuário utilizar a tecla 'space'

            if (e.KeyCode == Keys.Space)
                e.SuppressKeyPress = true;
        }

        private void txtVisor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) && !"+-*/.()^".Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractere inválido!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVisor_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}