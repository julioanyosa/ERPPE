ALTER TABLE EMPRESA.EMPRESA ADD
 [RutaXMLFE] VARCHAR(500), [RutaCDRFE] VARCHAR(500), [RutaCertificado] VARCHAR(500), 
 [ClaveCertificado] VARCHAR(500), [UsuarioSOL] VARCHAR(500), [ClaveSol] VARCHAR(500),
  [EmiteFE] CHAR(1), [GenerarFisico] CHAR(1)
  GO

  UPDATE Empresa.Empresa SET
   [RutaXMLFE] ='E:\FE_PE\XML\', [RutaCDRFE] = 'E:\FE_PE\CDR\', [RutaCertificado] = 'E:\FE_PE\PERUANAENVASES.pfx', 
 [ClaveCertificado] = '0123456789ab', [UsuarioSOL] ='JULIO111', [ClaveSol] = '123456ab',
  [EmiteFE] = 'S', [GenerarFisico] ='S'
    WHERE EmpresaID = 'PE'

alter table ventas.IGV add FechaCreacion datetime, UsuarioID int
GO
update ventas.IGV set FechaCreacion = GETDATE()
GO




ALTER TABLE [Ventas].[Comprobante] ADD [ComprobanteId] BIGINT IDENTITY(1,1),
[EnviadoSunat] CHAR(1), [FechaEnvioSunat] DATETIME, [MensajeSunat] VARCHAR(1000)
GO

ALTER TABLE [Ventas].[NotaCredito] ADD [NotaID] INT IDENTITY(1,1), [Tipo] CHAR(2),
[Serie] CHAR(4), [Numero] INT, [EmpresaID] CHAR(2), [SerieRelacionado] CHAR(4) NULL,
[NumeroRelacionado] INT NULL,[TicketSunat] BIGINT , [MensajeSunat] VARCHAR(1000),
[EnviadoSunat] CHAR(1), [FechaEnvioSunat] DATETIME, [ComprobanteId] BIGINT
GO

ALTER TABLE [Ventas].[Comprobante] ALTER COLUMN NotaCreditoID VARCHAR(13)
go

ALTER TABLE  Almacen.Almacen   ADD Establecimiento CHAR(4) 
GO  

ALTER TABLE VENTAS.TIPOCOMPROBANTE ADD TipoSunat CHAR(2)
GO

INSERT INTO VENTAS.TipoComprobante( TipoComprobanteID,	NomTipoComprobante,	tiposunat)
SELECT 4,	'BOLETA ELECTRONICA',	'03'
UNION
SELECT 5,	'FACTURA ELECTRONICA',	'01'
GO
UPDATE VENTAS.TIPOCOMPROBANTE SET TipoSunat = '03' WHERE TipoComprobanteID = 1
UPDATE VENTAS.TIPOCOMPROBANTE SET TipoSunat = '01' WHERE TipoComprobanteID = 2
UPDATE VENTAS.TIPOCOMPROBANTE SET TipoSunat = '12' WHERE TipoComprobanteID = 3
GO


insert into ventas.SerieGuia
([EmpresaSede], [TipoDocumento], [Serie], [Numero], [SerieEticketera], [NroAutorizacion],
 [FlgEst], [UsuarioID], [AudCrea])
 values
 ('PE00001',4,'001',0,'','',1,1,GETDATE())
 go
 insert into ventas.SerieGuia
([EmpresaSede], [TipoDocumento], [Serie], [Numero], [SerieEticketera], [NroAutorizacion],
 [FlgEst], [UsuarioID], [AudCrea])
 values
 ('PE00001',5,'001',0,'','',1,1,GETDATE())
 go


CREATE procedure Ventas.ActualizarNotaCredito  
(  
@NotaID int,  
@TicketSunat bigint,  
@MensajeSunat varchar(1000),  
@EnviadoSunat char(1),  
@ComprobanteId bigint  
)  
as  
update Ventas.NotaCredito set TicketSunat =@TicketSunat , MensajeSunat = @MensajeSunat, EnviadoSunat = @EnviadoSunat, FechaEnvioSunat = getdate(), ComprobanteId = @ComprobanteId  
 where NotaID = @NotaID  
  GO

  --Ventas.GenerarFE_SUNAT null,'', 'IH', '2018-01-06', ''      
