# HU-BH-011: Consultar historial y detalle de compras

## Metadatos

- **ID:** HU-BH-011
- **Épica:** E04 — Carrito y checkout
- **Prioridad:** P1
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente autenticado,
quiero consultar mis compras y sus detalles,
para conocer qué pedí y en qué estado se encuentra.

## Objetivo

Permitir a clientes consultar su historial de compras y detalle usando los snapshots guardados, con control de acceso (solo propias, excepto roles administrativos autorizados) y distinción entre estados de compra/pago/envío.

## Contexto y reglas de negocio

Acceso restringido a compras propias salvo roles administrativos autorizados. Debe usar snapshots guardados. Mostrar número de pedido, fecha, artículos, dirección registrada, totales, estado. Distinguir estado de compra, estado de pago, estado de envío.

## Alcance

### Incluye

- Listado de compras del cliente
- Detalle de compra con snapshots
- Control de acceso por propietario/rol
- Mostrar estados separados
- Mostrar dirección registrada (snapshot)

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** El cliente puede consultar únicamente sus compras, excepto los roles administrativos autorizados.
- **CA-02:** El detalle utiliza los snapshots guardados en la compra.
- **CA-03:** Se muestran número de pedido, fecha, artículos, dirección registrada, totales y estado de compra.
- **CA-04:** Se distingue estado de compra de estado de pago y de estado de envío.

## Dependencias

- HU-BH-010 (Crear una compra y conservar sus snapshots)

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir roles administrativos autorizados
- Asegurar que se muestran estados correctamente separados

## Definición de terminado (DoD)

- Historial y detalle accesibles solo a propietario o roles autorizados
- Usa snapshots correctamente
- Muestra toda la información requerida
- Distingue estados correctamente
- Pruebas de autorización

## Notas y cuestiones pendientes

- Confirmar qué roles administrativos pueden consultar compras ajenas.
- Asegurar que dirección mostrada es la snapshot de `direcciones_compra`, no la actual de cuenta.
