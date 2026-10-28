# HU-BH-006: Consultar catálogo y detalle de producto

## Metadatos

- **ID:** HU-BH-006
- **Épica:** E02 — Catálogo y variantes
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como visitante,
quiero explorar el catálogo y consultar el detalle de un producto con sus fotografías, colores, tallas y precios,
para elegir qué comprar.

## Objetivo

Exponer el catálogo público real desde la API para que el frontend lo consume (sin datos hardcodeados), mostrando solo productos/variantes publicadas y comprables con toda la información necesaria.

## Contexto y reglas de negocio

Solo deben mostrarse productos y variantes publicadas y comprables. El detalle debe mostrar variantes disponibles, precio vigente e imágenes en orden definido. Debe contemplarse paginación, filtros/búsqueda si aplica, y estados de carga/error/catálogo vacío/producto no encontrado.

## Alcance

### Incluye

- Listado de catálogo público
- Detalle de producto con variantes, fotos, precios
- Filtrado por disponibilidad/publicación
- Paginación
- Estados de UI/API para errores/vacío/no encontrado

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** El frontend consume los endpoints reales de la API, no datos hardcodeados como fuente final.
- **CA-02:** El catálogo solo muestra productos y variantes publicadas y comprables.
- **CA-03:** El detalle muestra las variantes disponibles, el precio vigente y las imágenes en un orden definido.
- **CA-04:** Se contemplan estados de carga, error, catálogo vacío y producto no encontrado.
- **CA-05:** La API soporta paginación; filtros y búsqueda se incluyen si están dentro del alcance acordado.

## Dependencias

- HU-BH-003 (Administrar categorías y productos)
- HU-BH-004 (Definir variantes vendibles de un producto)
- HU-BH-005 (Asociar fotografías al catálogo)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- El backend es autoridad para precio

**Recomendaciones pendientes de validar:**
- Definir parámetros de paginación (page/size)
- Definir si filtros/búsqueda se incluyen en MVP

## Definición de terminado (DoD)

- Endpoints públicos de catálogo y detalle funcionales
- Solo se muestran productos/variantes publicadas/comprables
- Paginación implementada
- Manejo de errores/estados
- Integración con frontend usando datos reales
- Validaciones y rendimiento razonables

## Notas y cuestiones pendientes

- Confirmar alcance de filtros y búsqueda para MVP.
- Asegurar que solo variantes activas/comprables se muestran.
- Definir precio vigente a mostrar (precio actual de variante).
