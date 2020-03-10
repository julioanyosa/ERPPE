/*
--telefonos						ya esta
--conexiona sunat				ya esta
--impresion emitido				ya esta
--impresion doble hoja			ya esta
--monto cero en boletas			ya esta
--borrar emitidos resumen		ya esta
--borrar emitidos baja			ya esta
--puntos bonus
--



Create table Empresa.Sucursal
(
EmpresaID char(2),
SedeID char(5),
CodigoAlmacenSunat char(4),
TelefonoCelular varchar(15),
TelefonoFijo varchar(15)
)

go
insert into Empresa.Sucursal values('PE','00001', '0000','961 907 427','')
insert into Empresa.Sucursal values('PE','00002', '0003','938 666 461','')

10059371431
10058661975
*/


--Ventas.ObtenerTxtFacturadorSunat 81
--GO
 

alter table ventas.comprobante add Esgratuito bit 
go

ALTER PROCEDURE [Ventas].[ObtenerTxtFacturadorSunat]
(
@ID BIGINT 
)
as
--DECLARE @ID BIGINT = 2479196
--DECLARE @UNIDADRAIZ VARCHAR(500) = '', 
--@NOMBREARCHIVOCAB varchar(250), @NOMBREARCHIVOLEY varchar(250), @NOMBREARCHIVODET varchar(250),
--@NOMBREARCHIVOTRI varchar(250)
DECLARE @Cadena    varchar(max) 
 
--SELECT @UNIDADRAIZ AS UNIDADRAIZ 

CREATE TABLE #CABECERA    
(    
ID INT,    
TEXTO VARCHAR(8000)    
)    
    
CREATE TABLE #DETALLE    
(    
ID INT,    
TEXTO VARCHAR(8000)    
) 


-------------------------------------------------------------------
--CABECERA
INSERT INTO #CABECERA (ID, TEXTO)  
SELECT 1,   E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.CAB'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

INSERT INTO #DETALLE (ID, TEXTO)  
SELECT 1,
'0101' + '|' + --Tipo de operación (VENTA INTERNA)
CONVERT(char(10), C.AudCrea,126) + '|' + --Fecha de emisión
CONVERT(varchar(10),C.AudCrea,108) + '|' +--Hora de Emisión
'-' + '|' +--Fecha de vencimiento
'0001' + '|' +--Código del domicilio fiscal o de local anexo del emisor


 case      
 when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'      
 else td.TipoContabilidad end   + '|' + ---Tipo de documento de identidadL del adquirente o usuario      
 CASE      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'      
 else LEFT(cl.NroDocumento,100) end  + '|' + --Número de documento de identidad del adquirente o usuario       
 case      
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then 'Clientes Varios'      
 else LEFT(cl.RazonSocial,100) end  + '|' + --Apellidos y nombres, denominación o razón social del adquirente o usuario    + '|' + --apellidos y nombres  
 'PEN' + '|' +--Tipo de moneda en la cual se emite la factura electrónica
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV)) + '|' + --Sumatoria Tributos
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) + '|' +--Total valor de venta 
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) + '|' +--Total Precio de Venta
CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))  + '|' +--Total descuentos
'0.00' + '|' + --Sumatoria otros Cargos
'0.00' + '|' + --Total Anticipos
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV)) + '|'  + --Importe total de la venta, cesión en uso o del servicio prestado
'2.1' + '|' + --Versión UBL
'2.0' + '|'--Customization Documento
 as COL1
 FROM Ventas.Comprobante AS C
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID
  INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento  
   left JOIN         
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'        
 GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID         
  left join         
  (        
  select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen        
  )        
   as AL on AL.EmpresaID = C.EmpresaID and AL.SedeID = C.SedeID    
  WHERE C.ComprobanteId =  @ID

 
-------------------------------------------------------------------
--DETALLE   
INSERT INTO #CABECERA (ID, TEXTO)  
SELECT 2,  E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.DET'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID

