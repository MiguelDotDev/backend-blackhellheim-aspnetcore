# HU-BH-016: Registrar envío y eventos de seguimiento

## Metadatos

- **ID:** HU-BH-016
- **Épica:** E06 — Dropshipping y envíos
- **Prioridad:** P1
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente,
quiero consultar el seguimiento de mi compra cuando esté disponible,
para conocer su estado de entrega.

## Objetivo

Registrar envíos y eventos de seguimiento desde el proveedor, distinguir datos crudos vs normalizados, permitir múltiples envíos si aplica, evitar duplicados y mostrar información válida aunque no haya código de seguimiento aún.

## Contexto y reglas de negocio

Puede haber uno o varios envíos. Cada envío registra paquetería, código seguimiento, estado, fechas. Eventos con fecha/estado/descripción/ubicación si proveedor los provee. Distinguir datos recibidos del proveedor vs estados normalizados de tienda. Si no hay código de seguimiento, mostrar situación válida sin fallar. Evitar eventos duplicados.

## Alcance

### Incluye

- Modelo de envíos y eventos
- Asociación a compra/pedido proveedor
- Registro de paquetería/código/fechas/estado
- Normalización de estados
- Detección/prevención de duplicados
- Exposición al cliente

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Un pedido puede asociarse a uno o varios envíos si el negocio lo permite.
- **CA-02:** Cada envío registra paquetería, código de seguimiento cuando exista, estado y fechas relevantes.
- **CA-03:** Los eventos conservan fecha, estado, descripción y ubicación si el proveedor proporciona esos datos.
- **CA-04:** Se distinguen los datos recibidos del proveedor de los estados normalizados que presenta la tienda.
- **CA-05:** Si aún no existe código de seguimiento, la interfaz muestra una situación válida en lugar de fallar.
- **CA-06:** Las actualizaciones repetidas no generan eventos duplicados cuando pueden identificarse como el mismo evento.

## Dependencias

- HU-BH-015 (Remitir al proveedor una compra pagada)
- Disponibilidad de datos de paquetería/proveedor

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Revisar qué datos de seguimiento provee el proveedor
- Definir cómo identificar eventos duplicados (clave única)

## Definición de terminado (DoD)

- Modelo de envíos/eventos implementado
- Integración con actualizaciones del proveedor
- Normalización de estados
- Prevención de duplicados
- UI/API muestra seguimiento correctamente incluso sin código
- Pruebas básicas

## Notas y cuestiones pendientes

- Confirmar si MVP permite múltiples envíos por pedido
- Definir mapeo de estados proveedor -> estados normalizados tienda
- Definir estrategia para detectar duplicados de eventos
- Integrar con historial de estados de compra (HU-BH-013)
- Considerar que algunos pedidos pueden no tener seguimiento inmediatamente
