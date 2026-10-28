# HU-BH-019: Guardar y quitar productos favoritos

## Metadatos

- **ID:** HU-BH-019
- **Épica:** E08 — Complementos posteriores al MVP
- **Prioridad:** P2
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente autenticado,
quiero guardar productos favoritos y consultarlos posteriormente,
para encontrarlos fácilmente.

## Objetivo

Añadir funcionalidad de favoritos para clientes autenticados, evitando duplicados, con control de propiedad, y definiendo comportamiento con productos desactivados.

## Contexto y reglas de negocio

Añadir/quitar productos. Sin duplicados. Solo gestionar sus propios favoritos. Definir presentación de productos desactivados en favoritos.

## Alcance

### Incluye

- Añadir/quitar favorito
- Listado de favoritos
- Sin duplicados
- Control por usuario
- Comportamiento con productos desactivados

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Se puede añadir o quitar un producto del listado.
- **CA-02:** Un producto no aparece duplicado en los favoritos de un usuario.
- **CA-03:** El usuario solo puede gestionar sus favoritos.
- **CA-04:** Los productos desactivados se presentan según una regla definida.

## Dependencias

- HU-BH-006 (Consultar catálogo y detalle de producto)
- HU-BH-007 (Registrar e iniciar sesión)

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir regla para productos desactivados en favoritos (ocultar, mostrar con aviso, etc.)

## Definición de terminado (DoD)

- Favoritos funcionales
- Sin duplicados
- Autorización correcta
- Regla para desactivados definida y aplicada
- Pruebas básicas

## Notas y cuestiones pendientes

- Decidir comportamiento con productos desactivados (recomendado: mostrar con indicador o filtrar)
- Considerar si favoritos afectan carrito/checkout
- Post-MVP según plan