INSERT INTO #DETALLE (ID, TEXTO) 
SELECT 2,
  case
  when p.ProductoID = '00394000102.7' then   'ZZ' 
  when p.ProductoID = '00478000102.7' then   'ZZ' 
  when p.ProductoID = '00216000102.7' then   'ZZ'  
  when p.ProductoID = '00645050102.7' then   'ZZ' 
  when p.ProductoID = '00650000060.7' then   'ZZ' 
  when p.ProductoID = '00650000060.7' then   'ZZ'  
  when p.ProductoID = '00651050102.7' then   'ZZ' 
  when p.ProductoID = '00652050102.7' then   'ZZ'        
  when p.unidadmedidaid = 'UN' then   'NIU'        
  when p.unidadmedidaid = 'KG' then   'KGM'        
  when p.unidadmedidaid = 'MT' then   'MTR'        
  when p.unidadmedidaid = 'LT' then   'LTR'        
  when p.unidadmedidaid = 'PQ' then   'PK'        
  when p.unidadmedidaid = 'GL' then   'GLL'        
  when p.unidadmedidaid = 'GR' then   'GRM'        
  when p.unidadmedidaid = 'SC' then   'NIU'       
  else 'ERROR-' END + '|' +  --Código de unidad de medida por ítem        
  convert(varchar(23),convert(decimal(12,2),dc.Cantidad))  + '|' + --Cantidad de unidades por ítem        
  dc.ProductoID + '|' + --Código de producto        
  '-'  + '|' + --Codigo producto SUNAT        
  left(p.alias,250) + '|' + --Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando las características.        
 case when con.Esgratuito = 1 then '0.00' else CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) end  + '|' + --Valor unitario por ítem 
  '0.00'   + '|' +  --Sumatoria Tributos por item
 case when con.Esgratuito = 1 then '9996' else '9997' end + '|' +  --Tributo: Códigos de tipos de tributos IGV (GRATUITO 9996) (EXONERADO 9997)
'0.00'   + '|' +  --Tributo: Monto de IGV por ítem
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))   + '|' +  --Tributo: Base Imponible IGV por Item
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' +  --Tributo: Nombre de tributo por item
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END  + '|' +  --Tributo: Código de tipo de tributo por Item
case when con.Esgratuito = 1 then '21' ELSE '20' END  + '|' +  --Tributo: Afectación al IGV por ítem
'0.00'   + '|' +  --Tributo: Porcentaje de IGV
 

'-'   + '|' + --15	Tributo ISC: Códigos de tipos de tributos ISC
''   + '|' + --16	Tributo ISC: Monto de ISC por ítem
''   + '|' + --17	Tributo ISC: Base Imponible ISC por Item
''   + '|' + --18	Tributo ISC: Nombre de tributo por item
''   + '|' + --19	Tributo ISC: Código de tipo de tributo por Item
''   + '|' + --20	Tributo ISC: Tipo de sistema ISC
''   + '|' + --21	Tributo ISC: Porcentaje de ISC
 

'-'   + '|' + --22	Tributo Otro: Códigos de tipos de tributos OTRO
''   + '|' + --23	Tributo Otro: Monto de tributo OTRO por iItem
''   + '|' + --24	Tributo Otro: Base Imponible de tributo OTRO por Item
''   + '|' + --25	Tributo Otro:  Nombre de tributo OTRO por item
''   + '|' + --26	Tributo Otro: Código de tipo de tributo OTRO por Item
''   + '|' + --27	Tributo Otro: Porcentaje de tributo OTRO por Item
case when con.Esgratuito = 1 then '0.00' 
else CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) end + '|' + --28	"Precio de venta unitario cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice"
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario))) + '|' + --29	Valor de venta por Item cac:InvoiceLine/cbc:LineExtensionAmount
case when con.Esgratuito = 1 then
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario)))
else '0.00' end + '|'  --30	"Valor REFERENCIAL unitario (gratuitos) "
as COL1  
  FROM Ventas.DetalleComprobante dc        
  INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID        
  inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID        
  inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID        
  --WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and        
  WHERE   
    con.ComprobanteId =  @ID    
	 
 --BX|19|9100||Item 1 - Gratuito 9996|0.00|0.00|9996|0.00|190.00|GRA|FRE|21|0.00|-|0.00||ISC|EXC|01|2.00|-||||||0.00|190.00|10.00|
-------------------------------------------------------------------
--TRIBUTOS GENERALES 
INSERT INTO #CABECERA (ID, TEXTO) 
SELECT 3, E.RUC + '-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.TRI'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID
 
INSERT INTO #DETALLE (ID, TEXTO)
SELECT 3,
case when con.Esgratuito = 1 then '9996' else '9997' end + '|' + --1	Identificador de tributo
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' + --2	Nombre de tributo
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END + '|' + --3	Código de tipo de tributo
CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))) + '|' + --4	Base imponible
'0.00'   + '|'  --5	Monto de Tirbuto por ítem
as COL1
FROM Ventas.DetalleComprobante dc        
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID        
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID        
inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID        
--WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and        
WHERE   
con.ComprobanteId =  @ID    
group by con.Esgratuito 
-------------------------------------------------------------------
--LEYENDA
INSERT INTO #CABECERA (ID, TEXTO)
SELECT 4, E.RUC +'-' + CASE WHEN C.TipoComprobanteID = 4 THEN '03' ELSE '01'  END + '-' +
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.LEY'  FROM Ventas.Comprobante AS C
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID
 
