 ALTER table VENTAS.Comprobante add TotalICBPER decimal(18,2)
   ALTER table Ventas.OrdenPedido add TotalICBPER decimal(18,2)
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
select top 500 1,      
      
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
 case when C.TotalICBPER  > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),c.TotalICBPER),0.00)) else  '0.00' end + '|' + --15 Total Otros tributos          
  CONVERT(varchar(14),convert(decimal(12,2),c.TotalIGV + c.SubTotal + isnull(c.TotalICBPER,0))) + '|' + --16 Importe total de la venta, cesión en uso o del servicio prestado         
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
        
  WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID      
  and c.FlgEst = 0  and GeneradoBajaId is null    
      
  update ventas.Comprobante set GeneradoBajaId = @CorrelativoFacturadorSunatId , FechaBajaSunat = GETDATE()    
    WHERE  ComprobanteId in(  
 select top 500 C.ComprobanteId FROM Ventas.Comprobante AS C          
   WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID    and FlgEst = 0       
   
 )    
      
  SELECT @UNIDADRAIZ AS RUTA      
  SELECT * FROM #CABECERA      
  SELECT * FROM #DETALLE   
  go   

 
 
 SELECT * FROM Producto.Producto WHERE ALIAS LIKE '%ICB%'

 select * from ventas.Comprobante where convert(date, audcrea) = '2019-08-04'


insert into Empresa.Grupo values(2,'Productos Sujetos a impuesto bolsas plasticas')
insert into Empresa.GrupoDetalle values(1,2,'BOLSA MEDIANA ICBPER',	'00264000001.10',1)
insert into Empresa.GrupoDetalle values(2,2,'BOLSA GRANDE ICBPER',	'00611000102.7',2)
/*
F001-00002841 generado con clientes varios	
https://demo-ose.nubefact.com/ol-ti-itcpe/billService?wsdl
https://ose.nubefact.com/ol-ti-itcpe/billService?wsdl

*/

alter PROCEDURE [Ventas].[ObtenerTxtFacturadorSunat]    
(    
@ID BIGINT     
)    
as    
--DECLARE @ID BIGINT = 2479196    
--DECLARE @UNIDADRAIZ VARCHAR(500) = '',     
--@NOMBREARCHIVOCAB varchar(250), @NOMBREARCHIVOLEY varchar(250), @NOMBREARCHIVODET varchar(250),    
--@NOMBREARCHIVOTRI varchar(250)    
DECLARE @Cadena    varchar(max)     
     
declare @impuestobolsa decimal(18,2)

select @impuestobolsa = CONVERT(decimal(18,2),Valor) from Empresa.GrupoDetalle
where Descripcion = (select convert(varchar(50), YEAR(AudCrea)) from ventas.Comprobante as C WHERE C.ComprobanteId =  @ID)
and GrupoId = 1
  
    
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
SUC.CodigoAlmacenSunat + '|' + --'0001' + '|' +--Código del domicilio fiscal o de local anexo del emisor    
    
    
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
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV) + isnull(C.TotalICBPER,0.00)) + '|' + --Sumatoria Tributos  
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) + '|' +--Total valor de venta      
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV + isnull(C.TotalICBPER,0.00)- ISNULL(convert(decimal(12,2),Descuento.Importe  * -1),0.00))) + '|' +--Total Precio de Venta  
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
  INNER JOIN Empresa.Sucursal AS SUC ON SUC.EmpresaID= C.EmpresaID AND SUC.SedeID = C.SedeID    
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
     
    
'-'   + '|' + --15 Tributo ISC: Códigos de tipos de tributos ISC    
''   + '|' + --16 Tributo ISC: Monto de ISC por ítem    
''   + '|' + --17 Tributo ISC: Base Imponible ISC por Item    
''   + '|' + --18 Tributo ISC: Nombre de tributo por item    
''   + '|' + --19 Tributo ISC: Código de tipo de tributo por Item    
''   + '|' + --20 Tributo ISC: Tipo de sistema ISC    
''   + '|' + --21 Tributo ISC: Porcentaje de ISC    
 
  
    
 case when con.TotalICBPER > 0 then '9999' else  '-' end  + '|' + --22	Tributo Otro: Códigos de tipos de tributos OTRO