--ventas.GenerarFE_SUNAT 5,'IH001-0000014', 'IH' , null    ,'07'    
ALTER procedure Ventas.GenerarFE_SUNAT        
(          
@TipoComprobanteID int = null,          
@NumComprobante char(13) = null,        
@EmpresaID char(2),      
@Fecha date = null,  
@Tipo char(2)      
)          
as          
          
      
set dateformat ymd          
    
          
        
 select       
con.FlgEst as Estado,       
 con.ComprobanteId,       
 con.TipoComprobanteID,       
 emp.RUC,        
 6 as TipoDocumentoEmisor,        
 emp.NomEmpresa as RazonSocial,      
 emp.DomicilioFiscal  as DomicilioFiscalEmisor,    
 emp.Telefono as TelefonoEmisor,      
  case    
  when @Tipo = '07' then emp.RutaXMLFE + 'NC\'   
  when @Tipo = '08' then emp.RutaXMLFE + 'ND\'   
  when con.TipoComprobanteID = 4 then emp.RutaXMLFE + 'B\'     
  when con.TipoComprobanteID = 5 then emp.RutaXMLFE + 'F\'     
  end as RutaXMLFE,      
    
  case   
  when @Tipo = '07' then emp.RutaXMLFE + 'NC\'   
  when @Tipo = '08' then emp.RutaXMLFE + 'ND\'    
  when con.TipoComprobanteID = 4 then emp.RutaCDRFE + 'B\'     
  when con.TipoComprobanteID = 5 then emp.RutaCDRFE + 'F\'     
  end as RutaCDRFE,      
      
