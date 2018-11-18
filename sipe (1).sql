-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-11-2018 a las 22:14:51
-- Versión del servidor: 10.1.34-MariaDB
-- Versión de PHP: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sipe`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `actualizar_insumo` (IN `nombre` VARCHAR(50), IN `cantidadMin` FLOAT, IN `idTipo` VARCHAR(15), IN `aunFacturar` VARCHAR(2), IN `comentario` VARCHAR(200), IN `id` VARCHAR(15))  BEGIN

DECLARE _idTipoMedida varchar(20);

SELECT idTipoCantidad INTO _idTipoMedida FROM tipos_de_cantidades WHERE nombreTipoCantidad=idTipo;

UPDATE insumos SET nombreInsumo=nombre,cantidadMinimaInsumo=cantidadMin,idTipoCantidad=_idTipoMedida,facturarInsumo=aunFacturar,descripcionInsumo=comentario WHERE idInsumo=id;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `actualizar_proveedores` (IN `muni` VARCHAR(15), IN `nombre` VARCHAR(30), IN `direccion` VARCHAR(50), IN `telefono` VARCHAR(20), IN `razon` VARCHAR(50), IN `nit` VARCHAR(20), IN `url` VARCHAR(40), IN `postal` VARCHAR(20), IN `email` VARCHAR(50), IN `fax` VARCHAR(20), IN `contactovend` VARCHAR(20), IN `entrega` VARCHAR(6), IN `obser` VARCHAR(500), IN `id` VARCHAR(15))  NO SQL
UPDATE proveedores set idMunicipio=muni,nombreProveedor=nombre,direccionProveedor=direccion,telefonoProveedor=telefono,razonSocial=razon,nitProveedor=nit,urlProveedor=url,codigoPostal=postal,emailProveedor=email,faxProveedor=fax,contactoVendedor=contactovend,idDia=entrega,observaciones=obser WHERE idProveedor=id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `actualiza_factura_compra` (IN `idFact` VARCHAR(20), IN `idProv` VARCHAR(15), IN `idTipo` VARCHAR(15), IN `fechaCom` DATE, IN `valTot` VARCHAR(20))  UPDATE facturas_de_compras SET idProveedor=idProv, idTipoCompra=idTIpo,fechaCompra=fechaCom, valorTotal=valTot WHERE idFacturaCompra=idFact$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `agregarCompra` (IN `prov` VARCHAR(15), IN `tipo` VARCHAR(20), IN `valor` FLOAT(20), IN `idfactura` INT(11), IN `nombre` VARCHAR(40), IN `tipoCan` VARCHAR(15), IN `cantidad` FLOAT(20))  BEGIN

DECLARE a int(20);
declare x varchar(15);
declare y float(20);
declare z int (20);
DECLARE flag int (20) DEFAULT 0;
DECLARE b int;

select idFacturaCompra into z from facturas_de_compras where idFacturaCompra=idfactura;

SELECT idTipoCantidad into b FROM tipos_de_cantidades WHERE nombreTipoCantidad=tipoCan;

SELECT idTipoCompra into a FROM tipos_de_compras WHERE nombreTipoCompra=tipo;

SELECT idProductoMarca into x from productos_marcas where NombreProductoMarca=nombre;

if(z=idfactura ) then 
	


insert into detalles_compras(idDetalleCompra,idFacturaCompra,idProductoMarca,idTipoCantidad,cantidad,subtotal) VALUES(null,idfactura,x,b,cantidad,(cantidad*valor));

select cantidaProductoMarca into y from productos_marcas where NombreProductoMarca=nombre;

UPDATE  productos_marcas SET cantidaProductoMarca=(cantidad+y),cantidadExitencia=(cantidadExitencia+cantidad) WHERE NombreProductoMarca=nombre;

SELECT x;
else 

insert into facturas_de_compras(idFacturaCompra,idProveedor,idTipoCompra,fechaCompra,valorTotal,idBodega,estadoMercancia) values(null,prov,a,now(),valor,"1","compra");



insert into detalles_compras(idDetalleCompra,idFacturaCompra,idProductoMarca,idTipoCantidad,cantidad,subtotal) VALUES(null,idfactura,x,b,cantidad,(cantidad*valor));

select cantidaProductoMarca into y from productos_marcas where NombreProductoMarca=nombre;

UPDATE  productos_marcas SET cantidaProductoMarca=(cantidad+y),cantidadExitencia=(cantidadExitencia+cantidad) WHERE NombreProductoMarca=nombre;

SELECT x;
end if;

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `agregarInventarioInsumos` (IN `idInsu` VARCHAR(20), IN `cant` FLOAT(11))  UPDATE insumos SET cantidadInsumo=cantidadInsumo+cant WHERE idInsumo=idInsu$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `agregarInventarioInsumos_y_cambiar_estado_compra` (IN `idInsu` VARCHAR(20), IN `cant` FLOAT(11), IN `idFactu` VARCHAR(20))  BEGIN

UPDATE insumos SET cantidadInsumo=cantidadInsumo+cant WHERE idInsumo=idInsu;

UPDATE facturas_de_compras SET estadoMercancia="RECIBIDO" WHERE idFacturaCompra=idFactu;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `aumentar_cantidad_producto_marca_desde_preparacion` (IN `idRece` VARCHAR(20))  UPDATE productos_marcas SET cantidadExitencia=cantidaProductoMarca+(SELECT cantidadProductoGenerado FROM recetas WHERE idReceta=idRece) WHERE idProductoMarca=(SELECT idProductoMarca FROM recetas WHERE idReceta=idRece)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `autoCompletar` ()  select idCliente from clientes$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `autoCompletarProductoVenta` ()  select NombreProductoMarca from productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `autocompletar_nombre_productos_marca` ()  SELECT NombreProductoMarca from productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarCliente` (IN `id` VARCHAR(15))  BEGIN

declare x int(20);

select idCliente into x from clientes where idCliente=id;

if (x>=0) then 

select * from clientes where idCliente=id;


ELSE

SELECT "0";

end if;

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `buscarInventario` (IN `nombre` VARCHAR(40))  select * from productos_marcas where  NombreProductoMarca=nombre$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cantidadProducto` (IN `Prod` VARCHAR(40))  NO SQL
BEGIN

DECLARE var int;
DECLARE var2 int;

SELECT NombreProductoMarca into var from productos_marcas WHERE NombreProductoMarca=Prod;

IF var=Prod THEN

select cantidadExitencia from productos_marcas where NombreProductoMarca=Prod;

ELSE

SELECT "NO EXISTE";
END IF;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cargar_tabla_compra_insumo_modificar` (IN `idFact` VARCHAR(20))  SELECT detalles_compras_insumos.idInsumo as Codigo,nombreInsumo as Descipcion,cantidad as Cantidad,costoInsumo AS PrecioUnit ,subtotal as SubTotal FROM detalles_compras_insumos,insumos WHERE detalles_compras_insumos.idInsumo=insumos.idInsumo AND detalles_compras_insumos.idFacturaCompra=idFact$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cargar_ventana_modificar_detalles_receta` (IN `idRece` VARCHAR(20))  SELECT idInsumo,cantidadInsumoUtilizado FROM detalles_recetas WHERE idReceta=idRece$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cargar_ventana_modificar_receta` (IN `idRece` VARCHAR(20))  SELECT idReceta,nombreReceta,cantidadProductoGenerado,fechaElaboracion,descripcionReceta FROM recetas WHERE idReceta=idRece$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `crearCategoria` (IN `idC` VARCHAR(20), IN `nomC` VARCHAR(20))  insert into categorias values(idC,nomC)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `crearUbicacion` (IN `id` VARCHAR(20), IN `nom` VARCHAR(20), IN `can` VARCHAR(20))  insert into ubicaciones values(id,nom,can)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `descontar_cantidad_de_insumo_usado` (IN `idInsu` VARCHAR(20), IN `cantiElab` VARCHAR(20))  UPDATE insumos SET cantidadInsumo=cantidadInsumo-cantiElab WHERE idInsumo=idInsu$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `descontar_producto_marca` (IN `idProdu` VARCHAR(40), IN `cant` INT(11))  UPDATE productos_marcas SET cantidadExitencia=cantidadExitencia-cant WHERE idProductoMarca=idProdu$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `detallesProducto` (IN `nombre` VARCHAR(40))  SELECT idProductoMarca,NombreProductoMarca,idUbicacion,cantidadExitencia,precio_unidad,precio_cantidad from productos_marcas where NombreProductoMarca=nombre$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `devoluciones` (IN `numero` VARCHAR(15), IN `nombre` VARCHAR(20), IN `cantidad` INT(20))  BEGIN

declare a,b,c,d,e,f,g,h varchar(20);

select idUbicacion into a from productos_marcas where idProductoMarca=numero;
select idCategotia into b from productos_marcas where idProductoMarca=numero;
select cantidaProductoMarca into c from productos_marcas where idProductoMarca=numero;
select cantidadExistencia into d from productos_marcas where idProductoMarca=numero;
select valorCompraUnidad into e from productos_marcas where idProductoMarca=numero;
select precio_unidad into f from productos_marcas where idProductoMarca=numero;
select precio_cantidad into g from productos_marcas where idProductoMarca=numero;
select valorCompraMayor into h from productos_marcas where idProductoMarca=numero;

insert into productos_marcas values ((CONCAT(numero,'d')),a,b,nombre,(cantidad),(d-cantidad),(cantidad*f),now(),f,g,(g*cantidad),"Devolucion",null);


end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_detalles_factura_insumo` (IN `idFact` VARCHAR(20))  DELETE FROM detalles_compras_insumos WHERE detalles_compras_insumos.idFacturaCompra=idFact$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_factura_compras` (IN `idFact` VARCHAR(20))  DELETE FROM facturas_de_compras WHERE idFacturaCompra=idFact$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_receta` (IN `codigo` VARCHAR(20))  BEGIN
DELETE FROM detalles_recetas WHERE idReceta=codigo;

DELETE FROM recetas WHERE idReceta=codigo;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Entradas` (IN `nombre` VARCHAR(40))  BEGIN
declare x int (11)DEFAULT 0;
declare y int(11)DEFAULT 0;

select idProductoMarca into x from productos_marcas where NombreProductoMarca=nombre;



SELECT facturas_de_compras.idFacturaCompra,facturas_de_compras.fechaCompra,facturas_de_compras.idProveedor,cantidad,facturas_de_compras.valorTotal  from facturas_de_compras inner join detalles_Compras on facturas_de_compras.idFacturaCompra=detalles_compras.idFacturaCompra and detalles_compras.IdProductoMarca=x;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `guardarFactura` (IN `idC` VARCHAR(15), IN `nomVend` VARCHAR(15), IN `idTipoP` VARCHAR(15), IN `fecha` DATETIME, IN `vVenta` DOUBLE, IN `obser` TEXT)  begin 
declare x varchar(15);
declare var int;

SELECT idVendedor into var FROM vendedores WHERE nombreVendedor=nomVend;

select idTipoDePago  into x from tipos_de_pagos where nombreTipoDePago = idTipoP;

insert into factura_ventas values (null,idC,var,x,fecha,vVenta,obser);

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Idvend` (IN `idVe` VARCHAR(15))  select idVendedor from vendedores where idVendedor=idVe$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ingresarProductosMarca` (IN `idP` VARCHAR(15), IN `idU` VARCHAR(20), IN `idC` VARCHAR(20), IN `nombre` VARCHAR(20), IN `unidad` INT(20), IN `precio` INT(20), IN `tipoC` VARCHAR(15), IN `idB` VARCHAR(20))  BEGIN

DECLARE y int(11);
DECLARE x int(11);
declare cantidad int(20) DEFAULT 0;
SELECT idCategoria into y from categorias WHERE nombreCategoria =idU;
SELECT idUbicacion into x from ubicaciones where nombreUbicacion=idC;

insert into productos_marcas values(idP,x,y,nombre,cantidad,(cantidad),(cantidad*unidad),now(),unidad,precio,(cantidad*precio),"Compra",null,tipoC,idB);

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_cliente` (IN `id` VARCHAR(15), IN `nombre` VARCHAR(30), IN `apellido` VARCHAR(30), IN `telefono` VARCHAR(20), IN `direccion` VARCHAR(50))  BEGIN

declare identificacion varchar(15) default "";

select idCliente into identificacion from clientes where id=idCliente;


if(identificacion=id) then 

Select"El cliente a ingresar ya existe ";

ELSE

insert into clientes values(id,nombre,apellido,telefono,direccion);

end if;


END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_detalles_compra_insumo` (IN `idFact` INT(15), IN `idInsu` VARCHAR(15), IN `cant` VARCHAR(11), IN `subTo` VARCHAR(11))  INSERT into detalles_compras_insumos(idDetalleCompraInsumo,idFacturaCompra,idInsumo,cantidad,subtotal) VALUES(null ,idFact,idInsu,cant,subTo)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_detalles_recetas` (IN `idRece` VARCHAR(15), IN `idInsu` VARCHAR(15), IN `idTipo` VARCHAR(15), IN `cantiInsu` FLOAT(11))  INSERT into detalles_recetas(idDetalleReceta,idReceta,idinsumo,idTipoCantidad,cantidadInsumoUtilizado)VALUES(null,idRece,idInsu,idTipo,cantiInsu)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_detalles_ventas` (IN `codigoFac` VARCHAR(20), IN `idProdu` VARCHAR(20), IN `cant` INT(11), IN `subTo` FLOAT(11))  BEGIN

INSERT INTO detalles_ventas(idDetalleVenta,idFacturaVenta,idProductoMArca,cantidad,subtotal)VALUES(null,codigoFac,idProdu,cant,subTo);

