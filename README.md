# Serial_Communication_Chat
Proyecto en C# que permite establecer un chat mediante comunicación serial, utilizando un sistema de tramas. Solución completa y confiable para el envío y recepción de mensajes entre dispositivos.

Este proyecto en C# ofrece una solución completa para la comunicación mediante puerto serial, utilizando un sistema de transmisión y recepción de mensajes por tramas. El proyecto consta de dos aplicaciones independientes: una como transmisor y otra como receptor.

El transmisor permite enviar mensajes a través del puerto serial hacia el receptor. Se definen tramas de mensajes estructuradas para garantizar una comunicación confiable entre ambos extremos. El proyecto utiliza la clase SerialPort de C# para establecer la conexión con el puerto serial y enviar los datos.

Por su parte, el receptor está diseñado para recibir las tramas de mensajes enviadas por el transmisor a través del puerto serial. Después de recibir una trama, la aplicación procesa los datos según el formato especificado y toma las acciones correspondientes. También se implementan mecanismos de control de errores para asegurar la integridad de la comunicación.

Este proyecto proporciona una base sólida para aquellos que deseen implementar la comunicación por puerto serial en sus propias aplicaciones. Al publicarlo en GitHub, se busca compartir esta solución con la comunidad y permitir a otros desarrolladores aprovecharlo, mejorarlo o adaptarlo a sus necesidades específicas.
