# PruebaTecnicaCarsalesFrontEnd

## Requisitos

- Node.js 18 o superior: https://nodejs.org/

## Instalación y Ejecución

### 1. Verificar Node.js

```bash
node --version
```

Debe mostrar `v18.x.x` o superior

### 2. Instalar dependencias

```bash
cd PruebaTecnicaCarsalesFrontEnd
npm install
```

Esto puede tomar 2-3 minutos la primera vez.

### 3. Ejecutar

```bash
npm start
```

La aplicación estará disponible en: **http://localhost:4200**

## IMPORTANTE

El backend DEBE estar ejecutándose en `http://localhost:5001` antes de iniciar el frontend.

## Funcionalidades

- Ver lista de episodios
- Buscar por nombre
- Buscar por código de episodio (S01E01)
- Paginación

## Solución de Problemas

### Error: comando 'ng' no encontrado
```bash
npm install -g @angular/cli@19
```

### Error: Cannot connect
- Verificar que el backend esté ejecutándose en http://localhost:5001
- Abrir http://localhost:5001/api/episodes en el navegador para verificar

### Cambiar URL del backend
Si el backend está en otro puerto, edita `src/environments/environment.ts`:
```typescript
export const environment = {
  apiUrl: 'http://localhost:5002/api/episodes'
};
```

### Error: Puerto 4200 en uso
```bash
# Usar otro puerto
ng serve --port 4201
```

### Reinstalar dependencias
```bash
rm -rf node_modules package-lock.json
npm install
```