INSERT INTO #DETALLE (ID, TEXTO)
select 4, ttt.COL1  from( 
SELECT 
'1000|' + [dbo].[FN_CantidadConLetraSoles](C.SubTotal + C.TotalIGV) + '|' as COL1
FROM Ventas.Comprobante AS C  WHERE C.ComprobanteId =  @ID

 union

SELECT  '2001|BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA|' as COL1
) as ttt
 


SELECT '' AS RUTA    
SELECT * FROM #CABECERA    
SELECT * FROM #DETALLE  


go

alter Procedure [Ventas].[Usp_Insert_ComprobanteManual] 
( 
 @NumComprobante char(13), 
 @EmpresaID char(2), 
 @SedeID char(5), 
 @TipoComprobanteID tinyint, 
 @ClienteID int, 
 @Direccion varchar(150), 
 @TipoVentaID tinyint, 
 @TipoPagoID tinyint, 
 @FormaPagoID tinyint, 
 @NumCaja int, 
 @NroGuia varchar(12), 
 @IGV tinyint, 
 @SubTotal decimal(12,3), 
 @TotalIGV decimal(12,3), 
 @Vendedor int, 
 @CreditoID int, 
 @Cajero int, 
 @EstadoID int, 
 @Externa bit, 
 @Vale bit, 
 @Serie char(3), 
 @NumVale int, 
 @XMLDetalle xml, 
 @NumPedido int, 
 @Tipo Char(1), 
 @AudCrea smalldatetime 
) 
As 
Begin 
 Set Nocount On 

 declare @EsGratuito bit = null

 if(@SubTotal = 0)
	set @EsGratuito = 1
 
 DECLARE @hDoc int 
 IF EXISTS(SELECT NumComprobante FROM Ventas.Comprobante WHERE NumComprobante = @NumComprobante and TipoComprobanteID = @TipoComprobanteID) 
 begin 
 declare @Message varchar(500) 
 Select @Message = 'Esta Comprobante ya ha sido ingresado con ese codigo: ' + @NumComprobante 
 RaisError(@Message, 16, 1) 
 Return 
 end 
 else 
 begin 
 Insert Into Ventas.Comprobante 
 ( 
 NumComprobante, EmpresaID, SedeID, TipoComprobanteID, ClienteID, Direccion, TipoVentaID, TipoPagoID, FormaPagoID, 
 NumCaja, NroGuia, IGV, SubTotal, TotalIGV, Vendedor, CreditoID, Cajero, EstadoID, Externa, 
 Vale, NumVale, Ingreso, AudCrea, FlgEst , EsGratuito
 ) 
 Values 
 ( 
 @NumComprobante, @EmpresaID, @SedeID, @TipoComprobanteID, @ClienteID, @Direccion, @TipoVentaID, @TipoPagoID, @FormaPagoID, 
 @NumCaja, @NroGuia, @IGV, @SubTotal, @TotalIGV, @Vendedor, @CreditoID, @Cajero, @EstadoID, @Externa, 
 @Vale, @NumVale, 'M', @AudCrea, 'True' ,@EsGratuito
 ) 
 
 Exec sp_xml_preparedocument @hDoc OUTPUT,@XMLDetalle 
 
 Insert Into Ventas.DetalleComprobante 
 ( 
 NumComprobante, TipoComprobanteID, ProductoID, Cantidad, PrecioUnitario, Importe, FechaReserva, 
 EstadoID, HistoricoPrecioID ) 
 Select 
 @NumComprobante, @TipoComprobanteID, ProductoID, Cantidad, PrecioUnitario, Importe, FechaReserva, 
 EstadoID, HistoricoPrecioID 
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido') 
 WITH 
 ( 
 ProductoID varchar(20) 'ProductoID', 
 Cantidad decimal(12,3) 'Cantidad', 
 PrecioUnitario decimal(12,3) 'PrecioUnitario', 
 Importe decimal(12,3) 'Importe', 
 FechaReserva smalldatetime 'FechaReserva', 
 EstadoID int 'EstadoID', 
 HistoricoPrecioID INT 'HistoricoPrecioID' 
 )XMLDetalleComprobante 
 
 
 --disminuir del credito disponible del cliente 
 if(isnull(@TipoPagoID,0) = 1)--venta al credito 
 Begin 
 update Ventas.Credito set 
 CreditoDisponible = CreditoDisponible - (@SubTotal + @TotalIGV), 
 UsuarioIDM = @Cajero, 
 SedeIDM = @SedeID 
 Where CreditoID = @CreditoID 
 End 
 /*else if(isnull(@TipoPagoID,0) = 2)--venta al contado 
 Begin 
 Insert into Ventas.Pago 
 ( 
 NumComprobante, TipoComprobanteID, Importe, FormaPagoID, UsuarioID, AudCrea 
 ) 
 Values 
 ( 
 @NumComprobante, @TipoComprobanteID, @SubTotal + @TotalIGV, @FormaPagoID, @Cajero, GETDATE() 
 ) 
 End*/ 
 
 if(isnull(@TipoVentaID,0) <> 3 and isnull(@TipoVentaID,0) <> 6 and @Tipo = 'D')--diferente de reserva y de diferida, Tipo = 'D' es descuento 
 Begin 
 --********** Insertar en Kardex ***************** 
 
 --Obtenemos el tipo de documento 
 declare @TipoComprobante char(2) 
 select @TipoComprobante = TipoContabilidad from Almacen.TipoDocumento where DocumentoID = @TipoComprobanteID 
 
 
 Insert Into Almacen.Kardex 
 ( 
 AlmacenID,ProductoID, Cantidad, MovimientoID, NroDocumento, TipoComprobante, Serie, Numero, 
 TipoOperacion, CostoUnitario, Ingreso, UsuarioID, AudCrea ) 
 Select 
 AlmacenID, 
 ProductoID, 
 Cantidad, 
 1, 
 cast(@TipoComprobanteID as CHAR(1)) + '-' + @NumComprobante, 
 @TipoComprobante, 
 SUBSTRING(@NumComprobante,3,3), 
 cast(right(@NumComprobante,7) as int), 
 '01', 
 PrecioUnitario, 
 'S', 
 @Cajero, 
 GETDATE() 
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido') 
 WITH 
 ( 
 AlmacenID char(10) 'AlmacenID', 
 ProductoID varchar(20) 'ProductoID', 
 Cantidad decimal(12,3) 'Cantidad', 
 PrecioUnitario decimal(12,3) 'PrecioUnitario' 
 ) XMLInsertKardex 
 where XMLInsertKardex.ProductoID not in (select ProductoID from Ventas.Servicios --excluyendo los servicios 
 union select ProductoID from Producto.Producto where IDExistencia = 6) -- excluyendo existencias que no mueven kardex 
 
 --************ Actualizar Stock ***************** 
 Update Almacen.StockAlmacen 
 Set 
 Almacen.StockAlmacen.StockActual=Almacen.StockAlmacen.StockActual - XMLUpdateStock.Cantidad, 
 Almacen.StockAlmacen.StockDisponible=Almacen.StockAlmacen.StockDisponible - XMLUpdateStock.Cantidad, 
 Almacen.StockAlmacen.AudModifica=@AudCrea 
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido') 
 WITH 
 ( 
 AlmacenID char(10) 'AlmacenID', 
 ProductoID varchar(20) 'ProductoID', 
 Cantidad decimal(12,3) 'Cantidad' 
 )XMLUpdateStock 
 WHERE 
 Almacen.StockAlmacen.AlmacenID=XMLUpdateStock.AlmacenID AND 
 Almacen.StockAlmacen.ProductoID=XMLUpdateStock.ProductoID 
 end 
 
 --ELIMINAMOS EL PEDIDO 
 Delete Ventas.DetallePedido where NumPedido=@NumPedido 
 Delete Ventas.OrdenPedido where NumPedido=@NumPedido 
 
 EXEC sp_xml_removedocument @hDoc 
 end 
 Set Nocount Off 
