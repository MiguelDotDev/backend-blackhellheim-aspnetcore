# HU-BH-008: Gestionar direcciones de entrega

## Metadatos

- **ID:** HU-BH-008
- **Épica:** E03 — Cuenta y direcciones
- **Prioridad:** P0
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente autenticado,
quiero registrar, consultar, editar y eliminar mis direcciones guardadas,
para seleccionar una dirección al comprar.

## Objetivo

Permitir a clientes autenticados gestionar sus direcciones con control de propiedad, validación adecuada, y garantizar que cambios en direcciones guardadas no afecten compras históricas.

## Contexto y reglas de negocio

Cada dirección pertenece al usuario autenticado. Un usuario no puede acceder a direcciones ajenas. Validar datos obligatorios. Código postal como texto, teléfonos como texto. Borrado/cambio no debe modificar direcciones ya copiadas a compras anteriores.

## Alcance

### Incluye

- CRUD de direcciones por usuario autenticado
- Validación de campos obligatorios
- Control de propiedad (solo propias)
- Almacenamiento correcto de CP/teléfonos como texto
- Preservación de snapshots en compras

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** Cada dirección pertenece al usuario autenticado.
- **CA-02:** Un usuario no puede consultar ni modificar direcciones de otro usuario.
- **CA-03:** Los datos obligatorios de destinatario, teléfono y dirección se validan.
- **CA-04:** El código postal se almacena como texto y los teléfonos como texto.
- **CA-05:** El borrado o cambio de una dirección guardada no modifica direcciones ya copiadas a compras anteriores.

## Dependencias

- HU-BH-007 (Registrar e iniciar sesión)

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir campos obligatorios exactos
- Asegurar copia a `direcciones_compra` en checkout (se verá en HU-BH-010)

## Definición de terminado (DoD)

- CRUD funcional con autorización por propietario
- Validaciones implementadas
- Formato correcto de CP/teléfono
- Garantía de no afectar snapshots históricos
- Pruebas de seguridad (acceso ajeno)

## Notas y cuestiones pendientes

Si no hay cuestiones pendientes identificadas, indícalo.
No se identificaron cuestiones pendientes en el documento original.
