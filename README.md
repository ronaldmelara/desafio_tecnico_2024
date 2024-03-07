# Desafío Técnico - Consalud 2024

Autor: Ronald Enrique Melara Serrano
Fecha entrega: 7 de marzo de 2024

## Enunciado del desafío.
Hola Ronald, buenas tardes

Te cuento que avanzaste a la segunda etapa del proceso de búsqueda para nuevo Desarrollador.

Es por ello, que te invitamos a realizar el siguiente ejercicio, para destacar tus habilidades como desarrollador.

Entre las consideraciones:
-Tienes hasta el Jueves 7 de marzo a las 15:00 pm para enviarnos la solución del ejercicio.  
-Debes enviarnos collection de postman para realizar pruebas.  
-Debes enviarnos link de swagger de la aplicación.  
-Debe ser desarrollado en .NetCore 6.

-Considerar capa de seguridad con el uso de una apiKey para todos los métodos.  
-Uso de códigos http según sea la respuesta.

-Implementar algún patrón de desarrollo según tu preferencia.  
-Debe compilar correctamente.

Por motivos de seguridad no podemos recibir comprimidos por el correo electrónico institucional, por favor publicar la solución en algún gestor de documentos, y nos compartes el link.  
  
**Ejercicio:**

Dado un Json con lista de facturas, este deberás utilizarlo como base de datos (No tiene el total de cada factura). El artefacto deberá considerar distintos métodos que permitan las siguientes acciones:

 - Retornar lista completa de las facturas y calcular el total de cada para cada una de ellas.  
 - Debe retornar las facturas de un comprador según su rut.  
 - Debe retornar el comprador que tenga mas compras.  
 - Retornar lista de compradores con el monto total de compras realizadas.  
 - Retornar lista de facturas agrupadas por comuna, y permitir buscar facturas de una comuna específica.  
  
Te adjuntamos el json DB .

## Solución.
Fue necesario utilizar los siguientes elementos:

 - Instalar Visual Studio 2022 para Mac OS (https://learn.microsoft.com/es-mx/visualstudio/releases/2022/mac-release-notes)
 - Instalar Postman
 - Instalar Dotnet SDK 6.0.419 para Mac (https://dotnet.microsoft.com/es-es/download/dotnet/6.0)
 - DBeaver 23.3.5

Una vez instalado los componentes, se crea un proyecto de tipo API (ASPNET Core) para dotnet 6.0. 
Para poder realizar este ejercicio utiliza el archivo json y se vuelca a una base de datos **SQLite**, en la cual construí las tablas que relacionan Facturas, Detalle de Facturas y Producto con el siguiente esquema.

![enter image description here](https://github.com/ronaldmelara/desafio_tecnico_2024/blob/main/esquema_db_1.png)

Adicional, existe la tabla "User" (esta se utiliza para la autenticación)![enter image description here](https://github.com/ronaldmelara/desafio_tecnico_2024/blob/main/esquema_bd_2.png)

Para fines de Autenticación, implementé **JWT**, donde, la dinámica será que cuando un "*cliente*" (llamaré asi a la aplicación que consume mi API) requiera consumir alguno de los métodos de consulta, este deberá proveer un **"Token Bearer"** para poder identificarse y que la API pueda devolver los datos.
De manera, que para conseguir lo anterior mi API expone los siguientes métodos:
| Path |Tipo  | Requiere Token | Descripción breve
|--|--|--|--|
| auth/New | POST  | N/A | Crear un nuevo usuario. Se retornará un token activo para 45min|
| auth/Login | POST  | N/A | Valida un usuario. Se retornará un token activo para 45min|
| api/v1/facturas | GET  | Si | Lista de Facturas|
| api/v1/facturas/{rut} | GET  | Si | Lista de Facturas por RUT|
| api/v1/facturas/clientes/frecuente | GET  | Si | Comprador con más compras|
| api/v1/facturas/clientes | GET  | Si | Lista clientes y compras realizadas|
| api/v1/facturas/comuna/{idComuna} | GET  | Si | Facturas relacionadas a una comuna específica|
| api/v1/facturas/comuna | GET  | Si | Lista de Facturas agrupadas por comuna|


En cuanto a ***codificación***: se construye una aplicación con arquitectura típica en **N Capas**.   Donde es posible distinguir los controladores, los servicios y librerías donde se agrupan el Modelo (Entidades, dto, Request, response),  DataAccess donde se exponen las interfaces de contrato que exponen los repositorios y sus métodos para acceder a datos mediante **EntityFramework**.
