# HU-BH-014: Mapear variantes internas a variantes del proveedor

## Metadatos

- **ID:** HU-BH-014
- **Épica:** E06 — Dropshipping y envíos
- **Prioridad:** P0 si la operación depende del proveedor
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como administrador o proceso de integración,
quiero vincular cada variante de BlackHellHeim con los identificadores correspondientes del proveedor,
para poder consultar disponibilidad y remitir pedidos correctamente.

## Objetivo

Mapear variantes internas a externas del proveedor, manteniendo IDs internos estables, evitando mapeos duplicados, registrando sincronización/disponibilidad y haciendo visibles los fallos.

## Contexto y reglas de negocio

Relación debe identificar proveedor, producto externo, variante externa, SKU externo cuando existan. Misma variante externa no debe mapearse múltiples veces en mismo proveedor. Registrar fecha/resultado última sincronización. Fallos visibles. IDs internos estables aunque proveedor cambie los suyos.

## Alcance

### Incluye

- Tabla/mapeo proveedor-variante interna-externa
- Validación de unicidad
- Registro de sincronización/disponibilidad
- Visibilidad de fallos
- Preservación de IDs internos

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** La relación identifica proveedor, producto externo, variante externa y SKU externo cuando existan.
- **CA-02:** La misma variante externa no se mapea accidentalmente varias veces dentro del mismo proveedor.
- **CA-03:** Se registran fecha y resultado de la última sincronización cuando se consulte disponibilidad o costo.
- **CA-04:** Los fallos de sincronización quedan visibles para su diagnóstico.
- **CA-05:** La tienda conserva identificadores internos estables aunque el proveedor cambie los suyos.

## Dependencias

- HU-BH-001 (Definir reglas de negocio del MVP)
- HU-BH-004 (Definir variantes vendibles de un producto)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Mantener catálogo propio y mapear variantes a IDs del proveedor (sección 2)
- Usar IDs externos sin usarlos como claves primarias internas

**Recomendaciones pendientes de validar:**
- Revisar API del proveedor para operaciones disponibles (HU-BH-001)

## Definición de terminado (DoD)

- Mapeo variante interna-externa implementado
- Unicidad garantizada
- Registro de sincronización/fallos
- Integración con consulta de disponibilidad preparada
- Pruebas básicas

## Notas y cuestiones pendientes

- Confirmar si hay un solo proveedor o múltiples (sección 6 dice trabajar con uno solo en MVP salvo explícito)
- Validar operaciones disponibles en API del proveedor
- Definir formato de registro de sincronización/fallos
- Asegurar que carrito/checkout pueden usar este mapeo para validación
