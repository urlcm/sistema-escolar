<div align="center">

# 🏫 Sistema Escolar

> Aplicación de escritorio para la **gestión integral de instituciones educativas** — alumnos, maestros, tareas, grados y grupos — construida con C#, WinForms y SQL Server bajo arquitectura MVC.

[![C#](https://img.shields.io/badge/C%23-.NET-512BD4?style=for-the-badge&logo=csharp&logoColor=white)](https://dotnet.microsoft.com/)
[![WinForms](https://img.shields.io/badge/UI-WinForms-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![MVC](https://img.shields.io/badge/Arquitectura-MVC-6DB33F?style=for-the-badge)](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)

</div>

---

## 📌 ¿Qué es este proyecto?

Sistema Escolar es una aplicación de escritorio que permite a instituciones educativas administrar su operación académica desde una sola herramienta. Cubre el ciclo completo: registro de alumnos y maestros, organización por grados y grupos, y seguimiento de tareas.

Desarrollado en C# con WinForms y SQL Server, aplicando el patrón **MVC** para mantener separación entre lógica de negocio, acceso a datos e interfaz de usuario.

> 💡 Este fue un proyecto previo en mi aprendizaje de C# y .NET. Mi proyecto más reciente — una [Plataforma de Lógica de Programación con IA](https://github.com/urlcm/plataforma-logica-de-programacion) usando Java, Spring Boot, Angular y Docker o [La aplicaciion del hospital Christus](https://github.com/urlcm/visualizador-de-datos) usando C# Windows Forms, SQL Server, websockets — refleja mi stack actual.

---

## 📸 Capturas de pantalla

## Login
<img width="920" height="563" alt="Image" src="https://github.com/user-attachments/assets/a99e9fba-1b3b-441d-91e4-951d624a7a6d" />

## Sesión de administrador
<img width="941" height="474" alt="Image" src="https://github.com/user-attachments/assets/b2e1434a-0a6a-4f45-8d46-ad6992e06f78" />

## Sesión de padre
<img width="945" height="560" alt="Image" src="https://github.com/user-attachments/assets/93d7b776-12d4-4d45-9f12-357a1f755e6f" />

## Sesión de alumno
<img width="945" height="560" alt="Image" src="https://github.com/user-attachments/assets/e14ee126-ab7d-43dc-935f-7b0d12f306f1" />


## Video del sistema

---

## ✨ Funcionalidades

- 👩‍🎓 **Gestión de alumnos** — Alta, baja, modificación y consulta de estudiantes
- 👨‍🏫 **Gestión de maestros** — Registro y administración del personal docente
- 📚 **Gestión de tareas** — Creación y asignación de tareas por grupo o materia
- 🏫 **Grados y grupos** — Organización jerárquica del alumnado por nivel y grupo
- 🔍 **Consultas y filtros** — Búsqueda y listado de registros por distintos criterios
- 📋 **Generación de reportes** —Creación de reportes en formato de PDF o Excel

---

## 🏗️ Arquitectura MVC

```
sistema-escolar/
├── Models/             # Entidades del dominio (Alumno, Maestro, Tarea, Grupo...)
├── Controllers/        # Lógica de negocio y coordinación entre capas
├── SistemaEscolar/     # Vistas — formularios WinForms
├── packages/           # Dependencias NuGet
└── SistemaEscolar.sln  # Solución de Visual Studio
```

| Capa | Responsabilidad |
|---|---|
| **Models** | Entidades del dominio y lógica de datos |
| **Controllers** | Coordinan las acciones del usuario con los modelos |
| **Views** | Formularios WinForms que presentan la información al usuario |

---

## 🧰 Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| **C#** | Lenguaje principal |
| **.NET Framework** | Plataforma de ejecución |
| **WinForms** | Framework de interfaz de usuario de escritorio |
| **SQL Server** | Base de datos relacional para persistencia |
| **Visual Studio** | Entorno de desarrollo |
| **NuGet** | Gestión de dependencias |

---

## 🚀 Cómo correr el proyecto

### Prerrequisitos
- [Visual Studio](https://visualstudio.microsoft.com/) 2019 o superior
- SQL Server instalado y corriendo localmente
- .NET Framework compatible con el proyecto

### Pasos

```bash
# 1. Clonar el repositorio
git clone https://github.com/urlcm/sistema-escolar.git
cd sistema-escolar
```

```
# 2. Abrir la solución en Visual Studio
Doble clic en SistemaEscolar.sln

# 3. Configurar la cadena de conexión a SQL Server
Busca el archivo de configuración (App.config o similar)
y actualiza el connectionString con tu instancia de SQL Server

# 4. Restaurar dependencias NuGet
Clic derecho en la solución → Restore NuGet Packages

# 5. Compilar y ejecutar
F5 o botón "Start"
```

---

## 💡 Decisiones técnicas

- **MVC en aplicación de escritorio** — Aplicar MVC fuera del contexto web requiere disciplina extra, ya que WinForms no lo impone por defecto. Se estructuró manualmente para mantener el código organizado y desacoplado
- **SQL Server como motor de persistencia** — Elección orientada a entornos institucionales donde SQL Server es el estándar corporativo más común
- **Una entidad, un modelo** — Cada entidad del dominio (Alumno, Maestro, Tarea, Grupo) tiene su propia clase en `Models`, lo que facilita extender el sistema sin romper otras partes


---

## 👨‍💻 Autor

**[urlcm](https://github.com/urlcm)** · Desarrollador Fullstack

> ¿Tienes feedback o preguntas? Abre un Issue.

---

<div align="center">
⭐ Si este proyecto te resultó útil, considera darle una estrella
</div>