case when con.TotalICBPER > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.Cantidad * @impuestobolsa),0.00)) else  '' end  + '|' + --23	Tributo Otro: Monto de tributo OTRO por iItem
case when con.TotalICBPER > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.Importe),0.00)) else  '' end   + '|' + --24	Tributo Otro: Base Imponible de tributo OTRO por Item
case when con.TotalICBPER > 0 then 'OTROS' else  '' end   + '|' + --25	Tributo Otro:  Nombre de tributo OTRO por item
case when con.TotalICBPER > 0 then 'OTH' else  '' end  + '|' + --26	Tributo Otro: Código de tipo de tributo OTRO por Item
case when con.TotalICBPER > 0 then '0.00' else  '' end   + '|' + --27	Tributo Otro: Porcentaje de tributo OTRO por Item  
case when con.Esgratuito = 1 then '0.00'     
else CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00)) end + '|' + --28 "Precio de venta unitario cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice"    
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario))) + '|' + --29 Valor de venta por Item cac:InvoiceLine/cbc:LineExtensionAmount    
case when con.Esgratuito = 1 then    
CONVERT(varchar(14),(convert(decimal(12,2),dc.Cantidad * dc.PrecioUnitario)))    
else '0.00' end + '|'  --30 "Valor REFERENCIAL unitario (gratuitos) "    
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
case when con.Esgratuito = 1 then '9996' else '9997' end + '|' + --1 Identificador de tributo    
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' + --2 Nombre de tributo    
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END + '|' + --3 Código de tipo de tributo    
CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.PrecioUnitario),0.00))) + '|' + --4 Base imponible    
'0.00'   + '|'  --5 Monto de Tirbuto por ítem    
as COL1    
FROM Ventas.DetalleComprobante dc            
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID            
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID            
inner join [Ventas].[TipoComprobante] as tc on tc.TipoComprobanteID = con.TipoComprobanteID            
--WHERE dc.ProductoID NOT IN( '00267000102.7','00216000102.7') and            
WHERE       
con.ComprobanteId =  @ID        
group by con.Esgratuito     

 if  exists(SELECT *
FROM Ventas.DetalleComprobante dc              
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID              
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID                
WHERE         
con.ComprobanteId =  @ID  
and dc.ProductoID IN(select Valor from Empresa.GrupoDetalle where GrupoId = 2) )
begin
	INSERT INTO #DETALLE (ID, TEXTO)
	SELECT 3,  
	'9999|' + --1 Identificador de tributo      
	'OTROS|' + --2 Nombre de tributo      
	'OTH|' + --3 Código de tipo de tributo      
	CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.Importe),0.00))) + '|' + --4 Base imponible      
	CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.Cantidad * @impuestobolsa),0.00))) + '|'  --5 Monto de Tirbuto por ítem      
	as COL1      
	FROM Ventas.DetalleComprobante dc              
	INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID              
	inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID                
	WHERE         
	con.ComprobanteId =  @ID  
	and dc.ProductoID IN(select Valor from Empresa.GrupoDetalle where GrupoId = 2) 