End 
go



--[Contabilidad].[Usp_GetConsolidadoDeVentas]  '01/01/2019','30/03/2019',4,'PE'  
alter Procedure [Contabilidad].[Usp_GetConsolidadoDeVentas]    
(    
 @FechaIni   smalldatetime,    
 @FechaFin   smalldatetime,    
 @TipoComprobanteID int,    
 @EmpresaID   char(2)    
)    
As    
Begin    
 Set Nocount On    
 declare @LetraSerie char(1) = ''  
 if(@TipoComprobanteID = 4)  
 set @LetraSerie = 'B'  
  else if(@TipoComprobanteID = 5)  
 set @LetraSerie = 'F'  
  
 --TOTAL DE VENTAS EN RABGO DE FECHA    
  Select    
  convert(smalldatetime,CONVERT(char(10), C.AudCrea, 103))     AS FECHA,    
 C.AudCrea,    
  ATD.tiposunat     AS TIPOCONTABILIDAD,    
  @LetraSerie + SUBSTRING(C.NumComprobante,3,3)   AS SERIE,    
  convert(int,RIGHT(C.NumComprobante,7)) AS NUMERO,    
  CASE C.ClienteID    
  WHEN 204    
   THEN ''    
  ELSE    
   ETD.TIPOCONTABILIDAD    
  END          AS TIPO_DOCUMENTO_IDENTIDAD,    
  CASE C.ClienteID    
  WHEN 204    
   THEN ''    
  ELSE    
   CL.NroDocumento    
  END          AS NUMERO_DOCUMENTO,    
  CASE C.ClienteID    
  WHEN 204 THEN    
   CASE C.FlgEst    
   WHEN 'TRUE'    
    THEN 'VENTA DIARIA'    
   ELSE    
    'ANULADO'    
   END    
  ELSE    
   CASE C.FlgEst    
   WHEN 'TRUE'    
    THEN CL.RazonSocial    
   ELSE    
    'ANULADO'    
   END    
  END          AS RAZON_SOCIAL,    
  CASE C.FlgEst    
  WHEN 'False'    
   THEN 0    
  ELSE    
   C.SubTotal    
  END          AS BASE_IMPONIBLE_OE,    
  0.00         AS BASE_IMPONIBLE_OG,    
  CASE C.FlgEst    
  WHEN 'False'    
   THEN 0    
  ELSE    
   C.IGV    
  END          AS IGV,  
  --C.TipoComprobanteID,  
  --C.NumComprobante,  
  C.ComprobanteId,  
   C.SubTotal + C.TotalIGV as Total    
  from Ventas.Comprobante as C    
  INNER JOIN Ventas.TipoComprobante AS ATD ON C.TipoComprobanteID = ATD.TipoComprobanteID    
  INNER JOIN Ventas.Cliente   AS CL ON CL.ClienteID = C.ClienteID    
  INNER JOIN EMPRESA.TipoDocumento AS ETD ON CL.IDTipoDocumento = ETD.IDTipoDocumento    
  where    
  convert(date,C.AudCrea) between @FechaIni and   @FechaFin    
  AND LEFT(C.NumComprobante,2) = @EmpresaID    
  and C.TipoComprobanteID = @TipoComprobanteID    
  ORDER BY FECHA, SERIE, NUMERO    
 --COMPROBANTES GENERADOS POR EMPRESA    
     
 Set Nocount Off    
