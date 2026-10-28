## Backend .NET Para E-Commerce "Blackhellheim" con Clean Architecture
Este es un proyecto creado con .NET 10 siguiendo el modelo de desarrollo de Clean Architecture.
Este backend aun sigue en desarrollo. **No debe tomarse como un proyecto terminado**

# Caracteristicas
1. Las capas Aplicacion y Dominio de Clean Architecture estan dentro de la carpeta Core.
1. Las capas Aplicación y Dominio son Class Libraries.
1. La capa de Presentación se encuentra dentro de la carpeta API, y es una Web Api MVC de Net Core.

# ¿Como probar el proyecto?
## Requisitos Previos
1. Docker Compose y Docker intalados en tu sistema, ya sea Windows o Linux

## Instrucciones
1. Clona este repositorio en tu computadora
1. Ejecuta ```docker compose up -d``` desde la carpeta raiz del proyecto