emp.RutaCertificado,        
emp.ClaveCertificado,         
emp.UsuarioSOL,        
emp.ClaveSol,         
emp.EmiteFE,   
emp.GenerarFisico,  
 '01' as TipoOperacion, --Tipo de operación           
 convert(char(4),YEAR(con.AudCrea)) + '-' + right('00' + convert(varchar(2),month(con.AudCrea)),2) + '-' + right('00' + convert(varchar(2),day(con.AudCrea)),2)  as FechaEmision, --Fecha de emisión          
 ISNULL(AL.Establecimiento,'9999') as CodigoDomicilioFiscal, --Código del domicilio fiscal o de local anexo del emisor          
 case          
 when con.ClienteID = 0 or con.ClienteID = 1 or con.ClienteID = 204 or con.ClienteID = 241 or con.ClienteID = 3032 then '0'          
 else td.TipoContabilidad end   as TipoDocumentoIdentidadCliente, ---Tipo de documento de identidad del adquirente o usuario          
 case          
 when con.ClienteID = 0 or con.ClienteID = 1 or con.ClienteID = 204 or con.ClienteID = 241 or con.ClienteID = 3032 then '-'          
 else c.NroDocumento end  NumeroDocumentoIdentidadCliente,--Número de documento de identidad del adquirente o usuario          
 case          
 when con.ClienteID = 0 or con.ClienteID = 1 or con.ClienteID = 204 or con.ClienteID = 241 or con.ClienteID = 3032 then 'CLIENTE VARIOS'          
 else LEFT(c.RazonSocial,100) end  as RazonSocialCliente, --Apellidos y nombres, denominación o razón social del adquirente o usuario           
 'PEN' as TipoMoneda, --Tipo de moneda en la cual se emite la factura electrónica          
  ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00)  as DescuentosGlobales, --Descuentos Globales       
 convert(decimal(12,2),con.SubTotal)   as SubTotal, --Total valor de venta            
 convert(decimal(12,2),'0.00')   as SumatoriaOtrosCargos,  --Sumatoria otros Cargos          
  ISNULL(convert(decimal(12,2),Descuento.Importe * -1),0.00)  as TotalDescuentos, --Total descuentos          
 CASE WHEN con.TotalIGV != 0 THEN convert(decimal(12,2),con.SubTotal) ELSE convert(decimal(12,2),'0.00') END  as OperacionesGravadas, --Total valor de venta - Operaciones gravadas          
 convert(decimal(12,2),'0.00')   as OperacionesInafectas, --Total valor de venta - Operaciones inafectas          
 CASE WHEN con.TotalIGV = 0 THEN convert(decimal(12,2),con.SubTotal) ELSE convert(decimal(12,2),'0.00') END    as ValorVentaOperacionesExoneradas, --Total valor de venta - Operaciones exoneradas          
  convert(decimal(12,2),con.TotalIGV)   as SumatoriaIGV, --Sumatoria IGV          
 convert(decimal(12,2),'0.00')   as SumatoriaISC, + --Sumatoria ISC          
 convert(decimal(12,2),'0.00')  as SumatoriaOtrosTributos, --Sumatoria otros tributos          
  convert(decimal(12,2),con.TotalIGV + con.SubTotal) as ImporteTotal, --Importe total de la venta, cesión en uso o del servicio prestado          
  0.00 as Gratuitas,con.IGV as CalculoIgv, 0 as CalculoDetraccion, 0 as CalculoIsc,        
 tc.TipoSunat as TipoDocumento,          
 --@Tipo as TipoDocumento,  
  substring(con.NumComprobante,3,3) as Serie,          
  '0' + substring(con.NumComprobante,7,7) as Numero,          
  con.NumComprobante,         
  case    
  when con.TipoComprobanteID = 4 then 'B' + SUBSTRING(con.NumComprobante,3,3) + '-0' + RIGHT(con.NumComprobante,7)    
  when con.TipoComprobanteID = 5 then 'F' + SUBSTRING(con.NumComprobante,3,3) + '-0' + RIGHT(con.NumComprobante,7)    
  end as NumComprobante2,    
  tc.NomTipoComprobante,    
  C.Direccion AS DireccionCLiente,  
  con.ClienteID    
          
 from Ventas.Comprobante AS con          
 INNER JOIN Ventas.Cliente c ON c.ClienteID = con.ClienteID          
 INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = c.IDTipoDocumento          
 inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID          
 inner join Empresa.Empresa as emp on emp.EmpresaID = con.EmpresaID        
 left JOIN           
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'          
 GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = con.NumComprobante AND Descuento.TipoComprobanteID = con.TipoComprobanteID           
  left join           
  (          
  select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen          
  )          
   as AL on AL.EmpresaID = con.EmpresaID and AL.SedeID = con.SedeID          
 where          
 (con.NumComprobante = @NumComprobante  and con.EmpresaID = @EmpresaID and con.tipocomprobanteid = @TipoComprobanteID )      
 or(convert(date,con.AudCrea) = @Fecha and con.tipocomprobanteid in(4))         
          
           
        
  --ahora los detalles ----------------------------------------------------------------          
        
        
  SELECT      
   con.ComprobanteId,          
  case          
  when p.unidadmedidaid = 'UN' then   'NIU'          
  when p.unidadmedidaid = 'KG' then   'KGM'          
  when p.unidadmedidaid = 'MT' then   'MTR'          
  when p.unidadmedidaid = 'LT' then   'LTR'          
  when p.unidadmedidaid = 'PQ' then   'PK'          
  when p.unidadmedidaid = 'GL' then   'GLL'          
  when p.unidadmedidaid = 'GR' then   'GRM'          
  when p.unidadmedidaid = 'SC' then   'NIU'         
  else 'ERROR-' + p.UnidadMedidaID end  as CodigoUM, --Código de unidad de medida por ítem          
  convert(varchar(23),convert(decimal(12,2),dc.Cantidad))  as Cantidad, --Cantidad de unidades por ítem          
  dc.ProductoID  as CodigoProducto, --Código de producto          
  dc.ProductoID  as CodigoProductoSunat, --Codigo producto SUNAT          
  left(p.alias,250) as DescripcionProducto, --Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando las características.          
  CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))   as ValorUnitario, --Valor unitario por ítem          
  '0.00'  as DescuentoItem, --Descuentos por item          
  '0.00'  as MontoIgvItem, --Monto de IGV por ítem          
  '30' as AfectacionIGVItem, --Afectación al IGV por ítem          
  '0.00'  as MontoISCItem, --Monto de ISC por ítem          
  '01'  as TipoSistemaISC, -- Tipo de sistema ISC          
  CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) as PrecioVentaItem, --Precio de venta unitario por item          
  CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) as ValorVentaItem,    --Valor de venta por ítem,        
  (convert(decimal(12,2),dc.PrecioUnitario) * convert(decimal(12,2),dc.Cantidad)) as Suma,          
   (convert(decimal(12,2),dc.PrecioUnitario) * convert(decimal(12,2),dc.Cantidad)) as TotalVenta,          
  tc.TipoSunat as TipoDocumento,          
  substring(con.NumComprobante,3,3) as Serie,          
  '0' + substring(con.NumComprobante,7,7) as Numero          
             
  FROM Ventas.DetalleComprobante dc          
  INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID          
  inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID          
  inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID          
  WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and          
  (      
  (con.NumComprobante = @NumComprobante and con.TipoComprobanteID = @TipoComprobanteID )      
   or(convert(date,con.AudCrea) = @Fecha and con.tipocomprobanteid  in(4))        
   )     