UPDATE productos_marcas SET cantidadExitencia=cantidadExitencia-cant WHERE idProductoMarca=idProdu;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_factura_compra` (IN `idProve` VARCHAR(15), IN `idTipoCom` VARCHAR(15), IN `fechaCom` DATE, IN `valTotal` FLOAT(11), IN `idBod` VARCHAR(20), IN `estado` VARCHAR(20))  INSERT INTO facturas_de_compras (idFacturaCompra,idProveedor,idTipoCompra,fechaCompra,valorTotal,idBodega, estadoMercancia) VALUES(null,idProve,idTipoCom,fechaCom,valTotal,idBod, estado)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_guardar_compra` (IN `idProve` VARCHAR(15), IN `idTipoCom` VARCHAR(15), IN `fechaCom` VARCHAR(15), IN `valTotal` DATE, IN `idBod` VARCHAR(20), IN `uso` VARCHAR(6), IN `idFac` VARCHAR(20))  INSERT INTO guardar_facturas(idFacturaGuardada,idCliente,idVendedor,idTipoDePago,fechaVenta,valorVenta,EnUso) VALUES(idFac,idProve,idTipoCom,fechaCom,valTotal,idBod,uso)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_insumo` (IN `id` VARCHAR(15), IN `nombre` VARCHAR(30), IN `costo` FLOAT(15), IN `cantidad` FLOAT(15), IN `stock` INT(15), IN `tipoCant` VARCHAR(15), IN `facturarSin` VARCHAR(2), IN `comen` VARCHAR(60))  INSERT INTO insumos(idInsumo,nombreInsumo,costoInsumo,cantidadInsumo,cantidadMinimaInsumo,idTipoCantidad,facturarInsumo,descripcionInsumo) VALUES(id,nombre,costo,cantidad,stock,tipoCant,facturarSin,comen)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_proveedor` (IN `id` VARCHAR(15), IN `muni` VARCHAR(20), IN `nombre` VARCHAR(30), IN `direccion` VARCHAR(50), IN `telefono` VARCHAR(20), IN `razon` VARCHAR(50), IN `nit` VARCHAR(20), IN `url` VARCHAR(40), IN `postal` VARCHAR(20), IN `email` VARCHAR(50), IN `fax` VARCHAR(20), IN `contacto` VARCHAR(20), IN `diaEn` VARCHAR(20), IN `obser` VARCHAR(500))  INSERT INTO proveedores(idProveedor,idMunicipio,nombreProveedor,direccionProveedor,telefonoProveedor,razonSocial,nitProveedor,urlProveedor,codigoPostal,emailProveedor,faxProveedor,contactoVendedor,idDia,observaciones) VALUES(id,muni,nombre,direccion,telefono,razon,nit,url,postal,email,fax,contacto,diaEn,obser)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_receta` (IN `idRece` VARCHAR(15), IN `idProdu` VARCHAR(15), IN `nomRece` VARCHAR(30), IN `cantProGen` INT(6), IN `fechaEla` DATE, IN `descRece` TEXT)  INSERT INTO recetas(idReceta,idProductoMarca,nombreReceta,cantidadProductoGenerado,fechaElaboracion,descripcionReceta)VALUES(idRece,idProdu,nomRece,cantProGen,fechaEla,descRece)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamarbodega` ()  SELECT nombreBodega from bodega$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamarCategoria` (IN `idm` VARCHAR(20))  select nombreCategoria from categorias where idCategoria=idm$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamarNombreProducto` ()  SELECT NombreProductoMarca from productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamarPrecio` (IN `nombre` VARCHAR(60), IN `cantidad` INT(20))  Begin
if (cantidad>10) then
select precio_cantidad from productos_marcas where NombreProductoMarca= nombre; 

else 
select precio_unidad from productos_marcas where NombreProductoMarca= nombre;

end if ;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamarTipo` ()  SELECT nombreTipoCantidad from tipos_de_cantidades$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamartipocantidad` ()  SELECT idTipoCantidad from tipos_de_cantidades$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `llamarUbicacion` (IN `id` VARCHAR(20))  select nombreUbicacion from ubicaciones where idUbicacion=id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `modificarDatos` (IN `idc` VARCHAR(15), IN `nombrec` VARCHAR(30), IN `apellidoc` VARCHAR(30), IN `telefonoc` VARCHAR(20), IN `direccionc` VARCHAR(50))  NO SQL
update clientes set idCliente=idc,nombreCliente=nombrec,apellidoCliente=apellidoc,telefonoCliente=telefonoc,direccionCliente=direccionc where idCliente=idc$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `modificarProducto` (IN `nombre` VARCHAR(40), IN `cantidad` VARCHAR(20), IN `unidad` VARCHAR(20), IN `precio` VARCHAR(20), IN `recibo` VARCHAR(40))  update productos_marcas set NombreProductoMarca=nombre,cantidaProductoMarca=cantidad,precio_unidad=unidad,precio_cantidad=precio,cantidadExitencia=(cantidadExitencia+cantidad),valorCompraUnidad=(unidad*cantidad),valorCompraMayor=(precio*cantidad) where productos_marcas.NombreProductoMarca=recibo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrarNombreProducto` (IN `id` VARCHAR(20))  select NombreProductoMarca from productos_marcas where idProductoMarca=id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrarProducto` ()  SELECT NombreProductoMarca from productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrarProductosMarca` ()  select idProductoMarca,idUbicacion,idCategotia,NombreProductoMarca,CantidaProductoMarca,precio_unidad,precio_cantidad from productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrarproveedor` ()  select idProveedor from proveedores$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_clientes` ()  Select * from clientes$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_compra_insumos` ()  SELECT idFacturaCompra,facturas_de_compras.idProveedor,nombreProveedor, nombreTipoCompra,fechaCompra,valorTotal,estadoMercancia FROM facturas_de_compras, tipos_de_compras,proveedores WHERE tipos_de_compras.idTIpoCompra=facturas_de_compras.idTipoCompra AND idBodega=2 AND proveedores.idProveedor=facturas_de_compras.idProveedor ORDER by idFacturaCompra DESC$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_insumos_busqueda` ()  SELECT idInsumo,nombreInsumo,cantidadInsumo,nombreTipoCantidad FROM insumos,tipos_de_cantidades WHERE insumos.idTipoCantidad=tipos_de_cantidades.idTipoCantidad$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_inventario_insumos` ()  SELECT idInsumo,nombreInsumo,costoInsumo,cantidadInsumo, nombreTipoCantidad FROM insumos,tipos_de_cantidades WHERE insumos.idTipoCantidad=tipos_de_cantidades.idTipoCantidad$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_productos_marca_busqueda` ()  SELECT idProductoMarca,NombreProductoMarca,cantidadExitencia FROM productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_recetas` ()  SELECT idReceta,nombreReceta,cantidadProductoGenerado,fechaElaboracion from recetas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_tipo_pago` (IN `nombreTip` VARCHAR(20))  select nombreTipoDePago from tipos_de_pagos where nombreTipoDePAgo=nombreTip$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_vista_insumos` ()  SELECT * FROM vista_mostrar_insumos$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `mostrar_vista_proveedores` ()  SELECT idProveedor as Codigo,nombreProveedor as Nombre, nitProveedor as Nit,direccionProveedor as Direccion FROM proveedores_vista$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `nCliente` (IN `n` VARCHAR(40))  SELECT clientes.nombreCliente from clientes WHERE clientes.idCliente=n$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `nombreCliente` (IN `Clien` VARCHAR(15))  select nombreCliente from clientes where idCliente=Clien$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccioarFactura` ()  select idProductoMarca from productos_marcas$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionarcategoria` ()  select categorias.nombreCategoria from categorias$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionarPago` ()  select nombreTipoDePago from tipos_de_pagos$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionarProducto` (IN `nom` VARCHAR(30))  select productos_marcas.idProductoMarca,productos_marcas.idUbicacion,productos_marcas.idCategotia,productos_marcas.NombreProductoMarca,productos_marcas.cantidadExitencia,productos_marcas.precio_unidad,productos_marcas.precio_cantidad from productos_marcas where productos_marcas.NombreProductoMarca=nom$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionarUbicacion` ()  select ubicaciones.nombreUbicacion from ubicaciones$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `tipo_de_pago` ()  NO SQL
select nombreTipoDePago from tipos_de_pagos$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `traer_idInsumo_idTipoCantidad` (IN `nombreIns` VARCHAR(50))  select idInsumo,idTipoCantidad from insumos where nombreInsumo=nombreins$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `traer_numero_factura_compra` ()  NO SQL
SELECT `AUTO_INCREMENT`
FROM  INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = "sipe"
AND   TABLE_NAME   = "facturas_de_compras"$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `traer_numero_venta` ()  SELECT `AUTO_INCREMENT`
FROM  INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = "sipe"
AND   TABLE_NAME   = "factura_ventas"$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `traer_precio_unidad_insumo` (IN `id` VARCHAR(20))  SELECT costoInsumo FROM insumos WHERE idInsumo=id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `trae_insumos_y_cantidades_para_preparar_receta` (IN `idRece` VARCHAR(20))  SELECT idInsumo,cantidadInsumoUtilizado FROM detalles_recetas WHERE idReceta=idRece$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `trae_resta_de_insumos_para_preparar_receta` (IN `idRece` VARCHAR(20))  NO SQL
SELECT insumos.idInsumo,  cantidadInsumo-cantidadInsumoUtilizado as resta FROM insumos,detalles_recetas WHERE detalles_recetas.idReceta=idRece AND insumos.idInsumo=detalles_recetas.idInsumo$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validarCategoria` (IN `idC` VARCHAR(20), IN `nomC` VARCHAR(20))  BEGIN

declare c varchar(20);

select idCategoria into c from categorias where idCategoria=idC or nombreCategoria=nomC;

if(c>=1) THEN

select"1";

else 

select"0";


end if;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validarSeleccion` (IN `id` VARCHAR(20))  begin 

declare c varchar(20);

select idProductoMarca into c from productos_marcas where idProductoMarca=id;

if(c>=1)THEN

select"1";

else  

select"0";

end if;


end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validarUbicacion` (IN `id` VARCHAR(20), IN `nom` VARCHAR(20), IN `can` VARCHAR(20))  BEGIN

declare c varchar(20);

select idUbicacion into c from ubicaciones where idUbicacion=id or nombreUbicacion=nom or capacidad=can;

if(c>=1) THEN

select "1";

ELSE

select "0";

end if;


END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_cantidad_de_insumo` (IN `nombreInsu` VARCHAR(50), IN `cantidad` VARCHAR(11))  BEGIN 

DECLARE var int;
SELECT cantidadInsumo INTO var FROM insumos WHERE nombreInsumo=nombreInsu;

IF(var>=cantidad)THEN
SELECT "1",nombreInsumo FROM insumos WHERE nombreInsumo=nombreInsu;
ELSE
SELECT "0",nombreInsumo FROM insumos WHERE nombreInsumo=nombreInsu;
END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_cantidad_de_insumo_para_preparar_receta` (IN `idInsu` VARCHAR(20), IN `resta` VARCHAR(20))  NO SQL
BEGIN

IF resta>=0 THEN
SELECT "yes", nombreInsumo FROM insumos WHERE idInsumo=idInsu;
ELSE
SELECT "no",nombreInsumo FROM insumos WHERE idInsumo=idInsu;
END IF;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_codigo_receta` (IN `codigo` VARCHAR(20))  BEGIN

DECLARE var int;

SELECT idReceta into var FROM recetas WHERE idReceta=codigo;

IF var=codigo THEN
SELECT "YA EXISTE";
ELSE
SELECT "NO EXISTE";
end if;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_estado_Compra_facturas_compra` (IN `idFact` VARCHAR(20))  BEGIN 

DECLARE var int;
SELECT idFacturaCompra into var FROM facturas_de_compras WHERE idFacturaCompra=idFact AND estadoMercancia="RECIBIDO";

if(var=idFact) THEN
SELECT '1'; 
ELSE
SELECT '0';
END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_idInsumo` (IN `codigo` VARCHAR(20))  BEGIN

DECLARE var int;
DECLARE flag int DEFAULT 0;

SELECT idInsumo into var from insumos WHERE idInsumo=codigo;

IF var=codigo THEN
SELECT flag+1;
ELSE
SELECT flag;
END if;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_idInsumo_trae_el_nombre_del_insumo` (IN `codigo` VARCHAR(20))  BEGIN

DECLARE var int;
DECLARE flag int DEFAULT 0;

SELECT idInsumo into var from insumos WHERE idInsumo=codigo;

IF var=codigo THEN
SELECT nombreInsumo FROM insumos WHERE idInsumo=codigo ;
ELSE
SELECT flag;
END if;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_idProductoMarca_trae_nombre_y_cantidad` (IN `codigo` VARCHAR(20))  BEGIN

DECLARE var int;

SELECT idProductoMarca into var FROM productos_marcas WHERE idProductoMarca=codigo;

IF var=codigo THEN
SELECT NombreProductoMarca,cantidadExitencia FROM productos_marcas WHERE idProductoMarca=codigo;
ELSE
SELECT "NO EXISTE";

END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_idProveedor` (IN `codigo` VARCHAR(20))  BEGIN

DECLARE var varchar(20);
DECLARE flag int DEFAULT 0;

SELECT idProveedor into var from proveedores WHERE idProveedor=codigo;

IF var=codigo THEN
SELECT flag+1;
ELSE
SELECT flag;
END if;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validar_y_traer_nombre_proveedor_con_id` (IN `codigo` VARCHAR(20))  NO SQL
BEGIN

DECLARE var int;
DECLARE flag int DEFAULT 0;

SELECT idProveedor into var from proveedores WHERE idProveedor=codigo;

IF var=codigo THEN
SELECT nombreProveedor,nitProveedor from proveedores WHERE idProveedor=var;
ELSE
SELECT flag;
END if;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `valida_cliente` (IN `id` VARCHAR(15))  BEGIN

declare v varchar(20) default "";

select idCliente into v from clientes where id=idCliente;

SELECT v;
if(id=v)THEN

select"1";

ELSE

select"0";

end if;


END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `verificar_si_la_factura_ya_existe` (IN `idFact` VARCHAR(20))  NO SQL
BEGIN 
DECLARE var int;

SELECT DISTINCT(detalles_compras_insumos.idFacturaCompra)  into var FROM detalles_compras_insumos WHERE idFacturaCompra=idFact; 

IF (var=idFact)THEN
SELECT 1;
ELSE
SELECT 0;
END IF;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `verificar_usuario_y_contraseña` (IN `usuario` VARCHAR(50), IN `passw` VARCHAR(50))  BEGIN

declare usu varchar(40) default "";
DECLARE pass varchar(40) DEFAULT "";

SELECT usuarioVendedor into usu FROM vendedores WHERE usuarioVendedor=usuario;

SELECT claveVendedor into pass FROM vendedores WHERE
usuarioVendedor=usuario;


IF strcmp(usu,usuario)=0 THEN

	IF strcmp(pass,passw)=0 THEN
	SELECT "bienvenido",nombreVendedor FROM vendedores WHERE usuarioVendedor=usuario;
    ELSE
    SELECT "error2";
	END if;
ELSE
SELECT "error1";
END if;

END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bodega`
--

CREATE TABLE `bodega` (
  `idBodega` varchar(20) COLLATE utf8_bin NOT NULL,
  `nombreBodega` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `bodega`
--

INSERT INTO `bodega` (`idBodega`, `nombreBodega`) VALUES
('1', 'INVENTARIO'),
('2', 'COCINA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE `categorias` (
  `idCategoria` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreCategoria` varchar(30) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`idCategoria`, `nombreCategoria`) VALUES
('1222', 'frituras'),
('123', 'solido'),
('1234', 'manzanada'),
('125', 'liquido'),
('254', 'géÑerico');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `idCliente` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreCliente` varchar(30) COLLATE utf8_bin NOT NULL,
  `apellidoCliente` varchar(30) COLLATE utf8_bin NOT NULL,
  `telefonoCliente` varchar(20) COLLATE utf8_bin NOT NULL,
  `direccionCliente` varchar(50) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`idCliente`, `nombreCliente`, `apellidoCliente`, `telefonoCliente`, `direccionCliente`) VALUES
('112188477', 'URIEL', 'RAMOS', '43524', 'CIERTO'),
('1121884776', 'FERNANDO', 'PARRADO', '123', 'CALLE38A'),
('1121884892', 'BRAYAN ', 'HURTADO', '3138369712', 'CALLE 37'),
('1121920139', 'CARVAJAL', 'CARLOS', '3212467031', 'MANZANA'),
('12345', 'ABCD', 'XYZ', '0000', 'CALLE 15'),
('4124', 'ALVARO', 'MANZANO', '34444', 'CALLE 14');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamentos`
--

