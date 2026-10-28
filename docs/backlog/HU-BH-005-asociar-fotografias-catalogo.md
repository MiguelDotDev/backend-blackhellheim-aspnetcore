# HU-BH-005: Asociar fotografías al catálogo

## Metadatos

- **ID:** HU-BH-005
- **Épica:** E02 — Catálogo y variantes
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como administrador,
quiero asociar y ordenar fotografías de productos y, cuando corresponda, de variantes,
para mostrar el artículo con claridad antes de la compra.

## Objetivo

Permitir asociar imágenes a productos y opcionalmente a variantes, con orden y texto alternativo, definiendo dónde se almacenan sin guardar archivos arbitrarios en la base de datos.

## Contexto y reglas de negocio

Las fotos pueden asociarse a producto y opcionalmente a variante concreta. Debe validarse que las relaciones apuntan a entidades existentes. Se debe decidir el almacenamiento (no guardar binarios en BD sin decisión explícita).

## Alcance

### Incluye

- Asociación foto-producto y opcionalmente foto-variante
- URL/referencia, texto alternativo, orden de presentación
- Validación de campos y referencias existentes
- Definir ubicación de almacenamiento

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Una foto puede asociarse a un producto y opcionalmente a una variante concreta.
- **CA-02:** Se guarda una URL o referencia al almacenamiento, texto alternativo y orden de presentación.
- **CA-03:** El sistema valida los campos requeridos y no permite relaciones a productos inexistentes.
- **CA-04:** Se define dónde se alojan las imágenes; no se guardan archivos arbitrarios dentro de la base de datos sin una decisión explícita.

## Dependencias

- HU-BH-003 (Administrar categorías y productos)
- HU-BH-004 (Definir variantes vendibles de un producto) - si las imágenes dependen de variantes

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir proveedor/almacenamiento de imágenes (local, cloud, CDN)
- Validar tipos/tamaños si se permite subida
- Política de orden y fallback

## Definición de terminado (DoD)

- Modelo de fotos implementado con validaciones
- Asociación a producto/variante funcional
- Orden y texto alternativo gestionables
- Decisión de almacenamiento documentada
- Validaciones aplicadas

## Notas y cuestiones pendientes

- Decidir almacenamiento de imágenes (externo vs interno). No guardar archivos binarios en base de datos sin decisión explícita.
- Definir si se permite subir archivos o solo URLs/referencias.
- Definir comportamiento cuando hay imágenes a nivel variante vs producto.
