using EsameCSharp.Books;
using EsercizioEsame2.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsercizioEsame2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var bookCollection = new BookCollection();
            var libri = bookCollection.GetLibri();
            var libriConPrezzo = new List<LibroConPrezzo>();

            foreach (var libro in libri)
            {
                var libroConPrezzo = new LibroConPrezzo();
                libroConPrezzo.Anno = libro.Anno;
                libroConPrezzo.Autore = libro.Autore;
                libroConPrezzo.Codice = libro.Codice;
                libroConPrezzo.Genere = libro.Genere;
                libroConPrezzo.Titolo = libro.Titolo;
                libriConPrezzo.Add(libroConPrezzo);
            }

            dataGridView1.DataSource = libriConPrezzo;
            dataGridView1.Columns["Prezzo"].DisplayIndex = 5;
        }

        private void btn_salva_Click(object sender, EventArgs e)
        {
            var listaLibri = dataGridView1.DataSource as List<LibroConPrezzo>;
            var result = saveFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                using (var strWriter = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (var lp in listaLibri)
                    {
                        strWriter.WriteLine($"{lp.Codice}\t{lp.Autore}\t{lp.Anno}\t{lp.Genere}\t{lp.Prezzo}");
                    }
                }
            }
        }
    }
}
