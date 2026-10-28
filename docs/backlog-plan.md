# BlackHellHeim — Plan de implementación y backlog inicial de HU

> **Objetivo:** convertir el modelo ER propuesto en un plan de trabajo incremental para el MVP de BlackHellHeim, ecommerce de ropa con variantes de productos, carrito, checkout, pagos y dropshipping.
>
> **Stack de referencia:** frontend Vue + Vite, backend ASP.NET Core, SQL Server y EF Core. La integración con el proveedor de dropshipping y la pasarela de pagos queda sujeta a confirmar sus APIs y condiciones reales.
>
> **Importante:** este backlog es una propuesta inicial para refinar con el equipo. Las HU no equivalen a tablas; cada una entrega un comportamiento observable y comprobable. Las decisiones que todavía no están definidas se registran como trabajo de descubrimiento, no como supuestos ocultos.

---

## 1. Estrategia recomendada

Construir el producto mediante **incrementos verticales**. Cada incremento debe atravesar las capas necesarias —frontend, API, lógica de aplicación y persistencia— y dejar una funcionalidad comprobable. No conviene crear primero todas las tablas, después todos los controladores y al final conectar el frontend.

### Orden general

1. **Cerrar reglas de negocio y riesgos externos.** Definir qué se venderá, cómo se identifican las variantes, quién controla los precios, cuándo se crea una compra, cómo se confirma un pago y cómo se envía al proveedor.
2. **Preparar la base técnica.** Configuración local, SQL Server, EF Core, migraciones, documentación de API, manejo de errores y pruebas automatizadas mínimas.
3. **Entregar el catálogo.** Categorías, productos, fotos y variantes vendibles; el usuario puede explorar el catálogo real desde el frontend.
4. **Entregar la identidad y el carrito.** Registro/inicio de sesión, direcciones y carrito de variantes.
5. **Cerrar checkout sin cobrar todavía.** Validar precio y disponibilidad desde el servidor y crear una compra con líneas y dirección histórica.
6. **Integrar cobro.** Procesar pagos y confirmaciones de forma segura e idempotente.
7. **Completar dropshipping y envío.** Remitir al proveedor pedidos pagados, guardar resultados y exponer el seguimiento disponible.
8. **Endurecer y publicar.** Pruebas del flujo de extremo a extremo, seguridad, configuración de despliegue y observabilidad básica.
9. **Añadir funciones secundarias.** Favoritos, reseñas, fotografías de reseñas y promociones cuando el recorrido de compra esté estable.

## 2. Decisiones que hay que cerrar antes de comprometer el diseño

Crear una tarea de descubrimiento corta para documentar estas decisiones. No es necesario resolver todo el futuro del negocio, pero sí lo que condiciona el MVP.

| Decisión | Propuesta inicial para el MVP | Por qué importa |
|---|---|---|
| Fuente del catálogo | Mantener un catálogo propio y mapear las variantes a los identificadores del proveedor. Confirmarlo revisando la API real. | Evita que el frontend y el checkout dependan directamente del formato externo. |
| Variantes vendibles | Una variante es una combinación concreta de producto, color y talla con SKU interno, precio y estado. | Carrito y compra deben apuntar a una variante real, no a una selección del usuario. |
| Precios y disponibilidad | El backend es la autoridad para el precio final; comprobar disponibilidad en checkout y, cuando sea viable, antes de enviar la orden al proveedor. | Evita confiar en importes enviados por el navegador y vender una variante no disponible. |
| Carrito | Para simplificar, exigir cuenta para guardar carrito y finalizar compra; navegación del catálogo pública. | Un carrito de invitado y su posterior fusión agregan complejidad. Si se requieren, deben planearse explícitamente. |
| Autenticación | Evaluar ASP.NET Core Identity antes de diseñar tablas de credenciales propias. | Reduce riesgos de seguridad y evita duplicar mecanismos de autenticación. |
| Pago | Seleccionar una pasarela compatible con las necesidades del negocio y confirmar sus flujos de webhook, reembolso y pruebas. | La integración depende del proveedor, sus estados y sus reglas de idempotencia. |
| Dropshipping | Enviar la orden al proveedor solo cuando el pago esté confirmado, salvo que la API y las reglas de negocio indiquen otra secuencia. | Evita generar pedidos externos por pagos fallidos. |
| Impuestos, envío y cancelaciones | Documentar cómo se calculan IVA, envío, descuentos, devoluciones y cancelaciones. No codificar cifras o reglas sin validarlas. | Los importes de cabecera y líneas deben ser coherentes. |
| Administración del catálogo | Definir si se tendrá un panel administrativo en el MVP o si los productos se cargarán inicialmente por seed/importación controlada. | Hace posible mantener el catálogo sin editar la base manualmente en producción. |

