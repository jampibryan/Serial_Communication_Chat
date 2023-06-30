using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windLaboratorio001
{
    public partial class Form1 : Form
    {
        //La declaración de un delegado es una plantilla para ser usada en un proceso
        public delegate void plantilla(string mensaje);

        //esta plantilla declara un proceso
        plantilla proceso1; //Aquí declaramos

        //Declaración de variables de la configuración previa
        public string puerto;
        public int baudios;
        public string pariedad;
        public string stop;


        miClase puertoC;

        public Form1(string puerto, int baudios, string pariedad, string stop)
        {
            InitializeComponent();
            this.puerto = puerto;
            this.baudios = baudios;
            this.pariedad = pariedad;
            this.stop = stop;
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            puertoC = new miClase();
            puertoC.iniciar(puerto, baudios, pariedad, stop);
            puertoC.LlegoMensaje += new miClase.miManejadorEventos(puertoC_llegoMensaje);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DATO: PASAMOS EL MENSAJE A UN ARREGLO PARA SABER SU LONGITUD REAL 
            // YA QUE NUESTRO MENSAJE PUEDE CONTENER ALGUNA TILDE
            //Y LA TILDE ES DE 2 BYTES
            //ASÍ EVITAMOS QUE NO EXCEDA LOS 1016 BYTES

            byte[] ArregloMensaje = Encoding.UTF8.GetBytes(txtMensaje.Text);

            puertoC.envio(txtMensaje.Text);

            if (ArregloMensaje.Length <= 1016)
            {
                txtChat.Text += "Bryan: " + txtMensaje.Text + Environment.NewLine;
            }

            txtMensaje.Clear();
        }

        private void puertoC_llegoMensaje(object o, string s)
        {
           
            //proceso1 ejecuta el procedimiento arre
            proceso1 = new plantilla(mensajeSubido); //Aquí instanciamos

            //Invoke - permite ejecutar procesos
            this.Invoke(proceso1, s);

            //Aquí estoy llamando a proceso1 que es de tipo plantilla, y que ejecuta arre
            //Y como arre necesita un argumento, le pasamos el argumento(s)
        }

        private void mensajeSubido(string cadena)
        {
            txtChat.Text += "Karen: " + cadena + Environment.NewLine;
        }
    }
}
