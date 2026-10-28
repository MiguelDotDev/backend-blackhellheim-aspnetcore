# HU-BH-003: Administrar categorías y productos

## Metadatos

- **ID:** HU-BH-003
- **Épica:** E02 — Catálogo y variantes
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como administrador,
quiero crear, consultar, actualizar y desactivar categorías y productos,
para mantener el catálogo que ve el cliente.

## Objetivo

Habilitar la gestión del catálogo base (categorías y productos) para que el contenido que se muestra a los clientes esté bajo control administrativo, preservando productos con historial de compras al desactivarlos.

## Contexto y reglas de negocio

Parte del flujo de catálogo. Los productos desactivados no deben ofrecerse en el catálogo público pero deben conservarse si tienen compras históricas. Las operaciones administrativas requieren autorización. Si no hay panel administrativo en MVP, debe documentarse una alternativa temporal de carga controlada.

## Alcance

### Incluye

- Crear, consultar, actualizar categorías
- Crear, consultar, actualizar productos
- Desactivar categorías/productos
- Control de autorización para operaciones administrativas
- Preservar productos con compras históricas al desactivarlos

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Se puede crear y consultar una categoría con nombre y slug único.
- **CA-02:** Se puede crear un producto con título, descripción, categoría, público objetivo y estado de publicación.
- **CA-03:** Se pueden editar los datos de un producto sin cambiar el identificador interno.
- **CA-04:** Un producto desactivado deja de ofrecerse en el catálogo público, pero se conserva si tiene compras históricas.
- **CA-05:** Las operaciones administrativas requieren autorización.
- **CA-06:** Si no se construye un panel administrativo para el MVP, se documenta la alternativa temporal de carga controlada y no se editan datos productivos directamente como procedimiento normal.

## Dependencias

- HU-BH-002 (Preparar backend, persistencia y configuración por entorno)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Definir si habrá panel administrativo en MVP o carga por seed/importación controlada (sección 2 del plan)

**Recomendaciones pendientes de validar:**
- Implementar autorización/roles para operaciones administrativas
- Definir estrategia de carga controlada si no hay panel

## Definición de terminado (DoD)

- CRUD de categorías y productos implementado
- Autorización aplicada a operaciones administrativas
- Productos desactivados no aparecen en catálogo público
- Preservación de productos con compras históricas garantizada
- Documentación de alternativa temporal si aplica
- Validaciones y manejo de errores implementados

## Notas y cuestiones pendientes

- Decidir si se construye panel administrativo para MVP o se usa carga controlada por seed/importación.
- Asegurar que desactivación no elimina entidades con referencias históricas.
