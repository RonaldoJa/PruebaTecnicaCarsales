# Prueba Técnica Carsales - Rick and Morty

Aplicación full-stack que consume la API de Rick and Morty, compuesta por:
- **Backend**: API REST en .NET 8
- **Frontend**: Aplicación web en Angular 19

## 📋 Tabla de Contenidos

- [Ejecución con Docker (Recomendado)](#-ejecución-con-docker-recomendado)
- [Ejecución Manual](#-ejecución-manual)

## 🐳 Ejecución con Docker (Recomendado)

### Requisitos

- Docker: https://docs.docker.com/get-docker/
- Docker Compose: https://docs.docker.com/compose/install/

### Inicio Rápido

1. **Clonar el repositorio** (si aún no lo has hecho)
   ```bash
   git clone <repository-url>
   cd PruebaTecnicaCarsales
   ```

2. **Levantar los servicios**
   ```bash
   docker-compose up --build
   ```

   Este comando:
   - Construye las imágenes Docker para backend y frontend
   - Levanta ambos servicios
   - Configura la red para que se comuniquen entre sí

   **Nota**: La primera vez puede tomar 3-5 minutos descargando dependencias.

3. **Acceder a la aplicación**
   - Frontend: http://localhost:4200
   - Backend API: http://localhost:5001
   - Swagger (Documentación API): http://localhost:5001/swagger

### Comandos Útiles de Docker

```bash
# Levantar servicios en segundo plano
docker-compose up -d

# Ver logs en tiempo real
docker-compose logs -f

# Ver logs solo del backend
docker-compose logs -f backend

# Ver logs solo del frontend
docker-compose logs -f frontend

# Detener los servicios
docker-compose down

# Detener y eliminar volúmenes
docker-compose down -v

# Reconstruir las imágenes
docker-compose build --no-cache

# Ver estado de los contenedores
docker-compose ps
```

### Solución de Problemas Docker

#### Error: Puerto en uso
Si los puertos 4200 o 5001 están en uso, puedes cambiarlos en `docker-compose.yml`:
```yaml
ports:
  - "4201:80"  # Cambiar 4200 por 4201 para frontend
  - "5002:5001"  # Cambiar 5001 por 5002 para backend
```
#### Error: No se puede conectar al backend
1. Verificar que ambos contenedores estén corriendo:
   ```bash
   docker-compose ps
   ```
2. Ver logs del backend:
   ```bash
   docker-compose logs backend
   ```

#### Reconstruir desde cero
Si tienes problemas, intenta reconstruir todo:
```bash
docker-compose down -v
docker-compose build --no-cache
docker-compose up
```

## 🔧 Ejecución Manual

Si prefieres ejecutar los servicios sin Docker, consulta las instrucciones específicas:

- [Backend Manual Setup](./PruebaTecnicaCarsalesBackEnd/PruebaTecnicaCarsalesBackEnd/READMED.md)
- [Frontend Manual Setup](./PruebaTecnicaCarsalesFrontEnd/README.md)

### Resumen Rápido (Ejecución Manual)

**Backend (.NET 8)**
```bash
cd PruebaTecnicaCarsalesBackEnd/PruebaTecnicaCarsalesBackEnd
dotnet restore
dotnet run
```

**Frontend (Angular 19)**
```bash
cd PruebaTecnicaCarsalesFrontEnd
npm install
npm start


## 🏗️ Arquitectura

### Backend (.NET 8)
- **Framework**: ASP.NET Core 8.0
- **Patrón**: API REST
- **Documentación**: Swagger/OpenAPI
- **Puerto**: 5001
- **Características**:
  - Consumo de API externa (Rick and Morty API)
  - Manejo de errores centralizado
  - CORS configurado
  - Logging estructurado

### Frontend (Angular 19)
- **Framework**: Angular 19
- **Puerto**: 4200
- **Características**:
  - Componentes modulares
  - Servicios HTTP
  - Manejo de estado reactivo con RxJS
  - Routing configurado
  - Diseño responsive


## 📝 Notas Técnicas

### Docker
- Las imágenes utilizan Alpine Linux para ser ligeras
- Multi-stage builds para optimizar tamaño
- Network bridge para comunicación entre servicios
- Health checks configurados para el backend
- El frontend usa Nginx para servir archivos estáticos en producción

### Seguridad
- CORS configurado en el backend
- Variables de entorno para configuración
- Sin credenciales hardcodeadas
- Imágenes base oficiales de Microsoft y Node.js
