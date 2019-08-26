/*
Created: 26/08/2019
Modified: 26/08/2019
Model: Microsoft SQL Server 2017
Database: MS SQL Server 2017
*/


-- Create tables section -------------------------------------------------

-- Table Cliente

CREATE TABLE [Cliente]
(
 [clienteID] Int IDENTITY(1,1) NOT NULL,
 [nombreCliente] Nvarchar(100) NOT NULL,
 [apellidoCliente] Nvarchar(100) NOT NULL,
 [NIT] Nvarchar(20) NULL
)
go

-- Add keys for table Cliente

ALTER TABLE [Cliente] ADD CONSTRAINT [PK_Cliente] PRIMARY KEY ([clienteID])
go

-- Table Producto

CREATE TABLE [Producto]
(
 [productoID] Int IDENTITY(1,1) NOT NULL,
 [nombreProducto] Nvarchar(100) NOT NULL,
 [PrecioVenta] Float NOT NULL,
 [Descripcion] Nvarchar(100) NULL,
 [descuentoProducto] Float NULL,
 [existenciaProducto] Int NOT NULL,
 [tipopID] Int NULL,
 [PresentacionID] Int NULL,
 [proveedorID] Int NULL
)
go

-- Create indexes for table Producto

CREATE INDEX [IX_Relationship1] ON [Producto] ([tipopID])
go

CREATE INDEX [IX_Relationship2] ON [Producto] ([PresentacionID])
go

CREATE INDEX [IX_Relationship10] ON [Producto] ([proveedorID])
go

-- Add keys for table Producto

ALTER TABLE [Producto] ADD CONSTRAINT [PK_Producto] PRIMARY KEY ([productoID])
go

-- Table TipoP

CREATE TABLE [TipoP]
(
 [tipopID] Int IDENTITY(1,1) NOT NULL,
 [NombreTP] Nvarchar(50) NOT NULL
)
go

-- Add keys for table TipoP

ALTER TABLE [TipoP] ADD CONSTRAINT [PK_TipoP] PRIMARY KEY ([tipopID])
go

-- Table Empleado

CREATE TABLE [Empleado]
(
 [empleadoID] Int IDENTITY(1,1) NOT NULL,
 [nombreEmpleado] Nvarchar(100) NOT NULL,
 [apellidoEmpleado] Nvarchar(100) NOT NULL,
 [direccionEmpleado] Nvarchar(100) NULL,
 [telefonoEmpleado] Int NOT NULL
)
go

-- Add keys for table Empleado

ALTER TABLE [Empleado] ADD CONSTRAINT [PK_Empleado] PRIMARY KEY ([empleadoID])
go

-- Table Factura

CREATE TABLE [Factura]
(
 [facturaID] Int IDENTITY(100,2) NOT NULL,
 [letraSerie] Char(1) NOT NULL,
 [fechaFactura] Date DEFAULT getdate() NOT NULL,
 [clienteID] Int NULL,
 [empleadoID] Int NULL,
 [totalFactura] Float NOT NULL
)
go

-- Create indexes for table Factura

CREATE INDEX [IX_Relationship7] ON [Factura] ([clienteID])
go

CREATE INDEX [IX_Relationship8] ON [Factura] ([empleadoID])
go

-- Add keys for table Factura

ALTER TABLE [Factura] ADD CONSTRAINT [PK_Factura] PRIMARY KEY ([facturaID])
go

-- Table Presentacion

CREATE TABLE [Presentacion]
(
 [PresentacionID] Int IDENTITY(1,1) NOT NULL,
 [NombrePres] Nvarchar(50) NOT NULL
)
go

-- Add keys for table Presentacion

ALTER TABLE [Presentacion] ADD CONSTRAINT [PK_Presentacion] PRIMARY KEY ([PresentacionID])
go

-- Table Proveedor

