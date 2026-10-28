# HU-BH-015: Remitir al proveedor una compra pagada

## Metadatos

- **ID:** HU-BH-015
- **Épica:** E06 — Dropshipping y envíos
- **Prioridad:** P0 para operación de dropshipping
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como operador de la tienda,
quiero enviar al proveedor las líneas de una compra cuyo pago está confirmado,
para iniciar su preparación o producción.

## Objetivo

Remitir solo compras con pago confirmado al proveedor, guardar referencia externa/fecha/respuesta/estado, usar idempotencia ante reintentos/timeouts, manejar rechazos con visibilidad y procedimiento operativo.

## Contexto y reglas de negocio

Solo compras elegibles según reglas pueden enviarse. Conservar referencia externa, fecha, respuesta, estado del pedido del proveedor. Timeout/reintento no deben crear órdenes duplicadas - usar idempotencia si API lo soporta, definir recuperación si no. Rechazos generan estado visible y procedimiento operativo definido, no ocultarlos. Probar respuestas exitosas/errores/temporales/resultado desconocido.

## Alcance

### Incluye

- Envío solo de compras con pago confirmado
- Almacenamiento de respuesta/referencia externa
- Idempotencia ante reintentos/timeouts
- Manejo de rechazos con visibilidad
- Procedimiento operativo para errores
- Pruebas con distintos escenarios

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Solo las compras elegibles según las reglas pueden enviarse al proveedor.
- **CA-02:** Se conserva la referencia externa, fecha, respuesta y estado del pedido del proveedor.
- **CA-03:** Un timeout o reintento no crea órdenes duplicadas; se usa idempotencia cuando la API lo soporte y se define recuperación cuando no lo soporte.
- **CA-04:** Los rechazos del proveedor generan un estado visible y un procedimiento operativo definido; no se ocultan ni se marcan como completados.
- **CA-05:** La integración tiene pruebas con respuestas exitosas, errores de validación, errores temporales y resultado desconocido.

## Dependencias

- HU-BH-012 (Procesar el pago de una compra)
- HU-BH-014 (Mapear variantes internas a variantes del proveedor)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Enviar al proveedor solo cuando pago esté confirmado
- Usar mapeo interno-externo

**Recomendaciones pendientes de validar:**
- Revisar API del proveedor (idempotencia, reintentos, timeouts)
- Definir estados/resultados del proveedor
- Definir procedimiento operativo para rechazos

## Definición de terminado (DoD)

- Integración para envío a proveedor implementada
- Solo envía compras pagadas
- Respuestas guardadas correctamente
- Idempotencia implementada o recuperación definida
- Rechazos visibles con procedimiento
- Pruebas de escenarios cubiertas

## Notas y cuestiones pendientes

- Confirmar capacidades de API del proveedor (idempotency keys, timeouts, reintentos)
- Definir qué significa "compra elegible" explícitamente
- Crear procedimiento operativo para rechazos/fallos temporales
- Integrar con historial de estados (HU-BH-013)
- Considerar resultado desconocido ante timeout