end
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


  create procedure Ventas.Usp_GetProductosImpuestoBolsa
 as
  select * from Empresa.GrupoDetalle where GrupoId = 1 and Descripcion = CONVERT(varchar(10), year(getdate()))
  union
   select * from Empresa.GrupoDetalle where GrupoId = 2 
 go

 /************************************************************************************************************  
Autor  : julio Cesar Anyosa Candela  
Fecha  : 07/11/2011  
Descripción : Listar registros de la tabla de base de datos   
Prueba  :        
*************************************************************************************************************/   
alter Procedure [Ventas].[Usp_InsertOrdenPedido]  
(  
 @ClienteID    int,  
 @TipoVentaID   tinyint,  
 @TipoComprobanteID  tinyint,  
 @TipoPagoID    tinyint,  
 @FormaPagoID   tinyint,  
 @IGV     int,  
 @SubTotal    decimal(12,3),  
 @TotalIGV    decimal(12,3),   
 @UsuarioID    int,  
 @EmpresaID    char(2),  
 @SedeID     char(5),  
 @Comentario    varchar(300),  
 @Externa    bit,  
 @Vale     bit,  
 @NumVale    int,  
 @XMLDetalle    XML ,
 @TotalICBPER decimal(18,2) 
)  
As   
Begin  
 Set Nocount On  
   
 DECLARE @hDoc int  
 DECLARE @NumPedido int  
  EXEC sp_xml_preparedocument @hDoc OUTPUT,@XMLDetalle  
   
 Insert Into Ventas.OrdenPedido  
 (  
  ClienteID,  
  TipoVentaID,  
  TipoComprobanteID,  
  TipoPagoID,  
  FormaPagoID,  
  IGV,  
  SubTotal,  
  TotalIGV,  
  FechaPedido,  
  UsuarioID,  
  EmpresaID,  
  SedeID,  
  Comentario,  
  Externa,  
  Vale,  
  NumVale,
  TotalICBPER  
 )  
 Values  
 (  
  @ClienteID,  
  @TipoVentaID,  
  @TipoComprobanteID,  
  @TipoPagoID,  
  @FormaPagoID,  
  @IGV,  
  @SubTotal,  
  @TotalIGV,  
  GETDATE(),  
  @UsuarioID,  
  @EmpresaID,  
  @SedeID,  
  @Comentario,  
  @Externa,  
  @Vale,  
  @NumVale,
  @TotalICBPER    
 )  
   
 Set @NumPedido=SCOPE_IDENTITY()  
   
  Insert Into Ventas.DetallePedido  
  (  
   NumPedido,  
   ProductoID,  
   Cantidad,  
   PrecioUnitario,  
   Importe,  
   FechaReserva,  
   AlmacenID,  
   HistoricoPrecioID  
  )  
  Select  
   @NumPedido,  
   Codigo,  
   Cantidad,  
   PrecioUnitario,  
   Importe,  
   FechaReserva,  
   AlmacenID,  
   HistoricoPrecioID  
  FROM OPENXML(@hDoc, '/DocumentElement/OrdenPedido')  
  WITH  
  (  
   Codigo   varchar(20)  'Codigo',  
   Cantidad  decimal(12,3) 'Cantidad',  
   PrecioUnitario decimal(12,3) 'PrecioUnitario',  
   Importe   decimal(12,3) 'Importe',  
   FechaReserva smalldatetime 'FechaReserva',  
   AlmacenID  char(10)  'AlmacenID',  
   HistoricoPrecioID INT   'HistoricoPrecioID'  
  )  XMLDetallePedido    
   
 EXEC sp_xml_removedocument @hDoc     
   
 Select @NumPedido  
   
 Set Nocount Off  
End  
go

/************************************************************************************************************    
Autor  : Julio Cesar    
Fecha  : 02/05/2011    
Descripción : Listar registros de la tabla de base de datos     
Prueba         
*************************************************************************************************************/    
Alter Procedure [Ventas].[Usp_get_OrdenPedido2]    
(    
 @NumPedido  int    
)    
as    
Begin    
 Set Nocount On    
     
  Select    
   Op.ClienteID,    
   Op.TipoVentaID,    
   case when cb.Descripcion is not null then cb.Descripcion else C.RazonSocial end as RazonSocial,    
   C.NroDocumento,    
   Td.TipoDocumento,    
   C.Direccion,    
   Op.TipoComprobanteID,    
   Op.TipoPagoID,    
   Op.FormaPagoID,    
   Op.IGV,    
   Op.SubTotal,    
   Op.TotalIGV,    
   Op.UsuarioID,    
   U.Descripcion,    
   Op.Comentario,    
   Op.Externa,    
   Op.Vale,    
   Op.NumVale,    
   E.NomEmpresa,    
   E.RUC,    
   E.EmpresaID,    
   C.IDTipoDocumento,
   isnull(Op.TotalICBPER,0) as TotalICBPER
  From     
   Ventas.OrdenPedido Op  
   Inner join Ventas.Cliente C   ON Op.ClienteID=C.ClienteID    
   Inner join Empresa.TipoDocumento Td  ON C.IDTipoDocumento=Td.IDTipoDocumento    
   Inner join Usuario.Usuario U  ON Op.UsuarioID=U.UserID    
   Inner join Empresa.Empresa E  ON E.EmpresaID = Op.EmpresaID    
   left join ventas.ClienteBoleta as cb on cb.ComprobanteId = op.NumPedido and cb.Tipo = 'P'  
  Where    
   Op.NumPedido=@NumPedido    
   /*Op.EmpresaID=@EmpresaID and    
   Op.SedeID=@SedeID*/    
       
  Select    
   dp.ProductoID,    
   P.Alias,    
   P.UnidadMedidaID,    
   dp.PrecioUnitario,    
   dp.Cantidad,    
   dp.Importe,    
   dp.FechaReserva,    
   (p.Peso * dp.Cantidad) as PesoNeto,    
   dp.AlmacenID,    
   dp.HistoricoPrecioID    
  From    
   Ventas.DetallePedido dp Inner Join Producto.Producto p  On Dp.ProductoID=P.ProductoID    
  
  Where    
   dp.NumPedido=@NumPedido             
             
 Set Nocount Off    
