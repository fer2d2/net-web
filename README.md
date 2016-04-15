# Práctica 2 - .NET

- Alumno: Fernando Moro Hernández
- Matrícula: BH0611

## Tareas realizadas

- Tienda web que incluye:
    - CRUD para gestionar productos.
    - Gestión de carrito (añadir, eliminar).
    - Control de stock:
        - Se actualiza el stock con cada pedido.
        - No procesa el carrito si se añaden más elementos de los permitidos (muestra mensaje de error).
        - No permite añadir elemento al carrito si no existe stock (se oculta el botón).
    - En vista de listado de productos, cuando no queda Stock se muestra un aviso con un literal textual, en lugar del número de elementos.
    - En vista de listado y detalle de productos, se muestra la imagen del producto en lugar de la URL.
    - En el carrito se muestra el precio total (sumatorio de precio de todos los productos). Dicho precio se actualiza al añadir o quitar productos.
    - En el carrito, si se compra varias veces el mismo elemento, se muestra una única vez junto con la cantidad, en lugar de aparecer repetido.
    - Se incluye botón para confirmar una compra del carrito. Si todo va bien, se muestra mensaje de éxito y se lleva al usuario al listado de productos, si no, se muestra error.
    - Se añade una tabla histórica que almacena pedidos, incluyendo la fecha y los artículos que se compraron.
    - Se añade vista para consultar los pedidos realizados.

