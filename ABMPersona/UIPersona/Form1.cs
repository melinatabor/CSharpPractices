using BE;
using BL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABMPersona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgv.Columns.Add("Id", "Id");
            dgv.Columns.Add("Nombre", "Nombre");
            dgv.Columns.Add("Apellido", "Apellido");
            dgv.Columns.Add("Documento", "Documento");
            ActualizarDgv();
        }

        private void ActualizarDgv()
        {
            dgv.Rows.Clear();
            foreach (PersonaBE persona in PersonaBL.Listar())
            {
                dgv.Rows.Add(persona.Id, persona.Nombre, persona.Apellido, persona.Documento);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PersonaBL.Eliminar(int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString()));
            ActualizarDgv();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            PersonaBE persona = PersonaBL.ObtenerPersona(id);
            persona.Nombre = Interaction.InputBox("NOMBRE:");
            persona.Apellido = Interaction.InputBox("APELLIDO:");
            persona.Documento = int.Parse(Interaction.InputBox("DOCUMENTO:"));
            PersonaBL.Modificar(persona);
            ActualizarDgv();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PersonaBE persona = new PersonaBE();
            persona.Nombre = Interaction.InputBox("NOMBRE:");
            persona.Apellido = Interaction.InputBox("APELLIDO:");
            persona.Documento = int.Parse(Interaction.InputBox("DOCUMENTO:"));
            PersonaBL.Agregar(persona);
            ActualizarDgv();
        }
    }
}