End    
go

alter table Ventas.CorrelativoFacturadorSunat add  FechaEnvioSunat datetime, TipoComprobanteID int, MensajeSunat varchar(1000), GeneradoTxt bit, EstadoSunat char(2)

--Ventas.ListarFacturadorSunat 'PE', '2018-01-01', '2019-03-09',5, '01' ,1, 50      
alter procedure Ventas.ListarFacturadorSunat      
(      
@EmpresaID char(2),      
@FechaIni date,      
@FechaFin date,      
@TipoComprobanteId int,      
@EstadoSunat char(2),      
@pagenum  int,      
@pagesize int,  
@tipo smallint      
)      
as      
      
       
 if @tipo = 1  
 begin  
WITH C AS      
(       
SELECT ROW_NUMBER() OVER(ORDER BY tabla1.NumComprobante) AS rownum,  
tabla1.* from(
select    
C.ComprobanteId,      
C.NumComprobante,       
TC.TipoSunat,      
TC.NomTipoComprobante AS TipoComprobante,      
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END      
+ SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as Comprobante,      
        
CONVERT(char(10), C.AudCrea,126) as FechaEmision,       
CONVERT(varchar(10),C.AudCrea,108) as HoraEmision,      
      
case            
when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'            
else td.TipoContabilidad end as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario            
CASE            
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'            
else LEFT(cl.NroDocumento,100) end  as DocumentoCliente,             
case            
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then 'Clientes Varios'            
else LEFT(cl.RazonSocial,100) end as RazonSocial,          
'PEN' as TipoMoneda,        
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV)) as SumatoriaTributos,      
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) as ValorVenta,       
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV       
- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) as PrecioVenta,      
CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00)) as TotalDescuento,      
      
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV))  as ImporteTotal,      
C.GeneradoTxt, C.MensajeSunat,      
isnull(C.EstadoSunat, '00') as EstadoSunat, isnull(efe.Descripcion,'') as EstadoEnvio      
       
       
FROM Ventas.Comprobante AS C      
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID      
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID      
INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento        
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  C.EstadoSunat       
left JOIN               
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'              
GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID               
where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) between @FechaIni and @FechaFin       
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(4,5) and @TipoComprobanteId = 0))  
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')    

union all	 

