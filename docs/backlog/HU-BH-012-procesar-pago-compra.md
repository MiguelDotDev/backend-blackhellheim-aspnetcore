# HU-BH-012: Procesar el pago de una compra

## Metadatos

- **ID:** HU-BH-012
- **Épica:** E05 — Pagos y estados de compra
- **Prioridad:** P0 para cobrar en el MVP
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente,
quiero pagar una compra mediante la pasarela seleccionada y recibir un resultado fiable,
para completar el pedido de forma segura.

## Objetivo

Integrar pasarela de pago seleccionada de forma segura (sin almacenar datos sensibles de tarjetas), con registro de intentos, confirmación confiable para marcar compra como pagada, webhooks idempotentes, y sin enviar pedidos al proveedor por pagos fallidos/rechazados.

## Contexto y reglas de negocio

Usar flujo recomendado por pasarela. No almacenar datos sensibles de tarjetas. Registrar intentos con importe/moneda/estado/referencia externa. Compra solo se marca pagada tras confirmación fiable (backend o webhook verificado). Webhooks/callbacks validados e idempotentes. Intentos rechazados/cancelados registrados, no generan pedido al proveedor. Manejar fallos temporales, permitir consultar resultado sin duplicar cobros. Ambiente de pruebas disponible.

## Alcance

### Incluye

- Integración con pasarela seleccionada
- Registro de intentos de pago
- Confirmación fiable para marcar pagada
- Validación e idempotencia de webhooks
- Manejo de estados rechazado/cancelado/fallo temporal
- Prevención de doble cobro
- Pruebas con entorno de pruebas

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** La integración usa el flujo recomendado por la pasarela y no almacena datos sensibles de tarjetas en BlackHellHeim.
- **CA-02:** Cada intento de pago se registra con importe, moneda, estado y referencia externa cuando exista.
- **CA-03:** La compra solo se marca pagada después de una confirmación fiable del backend o de una notificación verificada de la pasarela.
- **CA-04:** Los webhooks o callbacks se validan y procesan de forma idempotente.
- **CA-05:** Los intentos rechazados o cancelados quedan registrados y no provocan por sí solos un pedido al proveedor.
- **CA-06:** El sistema contempla fallos temporales y permite consultar el resultado del intento sin duplicar cobros.
- **CA-07:** El entorno de pruebas de la pasarela permite validar pagos exitosos y fallidos.

## Dependencias

- HU-BH-010 (Crear una compra y conservar sus snapshots)
- Decisión de pasarela resuelta en HU-BH-001

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Solo enviar al proveedor cuando pago confirmado (regla general)
- Idempotencia requerida para webhooks

**Recomendaciones pendientes de validar:**
- Seleccionar pasarela compatible y revisar flujos/webhooks/reembolsos/pruebas
- Definir mecanismo de idempotencia
- Definir cómo se consulta resultado del intento

## Definición de terminado (DoD)

- Integración con pasarela funcional en pruebas
- Sin almacenamiento de datos sensibles de tarjetas
- Intentos registrados correctamente
- Confirmación fiable implementada
- Webhooks validados e idempotentes
- Prevención de doble cobro
- Pruebas de pagos exitosos/fallidos

## Notas y cuestiones pendientes

- Resolver selección de pasarela en HU-BH-001 con documentación/requisitos técnicos
- Confirmar flujo (redirect, hosted fields, etc.) recomendado por pasarela
- Definir estrategia de idempotencia para webhooks/callbacks
- Asegurar que solo compras con pago confirmado pueden ir a proveedor
- Documentar manejo de reembolsos si aplica (mencionado en decisiones)