End  
go


/************************************************************************************************************    
Autor  : Juan Carlos    
Fecha  : 02/05/2011    
Descripción : Listar registros de la tabla de base de datos   
Prueba  :    
*************************************************************************************************************/   
alter Procedure [Ventas].[Usp_Insert_Comprobante2]    
(    
 @EmpresaID  char(2),    
 @SedeID char(5),    
 @TipoComprobanteID  tinyint,    
 @ClienteID  int,    
 @Direccion  varchar(150),    
 @TipoVentaID tinyint,    
 @TipoPagoID  tinyint,    
 @FormaPagoID tinyint,    
 @NumCaja  int,    
 @NroGuia  varchar(12),    
 @IGV tinyint,    
 @SubTotal  decimal(12,3),    
 @TotalIGV  decimal(12,3),    
 @Vendedor  int,    
 @CreditoID  int,    
 @Cajero int,    
 @EstadoID  int,    
 @Externa  bit,    
 @Vale bit,    
 @Serie char(3),    
 @NumVale  int,    
 @XMLDetalle  xml,    
 @NumPedido  int,    
 @Tipo Char(1),    
 @TipoTicket char(1)    
)    
As    
Begin    
 Set Nocount On    
    
 DECLARE @hDoc int    
 DECLARE @NumComprobante char(13)    
 DECLARE @NumGuia int    
 DECLARE @NumGuiaS char(7)    
 DECLARE @EmpresaSede char(7)    
 DECLARE @FECHA_ACTUAL SMALLDATETIME = GETDATE()    
 declare @TotalICBPER decimal(18,2)   
 
 declare @impuestobolsa decimal(18,2)