select
cs.CorrelativoFacturadorSunatId as ComprobanteId,     

cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))
+ right('00' + convert(varchar(10),month(cs.fecha)),2)
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-' 
+ right('000' + convert(varchar(10), cs.Correlativo),3) AS NumComprobante,      
 
cs.Tipo as TipoSunat,      
case
when cs.tipo = 'RA' then 'Comunicacion de Baja'
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS TipoComprobante, 
   
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))
+ right('00' + convert(varchar(10),month(cs.fecha)),2)
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-' 
+ right('000' + convert(varchar(10),month(cs.Correlativo)),3) AS Comprobante,     
        
CONVERT(char(10), cs.Fecha,126) as FechaEmision,       
'00:00' as HoraEmision,      

'' as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario            
'' as DocumentoCliente, 
case
when cs.tipo = 'RA' then 'Comunicacion de Baja'
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS RazonSocial,        
'PEN' as TipoMoneda,        
'0.00' as SumatoriaTributos,      
'0.00'  as ValorVenta,       
'0.00' as PrecioVenta,      
'0.00'  as TotalDescuento,      
'0.00'   as ImporteTotal,      
cs.GeneradoTxt, cs.MensajeSunat,      
isnull(cs.EstadoSunat, '00') as EstadoSunat,
isnull(efe.Descripcion,'') as EstadoEnvio     
from Ventas.CorrelativoFacturadorSunat as cs
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  cs.EstadoSunat    
where cs.EmpresaID = @EmpresaID and cs.Fecha between @FechaIni and @FechaFin       
and (cs.TipoComprobanteID = @TipoComprobanteId or (cs.TipoComprobanteID in(10,11) and @TipoComprobanteId = 0))  
and (isnull(cs.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ') 
) as tabla1
   
),    
    
TotalRegistros  AS      
(
select count(t1.col) as Cantidad from(   
select 1  as col
FROM Ventas.Comprobante AS C      

where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) between @FechaIni and @FechaFin       
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(4,5) and @TipoComprobanteId = 0))  
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ') 
  
union all 
select 2 as col
from Ventas.CorrelativoFacturadorSunat as cs
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  cs.EstadoSunat    
where cs.EmpresaID = @EmpresaID and cs.Fecha between @FechaIni and @FechaFin       
and (cs.TipoComprobanteID = @TipoComprobanteId or (cs.TipoComprobanteID in(10,11) and @TipoComprobanteId = 0))  
and (isnull(cs.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ') 
) as t1        
)       
SELECT * ,(select Cantidad from TotalRegistros) as Cantidad    
FROM C      
WHERE rownum BETWEEN (@pagenum - 1) * @pagesize + 1 AND @pagenum * @pagesize ORDER BY NumComprobante ;    
     
end     
  
else if @tipo = 2  
begin  
select    
C.AudCrea as Fecha,    
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END  +    
SUBSTRING(C.NumComprobante,3,3)  as Serie,    
'''0' + RIGHT(C.NumComprobante,7) as Numero,    
TC.NomTipoComprobante,    
CASE          
when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'          
else '''' + LEFT(cl.NroDocumento,100) end  as NroDocumentoCliente,    
case              
when c.ClienteID = 0 or c.ClienteID = 1 or c.ClienteID = 204 or c.ClienteID = 241 or c.ClienteID = 3032 then 'CLIENTE VARIOS'              
else LEFT(cl.RazonSocial,500) end  as RazonSocialCliente,   
convert(decimal(12,2),C.TotalIGV + C.SubTotal) as ImporteTotal,  
isnull('''' +efe.Codigo, '''00') as [Codigo sunat] ,  
isnull(efe.Descripcion, 'Sin Estado')  as [Estado Sunat],  
C.MensajeSunat  
    
from ventas.Comprobante as C    
inner join ventas.TipoComprobante as TC on TC.TipoComprobanteID  = c.TipoComprobanteID    
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID    
left join ventas.EstadoFacturacionElectronica as efe on efe.Codigo = c.EstadoSunat  
where C.EmpresaID = @EmpresaID and CONVERT(date,c.AudCrea) between @FechaIni and @FechaFin    
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')  
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(4,5) and @TipoComprobanteId = 0))  
order by NomTipoComprobante, Serie, Numero    
end      
 go


    
