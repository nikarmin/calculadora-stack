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
            //if (txtVisor.Text.Length != 0)
            char ultimaLetra = txtVisor.Text[txtVisor.TextLength - 1];

            if (!"1234567890-+*/.()".Contains(ultimaLetra))
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

        bool EhAbertura(char caracter)
        {
            return "{[(".Contains(caracter);
        }
        bool EhFechamento(char caracter)
        {
            return "}])".Contains(caracter);
        }

        bool Combinam(char anterior, char atual)
        {
            return anterior == '{' && atual == '}' ||
                   anterior == '(' && atual == ')' ||
                   anterior == '[' && atual == ']';
        }

        bool Balanceada()
        {
            PilhaLista<char> pilhaBalanceamento = new PilhaLista<char>();
            string expressao = txtVisor.Text;
            bool estaBalanceada = true;
            int abertura = 0;
            int fechamento = 0;

            for (int i = 0; i < expressao.Length && estaBalanceada; i++)
            {
                char caracterLido = expressao[i];
                if (EhAbertura(caracterLido))
                {
                    pilhaBalanceamento.Empilhar(caracterLido);
                    abertura++;
                }

                else // caracter é de fechamento?
                    if (EhFechamento(caracterLido))
                {
                    char aberturaAnterior = ' ';
                    fechamento++;

                    try
                    {
                        aberturaAnterior = pilhaBalanceamento.Desempilhar();
                    }
                    catch (Exception ex)
                    {
                        estaBalanceada = false;
                    }
                    if (!Combinam(aberturaAnterior, caracterLido))
                        estaBalanceada = false;
                }

                else
                    estaBalanceada = false;
            }

            if (abertura != fechamento)
                return false;

            return estaBalanceada;
        }

        bool TemPrecedencia(NoLista<char> topo, char simbolo)
        {

            switch (simbolo)
            {
                case '+':
                    if (topo.Info == '+' || topo.Info == '-')
                        return true;
                    else
                        return false;
                    break;
            }

            return false;
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
                    while (!parar && !umaPilha.EstaVazia /*&& TemPrecedencia(umaPilha.OTopo, simboloLido)*/)
                    {

                    }
                }
            }

            return resultado;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (Balanceada())
            {
                MessageBox.Show("Equação balanceada!");
            }
            else
                MessageBox.Show("A equação não está balanceada! Verifique os parênteses!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