select @impuestobolsa = CONVERT(decimal(18,2),Valor) from Empresa.GrupoDetalle
where Descripcion = (convert(varchar(50), YEAR(GETDATE())) )
and GrupoId = 1 
 
    
 Set @EmpresaSede=@EmpresaID+@SedeID    
 Select @NumGuia = Numero From ventas.SerieGuia Where EmpresaSede = @EmpresaSede and Serie =@Serie and TipoDocumento = @TipoComprobanteID    
 Set @NumGuiaS = RIGHT('0000000' + cast(@NumGuia + 1  as varchar(7)), 7)    
 Select @NumComprobante = left(@EmpresaSede,2) + @Serie + '-' + @NumGuiaS    
 

 
 --actualizar el nuevo numero de guia   
 update ventas.SerieGuia set Numero = @NumGuia + 1 Where EmpresaSede = @EmpresaSede and Serie =@Serie and TipoDocumento = @TipoComprobanteID    
 
   Exec sp_xml_preparedocument @hDoc OUTPUT,@XMLDetalle      

  Select    @TotalICBPER =     
   sum(Cantidad * @impuestobolsa)
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')        
 WITH        
 (        
  ProductoID  varchar(20)  'ProductoID',        
  Cantidad  decimal(12,3) 'Cantidad',        
  PrecioUnitario decimal(12,3) 'PrecioUnitario',        
  Importe   decimal(12,3) 'Importe',        
  FechaReserva smalldatetime 'FechaReserva',        
  EstadoID  int    'EstadoID',        
  HistoricoPrecioID INT   'HistoricoPrecioID'        
 )XMLDetalleComprobante        
  where XMLDetalleComprobante.ProductoID IN(select Valor from Empresa.GrupoDetalle where GrupoId = 2) 
    
 declare @id bigint   
 Insert Into Ventas.Comprobante    
 (    
  NumComprobante, EmpresaID,   SedeID,    TipoComprobanteID,    ClienteID,    Direccion,    TipoVentaID,    TipoPagoID,    FormaPagoID,    
  NumCaja,    NroGuia,    IGV,    SubTotal,    TotalIGV,    Vendedor,    CreditoID,    Cajero,    EstadoID,    Externa,    Vale,    NumVale,    
  Ingreso,    AudCrea,    FlgEst,    TipoTicket, TotalICBPER   )    
 Values    
 (    
  @NumComprobante,   @EmpresaID,    @SedeID,    @TipoComprobanteID,    @ClienteID,    @Direccion,    @TipoVentaID,    @TipoPagoID,    @FormaPagoID,    
  @NumCaja,    @NroGuia,    @IGV,    @SubTotal,    @TotalIGV,    @Vendedor,    @CreditoID,    @Cajero,    @EstadoID,    @Externa,    @Vale,  @NumVale,    
  'A',    @FECHA_ACTUAL,    'True',   @TipoTicket , @TotalICBPER   
 )    
 set @id = SCOPE_IDENTITY()    
   
 
   
 Insert Into Ventas.DetalleComprobante    
 (    
  NumComprobante,    TipoComprobanteID,    ProductoID,    Cantidad,    PrecioUnitario,    Importe,    FechaReserva,    EstadoID,  HistoricoPrecioID    
 )    
 Select    
  @NumComprobante,  @TipoComprobanteID,    ProductoID,  Cantidad, PrecioUnitario, Importe,  FechaReserva,  EstadoID,  HistoricoPrecioID    
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')    
 WITH    
 (    
  ProductoID  varchar(20)  'ProductoID',    
  Cantidad  decimal(12,3) 'Cantidad',    
  PrecioUnitario decimal(12,3) 'PrecioUnitario',    
  Importe decimal(12,3) 'Importe',    
  FechaReserva smalldatetime 'FechaReserva',    
  EstadoID  int  'EstadoID',    
  HistoricoPrecioID INT 'HistoricoPrecioID'    
 )XMLDetalleComprobante    
   
  ---------------------------------------------------------------------------------------------------  
 --insertamos los puntos  
 insert into Ventas.PuntosClientes(Puntos,ComprobanteId, ClienteID, Fecha, Usuario)  
 Select    
 convert(int,sum(lp.Puntos * Cantidad)) as puntos,   @id, @ClienteID, @FECHA_ACTUAL, @Cajero  
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')    
 WITH    
 (    
  ProductoID  varchar(20)  'ProductoID',    
  Cantidad  decimal(12,3) 'Cantidad',    
  PrecioUnitario decimal(12,3) 'PrecioUnitario',    
  Importe decimal(12,3) 'Importe',    
  FechaReserva smalldatetime 'FechaReserva',    
  EstadoID  int  'EstadoID',    
  HistoricoPrecioID INT 'HistoricoPrecioID'    
 )XMLDetalleComprobante  
 inner join Producto.ListaPrecio as lp on lp.ProductoID = XMLDetalleComprobante.ProductoID  
 and lp.EmpresaID = @EmpresaID and lp.SedeID = @SedeID where lp.Puntos >0  
 ---------------------------------------------------------------------------------------------------  
  
  
 --disminuir del credito disponible del cliente    
 if(isnull(@TipoPagoID,0) = 1)--venta al credito    
 Begin    
  update Ventas.Credito set   
 CreditoDisponible = CreditoDisponible - (@SubTotal + @TotalIGV),    
 UsuarioIDM = @Cajero,    
 SedeIDM = @SedeID    
  Where CreditoID = @CreditoID    
 End    
      
   
 if(isnull(@TipoVentaID,0) <> 3 and isnull(@TipoVentaID,0) <> 6 and @Tipo = 'D')--diferente de reserva y de diferida, Tipo = 'D' es descuento    
 Begin    
  --********** Insertar en Kardex *****************    
  --Obtenemos el tipo de documento    
  declare @TipoComprobante char(2)    
  select @TipoComprobante = TipoContabilidad from Almacen.TipoDocumento where DocumentoID = @TipoComprobanteID    
    
 Insert Into Almacen.Kardex    
  (    
  AlmacenID,    ProductoID,    Cantidad,    MovimientoID,    NroDocumento,    TipoComprobante,    Serie,    Numero,    TipoOperacion,    
  CostoUnitario,    Ingreso,    UsuarioID,    AudCrea    )    
  Select    
  AlmacenID,    ProductoID,    Cantidad,    1,    cast(@TipoComprobanteID as CHAR(1)) + '-' + @NumComprobante,    @TipoComprobante,    SUBSTRING(@NumComprobante,3,3),    
  cast(right(@NumComprobante,7) as int),    '01',    
  PrecioUnitario,   'A',    @Cajero,    @FECHA_ACTUAL    
 FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')    
 WITH    
 (    
 AlmacenID  char(10)  'AlmacenID',    
 ProductoID  varchar(20)  'ProductoID',    
 Cantidad  decimal(12,3) 'Cantidad',    
 PrecioUnitario decimal(12,3) 'PrecioUnitario'    
 )  XMLInsertKardex    
  where XMLInsertKardex.ProductoID not in (select  ProductoID from Ventas.Servicios --excluyendo los servicios    
  union select ProductoID from Producto.Producto where IDExistencia = 6) -- excluyendo existencias que no mueven kardex    
    
  --************ Actualizar Stock *****************    
  Update Almacen.StockAlmacen    
  Set   
 Almacen.StockAlmacen.StockActual=Almacen.StockAlmacen.StockActual - XMLUpdateStock.Cantidad,    
 Almacen.StockAlmacen.StockDisponible=Almacen.StockAlmacen.StockDisponible - XMLUpdateStock.Cantidad,    
 Almacen.StockAlmacen.AudModifica=@FECHA_ACTUAL    
  FROM OPENXML(@hDoc, '/DocumentElement/detallePedido')   
 WITH    
 (    
  AlmacenID  char(10)  'AlmacenID',    
  ProductoID  varchar(20)  'ProductoID',    
  Cantidad  decimal(12,3) 'Cantidad'    
 )XMLUpdateStock    
 WHERE    
  Almacen.StockAlmacen.AlmacenID=XMLUpdateStock.AlmacenID AND    
  Almacen.StockAlmacen.ProductoID=XMLUpdateStock.ProductoID    
 end    
   
 --ELIMINAMOS EL PEDIDO    
 Delete Ventas.DetallePedido where NumPedido=@NumPedido    
 Delete Ventas.OrdenPedido where NumPedido=@NumPedido    
   
 EXEC sp_xml_removedocument @hDoc    
    
    
    
 Select @NumComprobante as NumComprobante, @FECHA_ACTUAL as FECHA_ACTUAL, @id as id    
   
   
   
 Set Nocount Off    
