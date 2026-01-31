# Backend - Rick and Morty API

API simple en .NET 8 que consume la API pública de Rick and Morty.

## Requisitos

- .NET 8 SDK: https://dotnet.microsoft.com/download/dotnet/8.0

## Instalación y Ejecución

### 1. Verificar .NET 8

```bash
dotnet --version
```

Debe mostrar `8.0.x`

### 2. Restaurar dependencias

```bash
cd backend
dotnet restore
```

### 3. Ejecutar

```bash
dotnet run
```

La API estará disponible en: **http://localhost:5001**

### 4. Probar

Abre tu navegador en:
- Swagger: http://localhost:5001/swagger
- Episodios: http://localhost:5001/api/episodes

## Endpoints

### GET /api/episodes
Obtiene lista paginada de episodios

**Parámetros:**
- `page` (opcional): Número de página (default: 1)
- `name` (opcional): Filtrar por nombre
- `episode` (opcional): Filtrar por código (ej: S01E01)

**Ejemplo:**
```
GET http://localhost:5001/api/episodes?page=1
GET http://localhost:5001/api/episodes?name=Pilot
GET http://localhost:5001/api/episodes?episode=S01E01
```

### GET /api/episodes/{id}
Obtiene un episodio específico

**Ejemplo:**
```
GET http://localhost:5001/api/episodes/1
```

## Solución de Problemas

### Error: SDK no encontrado
- Instalar .NET 8 SDK desde: https://dotnet.microsoft.com/download/dotnet/8.0

### Error: Puerto en uso
- Cerrar otras aplicaciones en el puerto 5001
- O cambiar el puerto en `appsettings.json`:
  ```json
  {
    "Urls": "http://localhost:5002"
  }
  ```

### Cambiar URL de la API externa
Si necesitas usar otra URL de Rick and Morty API, edita `appsettings.json`:
```json
{
  "PruebaTecnicaCarsalesBackEnd": {
    "BaseUrl": "https://otra-url.com/api/episode"
  }
}
```

### Error de CORS
- Verificar que el frontend usa `http://localhost:4200`
- CORS ya está configurado en `Program.cs`
