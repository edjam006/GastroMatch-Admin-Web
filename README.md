# GastroMatch - Administración MVC

![GitHub build status](https://img.shields.io/github/actions/workflow/status/edjam006/GastroMatch-Admin-Web/dotnet.yml?branch=main)
![Language](https://img.shields.io/github/languages/top/edjam006/GastroMatch-Admin-Web)
![License](https://img.shields.io/github/license/edjam006/GastroMatch-Admin-Web)

Módulo administrativo diseñado para la gestión integral de la red gastronómica de GastroMatch. Este sistema permite administrar locales, menús y categorías, sirviendo como el núcleo de alimentación de datos para la plataforma inteligente de recomendaciones.

## 🚀 Requisitos Cumplidos

- **Validación de RUC en Back-End**: Implementación de lógica de validación robusta para el RUC (13 dígitos numéricos) con verificación de unicidad en la base de datos antes de permitir el guardado.
- **Dropdowns dinámicos en cascada**: Interfaz inteligente donde el selector de *Restaurante* se filtra automáticamente mediante AJAX según la *Categoría* seleccionada, optimizando la experiencia de carga de platos.

## 🛠️ Tecnologías Utilizadas

- **Core**: .NET 8 (ASP.NET Core MVC)
- **ORM**: Entity Framework Core
- **Base de Datos**: PostgreSQL (Hospedado en Supabase)
- **Contenerización**: Docker
- **Frontend**: Bootstrap 5 + jQuery (AJAX para cascada)

## 💻 Instrucciones de Ejecución Local

Para correr este proyecto localmente, sigue estos pasos:

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/edjam006/GastroMatch-Admin-Web.git
   cd GastroMatch-Admin-Web
   ```

2. **Restaurar dependencias**:
   ```bash
   dotnet restore
   ```

3. **Ejecutar la aplicación**:
   ```bash
   dotnet run
   ```
   La aplicación estará disponible en `http://localhost:5000` (o el puerto configurado en tu entorno).

## 🚢 Deployment

La aplicación está preparada para desplegarse automáticamente en Render mediante el Dockerfile incluido.

URL de producción: [AQUÍ VA EL LINK DE RENDER]

---
Desarrollado por **edjam006**
