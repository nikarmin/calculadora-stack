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

        Nicoli Ferreira - 21689
        Julia Flausino da Silva - 21241
        Professor: Francisco da Fonseca Rodrigues
     */

    public partial class frmCalculadora : Form
    {
        PilhaLista<char> umaPilha;
        char[] vetorValores;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {
            char ultimaLetra = ' ';

            if (txtVisor.Text.Length != 0)
            {
                ultimaLetra = txtVisor.Text[txtVisor.TextLength - 1];

                if (!"1234567890-+*/.()".Contains(ultimaLetra))
                {
                    txtVisor.Text = txtVisor.Text.Substring(0, txtVisor.Text.Length - 1);
                    MessageBox.Show("Caractere inválido!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        bool EhOperador(char simbolo)
        {
            if ("/*-+()".Contains(simbolo))
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

        private void btnIgual_Click(object sender, EventArgs e)
        {
            // Verifica se a expressão está balanceada
            if (Balanceada())
            {
                // Criamos um vetor com o tamanho do txtVisor
                // Verificar quantos operadores tem na expressão?

                vetorValores = new char[txtVisor.TextLength];
                string numero = "";

                for (int i = 0; i < txtVisor.TextLength; i++)
                {
                    if ("1234567890".Contains(txtVisor.Text[i]))
                        numero += txtVisor.Text[i];
                    /*
                    if ("1234567890".Contains(txtVisor.Text[i]))
                    {
                        vetorValores[i] = txtVisor.Text[i];
                    }*/
                }

                byte contador = 0;
                foreach (Char ind in numero)
                    vetorValores[contador++] = ind;
            }
            else
                MessageBox.Show("A equação não está balanceada! Verifique os parênteses!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}