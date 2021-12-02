Bases and Bricks
  por José Luis Ávila

Para esta primera entrega la entrada y salida de datos se realiza a través de la terminal.

Requerimientos para ejecutar el software: Abrir la solución del proyecto con la extensión de visual studio de C#. Para revisar los datos **se debe hacer uso del depurador de visual studio**. 

  >  Funcionalidades
 - Disponer de un inventario personal para manejar tus piezas/sets de LEGO
 - Agregar/Eliminar piezas y sets de LEGO a tu inventario personal
 - Buscar piezas mediante filtros en tu inventario personal
 - Añadir sets que deseas construir a un apartado extra para ordenarlos por prioridad
>  ¿Cómo funciona?

Se leen datos en archivos .csv que se encuentran en el directorio `./Data`. En este directorio están las tablas de MySQL y los archivos .csv resultantes de operaciones con estas tablas. Estos datos se cargan a las estructuras de datos del proyecto. En el archivo `Queries.cs` se tienen las **operaciones CRUD** sobre estas estructuras de datos y en `Program.cs` se llaman estas operaciones.

>  ¿Qué estructuras de datos se implementaron?

 1. Lista simplemente encadenada con cola
 2. Arreglo dinámico
 3. Pila
 4. Cola

