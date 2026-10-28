# HU-BH-004: Definir variantes vendibles de un producto

## Metadatos

- **ID:** HU-BH-004
- **Épica:** E02 — Catálogo y variantes
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como administrador,
quiero asociar colores y tallas a un producto mediante variantes con SKU y precio,
para ofrecer únicamente combinaciones realmente comprables.

## Objetivo

Modelar las variantes vendibles como la unidad mínima comprable (combinación producto-color-talla) con SKU, precio, moneda y estado, garantizando unicidad y preservando referencias históricas.

## Contexto y reglas de negocio

Una variante es una combinación concreta de producto, color y talla con SKU interno, precio y estado. Carrito y compra deben apuntar a una variante real. El precio es autoridad del backend. Deben poder desactivarse variantes sin eliminar referencias históricas. Se deben poder guardar identificadores externos del proveedor sin usarlos como claves primarias.

## Alcance

### Incluye

- Crear variantes por producto con talla, color, SKU, precio, moneda, estado
- Garantizar unicidad de SKU interno
- Garantizar unicidad de combinación producto-color-talla cuando aplique
- Validación de precio (no negativo) y cantidad > 0 en flujo comercial
- Desactivación de variantes preservando historial
- Soporte para identificadores externos del proveedor (sin PK)

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Cada variante pertenece a un producto y define talla, color, SKU, precio, moneda y estado.
- **CA-02:** No se puede repetir el SKU interno.
- **CA-03:** No se puede crear la misma combinación producto-color-talla dos veces cuando esa combinación deba ser única.
- **CA-04:** El precio no puede ser negativo y la cantidad solicitada en el flujo comercial debe ser mayor que cero.
- **CA-05:** Se pueden desactivar variantes sin eliminar referencias históricas de compras.
- **CA-06:** El modelo permite guardar identificadores externos del proveedor sin usarlos como claves primarias internas.

## Dependencias

- HU-BH-003 (Administrar categorías y productos)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Una variante es la unidad comprable
- El backend es autoridad para precio final

**Recomendaciones pendientes de validar:**
- Definir reglas exactas de unicidad (combinación producto-color-talla)
- Definir moneda por defecto y validaciones

## Definición de terminado (DoD)

- Modelo de variantes implementado con validaciones
- Unicidad de SKU y combinación garantizada
- Validaciones de precio/cantidad aplicadas
- Desactivación sin pérdida de historial
- Campos para IDs externos del proveedor presentes
- Pruebas de validación básicas

## Notas y cuestiones pendientes

- Confirmar si hay excepciones a la unicidad de combinación producto-color-talla.
- Definir moneda soportada para MVP.
- Asegurar integridad referencial con líneas de compra históricas.
