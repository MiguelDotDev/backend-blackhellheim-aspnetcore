# HU-BH-002: Preparar backend, persistencia y configuración por entorno

## Metadatos

- **ID:** HU-BH-002
- **Épica:** E00 — Descubrimiento y reglas
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como desarrollador,
quiero ejecutar el backend localmente con SQL Server y EF Core,
para desarrollar funcionalidades sobre una persistencia reproducible.

## Objetivo

Tener el backend desplegable localmente con persistencia versionada, configuración segura por entorno, documentación de API y pruebas básicas para poder desarrollar sobre una base técnica sólida.

## Contexto y reglas de negocio

Base técnica habilitadora para el resto del backlog. Debe seguir buenas prácticas de seguridad (sin secretos en repositorio), permitir migraciones reproducibles, y contar con manejo de errores, validación y pruebas mínimas.

## Alcance

### Incluye

- Solución compilable y arrancable con instrucciones documentadas
- Conexión a SQL Server mediante variables de entorno o configuración local no versionada
- Migraciones para crear y actualizar esquema
- Estrategia para datos de referencia de desarrollo
- API con documentación OpenAPI en entorno de desarrollo
- Manejo consistente de errores y validación de entrada
- Pruebas automatizadas básicas en build o CI

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** La solución compila y arranca con instrucciones documentadas.
- **CA-02:** La conexión a SQL Server se configura mediante variables de entorno o configuración local no versionada; no se suben secretos al repositorio.
- **CA-03:** Las migraciones permiten crear y actualizar el esquema de la base de datos.
- **CA-04:** Existe una estrategia para datos de referencia de desarrollo, sin insertar datos de prueba en producción por accidente.
- **CA-05:** La API expone documentación OpenAPI en el entorno de desarrollo.
- **CA-06:** Existe manejo consistente de errores y validación de entrada.
- **CA-07:** Se ejecutan pruebas automatizadas básicas en el proceso de build o CI.

## Dependencias

- HU-BH-001 (Definir reglas de negocio del MVP)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Stack de referencia: backend ASP.NET Core, SQL Server y EF Core
- Evaluar ASP.NET Core Identity para autenticación (según HU-BH-001)

**Recomendaciones pendientes de validar:**
- Definir estrategia concreta para datos de referencia de desarrollo (seed controlado)
- Definir enfoque de manejo de errores y validación consistente

## Definición de terminado (DoD)

- Backend ejecutándose localmente con SQL Server
- Migraciones funcionales
- Configuración por entorno sin secretos versionados
- OpenAPI disponible en desarrollo
- Manejo de errores y validación implementados
- Pruebas básicas integradas en build/CI
- Documentación de ejecución local actualizada

## Notas y cuestiones pendientes

Si no hay cuestiones pendientes identificadas, indícalo.
No se identificaron cuestiones pendientes en el documento original.