CREATE TABLE [Proveedor]
(
 [proveedorID] Int IDENTITY(1,1) NOT NULL,
 [nombreProveedor] Nvarchar(150) NOT NULL,
 [direccionProveedor] Nvarchar(200) NULL,
 [telefonoProveedor] Int NOT NULL,
 [correoProveedor] Nvarchar(100) NULL
)
go

-- Add keys for table Proveedor

ALTER TABLE [Proveedor] ADD CONSTRAINT [PK_Proveedor] PRIMARY KEY ([proveedorID])
go

-- Table IngresoUsuarios

CREATE TABLE [IngresoUsuarios]
(
 [usuarioID] Int IDENTITY(1,1) NOT NULL,
 [Usuario] Nvarchar(100) NOT NULL,
 [Contraseña] Nvarchar(100) NOT NULL,
 [tlID] Int NULL
)
go

-- Create indexes for table IngresoUsuarios

CREATE INDEX [IX_Relationship15] ON [IngresoUsuarios] ([tlID])
go

-- Add keys for table IngresoUsuarios

ALTER TABLE [IngresoUsuarios] ADD CONSTRAINT [PK_IngresoUsuarios] PRIMARY KEY ([usuarioID])
go

-- Table tipoLogin

CREATE TABLE [tipoLogin]
(
 [tlID] Int IDENTITY(1,1) NOT NULL,
 [nombreTipoL] Nvarchar(50) NOT NULL
)
go

-- Add keys for table tipoLogin

ALTER TABLE [tipoLogin] ADD CONSTRAINT [PK_tipoLogin] PRIMARY KEY ([tlID])
go

-- Table DetalleFactura

CREATE TABLE [DetalleFactura]
(
 [dfID] Int IDENTITY(1,1) NOT NULL,
 [facturaID] Int NOT NULL,
 [productoID] Int NOT NULL,
 [cantidadDF] Int NOT NULL,
 [subtotal] Float NOT NULL
)
go

-- Add keys for table DetalleFactura

ALTER TABLE [DetalleFactura] ADD CONSTRAINT [PK_DetalleFactura] PRIMARY KEY ([facturaID],[productoID],[dfID])
go

-- Table DetallePago

CREATE TABLE [DetallePago]
(
 [dpID] Int IDENTITY(1,1) NOT NULL,
 [facturaID] Int NULL,
 [Efectivo] Float NOT NULL,
 [Tarjeta] Float NOT NULL,
 [Cheque] Float NOT NULL
)
go

-- Create indexes for table DetallePago

CREATE INDEX [IX_Relationship14] ON [DetallePago] ([facturaID])
go

-- Add keys for table DetallePago

ALTER TABLE [DetallePago] ADD CONSTRAINT [PK_DetallePago] PRIMARY KEY ([dpID])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [DetallePago] ADD CONSTRAINT [Relationship14] FOREIGN KEY ([facturaID]) REFERENCES [Factura] ([facturaID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Producto] ADD CONSTRAINT [Relationship10] FOREIGN KEY ([proveedorID]) REFERENCES [Proveedor] ([proveedorID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Factura] ADD CONSTRAINT [Relationship8] FOREIGN KEY ([empleadoID]) REFERENCES [Empleado] ([empleadoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Factura] ADD CONSTRAINT [Relationship7] FOREIGN KEY ([clienteID]) REFERENCES [Cliente] ([clienteID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [DetalleFactura] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([productoID]) REFERENCES [Producto] ([productoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [DetalleFactura] ADD CONSTRAINT [Relationship5] FOREIGN KEY ([facturaID]) REFERENCES [Factura] ([facturaID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Producto] ADD CONSTRAINT [Relationship2] FOREIGN KEY ([PresentacionID]) REFERENCES [Presentacion] ([PresentacionID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Producto] ADD CONSTRAINT [Relationship1] FOREIGN KEY ([tipopID]) REFERENCES [TipoP] ([tipopID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [IngresoUsuarios] ADD CONSTRAINT [Relationship15] FOREIGN KEY ([tlID]) REFERENCES [tipoLogin] ([tlID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