End    
go

--Ventas.ObtenerParaImpresion 112    
alter procedure Ventas.ObtenerParaImpresion    
(    
@ComprobanteId bigint    
)    
as    
select    
C.AudCrea,C.TipoComprobanteID,c.NumComprobante, SubTotal + TotalIGV as Monto,    
c.TotalIGV,emp.RUC,emp.NomEmpresa,vt.Descripcion as NomCaja,C.EmpresaID,    
 CASE            
  when cl.ClienteID = 0 or cl.ClienteID = 1 or cl.ClienteID = 204 or cl.ClienteID = 241 or cl.ClienteID = 3032 then '0'            
  else   LEFT(cl.NroDocumento,100) end  as NroDocumentoCliente,      
   case                
  when c.ClienteID = 0 or c.ClienteID = 1 or c.ClienteID = 204 or c.ClienteID = 241 or c.ClienteID = 3032 then 'CLIENTE VARIOS'                
  else LEFT(cl.RazonSocial,500) end  as RazonSocialCliente,     
cl.Direccion as DireccionCliente, isnull(C.TotalICBPER ,0) as TotalICBPER 
from ventas.Comprobante C    
inner join Empresa.Empresa as emp on emp.EmpresaID = c.EmpresaID    
inner join Ventas.Terminal as vt on vt.Numcaja  = C.NumCaja    
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID      
where C.ComprobanteId = @ComprobanteId    
    
