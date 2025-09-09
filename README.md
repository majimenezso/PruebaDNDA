# Prueba Técnica – API .NET 8 + Angular DNRA

Proyecto fullstack que integra un **Backend en .NET 8** con una **SPA en Angular 19**, utilizando **MySQL 8** como motor de base de datos y tecnologías modernas como **TailwindCSS** y **SweetAlert2**.

##  Requisitos
###  Herramientas necesarias

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js 18+](https://nodejs.org/)
- [Angular CLI 19](https://angular.io/cli)
- [MySQL 8.x](https://dev.mysql.com/downloads/mysql/)
- [XAMPP](https://www.apachefriends.org/es/index.html) con MySQL 8.0 *(opcional)*
- VS Code o [Cursor](https://cursor.so/)
- Docker *(opcional para levantar MySQL con contenedor)*

##  Estructura del Proyecto
PruebaTecnica.Api → API en .NET 8
frontend-prueba → Aplicación Angular 19
BASE DE DATOS → Script SQL de la base de datos (opcional)

Backend :

Configura el archivo appsettings.json con tu conexión local a MySQL

{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=pruebatecnica;user=root;password=;"
  }
}

Restaurar y ejecutar los paquetes :

dotnet restore

dotnet run



Frontend :

instalar las dependencias

npm install


correr el serivicio

ng serve


ejecutar la url en el navegador

http://localhost:4200