GO


create procedure Ventas.ActualizarComprobanteSunat  
(  
@ComprobanteId bigint,  
@EnviadoSunat char(1)  
)  
as  
declare @FechaEnvioSunat datetime = getdate()  
update Ventas.Comprobante set EnviadoSunat = @EnviadoSunat, FechaEnvioSunat= @FechaEnvioSunat where ComprobanteId = @ComprobanteId  
  
select @ComprobanteId as ComprobanteId, @FechaEnvioSunat as FechaEnvioSunat
GO

  
CREATE procedure Ventas.InsertarNotaCreditoFE  
(  
 @Tipo Char(2),  
 @EmpresaID char(2),  
 @SerieRelacionado char(4),  
 @NumeroRelacionado int,  
 @TipoComprobanteID tinyint,  
 @Importe decimal(12,3),  
 @Concepto varchar(200),  
 @Descuento decimal(12,3) ,  
 @ClienteID int,  
 @UsuarioID int,  
 @SedeID char(5)  
)  
as  
declare @NotaID int  
declare @Fecha date = getdate()  
declare @Serie char(4)   
declare @numero int  
declare @serietipo char(3)  
declare @NumComprobanteNota char(13)  
declare @NumComprobante char(13)  
  
if(@Tipo = '07')  
 set @serietipo = 'NC1'  
else if(@Tipo = '08')  
 set @serietipo = 'NB1'  
  
select @numero = max(Numero) from ventas.NotaCredito where Tipo = @Tipo and EmpresaID = @EmpresaID  
  
set @numero = isnull(@numero,0) +1  
if(@TipoComprobanteID = 4)  
 set @Serie = 'B' + @serietipo  
else if(@TipoComprobanteID = 5)  
 set @Serie = 'F' + @serietipo  
  
  
set @NumComprobanteNota = @Serie + '-' + right('00000000' + convert(varchar(8), @numero),8)  
set @NumComprobante = @SerieRelacionado + '-' + right('00000000' + convert(varchar(8), @NumeroRelacionado),8)  
  
Insert into [Ventas].[NotaCredito]  
(Tipo,Serie,Numero,EmpresaID,SerieRelacionado,NumeroRelacionado, AudCrea, TipoComprobanteID,  
Importe, Concepto, [Descuento%], NotaCreditoID, NumComprobante, ClienteID, UsuarioID, SedeID)  
values  
(@Tipo,@Serie,@Numero,@EmpresaID,@SerieRelacionado,@NumeroRelacionado, @Fecha, @TipoComprobanteID,  
@Importe, @Concepto, @Descuento,@NumComprobanteNota,@NumComprobante,@ClienteID,@UsuarioID,@SedeID )  
  
select @NotaID = SCOPE_IDENTITY()  
  
  
Select @NotaID as NotaID,  @Fecha as Fecha, @Serie as Serie, @numero as Numero, @NumComprobanteNota as NumeroComprobante  
GO

CREATE PROCEDURE VENTAS.HABILITADOFE    
AS    
    
SELECT 0 

GO

--VENTAS.HABILITADOFE2 'IH'  
CREATE PROCEDURE VENTAS.HABILITADOFE2  
(  
@EmpresaID char(2)  
)      
AS      
      
if ((select EmiteFE from Empresa.Empresa where EmpresaID = @EmpresaID) = 'S')  
 select 1  