**Entregable de esta etapa:** decisiones registradas, modelo ER revisado, límites del MVP y criterios de aceptación aprobados. Las decisiones sobre APIs externas requieren una prueba técnica o documentación verificable del proveedor; no hay que asumir que una integración es posible solo porque se desea.

---

## 3. Épicas

| Épica | Resultado |
|---|---|
| E00 — Descubrimiento y reglas | Requerimientos, estados y contratos externos definidos. |
| E01 — Base técnica | Backend desplegable, persistencia versionada y pruebas básicas. |
| E02 — Catálogo y variantes | El visitante puede explorar productos y variantes reales. |
| E03 — Cuenta y direcciones | Los clientes se autentican y mantienen sus direcciones. |
| E04 — Carrito y checkout | Se puede preparar y registrar una compra coherente. |
| E05 — Pagos y pedidos | Se confirma el pago y se consulta la compra. |
| E06 — Dropshipping y envíos | Las compras pagadas se remiten al proveedor y se da seguimiento. |
| E07 — Calidad y publicación | El recorrido completo se valida y se prepara el despliegue. |
| E08 — Complementos | Favoritos, reseñas y mejoras no esenciales. |

---

## 4. Backlog inicial de historias de usuario

Las prioridades son relativas: **P0** bloquea el flujo principal; **P1** completa el MVP operativo; **P2** es posterior. Las dependencias son sugeridas y pueden ajustarse después del refinamiento. Las historias se deben dividir de nuevo si no caben razonablemente dentro de un sprint.

### E00 — Descubrimiento y reglas

#### HU-BH-001 — Definir reglas de negocio del MVP
**Prioridad:** P0 · **Tipo:** descubrimiento / habilitadora

**Como** equipo de desarrollo, **quiero** documentar las reglas principales de catálogo, variantes, autenticación, checkout, pagos, impuestos y dropshipping, **para** implementar un flujo consistente y evitar rehacer el modelo de datos.

**Criterios de aceptación**
- [ ] Existe un documento aprobado con el alcance incluido y excluido del MVP.
- [ ] Se define si el catálogo se administra internamente, se importa o se sincroniza con el proveedor.
- [ ] Se documentan las reglas de precio, disponibilidad, cantidad, IVA, costo de envío y total de compra.
- [ ] Se define el ciclo de estados de compra, pago y envío por separado.
- [ ] Se selecciona o identifica como pendiente la pasarela de pago, con sus requisitos técnicos.
- [ ] Se comprueba la documentación o se realiza una prueba técnica del proveedor de dropshipping para identificar operaciones disponibles y limitaciones.
- [ ] El ER se actualiza para reflejar las decisiones, sin mantener dos fuentes distintas para las mismas variantes vendibles.

#### HU-BH-002 — Preparar backend, persistencia y configuración por entorno
**Prioridad:** P0 · **Dependencias:** HU-BH-001

**Como** desarrollador, **quiero** ejecutar el backend localmente con SQL Server y EF Core, **para** desarrollar funcionalidades sobre una persistencia reproducible.

**Criterios de aceptación**
- [ ] La solución compila y arranca con instrucciones documentadas.
- [ ] La conexión a SQL Server se configura mediante variables de entorno o configuración local no versionada; no se suben secretos al repositorio.
- [ ] Las migraciones permiten crear y actualizar el esquema de la base de datos.
- [ ] Existe una estrategia para datos de referencia de desarrollo, sin insertar datos de prueba en producción por accidente.
- [ ] La API expone documentación OpenAPI en el entorno de desarrollo.
- [ ] Existe manejo consistente de errores y validación de entrada.
- [ ] Se ejecutan pruebas automatizadas básicas en el proceso de build o CI.

