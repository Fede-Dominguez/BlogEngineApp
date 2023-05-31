# Aoniken Blog API

## Descripcion
API donde un editor puede recibir, modificar y subir nuevos Blogs.

## Aclaracion
Para el correcto funcionamiento requeriremos de un IDE capaz de ejecutar el codigo y preparar nuestra base de datos corriendo el script Script_BlogsTable.sql en SQL Server.

## Instalacion
1) Desde nuestro IDE necesitamos modificar la propiedad ConnectionString del archivo appsettings.json con la ruta de la base de datos correspondiente.
2) Compilamos y ejecutamos el proyecto.

## Pruebas 
Al ejecutar nuestro codigo en el navegador web automaticamente se podran visualizar las distintas llamadas mediante Swagger UI. En la misma se encuentran:
1) GetBlogs: Devuelve un JSON con un listado de los blogs en estado pendiente de la base.
2) GetBlogsByCod: Al asignar un codigo de blog devuelve un JSON con el mismo.
3) SaveBlogs: Permite crear un nuevo blog.
4) UpdateBlogs: Actualiza valores en base a un codigo de blog.
