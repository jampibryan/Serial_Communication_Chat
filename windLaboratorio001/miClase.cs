using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Windows.Forms;

using System.Threading;
using System.IO;

namespace windLaboratorio001
{
    class miClase
    {
        //Plantilla de delegados, mi manejador de eventos como plantilla
        //puede ejecutar cualquier metodo que tenga como argumento (object y string)

        public delegate void miManejadorEventos(object oo, string ss);

        public event miManejadorEventos LlegoMensaje;


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



        private Boolean BufferSalidaVacio;

        Thread procesoEnvioArchivo;
        Thread procesoConstruyeArchivo;

        private ClaseArchivo archivoEnviar;//Guarda  información del archivo que vamos a enviar
        private FileStream FlujoArchivoEnviar; //Establece un flujo del archivo a enviar
        private BinaryReader LeyendoArchivo; //Con el BinaryReader leermos el archivo abierto que queremos transmitir


        private ClaseArchivo archivoRecibir; //Guarda  información del archivo que estamos recibiendo
        private FileStream FlujoArchivoRecibir;
        private BinaryWriter EscribiendoArchivo;
        //Con el BinaryWriter vamos a escribir en el archivo que hemos creado

        Thread procesoVerificaSalida;
        Thread procesoRecibirMensaje;

        //string nameNewArchivo;

        //ARREGLOS PARA EL ENVÍO DE LA PRIMERA TRAMA(NOMBRE Y TAMAÑO DEL ARCHIVO A CREAR)
        byte[] TramaLongitudNombreNewArchivo;
        byte[] TramaNombreNewArchivo;
        byte[] TramaTamanoNewArchivo;
        byte[] TramaLongitudTamanoNewArchivo;


        //Definimos un evento que notificará el progreso actualizado(Barra)
        public delegate void ProgresoActualizadoEventHandler(long avance, long tamanio);
        public event ProgresoActualizadoEventHandler ProgresoActualizado;


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

            BufferSalidaVacio = true;

            procesoVerificaSalida = new Thread(VerificandoSalida);
            procesoVerificaSalida.Start();

            archivoEnviar = new ClaseArchivo();
            archivoRecibir = new ClaseArchivo();

            MessageBox.Show("apertura del puerto" + sPuerto.PortName);


            ArregloTramaEnvio = new byte[1024];
            ArregloTramaRelleno = new byte[1024];
            ArregloTramaCabecera = new byte[8];
            TramaRecibida = new byte[1024];

            for (int i = 0; i < 1024; i++)
                ArregloTramaRelleno[i] = 64;
        }



