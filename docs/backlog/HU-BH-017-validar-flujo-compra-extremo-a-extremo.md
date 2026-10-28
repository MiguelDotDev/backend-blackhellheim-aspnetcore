# HU-BH-017: Validar el flujo de compra de extremo a extremo

## Metadatos

- **ID:** HU-BH-017
- **Épica:** E07 — Calidad y publicación
- **Prioridad:** P0 antes de publicar
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como responsable del producto,
quiero verificar el recorrido de compra y sus fallos comunes,
para publicar sin perder pedidos ni crear cobros u órdenes duplicadas.

## Objetivo

Validar el flujo completo de compra con pruebas automatizadas/manuales cubriendo casos válidos, inválidos, fallos de pago, errores con proveedor, y seguridad (acceso a compras ajenas), antes de publicar.

## Contexto y reglas de negocio

Debe probarse todo el recorrido: catálogo -> carrito -> checkout -> pago -> remisión a proveedor (si aplica). Cubrir casos de variantes inválidas, cantidades inválidas, permisos, precios actualizados, disponibilidad insuficiente, pago exitoso/rechazado/reintento/notificación duplicada, conservación de snapshots históricos, rechazo/fallo temporal con proveedor, y aislamiento de compras entre usuarios.

## Alcance

### Incluye

- Pruebas de extremo a extremo del flujo principal
- Pruebas de casos negativos y fallos
- Verificación de idempotencia/doble cobro/duplicados
- Verificación de snapshots históricos
- Verificación de seguridad (aislamiento)
- Documentación de pruebas y resultados

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Hay pruebas automatizadas para variantes inválidas, cantidades inválidas, permisos, precios actualizados y disponibilidad insuficiente.
- **CA-02:** Se prueba un pago exitoso, un pago rechazado y un reintento o notificación duplicada.
- **CA-03:** Se verifica que una compra conserva sus datos históricos tras modificar producto, precio o dirección.
- **CA-04:** Se prueba un rechazo o fallo temporal al enviar el pedido al proveedor.
- **CA-05:** Se comprueba que un usuario no puede leer o modificar compras ajenas.
- **CA-06:** Las pruebas y su resultado están documentados y se corrigen defectos bloqueantes antes de liberar.

## Dependencias

- HU-BH-006 (Consultar catálogo y detalle de producto)
- HU-BH-007 (Registrar e iniciar sesión)
- HU-BH-009 (Gestionar el carrito)
- HU-BH-010 (Crear una compra y conservar sus snapshots)
- HU-BH-012 (Procesar el pago de una compra)
- HU-BH-015 (Remitir al proveedor una compra pagada) - para dropshipping real

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir suite de pruebas (unitarias/integración/E2E)
- Preparar entorno de pruebas con pasarela y proveedor

## Definición de terminado (DoD)

- Suite de pruebas E2E ejecutada
- Todos los casos críticos cubiertos
- Defectos bloqueantes corregidos
- Pruebas documentadas con resultados
- Aprobación para publicación

## Notas y cuestiones pendientes

- Coordinar con equipos/proveedores para tener entornos de prueba disponibles
- Definir criterios de aceptación para "listo para publicar"
- Asegurar cobertura de idempotencia en todos los puntos críticos
- Verificar que webhooks duplicados no generan efectos colaterales
- Documentar plan de pruebas
