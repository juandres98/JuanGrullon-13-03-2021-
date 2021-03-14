# JuanGrullon-13-03-2021-

El presente proyecto fue realizado utilizando Xamarin Forms en su versión 5.0.0.2012 para el sistema operativo Android en la Plataforma de Destino Android 11.0 (API 30).
Es necesario tener instalada esta versión de Xamarin Forms y el SDK de Android correspondiente al API 30 para ejecutar la aplicación de forma correcta.

El propósito de la Aplicación es mostrar una Lista de Tareas. La aplicación permite agregar nuevas Tareas, eliminarlas y marcarlas como completadas,
las tareas completadas aparecen en la vista principal con un borde azul. En la vista de crear Tareas se valida que todos los campos hayan sido llenados.

Se utilizó el Patrón de Diseño MVVM, por lo cual la aplicación se divide en las carpetas Models, Views y ViewModels además de la carpeta Data donde se almacena la clase que contiene a la Base de Datos.

Para la implementación de la Base de datos se utilizó SQLite por medio de la instalación de la librería sqlite-net-pcl. La Base de datos utiliza una conexión asíncrona por medio de la implementación
de la clase SQLiteAsyncConnection.

La Aplicación Utiliza una clase estática llamada Locator que contiene propiedades estáticas de la Clase de la base de datos y de cada una de las clases que cumplen la función de ViewModels de cada una de las vistas,
de esta manera se implementa el patrón de diseño MVVM.

Se utilizan ventanas emergentes PopUp implementando la librería Rg.Plugins.PopUp para agilizar la funcionalidad de seleccionar una tarea para editarla o eliminarla.



