# HU-BH-007: Registrar e iniciar sesión

## Metadatos

- **ID:** HU-BH-007
- **Épica:** E03 — Cuenta y direcciones
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente,
quiero registrarme e iniciar sesión de forma segura,
para mantener mi carrito, direcciones y compras asociados a mi cuenta.

## Objetivo

Implementar autenticación segura para clientes, preferentemente con ASP.NET Core Identity, con manejo adecuado de errores y rutas protegidas.

## Contexto y reglas de negocio

Correo normalizado único. Contraseñas no en texto plano. Rutas protegidas requieren autenticación/autorización. Respuestas seguras sin filtrar información sensible. Documentar flujos de sesión, expiración y cierre de sesión.

## Alcance

### Incluye

- Registro de usuario
- Inicio/cierre de sesión
- Protección de rutas
- Normalización de correo
- Almacenamiento seguro de contraseñas
- Documentación de flujos de sesión

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Un correo normalizado no puede registrarse dos veces.
- **CA-02:** Las contraseñas no se guardan en texto plano; se utiliza una solución segura, preferentemente ASP.NET Core Identity si encaja con la arquitectura.
- **CA-03:** Las rutas protegidas rechazan solicitudes no autenticadas o sin el rol necesario.
- **CA-04:** Se implementan respuestas adecuadas para credenciales incorrectas y datos inválidos sin filtrar información sensible.
- **CA-05:** Se documentan los flujos de sesión, expiración y cierre de sesión.

## Dependencias

- HU-BH-002 (Preparar backend, persistencia y configuración por entorno)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Evaluar ASP.NET Core Identity antes de diseñar tablas de credenciales propias

**Recomendaciones pendientes de validar:**
- Decidir mecanismo de autenticación (cookies, JWT, etc.) según arquitectura
- Configurar roles si aplica

## Definición de terminado (DoD)

- Registro e inicio/cierre de sesión funcionales
- ASP.NET Core Identity integrado o alternativa segura justificada
- Rutas protegidas con autorización
- Validaciones y respuestas seguras
- Documentación de flujos
- Pruebas básicas de autenticación

## Notas y cuestiones pendientes

- Confirmar uso de ASP.NET Core Identity vs implementación propia.
- Definir estrategia de sesión (expiración, refresh si aplica).
- Definir roles necesarios para MVP.
