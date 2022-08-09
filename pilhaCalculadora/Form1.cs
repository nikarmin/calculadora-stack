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
                }
            }

            return resultado;
        }
    }
}
