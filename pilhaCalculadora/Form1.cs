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
        //PilhaLista<> umaPilha;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {
            // testando DOIDEIRAS
            if ("1234567890-+*/.".Contains(txtVisor.Text))
            {
                MessageBox.Show("aaaaaaaaaa");
                //ConverterInfixaParaPosfixa(txtVisor.Text);
            }
        }

        bool EhOperador(char simbolo)
        {
            if ("/*-+()".Contains(simbolo))
                return true;
            else
                return false;
        }

        string ConverterInfixaParaPosfixa(string cadeiaLida)
        {
            string resultado = "";
            //umaPilha = new PilhaLista();

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
                    //while (!parar && /*!umaPilha.EstaVazia*/)
                }
            }

            return resultado;
        }
    }
}