### E02 — Catálogo y variantes

#### HU-BH-003 — Administrar categorías y productos
**Prioridad:** P0 · **Dependencias:** HU-BH-002

**Como** administrador, **quiero** crear, consultar, actualizar y desactivar categorías y productos, **para** mantener el catálogo que ve el cliente.

**Criterios de aceptación**
- [ ] Se puede crear y consultar una categoría con nombre y slug único.
- [ ] Se puede crear un producto con título, descripción, categoría, público objetivo y estado de publicación.
- [ ] Se pueden editar los datos de un producto sin cambiar el identificador interno.
- [ ] Un producto desactivado deja de ofrecerse en el catálogo público, pero se conserva si tiene compras históricas.
- [ ] Las operaciones administrativas requieren autorización.
- [ ] Si no se construye un panel administrativo para el MVP, se documenta la alternativa temporal de carga controlada y no se editan datos productivos directamente como procedimiento normal.

#### HU-BH-004 — Definir variantes vendibles de un producto
**Prioridad:** P0 · **Dependencias:** HU-BH-003

**Como** administrador, **quiero** asociar colores y tallas a un producto mediante variantes con SKU y precio, **para** ofrecer únicamente combinaciones realmente comprables.

**Criterios de aceptación**
- [ ] Cada variante pertenece a un producto y define talla, color, SKU, precio, moneda y estado.
- [ ] No se puede repetir el SKU interno.
- [ ] No se puede crear la misma combinación producto-color-talla dos veces cuando esa combinación deba ser única.
- [ ] El precio no puede ser negativo y la cantidad solicitada en el flujo comercial debe ser mayor que cero.
- [ ] Se pueden desactivar variantes sin eliminar referencias históricas de compras.
- [ ] El modelo permite guardar identificadores externos del proveedor sin usarlos como claves primarias internas.

#### HU-BH-005 — Asociar fotografías al catálogo
**Prioridad:** P0 · **Dependencias:** HU-BH-003; HU-BH-004 si las imágenes dependen de variantes

**Como** administrador, **quiero** asociar y ordenar fotografías de productos y, cuando corresponda, de variantes, **para** mostrar el artículo con claridad antes de la compra.

**Criterios de aceptación**
- [ ] Una foto puede asociarse a un producto y opcionalmente a una variante concreta.
- [ ] Se guarda una URL o referencia al almacenamiento, texto alternativo y orden de presentación.
- [ ] El sistema valida los campos requeridos y no permite relaciones a productos inexistentes.
- [ ] Se define dónde se alojan las imágenes; no se guardan archivos arbitrarios dentro de la base de datos sin una decisión explícita.

#### HU-BH-006 — Consultar catálogo y detalle de producto
**Prioridad:** P0 · **Dependencias:** HU-BH-003, HU-BH-004, HU-BH-005

**Como** visitante, **quiero** explorar el catálogo y consultar el detalle de un producto con sus fotografías, colores, tallas y precios, **para** elegir qué comprar.

**Criterios de aceptación**
- [ ] El frontend consume los endpoints reales de la API, no datos hardcodeados como fuente final.
- [ ] El catálogo solo muestra productos y variantes publicadas y comprables.
- [ ] El detalle muestra las variantes disponibles, el precio vigente y las imágenes en un orden definido.
- [ ] Se contemplan estados de carga, error, catálogo vacío y producto no encontrado.
- [ ] La API soporta paginación; filtros y búsqueda se incluyen si están dentro del alcance acordado.

### E03 — Cuenta y direcciones

#### HU-BH-007 — Registrar e iniciar sesión
**Prioridad:** P0 · **Dependencias:** HU-BH-002

**Como** cliente, **quiero** registrarme e iniciar sesión de forma segura, **para** mantener mi carrito, direcciones y compras asociados a mi cuenta.

