# HU-BH-001: Definir reglas de negocio del MVP

## Metadatos

- **ID:** HU-BH-001
- **Épica:** E00 — Descubrimiento y reglas
- **Prioridad:** P0
- **Tipo:** Descubrimiento / habilitadora
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como equipo de desarrollo,
quiero documentar las reglas principales de catálogo, variantes, autenticación, checkout, pagos, impuestos y dropshipping,
para implementar un flujo consistente y evitar rehacer el modelo de datos.

## Objetivo

Documentar y acordar todas las reglas de negocio clave del MVP para establecer un marco consistente de implementación. Esto evita rehacer el modelo de datos y asegura que las decisiones críticas se tomen antes de comprometer el diseño.

## Contexto y reglas de negocio

Esta es una historia habilitadora centrada en descubrimiento. Debe documentarse el alcance completo del MVP, definir los ciclos de estados, seleccionar o identificar la pasarela de pago, y validar las capacidades del proveedor de dropshipping. También debe actualizarse el modelo ER para reflejar las decisiones sin duplicar información sobre variantes vendibles.

## Alcance

### Incluye

- Definir alcance incluido y excluido del MVP
- Definir si el catálogo se administra internamente, se importa o se sincroniza con el proveedor
- Documentar reglas de precio, disponibilidad, cantidad, IVA, costo de envío y total de compra
- Definir ciclo de estados de compra, pago y envío por separado
- Seleccionar o identificar como pendiente la pasarela de pago con sus requisitos técnicos
- Comprobar documentación o realizar prueba técnica del proveedor de dropshipping
- Actualizar el modelo ER para reflejar las decisiones

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Existe un documento aprobado con el alcance incluido y excluido del MVP.
- **CA-02:** Se define si el catálogo se administra internamente, se importa o se sincroniza con el proveedor.
- **CA-03:** Se documentan las reglas de precio, disponibilidad, cantidad, IVA, costo de envío y total de compra.
- **CA-04:** Se define el ciclo de estados de compra, pago y envío por separado.
- **CA-05:** Se selecciona o identifica como pendiente la pasarela de pago, con sus requisitos técnicos.
- **CA-06:** Se comprueba la documentación o se realiza una prueba técnica del proveedor de dropshipping para identificar operaciones disponibles y limitaciones.
- **CA-07:** El ER se actualiza para reflejar las decisiones, sin mantener dos fuentes distintas para las mismas variantes vendibles.

## Dependencias

No se especificaron dependencias en el documento original.

## Consideraciones técnicas

**Decisiones técnicas ya establecidas:**
- Las decisiones sobre APIs externas requieren una prueba técnica o documentación verificable del proveedor; no hay que asumir que una integración es posible solo porque se desea.

**Recomendaciones pendientes de validar:**
- Revisar las decisiones listadas en la sección "Decisiones que hay que cerrar antes de comprometer el diseño" del plan (fuente del catálogo, variantes vendibles, precios/disponibilidad, carrito, autenticación, pago, dropshipping, impuestos/envío/cancelaciones, administración del catálogo).

## Definición de terminado (DoD)

- Implementación funcional acorde con los criterios de aceptación.
- Documento aprobado con todas las reglas de negocio definidas.
- Modelo ER actualizado coherentemente con las decisiones.
- Se ha validado la viabilidad de las integraciones externas (pasarela y proveedor dropshipping) o se ha documentado explícitamente su estado pendiente.
- Decisiones registradas y accesibles para el equipo.

## Notas y cuestiones pendientes

- Se requiere tomar decisiones sobre: catálogo propio vs sincronizado, autenticación (evaluar ASP.NET Core Identity), pasarela de pago compatible, secuencia dropshipping (enviar solo con pago confirmado), cálculo de impuestos/envío/descuentos, y si habrá panel administrativo o carga por seed/importación.
- Las integraciones con proveedor de dropshipping y pasarela de pago dependen de documentación verificable o prueba técnica - no asumir viabilidad sin confirmación.
- Se debe revisar el ER existente para evitar duplicidad de fuentes para variantes vendibles.
