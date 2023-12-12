<h1 align="center"><img width="48" height="48" src="https://img.icons8.com/fluency/48/safety-care.png" alt="Clay Security"/><b>Clay Security</b></h1>

<p>La empresa Clay Security dedicada a la prestacion de servicios de seguridad, esta interesada en desarrollar un backend que le permita integrar diferentes aplicaciones creadas por una empresa consultora de software, para el desarrollo de la prueba, la empresa le proporciona el DER de la base de datos elaborada por la empresa consultora!</p>

## Tecnologias 🧑🏻‍💻
<p align="center">
<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

- **Back-End Development**: 
  ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=flat&logo=c-sharp&logoColor=white) 
  ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white) 

- **Frameworks, platforms & libraries**:
  ![JWT](https://img.shields.io/badge/JWT-black?style=flat&logo=JSON%20web%20tokens)

- **Softwares & Tools**: 
  ![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=flat&logo=visual-studio-code&logoColor=white) 
  ![Postman](https://img.shields.io/badge/Postman-FF6C37?style=flat&logo=postman&logoColor=white) 
  ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=flat&logo=swagger&logoColor=white) 
  ![Insomnia](https://img.shields.io/badge/Insomnia-black?style=flat&logo=insomnia&logoColor=5849BE) 
  ![GIT](https://img.shields.io/badge/Git-fc6d26?style=flat&logo=git&logoColor=white)

- **Database**:
  ![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=flat&logo=mysql&logoColor=white)

</p>

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

## Requerimientos funcionales 👻<br>
🎯 Implementar control de acceso, usando JWT. ✔ <br>
🎯 Se debe prevenir peticiones automatizadas. ✔ <br>
🎯 Se debe implementar arquitectura DTO. ✔ <br>
🎯 Se debe implementar patron Singleton usando unidades de trabajo. ✔ <br>
🎯 Se debe implementar paginacion. ✔ <br>
🎯 Se debe generar CRUD. ✔ <br>

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

## Conteo de todas las consultas a realizar 📝
<details>
  <summary>Ver progreso de las consultas</summary>

### Consultas Totales: `Total 4/7` 👷‍♂️ <br>

</details>

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

## Consultas requeridas 👨‍💻 <br>
 **Method**: `GET`

**🔰 Query 1: Listar todos los `empleados` de la `empresa de seguridad` ✅**: `http://localhost:5106/api/Empleado/ListarEmpleados`
```sql
    SELECT `p`.`Id` AS `IdEmpleado`, `p`.`IdPersona` AS `IdUnicoPersona`, `p`.`Nombre` AS `NombreDelEmpleado`, `t`.`Descripcion` AS `TipoDeEmpleado`, `p`.`IdCategoria`, `c`.`NombreCiu` AS `NombreCiudad`
    FROM `Persona` AS `p`
    INNER JOIN `TipoPersona` AS `t` ON `p`.`IdTipoPersona` = `t`.`Id`
    INNER JOIN `Ciudad` AS `c` ON `p`.`IdCiudad` = `c`.`Id`
    WHERE `t`.`Descripcion` = 'Empleado'

    public async Task<IEnumerable<object>> ListarEmpleados()
    {
        var mensaje = "listado de empleados de la empresa".ToUpper();

        var consulta = from c in _context.Personas
                       join e in _context.Tipopersonas on c.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on c.IdCiudad equals ci.Id
                       where e.Descripcion == "Empleado"
                       select new
                       {
                           IdEmpleado = c.Id,
                           IdUnicoPersona = c.IdPersona,
                           NombreDelEmpleado = c.Nombre,
                           TipoDeEmpleado = e.Descripcion,
                           IdCategoria = c.IdCategoria,
                           NombreCiudad = ci.NombreCiu,
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
```
**Method**: `GET`

**🔰 Query 2: Listar todos los `empleados` que son `vigilantes`. ✅**: `http://localhost:5106/api/Persona/EmpleadosVigilantes`
```sql
    SELECT `p`.`Id` AS `IdEmpleado`, `p`.`IdPersona` AS `IdUnicoPersona`, `p`.`Nombre` AS `NombreDelEmpleado`, `t`.`Descripcion` AS `TipoDeEmpleado`, `c0`.`NombreCat` AS `CategoriaDeEmpleado`, `c`.`NombreCiu` AS `NombreCiudad`
    FROM `Persona` AS `p`
    INNER JOIN `TipoPersona` AS `t` ON `p`.`IdTipoPersona` = `t`.`Id`
    INNER JOIN `Ciudad` AS `c` ON `p`.`IdCiudad` = `c`.`Id`
    INNER JOIN `CategoriaPer` AS `c0` ON `p`.`IdCategoria` = `c0`.`Id`
    WHERE (`t`.`Descripcion` = 'Empleado') AND (`c0`.`NombreCat` = 'Vigilante')

    public async Task<IEnumerable<object>> ListarEmpleadosVigilantes()
    {
        var mensaje = "listado de empleados que son vigilantes en la empresa".ToUpper();

        var consulta = from c in _context.Personas
                       join e in _context.Tipopersonas on c.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on c.IdCiudad equals ci.Id
                       join cp in _context.Categoriapers on c.IdCategoria equals cp.Id
                       where e.Descripcion == "Empleado" && cp.NombreCat == "Vigilante"
                       select new
                       {
                           IdEmpleado = c.Id,
                           IdUnicoPersona = c.IdPersona,
                           NombreDelEmpleado = c.Nombre,
                           TipoDeEmpleado = e.Descripcion,
                           CategoriaDeEmpleado = cp.NombreCat,
                           NombreCiudad = ci.NombreCiu,
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
```
**Method**: `GET`

**🔰 Query 3: Listar los `numeros de contacto` de un `empleado` que sea `vigilante`. ✅**: `http://localhost:5106/api/ContactoPer/ContactoEmpleadoVigilante`
```sql
    SELECT `p`.`Id` AS `IdEmpleado`, `p`.`Nombre` AS `NombreDelEmpleado`, `t`.`Descripcion` AS `TipoDeEmpleado`, `c1`.`NombreCat` AS `CategoriaDeEmpleado`, `c`.`Descripcion` AS `DescripcionContacto`, `c`.`IdTipoContacto` AS `TipoContacto`
      FROM `ContactoPer` AS `c`
      INNER JOIN `Persona` AS `p` ON `c`.`IdPersona` = `p`.`Id`
      INNER JOIN `TipoPersona` AS `t` ON `p`.`IdTipoPersona` = `t`.`Id`
      INNER JOIN `Ciudad` AS `c0` ON `p`.`IdCiudad` = `c0`.`Id`
      INNER JOIN `CategoriaPer` AS `c1` ON `p`.`IdCategoria` = `c1`.`Id`
      WHERE (`t`.`Descripcion` = 'Empleado') AND (`c1`.`NombreCat` = 'Vigilante')

    public async Task<IEnumerable<object>> ContactoEmpleadoVigilante()
    {
        var mensaje = "listado de los contactos de los empleados que son vigilantes en la empresa".ToUpper();

        var consulta = from c in _context.Contactopers
                       join emp in _context.Personas on c.IdPersona equals emp.Id
                       join e in _context.Tipopersonas on emp.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on emp.IdCiudad equals ci.Id
                       join cp in _context.Categoriapers on emp.IdCategoria equals cp.Id
                       where e.Descripcion == "Empleado" && cp.NombreCat == "Vigilante"
                       select new
                       {
                           IdEmpleado = emp.Id,
                           NombreDelEmpleado = emp.Nombre,
                           TipoDeEmpleado = e.Descripcion,
                           CategoriaDeEmpleado = cp.NombreCat,
                           DescripcionContacto = c.Descripcion,
                           TipoContacto = c.IdTipoContacto
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
```
**Method**: `GET`

**🔰 Query 4: Listar todos los `clientes` que vivan en la ciudad de `Bucaramanga`. ✅**: `http://localhost:5106/api/Persona/ClientesQueVivenEnBucaramanga`
```sql
    SELECT `p`.`Id` AS `IdCliente`, `p`.`IdPersona` AS `IdUnicoPersona`, `p`.`Nombre` AS `NombreDelCliente`, `c`.`NombreCiu` AS `NombreCiudad`
      FROM `Persona` AS `p`
      INNER JOIN `TipoPersona` AS `t` ON `p`.`IdTipoPersona` = `t`.`Id`
      INNER JOIN `Ciudad` AS `c` ON `p`.`IdCiudad` = `c`.`Id`
      WHERE (`t`.`Descripcion` = 'Cliente') AND (`c`.`NombreCiu` = 'Bucaramanga')

    public async Task<IEnumerable<object>> ClientesQueVivenEnBucaramanga()
    {
        var mensaje = "listado de clientes que viven en Bucaramanga".ToUpper();

        var consulta = from c in _context.Personas
                       join e in _context.Tipopersonas on c.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on c.IdCiudad equals ci.Id
                       where e.Descripcion == "Cliente" && ci.NombreCiu == "Bucaramanga"
                       select new
                       {
                           IdCliente = c.Id,
                           IdUnicoPersona = c.IdPersona,
                           NombreDelCliente = c.Nombre,
                           NombreCiudad = ci.NombreCiu,
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
```
**Method**: `GET`

**🔰 Query 5: Listar todos los `empleados` que vivan en `Giron` y `Piedecuesta`. 👷‍♂️**: `http://localhost:5106/api/Persona/EmpleadosQueVivenEnGiron&Piedecuesta`
```sql


    public async Task<IEnumerable<object>> EmpleadosQueVivenEnGironYPiedecuesta()
    {
        var mensaje = "listado de clientes que viven en Bucaramanga".ToUpper();

        var consulta = from c in _context.Personas
                       join e in _context.Tipopersonas on c.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on c.IdCiudad equals ci.Id
                       join cp in _context.Categoriapers on c.IdCategoria equals cp.Id
                       where e.Descripcion == "Empleado" && ci.NombreCiu == "Giron" || ci.NombreCiu == "Piedecuesta"
                       select new
                       {
                           IdEmpleado = c.Id,
                           IdUnicoPersona = c.IdPersona,
                           NombreDelEmpleado = c.Nombre,
                           TipoDeEmpleado = e.Descripcion,
                           CategoriaDeEmpleado = cp.NombreCat,
                           NombreCiudad = ci.NombreCiu,
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
```
**Method**: `GET`

**🔰 Qeury 6: Listar todos los `clientes` que tengan `mas de 5 años de antiguedad`. 👷‍♂️**: `http://localhost:5106/api/Persona/ClientesCon5AñosDeAntiguedad`
```sql
    
```
**Method**: `GET`

**🔰 Query 7: Listar todos los `contratos` cuyo estado es `activo`. Se debe mostrar el `Nro de contrato`, el `nombre del cliente` y el `empleado que registro el contrato`. 👷‍♂️**: `http://localhost:5292/api/Pedido/ContratosActivos`
```sql
    
```

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

## Preview project 👀
### 1. Controllers:
<img src="./assets/controllers.png">

### 2. Diagram-Database: Clay Security:
<img src="./assets/database_diagram.png">

### 3. Diagram-Tables JWT: User-Rol-RefreshToken:
<img src="./assets/diagram_tables_jwt.png">

### 4. Data-Table: Pais:
<img src="./assets/table_pais.png">

### 5. Data-Table: Departamento:
<img src="./assets/table_departamento.png">

### 6. Data-Table: Ciudad:
<img src="./assets/table_ciudad.png">

### 7. Data-Table: Persona:
<img src="./assets/table_persona.png">

### 8. Data-Table: Tipo Persona:
<img src="./assets/table_tipo_persona.png">

### 9. Data-Table: Categoria Persona:
<img src="./assets/table_categoria_persona.png">

### 10. Data-Table: Direccion Persona:
<img src="./assets/table_direccion_persona.png">

### 11. Data-Table: Tipo Direccion:
<img src="./assets/table_tipo_direccion.png">

### 12. Data-Table: Contacto Persona:
<img src="./assets/table_contacto_persona.png">

### 13. Data-Table: Tipo Contacto:
<img src="./assets/table_tipo_contacto.png">

### 14. Data-Table: Contrato:
<img src="./assets/table_contrato.png">

### 15. Data-Table: Programacion:
<img src="./assets/table_programacion.png">

### 16. Data-Table: Turno:
<img src="./assets/table_turno.png">

### 17. Data-Table: Estado:
<img src="./assets/table_estado.png">

<h4>Pasos a Seguir:</h4>
<p>Usuarios por defecto</p>
<img src="./assets/usuarios.png"><br>

<p>Registro de usuario</p>
<img src="./assets/registro.png"><br>

<p>Loguearse para obtener Token</p>
<img src="./assets/logueo.png"><br>

<p>Consultas resguardas por tipo de autenticacion con Bearer Token</p>
<img src="./assets/tipoToken.png"><br>

<p>Ingreso de Token</p>
<img src="./assets/token.png"><br>

<p>Consultas especiales de Usuarios & Roles</p>
<img src="./assets/especiales
.png"><br>

## Authors and collaborators:
- Powered by <a href="https://github.com/IgmarLozadaBolivar">Igmar Lozada</a><br>

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>

## Thank you for reading this documentation and that you have observed this interesting project!

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif"><br>