**Criterios de aceptación**
- [ ] Un correo normalizado no puede registrarse dos veces.
- [ ] Las contraseñas no se guardan en texto plano; se utiliza una solución segura, preferentemente ASP.NET Core Identity si encaja con la arquitectura.
- [ ] Las rutas protegidas rechazan solicitudes no autenticadas o sin el rol necesario.
- [ ] Se implementan respuestas adecuadas para credenciales incorrectas y datos inválidos sin filtrar información sensible.
- [ ] Se documentan los flujos de sesión, expiración y cierre de sesión.

#### HU-BH-008 — Gestionar direcciones de entrega
**Prioridad:** P0 · **Dependencias:** HU-BH-007

**Como** cliente autenticado, **quiero** registrar, consultar, editar y eliminar mis direcciones guardadas, **para** seleccionar una dirección al comprar.

**Criterios de aceptación**
- [ ] Cada dirección pertenece al usuario autenticado.
- [ ] Un usuario no puede consultar ni modificar direcciones de otro usuario.
- [ ] Los datos obligatorios de destinatario, teléfono y dirección se validan.
- [ ] El código postal se almacena como texto y los teléfonos como texto.
- [ ] El borrado o cambio de una dirección guardada no modifica direcciones ya copiadas a compras anteriores.

### E04 — Carrito y checkout

#### HU-BH-009 — Gestionar el carrito
**Prioridad:** P0 · **Dependencias:** HU-BH-004, HU-BH-007

**Como** cliente autenticado, **quiero** añadir variantes al carrito, cambiar cantidades y quitar artículos, **para** preparar mi compra.

**Criterios de aceptación**
- [ ] El cliente solo puede manipular su propio carrito.
- [ ] Solo se agregan variantes activas y comprables.
- [ ] La cantidad debe ser un entero positivo y se aplican límites razonables definidos por negocio.
- [ ] Una misma variante no genera líneas duplicadas dentro del mismo carrito si la política es consolidarlas.
- [ ] La API devuelve cantidades, productos, variantes y precios informativos actuales.
- [ ] El servidor no considera que el precio mostrado en el carrito sea un precio final garantizado.

#### HU-BH-010 — Crear una compra y conservar sus snapshots
**Prioridad:** P0 · **Dependencias:** HU-BH-008, HU-BH-009

**Como** cliente, **quiero** confirmar carrito y dirección, **para** crear una compra con totales y datos históricos consistentes.

**Criterios de aceptación**
- [ ] El servidor vuelve a consultar el precio y la disponibilidad; no acepta los totales enviados por el frontend como autoridad.
- [ ] Se calcula subtotal, descuentos si aplican, impuestos, envío y total usando las reglas aprobadas.
- [ ] Se crea una compra con número de pedido único, líneas de compra y snapshot de producto, SKU, talla, color, cantidad y precio unitario.
- [ ] Se copia la dirección confirmada a `direcciones_compra`.
- [ ] La compra inicia en un estado explícito, como `PENDIENTE_PAGO`, y todavía no se considera pagada.
- [ ] La operación es transaccional: no se crea una cabecera sin sus líneas ni una compra parcial si falla la persistencia.
- [ ] Una compra anterior se puede consultar correctamente aunque después cambien el producto, precio o dirección de la cuenta.
- [ ] Se define qué pasa con el carrito tras la creación de la compra y se evita crear pedidos duplicados ante reintentos de la solicitud.

#### HU-BH-011 — Consultar historial y detalle de compras
**Prioridad:** P1 · **Dependencias:** HU-BH-010

**Como** cliente autenticado, **quiero** consultar mis compras y sus detalles, **para** conocer qué pedí y en qué estado se encuentra.

**Criterios de aceptación**
- [ ] El cliente puede consultar únicamente sus compras, excepto los roles administrativos autorizados.
- [ ] El detalle utiliza los snapshots guardados en la compra.
- [ ] Se muestran número de pedido, fecha, artículos, dirección registrada, totales y estado de compra.
- [ ] Se distingue estado de compra de estado de pago y de estado de envío.

### E05 — Pagos y estados de compra

