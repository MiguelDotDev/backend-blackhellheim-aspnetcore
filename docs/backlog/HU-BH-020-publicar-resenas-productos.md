# HU-BH-020: Publicar reseñas de productos

## Metadatos

- **ID:** HU-BH-020
- **Épica:** E08 — Complementos posteriores al MVP
- **Prioridad:** P2
- **Estado:** Pendiente
- **Fuente:** `docs/backlog-plan.md`

## Historia de usuario

Como cliente,
quiero calificar y comentar un producto,
para compartir mi experiencia con otros compradores.

## Objetivo

Permitir reseñas de productos con calificación, validaciones, política de reseñas verificadas, límites, posibilidad de fotos con validación/almacenamiento, y decisión sobre publicación directa o moderación.

## Contexto y reglas de negocio

Calificación 1-5. Aplicar política sobre reseñas verificadas y cantidad por compra/usuario. Comentario con límites de longitud y validación. Si hay fotos, validar tipo/tamaño y usar almacenamiento apropiado. Definir si publicación directa o requiere moderación.

## Alcance

### Incluye

- Calificación y comentario
- Validaciones (rango, longitud)
- Política de reseñas verificadas
- Límite por usuario/compra
- Soporte opcional para fotos con validación
- Moderación o publicación directa

### No incluye

- No se especificaron exclusiones explícitas en el documento original.

## Criterios de aceptación

- **CA-01:** La calificación cumple el rango definido, por ejemplo de 1 a 5.
- **CA-02:** Se aplica la política acordada sobre reseñas verificadas y cantidad de reseñas por compra/usuario.
- **CA-03:** El comentario tiene límites de longitud y se valida la entrada.
- **CA-04:** Si se adjuntan fotografías, se valida su tipo y tamaño y se utiliza un almacenamiento apropiado.
- **CA-05:** Se define si la reseña se publica directamente o requiere moderación.

## Dependencias

- HU-BH-006 (Consultar catálogo y detalle de producto)
- HU-BH-007 (Registrar e iniciar sesión)
- HU-BH-011 (Consultar historial y detalle de compras)

## Consideraciones técnicas

**Recomendaciones pendientes de validar:**
- Definir política exacta de reseñas verificadas (solo compradores)
- Definir límites de longitud/tipo/tamaño de fotos
- Decidir moderación vs publicación directa
- Considerar almacenamiento para fotos de reseñas

## Definición de terminado (DoD)

- Reseñas funcionales con validaciones
- Política de verificadas aplicada
- Límites aplicados
- Fotos validadas si se permiten
- Moderación/publicación definida e implementada
- Pruebas básicas

## Notas y cuestiones pendientes

- Definir si solo clientes con compra pueden reseñar (reseña verificada)
- Límite de reseñas por producto/usuario/compra
- Política de moderación
- Almacenamiento para fotos de reseñas (consistente con HU-BH-005)
- Post-MVP según plan