        //Este método se va a llamar a través del delegado, 
        //para que se desencadene cuando se dispare el evento de recepción
        private void sPuerto_DataReceived(object o, SerialDataReceivedEventArgs eee)
        {
            if (sPuerto.BytesToRead >= 1024)
            {
                sPuerto.Read(TramaRecibida, 0, 1024);

                //MessageBox.Show(ASCIIEncoding.UTF8.GetString(TramaRecibida));

                string TAREA = ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 2);

                switch (TAREA)
                {
                    case "00":
                        procesoRecibirMensaje = new Thread(RecibiendoMensaje);
                        procesoRecibirMensaje.Start();
                        break;

                    case "AI":

                        int longitudNombre = Convert.ToInt32(Encoding.UTF8.GetString(TramaRecibida, 5, 2)); // 19
                        string nombreNewArchivo = Encoding.UTF8.GetString(TramaRecibida, 7, longitudNombre); // "D:\PRUEBA\copia.jpg"

                        int longitudArchivo = Convert.ToInt32(Encoding.UTF8.GetString(TramaRecibida, 7 + longitudNombre, 1)); // 5
                        long tamanoNewArchivo = long.Parse(Encoding.UTF8.GetString(TramaRecibida, 7 + longitudNombre + 1, longitudArchivo)); // 19665

                        InicioConstruirArchivo(nombreNewArchivo, tamanoNewArchivo);
                        break;

                    case "AC":
                        ConstruirArchivo();
                        break;

                    default:
                        MessageBox.Show("trama no reconocida");
                        break;
                }

            }
        }


        //ENVIOOO MENSAJEEE
        public void envio(string mens)
        {
            mensajeEnviado = mens;
            procesoEnvio = new Thread(EnviandoMensaje);
            procesoEnvio.Start();
        }

        //ENVIOOO MENSAJEEE
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


        //RECIBEEEEE MENSAJEEE
        private void RecibiendoMensaje()
        {
            try
            {
                int LongValMsgeRecibido = 0;

                LongValMsgeRecibido = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 8));

                mensajeRecibido = ASCIIEncoding.UTF8.GetString(TramaRecibida, 8, LongValMsgeRecibido);

                //"OnLlegoMensaje(mensajeRecibido);" se utiliza para invocar 
                //el evento "LlegoMensaje" de una clase y pasarle un parámetro "mensajeRecibido".
                OnLlegoMensaje(mensajeRecibido);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error" + e);
            }

        }


        //El virtual void se usa para disparar un evento
        protected virtual void OnLlegoMensaje(string s)
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, s);
        }


        //---------------------VERIFICA SI HAY DATOS PENDIENTES PARA ESCRIBIR---------------
        private void VerificandoSalida()
        {
            while (true)
            {
                //propiedad BytesToWrite del objeto puerto(serial port), se utiliza para verificar 
                //si hay datos pendientes para escribir en el puerto o dispositivo de comunicación.
                if (sPuerto.BytesToWrite > 0)
                    BufferSalidaVacio = false; // indica que el búfer de salida no está vacío.
                else
                    BufferSalidaVacio = true;
            }
        }


        //------------------------ENVÍO DE ARCHIVO---------------------------------

        //Este es el método que configura lo necesario para enviar un archivo
        public void IniciaEnvioArchivo(string nombreEnviarArchivo, string nombreNewArchivo)
        {
            FlujoArchivoEnviar = new FileStream(nombreEnviarArchivo, FileMode.Open, FileAccess.Read);
            LeyendoArchivo = new BinaryReader(FlujoArchivoEnviar);

            archivoEnviar.Nombre = nombreEnviarArchivo;
            archivoEnviar.Tamaño = Convert.ToInt32(FlujoArchivoEnviar.Length);
            archivoEnviar.Avance = 0; //Avance de lectura que en primera instancia es 0 porque no hemos leído nada.
            archivoEnviar.Num = 1; //El número de archivo abierto 


            archivoEnviar.newNombreCompleto = nombreNewArchivo;  //"D:\PRUEBA\copia.jpg"

            archivoEnviar.longitudNombre = nombreNewArchivo.Length; //19

            archivoEnviar.tamañoString = archivoEnviar.Tamaño.ToString();//"19665"
            archivoEnviar.longitudTamaño = archivoEnviar.tamañoString.Length;//5

            archivoEnviar.primeraTramaActiva = true;

            procesoEnvioArchivo = new Thread(EnviandoArchivo);
            procesoEnvioArchivo.Start();
        }

        private void EnviandoArchivo()
        {
            byte[] TramaEnvioArchivo;
            byte[] TramCabaceraEnvioArchivo;

            TramaEnvioArchivo = new byte[1019];
            TramCabaceraEnvioArchivo = new byte[5];


            //ENVIAR LA PRIMERA TRAMA CON EL NOMBRE Y TAMAÑO DEL NUEVO ARCHIVO;
            if (archivoEnviar.primeraTramaActiva == true)
            {
                TramCabaceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes("AI001");

                TramaLongitudNombreNewArchivo = Encoding.UTF8.GetBytes(archivoEnviar.longitudNombre.ToString()); //[1,9]
                TramaNombreNewArchivo = Encoding.UTF8.GetBytes(archivoEnviar.newNombreCompleto);//[D,:,\,P,R,U,E,B,A,\,c,o,p,i,a,.,j,p,g] //19

                TramaLongitudTamanoNewArchivo = ASCIIEncoding.UTF8.GetBytes(archivoEnviar.longitudTamaño.ToString()); //[5]          
                TramaTamanoNewArchivo = ASCIIEncoding.UTF8.GetBytes(archivoEnviar.tamañoString); //[1,9,6,6,5]

                archivoEnviar.primeraTramaActiva = false;

                //ENVIO DE LA PRIMERA TRAMA---------------------------------------
                sPuerto.Write(TramCabaceraEnvioArchivo, 0, 5);

                //LONGITUD DEL NOMBRE Y NOMBRE
                sPuerto.Write(TramaLongitudNombreNewArchivo, 0, TramaLongitudNombreNewArchivo.Length); //2
                sPuerto.Write(TramaNombreNewArchivo, 0, TramaNombreNewArchivo.Length); //19

                //LONGITUD DEL TAMAÑO ARCHIVO Y TAMAÑO
                sPuerto.Write(TramaLongitudTamanoNewArchivo, 0, TramaLongitudTamanoNewArchivo.Length); //1
                sPuerto.Write(TramaTamanoNewArchivo, 0, TramaTamanoNewArchivo.Length); //"19665"

                int rellenoLength = 1019 - (TramaLongitudNombreNewArchivo.Length + TramaNombreNewArchivo.Length +
                                TramaLongitudTamanoNewArchivo.Length + TramaTamanoNewArchivo.Length);
                sPuerto.Write(ArregloTramaRelleno, 0, rellenoLength);
            }


            Thread.Sleep(1000); // Pausa de 1 segundo

            if (archivoEnviar.primeraTramaActiva == false)
            {
                //ENVIAR LAS TRAMAS DEL ARCHIVO
                TramCabaceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes("AC001");

                while (archivoEnviar.Avance <= archivoEnviar.Tamaño - 1019)
                {
                    LeyendoArchivo.Read(TramaEnvioArchivo, 0, 1019); //Extraemos 1019 bytes de flujo y se lo pasamos a TramaEnvioArchivo
                                                                     //LeyendoArchivo es el BinaryReader que lee el flujo donde está el archivo a transmitir                                                                  
                    Thread.Sleep(100); // Pausa de 100 milisegundos

                    archivoEnviar.Avance = archivoEnviar.Avance + 1019;
                    
                    sPuerto.Write(TramCabaceraEnvioArchivo, 0, 5);
                    sPuerto.Write(TramaEnvioArchivo, 0, 1019);
                }
                int tamanito = Convert.ToInt16(archivoEnviar.Tamaño - archivoEnviar.Avance);
                LeyendoArchivo.Read(TramaEnvioArchivo, 0, tamanito);
                Thread.Sleep(100); // Pausa de 100 milisegundos
          
                sPuerto.Write(TramCabaceraEnvioArchivo, 0, 5);
                sPuerto.Write(TramaEnvioArchivo, 0, tamanito);
                sPuerto.Write(ArregloTramaRelleno, 0, 1019 - tamanito);

                LeyendoArchivo.Close();
                FlujoArchivoEnviar.Close();
            }
        }



        //------------------------CREACIÓN DE ARCHIVO---------------------------------

        private void InicioConstruirArchivo(string nombre, long tama)
        {
            FlujoArchivoRecibir = new FileStream(nombre, FileMode.Create, FileAccess.Write);
            EscribiendoArchivo = new BinaryWriter(FlujoArchivoRecibir);
            archivoRecibir.Nombre = nombre;
            archivoRecibir.Num = 1;
            archivoRecibir.Tamaño = tama;
            archivoRecibir.Avance = 0;
        }

        //------------------------ENVÍO DE ARCHIVO---------------------------------

        private void ConstruirArchivo()
        {
            long avancerecep;

            // debe realizarse en funcion del tamaño 1019 y la ultima será tamanito

            if (archivoRecibir.Avance <= archivoRecibir.Tamaño - 1019)
            {
                EscribiendoArchivo.Write(TramaRecibida, 5, 1019);

                archivoRecibir.Avance = archivoRecibir.Avance + 1019;
                avancerecep = archivoRecibir.Avance;
            }

            else
            {
                int tamanito = Convert.ToInt16(archivoRecibir.Tamaño - archivoRecibir.Avance);
                EscribiendoArchivo.Write(TramaRecibida, 5, tamanito);
                avancerecep = archivoRecibir.Avance + tamanito;

                EscribiendoArchivo.Close();
                FlujoArchivoRecibir.Close();
            }
            long tamanio = archivoRecibir.Tamaño;

            //Notificar el progreso actualizado a través del evento
            ProgresoActualizado?.Invoke(avancerecep, tamanio);
        }
    }
}