#### HU-BH-012 — Procesar el pago de una compra
**Prioridad:** P0 para cobrar en el MVP · **Dependencias:** HU-BH-010 y decisión de pasarela resuelta en HU-BH-001

**Como** cliente, **quiero** pagar una compra mediante la pasarela seleccionada y recibir un resultado fiable, **para** completar el pedido de forma segura.

**Criterios de aceptación**
- [ ] La integración usa el flujo recomendado por la pasarela y no almacena datos sensibles de tarjetas en BlackHellHeim.
- [ ] Cada intento de pago se registra con importe, moneda, estado y referencia externa cuando exista.
- [ ] La compra solo se marca pagada después de una confirmación fiable del backend o de una notificación verificada de la pasarela.
- [ ] Los webhooks o callbacks se validan y procesan de forma idempotente.
- [ ] Los intentos rechazados o cancelados quedan registrados y no provocan por sí solos un pedido al proveedor.
- [ ] El sistema contempla fallos temporales y permite consultar el resultado del intento sin duplicar cobros.
- [ ] El entorno de pruebas de la pasarela permite validar pagos exitosos y fallidos.

#### HU-BH-013 — Mantener un historial de estados de compra
**Prioridad:** P1 · **Dependencias:** HU-BH-010; se integra con HU-BH-012

**Como** equipo de operación, **quiero** conservar los cambios de estado de una compra, **para** auditar el ciclo de vida del pedido y explicar su situación.

**Criterios de aceptación**
- [ ] Cada cambio registra compra, estado, fecha y actor o proceso que lo provocó.
- [ ] Solo se permiten transiciones válidas según las reglas documentadas.
- [ ] Los cambios de pago y envío no se confunden con el estado de compra.
- [ ] La historia de estados no se reescribe al cambiar el estado actual.

### E06 — Dropshipping y envíos

#### HU-BH-014 — Mapear variantes internas a variantes del proveedor
**Prioridad:** P0 si la operación depende del proveedor · **Dependencias:** HU-BH-001, HU-BH-004

**Como** administrador o proceso de integración, **quiero** vincular cada variante de BlackHellHeim con los identificadores correspondientes del proveedor, **para** poder consultar disponibilidad y remitir pedidos correctamente.

**Criterios de aceptación**
- [ ] La relación identifica proveedor, producto externo, variante externa y SKU externo cuando existan.
- [ ] La misma variante externa no se mapea accidentalmente varias veces dentro del mismo proveedor.
- [ ] Se registran fecha y resultado de la última sincronización cuando se consulte disponibilidad o costo.
- [ ] Los fallos de sincronización quedan visibles para su diagnóstico.
- [ ] La tienda conserva identificadores internos estables aunque el proveedor cambie los suyos.

#### HU-BH-015 — Remitir al proveedor una compra pagada
**Prioridad:** P0 para operación de dropshipping · **Dependencias:** HU-BH-012, HU-BH-014

**Como** operador de la tienda, **quiero** enviar al proveedor las líneas de una compra cuyo pago está confirmado, **para** iniciar su preparación o producción.

**Criterios de aceptación**
- [ ] Solo las compras elegibles según las reglas pueden enviarse al proveedor.
- [ ] Se conserva la referencia externa, fecha, respuesta y estado del pedido del proveedor.
- [ ] Un timeout o reintento no crea órdenes duplicadas; se usa idempotencia cuando la API lo soporte y se define recuperación cuando no lo soporte.
- [ ] Los rechazos del proveedor generan un estado visible y un procedimiento operativo definido; no se ocultan ni se marcan como completados.
- [ ] La integración tiene pruebas con respuestas exitosas, errores de validación, errores temporales y resultado desconocido.

#### HU-BH-016 — Registrar envío y eventos de seguimiento
**Prioridad:** P1 · **Dependencias:** HU-BH-015 y disponibilidad de datos de paquetería/proveedor

**Como** cliente, **quiero** consultar el seguimiento de mi compra cuando esté disponible, **para** conocer su estado de entrega.

