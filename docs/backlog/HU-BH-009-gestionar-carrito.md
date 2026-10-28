# HU-BH-009: Gestionar el carrito

## Metadatos

- **ID:** HU-BH-009
- **Épica:** E04 — Carrito y checkout
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente autenticado,
quiero añadir variantes al carrito, cambiar cantidades y quitar artículos,
para preparar mi compra.

## Objetivo

Permitir a clientes autenticados gestionar su carrito de variantes comprables, con validaciones y dejando claro que los precios mostrados son informativos (el servidor es autoridad).

## Contexto y reglas de negocio

Para MVP se exige cuenta para guardar carrito y finalizar compra (navegación pública del catálogo). Solo variantes activas y comprables. Cantidad entera positiva con límites razonables. Consolidar líneas si aplica. Precios informativos, no garantizados. Solo manipular propio carrito.

## Alcance

### Incluye

- Añadir/actualizar/quitar items del carrito
- Validar variante activa/comprable
- Validar cantidad positiva con límites
- Consolidación de líneas (si política lo define)
- Mostrar precios/cantidades/variantes informativos
- Control de propiedad

### No incluye

- Carrito de invitado (explícitamente fuera para MVP según sección 2)

## Criterios de aceptación

- **CA-01:** El cliente solo puede manipular su propio carrito.
- **CA-02:** Solo se agregan variantes activas y comprables.
- **CA-03:** La cantidad debe ser un entero positivo y se aplican límites razonables definidos por negocio.
- **CA-04:** Una misma variante no genera líneas duplicadas dentro del mismo carrito si la política es consolidarlas.
- **CA-05:** La API devuelve cantidades, productos, variantes y precios informativos actuales.
- **CA-06:** El servidor no considera que el precio mostrado en el carrito sea un precio final garantizado.

## Dependencias

- HU-BH-004 (Definir variantes vendibles de un producto)
- HU-BH-007 (Registrar e iniciar sesión)

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Exigir cuenta para carrito/compra en MVP

**Recomendaciones pendientes de validar:**
- Definir límite de cantidad por línea/carrito
- Definir política de consolidación de líneas
- Definir si carrito persiste entre sesiones

## Definición de terminado (DoD)

- Gestión de carrito funcional con autorización
- Validaciones de variante/cantidad aplicadas
- Precios informativos claramente identificados como no finales
- Consolidación según política
- Pruebas básicas

## Notas y cuestiones pendientes

- Confirmar límite de cantidad razonable.
- Definir política explícita de consolidación de líneas duplicadas.
- Aclarar comportamiento al quedar variante desactivada/no disponible.
