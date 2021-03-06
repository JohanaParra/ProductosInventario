USE [dbproductos]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 11/21/2021 22:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spAddCategoria]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spAddCategoria]          
(                    
    @nombre VARCHAR(50),          
    @descripcion VARCHAR(225),
    @estado BIT          
)          
as           
Begin           
    Insert into categoria (nombre, descripcion, estado)           
    Values (@nombre, @descripcion, @estado)           
End
GO
/****** Object:  Table [dbo].[producto]    Script Date: 11/21/2021 22:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[idproducto] [int] IDENTITY(1,1) NOT NULL,
	[idcategoria] [int] NOT NULL,
	[codigo] [varchar](64) NULL,
	[nombre] [varchar](100) NOT NULL,
	[precio_venta] [decimal](11, 2) NOT NULL,
	[stock] [int] NOT NULL,
	[descripcion] [varchar](255) NULL,
	[imagen] [varbinary](max) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idproducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCategoria]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteCategoria]           
(            
   @idcategoria int            
)            
as             
begin            
   Delete from categoria where idcategoria=@idcategoria            
End
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCategoria]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllCategoria]        
as        
Begin        
    select *        
    from categoria     
    order by idcategoria   
End
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCategoria]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spUpdateCategoria]            
(            
    @idcategoria INTEGER ,               
    @nombre VARCHAR(50),          
    @descripcion VARCHAR(225),
    @estado BIT           
)            
as            
begin            
   Update categoria             
   set nombre=@nombre,             
   descripcion=@descripcion,  
   estado=@estado                  
   where idcategoria=@idcategoria            
End
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProducto]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spUpdateProducto]            
(            
    @idproducto INTEGER , 
    @idcategoria INTEGER ,         
    @codigo VARCHAR(64),          
    @nombre VARCHAR(100),          
    @precio_venta DECIMAL(11,2),          
    @stock INT,  
    @descripcion VARCHAR(225),
    @imagen VARBINARY(MAX) = null,
    @estado BIT           
)            
as            
begin            
   Update producto             
   set 
   idcategoria=@idcategoria,
   codigo=@codigo,            
   nombre=@nombre,          
   precio_venta=@precio_venta,
   stock=@stock,          
   descripcion=@descripcion,  
   imagen=@imagen,
   estado=@estado              
   where idproducto=@idproducto            
End
GO
/****** Object:  StoredProcedure [dbo].[spGetAllProducto]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetAllProducto]        
as        
Begin        
    select producto.* , categoria.nombre as NombreCat       
    from producto
    inner join categoria on  producto.idcategoria = Categoria.idcategoria   
    order by idproducto   
End
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProducto]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteProducto]          
(            
   @idproducto int            
)            
as             
begin            
   Delete from producto where idproducto=@idproducto            
End
GO
/****** Object:  StoredProcedure [dbo].[spAddProducto]    Script Date: 11/21/2021 22:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddProducto]          
(          
    @idcategoria INT, 
    @codigo VARCHAR(64),          
    @nombre VARCHAR(100),          
    @precio_venta DECIMAL(11,2),          
    @stock INT,  
    @descripcion VARCHAR(225),
    @imagen VARBINARY(MAX)=null,
    @estado BIT          
)          
as           
Begin           
    Insert into producto (idcategoria,codigo,nombre, precio_venta,stock, descripcion,imagen,estado)           
    Values (@idcategoria,@codigo,@nombre, @precio_venta,@stock,@descripcion,@imagen,@estado)           
End
GO
/****** Object:  Default [DF__categoria__estad__38996AB5]    Script Date: 11/21/2021 22:40:56 ******/
ALTER TABLE [dbo].[categoria] ADD  DEFAULT ((1)) FOR [estado]
GO
/****** Object:  Default [DF__producto__estado__3C69FB99]    Script Date: 11/21/2021 22:40:56 ******/
ALTER TABLE [dbo].[producto] ADD  DEFAULT ((1)) FOR [estado]
GO
/****** Object:  ForeignKey [FK__producto__idcate__3D5E1FD2]    Script Date: 11/21/2021 22:40:56 ******/
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