**Criterios de aceptación**
- [ ] Un pedido puede asociarse a uno o varios envíos si el negocio lo permite.
- [ ] Cada envío registra paquetería, código de seguimiento cuando exista, estado y fechas relevantes.
- [ ] Los eventos conservan fecha, estado, descripción y ubicación si el proveedor proporciona esos datos.
- [ ] Se distinguen los datos recibidos del proveedor de los estados normalizados que presenta la tienda.
- [ ] Si aún no existe código de seguimiento, la interfaz muestra una situación válida en lugar de fallar.
- [ ] Las actualizaciones repetidas no generan eventos duplicados cuando pueden identificarse como el mismo evento.

### E07 — Calidad y publicación

#### HU-BH-017 — Validar el flujo de compra de extremo a extremo
**Prioridad:** P0 antes de publicar · **Dependencias:** HU-BH-006, HU-BH-007, HU-BH-009, HU-BH-010, HU-BH-012 y, para dropshipping real, HU-BH-015

**Como** responsable del producto, **quiero** verificar el recorrido de compra y sus fallos comunes, **para** publicar sin perder pedidos ni crear cobros u órdenes duplicadas.

**Criterios de aceptación**
- [ ] Hay pruebas automatizadas para variantes inválidas, cantidades inválidas, permisos, precios actualizados y disponibilidad insuficiente.
- [ ] Se prueba un pago exitoso, un pago rechazado y un reintento o notificación duplicada.
- [ ] Se verifica que una compra conserva sus datos históricos tras modificar producto, precio o dirección.
- [ ] Se prueba un rechazo o fallo temporal al enviar el pedido al proveedor.
- [ ] Se comprueba que un usuario no puede leer o modificar compras ajenas.
- [ ] Las pruebas y su resultado están documentados y se corrigen defectos bloqueantes antes de liberar.

#### HU-BH-018 — Preparar despliegue y configuración segura
**Prioridad:** P0 antes de publicar · **Dependencias:** HU-BH-002 y las funciones que se desplieguen

**Como** responsable técnico, **quiero** desplegar frontend y backend con configuración separada por entorno, **para** publicar el MVP sin exponer secretos ni depender de pasos manuales no documentados.

**Criterios de aceptación**
- [ ] Las credenciales y claves se gestionan como secretos del entorno, no dentro del repositorio.
- [ ] Se documentan variables requeridas, migraciones y procedimiento de despliegue y reversión.
- [ ] La API tiene un mecanismo de salud y registra errores útiles sin exponer contraseñas, tokens o datos sensibles.
- [ ] Se valida conectividad con SQL Server y servicios externos desde el entorno desplegado.
- [ ] Existe un flujo reproducible de build y pruebas mediante CI; el despliegue automático se habilita cuando el equipo lo apruebe.

### E08 — Complementos posteriores al MVP

#### HU-BH-019 — Guardar y quitar productos favoritos
**Prioridad:** P2 · **Dependencias:** HU-BH-006, HU-BH-007

**Como** cliente autenticado, **quiero** guardar productos favoritos y consultarlos posteriormente, **para** encontrarlos fácilmente.

**Criterios de aceptación**
- [ ] Se puede añadir o quitar un producto del listado.
- [ ] Un producto no aparece duplicado en los favoritos de un usuario.
- [ ] El usuario solo puede gestionar sus favoritos.
- [ ] Los productos desactivados se presentan según una regla definida.

#### HU-BH-020 — Publicar reseñas de productos
**Prioridad:** P2 · **Dependencias:** HU-BH-006, HU-BH-007, HU-BH-011

**Como** cliente, **quiero** calificar y comentar un producto, **para** compartir mi experiencia con otros compradores.

**Criterios de aceptación**
- [ ] La calificación cumple el rango definido, por ejemplo de 1 a 5.
- [ ] Se aplica la política acordada sobre reseñas verificadas y cantidad de reseñas por compra/usuario.
- [ ] El comentario tiene límites de longitud y se valida la entrada.
- [ ] Si se adjuntan fotografías, se valida su tipo y tamaño y se utiliza un almacenamiento apropiado.
- [ ] Se define si la reseña se publica directamente o requiere moderación.

---

