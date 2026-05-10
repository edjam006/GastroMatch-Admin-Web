# GastroMatch - Administración MVC

![.NET 8](https://img.shields.io/badge/.NET-8.0-512bd4?style=flat&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=flat&logo=postgresql&logoColor=white)
![Supabase](https://img.shields.io/badge/Supabase-3ECF8E?style=flat&logo=supabase&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![Render](https://img.shields.io/badge/Render-46E3B7?style=flat&logo=render&logoColor=white)

Módulo administrativo diseñado para la gestión integral de la red gastronómica de GastroMatch. Este sistema permite administrar locales, menús y categorías, sirviendo como el núcleo de alimentación de datos para la plataforma inteligente de recomendaciones.

## 🚀 Requisitos Implementados

- **Validación de RUC en Back-End**: Implementación de lógica de validación para el RUC (13 dígitos numéricos) con verificación de unicidad en la base de datos.
- **Dropdowns dinámicos en cascada**: Interfaz donde el selector de *Restaurante* se filtra automáticamente mediante AJAX según la *Categoría* seleccionada.

## 🛠️ Tecnologías Utilizadas

- **Backend**: .NET 8 (ASP.NET Core MVC)
- **ORM**: Entity Framework Core
- **Base de Datos**: PostgreSQL (Hospedado en Supabase)
- **Contenerización**: Docker
- **Infraestructura**: Render

## 💻 Instrucciones de Ejecución Local

Para ejecutar el proyecto en un entorno local:

1. **Clonación del repositorio**:
   ```bash
   git clone https://github.com/edjam006/GastroMatch-Admin-Web.git
   cd GastroMatch-Admin-Web
   ```

2. **Restauración de dependencias**:
   ```bash
   dotnet restore
   ```

3. **Ejecución de la aplicación**:
   ```bash
   dotnet run
   ```
   La aplicación se encuentra disponible de forma predeterminada en los puertos configurados por el SDK de .NET.

## 🚢 Despliegue

La aplicación se encuentra desplegada y operativa en la plataforma Render.

**Link de Producción**: [https://gastromatch-admin.onrender.com](https://gastromatch-admin.onrender.com)

---
Desarrollado por **edjam006**
