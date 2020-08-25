create database bodegas;
use bodegas;

create table if not exists cliente(
	idCliente int(6)not null auto_increment,
    nombre varchar(30)not null,
    apellido varchar(40)not null,
    nit varchar(15),
    dpi varchar(15),
    telefono varchar(10),
    correo varchar(50),
    direccion varchar(40),
    estado int(1)not null,
    primary key (idCliente),
    key (idCliente)
);
create table if not exists proveedor(
	idProveedor int(6)not null auto_increment,
    razon_social varchar(80)not null,
    representante varchar(40)not null,
    nit varchar(15)not null,
    telefono varchar(10),
    correo varchar(50),
    estado int(1)not null,
    primary key (idProveedor),
    key (idProveedor)
);
create table if not exists categoria_producto(
	idCategoria int(6)not null auto_increment,
    nombre varchar(30)not null,
    descripcion varchar(50)not null,
    estado int(1)not null,
    primary key (idCategoria),
    key (idCategoria)
);
create table if not exists producto(
	idProducto int(6)not null auto_increment,
    nombre varchar(30)not null,
    cantidad int(6)not null,
    precio double(12,2)not null,
    idCategoia int(6)not null,
    estado int(1)not null,
    primary key (idProducto),
    key (idProducto)
);

create table if not exists bodega(
	idBodega int(6)not null auto_increment,
    nombre varchar(30)not null,
    direccion varchar(45)not null,
    estado int(1)not null,
    primary key (idBodega),
    key (idBodega)
);

create table if not exists bodega_producto(
	idBodega int(6) not null,
    idProducto int(6)not null,
    estado int(1)not null,
    primary key (idBodega),
    key (idBodega)
);

create table if not exists empleado (
    idEmpleado int(6) not null auto_increment,
    idCargo int(6) not null,
    dpi varchar(16) not null,
    nit varchar(20) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    correo varchar(45) not null,
    telefono int(8) not null,
    direccion varchar(45) not null,
    estado int(1)not null,
    primary key (idEmpleado),
    key (idEmpleado)
);

create table if not exists cargo (
    idCargo int(6) not null auto_increment,
    nombre varchar(20) not null,
    descripcion varchar(25),
    estado int(1)not null,
    primary key (idCargo),
    key (idCargo)
);
create table if not exists factura_encabezado(
	idEncabezado int(6)not null,
    idEmpleado int(6)not null,
    idCliente int(6)not null,
    no_serie varchar(10)not null,
    fecha  datetime not null,
    forma_pago int(1)not null,
    total_factura double(12,2) not null,
    tipo_doc int(1)not null,
    estado int(1) not null,
    primary key (idEncabezado),
    key (idEncabezado)
);

create table if not exists detalle_factura (
    idEncabezado int(6)not null,
    cod_linea int(6)not null,
    idProducto int(6) not null,
    cantidad double(12,2)not null,
    subtotal double(12,2) not null,
    estado int(1)not null,
    primary key (cod_linea,idEncabezado)
);

create table if not exists encabezado_compra (
    idCompra int(6) not null,
    idProveedor int(6) not null,
    tipo_doc int(1)not null,
    fecha_compra datetime not null,
    total_compra double(12,2)not null,
    estado int(1)not null,
    primary key (idCompra),
    key (idCompra)
);

create table if not exists detalle_compra (
    idCompra int(6) not null,
    cod_linea int(6)not null,
    idProducto int(6) not null,
    cantidad int(6) not null,
    precio_unitario double(12,2) not null,
    subtotal double(12,2)not null,
    estado int(1)not null,
    primary key (idCompra,cod_linea)
);

create table if not exists comisiones_empleado(
	idRegistroComision int(6) not null auto_increment,
    idEncabezado int(6) not null,
    idEmpleado int(6) not null,
    comision double(12,2)not null,
    estado int(1)not null,
    primary key(idRegistroComision),
    key(idRegistroComision)
);
/*RELACIONES-LLAVES FORANEAS*/
alter table producto add constraint fk_producto_categoria foreign key(idCategoia) references categoria_producto(idCategoria);
alter table bodega_producto add constraint fk_bodega foreign key(idBodega) references bodega(idBodega);
alter table bodega_producto add constraint fk_producto foreign key(idProducto) references producto(idProducto);
alter table empleado add constraint fk_cargo foreign key(idCargo) references cargo(idCargo);
alter table factura_encabezado add constraint fk_encabezado_cliente foreign key(idCliente) references cliente(idCliente);
alter table factura_encabezado add constraint fk_encabezado_empleado foreign key(idEmpleado) references empleado(idEmpleado);
alter table detalle_factura add constraint fk_detalle_encabezado foreign key(idEncabezado)  references factura_encabezado(idEncabezado);
alter table detalle_factura add constraint fk_detalle_producto foreign key(idProducto)  references producto(idProducto);
alter table encabezado_compra add constraint fk_compra_proveedor foreign key(idProveedor) references proveedor(idProveedor);
alter table detalle_compra add constraint fk_compra_detalle foreign key(idCompra) references encabezado_compra(idCompra);
alter table detalle_compra add constraint fk_compra_producto foreign key(idProducto) references producto(idProducto);
alter table comisiones_empleado add constraint fk_encabezado_comision foreign key(idEncabezado) references factura_encabezado(idEncabezado);
alter table comisiones_empleado add constraint fk_empleado_comision foreign key(idEmpleado) references empleado(idEmpleado);