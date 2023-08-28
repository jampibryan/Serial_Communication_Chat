using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        //Envio
        private string rutaCompletaArchivoEnviar;
        private long progresoTotal;  // Variable para realizar el seguimiento del progreso total
        private string extension;
        private long tamanoArchivo;

        //Recibir
        private string rutaDirectorioDestino;

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
            // Suscribirse al evento ProgresoActualizado de miclase
            puertoC.ProgresoActualizado += ActualizarBarraCarga;
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
                txtChat.Text += "Tú: " + txtMensaje.Text + Environment.NewLine;
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
            txtChat.Text += "Bryan: " + cadena + Environment.NewLine;
        }


        //OBTENER INFORMACIÓN DEL ARCHIVO A ENVIAR
        private void btn_InfoArchivoEnviar_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    /*Aquí se asigna la ruta del archivo seleccionado a la variable.*/
                    rutaCompletaArchivoEnviar = dialog.FileName;
                    extension = Path.GetExtension(rutaCompletaArchivoEnviar);

                    txtNombreArchivoEnviar.Text = rutaCompletaArchivoEnviar;

                }
            }
        }


        //OBTENER EL DIRECTORIO DEL NUEVO ARCHIVO A CREAR
        private void btnInfoDirectorioRecibir_Click(object sender, EventArgs e)
        {
            /* Aquí se utiliza la declaración using para crear una instancia del diálogo 
            de selección de carpeta (FolderBrowserDialog). La declaración using se encarga 
            de liberar automáticamente los recursos utilizados por el diálogo 
            una vez que se haya terminado su uso. */
            using (var dialog = new FolderBrowserDialog())
            {
                /* Esta línea muestra el diálogo de selección de carpeta 
                y comprueba si el resultado es DialogResult.OK, 
                lo que indica que el usuario ha seleccionado una carpeta y ha hecho clic 
                en el botón "Aceptar".*/
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    /*Aquí se asigna la ruta de la carpeta seleccionada 
                    a la variable rutaNuevoAchivo.*/
                    rutaDirectorioDestino = dialog.SelectedPath;
                    txtRutaRecibida.Text = rutaDirectorioDestino;
                }
            }
        }


        private void btnEnviarArchivo_Click(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            progresoTotal = 0;
            string rutaCompletaDestino = rutaDirectorioDestino + "\\" + txtNombreArchivoCreado.Text + extension;

            puertoC.IniciaEnvioArchivo(rutaCompletaArchivoEnviar, rutaCompletaDestino);
        }


        private void ActualizarBarraCarga(long avance, long tamanio)
        {
            // Incrementar el progreso total
            progresoTotal = avance;

            // Calcular el valor porcentual
            int porcentaje = Convert.ToInt32(((decimal)progresoTotal / tamanio) * 100);

            // Asegurarse de que el porcentaje esté dentro del rango válido
            porcentaje = Math.Max(Math.Min(porcentaje, 100), 0);

            // Actualizar la barra de carga en el hilo de la interfaz de usuario
            Invoke((MethodInvoker)delegate
            {
                BarraProgreso.Value = porcentaje;

                if (porcentaje == 100)
                {
                    porcentajeActual.Text = "Envio Completado";
                }
                else
                {
                    // Establecer el valor de avance de la barra de carga
                    porcentajeActual.Text = porcentaje.ToString() + "%";
                }
            });
        }

        private void btn_InfoArchivoEnviar_Click_1(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    /*Aquí se asigna la ruta del archivo seleccionado a la variable.*/
                    rutaCompletaArchivoEnviar = dialog.FileName;
                    extension = Path.GetExtension(rutaCompletaArchivoEnviar);

                    txtNombreArchivoEnviar.Text = rutaCompletaArchivoEnviar;

                }
            }
        }

        private void btnInfoDirectorioRecibir_Click_2(object sender, EventArgs e)
        {
            /* Aquí se utiliza la declaración using para crear una instancia del diálogo 
            de selección de carpeta (FolderBrowserDialog). La declaración using se encarga 
            de liberar automáticamente los recursos utilizados por el diálogo 
            una vez que se haya terminado su uso. */
            using (var dialog = new FolderBrowserDialog())
            {
                /* Esta línea muestra el diálogo de selección de carpeta 
                y comprueba si el resultado es DialogResult.OK, 
                lo que indica que el usuario ha seleccionado una carpeta y ha hecho clic 
                en el botón "Aceptar".*/
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    /*Aquí se asigna la ruta de la carpeta seleccionada 
                    a la variable rutaNuevoAchivo.*/
                    rutaDirectorioDestino = dialog.SelectedPath;
                    txtRutaRecibida.Text = rutaDirectorioDestino;
                }
            }
        }

        private void btnEnviarArchivo_Click_2(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            progresoTotal = 0;
            string rutaCompletaDestino = rutaDirectorioDestino + "\\" + txtNombreArchivoCreado.Text + extension;

            puertoC.IniciaEnvioArchivo(rutaCompletaArchivoEnviar, rutaCompletaDestino);
        }
    }
}