alter procedure Ventas.ActualizarDesdeFacturadorSunat  
(  
@EmpresaID char(2),  
@NumComprobante varchar(20),  
@TipoComprobanteID int,  
@fechaenvio datetime,  
@mensaje varchar(500),  
@EstadoSunat char(2)  
)  
as  
 if(@TipoComprobanteID = 4 or @TipoComprobanteID = 5)
 begin
	update ventas.Comprobante set FechaEnvioSunat = @fechaenvio, MensajeSunat = @mensaje, EstadoSunat = @EstadoSunat  
	where NumComprobante = @NumComprobante and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID  
 end
 else if(@TipoComprobanteID = 10 or @TipoComprobanteID = 11)
 begin
 --RA-20190306-001
	update ventas.CorrelativoFacturadorSunat set FechaEnvioSunat = @fechaenvio, MensajeSunat = @mensaje, EstadoSunat = @EstadoSunat  
	where 
	Tipo + '-' + convert(varchar(10), year(Fecha)) + right('00' + convert(varchar(10),month(fecha)),2)
	+ right('00' + convert(varchar(10),day(fecha)),2) + '-' + right('000' + convert(varchar(10), Correlativo),3) = @NumComprobante 
	and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID  
 end
go

alter procedure Ventas.GenerarTxtFacturadorSunatResumenDiario    
(    
@fecha date,    
@EmpresaID char(2),    
@TipoComprobanteID int    
)    
as    
declare @Message varchar(500)   
  
if not exists(select *  
FROM Ventas.Comprobante AS C     
WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID    
and c.FlgEst = 0  and GeneradoBajaId is null)  
begin    
   Select @Message = 'No hay comprobantes anulados para generar del día ' +  convert(varchar(10), @fecha , 103)  
   RaisError(@Message, 16, 1)    
   Return    
end    
  
if (  
(select count(*)  
FROM Ventas.Comprobante AS C     
WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID    
and c.FlgEst = 0  and GeneradoBajaId is null) !=   
(select count(*)  
FROM Ventas.Comprobante AS C     
WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID    
and c.FlgEst = 0  and GeneradoBajaId is null and EstadoSunat in('03', '04', '05', '11', '12'))  
)  
begin    
   Select @Message = 'alguno de comprobantes aún no han sido enviados a sunat. Fecha: ' +  convert(varchar(10), @fecha , 103)  
   RaisError(@Message, 16, 1)    
   Return    
end    
  
  
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\'     
     
--obtener correlativo    
declare @cor int    
declare @CorrelativoFacturadorSunatId int  
select @cor = max(Correlativo) from     
Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,GETDATE()) and Tipo = 'RC'    
    
set @cor  = ISNULL(@cor,0) + 1    
    
insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo,TipoComprobanteID)    
values(@EmpresaID,convert(date,GETDATE()),@cor, 'RC', 10)    
  
set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()  
  
CREATE TABLE #CABECERA    
(    
ID INT,    
TEXTO VARCHAR(8000)    
)    
    
CREATE TABLE #DETALLE    
(    
ID INT,    
TEXTO VARCHAR(8000)    
)    
    
INSERT INTO #CABECERA (ID, TEXTO)    
SELECT 1,   E.RUC + '-RC-' +    
convert(char(4),YEAR(getdate())) + right('00' + convert(varchar(2),month(getdate())),2)    
  + right('00' + convert(varchar(2),day(getdate())),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.RDI' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E     
  WHERE   E.EmpresaID = @EmpresaID      
    
      
INSERT INTO #DETALLE (ID, TEXTO)    
select 1,    
    
CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento    
CONVERT(char(10), getdate(),126) + '|' + --2 Fecha de generación del resumen    
'03' + '|'+ --3 Tipo de documento de resumen (boleta)    
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END +     
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '|' + --4 Serie y número de documento    
 case          
 when cL.ClienteID = 0 or cL.ClienteID = 1 or cL.ClienteID = 204 or cL.ClienteID = 241 or cL.ClienteID = 3032 then '0'          
 else td.TipoContabilidad end   + '|' + --5 Tipo de documento de Identidad del adquirente o usuario     
 CASE          
 when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'          
 else LEFT(cl.NroDocumento,100) end  + '|' + --6 Número de documento del adquirente o usuario     
 'PEN' + '|' + --7 Tipo de Moneda    
'0.00' + '|' + --8 Total valor de venta - operaciones gravadas    
CONVERT(varchar(14),convert(decimal(12,2),c.SubTotal)) + '|' + --9 Total valor de venta - operaciones exoneradas    
'0.00' + '|' + --10 Total valor de venta - operaciones inafectas    
'0.00' + '|' + --11 Total valor de venta - operaciones gratuitas    
'0.00' + '|' + --12 Importe total de sumatoria otros cargos del ítem    
'0.00' + '|' + --13 Total ISC    
CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV)) + '|' + --14 Total IGV    
'0.00' + '|' + --15 Total Otros tributos    
 CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV + c.SubTotal)) + '|' + --16 Importe total de la venta, cesión en uso o del servicio prestado    