select     
dc.Cantidad,pro.UnidadMedidaID,pro.Alias, dc.PrecioUnitario,dc.Importe    
from ventas.Comprobante C    
inner join Ventas.DetalleComprobante as dc on dc.TipoComprobanteID = c.TipoComprobanteID    
and dc.NumComprobante = c.NumComprobante    
inner join Producto.Producto as pro on pro.ProductoID = dc.ProductoID    
where C.ComprobanteId = @ComprobanteId    
go

/************************************************************************************************************  
Autor  : Juan Carlos  
Fecha  : 13/05/2011  
Descripción : Listar registros de la tabla de base de datos   
Prueba  : [ventas].[usp_GetDetalleVentasComprobante] '12/07/2011', '12/8/2011', 52, 'GH', '001VU'  
*************************************************************************************************************/  
alter Procedure [Ventas].[usp_GetDetalleVentasComprobante]  
(  
 @FechaIni smalldatetime,  
 @FechaFin smalldatetime,  
 @Cajero  int,  
 @EmpresaID char(2),  
 @SedeID  char(5)  
)  
As  
Begin  
   select  
    N.AudCrea   as AudCrea,  
    convert(varchar(13),N.NotaIngresoID) as NumComprobante,  
    Case N.Tipo  
    when 'C'  
     then '*SALDO INICIAL'  
    when 'A'  
     then '*INGRESO'  
    when 'E'  
     then '*EGRESO'  
    end as NomTipoComprobante,  
    N.Importe   as TotalComprobante,  
    N.Importe   as Pagado,  
    'PAGADO'   as NomEstado,  
    'EFECTIVO'   as NomFormaPago,  
    'True'    as FlgEst,  
    ''     as Ingreso  
   from Ventas.NotaIngreso as N  
   where N.UsuarioID = @Cajero  
   and LugarPago = @SedeID  
   and N.Tipo in('C','E', 'A')--comienzo del dia, egreso y Adelanto  
   and N.EmpresaID = @EmpresaID  
   And N.AudCrea between @FechaIni and @FechaFin  
   union all  
  
   Select  
    C.AudCrea,  
    C.NumComprobante,  
    TD.NomTipoComprobante,  
    C.Subtotal + C.TotalIGV + isnull(C.TotalICBPER,0) as TotalComprobante,  
    PA.Importe as Pagado,  
    E.NomEstado,  
    FP.NomFormaPago,  
    FlgEst,  
    Ingreso  
   from ventas.Comprobante as C  
   --Inner Join ventas.DetalleComprobante as DC On C.NumComprobante = DC.NumComprobante and C.TipoComprobanteID = DC.TipoComprobanteID  
   Inner Join ventas.TipoComprobante as TD  On C.TipoComprobanteID = TD.TipoComprobanteID  
   Inner join Almacen.Estado as E    On C.EstadoID = E.EstadoID  
   inner Join Ventas.Pago as PA    on PA.NumComprobante = C.NumComprobante and PA.TipoComprobanteID = C.TipoComprobanteID  
   inner join Ventas.FormaPago  as FP   on FP.FormaPagoID = PA.FormaPagoID  
   where  
    PA.UsuarioID = @Cajero  
    and PA.AudCrea >= @FechaIni and PA.AudCrea < @FechaFin  
    and C.EmpresaID = @EmpresaID  
    and C.SedeID = @SedeID  
   order by NomEstado, NomTipoComprobante, NumComprobante asc  
  
  
     
   select top 1 U.Descripcion from Usuario.Usuario as U  
   inner join Ventas.Comprobante as C on C.Cajero = U.UserID  
   where C.Cajero = @Cajero  
End  
go
 --///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
 

 