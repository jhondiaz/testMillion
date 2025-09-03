# TestMillion - Arquitectura

## Descripción General

TestMillion es una aplicación web API desarrollada en C# que implementa una arquitectura limpia (Clean Architecture) siguiendo los principios de Clean Architecture de Robert C. Martin (Uncle Bob). El proyecto está estructurado en múltiples capas con responsabilidades bien definidas y utiliza patrones de diseño modernos para mantener la separación de concerns y la testabilidad.

## Arquitectura General

El proyecto implementa la **Arquitectura Limpia (Clean Architecture)** con las siguientes capas organizadas de adentro hacia afuera:

### 1. **Entities (Entidades)**
- **Ubicación**: `TestMillion.Entities`
- **Responsabilidad**: Contiene las entidades de dominio y reglas de negocio centrales
- **Independencia**: No depende de ninguna otra capa
- **Componentes**:
  - `POCOs/`: Objetos de dominio (Owner, Property, PropertyImage, PropertyTrace, Entity)
  - `Interfaces/`: Contratos de repositorios (IPropertyRepository, IOwnerRepository, etc.)
  - `Exceptions/`: Excepciones de dominio

### 2. **Use Cases (Casos de Uso)**
- **Ubicación**: `TestMillion.UseCase`
- **Responsabilidad**: Implementa la lógica de negocio y orquesta las operaciones
- **Dependencias**: Solo depende de Entities
- **Componentes**:
  - `CreateProperty/`, `UpdateProperty/`, `GetProperties/`, etc.
  - Cada caso de uso tiene su Interactor y Validator
  - `Mappings/`: Configuración de AutoMapper

### 3. **Use Cases Ports (Puertos de Casos de Uso)**
- **Ubicación**: `TestMillion.UseCasesPort`
- **Responsabilidad**: Define las interfaces de entrada y salida para los casos de uso
- **Patrón**: Ports and Adapters (Hexagonal Architecture)
- **Componentes**:
  - `InputPorts/`: Interfaces para entrada de datos
  - `OutputPorts/`: Interfaces para salida de datos

### 4. **Interface Adapters (Adaptadores de Interfaz)**
- **Ubicación**: `TestMillion.Controllers`, `TestMillion.Presenters`
- **Responsabilidad**: Adapta la aplicación para diferentes interfaces
- **Componentes**:
  - **Controllers**: Manejan las peticiones HTTP
  - **Presenters**: Formatean las respuestas

### 5. **Frameworks and Drivers (Frameworks y Controladores)**
- **Ubicación**: `TestMillion.Repository`, `TestMillion.DataContexts`, `testMillion` (API)
- **Responsabilidad**: Implementa la infraestructura y frameworks externos
- **Componentes**:
  - **Repository**: Implementación de acceso a datos
  - **DataContexts**: Contexto de Entity Framework
  - **API**: Configuración de ASP.NET Core

## Patrones de Diseño Implementados

### 1. **Clean Architecture / Hexagonal Architecture**
- Separación clara de responsabilidades
- Dependencias apuntando hacia adentro
- Independencia de frameworks externos

### 2. **Dependency Injection (Inyección de Dependencias)**
- **Ubicación**: `TestMillion.IoC`
- **Implementación**: Microsoft.Extensions.DependencyInjection
- **Configuración**: Contenedores de dependencias por capa

### 3. **Repository Pattern**
- **Ubicación**: `TestMillion.Repository/Repositories/`
- **Propósito**: Abstraer el acceso a datos
- **Implementación**: 
  - `PropertyRepository`
  - `OwnerRepository`
  - `PropertyImageRepository`
  - `UnitOfWork`

### 4. **Unit of Work Pattern**
- **Ubicación**: `TestMillion.Repository/Repositories/UnitOfWork.cs`
- **Propósito**: Manejar transacciones y consistencia de datos

### 5. **Presenter Pattern**
- **Ubicación**: `TestMillion.Presenters`
- **Propósito**: Formatear respuestas para diferentes interfaces
- **Implementación**: Presenters específicos por entidad

### 6. **Ports and Adapters Pattern**
- **Puertos**: Interfaces definidas en UseCasesPort
- **Adaptadores**: Implementaciones en Controllers y Presenters

### 7. **DTO Pattern (Data Transfer Objects)**
- **Ubicación**: `TestMillion.DTOs`
- **Propósito**: Transferir datos entre capas sin exponer entidades internas
- **Tipos**:
  - `CreatePropertyDTO`
  - `PropertyDTO`
  - `OwnerDTO`
  - `UpdatePropertyDTO`

