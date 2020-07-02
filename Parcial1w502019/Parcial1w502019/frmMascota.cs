using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parcial1w502019
{
    public partial class frmMascota : Form
    {
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Usuario\Desktop\Parcial1w502019\dbfMascotas.mdb");
        const int tam = 5;
        Mascota[] am = new Mascota[tam];
        int c; 


        public frmMascota()
        {
            InitializeComponent();
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            cargarCombo(cboEspecie, "Especie");
            cargarLista("Mascota");

        }
        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable dt = new DataTable();
            dt = oDato.consultarTabla(nombreTabla);
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void cargarLista(string nombreTabla)
        {
            c = 0;
            lstMascotas.Items.Clear();
            oDato.leerTabla(nombreTabla);
            while (oDato.pLector.Read())
            {
                Mascota m = new Mascota();
                if (!oDato.pLector.IsDBNull(0))
                {
                    am[c].pCodigo = oDato.pLector.GetInt32(0);

                }
                    

                if (!oDato.pLector.IsDBNull(1))
                {
                    am[c].pNombre = oDato.pLector.GetString(1);
                }
                if (!oDato.pLector.IsDBNull(2))
                {
                    am[c].pEspecie = oDato.pLector.GetInt32(2);
                }
                if (!oDato.pLector.IsDBNull(3))
                {
                    am[c].pSexo = oDato.pLector.GetInt32(3);
                }
                if (!oDato.pLector.IsDBNull(4))
                {
                    am[c].pFechaNacimiento = oDato.pLector.GetDateTime(4);            
                }
                am[c] = m;
                c++;
            }
          
        }
       

       

        private void btnGrabar_Click(object sender, EventArgs e)
        { 
            
      
          
        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}