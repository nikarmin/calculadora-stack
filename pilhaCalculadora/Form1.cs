using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        PilhaLista<char> umaPilha;
        char[] vetorValores;
        int[] vetorLetras;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {
            char ultimaLetra = ' ';

            if (txtVisor.Text.Length != 0)
            {
                byte contador = 0;
                ultimaLetra = txtVisor.Text[txtVisor.TextLength - 1];

                if (!"1234567890-+*/.()^ ".Contains(ultimaLetra))
                {
                    txtVisor.Text = txtVisor.Text.Substring(0, txtVisor.Text.Length - 1);
                    MessageBox.Show("Caractere inválido!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    precedencia = 3;
                    break;
                case ')':
                    precedencia = 4;
                    break;
            }

            return precedencia;
        }

        bool TemPrecedencia(char topo, char simboloLido)
        {
            byte pTopo = VerificarValorDePrecedencia(topo);
            byte pSimboloLido = VerificarValorDePrecedencia(simboloLido);

            if (pTopo < pSimboloLido)
                return true;
            else if (pTopo == pSimboloLido)
                return true;

            return false;
        }

        string ConverterInfixaParaPosfixa(string cadeiaLida)
        {
            string resultado = " ";
            umaPilha = new PilhaLista<char>();

            for (int x = 0; x < cadeiaLida.Length; x++)
            {
                char simboloLido = cadeiaLida[x];
                // OPERANDO
                if (!EhOperador(simboloLido))
                    resultado += simboloLido;
                // OPERADOR
                else
                {
                    bool parar = false;

                    while (!parar && !umaPilha.EstaVazia && TemPrecedencia(umaPilha.OTopo(), simboloLido))
                    {
                        // se o topo da pilha é "mais importante" que o simboloLido, desempilhamos o topo,
                        // colocando ele na expressão pós-fixa e empilhamos o simbolo lido
                        if (umaPilha.OTopo() == '(')
                            umaPilha.Desempilhar();
                        else
                            resultado += umaPilha.Desempilhar();

                        umaPilha.Empilhar(simboloLido);
                    }
                }
            }

            return resultado;
        }

        private string FormarExpressaoInfixa(string expressao)
        {
            string expInfx = "";                      // string que será retornada, contendo a expressão infixa com números ao invés de letras
            List<double> numeros = new List<double>(); // vetor de doubles que vai guardar os operandos da expressão

            // percorre a expressão passada como parâmetro
            for (byte i = 0; i < expressao.Length; i++)
            {
                // se o caracter analisado é operador
                if (EhOperador(expressao[i]))
                {
                    expInfx += expressao[i]; // adicionamos ele na expressão infixa
                }

                else // número ou ponto
                {
                    string operando = ""; // a string operando começa vazia, vamos verificar os chars que vem depois do número encontrado
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

                    if (!numeros.Contains(numero))
                        numeros.Add(numero);

                    expInfx += (char)(65 + numeros.IndexOf(numero));

                }
            }

            return expInfx;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            // Verifica se a expressão está balanceada
            if (Balanceada())
            {
                //string exp = "(5+8)*5+7^4";
                //string exp1 = "(5.2+8)*5.2+7^4";
                //string exp2 = "6+4*6^356+356";
                //string expInfx = FormarExpressaoInfixa(exp);
                //string expInfx2 = FormarExpressaoInfixa(exp2);
                //string expInfx = FormarExpressaoInfixa(exp1);

                /*double teste = double.Parse("2.5");
                double teste2 = double.Parse("2,5");*/

                /*string expressaoLetras = txtVisor.Text;
                FormarExpressaoInfixa(expressaoLetras);*/

            }
            else
                MessageBox.Show("A equação não está balanceada! Verifique os parênteses!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExpo_Click_1(object sender, EventArgs e)
        {
            char numero = (sender as Button).Text[0];
                txtVisor.Text += numero;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
        }

        private void txtVisor_KeyDown(object sender, KeyEventArgs e)
        {
            // Não deixar o usuário utilizar a tecla 'space'

            if (e.KeyCode == Keys.Space)
                e.SuppressKeyPress = true;
        }
    }
}