### 8. **AutoMapper Pattern**
- **Ubicación**: `TestMillion.UseCase/Mappings/`
- **Propósito**: Mapeo automático entre DTOs y entidades

### 9. **Exception Handling Pattern**
- **Ubicación**: `TestMillion.WebExceptions`
- **Implementación**: Filtros de excepción personalizados
- **Componentes**:
  - `ApiExceptionFilterAttribute`
  - `GeneralExceptionHandler`
  - `ValidationExceptionHandler`

### 10. **Validator Pattern**
- **Ubicación**: `TestMillion.UseCase/[UseCase]/[UseCase]Validator.cs`
- **Framework**: FluentValidation
- **Propósito**: Validación de datos de entrada

## Estructura de Proyectos

```
TestMillion/
├── testMillion/                    # API Principal (Frameworks and Drivers)
├── TestMillion.Entities/           # Entidades de Dominio
├── TestMillion.UseCase/           # Casos de Uso
├── TestMillion.UseCasesPort/      # Puertos de Casos de Uso
├── TestMillion.Controllers/       # Controladores HTTP
├── TestMillion.Presenters/        # Presentadores
├── TestMillion.Repository/        # Repositorios
├── TestMillion.DataContexts/      # Contexto de Base de Datos
├── TestMillion.DTOs/              # Objetos de Transferencia de Datos
├── TestMillion.IoC/               # Inyección de Dependencias
└── TestMillion.WebExceptions/     # Manejo de Excepciones
```

## Flujo de Datos

1. **Request HTTP** → `Controller`
2. **Controller** → `InputPort` (Use Case)
3. **Use Case** → `Repository` (a través de interfaces)
4. **Repository** → `DataContext` (Entity Framework)
5. **Response** → `OutputPort` → `Presenter` → `Controller`

## Tecnologías Utilizadas

- **Framework**: ASP.NET Core 6+
- **ORM**: Entity Framework Core
- **Validación**: FluentValidation
- **Mapeo**: AutoMapper
- **Autenticación**: JWT Bearer
- **Documentación**: Swagger/OpenAPI
- **Inyección de Dependencias**: Microsoft.Extensions.DependencyInjection

## Ventajas de la Arquitectura

1. **Testabilidad**: Fácil creación de tests unitarios
2. **Mantenibilidad**: Código organizado y fácil de mantener
3. **Escalabilidad**: Fácil agregar nuevas funcionalidades
4. **Independencia**: Cambios en una capa no afectan otras
5. **Flexibilidad**: Fácil cambiar frameworks externos

## Configuración y Ejecución

1. Configurar la cadena de conexión en `appsettings.json`
2. Ejecutar las migraciones de Entity Framework
3. Configurar las dependencias en `DependencyContainer`
4. Ejecutar la aplicación

## Endpoints Principales

- `POST /api/CreateProperty` - Crear propiedad
- `GET /api/GetProperties` - Obtener propiedades
- `PUT /api/UpdateProperty` - Actualizar propiedad
- `POST /api/CreateOwner` - Crear propietario
- `GET /api/GetOwners` - Obtener propietarios
- `POST /api/Authentication` - Autenticación

Esta arquitectura garantiza un código limpio, mantenible y escalable siguiendo las mejores prácticas de desarrollo de software.


## Tecnologías

ASP.NET Core, Entity Framework Core, FluentValidation, AutoMapper, JWT Bearer, Swagger/OpenAPI.
El proyecto está muy bien estructurado siguiendo las mejores prácticas de Clean Architecture, con una clara separación de responsabilidades y patrones de diseño que facilitan la mantenibilidad, testabilidad y escalabilidad del código.


##  Base de Datos TestMillionDB

- La base de datos esta en una carpeta **/BaseDatosScript**,  dentro esta  el script SQL.  

## ConnectionStrings 

- En el archivo  **appsettings.json**  en la vale **ConnectionStrings/TMConnection** 
  Data Source=*;Initial Catalog=TestMillionDB;User=*;password=*;Connection Timeout=200; pooling=true;MultipleActiveResultSets=True;TrustServerCertificate=True
  - Data Source=*
  - User=* 
  - password=* 


## El servicio esta  deployado en la siguiente  url  para  su prueba

https://testmillionapi-gje7dnbqfwdcdtga.canadacentral-01.azurewebsites.net/swagger/index.html


- `/api/Authentication` : Esta el metodo de autencicacion  que genera el token JWT , que permite la ejecucion de los  demas Endpoint
