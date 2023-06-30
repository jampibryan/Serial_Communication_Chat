using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Windows.Forms;

using System.Threading; //podemos utilizar las hebras

namespace windLaboratorio001
{
    class miClase
    {
        //Plantilla de delegados, mi manejador de eventos como plantilla
        //puede ejecutar cualquier metodo que tenga como argumento (object y string)

        public delegate void miManejadorEventos(object oo, string ss);

        public event miManejadorEventos LlegoMensaje;

        byte cantidad;
        byte[] cantidadMensajeArr;

        string mensajeRecibido;
        string mensajeEnviado;
        byte[] ArregloTramaEnvio;
        byte[] ArregloTramaRelleno;
        byte[] ArregloTramaCabecera;
        byte[] TramaRecibida;



        SerialPort sPuerto; //Nos va a permitir transmitir bit por bit a través
                            //de un formato predefinido usando el puerto de comunicaciones.

        Thread procesoEnvio; //Una hebra ejecuta un proceso, 
                             //el proceso está dentro de un procedimiento

        public void iniciar(string puerto, int baudios, string pariedad, string stop)
        {
            sPuerto = new SerialPort();
            sPuerto.PortName = puerto;  //Nombre del puerto
            sPuerto.DataBits = 8;       //Cantidad de bits de datos(tamaño)
            sPuerto.BaudRate = baudios;    //Velocidad en baulios
            sPuerto.ReceivedBytesThreshold = 1024; //Indica que cuando llegue 1024bytes
                                                   //se va a disparar el evento sPuerto_DataReceived

            sPuerto.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stop, true);
            sPuerto.Parity = (Parity)Enum.Parse(typeof(Parity), pariedad, true);
            sPuerto.Open();

            //Este evento DataReceived se dispara cuando llegan una cierta cantidad bytes
            sPuerto.DataReceived += new SerialDataReceivedEventHandler(sPuerto_DataReceived);

            ArregloTramaEnvio = new byte[1024]; //Le damos el tamaño máximo a dicho arreglo
            ArregloTramaRelleno = new byte[1024]; //La trama enviada tendrá tamaño de 1024.
            ArregloTramaCabecera = new byte[8]; //
            TramaRecibida = new byte[1024];

            for (int i = 0; i < 1024; i++)
                ArregloTramaRelleno[i] = 64;

        }

        public void envio(string mens)
        {
            mensajeEnviado = mens;
            procesoEnvio = new Thread(EnviandoMensaje);
            procesoEnvio.Start();
        }

        private void EnviandoMensaje()
        {
            int tamano;
            int tamanodTamano;

            try
            {
                ArregloTramaEnvio = Encoding.UTF8.GetBytes(mensajeEnviado);
                tamano = ArregloTramaEnvio.Length;
                tamanodTamano = tamano.ToString().Length;

                if (ArregloTramaEnvio.Length > 1016)
                {
                    throw new Exception("Por favor, vuelva a enviar un mensaje");
                }

                //Valor de 1 si los mensajes contiene hasta 9 caracteres
                //Valor de 2 si los mensajes contiene hasta 10-99 caracteres
                //Valor de 3 si los mensajes contiene hasta 100-999 caracteres
                //Valor de 4 si los mensajes contiene hasta 1000-1015 caracteres

                if (tamanodTamano == 1)
                {
                    ArregloTramaCabecera = ASCIIEncoding.UTF8.GetBytes("0000000" + tamano.ToString());
                }
                if (tamanodTamano == 2)
                {
                    ArregloTramaCabecera = ASCIIEncoding.UTF8.GetBytes("000000" + tamano.ToString());
                }
                if (tamanodTamano == 3)
                {
                    ArregloTramaCabecera = ASCIIEncoding.UTF8.GetBytes("00000" + tamano.ToString());
                }
                if (tamanodTamano == 4)
                {
                    ArregloTramaCabecera = ASCIIEncoding.UTF8.GetBytes("0000" + tamano.ToString());
                }


                //Este método "write" espera que salgan todos los bytes 
                //para que después recién se ejecute el MessageBox
                sPuerto.Write(ArregloTramaCabecera, 0, 8);
                sPuerto.Write(ArregloTramaEnvio, 0, tamano);

                sPuerto.Write(ArregloTramaRelleno, 0, 1016 - tamano);
            }
            catch (Exception e)
            {
                MessageBox.Show("El mensaje tiene que contener máximo 1016 bytes " + e);
            }
        }


        //Este método se va a llamar a través del delegado, 
        //para que se desencadene cuando se dispare el evento de recepción
        private void sPuerto_DataReceived(object o, SerialDataReceivedEventArgs eee)
        {
            if (sPuerto.BytesToRead >= 1024)
            {
                try
                {
                    
                    int LongValMsgeRecibido = 0;
                    //EXTRAEMOS TODA LA TRAMA QUE HA LLEGADO

                    sPuerto.Read(TramaRecibida, 0, 1024);

                    LongValMsgeRecibido = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 8));

                    mensajeRecibido = ASCIIEncoding.UTF8.GetString(TramaRecibida, 8, LongValMsgeRecibido);

                    Array.Clear(TramaRecibida, 0, 1024);


                    //"OnLlegoMensaje(mensajeRecibido);" se utiliza para invocar 
                    //el evento "LlegoMensaje" de una clase y pasarle un parámetro "mensajeRecibido".
                    OnLlegoMensaje(mensajeRecibido);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrió un error" + e);
                }

            }
        }


        //El virtual void se usa para disparar un evento
        protected virtual void OnLlegoMensaje(string s)
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, s);
        }
    }
}