else  
 select 0  
  
  GO


  CREATE TABLE [Ventas].[BajaFE](
	[EmpresaID] [char](2) NULL,
	[TipoSunat] [char](2) NULL,
	[Numero] [int] NULL,
	[UsuarioID] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[TipoComprobanteID] [int] NULL,
	[NumComprobante] [char](13) NULL,
	[FechaReferencia] [date] NULL,
	[TicketSunat] [bigint] NULL,
	[MensajeSunat] [varchar](1000) NULL,
	[BajaFEId] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO


  CREATE procedure [Ventas].[ActualizarBajaFE]  
(  
@BajaFEId int,  
@FechaReferencia date = null,  
@TicketSunat bigint,  
@MensajeSunat varchar(1000)  
)  
as  
update ventas.BajaFE set  
FechaReferencia = @FechaReferencia, TicketSunat = @TicketSunat, MensajeSunat = @MensajeSunat  
where BajaFEId = @BajaFEId  
  
SELECT 200 vCod, 'RS' vType, 'OK' vDesc     
go



  
CREATE procedure Ventas.DatosAnulacionFE         
(          
@TipoComprobanteID int = null,          
@NumComprobante char(13) =  null,        
@EmpresaID char(2),      
@TipoSunat char(2) ,      
@UsuarioID int      
)          
as          
          
declare @numero int    , @BajaFEId int  
      
select @numero = max(Numero) from ventas.BajaFE where EmpresaID = @EmpresaID       
and TipoSunat = @TipoSunat and convert(char(8),FechaCreacion,103) = convert(char(8),getdate(),103)      
      
set @numero =  isnull(@numero,0) + 1      
      
insert into Ventas.BajaFE      
(EmpresaID,TipoSunat,Numero,UsuarioID,FechaCreacion,TipoComprobanteID,NumComprobante)      
values      
(@EmpresaID,@TipoSunat,@numero,@UsuarioID,getdate(),@TipoComprobanteID,@NumComprobante)      
   
 set @BajaFEId = SCOPE_IDENTITY()  
  
if @TipoSunat = 'RA'      
begin      
 select          
 emp.RUC,        
 6 as TipoDocumentoEmisor,        
 emp.NomEmpresa as RazonSocial,      
    
     
  case    
  when con.TipoComprobanteID = 4 then emp.RutaXMLFE + 'B\'     
  when con.TipoComprobanteID = 5 then emp.RutaXMLFE + 'F\'     
  end as RutaXMLFE,      
    
  case    
  when con.TipoComprobanteID = 4 then emp.RutaCDRFE + 'B\'     
  when con.TipoComprobanteID = 5 then emp.RutaCDRFE + 'F\'     
  end as RutaCDRFE,      
      
       
 emp.RutaCertificado,        
 emp.ClaveCertificado,         
 emp.UsuarioSOL,        
 emp.ClaveSol,         
 emp.EmiteFE,      
 right('00000' + convert(varchar(5),@numero),5) as Numero ,       
 con.ComprobanteId ,      
 tc.TipoSunat as TipoDocumento,      
 con.AudCrea,      
 GETDATE() as Fecha,  
 @BajaFEId as BajaFEId        
 from  Empresa.Empresa as emp      
 inner join ventas.Comprobante as con on con.EmpresaID = emp.EmpresaID      
 inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID          
  where emp.EmpresaID = @EmpresaID    and con.TipoComprobanteID = @TipoComprobanteID and con.NumComprobante = @NumComprobante      
end      
else if @TipoSunat = 'RC'      
begin      
 select          
 emp.RUC,        
 6 as TipoDocumentoEmisor,        
 emp.NomEmpresa as RazonSocial,      
 emp.RutaXMLFE + 'B\' as RutaXMLFE,        
 emp.RutaCDRFE + 'B\' as RutaCDRFE,         
 emp.RutaCertificado,        
 emp.ClaveCertificado,         
 emp.UsuarioSOL,        
 emp.ClaveSol,         
 emp.EmiteFE,      
 right('00000' + convert(varchar(5),@numero),5) as Numero,      
 GETDATE() as Fecha,  
 @BajaFEId as BajaFEId         
 from  Empresa.Empresa as emp      
  where emp.EmpresaID = @EmpresaID       
end      
      
go


/************************************************************************************************************  
Autor  : Juan Carlos  
Fecha  : 12/07/2011  
Descripción : Listar registros de la tabla de base de datos   
Prueba  : Ventas.Usp_get_TipoPago  
*************************************************************************************************************/  
ALTER Procedure [Ventas].[Usp_get_IGV]  
AS  
Begin  
 Set Nocount On  
   
  Select  TOP 1 
   [IGV%]  
  from   
   Ventas.IGV  ORDER BY FechaCreacion DESC
     
 Set Nocount Off          
End  
GO

CREATE PROCEDURE VENTAS.proc_InsertarIGV
(
@IGV smallint,
@UsuarioID int
)
as
insert into ventas.IGV ([IGV%],FechaCreacion,UsuarioID) values (@IGV,GETDATE(),@UsuarioID)
go

select top 5000 * from Ventas.Comprobante order by ComprobanteId desc

select * from ventas.IGV