CREATE TABLE `departamentos` (
  `idDepartamento` int(11) NOT NULL,
  `nombreDepartamento` varchar(30) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `departamentos`
--

INSERT INTO `departamentos` (`idDepartamento`, `nombreDepartamento`) VALUES
(0, 'NINGUNO'),
(5, 'ANTIOQUIA'),
(8, 'ATLANTICO'),
(11, 'BOGOTA'),
(13, 'BOLIVAR'),
(15, 'BOYACA'),
(17, 'CALDAS'),
(18, 'CAQUETA'),
(19, 'CAUCA'),
(20, 'CESAR'),
(23, 'CORDOBA'),
(25, 'CUNDINAMARCA'),
(27, 'CHOCO'),
(41, 'HUILA'),
(44, 'LA GUAJIRA'),
(47, 'MAGDALENA'),
(50, 'META'),
(52, 'NARIÑO'),
(54, 'N. DE SANTANDER'),
(63, 'QUINDIO'),
(66, 'RISARALDA'),
(68, 'SANTANDER'),
(70, 'SUCRE'),
(73, 'TOLIMA'),
(76, 'VALLE DEL CAUCA'),
(81, 'ARAUCA'),
(85, 'CASANARE'),
(86, 'PUTUMAYO'),
(88, 'SAN ANDRES'),
(91, 'AMAZONAS'),
(94, 'GUAINIA'),
(95, 'GUAVIARE'),
(97, 'VAUPES'),
(99, 'VICHADA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalles_compras`
--

CREATE TABLE `detalles_compras` (
  `idDetalleCompra` int(11) NOT NULL,
  `idFacturaCompra` int(11) NOT NULL,
  `IdProductoMarca` varchar(15) COLLATE utf8_bin NOT NULL,
  `idTipoCantidad` varchar(15) COLLATE utf8_bin NOT NULL,
  `cantidad` float NOT NULL,
  `subtotal` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `detalles_compras`
--

INSERT INTO `detalles_compras` (`idDetalleCompra`, `idFacturaCompra`, `IdProductoMarca`, `idTipoCantidad`, `cantidad`, `subtotal`) VALUES
(0, 154, '214', '1', 4000, 8000000),
(2, 134, '214', '1', 10, 55000),
(4, 157, '123456', '1', 20, 10000),
(5, 157, '214', '1', 20, 10000),
(6, 158, '214', '1', 40, 20000),
(7, 158, '123456', '1', 35, 350),
(8, 158, '123456', '1', 20, 600),
(9, 159, '214', '1', 20, 90000),
(10, 162, '123456', '1', 20, 10000),
(11, 165, '123456', '1', 30, 150000),
(12, 166, '323', '1', 20, 10000),
(13, 166, '8548', '2', 30, 133320),
(14, 174, '123456', '1', 3, 30000),
(15, 175, '8548', '1', 20, 4000),
(16, 176, '214', '1', 2, 200),
(17, 177, '123456', '1', 5, 7500),
(18, 177, '214', '1', 3, 1800),
(19, 178, '123456', '1', 2, 1000),
(20, 179, '123456', '1', 2, 1000),
(21, 180, '123456', '1', 5, 7775),
(22, 181, '214', '1', 4, 5776),
(23, 182, '214', '1', 3, 4800),
(24, 183, '323', '2', 6, 4200),
(25, 184, '2535', '2', 6, 9000),
(28, 187, '123456', '1', 10, 6000),
(31, 188, '123456', '1', 30, 30000),
(33, 189, '123456', '1', 20, 120000),
(35, 192, '214', '1', 2, 9000),
(41, 194, '214', '1', 5, 25000),
(53, 194, '123456', '1', 5, 25000),
(55, 194, '052', '1', 5, 25000),
(56, 194, '052', '1', 2, 12400),
(57, 195, '015', '1', 10, 75000),
(58, 195, '016', '1', 3, 16200),
(59, 196, '987', '1', 10, 40000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalles_compras_insumos`
--

CREATE TABLE `detalles_compras_insumos` (
  `idDetalleCompraInsumo` int(11) NOT NULL,
  `idFacturaCompra` int(11) NOT NULL,
  `idInsumo` varchar(15) COLLATE utf8_bin NOT NULL,
  `cantidad` int(11) NOT NULL,
  `subtotal` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `detalles_compras_insumos`
--

INSERT INTO `detalles_compras_insumos` (`idDetalleCompraInsumo`, `idFacturaCompra`, `idInsumo`, `cantidad`, `subtotal`) VALUES
(268, 118, '1103', 1, 7000),
(269, 118, '1108', 10, 5000),
(270, 119, '1105', 2, 400),
(271, 119, '1103', 3, 21000),
(272, 119, '1105', 3, 600),
(273, 120, '1103', 2, 14000),
(274, 120, '1104', 2, 3700.64),
(275, 121, '1109', 3, 24000),
(276, 121, '1110', 6, 4800),
(277, 122, '1102', 3, 3900),
(278, 122, '1105', 2, 400),
(279, 123, '1102', 2, 2600),
(280, 123, '1104', 3, 5550.96),
(281, 123, '1107', 3, 3000),
(321, 129, '1101', 10, 20000),
(322, 129, '1102', 10, 13000),
(323, 129, '1103', 10, 70000),
(324, 129, '1104', 10, 18503.2),
(325, 129, '1106', 10, 8000),
(326, 130, '1110', 10, 8000),
(327, 130, '1109', 10, 80000),
(328, 130, '1108', 10, 5000),
(329, 130, '1107', 10, 10000),
(330, 130, '1106', 10, 5000),
(331, 131, '1105', 10, 2000),
(332, 131, '1106', 10, 8000),
(333, 131, '1107', 10, 10000),
(334, 132, '1104', 1000, 1850320),
(335, 135, '1102', 3, 3900),
(336, 135, '1104', 3, 5550.96),
(337, 135, '1106', 1, 800),
(338, 135, '1107', 3, 3000),
(339, 135, '1110', 21, 16800),
(340, 136, '1103', 1, 7000),
(341, 137, '1102', 1, 1300),
(342, 137, '1103', 1, 7000),
(343, 138, '34', 1, 1200),
(344, 139, '34', 1, 1200),
(345, 140, '34', 1, 1200),
(346, 141, '34', 1, 1200),
(347, 142, '34', 1, 1200),
(348, 143, '34', 1, 1200),
(349, 144, '34', 1, 1200),
(353, 147, '1102', 1, 1300),
(354, 147, '1104', 1, 1850.32),
(357, 146, '1102', 100, 130000),
(358, 146, '1105', 20, 4000),
(359, 149, '1104', 3, 5550.96),
(360, 150, '1110', 10, 8000),
(361, 151, '1104', 10, 18503.2),
(362, 152, '1103', 10, 70000),
(363, 153, '1105', 20, 4000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalles_recetas`
--

CREATE TABLE `detalles_recetas` (
  `idDetalleReceta` int(11) NOT NULL,
  `idReceta` varchar(15) COLLATE utf8_bin NOT NULL,
  `idInsumo` varchar(15) COLLATE utf8_bin NOT NULL,
  `idTipoCantidad` varchar(15) COLLATE utf8_bin NOT NULL,
  `cantidadInsumoUtilizado` varchar(30) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `detalles_recetas`
--

INSERT INTO `detalles_recetas` (`idDetalleReceta`, `idReceta`, `idInsumo`, `idTipoCantidad`, `cantidadInsumoUtilizado`) VALUES
(2, '9999', '1106', '2', '9999'),
(3, '9999', '1107', '2', '9999'),
(4, '9999', '1103', '2', '9999'),
(5, '888', '1102', '2', '888'),
(6, '888', '1108', '2', '888'),
(7, '888', '1105', '2', '888'),
(8, '32', '1103', '2', '32'),
(9, '32', '1107', '2', '32'),
(10, '32', '1105', '2', '32'),
(11, '32', '1101', '2', '32'),
(14, '77', '1102', '2', '608'),
(15, '77', '1104', '1', '32'),
(16, '77', '1105', '2', '297'),
(17, '2222', '1101', '2', '230'),
(18, '2222', '1102', '2', '123'),
(19, '2222', '1104', '1', '478'),
(20, '2222', '1107', '2', '123'),
(21, '2222', '1103', '2', '745'),
(25, '21', '1105', '2', '200'),
(26, '21', '1108', '2', '200');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalles_ventas`
--

CREATE TABLE `detalles_ventas` (
  `idDetalleVenta` int(11) NOT NULL,
  `idFacturaVenta` int(11) NOT NULL,
  `idProductoMarca` varchar(15) COLLATE utf8_bin NOT NULL,
  `cantidad` int(11) NOT NULL,
  `subtotal` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `detalles_ventas`
--

INSERT INTO `detalles_ventas` (`idDetalleVenta`, `idFacturaVenta`, `idProductoMarca`, `cantidad`, `subtotal`) VALUES
(1, 24, '214', 2, 10000),
(2, 24, '2535', 2, 12000),
(3, 25, '8548', 1, 6000),
(4, 25, '123456', 10, 240),
(5, 27, '214', 2, 10000),
(6, 30, '8548', 1, 6000),
(7, 30, '214', 10, 50000),
(8, 31, '3202', 2, 3000),
(9, 36, '8548', 1, 6000),
(10, 40, '3202', 3, 4500),
(11, 50, '214', 10, 50000),
(12, 51, '123456', 100, 2300),
(13, 51, '8548', 2, 12000),
(14, 53, '214', 2, 10000),
(15, 53, '3202', 1, 1500),
(16, 54, '123456', 10, 240),
(17, 54, '214', 2, 10000),
(18, 54, '3202', 1, 1500),
(19, 57, '123456', 5, 120),
(20, 57, '214', 2, 10000),
(21, 57, '3202', 1, 1500),
(22, 58, '123456', 5, 120),
(23, 58, '214', 2, 10000),
(24, 58, '3202', 1, 1500),
(25, 60, '123456', 5, 120),
(26, 60, '214', 2, 10000),
(27, 60, '3202', 1, 1500),
(28, 61, '3202', 1, 1500),
(29, 62, '123456', 2, 48),
(30, 63, '8548', 3, 18000),
(31, 64, '8548', 1, 6000),
(32, 65, '8548', 1, 6000),
(33, 66, '8548', 1, 6000),
(34, 67, '8548', 1, 6000),
(35, 68, '8548', 1, 6000),
(36, 69, '8548', 2, 12000),
(37, 70, '8548', 1, 6000),
(38, 71, '8548', 1, 6000),
(39, 72, '8548', 1, 6000),
(40, 73, '323', 1, 24),
(41, 74, '3202', 1, 1500),
(42, 76, '8548', 1, 6000),
(43, 77, '8548', 1, 6000),
(44, 78, '8548', 1, 6000),
(45, 79, '323', 1, 24),
(46, 80, '214', 1000, 4000000),
(47, 81, '8548', 3, 18000),
(48, 81, '8548', 3, 18000),
(49, 83, '8548', 3, 18000),
(50, 84, '8548', 3, 18000),
(51, 85, '8548', 1, 6000),
(52, 86, '8548', 2, 12000),
(53, 86, '052', 1, 400);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `dias`
--

CREATE TABLE `dias` (
  `idDia` varchar(6) COLLATE utf8_bin NOT NULL,
  `nombreDia` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `dias`
--

INSERT INTO `dias` (`idDia`, `nombreDia`) VALUES
('0', 'NINGUNO'),
('1', 'LUNES'),
('2', 'MARTES'),
('3', 'MIERCOLES'),
('4', 'JUEVES'),
('5', 'VIERNES'),
('6', 'SABADO'),
('7', 'DOMINGO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `facturas_de_compras`
--

CREATE TABLE `facturas_de_compras` (
  `idFacturaCompra` int(11) NOT NULL,
  `idProveedor` varchar(15) COLLATE utf8_bin NOT NULL,
  `idTipoCompra` varchar(15) COLLATE utf8_bin NOT NULL,
  `fechaCompra` date NOT NULL,
  `valorTotal` float NOT NULL,
  `idBodega` varchar(20) COLLATE utf8_bin NOT NULL,
  `estadoMercancia` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `facturas_de_compras`
--

INSERT INTO `facturas_de_compras` (`idFacturaCompra`, `idProveedor`, `idTipoCompra`, `fechaCompra`, `valorTotal`, `idBodega`, `estadoMercancia`) VALUES
(0, '22052', '2', '2018-09-12', 2000, '1', 'RECIBIDO'),
(118, '22052', '1', '2018-08-23', 12000, '2', 'RECIBIDO'),
(119, '31032', '1', '2018-08-23', 22000, '2', 'RECIBIDO'),
(120, '22052', '1', '2018-08-23', 17700.6, '2', 'RECIBIDO'),
(121, '22052', '1', '2018-08-23', 28800, '2', 'RECIBIDO'),
(122, '22052', '1', '2018-08-23', 4300, '2', 'RECIBIDO'),
(123, '31032', '1', '2018-08-23', 11151, '2', 'RECIBIDO'),
(129, '22052', '1', '2018-09-05', 129503, '2', 'RECIBIDO'),
(130, '22052', '1', '2018-09-05', 108000, '2', 'RECIBIDO'),
(131, '31032', '1', '2018-09-05', 20000, '2', 'RECIBIDO'),
(132, '22052', '1', '2018-09-08', 1850320, '2', 'RECIBIDO'),
(133, '22052', '2', '2018-09-10', 234, '1', 'compra'),
(134, '22052', '1', '2018-09-11', 5500, '1', 'compra'),
(135, '31032', '1', '2018-09-11', 30051, '2', 'RECIBIDO'),
(136, '31032', '1', '2018-09-11', 7000, '2', 'RECIBIDO'),
(137, '31032', '1', '2018-09-12', 8300, '2', 'RECIBIDO'),
(138, '22052', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(139, '22052', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(140, '31032', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(141, '22052', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(142, '31032', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(143, '22052', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(144, '22052', '1', '2018-09-12', 1200, '2', 'RECIBIDO'),
(146, '22052', '1', '2018-09-13', 134000, '2', 'SIN RECIBIR'),
(147, '22052', '1', '2018-09-14', 3150.32, '2', 'RECIBIDO'),
(149, '31032', '3', '2018-09-16', 5550.96, '2', 'RECIBIDO'),
(150, '22052', '1', '2018-09-16', 8000, '2', 'SIN RECIBIR'),
(151, '45789', '1', '2018-09-16', 18503.2, '2', 'SIN RECIBIR'),
(152, '31032', '1', '2018-09-16', 70000, '2', 'RECIBIDO'),
(153, '31032', '1', '2018-09-16', 4000, '2', 'RECIBIDO'),
(154, '31032', '1', '2018-09-17', 0, '2', 'RECIBIDO'),
(156, '22052', '1', '2018-09-23', 50, '1', 'compra'),
(157, '22052', '1', '2018-09-23', 500, '1', 'compra'),
(158, '22052', '1', '2018-09-23', 500, '1', 'compra'),
(159, '31032', '1', '2018-09-23', 4500, '1', 'compra'),
(161, '22052', '1', '2018-09-23', 1500, '1', 'compra'),
(162, '22052', '2', '2018-09-24', 500, '1', 'compra'),
(163, '22052', '1', '2018-09-24', 500, '1', 'compra'),
(164, '22052', '1', '2018-09-24', 50, '1', 'compra'),
(165, '45789', '1', '2018-09-24', 5000, '1', 'compra'),
(166, '31032', '2', '2018-09-24', 500, '1', 'compra'),
(169, '22052', '1', '2018-09-28', 50000, '2', 'RECIBIDO'),
(170, '22052', '1', '2018-09-28', 50000, '2', 'RECIBIDO'),
(171, '22052', '1', '2018-09-28', 50000, '2', 'RECIBIDO'),
(172, '22052', '1', '2018-09-28', 50000, '2', 'RECIBIDO'),
(173, '22052', '1', '2018-09-28', 50000, '2', 'RECIBIDO'),
(174, '22052', '1', '2018-10-03', 10000, '1', 'compra'),
(175, '31032', '1', '2018-10-06', 200, '1', 'compra'),
(176, '22052', '1', '2018-10-06', 100, '1', 'compra'),
(177, '22052', '1', '2018-10-06', 1500, '1', 'compra'),
(178, '22052', '1', '2018-10-06', 500, '1', 'compra'),
(179, '22052', '1', '2018-10-07', 500, '1', 'compra'),
(180, '22052', '1', '2018-10-07', 1555, '1', 'compra'),
(181, '22052', '1', '2018-10-07', 1444, '1', 'compra'),
(182, '31032', '1', '2018-10-07', 1600, '1', 'compra'),
(183, '45789', '1', '2018-10-07', 700, '1', 'compra'),
(184, '31032', '1', '2018-10-07', 1500, '1', 'compra'),
(185, 'ABC123', '1', '2018-10-07', 1000, '1', 'compra'),
(186, 'ABC123', '1', '2018-10-07', 1000, '1', 'compra'),
(187, '22052', '1', '2018-10-07', 600, '1', 'compra'),
(188, '22052', '1', '2018-10-07', 1000, '1', 'compra'),
(189, '22052', '1', '2018-10-07', 6000, '1', 'compra'),
(190, '22052', '1', '2018-10-07', 4000, '1', 'compra'),
(191, '22052', '1', '2018-10-15', 10000, '1', 'compra'),
(192, '22052', '1', '2018-10-15', 4500, '1', 'compra'),
(193, '22052', '1', '2018-10-15', 5000, '1', 'compra'),
(194, '22052', '1', '2018-10-15', 5000, '1', 'compra'),
(195, '31032', '1', '2018-10-15', 7500, '1', 'compra'),
(196, '45789', '1', '2018-10-15', 4000, '1', 'compra');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `factura_ventas`
--

CREATE TABLE `factura_ventas` (
  `idFacturaVenta` int(11) NOT NULL,
  `idCliente` varchar(15) COLLATE utf8_bin NOT NULL,
  `IdVendedor` varchar(15) COLLATE utf8_bin NOT NULL,
  `idTipoDePago` varchar(15) COLLATE utf8_bin NOT NULL,
  `fechaVenta` datetime NOT NULL,
  `valorVenta` float NOT NULL,
  `observaciones` text COLLATE utf8_bin
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `factura_ventas`
--

INSERT INTO `factura_ventas` (`idFacturaVenta`, `idCliente`, `IdVendedor`, `idTipoDePago`, `fechaVenta`, `valorVenta`, `observaciones`) VALUES
(3, '4124', '1', '1', '2018-09-12 00:00:00', 10000, NULL),
(4, '4124', '1', '1', '2018-09-12 00:00:00', 10000, NULL),
(6, '4124', '1', '1', '2018-09-12 00:00:00', 24, NULL),
(7, '4124', '1', '1', '2018-09-13 00:00:00', 10460, NULL),
(9, '4124', '1', '1', '2018-09-13 00:00:00', 240, NULL),
(10, '4124', '1', '1', '2018-09-13 00:00:00', 10, NULL),
(11, '4124', '1', '1', '2018-09-13 00:00:00', 21, NULL),
(12, '4124', '1', '1', '2018-09-13 00:00:00', 21, NULL),
(13, '4124', '1', '1', '2018-09-13 00:00:00', 30, NULL),
(14, '4124', '1', '1', '2018-09-13 00:00:00', 20, NULL),
(15, '4124', '1', '1', '2018-09-13 00:00:00', 20, NULL),
(16, '4124', '1', '1', '2018-09-13 00:00:00', 10, NULL),
(17, '4124', '1', '1', '2018-09-13 00:00:00', 21, NULL),
(18, '4124', '1', '1', '2018-09-14 00:00:00', 20, NULL),
(19, '4124', '1', '1', '2018-09-14 00:00:00', 10, NULL),
(20, '4124', '1', '1', '2018-09-14 00:00:00', 20, NULL),
(21, '4124', '1', '1', '2018-09-14 00:00:00', 12000, NULL),
(22, '4124', '1', '1', '2018-09-14 00:00:00', 10000, NULL),
(23, '4124', '1', '1', '2018-09-14 00:00:00', 12000, NULL),
(24, '4124', '1', '1', '2018-09-14 00:00:00', 22000, NULL),
(25, '4124', '1', '1', '2018-09-14 00:00:00', 6240, NULL),
(27, '4124', '1', '1', '2018-09-15 00:00:00', 10000, NULL),
(28, '4124', '2', '1', '2018-09-15 00:00:00', 6000, NULL),
(29, '4124', '1', '1', '2018-09-23 00:00:00', 1500, NULL),
(30, '4124', '1', '1', '2018-09-23 00:00:00', 56000, NULL),
(31, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(32, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(33, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(34, '4124', '1', '1', '2018-09-23 00:00:00', 10000, NULL),
(35, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(36, '4124', '1', '1', '2018-09-23 00:00:00', 6000, NULL),
(37, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(38, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(39, '4124', '1', '1', '2018-09-23 00:00:00', 240, NULL),
(40, '4124', '1', '1', '2018-09-23 00:00:00', 4500, NULL),
(41, '4124', '1', '1', '2018-09-23 00:00:00', 6000, NULL),
(42, '4124', '1', '1', '2018-09-23 00:00:00', 10000, NULL),
(43, '4124', '1', '1', '2018-09-23 00:00:00', 4500, NULL),
(44, '4124', '1', '1', '2018-09-23 00:00:00', 10000, NULL),
(45, '4124', '1', '1', '2018-09-23 00:00:00', 3000, NULL),
(46, '4124', '1', '1', '2018-09-23 00:00:00', 50000, NULL),
(47, '4124', '1', '1', '2018-09-23 00:00:00', 50000, NULL),
(48, '4124', '1', '1', '2018-09-23 00:00:00', 50000, NULL),
(49, '4124', '1', '1', '2018-09-23 00:00:00', 50000, NULL),
(50, '4124', '1', '1', '2018-09-23 00:00:00', 62000, NULL),
(51, '4124', '1', '1', '2018-09-23 00:00:00', 14300, NULL),
(52, '4124', '1', '1', '2018-09-23 00:00:00', 11500, NULL),
(53, '4124', '1', '1', '2018-09-23 00:00:00', 11500, NULL),
(54, '4124', '1', '1', '2018-09-23 00:00:00', 11740, NULL),
(55, '4124', '1', '1', '2018-09-23 00:00:00', 11620, NULL),
(56, '4124', '1', '1', '2018-09-23 00:00:00', 11620, NULL),
(57, '4124', '1', '1', '2018-09-23 00:00:00', 11620, NULL),
(58, '4124', '1', '1', '2018-09-23 00:00:00', 11620, NULL),
(59, '4124', '1', '1', '2018-09-23 00:00:00', 11620, NULL),
(60, '4124', '1', '1', '2018-09-23 00:00:00', 11620, NULL),
(61, '4124', '1', '1', '2018-09-23 00:00:00', 1500, NULL),
(62, '4124', '1', '1', '2018-10-03 00:00:00', 48, NULL),
(63, '1121884776', '1', '1', '2018-10-03 00:00:00', 18000, NULL),
(64, '4124', '1', '1', '2018-10-03 00:00:00', 6000, NULL),
(65, '4124', '1', '1', '2018-10-03 00:00:00', 6000, NULL),
(66, '4124', '1', '1', '2018-10-04 00:00:00', 6000, NULL),
(67, '4124', '1', '1', '2018-10-04 00:00:00', 6000, NULL),
(68, '4124', '1', '1', '2018-10-05 00:00:00', 6000, NULL),
(69, '4124', '1', '1', '2018-10-06 00:00:00', 12000, NULL),
(70, '4124', '1', '1', '2018-10-06 00:00:00', 6000, ''),
(71, '4124', '1', '1', '2018-10-06 00:00:00', 6000, ''),
(72, '4124', '1', '1', '2018-10-06 00:00:00', 6000, ''),
(73, '4124', '1', '1', '2018-10-06 00:00:00', 24, ''),
(74, '4124', '1', '1', '2018-10-06 00:00:00', 1500, 'para aca\n		'),
(75, '4124', '1', '1', '2018-10-06 00:00:00', 6000, 'PARA LLEVAR'),
(76, '4124', '1', '1', '2018-10-06 00:00:00', 6000, ''),
(77, '4124', '1', '1', '2018-10-06 00:00:00', 6000, ''),
(78, '4124', '1', '1', '2018-10-06 00:00:00', 6000, ''),
(79, '4124', '1', '1', '2018-10-06 00:00:00', 24, ''),
(80, '4124', '1', '1', '2018-10-07 00:00:00', 4000000, ''),
(81, '1121884776', '1', '1', '2018-10-12 00:00:00', 18000, 'SDS'),
(82, '1121884776', '1', '1', '2018-10-12 00:00:00', 18000, 'SDS'),
(83, '1121884776', '1', '1', '2018-10-12 00:00:00', 18000, 'GOOGO'),
(84, '1121884776', '1', '1', '2018-10-12 00:00:00', 18000, 'DSD'),
(85, '4124', '1', '1', '2018-10-15 00:00:00', 6000, ''),
(86, '1121884892', '1', '1', '2018-10-15 00:00:00', 12400, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `guardar_facturas`
--

CREATE TABLE `guardar_facturas` (
  `idFacturaGuardada` varchar(20) COLLATE utf8_bin NOT NULL,
  `idCliente` varchar(15) COLLATE utf8_bin NOT NULL,
  `IdVendedor` varchar(15) COLLATE utf8_bin NOT NULL,
  `idTipoDePago` varchar(15) COLLATE utf8_bin NOT NULL,
  `fechaVenta` datetime NOT NULL,
  `valorVenta` float NOT NULL,
  `EnUso` varchar(6) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `guardar_facturas`
--

INSERT INTO `guardar_facturas` (`idFacturaGuardada`, `idCliente`, `IdVendedor`, `idTipoDePago`, `fechaVenta`, `valorVenta`, `EnUso`) VALUES
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI'),
('100', '4124', '1', '1', '2018-09-28 00:00:00', 50000, 'SI');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `insumos`
--

CREATE TABLE `insumos` (
  `idInsumo` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreInsumo` varchar(50) COLLATE utf8_bin NOT NULL,
  `costoInsumo` float NOT NULL,
  `cantidadInsumo` int(11) DEFAULT NULL,
  `cantidadMinimaInsumo` float DEFAULT NULL,
  `idTipoCantidad` varchar(15) COLLATE utf8_bin NOT NULL,
  `facturarInsumo` varchar(2) COLLATE utf8_bin NOT NULL,
  `descripcionInsumo` varchar(200) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `insumos`
--

INSERT INTO `insumos` (`idInsumo`, `nombreInsumo`, `costoInsumo`, `cantidadInsumo`, `cantidadMinimaInsumo`, `idTipoCantidad`, `facturarInsumo`, `descripcionInsumo`) VALUES
('0101', 'Arracachita', 1000, 2, 0, '1', 'SI', ''),
('1101', 'SALSA DE TOMATE', 2000, 200, 5, '2', 'NO', ''),
('1102', 'SAL', 1300, 631, 2000, '2', 'SI', 'SALas'),
('1103', 'CARNE', 7000, 18, 2000, '2', 'SI', 'CARNE'),
('1104', 'Leche', 1850.32, 614, 2, '1', 'NO', ''),
('1105', 'TOMATE', 200, 107, 2000, '2', 'SI', 'TOMATE'),
('1106', 'PEP', 800, 2041, 2000, '2', 'SI', 'PEPIN'),
('1107', 'CEBOLLA ', 1000, 589, 2000, '2', 'SI', 'CEBOLLA'),
('1108', 'AZUCAR', 500, 2055, 2000, '2', 'SI', 'AZUCAR'),
('1109', 'AJO', 8000, 24020, 2000, '2', 'SI', 'AJO'),
('1110', 'MASA', 800, 2136, 2000, '1', 'SI', 'MASA'),
('1111', 'TOMATE', 500, 0, 2, '1', '', 'TOMATE'),
('12345', 'AREPA YUCA ', 2000, 15, 0, '2', 'NO', 'SDFSSSDF'),
('34', 'Arroz', 1200, 34, 0, '1', 'NO', ''),
('6666', 'Apio', 200, 5, 2, '1', '', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `municipios`
--

CREATE TABLE `municipios` (
  `idMunicipio` varchar(20) COLLATE utf8_bin NOT NULL,
  `idDepartamento` int(11) NOT NULL,
  `nombreMunicipio` varchar(30) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `municipios`
--

INSERT INTO `municipios` (`idMunicipio`, `idDepartamento`, `nombreMunicipio`) VALUES
('0', 0, 'NINGUNO'),
('1', 5, 'MEDELLIN'),
('10', 5, 'ANORI'),
('100', 5, 'SAN VICENTE'),
('1000', 73, 'VALLE DE SAN JUAN'),
('1001', 73, 'VENADILLO'),
('1002', 73, 'VILLAHERMOSA'),
('1003', 73, 'VILLARRICA'),
('1004', 76, 'CALI'),
('1005', 76, 'ALCALA'),
('1006', 76, 'ANDALUCIA'),
('1007', 76, 'ANSERMANUEVO'),
('1008', 76, 'ARGELIA'),
('1009', 76, 'BOLIVAR'),
('101', 5, 'SANTA BARBARA'),
('1010', 76, 'BUENAVENTURA'),
('1011', 76, 'GUADALAJARA DE BUGA'),
('1012', 76, 'BUGALAGRANDE'),
('1013', 76, 'CAICEDONIA'),
('1014', 76, 'CALIMA'),
('1015', 76, 'CANDELARIA'),
('1016', 76, 'CARTAGO'),
('1017', 76, 'DAGUA'),
('1018', 76, 'EL AGUILA'),
('1019', 76, 'EL CAIRO'),
('102', 5, 'SANTA ROSA DE OSOS'),
('1020', 76, 'EL CERRITO'),
('1021', 76, 'EL DOVIO'),
('1022', 76, 'FLORIDA'),
('1023', 76, 'GINEBRA'),
('1024', 76, 'GUACARI'),
('1025', 76, 'JAMUNDI'),
('1026', 76, 'LA CUMBRE'),
('1027', 76, 'LA UNION'),
('1028', 76, 'LA VICTORIA'),
('1029', 76, 'OBANDO'),
('103', 5, 'SANTO DOMINGO'),
('1030', 76, 'PALMIRA'),
('1031', 76, 'PRADERA'),
('1032', 76, 'RESTREPO'),
('1033', 76, 'RIOFRIO'),
('1034', 76, 'ROLDANILLO'),
('1035', 76, 'SAN PEDRO'),
('1036', 76, 'SEVILLA'),
('1037', 76, 'TORO'),
('1038', 76, 'TRUJILLO'),
('1039', 76, 'TULUA'),
('104', 5, 'EL SANTUARIO'),
('1040', 76, 'ULLOA'),
('1041', 76, 'VERSALLES'),
('1042', 76, 'VIJES'),
('1043', 76, 'YOTOCO'),
('1044', 76, 'YUMBO'),
('1045', 76, 'ZARZAL'),
('1046', 81, 'ARAUCA'),
('1047', 81, 'ARAUQUITA'),
('1048', 81, 'CRAVO NORTE'),
('1049', 81, 'FORTUL'),
('105', 5, 'SEGOVIA'),
('1050', 81, 'PUERTO RONDON'),
('1051', 81, 'SARAVENA'),
('1052', 81, 'TAME'),
('1053', 85, 'YOPAL'),
('1054', 85, 'AGUAZUL'),
('1055', 85, 'CHAMEZA'),
('1056', 85, 'HATO COROZAL'),
('1057', 85, 'LA SALINA'),
('1058', 85, 'MANI'),
('1059', 85, 'MONTERREY'),
('106', 5, 'SONSON'),
('1060', 85, 'NUNCHIA'),
('1061', 85, 'OROCUE'),
('1062', 85, 'PAZ DE ARIPORO'),
('1063', 85, 'PORE'),
('1064', 85, 'RECETOR'),
('1065', 85, 'SABANALARGA'),
('1066', 85, 'SACAMA'),
('1067', 85, 'SAN LUIS DE PALENQUE'),
('1068', 85, 'TAMARA'),
('1069', 85, 'TAURAMENA'),
('107', 5, 'SOPETRAN'),
('1070', 85, 'TRINIDAD'),
('1071', 85, 'VILLANUEVA'),
('1072', 86, 'MOCOA'),
('1073', 86, 'COLON'),
('1074', 86, 'ORITO'),
('1075', 86, 'PUERTO ASIS'),
('1076', 86, 'PUERTO CAICEDO'),
('1077', 86, 'PUERTO GUZMAN'),
('1078', 86, 'LEGUIZAMO'),
('1079', 86, 'SIBUNDOY'),
('108', 5, 'TAMESIS'),
('1080', 86, 'SAN FRANCISCO'),
('1081', 86, 'SAN MIGUEL'),
('1082', 86, 'SANTIAGO'),
('1083', 86, 'VALLE DEL GUAMUEZ'),
('1084', 86, 'VILLAGARZON'),
('1085', 88, 'SAN ANDRES'),
('1086', 88, 'PROVIDENCIA'),
('1087', 91, 'LETICIA'),
('1088', 91, 'EL ENCANTO'),
('1089', 91, 'LA CHORRERA'),
('109', 5, 'TARAZA'),
('1090', 91, 'LA PEDRERA'),
('1091', 91, 'LA VICTORIA'),
('1092', 91, 'MIRITI - PARANA'),
('1093', 91, 'PUERTO ALEGRIA'),
('1094', 91, 'PUERTO ARICA'),
('1095', 91, 'PUERTO NARI?O'),
('1096', 91, 'PUERTO SANTANDER'),
('1097', 91, 'TARAPACA'),
('1098', 94, 'INIRIDA'),
('1099', 94, 'BARRANCO MINAS'),
('11', 5, 'SANTAFE DE ANTIOQUIA'),
('110', 5, 'TARSO'),
('1100', 94, 'MAPIRIPANA'),
('1101', 94, 'SAN FELIPE'),
('1102', 94, 'PUERTO COLOMBIA'),
('1103', 94, 'LA GUADALUPE'),
('1104', 94, 'CACAHUAL'),
('1105', 94, 'PANA PANA'),
('1106', 94, 'MORICHAL'),
('1107', 95, 'SAN JOSE DEL GUAVIARE'),
('1108', 95, 'CALAMAR'),
('1109', 95, 'EL RETORNO'),
('111', 5, 'TITIRIBI'),
('1110', 95, 'MIRAFLORES'),
('1111', 97, 'MITU'),
('1112', 97, 'CARURU'),
('1113', 97, 'PACOA'),
('1114', 97, 'TARAIRA'),
('1115', 97, 'PAPUNAUA'),
('1116', 97, 'YAVARATE'),
('1117', 99, 'PUERTO CARRE?O'),
('1118', 99, 'LA PRIMAVERA'),
('1119', 99, 'SANTA ROSALIA'),
('112', 5, 'TOLEDO'),
('1120', 99, 'CUMARIBO'),
('113', 5, 'TURBO'),
('114', 5, 'URAMITA'),
('115', 5, 'URRAO'),
('116', 5, 'VALDIVIA'),
('117', 5, 'VALPARAISO'),
('118', 5, 'VEGACHI'),
('119', 5, 'VENECIA'),
('12', 5, 'ANZA'),
('120', 5, 'VIGIA DEL FUERTE'),
('121', 5, 'YALI'),
('122', 5, 'YARUMAL'),
('123', 5, 'YOLOMBO'),
('124', 5, 'YONDO'),
('125', 5, 'ZARAGOZA'),
('126', 8, 'BARRANQUILLA'),
('127', 8, 'BARANOA'),
('128', 8, 'CAMPO DE LA CRUZ'),
('129', 8, 'CANDELARIA'),
('13', 5, 'APARTADO'),
('130', 8, 'GALAPA'),
('131', 8, 'JUAN DE ACOSTA'),
('132', 8, 'LURUACO'),
('133', 8, 'MALAMBO'),
('134', 8, 'MANATI'),
('135', 8, 'PALMAR DE VARELA'),
('136', 8, 'PIOJO'),
('137', 8, 'POLONUEVO'),
('138', 8, 'PONEDERA'),
('139', 8, 'PUERTO COLOMBIA'),
('14', 5, 'ARBOLETES'),
('140', 8, 'REPELON'),
('141', 8, 'SABANAGRANDE'),
('142', 8, 'SABANALARGA'),
('143', 8, 'SANTA LUCIA'),
('144', 8, 'SANTO TOMAS'),
('145', 8, 'SOLEDAD'),
('146', 8, 'SUAN'),
('147', 8, 'TUBARA'),
('148', 8, 'USIACURI'),
('149', 11, 'BOGOTA, D.C.'),
('15', 5, 'ARGELIA'),
('150', 13, 'CARTAGENA'),
('151', 13, 'ACHI'),
('152', 13, 'ALTOS DEL ROSARIO'),
('153', 13, 'ARENAL'),
('154', 13, 'ARJONA'),
('155', 13, 'ARROYOHONDO'),
('156', 13, 'BARRANCO DE LOBA'),
('157', 13, 'CALAMAR'),
('158', 13, 'CANTAGALLO'),
('159', 13, 'CICUCO'),
('16', 5, 'ARMENIA'),
('160', 13, 'CORDOBA'),
('161', 13, 'CLEMENCIA'),
('162', 13, 'EL CARMEN DE BOLIVAR'),
('163', 13, 'EL GUAMO'),
('164', 13, 'EL PE?ON'),
('165', 13, 'HATILLO DE LOBA'),
('166', 13, 'MAGANGUE'),
('167', 13, 'MAHATES'),
('168', 13, 'MARGARITA'),
('169', 13, 'MARIA LA BAJA'),
('17', 5, 'BARBOSA'),
('170', 13, 'MONTECRISTO'),
('171', 13, 'MOMPOS'),
('172', 13, 'NOROSI'),
('173', 13, 'MORALES'),
('174', 13, 'PINILLOS'),
('175', 13, 'REGIDOR'),
('176', 13, 'RIO VIEJO'),
('177', 13, 'SAN CRISTOBAL'),
('178', 13, 'SAN ESTANISLAO'),
('179', 13, 'SAN FERNANDO'),
('18', 5, 'BELMIRA'),
('180', 13, 'SAN JACINTO'),
('181', 13, 'SAN JACINTO DEL CAUCA'),
('182', 13, 'SAN JUAN NEPOMUCENO'),
('183', 13, 'SAN MARTIN DE LOBA'),
('184', 13, 'SAN PABLO'),
('185', 13, 'SANTA CATALINA'),
('186', 13, 'SANTA ROSA'),
('187', 13, 'SANTA ROSA DEL SUR'),
('188', 13, 'SIMITI'),
('189', 13, 'SOPLAVIENTO'),
('19', 5, 'BELLO'),
('190', 13, 'TALAIGUA NUEVO'),
('191', 13, 'TIQUISIO'),
('192', 13, 'TURBACO'),
('193', 13, 'TURBANA'),
('194', 13, 'VILLANUEVA'),
('195', 13, 'ZAMBRANO'),
('196', 15, 'TUNJA'),
('197', 15, 'ALMEIDA'),
('198', 15, 'AQUITANIA'),
('199', 15, 'ARCABUCO'),
('2', 5, 'ABEJORRAL'),
('20', 5, 'BETANIA'),
('200', 15, 'BELEN'),
('201', 15, 'BERBEO'),
('202', 15, 'BETEITIVA'),
('203', 15, 'BOAVITA'),
('204', 15, 'BOYACA'),
('205', 15, 'BRICE?O'),
('206', 15, 'BUENAVISTA'),
('207', 15, 'BUSBANZA'),
('208', 15, 'CALDAS'),
('209', 15, 'CAMPOHERMOSO'),
('21', 5, 'BETULIA'),
('210', 15, 'CERINZA'),
('211', 15, 'CHINAVITA'),
('212', 15, 'CHIQUINQUIRA'),
('213', 15, 'CHISCAS'),
('214', 15, 'CHITA'),
('215', 15, 'CHITARAQUE'),
('216', 15, 'CHIVATA'),
('217', 15, 'CIENEGA'),
('218', 15, 'COMBITA'),
('219', 15, 'COPER'),
('22', 5, 'CIUDAD BOLIVAR'),
('220', 15, 'CORRALES'),
('221', 15, 'COVARACHIA'),
('222', 15, 'CUBARA'),
('223', 15, 'CUCAITA'),
('224', 15, 'CUITIVA'),
('225', 15, 'CHIQUIZA'),
('226', 15, 'CHIVOR'),
('227', 15, 'DUITAMA'),
('228', 15, 'EL COCUY'),
('229', 15, 'EL ESPINO'),
('23', 5, 'BRICE?O'),
('230', 15, 'FIRAVITOBA'),
('231', 15, 'FLORESTA'),
('232', 15, 'GACHANTIVA'),
('233', 15, 'GAMEZA'),
('234', 15, 'GARAGOA'),
('235', 15, 'GUACAMAYAS'),
('236', 15, 'GUATEQUE'),
('237', 15, 'GUAYATA'),
('238', 15, 'GsICAN'),
('239', 15, 'IZA'),
('24', 5, 'BURITICA'),
('240', 15, 'JENESANO'),
('241', 15, 'JERICO'),
('242', 15, 'LABRANZAGRANDE'),
('243', 15, 'LA CAPILLA'),
('244', 15, 'LA VICTORIA'),
('245', 15, 'LA UVITA'),
('246', 15, 'VILLA DE LEYVA'),
('247', 15, 'MACANAL'),
('248', 15, 'MARIPI'),
('249', 15, 'MIRAFLORES'),
('25', 5, 'CACERES'),
('250', 15, 'MONGUA'),
('251', 15, 'MONGUI'),
('252', 15, 'MONIQUIRA'),
('253', 15, 'MOTAVITA'),
('254', 15, 'MUZO'),
('255', 15, 'NOBSA'),
('256', 15, 'NUEVO COLON'),
('257', 15, 'OICATA'),
('258', 15, 'OTANCHE'),
('259', 15, 'PACHAVITA'),
('26', 5, 'CAICEDO'),
('260', 15, 'PAEZ'),
('261', 15, 'PAIPA'),
('262', 15, 'PAJARITO'),
('263', 15, 'PANQUEBA'),
('264', 15, 'PAUNA'),
('265', 15, 'PAYA'),
('266', 15, 'PAZ DE RIO'),
('267', 15, 'PESCA'),
('268', 15, 'PISBA'),
('269', 15, 'PUERTO BOYACA'),
('27', 5, 'CALDAS'),
('270', 15, 'QUIPAMA'),
('271', 15, 'RAMIRIQUI'),
('272', 15, 'RAQUIRA'),
('273', 15, 'RONDON'),
('274', 15, 'SABOYA'),
('275', 15, 'SACHICA'),
('276', 15, 'SAMACA'),
('277', 15, 'SAN EDUARDO'),
('278', 15, 'SAN JOSE DE PARE'),
('279', 15, 'SAN LUIS DE GACENO'),
('28', 5, 'CAMPAMENTO'),
('280', 15, 'SAN MATEO'),
('281', 15, 'SAN MIGUEL DE SEMA'),
('282', 15, 'SAN PABLO DE BORBUR'),
('283', 15, 'SANTANA'),
('284', 15, 'SANTA MARIA'),
('285', 15, 'SANTA ROSA DE VITERBO'),
('286', 15, 'SANTA SOFIA'),
('287', 15, 'SATIVANORTE'),
('288', 15, 'SATIVASUR'),
('289', 15, 'SIACHOQUE'),
('29', 5, 'CA?ASGORDAS'),
('290', 15, 'SOATA'),
('291', 15, 'SOCOTA'),
('292', 15, 'SOCHA'),
('293', 15, 'SOGAMOSO'),
('294', 15, 'SOMONDOCO'),
('295', 15, 'SORA'),
('296', 15, 'SOTAQUIRA'),
('297', 15, 'SORACA'),
('298', 15, 'SUSACON'),
('299', 15, 'SUTAMARCHAN'),
('3', 5, 'ABRIAQUI'),
('30', 5, 'CARACOLI'),
('300', 15, 'SUTATENZA'),
('301', 15, 'TASCO'),
('302', 15, 'TENZA'),
('303', 15, 'TIBANA'),
('304', 15, 'TIBASOSA'),
('305', 15, 'TINJACA'),
('306', 15, 'TIPACOQUE'),
('307', 15, 'TOCA'),
('308', 15, 'TOGsI'),
('309', 15, 'TOPAGA'),
('31', 5, 'CARAMANTA'),
('310', 15, 'TOTA'),
('311', 15, 'TUNUNGUA'),
('312', 15, 'TURMEQUE'),
('313', 15, 'TUTA'),
('314', 15, 'TUTAZA'),
('315', 15, 'UMBITA'),
('316', 15, 'VENTAQUEMADA'),
('317', 15, 'VIRACACHA'),
('318', 15, 'ZETAQUIRA'),
('319', 17, 'MANIZALES'),
('32', 5, 'CAREPA'),
('320', 17, 'AGUADAS'),
('321', 17, 'ANSERMA'),
('322', 17, 'ARANZAZU'),
('323', 17, 'BELALCAZAR'),
('324', 17, 'CHINCHINA'),
('325', 17, 'FILADELFIA'),
('326', 17, 'LA DORADA'),
('327', 17, 'LA MERCED'),
('328', 17, 'MANZANARES'),
('329', 17, 'MARMATO'),
('33', 5, 'EL CARMEN DE VIBORAL'),
('330', 17, 'MARQUETALIA'),
('331', 17, 'MARULANDA'),
('332', 17, 'NEIRA'),
('333', 17, 'NORCASIA'),
('334', 17, 'PACORA'),
('335', 17, 'PALESTINA'),
('336', 17, 'PENSILVANIA'),
('337', 17, 'RIOSUCIO'),
('338', 17, 'RISARALDA'),
('339', 17, 'SALAMINA'),
('34', 5, 'CAROLINA'),
('340', 17, 'SAMANA'),
('341', 17, 'SAN JOSE'),
('342', 17, 'SUPIA'),
('343', 17, 'VICTORIA'),
('344', 17, 'VILLAMARIA'),
('345', 17, 'VITERBO'),
('346', 18, 'FLORENCIA'),
('347', 18, 'ALBANIA'),
('348', 18, 'BELEN DE LOS ANDAQUIES'),
('349', 18, 'CARTAGENA DEL CHAIRA'),
('35', 5, 'CAUCASIA'),
('350', 18, 'CURILLO'),
('351', 18, 'EL DONCELLO'),
('352', 18, 'EL PAUJIL'),
('353', 18, 'LA MONTA?ITA'),
('354', 18, 'MILAN'),
('355', 18, 'MORELIA'),
('356', 18, 'PUERTO RICO'),
('357', 18, 'SAN JOSE DEL FRAGUA'),
('358', 18, 'SAN VICENTE DEL CAGUAN'),
('359', 18, 'SOLANO'),
('36', 5, 'CHIGORODO'),
('360', 18, 'SOLITA'),
('361', 18, 'VALPARAISO'),
('362', 19, 'POPAYAN'),
('363', 19, 'ALMAGUER'),
('364', 19, 'ARGELIA'),
('365', 19, 'BALBOA'),
('366', 19, 'BOLIVAR'),
('367', 19, 'BUENOS AIRES'),
('368', 19, 'CAJIBIO'),
('369', 19, 'CALDONO'),
('37', 5, 'CISNEROS'),
('370', 19, 'CALOTO'),
('371', 19, 'CORINTO'),
('372', 19, 'EL TAMBO'),
('373', 19, 'FLORENCIA'),
('374', 19, 'GUACHENE'),
('375', 19, 'GUAPI'),
('376', 19, 'INZA'),
('377', 19, 'JAMBALO'),
('378', 19, 'LA SIERRA'),
('379', 19, 'LA VEGA'),
('38', 5, 'COCORNA'),
('380', 19, 'LOPEZ'),
('381', 19, 'MERCADERES'),
('382', 19, 'MIRANDA'),
('383', 19, 'MORALES'),
('384', 19, 'PADILLA'),
('385', 19, 'PAEZ'),
('386', 19, 'PATIA'),
('387', 19, 'PIAMONTE'),
('388', 19, 'PIENDAMO'),
('389', 19, 'PUERTO TEJADA'),
('39', 5, 'CONCEPCION'),
('390', 19, 'PURACE'),
('391', 19, 'ROSAS'),
('392', 19, 'SAN SEBASTIAN'),
('393', 19, 'SANTANDER DE QUILICHAO'),
('394', 19, 'SANTA ROSA'),
('395', 19, 'SILVIA'),
('396', 19, 'SOTARA'),
('397', 19, 'SUAREZ'),
('398', 19, 'SUCRE'),
('399', 19, 'TIMBIO'),
('4', 5, 'ALEJANDRIA'),
('40', 5, 'CONCORDIA'),
('400', 19, 'TIMBIQUI'),
('401', 19, 'TORIBIO'),
('402', 19, 'TOTORO'),
('403', 19, 'VILLA RICA'),
('404', 20, 'VALLEDUPAR'),
('405', 20, 'AGUACHICA'),
('406', 20, 'AGUSTIN CODAZZI'),
('407', 20, 'ASTREA'),
('408', 20, 'BECERRIL'),
('409', 20, 'BOSCONIA'),
('41', 5, 'COPACABANA'),
('410', 20, 'CHIMICHAGUA'),
('411', 20, 'CHIRIGUANA'),
('412', 20, 'CURUMANI'),
('413', 20, 'EL COPEY'),
('414', 20, 'EL PASO'),
('415', 20, 'GAMARRA'),
('416', 20, 'GONZALEZ'),
('417', 20, 'LA GLORIA'),
('418', 20, 'LA JAGUA DE IBIRICO'),
('419', 20, 'MANAURE'),
('42', 5, 'DABEIBA'),
('420', 20, 'PAILITAS'),
('421', 20, 'PELAYA'),
('422', 20, 'PUEBLO BELLO'),
('423', 20, 'RIO DE ORO'),
('424', 20, 'LA PAZ'),
('425', 20, 'SAN ALBERTO'),
('426', 20, 'SAN DIEGO'),
('427', 20, 'SAN MARTIN'),
('428', 20, 'TAMALAMEQUE'),
('429', 23, 'MONTERIA'),
('43', 5, 'DON MATIAS'),
('430', 23, 'AYAPEL'),
('431', 23, 'BUENAVISTA'),
('432', 23, 'CANALETE'),
('433', 23, 'CERETE'),
('434', 23, 'CHIMA'),
('435', 23, 'CHINU'),
('436', 23, 'CIENAGA DE ORO'),
('437', 23, 'COTORRA'),
('438', 23, 'LA APARTADA'),
('439', 23, 'LORICA'),
('44', 5, 'EBEJICO'),
('440', 23, 'LOS CORDOBAS'),
('441', 23, 'MOMIL'),
('442', 23, 'MONTELIBANO'),
('443', 23, 'MO?ITOS'),
('444', 23, 'PLANETA RICA'),
('445', 23, 'PUEBLO NUEVO'),
('446', 23, 'PUERTO ESCONDIDO'),
('447', 23, 'PUERTO LIBERTADOR'),
('448', 23, 'PURISIMA'),
('449', 23, 'SAHAGUN'),
('45', 5, 'EL BAGRE'),
('450', 23, 'SAN ANDRES SOTAVENTO'),
('451', 23, 'SAN ANTERO'),
('452', 23, 'SAN BERNARDO DEL VIENTO'),
('453', 23, 'SAN CARLOS'),
('454', 23, 'SAN PELAYO'),
('455', 23, 'TIERRALTA'),
('456', 23, 'VALENCIA'),
('457', 25, 'AGUA DE DIOS'),
('458', 25, 'ALBAN'),
('459', 25, 'ANAPOIMA'),
('46', 5, 'ENTRERRIOS'),
('460', 25, 'ANOLAIMA'),
('461', 25, 'ARBELAEZ'),
('462', 25, 'BELTRAN'),
('463', 25, 'BITUIMA'),
('464', 25, 'BOJACA'),
('465', 25, 'CABRERA'),
('466', 25, 'CACHIPAY'),
('467', 25, 'CAJICA'),
('468', 25, 'CAPARRAPI'),
('469', 25, 'CAQUEZA'),
('47', 5, 'ENVIGADO'),
('470', 25, 'CARMEN DE CARUPA'),
('471', 25, 'CHAGUANI'),
('472', 25, 'CHIA'),
('473', 25, 'CHIPAQUE'),
('474', 25, 'CHOACHI'),
('475', 25, 'CHOCONTA'),
('476', 25, 'COGUA'),
('477', 25, 'COTA'),
('478', 25, 'CUCUNUBA'),
('479', 25, 'EL COLEGIO'),
('48', 5, 'FREDONIA'),
('480', 25, 'EL PE?ON'),
('481', 25, 'EL ROSAL'),
('482', 25, 'FACATATIVA'),
('483', 25, 'FOMEQUE'),
('484', 25, 'FOSCA'),
('485', 25, 'FUNZA'),
('486', 25, 'FUQUENE'),
('487', 25, 'FUSAGASUGA'),
('488', 25, 'GACHALA'),
('489', 25, 'GACHANCIPA'),
('49', 5, 'FRONTINO'),
('490', 25, 'GACHETA'),
('491', 25, 'GAMA'),
('492', 25, 'GIRARDOT'),
('493', 25, 'GRANADA'),
('494', 25, 'GUACHETA'),
('495', 25, 'GUADUAS'),
('496', 25, 'GUASCA'),
('497', 25, 'GUATAQUI'),
('498', 25, 'GUATAVITA'),
('499', 25, 'GUAYABAL DE SIQUIMA'),
('5', 5, 'AMAGA'),
('50', 5, 'GIRALDO'),
('500', 25, 'GUAYABETAL'),
('501', 25, 'GUTIERREZ'),
('502', 25, 'JERUSALEN'),
('503', 25, 'JUNIN'),
('504', 25, 'LA CALERA'),
('505', 25, 'LA MESA'),
('506', 25, 'LA PALMA'),
('507', 25, 'LA PE?A'),
('508', 25, 'LA VEGA'),
('509', 25, 'LENGUAZAQUE'),
('51', 5, 'GIRARDOTA'),
('510', 25, 'MACHETA'),
('511', 25, 'MADRID'),
('512', 25, 'MANTA'),
('513', 25, 'MEDINA'),
('514', 25, 'MOSQUERA'),
('515', 25, 'NARI?O'),
('516', 25, 'NEMOCON'),
('517', 25, 'NILO'),
('518', 25, 'NIMAIMA'),
('519', 25, 'NOCAIMA'),
('52', 5, 'GOMEZ PLATA'),
('520', 25, 'VENECIA'),
('521', 25, 'PACHO'),
('522', 25, 'PAIME'),
('523', 25, 'PANDI'),
('524', 25, 'PARATEBUENO'),
('525', 25, 'PASCA'),
('526', 25, 'PUERTO SALGAR'),
('527', 25, 'PULI'),
('528', 25, 'QUEBRADANEGRA'),
('529', 25, 'QUETAME'),
('53', 5, 'GRANADA'),
('530', 25, 'QUIPILE'),
('531', 25, 'APULO'),
('532', 25, 'RICAURTE'),
('533', 25, 'SAN ANTONIO DEL TEQUENDAMA'),
('534', 25, 'SAN BERNARDO'),
('535', 25, 'SAN CAYETANO'),
('536', 25, 'SAN FRANCISCO'),
('537', 25, 'SAN JUAN DE RIO SECO'),
('538', 25, 'SASAIMA'),
('539', 25, 'SESQUILE'),
('54', 5, 'GUADALUPE'),
('540', 25, 'SIBATE'),
('541', 25, 'SILVANIA'),
('542', 25, 'SIMIJACA'),
('543', 25, 'SOACHA'),
('544', 25, 'SOPO'),
('545', 25, 'SUBACHOQUE'),
('546', 25, 'SUESCA'),
('547', 25, 'SUPATA'),
('548', 25, 'SUSA'),
('549', 25, 'SUTATAUSA'),
('55', 5, 'GUARNE'),
('550', 25, 'TABIO'),
('551', 25, 'TAUSA'),
('552', 25, 'TENA'),
('553', 25, 'TENJO'),
('554', 25, 'TIBACUY'),
('555', 25, 'TIBIRITA'),
('556', 25, 'TOCAIMA'),
('557', 25, 'TOCANCIPA'),
('558', 25, 'TOPAIPI'),
('559', 25, 'UBALA'),
('56', 5, 'GUATAPE'),
('560', 25, 'UBAQUE'),
('561', 25, 'VILLA DE SAN DIEGO DE UBATE'),
('562', 25, 'UNE'),
('563', 25, 'UTICA'),
('564', 25, 'VERGARA'),
('565', 25, 'VIANI'),
('566', 25, 'VILLAGOMEZ'),
('567', 25, 'VILLAPINZON'),
('568', 25, 'VILLETA'),
('569', 25, 'VIOTA'),
('57', 5, 'HELICONIA'),
('570', 25, 'YACOPI'),
('571', 25, 'ZIPACON'),
('572', 25, 'ZIPAQUIRA'),
('573', 27, 'QUIBDO'),
('574', 27, 'ACANDI'),
('575', 27, 'ALTO BAUDO'),
('576', 27, 'ATRATO'),
('577', 27, 'BAGADO'),
('578', 27, 'BAHIA SOLANO'),
('579', 27, 'BAJO BAUDO'),
('58', 5, 'HISPANIA'),
('580', 27, 'BOJAYA'),
('581', 27, 'EL CANTON DEL SAN PABLO'),
('582', 27, 'CARMEN DEL DARIEN'),
('583', 27, 'CERTEGUI'),
('584', 27, 'CONDOTO'),
('585', 27, 'EL CARMEN DE ATRATO'),
('586', 27, 'EL LITORAL DEL SAN JUAN'),
('587', 27, 'ISTMINA'),
('588', 27, 'JURADO'),
('589', 27, 'LLORO'),
('59', 5, 'ITAGUI'),
('590', 27, 'MEDIO ATRATO'),
('591', 27, 'MEDIO BAUDO'),
('592', 27, 'MEDIO SAN JUAN'),
('593', 27, 'NOVITA'),
('594', 27, 'NUQUI'),
('595', 27, 'RIO IRO'),
('596', 27, 'RIO QUITO'),
('597', 27, 'RIOSUCIO'),
('598', 27, 'SAN JOSE DEL PALMAR'),
('599', 27, 'SIPI'),
('6', 5, 'AMALFI'),
('60', 5, 'ITUANGO'),
('600', 27, 'TADO'),
('601', 27, 'UNGUIA'),
('602', 27, 'UNION PANAMERICANA'),
('603', 41, 'NEIVA'),
('604', 41, 'ACEVEDO'),
('605', 41, 'AGRADO'),
('606', 41, 'AIPE'),
('607', 41, 'ALGECIRAS'),
('608', 41, 'ALTAMIRA'),
('609', 41, 'BARAYA'),
('61', 5, 'JARDIN'),
('610', 41, 'CAMPOALEGRE'),
('611', 41, 'COLOMBIA'),
('612', 41, 'ELIAS'),
('613', 41, 'GARZON'),
('614', 41, 'GIGANTE'),
('615', 41, 'GUADALUPE'),
('616', 41, 'HOBO'),
('617', 41, 'IQUIRA'),
('618', 41, 'ISNOS'),
('619', 41, 'LA ARGENTINA'),
('62', 5, 'JERICO'),
('620', 41, 'LA PLATA'),
('621', 41, 'NATAGA'),
('622', 41, 'OPORAPA'),
('623', 41, 'PAICOL'),
('624', 41, 'PALERMO'),
('625', 41, 'PALESTINA'),
('626', 41, 'PITAL'),
('627', 41, 'PITALITO'),
('628', 41, 'RIVERA'),
('629', 41, 'SALADOBLANCO'),
('63', 5, 'LA CEJA'),
('630', 41, 'SAN AGUSTIN'),
('631', 41, 'SANTA MARIA'),
('632', 41, 'SUAZA'),
('633', 41, 'TARQUI'),
('634', 41, 'TESALIA'),
('635', 41, 'TELLO'),
('636', 41, 'TERUEL'),
('637', 41, 'TIMANA'),
('638', 41, 'VILLAVIEJA'),
('639', 41, 'YAGUARA'),
('64', 5, 'LA ESTRELLA'),
('640', 44, 'RIOHACHA'),
('641', 44, 'ALBANIA'),
('642', 44, 'BARRANCAS'),
('643', 44, 'DIBULLA'),
('644', 44, 'DISTRACCION'),
('645', 44, 'EL MOLINO'),
('646', 44, 'FONSECA'),
('647', 44, 'HATONUEVO'),
('648', 44, 'LA JAGUA DEL PILAR'),
('649', 44, 'MAICAO'),
('65', 5, 'LA PINTADA'),
('650', 44, 'MANAURE'),
('651', 44, 'SAN JUAN DEL CESAR'),
('652', 44, 'URIBIA'),
('653', 44, 'URUMITA'),
('654', 44, 'VILLANUEVA'),
('655', 47, 'SANTA MARTA'),
('656', 47, 'ALGARROBO'),
('657', 47, 'ARACATACA'),
('658', 47, 'ARIGUANI'),
('659', 47, 'CERRO SAN ANTONIO'),
('66', 5, 'LA UNION'),
('660', 47, 'CHIBOLO'),
('661', 47, 'CIENAGA'),
('662', 47, 'CONCORDIA'),
('663', 47, 'EL BANCO'),
('664', 47, 'EL PI?ON'),
('665', 47, 'EL RETEN'),
('666', 47, 'FUNDACION'),
('667', 47, 'GUAMAL'),
('668', 47, 'NUEVA GRANADA'),
('669', 47, 'PEDRAZA'),
('67', 5, 'LIBORINA'),
('670', 47, 'PIJI?O DEL CARMEN'),
('671', 47, 'PIVIJAY'),
('672', 47, 'PLATO'),
('673', 47, 'PUEBLOVIEJO'),
('674', 47, 'REMOLINO'),
('675', 47, 'SABANAS DE SAN ANGEL'),
('676', 47, 'SALAMINA'),
('677', 47, 'SAN SEBASTIAN DE BUENAVISTA'),
('678', 47, 'SAN ZENON'),
('679', 47, 'SANTA ANA'),
('68', 5, 'MACEO'),
('680', 47, 'SANTA BARBARA DE PINTO'),
('681', 47, 'SITIONUEVO'),
('682', 47, 'TENERIFE'),
('683', 47, 'ZAPAYAN'),
('684', 47, 'ZONA BANANERA'),
('685', 50, 'VILLAVICENCIO'),
('686', 50, 'ACACIAS'),
('687', 50, 'BARRANCA DE UPIA'),
('688', 50, 'CABUYARO'),
('689', 50, 'CASTILLA LA NUEVA'),
('69', 5, 'MARINILLA'),
('690', 50, 'CUBARRAL'),
('691', 50, 'CUMARAL'),
('692', 50, 'EL CALVARIO'),
('693', 50, 'EL CASTILLO'),
('694', 50, 'EL DORADO'),
('695', 50, 'FUENTE DE ORO'),
('696', 50, 'GRANADA'),
('697', 50, 'GUAMAL'),
('698', 50, 'MAPIRIPAN'),
('699', 50, 'MESETAS'),
('7', 5, 'ANDES'),
('70', 5, 'MONTEBELLO'),
('700', 50, 'LA MACARENA'),
('701', 50, 'URIBE'),
('702', 50, 'LEJANIAS'),
('703', 50, 'PUERTO CONCORDIA'),
('704', 50, 'PUERTO GAITAN'),
('705', 50, 'PUERTO LOPEZ'),
('706', 50, 'PUERTO LLERAS'),
('707', 50, 'PUERTO RICO'),
('708', 50, 'RESTREPO'),
('709', 50, 'SAN CARLOS DE GUAROA'),
('71', 5, 'MURINDO'),
('710', 50, 'SAN JUAN DE ARAMA'),
('711', 50, 'SAN JUANITO'),
('712', 50, 'SAN MARTIN'),
('713', 50, 'VISTAHERMOSA'),
('714', 52, 'PASTO'),
('715', 52, 'ALBAN'),
('716', 52, 'ALDANA'),
('717', 52, 'ANCUYA'),
('718', 52, 'ARBOLEDA'),
('719', 52, 'BARBACOAS'),
('72', 5, 'MUTATA'),
('720', 52, 'BELEN'),
('721', 52, 'BUESACO'),
('722', 52, 'COLON'),
('723', 52, 'CONSACA'),
('724', 52, 'CONTADERO'),
('725', 52, 'CORDOBA'),
('726', 52, 'CUASPUD'),
('727', 52, 'CUMBAL'),
('728', 52, 'CUMBITARA'),
('729', 52, 'CHACHAGsI'),
('73', 5, 'NARI?O'),
('730', 52, 'EL CHARCO'),
('731', 52, 'EL PE?OL'),
('732', 52, 'EL ROSARIO'),
('733', 52, 'EL TABLON DE GOMEZ'),
('734', 52, 'EL TAMBO'),
('735', 52, 'FUNES'),
('736', 52, 'GUACHUCAL'),
('737', 52, 'GUAITARILLA'),
('738', 52, 'GUALMATAN'),
('739', 52, 'ILES'),
('74', 5, 'NECOCLI'),
('740', 52, 'IMUES'),
('741', 52, 'IPIALES'),
('742', 52, 'LA CRUZ'),
('743', 52, 'LA FLORIDA'),
('744', 52, 'LA LLANADA'),
('745', 52, 'LA TOLA'),
('746', 52, 'LA UNION'),
('747', 52, 'LEIVA'),
('748', 52, 'LINARES'),
('749', 52, 'LOS ANDES'),
('75', 5, 'NECHI'),
('750', 52, 'MAGsI'),
('751', 52, 'MALLAMA'),
('752', 52, 'MOSQUERA'),
('753', 52, 'NARI?O'),
('754', 52, 'OLAYA HERRERA'),
('755', 52, 'OSPINA'),
('756', 52, 'FRANCISCO PIZARRO'),
('757', 52, 'POLICARPA'),
('758', 52, 'POTOSI'),
('759', 52, 'PROVIDENCIA'),
('76', 5, 'OLAYA'),
('760', 52, 'PUERRES'),
('761', 52, 'PUPIALES'),
('762', 52, 'RICAURTE'),
('763', 52, 'ROBERTO PAYAN'),
('764', 52, 'SAMANIEGO'),
('765', 52, 'SANDONA'),
('766', 52, 'SAN BERNARDO'),
('767', 52, 'SAN LORENZO'),
('768', 52, 'SAN PABLO'),
('769', 52, 'SAN PEDRO DE CARTAGO'),
('77', 5, 'PE?OL'),
('770', 52, 'SANTA BARBARA'),
('771', 52, 'SANTACRUZ'),
('772', 52, 'SAPUYES'),
('773', 52, 'TAMINANGO'),
('774', 52, 'TANGUA'),
('775', 52, 'SAN ANDRES DE TUMACO'),
('776', 52, 'TUQUERRES'),
('777', 52, 'YACUANQUER'),
('778', 54, 'CUCUTA'),
('779', 54, 'ABREGO'),
('78', 5, 'PEQUE'),
('780', 54, 'ARBOLEDAS'),
('781', 54, 'BOCHALEMA'),
('782', 54, 'BUCARASICA'),
('783', 54, 'CACOTA'),
('784', 54, 'CACHIRA'),
('785', 54, 'CHINACOTA'),
('786', 54, 'CHITAGA'),
('787', 54, 'CONVENCION'),
('788', 54, 'CUCUTILLA'),
('789', 54, 'DURANIA'),
('79', 5, 'PUEBLORRICO'),
('790', 54, 'EL CARMEN'),
('791', 54, 'EL TARRA'),
('792', 54, 'EL ZULIA'),
('793', 54, 'GRAMALOTE'),
('794', 54, 'HACARI'),
('795', 54, 'HERRAN'),
('796', 54, 'LABATECA'),
('797', 54, 'LA ESPERANZA'),
('798', 54, 'LA PLAYA'),
('799', 54, 'LOS PATIOS'),
('8', 5, 'ANGELOPOLIS'),
('80', 5, 'PUERTO BERRIO'),
('800', 54, 'LOURDES'),
('801', 54, 'MUTISCUA'),
('802', 54, 'OCA?A'),
('803', 54, 'PAMPLONA'),
('804', 54, 'PAMPLONITA'),
('805', 54, 'PUERTO SANTANDER'),
('806', 54, 'RAGONVALIA'),
('807', 54, 'SALAZAR'),
('808', 54, 'SAN CALIXTO'),
('809', 54, 'SAN CAYETANO'),
('81', 5, 'PUERTO NARE'),
('810', 54, 'SANTIAGO'),
('811', 54, 'SARDINATA'),
('812', 54, 'SILOS'),
('813', 54, 'TEORAMA'),
('814', 54, 'TIBU'),
('815', 54, 'TOLEDO'),
('816', 54, 'VILLA CARO'),
('817', 54, 'VILLA DEL ROSARIO'),
('818', 63, 'ARMENIA'),
('819', 63, 'BUENAVISTA'),
('82', 5, 'PUERTO TRIUNFO'),
('820', 63, 'CALARCA'),
('821', 63, 'CIRCASIA'),
('822', 63, 'CORDOBA'),
('823', 63, 'FILANDIA'),
('824', 63, 'GENOVA'),
('825', 63, 'LA TEBAIDA'),
('826', 63, 'MONTENEGRO'),
('827', 63, 'PIJAO'),
('828', 63, 'QUIMBAYA'),
('829', 63, 'SALENTO'),
('83', 5, 'REMEDIOS'),
('830', 66, 'PEREIRA'),
('831', 66, 'APIA'),
('832', 66, 'BALBOA'),
('833', 66, 'BELEN DE UMBRIA'),
('834', 66, 'DOSQUEBRADAS'),
('835', 66, 'GUATICA'),
('836', 66, 'LA CELIA'),
('837', 66, 'LA VIRGINIA'),
('838', 66, 'MARSELLA'),
('839', 66, 'MISTRATO'),
('84', 5, 'RETIRO'),
('840', 66, 'PUEBLO RICO'),
('841', 66, 'QUINCHIA'),
('842', 66, 'SANTA ROSA DE CABAL'),
('843', 66, 'SANTUARIO'),
('844', 68, 'BUCARAMANGA'),
('845', 68, 'AGUADA'),
('846', 68, 'ALBANIA'),
('847', 68, 'ARATOCA'),
('848', 68, 'BARBOSA'),
('849', 68, 'BARICHARA'),
('85', 5, 'RIONEGRO'),
('850', 68, 'BARRANCABERMEJA'),
('851', 68, 'BETULIA'),
('852', 68, 'BOLIVAR'),
('853', 68, 'CABRERA'),
('854', 68, 'CALIFORNIA'),
('855', 68, 'CAPITANEJO'),
('856', 68, 'CARCASI'),
('857', 68, 'CEPITA'),
('858', 68, 'CERRITO'),
('859', 68, 'CHARALA'),
('86', 5, 'SABANALARGA'),
('860', 68, 'CHARTA'),
('861', 68, 'CHIMA'),
('862', 68, 'CHIPATA'),
('863', 68, 'CIMITARRA'),
('864', 68, 'CONCEPCION'),
('865', 68, 'CONFINES'),
('866', 68, 'CONTRATACION'),
('867', 68, 'COROMORO'),
('868', 68, 'CURITI'),
('869', 68, 'EL CARMEN DE CHUCURI'),
('87', 5, 'SABANETA'),
('870', 68, 'EL GUACAMAYO'),
('871', 68, 'EL PE?ON'),
('872', 68, 'EL PLAYON'),
('873', 68, 'ENCINO'),
('874', 68, 'ENCISO'),
('875', 68, 'FLORIAN'),
('876', 68, 'FLORIDABLANCA'),
('877', 68, 'GALAN'),
('878', 68, 'GAMBITA'),
('879', 68, 'GIRON'),
('88', 5, 'SALGAR'),
('880', 68, 'GUACA'),
('881', 68, 'GUADALUPE'),
('882', 68, 'GUAPOTA'),
('883', 68, 'GUAVATA'),
('884', 68, 'GsEPSA'),
('885', 68, 'HATO'),
('886', 68, 'JESUS MARIA'),
('887', 68, 'JORDAN'),
('888', 68, 'LA BELLEZA'),
('889', 68, 'LANDAZURI'),
('89', 5, 'SAN ANDRES DE CUERQUIA'),
('890', 68, 'LA PAZ'),
('891', 68, 'LEBRIJA'),
('892', 68, 'LOS SANTOS'),
('893', 68, 'MACARAVITA'),
('894', 68, 'MALAGA'),
('895', 68, 'MATANZA'),
('896', 68, 'MOGOTES'),
('897', 68, 'MOLAGAVITA'),
('898', 68, 'OCAMONTE'),
('899', 68, 'OIBA'),
('9', 5, 'ANGOSTURA'),
('90', 5, 'SAN CARLOS'),
('900', 68, 'ONZAGA'),
('901', 68, 'PALMAR'),
('902', 68, 'PALMAS DEL SOCORRO'),
('903', 68, 'PARAMO'),
('904', 68, 'PIEDECUESTA'),
('905', 68, 'PINCHOTE'),
('906', 68, 'PUENTE NACIONAL'),
('907', 68, 'PUERTO PARRA'),
('908', 68, 'PUERTO WILCHES'),
('909', 68, 'RIONEGRO'),
('91', 5, 'SAN FRANCISCO'),
('910', 68, 'SABANA DE TORRES'),
('911', 68, 'SAN ANDRES'),
('912', 68, 'SAN BENITO'),
('913', 68, 'SAN GIL'),
('914', 68, 'SAN JOAQUIN'),
('915', 68, 'SAN JOSE DE MIRANDA'),
('916', 68, 'SAN MIGUEL'),
('917', 68, 'SAN VICENTE DE CHUCURI'),
('918', 68, 'SANTA BARBARA'),
('919', 68, 'SANTA HELENA DEL OPON'),
('92', 5, 'SAN JERONIMO'),
('920', 68, 'SIMACOTA'),
('921', 68, 'SOCORRO'),
('922', 68, 'SUAITA'),
('923', 68, 'SUCRE'),
('924', 68, 'SURATA'),
('925', 68, 'TONA'),
('926', 68, 'VALLE DE SAN JOSE'),
('927', 68, 'VELEZ'),
('928', 68, 'VETAS'),
('929', 68, 'VILLANUEVA'),
('93', 5, 'SAN JOSE DE LA MONTA?A'),
('930', 68, 'ZAPATOCA'),
('931', 70, 'SINCELEJO'),
('932', 70, 'BUENAVISTA'),
('933', 70, 'CAIMITO'),
('934', 70, 'COLOSO'),
('935', 70, 'COROZAL'),
('936', 70, 'COVE?AS'),
('937', 70, 'CHALAN'),
('938', 70, 'EL ROBLE'),
('939', 70, 'GALERAS'),
('94', 5, 'SAN JUAN DE URABA'),
('940', 70, 'GUARANDA'),
('941', 70, 'LA UNION'),
('942', 70, 'LOS PALMITOS'),
('943', 70, 'MAJAGUAL'),
('944', 70, 'MORROA'),
('945', 70, 'OVEJAS'),
('946', 70, 'PALMITO'),
('947', 70, 'SAMPUES'),
('948', 70, 'SAN BENITO ABAD'),
('949', 70, 'SAN JUAN DE BETULIA'),
('95', 5, 'SAN LUIS'),
('950', 70, 'SAN MARCOS'),
('951', 70, 'SAN ONOFRE'),
('952', 70, 'SAN PEDRO'),
('953', 70, 'SAN LUIS DE SINCE'),
('954', 70, 'SUCRE'),
('955', 70, 'SANTIAGO DE TOLU'),
('956', 70, 'TOLU VIEJO'),
('957', 73, 'IBAGUE'),
('958', 73, 'ALPUJARRA'),
('959', 73, 'ALVARADO'),
('96', 5, 'SAN PEDRO'),
('960', 73, 'AMBALEMA'),
('961', 73, 'ANZOATEGUI'),
('962', 73, 'ARMERO'),
('963', 73, 'ATACO'),
('964', 73, 'CAJAMARCA'),
('965', 73, 'CARMEN DE APICALA'),
('966', 73, 'CASABIANCA'),
('967', 73, 'CHAPARRAL'),
('968', 73, 'COELLO'),
('969', 73, 'COYAIMA'),
('97', 5, 'SAN PEDRO DE URABA'),
('970', 73, 'CUNDAY'),
('971', 73, 'DOLORES'),
('972', 73, 'ESPINAL'),
('973', 73, 'FALAN'),
('974', 73, 'FLANDES'),
('975', 73, 'FRESNO'),
('976', 73, 'GUAMO'),
('977', 73, 'HERVEO'),
('978', 73, 'HONDA'),
('979', 73, 'ICONONZO'),
('98', 5, 'SAN RAFAEL'),
('980', 73, 'LERIDA'),
('981', 73, 'LIBANO'),
('982', 73, 'MARIQUITA'),
('983', 73, 'MELGAR'),
('984', 73, 'MURILLO'),
('985', 73, 'NATAGAIMA'),
('986', 73, 'ORTEGA'),
('987', 73, 'PALOCABILDO'),
('988', 73, 'PIEDRAS'),
('989', 73, 'PLANADAS'),
('99', 5, 'SAN ROQUE'),
('990', 73, 'PRADO'),
('991', 73, 'PURIFICACION'),
('992', 73, 'RIOBLANCO'),
('993', 73, 'RONCESVALLES'),
('994', 73, 'ROVIRA'),
('995', 73, 'SALDA?A'),
('996', 73, 'SAN ANTONIO'),
('997', 73, 'SAN LUIS'),
('998', 73, 'SANTA ISABEL'),
('999', 73, 'SUAREZ');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_marcas`
--

CREATE TABLE `productos_marcas` (
  `idProductoMarca` varchar(15) COLLATE utf8_bin NOT NULL,
  `idUbicacion` varchar(15) COLLATE utf8_bin NOT NULL,
  `idCategotia` varchar(15) COLLATE utf8_bin NOT NULL,
  `NombreProductoMarca` varchar(30) COLLATE utf8_bin NOT NULL,
  `cantidaProductoMarca` int(11) NOT NULL,
  `cantidadExitencia` int(20) NOT NULL,
  `valorCompraUnidad` float NOT NULL,
  `fecha` date NOT NULL,
  `precio_unidad` int(11) NOT NULL,
  `precio_cantidad` int(11) NOT NULL,
  `valorCompraMayor` float NOT NULL,
  `detalles` varchar(100) COLLATE utf8_bin NOT NULL,
  `posicion` int(20) NOT NULL,
  `tipoProducto` varchar(30) COLLATE utf8_bin NOT NULL,
  `idBodega` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `productos_marcas`
--

INSERT INTO `productos_marcas` (`idProductoMarca`, `idUbicacion`, `idCategotia`, `NombreProductoMarca`, `cantidaProductoMarca`, `cantidadExitencia`, `valorCompraUnidad`, `fecha`, `precio_unidad`, `precio_cantidad`, `valorCompraMayor`, `detalles`, `posicion`, `tipoProducto`, `idBodega`) VALUES
('015', '12', '254', 'CASERA X10 UND', 10, 10, 0, '2018-10-15', 1000, 800, 0, 'Compra', 11, 'UND', 'INVENTARIO'),
('016', '12', '1234', 'SUPER JUMBO X 6 ', 3, 3, 0, '2018-10-15', 2400, 2000, 0, 'Compra', 12, 'UND', 'INVENTARIO'),
('021', '12', '125', 'VASO 7 OZ X 50', 0, 0, 0, '2018-10-07', 3600, 1000, 0, 'Compra', 0, '1', 'INVENTARIO'),
('052', '12', '1222', 'PORTACOMIDA J-1', 7, 6, 0, '2018-10-07', 400, 4000, 0, 'Compra', 0, 'UND', 'INVENTARIO'),
('123456', '12', '123', 'YUCAS', 1155, 2245, 26160, '2018-09-10', 24, 23, 25070, 'Compra', 9, '1', 'INVENTARIO'),
('214', '5', '125', 'CHOCOLATE', 4119, 7231, 20560000, '0000-00-00', 5000, 4000, 16448000, '', 4, '', ''),
('2535', '2', '123', 'HAMBURGUESA AMERICANA', 16, 16, 3000, '2018-08-24', 6000, 4000, 40000, 'HAMBURGUESA CON CARNE AMERICANA', 3, 'COCINA', ''),
('3202', '2', '123', 'EMPANADA POLLO', 8, 16, 12000, '2018-08-24', 1500, 1000, 8000, 'PRODUCTO ELABORADO EN RECETAS', 7, 'COCINA', ''),
('323', '4', '125', 'PAPAS', 48, 96, 1152, '0000-00-00', 24, 320, 15360, '', 5, '', ''),
('345', '4', '125', 'PERRO CALIENTE', 2, 0, 0, '0000-00-00', 24, 320, 0, '', 6, 'COCINA', ''),
('8548', '2', '123', 'SALCHIPAPAS', 52, 16, 1500, '2018-09-08', 6000, 5000, 4500, 'COMIDA RAPIDA', 6, 'COCINA', ''),
('987', '12', '1222', 'SAL REFISAL', 10, 10, 0, '2018-10-15', 800, 500, 0, 'Compra', 10, 'UND', 'INVENTARIO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `idProveedor` varchar(15) COLLATE utf8_bin NOT NULL,
  `idMunicipio` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `nombreProveedor` varchar(30) COLLATE utf8_bin NOT NULL,
  `direccionProveedor` varchar(50) COLLATE utf8_bin NOT NULL,
  `telefonoProveedor` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `razonSocial` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `nitProveedor` varchar(20) COLLATE utf8_bin NOT NULL,
  `urlProveedor` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `codigoPostal` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `emailProveedor` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `faxProveedor` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `contactoVendedor` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `idDia` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `observaciones` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`idProveedor`, `idMunicipio`, `nombreProveedor`, `direccionProveedor`, `telefonoProveedor`, `razonSocial`, `nitProveedor`, `urlProveedor`, `codigoPostal`, `emailProveedor`, `faxProveedor`, `contactoVendedor`, `idDia`, `observaciones`) VALUES
('11', '1088', '11', '11', '11', '11', '11', '1', '1', '11', '11', '1', '1', 'SAPO VERDE D E SA          PORQUE DE TAL PALO TAL ASTILLA\n'),
('22052', '0', 'LUIS RODRIGUEZ', 'CALLE 37A ', '3138369712', 'LLANO', '1121884892', '', '', 'LLANOS@GMAIL.COM', '0000000000', '', '0', ''),
('31032', '12', 'ROSA CARVAJALA', 'CALLE 9 SUR 48', '24567', 'LOS MANGOS ', '541', 'WWW.LOSMANGOS.COM', '17', 'LOSMANGOS@GMAIL.COM', '1254', '12354', '2', '	SADASDASD	\n			'),
('45789', '957', 'MARIA SUSANA TORRES', 'CALLE 15', '00000', 'LOS PITUFOS', '1111111', '', '1457', 'LAMAFEA@PORQUEYO.COM', '99999', '', '1', ''),
('ABC123', '0', 'CASD', 'CALLE 5', '322', 'SA', '231', '', '', 'CA', '43', '', '0', '');

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `proveedores_vista`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `proveedores_vista` (
`idProveedor` varchar(15)
,`nombreProveedor` varchar(30)
,`nitProveedor` varchar(20)
,`direccionProveedor` varchar(50)
);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recetas`
--

CREATE TABLE `recetas` (
  `idReceta` varchar(15) COLLATE utf8_bin NOT NULL,
  `idProductoMarca` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreReceta` varchar(30) COLLATE utf8_bin NOT NULL,
  `cantidadProductoGenerado` int(6) NOT NULL,
  `fechaElaboracion` date NOT NULL,
  `descripcionReceta` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `recetas`
--

INSERT INTO `recetas` (`idReceta`, `idProductoMarca`, `nombreReceta`, `cantidadProductoGenerado`, `fechaElaboracion`, `descripcionReceta`) VALUES
('21', '8548', 'SALCHIPAPAS', 1, '2018-09-14', ''),
('2222', '8548', 'SALCHIPAPAS', 2, '2018-09-08', 'RECETA\n1D'),
('32', '3202', 'EMPANADA POLLO', 1, '2018-09-04', ''),
('77', '345', 'PERRO CALIENTE', 1, '2018-09-05', ''),
('888', '2535', 'HAMBURGUESA AMERICANA', 3, '2018-08-28', ''),
('9999', '2535', 'HAMBURGUESA AMERICANA', 2, '2018-08-28', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipos_de_cantidades`
--

CREATE TABLE `tipos_de_cantidades` (
  `idTipoCantidad` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreTipoCantidad` varchar(30) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `tipos_de_cantidades`
--

INSERT INTO `tipos_de_cantidades` (`idTipoCantidad`, `nombreTipoCantidad`) VALUES
('1', 'UND'),
('2', 'GR');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipos_de_compras`
--

CREATE TABLE `tipos_de_compras` (
  `idTipoCompra` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreTipoCompra` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `tipos_de_compras`
--

INSERT INTO `tipos_de_compras` (`idTipoCompra`, `nombreTipoCompra`) VALUES
('1', 'EFECTIVO'),
('2', 'CRÉDITO'),
('3', 'CRÉDITO 8 DIAS'),
('4', 'CREDITO 15 DIAS'),
('5', 'CREDITO 30 DIAS'),
('6', 'CREDITO 45 DIAS'),
('7', 'CREDITO 60 DIAS');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipos_de_pagos`
--

CREATE TABLE `tipos_de_pagos` (
  `idTipoDePago` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreTipoDePago` varchar(30) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `tipos_de_pagos`
--

INSERT INTO `tipos_de_pagos` (`idTipoDePago`, `nombreTipoDePago`) VALUES
('1', 'EFECTIVO'),
('2', 'CRÉDITO'),
('3', 'CRÉDITO 8 DIAS'),
('4', 'CREDITO 15 DIAS'),
('5', 'CREDITO 30 DIAS'),
('6', 'CREDITO 45 DIAS'),
('7', 'CREDITO 60 DIAS');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ubicaciones`
--

CREATE TABLE `ubicaciones` (
  `idUbicacion` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreUbicacion` varchar(30) COLLATE utf8_bin NOT NULL,
  `capacidad` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `ubicaciones`
--

INSERT INTO `ubicaciones` (`idUbicacion`, `nombreUbicacion`, `capacidad`) VALUES
('12', 'mostrador', 11),
('12345', 'casa', 34),
('150', 'prueba', 23345),
('2', 'vitrina', 20),
('4', 'bodega', 50),
('5', 'estanteria', 30);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `vendedores`
--

CREATE TABLE `vendedores` (
  `idVendedor` varchar(15) COLLATE utf8_bin NOT NULL,
  `nombreVendedor` varchar(30) COLLATE utf8_bin NOT NULL,
  `usuarioVendedor` varchar(40) COLLATE utf8_bin NOT NULL,
  `claveVendedor` varchar(60) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `vendedores`
--

INSERT INTO `vendedores` (`idVendedor`, `nombreVendedor`, `usuarioVendedor`, `claveVendedor`) VALUES
('1', 'ANDRES RINCON', 'ADMIN', '2535'),
('2', 'ANDREA TOVAR', 'VENDEDOR1', '5556');

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_mostrar_compras_insumos`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_mostrar_compras_insumos` (
`NumeroFactura` int(11)
,`Codigo` varchar(15)
,`Proveedor` varchar(30)
,`Terminos` varchar(20)
,`Fecha` date
,`Valor` float
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_mostrar_insumos`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_mostrar_insumos` (
`Codigo` varchar(15)
,`Descripcion` varchar(50)
,`Costo` float
,`Cantidad` int(11)
,`Tipo` varchar(15)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_productos_marca`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_productos_marca` (
`idProductoMarca` varchar(15)
,`NombreProductoMarca` varchar(30)
,`cantidaProductoMarca` int(11)
,`precio_unidad` int(11)
);

-- --------------------------------------------------------

--
-- Estructura para la vista `proveedores_vista`
--
DROP TABLE IF EXISTS `proveedores_vista`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `proveedores_vista`  AS  select `proveedores`.`idProveedor` AS `idProveedor`,`proveedores`.`nombreProveedor` AS `nombreProveedor`,`proveedores`.`nitProveedor` AS `nitProveedor`,`proveedores`.`direccionProveedor` AS `direccionProveedor` from `proveedores` ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_mostrar_compras_insumos`
--
DROP TABLE IF EXISTS `vista_mostrar_compras_insumos`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_mostrar_compras_insumos`  AS  select `facturas_de_compras`.`idFacturaCompra` AS `NumeroFactura`,`facturas_de_compras`.`idProveedor` AS `Codigo`,`proveedores`.`nombreProveedor` AS `Proveedor`,`tipos_de_compras`.`nombreTipoCompra` AS `Terminos`,`facturas_de_compras`.`fechaCompra` AS `Fecha`,`facturas_de_compras`.`valorTotal` AS `Valor` from ((`facturas_de_compras` join `proveedores`) join `tipos_de_compras`) where ((`facturas_de_compras`.`idBodega` = '2') and (`proveedores`.`idProveedor` = `facturas_de_compras`.`idProveedor`) and (`tipos_de_compras`.`idTipoCompra` = `facturas_de_compras`.`idTipoCompra`)) order by `facturas_de_compras`.`idFacturaCompra` desc ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_mostrar_insumos`
--
DROP TABLE IF EXISTS `vista_mostrar_insumos`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_mostrar_insumos`  AS  select `insumos`.`idInsumo` AS `Codigo`,`insumos`.`nombreInsumo` AS `Descripcion`,`insumos`.`costoInsumo` AS `Costo`,`insumos`.`cantidadInsumo` AS `Cantidad`,`insumos`.`idTipoCantidad` AS `Tipo` from `insumos` ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_productos_marca`
--
DROP TABLE IF EXISTS `vista_productos_marca`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_productos_marca`  AS  select `productos_marcas`.`idProductoMarca` AS `idProductoMarca`,`productos_marcas`.`NombreProductoMarca` AS `NombreProductoMarca`,`productos_marcas`.`cantidaProductoMarca` AS `cantidaProductoMarca`,`productos_marcas`.`precio_unidad` AS `precio_unidad` from `productos_marcas` ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `bodega`
--
ALTER TABLE `bodega`
  ADD PRIMARY KEY (`idBodega`);

--
-- Indices de la tabla `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`idCategoria`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`idCliente`);

--
-- Indices de la tabla `departamentos`
--
ALTER TABLE `departamentos`
  ADD PRIMARY KEY (`idDepartamento`);

--
-- Indices de la tabla `detalles_compras`
--
ALTER TABLE `detalles_compras`
  ADD PRIMARY KEY (`idDetalleCompra`),
  ADD KEY `idFacturaCompra` (`idFacturaCompra`),
  ADD KEY `IdProductoMarca` (`IdProductoMarca`),
  ADD KEY `idTipoCantidad` (`idTipoCantidad`);

--
-- Indices de la tabla `detalles_compras_insumos`
--
ALTER TABLE `detalles_compras_insumos`
  ADD PRIMARY KEY (`idDetalleCompraInsumo`),
  ADD KEY `idInsumo` (`idInsumo`),
  ADD KEY `idFacturaCompra` (`idFacturaCompra`);

--
-- Indices de la tabla `detalles_recetas`
--
ALTER TABLE `detalles_recetas`
  ADD PRIMARY KEY (`idDetalleReceta`),
  ADD KEY `idInsumo` (`idInsumo`),
  ADD KEY `idReceta` (`idReceta`),
  ADD KEY `idTipoCantidad` (`idTipoCantidad`);

--
-- Indices de la tabla `detalles_ventas`
--
ALTER TABLE `detalles_ventas`
  ADD PRIMARY KEY (`idDetalleVenta`),
  ADD KEY `idFacturaVenta` (`idFacturaVenta`),
  ADD KEY `idProductoMarca` (`idProductoMarca`);

--
-- Indices de la tabla `dias`
--
ALTER TABLE `dias`
  ADD PRIMARY KEY (`idDia`);

--
-- Indices de la tabla `facturas_de_compras`
--
ALTER TABLE `facturas_de_compras`
  ADD PRIMARY KEY (`idFacturaCompra`),
  ADD KEY `idProveedor` (`idProveedor`),
  ADD KEY `idTipoCompra` (`idTipoCompra`),
  ADD KEY `idBodega` (`idBodega`);

--
-- Indices de la tabla `factura_ventas`
--
ALTER TABLE `factura_ventas`
  ADD PRIMARY KEY (`idFacturaVenta`),
  ADD KEY `idCliente` (`idCliente`),
  ADD KEY `IdVendedor` (`IdVendedor`),
  ADD KEY `idTipoDePago` (`idTipoDePago`);

--
-- Indices de la tabla `insumos`
--
ALTER TABLE `insumos`
  ADD PRIMARY KEY (`idInsumo`),
  ADD KEY `idTipoCantidad` (`idTipoCantidad`);

--
-- Indices de la tabla `municipios`
--
ALTER TABLE `municipios`
  ADD PRIMARY KEY (`idMunicipio`),
  ADD KEY `idDepartamento` (`idDepartamento`);

--
-- Indices de la tabla `productos_marcas`
--
ALTER TABLE `productos_marcas`
  ADD PRIMARY KEY (`idProductoMarca`),
  ADD KEY `idUbicacion` (`idUbicacion`),
  ADD KEY `idCategotia` (`idCategotia`),
  ADD KEY `posicion` (`posicion`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`idProveedor`),
  ADD KEY `idMunicipio` (`idMunicipio`),
  ADD KEY `idDia` (`idDia`);

--
-- Indices de la tabla `recetas`
--
ALTER TABLE `recetas`
  ADD PRIMARY KEY (`idReceta`),
  ADD KEY `idProductoMarca` (`idProductoMarca`);

--
-- Indices de la tabla `tipos_de_cantidades`
--
ALTER TABLE `tipos_de_cantidades`
  ADD PRIMARY KEY (`idTipoCantidad`);

--
-- Indices de la tabla `tipos_de_compras`
--
ALTER TABLE `tipos_de_compras`
  ADD PRIMARY KEY (`idTipoCompra`);

--
-- Indices de la tabla `tipos_de_pagos`
--
ALTER TABLE `tipos_de_pagos`
  ADD PRIMARY KEY (`idTipoDePago`);

--
-- Indices de la tabla `ubicaciones`
--
ALTER TABLE `ubicaciones`
  ADD PRIMARY KEY (`idUbicacion`);

--
-- Indices de la tabla `vendedores`
--
ALTER TABLE `vendedores`
  ADD PRIMARY KEY (`idVendedor`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `detalles_compras`
--
ALTER TABLE `detalles_compras`
  MODIFY `idDetalleCompra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=60;

--
-- AUTO_INCREMENT de la tabla `detalles_compras_insumos`
--
ALTER TABLE `detalles_compras_insumos`
  MODIFY `idDetalleCompraInsumo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=364;

--
-- AUTO_INCREMENT de la tabla `detalles_recetas`
--
ALTER TABLE `detalles_recetas`
  MODIFY `idDetalleReceta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de la tabla `detalles_ventas`
--
ALTER TABLE `detalles_ventas`
  MODIFY `idDetalleVenta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT de la tabla `facturas_de_compras`
--
ALTER TABLE `facturas_de_compras`
  MODIFY `idFacturaCompra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=197;

--
-- AUTO_INCREMENT de la tabla `factura_ventas`
--
ALTER TABLE `factura_ventas`
  MODIFY `idFacturaVenta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=87;

--
-- AUTO_INCREMENT de la tabla `productos_marcas`
--
ALTER TABLE `productos_marcas`
  MODIFY `posicion` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `detalles_compras`
--
ALTER TABLE `detalles_compras`
  ADD CONSTRAINT `detalles_compras_ibfk_1` FOREIGN KEY (`idFacturaCompra`) REFERENCES `facturas_de_compras` (`idFacturaCompra`) ON UPDATE CASCADE,
  ADD CONSTRAINT `detalles_compras_ibfk_2` FOREIGN KEY (`idTipoCantidad`) REFERENCES `tipos_de_cantidades` (`idTipoCantidad`) ON UPDATE CASCADE,
  ADD CONSTRAINT `detalles_compras_ibfk_3` FOREIGN KEY (`IdProductoMarca`) REFERENCES `productos_marcas` (`idProductoMarca`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `detalles_compras_insumos`
--
ALTER TABLE `detalles_compras_insumos`
  ADD CONSTRAINT `detalles_compras_insumos_ibfk_2` FOREIGN KEY (`idFacturaCompra`) REFERENCES `facturas_de_compras` (`idFacturaCompra`) ON UPDATE CASCADE,
  ADD CONSTRAINT `detalles_compras_insumos_ibfk_3` FOREIGN KEY (`idInsumo`) REFERENCES `insumos` (`idInsumo`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `detalles_recetas`
--
ALTER TABLE `detalles_recetas`
  ADD CONSTRAINT `detalles_recetas_ibfk_1` FOREIGN KEY (`idReceta`) REFERENCES `recetas` (`idReceta`) ON UPDATE CASCADE,
  ADD CONSTRAINT `detalles_recetas_ibfk_3` FOREIGN KEY (`idTipoCantidad`) REFERENCES `tipos_de_cantidades` (`idTipoCantidad`) ON UPDATE CASCADE,
  ADD CONSTRAINT `detalles_recetas_ibfk_4` FOREIGN KEY (`idInsumo`) REFERENCES `insumos` (`idInsumo`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `detalles_ventas`
--
ALTER TABLE `detalles_ventas`
  ADD CONSTRAINT `detalles_ventas_ibfk_2` FOREIGN KEY (`idFacturaVenta`) REFERENCES `factura_ventas` (`idFacturaVenta`) ON UPDATE CASCADE,
  ADD CONSTRAINT `detalles_ventas_ibfk_3` FOREIGN KEY (`idProductoMarca`) REFERENCES `productos_marcas` (`idProductoMarca`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `facturas_de_compras`
--
ALTER TABLE `facturas_de_compras`
  ADD CONSTRAINT `facturas_de_compras_ibfk_2` FOREIGN KEY (`idTipoCompra`) REFERENCES `tipos_de_compras` (`idTipoCompra`) ON UPDATE CASCADE,
  ADD CONSTRAINT `facturas_de_compras_ibfk_3` FOREIGN KEY (`idProveedor`) REFERENCES `proveedores` (`idProveedor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `facturas_de_compras_ibfk_4` FOREIGN KEY (`idBodega`) REFERENCES `bodega` (`idBodega`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `factura_ventas`
--
ALTER TABLE `factura_ventas`
  ADD CONSTRAINT `factura_ventas_ibfk_2` FOREIGN KEY (`IdVendedor`) REFERENCES `vendedores` (`idVendedor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `factura_ventas_ibfk_3` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`idCliente`) ON UPDATE CASCADE,
  ADD CONSTRAINT `factura_ventas_ibfk_4` FOREIGN KEY (`idTipoDePago`) REFERENCES `tipos_de_pagos` (`idTipoDePago`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `insumos`
--
ALTER TABLE `insumos`
  ADD CONSTRAINT `insumos_ibfk_1` FOREIGN KEY (`idTipoCantidad`) REFERENCES `tipos_de_cantidades` (`idTipoCantidad`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `municipios`
--
ALTER TABLE `municipios`
  ADD CONSTRAINT `municipios_ibfk_1` FOREIGN KEY (`idDepartamento`) REFERENCES `departamentos` (`idDepartamento`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `productos_marcas`
--
ALTER TABLE `productos_marcas`
  ADD CONSTRAINT `productos_marcas_ibfk_1` FOREIGN KEY (`idUbicacion`) REFERENCES `ubicaciones` (`idUbicacion`) ON UPDATE CASCADE,
  ADD CONSTRAINT `productos_marcas_ibfk_2` FOREIGN KEY (`idCategotia`) REFERENCES `categorias` (`idCategoria`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD CONSTRAINT `proveedores_ibfk_1` FOREIGN KEY (`idMunicipio`) REFERENCES `municipios` (`idMunicipio`) ON UPDATE CASCADE,
  ADD CONSTRAINT `proveedores_ibfk_2` FOREIGN KEY (`idDia`) REFERENCES `dias` (`idDia`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `recetas`
--
ALTER TABLE `recetas`
  ADD CONSTRAINT `recetas_ibfk_1` FOREIGN KEY (`idProductoMarca`) REFERENCES `productos_marcas` (`idProductoMarca`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
