# HU-BH-010: Crear una compra y conservar sus snapshots

## Metadatos

- **ID:** HU-BH-010
- **Épica:** E04 — Carrito y checkout
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente,
quiero confirmar carrito y dirección,
para crear una compra con totales y datos históricos consistentes.

## Objetivo

Crear una compra transaccional con líneas y snapshots históricos, recalculando totales/precios/disponibilidad en servidor, copiando dirección a `direcciones_compra`, iniciando en estado `PENDIENTE_PAGO`, y evitando duplicados ante reintentos.

## Contexto y reglas de negocio

El servidor es autoridad: vuelve a consultar precio y disponibilidad, no acepta totales del frontend. Calcular subtotal, descuentos, impuestos, envío, total según reglas aprobadas. Crear compra con número único, líneas con snapshot (producto, SKU, talla, color, cantidad, precio unitario). Copiar dirección a `direcciones_compra`. Estado inicial `PENDIENTE_PAGO`. Operación transaccional. Debe poder consultarse correctamente aunque cambien producto/precio/dirección después. Definir qué pasa con carrito tras creación y evitar duplicados.

## Alcance

### Incluye

- Checkout con validación servidor-side de precio/disponibilidad
- Cálculo de totales según reglas
- Creación transaccional de compra + líneas
- Snapshots históricos en líneas
- Copia de dirección a `direcciones_compra`
- Estado inicial explícito
- Gestión post-creación de carrito
- Protección contra duplicados (idempotencia)

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** El servidor vuelve a consultar el precio y la disponibilidad; no acepta los totales enviados por el frontend como autoridad.
- **CA-02:** Se calcula subtotal, descuentos si aplican, impuestos, envío y total usando las reglas aprobadas.
- **CA-03:** Se crea una compra con número de pedido único, líneas de compra y snapshot de producto, SKU, talla, color, cantidad y precio unitario.
- **CA-04:** Se copia la dirección confirmada a `direcciones_compra`.
- **CA-05:** La compra inicia en un estado explícito, como `PENDIENTE_PAGO`, y todavía no se considera pagada.
- **CA-06:** La operación es transaccional: no se crea una cabecera sin sus líneas ni una compra parcial si falla la persistencia.
- **CA-07:** Una compra anterior se puede consultar correctamente aunque después cambien el producto, precio o dirección de la cuenta.
- **CA-08:** Se define qué pasa con el carrito tras la creación de la compra y se evita crear pedidos duplicados ante reintentos de la solicitud.

## Dependencias

- HU-BH-008 (Gestionar direcciones de entrega)
- HU-BH-009 (Gestionar el carrito)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Precios y disponibilidad validados en checkout
- Direcciones copiadas (snapshot)
- Estados separados para compra/pago/envío

**Recomendaciones pendientes de validar:**
- Reglas exactas de cálculo (IVA, envío, descuentos)
- Estrategia de idempotencia para prevenir duplicados
- Comportamiento del carrito tras creación (vaciarlo)

## Definición de terminado (DoD)

- Checkout transaccional implementado
- Validación servidor-side de precio/disponibilidad
- Snapshots completos en líneas
- Dirección copiada correctamente
- Estado inicial correcto
- Idempotencia para reintentos
- Pruebas de transaccionalidad e histórico

## Notas y cuestiones pendientes

- Confirmar reglas de cálculo de totales (impuestos, envío, descuentos) desde HU-BH-001
- Definir mecanismo de idempotencia (clave/idempotency key)
- Definir qué ocurre con el carrito tras crear compra
- Garantizar unicidad de número de pedido
- Documentar estados de compra/pago/envío por separado
