# HU-BH-013: Mantener un historial de estados de compra

## Metadatos

- **ID:** HU-BH-013
- **Épica:** E05 — Pagos y estados de compra
- **Prioridad:** P1
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como equipo de operación,
quiero conservar los cambios de estado de una compra,
para auditar el ciclo de vida del pedido y explicar su situación.

## Objetivo

Auditar cambios de estado de compra/pago/envío con historial inmutable, transiciones válidas, y distinción clara entre los diferentes tipos de estado.

## Contexto y reglas de negocio

Cada cambio registra compra, estado, fecha, actor/proceso. Solo transiciones válidas según reglas documentadas. Cambios de pago/envío no se confunden con estado de compra. Historia no se reescribe al cambiar estado actual.

## Alcance

### Incluye

- Historial de cambios de estado
- Registro de actor/proceso
- Validación de transiciones
- Distinción entre estados de compra/pago/envío
- Inmutabilidad del historial

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Cada cambio registra compra, estado, fecha y actor o proceso que lo provocó.
- **CA-02:** Solo se permiten transiciones válidas según las reglas documentadas.
- **CA-03:** Los cambios de pago y envío no se confunden con el estado de compra.
- **CA-04:** La historia de estados no se reescribe al cambiar el estado actual.

## Dependencias

- HU-BH-010 (Crear una compra y conservar sus snapshots)
- Se integra con HU-BH-012 (Procesar el pago de una compra)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Estados de compra, pago y envío deben definirse por separado (HU-BH-001)

**Recomendaciones pendientes de validar:**
- Documentar máquina de estados y transiciones válidas

## Definición de terminado (DoD)

- Historial de estados implementado
- Transiciones validadas
- Distinción entre tipos de estado
- Historial inmutable
- Integración con cambios de estado existentes

## Notas y cuestiones pendientes

- Definir estados separados para compra/pago/envío en HU-BH-001
- Documentar transiciones válidas explícitamente
- Definir qué se considera "actor" (usuario, sistema, webhook)
- Integrar con flujo de pago (HU-BH-012)
