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
    public partial class frmCalculadora : Form
    {
        PilhaLista<char> umaPilha;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {
            char ultimaLetra = txtVisor.Text[txtVisor.TextLength - 1];

            if (!"1234567890-+*/.".Contains(ultimaLetra))
            {
                txtVisor.Text = txtVisor.Text.Substring(0, txtVisor.Text.Length - 1);
                MessageBox.Show("Caractere inválido!", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool EhOperador(char simbolo)
        {
            if ("/*-+()".Contains(simbolo))
                return true;
            else
                return false;
        }

        bool TemPrecedencia(char topo, char simboloLido)
        {
            byte pTopo        = VerificarValorDePrecedencia(topo);
            byte pSimboloLido = VerificarValorDePrecedencia(simboloLido);

            if (pTopo < pSimboloLido)
                return true;
            else if (pTopo == pSimboloLido)
                return true;

            return false;
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

        string ConverterInfixaParaPosfixa(string cadeiaLida)
        {
            string resultado = "";
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
    }
}