## 5. Cómo ordenar los primeros incrementos

No asigno semanas ni puntos sin conocer la capacidad del equipo. El orden siguiente representa dependencias funcionales, no una promesa de duración.

| Incremento | Historias propuestas | Resultado demostrable |
|---|---|---|
| I0 — Decisiones y cimientos | HU-BH-001, HU-BH-002 | Modelo acordado y backend reproducible conectado a SQL Server. |
| I1 — Catálogo real | HU-BH-003, HU-BH-004, HU-BH-005, HU-BH-006 | Un visitante consulta productos reales y sus variantes en el frontend. |
| I2 — Cuenta y selección | HU-BH-007, HU-BH-008, HU-BH-009 | Un usuario inicia sesión, guarda dirección y gestiona un carrito de variantes. |
| I3 — Pedido consistente | HU-BH-010, HU-BH-011, HU-BH-013 | Se crea una compra con líneas, dirección y precios históricos y se consulta su estado. |
| I4 — Pago real en entorno de prueba | HU-BH-012 | La compra puede pagarse y el resultado de pago queda registrado sin duplicados. |
| I5 — Dropshipping y seguimiento | HU-BH-014, HU-BH-015, HU-BH-016 | Una compra pagada se remite al proveedor y el seguimiento se refleja cuando existe. |
| I6 — Preparación de publicación | HU-BH-017, HU-BH-018 | El recorrido principal está probado y el despliegue está documentado. |
| Posterior | HU-BH-019, HU-BH-020 | Favoritos y reseñas. |

**Nota:** las historias se pueden desarrollar en paralelo cuando no compartan dependencias, pero la integración con pago y proveedor debe probarse con el flujo de compra completo.

---

## 6. Qué no implementaría todavía

Para limitar el alcance, dejaría fuera de la primera versión salvo que exista un requerimiento explícito:

- Panel de analítica avanzado, cupones y programa de fidelidad.
- Inventario de almacén propio si el negocio opera exclusivamente con dropshipping.
- Reseñas con fotos y moderación compleja.
- Carrito de invitado y sincronización del carrito entre dispositivos.
- Múltiples proveedores por artículo si el MVP trabaja con uno solo.
- Facturación electrónica, devoluciones físicas complejas o cancelaciones automatizadas, hasta tener reglas de negocio confirmadas.

No significa que nunca deban implementarse; significa que no deben bloquear la primera compra funcional sin una necesidad explícita.

---

## 7. Definition of Ready (DoR)

Una HU se puede llevar a sprint cuando:

- [ ] Tiene un actor, una necesidad y un resultado claro.
- [ ] Sus criterios de aceptación son verificables.
- [ ] Se conocen sus dependencias y no hay decisiones externas críticas ocultas.
- [ ] El alcance es suficientemente pequeño y el equipo entiende los casos normales y los errores esperados.
- [ ] Diseño, API, datos y seguridad están contemplados en el nivel que requiere la historia.

## 8. Definition of Done (DoD)

Una HU se considera terminada cuando:

- [ ] Cumple todos sus criterios de aceptación.
- [ ] Código revisado y convenciones de la solución respetadas.
- [ ] Validaciones y manejo de errores implementados.
- [ ] Pruebas relevantes pasan; se añaden pruebas automatizadas donde corresponda.
- [ ] Migraciones, contratos de API y documentación se actualizan cuando aplica.
- [ ] No hay secretos en el repositorio y los permisos se verifican.
- [ ] El cambio está integrado en la rama acordada y puede demostrarse en un entorno reproducible.

## 9. Recomendación para la siguiente sesión de refinamiento

Empezar por **HU-BH-001** y resolver solo las decisiones que afectan al primer recorrido: catálogo propio frente a sincronizado, variante vendible, autenticación, dirección de envío, cálculo del total y pasarela de pago. Después, revisar el ER y convertir **HU-BH-002 a HU-BH-006** en tareas concretas para entregar el catálogo de extremo a extremo.

No crear una HU independiente por cada tabla. Las tablas son parte de la implementación; las HU deben describir comportamientos de valor que puedan demostrarse y validarse.
