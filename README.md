¿Cómo correr el programa?

1. Ir al proyecto "solvex_technical_test" e ir al archivo "appsettings.json" y en la parte de Server tanto de DefaultConnection como de IdentityConnection ajustarlo a tu máquina de SqlServer.
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/48c78341-cb76-4b8d-8e3a-d49feb221433)

2. Ir a la API "WebApi" e ir al archivo "appsettings.json" y en la parte de Server en DefaultConnection ajustarlo a tu máquina de SqlServer.
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/d8f0ed3e-e327-4d5c-92be-4fffba93fe9b)

3. Ir al proyecto "solvex_technical_test" y establecerlo como proyecto de inicio.
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/561ad20e-4fda-4638-90b7-8e3efcf512e6)

4. Ir a la carpeta de Infrastructure y en la Capa "Database" eliminar la carpeta Migrations
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/84967a60-1021-4676-810b-54bb3a1d3fb7)

5. Abrir la Consola del Administrador de paquetes, en el apartado de "Proyecto predeterminado" seleccionar la Capa "Database".
 
  En la Consola del Administrador de paquetes escribir el comando: 
  Add-Migration Initial -Context ApplicationDbContext

  Luego de crearse el Migration escribir el comando:
  Update-Database -Context ApplicationDbContext

6. Para poder ejecutar el proyecto ir a la solución del proyecto
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/289f639c-7f78-4c3c-8aac-0e593a80adef)

7. Click derecho y seleccionar la opción "Propiedades"
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/cb91c144-5038-474a-b58e-df082e83440f)

8. Seleccionar la opción "Proyectos de inicio múltiples" y seleccionar los Proyectos "solvex_technical_test" y "WebApi" y a cada uno marcarles la opción de "Iniciar", luego darle click a "Aceptar".
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/a2d03bf8-48c9-4888-a8a2-e03beac2d938)

9. Por último ejecutar el proyecto en la opción de "Iniciar".
![image](https://github.com/JaimeTerrero/Solvex_Technical_Test/assets/95511131/34cafab3-1e10-4437-b531-75aff1e1329e)