'' + '|' + --17 Tipo de documento que modifica    
'' + '|' + --18 Número de serie de la boleta de venta que modifica    
'' + '|' + --19 Número correlativo de la boleta de venta que modifica    
'' + '|' + --20 Régimen de percepción    
'' + '|' + --21 Porcentaje de Percepcion    
'' + '|' + --22 Base imponible percepción     
'' + '|' + --23 Monto de la percepción    
'' + '|' + --24 "Monto total a cobrar incluida lapercepción"    
'3' + '|' --25 Estado    
as  COL1    
FROM Ventas.Comprobante AS C    
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID    
  INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento      
   left JOIN             
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'            
 GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID             
  left join             
  (            
  select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen            
  )            
   as AL on AL.EmpresaID = C.EmpresaID and AL.SedeID = C.SedeID        
  WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID    
  and c.FlgEst = 0  and GeneradoBajaId is null  
    
  update ventas.Comprobante set GeneradoBajaId = @CorrelativoFacturadorSunatId , FechaBajaSunat = GETDATE()  
  WHERE convert(date,AudCrea) =  @fecha and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID and FlgEst = 0  
    
  SELECT @UNIDADRAIZ AS RUTA    
  SELECT * FROM #CABECERA    
  SELECT * FROM #DETALLE    
 go

alter procedure Ventas.GenerarTxtFacturadorSunatComunicacionBaja    
(     
@EmpresaID char(2),    
@NumComprobante CHAR(13),    
@MotivoBaja varchar(100)    
)    
as  
  
declare @Message varchar(500)   
  
if not exists(select *  
FROM Ventas.Comprobante AS C     
WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5   
 and c.FlgEst = 0  and GeneradoBajaId is null)  
begin    
   Select @Message = 'No está anulada la factura '    
   RaisError(@Message, 16, 1)    
   Return    
end    
  
if (  
(select count(*)  
FROM Ventas.Comprobante AS C     
WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5   
 and c.FlgEst = 0  and GeneradoBajaId is null) !=   
(select count(*)  
FROM Ventas.Comprobante AS C     
WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5   
 and FlgEst = 0  and GeneradoBajaId is null and EstadoSunat in('03', '04', '05', '11', '12'))  
)  
begin    
   Select @Message = 'la factura no ha sido enviado a sunat.'   
   RaisError(@Message, 16, 1)    
   Return    
end    
   
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\'     
     
--obtener correlativo    
declare @cor int  
declare @CorrelativoFacturadorSunatId int  
  
select @cor = max(Correlativo) from     
Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,GETDATE()) and Tipo = 'RA'    
    
set @cor  = ISNULL(@cor,0) + 1    
    
insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo, TipoComprobanteID)    
values(@EmpresaID,convert(date,GETDATE()),@cor, 'RA',11)    
  
set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()  
  
  
CREATE TABLE #CABECERA    
(    
ID INT,    
TEXTO VARCHAR(8000)    
)    
    
CREATE TABLE #DETALLE    
(    
ID INT,    
TEXTO VARCHAR(8000)    
)    
    
INSERT INTO #CABECERA (ID, TEXTO)    
SELECT 1,   E.RUC + '-RA-' +    
convert(char(4),YEAR(getdate())) + right('00' + convert(varchar(2),month(getdate())),2)    
  + right('00' + convert(varchar(2),day(getdate())),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.CBA' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E     
  WHERE   E.EmpresaID = @EmpresaID      
    
      
INSERT INTO #DETALLE (ID, TEXTO)    
SELECT 1,    
CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento    
CONVERT(char(10), getdate(),126) + '|' + --2 Fecha de generación del resumen    
'01'+ '|' +  --Tipo de documento de baja    
CASE WHEN C.TipoComprobanteID = 4 THEN 'B' ELSE 'F'  END +     
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '|' + --Número de documento de baja    
@MotivoBaja + '|' --Descripción de motivo de baja    
FROM VENTAS.Comprobante AS C WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5   
 and c.FlgEst = 0  and GeneradoBajaId is null   
  
  update ventas.Comprobante set GeneradoBajaId = @CorrelativoFacturadorSunatId , FechaBajaSunat = GETDATE()  
  WHERE NumComprobante = @NumComprobante AND EmpresaID = @EmpresaID AND TipoComprobanteID = 5  and FlgEst = 0 and GeneradoBajaId is null  
   
      
  SELECT @UNIDADRAIZ AS RUTA    
  SELECT * FROM #CABECERA    
  SELECT * FROM #DETALLE    
  go