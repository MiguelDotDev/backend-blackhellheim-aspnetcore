# HU-BH-018: Preparar despliegue y configuración segura

## Metadatos

- **ID:** HU-BH-018
- **Épica:** E07 — Calidad y publicación
- **Prioridad:** P0 antes de publicar
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como responsable técnico,
quiero desplegar frontend y backend con configuración separada por entorno,
para publicar el MVP sin exponer secretos ni depender de pasos manuales no documentados.

## Objetivo

Preparar despliegue reproducible y seguro con secretos gestionados fuera del repositorio, configuración por entorno, health checks, logging seguro, migraciones documentadas y CI/CD cuando aplique.

## Contexto y reglas de negocio

Credenciales/claves como secretos de entorno, no en repo. Documentar variables requeridas, migraciones, procedimiento de despliegue y reversión. API con health check y logs útiles sin exponer datos sensibles. Validar conectividad con SQL Server y servicios externos. Build/pruebas reproducibles vía CI, despliegue automático opcional según aprobación.

## Alcance

### Incluye

- Configuración por entorno (dev/staging/prod)
- Gestión segura de secretos
- Documentación de variables, migraciones, despliegue, reversión
- Health checks
- Logging seguro sin datos sensibles
- Validación de conectividad
- CI para build/pruebas
- Procedimiento reproducible

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Las credenciales y claves se gestionan como secretos del entorno, no dentro del repositorio.
- **CA-02:** Se documentan variables requeridas, migraciones y procedimiento de despliegue y reversión.
- **CA-03:** La API tiene un mecanismo de salud y registra errores útiles sin exponer contraseñas, tokens o datos sensibles.
- **CA-04:** Se valida conectividad con SQL Server y servicios externos desde el entorno desplegado.
- **CA-05:** Existe un flujo reproducible de build y pruebas mediante CI; el despliegue automático se habilita cuando el equipo lo apruebe.

## Dependencias

- HU-BH-002 (Preparar backend, persistencia y configuración por entorno)
- Funciones que se desplieguen

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir plataforma de despliegue
- Configurar secretos manager
- Configurar CI/CD

## Definición de terminado (DoD)

- Configuración segura por entorno
- Documentación completa de despliegue/reversión
- Health checks funcionando
- Logs seguros
- CI configurado
- Validación en entorno desplegado

## Notas y cuestiones pendientes

- Definir variables de entorno para todas las integraciones (DB, Identity, pasarela, proveedor, almacenamiento imágenes)
- Documentar procedimiento de rollback
- Configurar monitoreo/observabilidad básica
- Asegurar que migraciones se ejecutan de forma controlada en despliegue
- Revisar configuración de CORS/seguridad
- No commitear appsettings con secretos
