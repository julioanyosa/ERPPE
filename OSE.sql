--Instalar el servicio web
--cambiar el web config


 alter table ventas.CorrelativoFacturadorSunat add EnviadoSunat char(1), NroTicket varchar(50), FechaConsultaTicket datetime
 go
 
 alter table ventas.Comprobante add GeneradoAltaId int, FechaAltaSunat datetime, Descuento decimal(18,2), MontoTotal  decimal(18,2)
 go

 alter procedure Ventas.ActualizarDesdeFacturadorSunat          
(          
@EmpresaID char(2),          
@NumComprobante varchar(20),          
@TipoComprobanteID int,          
@fechaenvio datetime,          
@mensaje varchar(500),          
@EstadoSunat char(2),      
@NroTicket varchar(50)      
)          
as       
      
declare @enviadosunat char(1) = null      
declare @GeneradoTxt bit = null    
      
if(@EstadoSunat in('03','04','11','12'))      
begin      
 set @enviadosunat = 'S'      
 set @GeneradoTxt = 1    
end      
      
 if(@TipoComprobanteID in(1,2,4,5))        
 begin        
 update ventas.Comprobante set FechaEnvioSunat = @fechaenvio, MensajeSunat = @mensaje, EstadoSunat = @EstadoSunat,      
 EnviadoSunat = @enviadosunat, GeneradoTxt = @GeneradoTxt    
 where NumComprobante = @NumComprobante and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID          
 end        
 else if(@TipoComprobanteID = 10 or @TipoComprobanteID = 11)        
 begin        
 --RA-20190306-001        
 update ventas.CorrelativoFacturadorSunat set FechaEnvioSunat = @fechaenvio, MensajeSunat = @mensaje, EstadoSunat = @EstadoSunat ,      
 EnviadoSunat = @enviadosunat, NroTicket = @NroTicket            
 where         
 Tipo + '-' + convert(varchar(10), year(Fecha)) + right('00' + convert(varchar(10),month(fecha)),2)        
 + right('00' + convert(varchar(10),day(fecha)),2) + '-' + right('000' + convert(varchar(10), Correlativo),3) = @NumComprobante         
 and EmpresaID = @EmpresaID and TipoComprobanteID = @TipoComprobanteID          
 end        
 
 go

create procedure Ventas.ActualizarTicketBaja    
(    
@id int,    
@mensaje varchar(500)    
)    
as    
declare @fecha datetime = getdate()    
declare @fechaenvio datetime;    
select @fechaenvio = FechaEnvioSunat from ventas.CorrelativoFacturadorSunat    
where CorrelativoFacturadorSunatId = @id    
    
update Ventas.CorrelativoFacturadorSunat set EnviadoSunat = 'S', MensajeSunat = @mensaje,    
FechaConsultaTicket = @fecha    
where CorrelativoFacturadorSunatId = @id    
    
update ventas.Comprobante set EnviadoSunat = 'S' , MensajeSunat = @mensaje,     
FechaEnvioSunat = @fechaenvio, FechaAltaSunat = @fechaenvio, EstadoSunat = '03'    
where GeneradoAltaId = @id    
    
update ventas.Comprobante set EnviadoSunat = 'S'  , MensajeSunat = @mensaje,    
FechaBajaSunat = @fechaenvio    
where GeneradoBajaId = @id    
    
--adicionalmente obtenemos informacion de las boletas enviadas para eliminarlas del facturador sunat    
select   
CASE  
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'  
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  +           
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as Comprobante, TC.TipoSunat     
from  ventas.Comprobante as C    
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID           
where GeneradoAltaId = @id    
  go

--Ventas.GenerarTxtFacturadorSunatResumenDiario '2019-07-13', 'IH', 3 ,1           
alter procedure Ventas.GenerarTxtFacturadorSunatResumenDiario                  
(                  
@fecha date,                  
@EmpresaID char(2),                  
@TipoComprobanteID int,            
@FlgEst bit              
)                  
as                  
declare @Message varchar(500)                 
             
               
                
DECLARE @UNIDADRAIZ VARCHAR(500) = 'E:\SFS_v1.2\sunat_archivos\sfs\DATA\'                   
declare @cor int                  
declare @CorrelativoFacturadorSunatId int                      
            
                
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
         
  if @FlgEst  = 0             
  begin            
            
 --validar que haya bajas            
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
and c.FlgEst = 0  and GeneradoBajaId is not null) =         
(select count(*)        
FROM Ventas.Comprobante AS C           
WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID          
and c.FlgEst = 0)        
)        
begin          
   Select @Message = 'las bajas ya han sido generadas. Fecha: ' +  convert(varchar(10), @fecha , 103)        
   RaisError(@Message, 16, 1)          
   Return          
end        
            
  --validar que hayan sido enviados los documentos            
    if (                
 (select count(*)                
 FROM Ventas.Comprobante AS C                   
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                  
 and c.FlgEst = 0  and GeneradoBajaId is null) !=                 
 (select count(*)                
 FROM Ventas.Comprobante AS C                   
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                  
 and c.FlgEst = 0  and GeneradoBajaId is null and EstadoSunat in('03', '04', '11', '12'))                
 )                
 begin                  
    Select @Message = 'alguno de comprobantes aún no han sido enviados a sunat. Fecha: ' +  convert(varchar(10), @fecha , 103)                
    RaisError(@Message, 16, 1)                  
    Return                  
 end            
            
 --obtener correlativo                  
             
 select @cor = max(Correlativo) from                   
 Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,@fecha) and Tipo = 'RC'                  
                  
 set @cor  = ISNULL(@cor,0) + 1               
             
  INSERT INTO #CABECERA (ID, TEXTO)                  
 SELECT 1,   E.RUC + '-RC-' +                  
 convert(char(4),YEAR(@fecha)) + right('00' + convert(varchar(2),month(@fecha)),2)                  
   + right('00' + convert(varchar(2),day(@fecha)),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.RDI' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E                   
   WHERE   E.EmpresaID = @EmpresaID                  
                  
 insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo,TipoComprobanteID)                  
 values(@EmpresaID,convert(date,@fecha),@cor, 'RC', 10)               
              
                 
 set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()                
             
  INSERT INTO #DETALLE (ID, TEXTO)                  
 select top 500 1,                  
                  
 CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento                  
 CONVERT(char(10), @fecha,126) + '|' + --2 Fecha de generación del resumen                  
 '03' + '|'+ --3 Tipo de documento de resumen (boleta)                  
CASE  
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'  
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  +                   
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
 case when c.FlgEst = 0 then '3' when c.FlgEst = 1 then '1' end + '|' --25 Estado                  
 as  COL1                  
 FROM Ventas.Comprobante AS C                  
  INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                  
   INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento                    
                
   WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                  
    and GeneradoBajaId is null    and c.FlgEst = 0             
             
                   
   update ventas.Comprobante set GeneradoBajaId = @CorrelativoFacturadorSunatId                 
   WHERE ComprobanteId in(          
   select top 500 ComprobanteId from Ventas.Comprobante as C          
    WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                  
    and GeneradoBajaId is null    and c.FlgEst = 0            
   )          
  end            
  else            
  begin            
   --validar que haya altas            
  if not exists(select *                
 FROM Ventas.Comprobante AS C                   
 WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                  
   and GeneradoAltaId is null)                
 begin                  
    Select @Message = 'No hay comprobantes para generar del día ' +  convert(varchar(10), @fecha , 103)                
    RaisError(@Message, 16, 1)                  
    Return                  
 end              
            
   select @cor = max(Correlativo) from                   
 Ventas.CorrelativoFacturadorSunat where EmpresaID = @EmpresaID and Fecha = convert(date,@fecha) and Tipo = 'RC'                  
                  
 set @cor  = ISNULL(@cor,0) + 1                  
                  
 insert into Ventas.CorrelativoFacturadorSunat (EmpresaID,Fecha,Correlativo, Tipo,TipoComprobanteID)                  
 values(@EmpresaID,convert(date,@fecha),@cor, 'RC', 10)                  
                
 set @CorrelativoFacturadorSunatId = SCOPE_IDENTITY()             
            
  INSERT INTO #CABECERA (ID, TEXTO)                  
  SELECT 1,   E.RUC + '-RC-' +                  
  convert(char(4),YEAR(@fecha)) + right('00' + convert(varchar(2),month(@fecha)),2)                  
  + right('00' + convert(varchar(2),day(@fecha)),2)+ '-' + right('000' + convert(varchar(3),@cor),3) + '.RDI' AS NOMBREARCHIVO  FROM  Empresa.Empresa AS E           
  WHERE   E.EmpresaID = @EmpresaID               
             
 INSERT INTO #DETALLE (ID, TEXTO)                  
 select top 500 1,                  
                  
 CONVERT(char(10), C.AudCrea,126) + '|' + --1 Fecha de generación del documento                  
 CONVERT(char(10), @fecha,126) + '|' + --2 Fecha de generación del resumen                  
 '03' + '|'+ --3 Tipo de documento de resumen (boleta)                  
CASE  
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'  
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'   END +                   
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
 '1'  + '|' --25 Estado      --siempre debe ser uno            
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
    and GeneradoAltaId is null              
            
            
 update ventas.Comprobante set GeneradoAltaId = @CorrelativoFacturadorSunatId                
 WHERE  ComprobanteId in(          
 select top 500 C.ComprobanteId FROM Ventas.Comprobante AS C                  
   WHERE convert(date,C.AudCrea) =  @fecha and c.EmpresaID = @EmpresaID and c.TipoComprobanteID = @TipoComprobanteID                  
    and GeneradoAltaId is null             
 )             
end            
            
                  
  SELECT @UNIDADRAIZ AS RUTA                  
  SELECT * FROM #CABECERA                  
  SELECT * FROM #DETALLE                  
  go

        
  --Ventas.ListarEnvioOSE 'IH', '2019-08-06'  
CREATE procedure Ventas.ListarEnvioOSE                 
(                  
@EmpresaID char(2),                  
@Fecha date          
)                  
as                  
                 
         
select      
C.TipoComprobanteID,                
C.ComprobanteId,                  
C.NumComprobante,                   
TC.TipoSunat,                  
TC.NomTipoComprobante AS TipoComprobante,                  
CASE  
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'  
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END                
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
     
                  
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + C.TotalIGV))  as ImporteTotal,                  
C.GeneradoTxt, C.MensajeSunat,                  
isnull(C.EstadoSunat, '00') as EstadoSunat, isnull(efe.Descripcion,'') as EstadoEnvio,          
C.FechaEnvioSunat                  
                   
                   
FROM Ventas.Comprobante AS C                  
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                  
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID                  
INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento                    
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  C.EstadoSunat                   
left JOIN                           
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'                          
GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID                           
where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) = @Fecha                   
and (c.TipoComprobanteID in(2,5) )              
and isnull(EnviadoSunat,'N') = 'N'          
    
    
     
union all              
            
select       
cs.TipoComprobanteID,            
cs.CorrelativoFacturadorSunatId as ComprobanteId,                 
    
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))            
+ right('00' + convert(varchar(10),month(cs.fecha)),2)            
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'             
+ right('000' + convert(varchar(10), cs.Correlativo),3) AS NumComprobante,                  
             
cs.Tipo as TipoSunat,            case            
when cs.tipo = 'RA' then 'Comunicacion de Baja'            
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS TipoComprobante,             
               
  convert(varchar(10), year(cs.Fecha))            
+ right('00' + convert(varchar(10),month(cs.fecha)),2)            
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'             
+ right('000' + convert(varchar(10),cs.Correlativo),3) AS Comprobante,      
                    
CONVERT(char(10), cs.Fecha,126) as FechaEmision,                   
'00:00' as HoraEmision,                  
            
'' as tipocliente, ---Tipo de documento de identidadL del adquirente o usuario                        
'' as DocumentoCliente,             
case            
when cs.tipo = 'RA' then 'Comunicacion de Baja'            
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS RazonSocial,                    
                  
'0.00'   as ImporteTotal,                  
cs.GeneradoTxt, cs.MensajeSunat,                  
isnull(cs.EstadoSunat, '00') as EstadoSunat,            
isnull(efe.Descripcion,'') as EstadoEnvio   ,          
cs.FechaEnvioSunat              
from Ventas.CorrelativoFacturadorSunat as cs            
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  cs.EstadoSunat                
where cs.EmpresaID = @EmpresaID and cs.Fecha = @Fecha  and                  
 cs.TipoComprobanteID in(10,11)               
and  isnull(EnviadoSunat,'N') = 'N'               
go 

--descuento--------------------------------------------------------------------------------------------
ALTER TABLE Ventas.Comprobante ADD Descuento decimal(18,2), MontoTotal decimal(18,2)
go

--actualizar los totales
update VENTAS.Comprobante set MontoTotal = SubTotal + isnull( TotalIGV,0) + ISNULL( TotalICBPER,0)   
where MontoTotal is null
go
update VENTAS.Comprobante set Descuento = 0   
where Descuento is null
go

select  * from ventas.Comprobante 
where CONVERT(date,AudCrea) = '2019-12-16'
order by AudCrea desc


  
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
 @TipoTicket char(1),  
 @TotalICBPER decimal(18,2),  
 @Descuento decimal(18,2),
 @MontoTotal decimal(18,2)     
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
  
  
      
 declare @id bigint 
 Insert Into Ventas.Comprobante 
 ( 
 NumComprobante, EmpresaID,SedeID, TipoComprobanteID, ClienteID, Direccion, TipoVentaID, TipoPagoID, FormaPagoID, 
 NumCaja, NroGuia, IGV, SubTotal, TotalIGV, Vendedor, CreditoID, Cajero, EstadoID, Externa, Vale, NumVale, 
 Ingreso, AudCrea, FlgEst, TipoTicket, TotalICBPER, Descuento,MontoTotal ) 
 Values 
 ( 
 @NumComprobante, @EmpresaID, @SedeID, @TipoComprobanteID, @ClienteID, @Direccion, @TipoVentaID, @TipoPagoID, @FormaPagoID, 
 @NumCaja, @NroGuia, @IGV, @SubTotal, @TotalIGV, @Vendedor, @CreditoID, @Cajero, @EstadoID, @Externa, @Vale, @NumVale, 
 'A', @FECHA_ACTUAL, 'True', @TipoTicket , @TotalICBPER,@Descuento, @MontoTotal 
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

sp_helptext 'contabilidad.Usp_GetConsolidadoDeVentas'
 

--[Ventas].[ObtenerTxtFacturadorSunat] 2499321
alter PROCEDURE [Ventas].[ObtenerTxtFacturadorSunat]  
(  
@ID BIGINT   
)  
as  
--DECLARE @ID BIGINT = 2479196  
--DECLARE @UNIDADRAIZ VARCHAR(500) = '',   
--@NOMBREARCHIVOCAB varchar(250), @NOMBREARCHIVOLEY varchar(250), @NOMBREARCHIVODET varchar(250),  
--@NOMBREARCHIVOTRI varchar(250)  
  
declare @impuestobolsa decimal(18,2)  
  
select @impuestobolsa = CONVERT(decimal(18,2),Valor) from Empresa.GrupoDetalle  
where Descripcion = (select convert(varchar(50), YEAR(AudCrea)) from ventas.Comprobante as C WHERE C.ComprobanteId =  @ID)  
and GrupoId = 1  
  
  
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
SELECT 1,   E.RUC + '-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  
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
CONVERT(VARCHAR(50),convert(decimal(12,2),C.TotalIGV) + isnull(C.TotalICBPER,0.00)) + '|' + --Sumatoria Tributos  
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal)) + '|' +--Total valor de venta   
CONVERT(VARCHAR(50),convert(decimal(12,2),C.SubTotal + isnull(C.TotalIGV,0.00) + isnull(C.TotalICBPER,0.00))) + '|' +--Total Precio de Venta  
CONVERT(VARCHAR(50), ISNULL(convert(decimal(12,2),c.Descuento),0.00))  + '|' +--Total descuentos  
'0.00' + '|' + --Sumatoria otros Cargos  
'0.00' + '|' + --Total Anticipos  
CONVERT(VARCHAR(50),convert(decimal(12,2),C.MontoTotal)) + '|'  + --Importe total de la venta, cesión en uso o del servicio prestado  
'2.1' + '|' + --Versión UBL  
'2.0' + '|'--Customization Documento  
 as COL1  
 FROM Ventas.Comprobante AS C  
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID  
  INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento    
--   left JOIN           
--(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'          
-- GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID           
  --left join           
  --(    select distinct EmpresaID,SedeID,Establecimiento from Almacen.Almacen      )          
  -- as AL on AL.EmpresaID = C.EmpresaID and AL.SedeID = C.SedeID      
  WHERE C.ComprobanteId =  @ID  
  
   
-------------------------------------------------------------------  
--DETALLE     
INSERT INTO #CABECERA (ID, TEXTO)    
SELECT 2,  E.RUC + '-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  
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
CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.PrecioUnitario * dc.Cantidad),0.00))   + '|' +  --10 Tributo: Base Imponible IGV por Item  
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' +  --11 Tributo: Nombre de tributo por item  
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END  + '|' +  --12 Tributo: Código de tipo de tributo por Item  
case when con.Esgratuito = 1 then '21' ELSE '20' END  + '|' +  -- 13 Tributo: Afectación al IGV por ítem  
'0.00'   + '|' +  --14 Tributo: Porcentaje de IGV  
   
   
'-'   + '|' + --15 Tributo ISC: Códigos de tipos de tributos ISC  
''   + '|' + --16 Tributo ISC: Monto de ISC por ítem  
''   + '|' + --17 Tributo ISC: Base Imponible ISC por Item  
''   + '|' + --18 Tributo ISC: Nombre de tributo por item  
''   + '|' + --19 Tributo ISC: Código de tipo de tributo por Item  
''   + '|' + --20 Tributo ISC: Tipo de sistema ISC  
''   + '|' + --21 Tributo ISC: Porcentaje de ISC  
   
  
case when con.TotalICBPER > 0 then '9999' else  '-' end  + '|' + --22 Tributo Otro: Códigos de tipos de tributos OTRO  
case when con.TotalICBPER > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),con.TotalICBPER),0.00)) else  '' end  + '|' + --23 Tributo Otro: Monto de tributo OTRO por iItem  
case when con.TotalICBPER > 0 then CONVERT(varchar(14),ISNULL(convert(decimal(12,2),dc.Importe),0.00)) else  '' end   + '|' + --24 Tributo Otro: Base Imponible de tributo OTRO por Item  
case when con.TotalICBPER > 0 then 'OTROS' else  '' end   + '|' + --25 Tributo Otro:  Nombre de tributo OTRO por item  
case when con.TotalICBPER > 0 then 'OTH' else  '' end  + '|' + --26 Tributo Otro: Código de tipo de tributo OTRO por Item  
case when con.TotalICBPER > 0 then '0.00' else  '' end   + '|' + --27 Tributo Otro: Porcentaje de tributo OTRO por Item  
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
SELECT 3, E.RUC + '-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.TRI'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  
   
INSERT INTO #DETALLE (ID, TEXTO)  
SELECT 3,  
case when con.Esgratuito = 1 then '9996' else '9997' end + '|' + --1 Identificador de tributo  
case when con.Esgratuito = 1 then 'GRA' ELSE 'EXO' END  + '|' + --2 Nombre de tributo  
case when con.Esgratuito = 1 then 'FRE' ELSE 'VAT' END + '|' + --3 Código de tipo de tributo  
CONVERT(varchar(14),SUM(ISNULL(convert(decimal(12,2),dc.Importe),0.00))) + '|' + --4 Base imponible  
'0.00'   + '|'  --5 Monto de Tirbuto por ítem  
as COL1  
FROM Ventas.DetalleComprobante dc          
INNER JOIN Producto.Producto p ON dc.ProductoID = p.ProductoID          
inner join ventas.Comprobante con on con.NumComprobante = dc.NumComprobante and dc.TipoComprobanteID = con.TipoComprobanteID           
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
SELECT 4, E.RUC +'-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END   
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.LEY'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  
   
INSERT INTO #DETALLE (ID, TEXTO)  
select 4, ttt.COL1  from(   
SELECT   
'1000|' + [dbo].[FN_CantidadConLetraSoles](C.MontoTotal) + '|' as COL1  
FROM Ventas.Comprobante AS C  WHERE C.ComprobanteId =  @ID  
  
 union  
  
SELECT  '2001|BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA|' as COL1  
) as ttt  

-----------------------------------------------------------------------
--ADICIONAL DE CABECERA
IF exists(select * from ventas.Comprobante where ComprobanteId = @ID and Descuento > 0)
BEGIN
DECLARE @PORCENTAJE DECIMAL(3,2), @MONTO DECIMAL(18,2), @DESCUENTO DECIMAL(18,2)

SELECT @MONTO = MontoTotal, @DESCUENTO = Descuento FROM VENTAS.Comprobante AS com
 WHERE  com.ComprobanteId = @ID
 
SET @PORCENTAJE = (@DESCUENTO) / (@MONTO + @DESCUENTO)


INSERT INTO #CABECERA (ID, TEXTO)  
SELECT 5, E.RUC +'-' + CASE WHEN C.TipoComprobanteID in(1,4) THEN '03' WHEN C.TipoComprobanteID in(2,5) THEN '01'  END + '-' +  
CASE
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END   
 + SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) + '.ACV'  FROM Ventas.Comprobante AS C  
INNER JOIN Empresa.Empresa AS E ON E.EmpresaID = C.EmpresaID WHERE C.ComprobanteId =  @ID  

INSERT INTO #DETALLE (ID, TEXTO)  
SELECT 5,
'false|' + --1	Variable Global: Tipo de variable
'03|' + --2	Variable Global: Código de tipo del Item (APLICA A Descuentos globales que no afectan la base imponible del IGV/IVAP)
CONVERT(VARCHAR(20), @PORCENTAJE) + '|' + --3	Variable Global: Porcentaje del Item
'PEN|' + --4	Variable Global: Moneda de Monto del Item
CONVERT(VARCHAR(20), @DESCUENTO) + '|' + --5	Variable Global: Monto del Item
'PEN|' + --6	Variable Global: Moneda de Base Imponible del Item
CONVERT(VARCHAR(20), @MONTO + @DESCUENTO)  --7	Variable GLobal:  Base Imponible  del Item

END


  
  
SELECT '' AS RUTA      
SELECT * FROM #CABECERA      
SELECT * FROM #DETALLE    
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
 convert(smalldatetime,CONVERT(char(10), C.AudCrea, 103)) AS FECHA,   
 C.AudCrea,   
 ATD.tiposunat AS TIPOCONTABILIDAD,   
 @LetraSerie + SUBSTRING(C.NumComprobante,3,3) AS SERIE,   
 convert(int,RIGHT(C.NumComprobante,7)) AS NUMERO,   
 CASE C.ClienteID WHEN 204 THEN '' ELSE ETD.TIPOCONTABILIDAD END AS TIPO_DOCUMENTO_IDENTIDAD,   
 CASE C.ClienteID WHEN 204 THEN '' ELSE CL.NroDocumento END AS NUMERO_DOCUMENTO,   
 CASE C.ClienteID WHEN 204 THEN CASE C.FlgEst WHEN 'TRUE' THEN 'VENTA DIARIA' ELSE   
 'ANULADO' END ELSE CASE C.FlgEst WHEN 'TRUE' THEN CL.RazonSocial ELSE 'ANULADO'   
 END END AS RAZON_SOCIAL,   
 CASE C.FlgEst WHEN 'False' THEN 0 ELSE C.SubTotal END AS BASE_IMPONIBLE_OE,   
 0.00 AS BASE_IMPONIBLE_OG,  
 CASE C.FlgEst WHEN 'False' THEN 0 ELSE isnull(C.TotalIGV,0) +isnull(C.TotalICBPER,0) END AS IGV,   
 CASE C.FlgEst WHEN 'False' THEN 0 ELSE isnull(C.TotalICBPER,0) END AS TotalICBPER,   
 C.ComprobanteId,   
 C.MontoTotal as Total   
 from Ventas.Comprobante as C   
 INNER JOIN Ventas.TipoComprobante AS ATD ON C.TipoComprobanteID = ATD.TipoComprobanteID   
 INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID   
 INNER JOIN EMPRESA.TipoDocumento AS ETD ON CL.IDTipoDocumento = ETD.IDTipoDocumento   
 where   
 convert(date,C.AudCrea) between @FechaIni and @FechaFin   
 AND LEFT(C.NumComprobante,2) = @EmpresaID   
 and C.TipoComprobanteID = @TipoComprobanteID   
 ORDER BY FECHA, SERIE, NUMERO   
 --COMPROBANTES GENERADOS POR EMPRESA   
   
 Set Nocount Off   
End 
go
  


/************************************************************************************************************    
Autor  : Juan Carlos    
Fecha  : 13/05/2011    
Descripción : Listar registros de la tabla de base de datos     
Prueba  : [Ventas].[usp_GetVentasSede] '30/06/2011', '01/12/2011', 'GH002VU'    
*************************************************************************************************************/    
alter Procedure [Ventas].[usp_GetVentasSede]    
(    
 @FechaIni date,    
 @FechaFin date,    
 @EmpresaSede char(7)    
)    
As    
Begin    
    
   Select    
    C.AudCrea,    
    C.NumComprobante,    
    TD.NomTipoComprobante,    
    CL.NroDocumento,    
    CL.RazonSocial,  
 isnull(pag2.Importe,0) as TotalComprobante,    
    E.NomEstado,    
    C.FlgEst,    
    TV.NomTipoPago,    
    c.Descuento as Descuento,    
    SERV.Importe as Servicio    
   from ventas.Comprobante as C    
   Inner Join ventas.TipoComprobante as TD On C.TipoComprobanteID = TD.TipoComprobanteID    
   Inner join Almacen.Estado as E On C.EstadoID = E.EstadoID    
   inner join Ventas.Cliente as CL On C.ClienteID = CL.ClienteID    
   Inner Join Ventas.TipoPago as TV on TV.TipoPagoID = C.TipoPagoID   
   left join  
   (select sum(pag.Importe) as Importe, com.ComprobanteId from ventas.Pago as pag  
   inner join ventas.Comprobante as com on com.NumComprobante = pag.NumComprobante and  
   com.TipoComprobanteID = pag.TipoComprobanteID   
   where convert(date,com.AudCrea) between @FechaIni and  @FechaFin   
   group by com.ComprobanteId) as pag2 on pag2.ComprobanteId = C.ComprobanteId  
   --left join    
   --(select DC.NumComprobante, DC.TipoComprobanteID, sum(DC.Importe) as Importe from Ventas.DetalleComprobante as DC    
   --inner join Ventas.Servicios as SE on SE.ProductoID = DC.ProductoID    
   --inner join Ventas.Comprobante as C on C.NumComprobante = DC.NumComprobante and C.TipoComprobanteID = DC.TipoComprobanteID    
   --where SE.Tipo = '-'    
   --and C.SedeID = substring(@EmpresaSede,3,5)    
   --and C.EmpresaID = substring(@EmpresaSede,1,2)    
   --and convert(date,C.AudCrea) between @FechaIni and  @FechaFin    
   --group by DC.NumComprobante, DC.TipoComprobanteID) as DESCU on DESCU.NumComprobante = C.NumComprobante and DESCU.TipoComprobanteID = C.TipoComprobanteID     
   left join    
   (select DC.NumComprobante, DC.TipoComprobanteID, sum(DC.Importe) as Importe from Ventas.DetalleComprobante as DC    
   inner join Ventas.Servicios as SE on SE.ProductoID = DC.ProductoID    
   inner join Ventas.Comprobante as C on C.NumComprobante = DC.NumComprobante and C.TipoComprobanteID = DC.TipoComprobanteID    
   where SE.Tipo = '+'    
   and C.SedeID = substring(@EmpresaSede,3,5)    
   and C.EmpresaID = substring(@EmpresaSede,1,2)    
   and convert(date,C.AudCrea) between @FechaIni and  @FechaFin    
   group by DC.NumComprobante, DC.TipoComprobanteID) as SERV on SERV.NumComprobante = C.NumComprobante and SERV.TipoComprobanteID = C.TipoComprobanteID     
   where C.SedeID = substring(@EmpresaSede,3,5)    
   and C.EmpresaID = substring(@EmpresaSede,1,2)    
   and convert(date,C.AudCrea) between @FechaIni and  @FechaFin     
   order by C.NumComprobante  
      
    
End    
go

alter table Empresa.Empresa add RutaWS varchar(1000)
update Empresa.Empresa set Rutaws = 'https://demo-ose.nubefact.com/ol-ti-itcpe/billService?wsdl'
       
alter procedure Ventas.ObtenerDatosFacturdorSunat        
(        
@EmpresaID char(2)        
)        
as        
select EmpresaID, NomEmpresa,RutaArchivosSunat,RutaBDSunat, RUC, DomicilioFiscal,RutaXMLFE, RutaCDRFE,  
RutaCertificado,ClaveCertificado,UsuarioSOL,ClaveSol, RutaWS    
 from Empresa.Empresa where EmpresaID = @EmpresaID     
 go


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
C.TipoComprobanteID,                    
C.ComprobanteId,                      
C.NumComprobante,                       
TC.TipoSunat,                      
TC.NomTipoComprobante AS TipoComprobante,                      
CASE  
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'  
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END                     
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
isnull(C.EstadoSunat, '00') as EstadoSunat, isnull(efe.Descripcion,'') as EstadoEnvio,              
C.FechaEnvioSunat, '' as NroTicket, null as FechaConsultaTicket,      
CASE when C.FlgEst = 0 then 'ANULADO' else '' end as Estado, CFS.FechaConsultaTicket as FechaEnvioAnulacion      
                       
                       
FROM Ventas.Comprobante AS C                      
INNER JOIN Ventas.Cliente AS CL ON CL.ClienteID = C.ClienteID                      
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID                      
INNER JOIN Empresa.TipoDocumento td ON td.IDTipoDocumento = cL.IDTipoDocumento                        
left join Ventas.EstadoFacturacionElectronica as efe on efe.Codigo =  C.EstadoSunat         
left join ventas.CorrelativoFacturadorSunat as CFS on CFS.CorrelativoFacturadorSunatId = C.GeneradoBajaId      
                   
left JOIN                               
(SELECT dc.NumComprobante, dc.TipoComprobanteID, SUM(dc.Importe) AS Importe FROM Ventas.DetalleComprobante dc WHERE dc.ProductoID = '00267000102.7'                              
GROUP BY dc.NumComprobante, dc.TipoComprobanteID) AS Descuento ON Descuento.NumComprobante = C.NumComprobante AND Descuento.TipoComprobanteID = C.TipoComprobanteID                               
where C.EmpresaID = @EmpresaID and convert(date, C.AudCrea) between @FechaIni and @FechaFin                       
and (c.TipoComprobanteID = @TipoComprobanteId or (c.TipoComprobanteID in(1,2,4,5) and @TipoComprobanteId = 0))                  
and (isnull(c.EstadoSunat,'00') = @EstadoSunat or @EstadoSunat = '  ')                    
                
union all                  
                
select           
cs.TipoComprobanteID,                
cs.CorrelativoFacturadorSunatId as ComprobanteId,                   
        
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))                
+ right('00' + convert(varchar(10),month(cs.fecha)),2)                
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'                 
+ right('000' + convert(varchar(10), cs.Correlativo),3) AS NumComprobante,                      
                 
cs.Tipo as TipoSunat,            case                
when cs.tipo = 'RA' then 'Comunicacion de Baja'                
when cs.tipo = 'RC' then 'Resumen de Boletas' end AS TipoComprobante,                 
                   
cs.Tipo + '-' + convert(varchar(10), year(cs.Fecha))                
+ right('00' + convert(varchar(10),month(cs.fecha)),2)                
+ right('00' + convert(varchar(10),day(cs.fecha)),2) + '-'                 
+ right('000' + convert(varchar(10),cs.Correlativo),3) AS Comprobante,                     
                        
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
isnull(efe.Descripcion,'') as EstadoEnvio   ,              
cs.FechaEnvioSunat, cs.NroTicket, cs.FechaConsultaTicket, ''  as Estado, null as FechaEnvioAnulacion                  
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
C.MensajeSunat,            
c.FechaEnvioSunat,    
case when isnull(c.GeneradoTxt,0 )= 0 then 'NO' else 'SI' end as [Generado TXT]                  
                    
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

alter procedure Ventas.ObtenerComprobantesResumen
@id int
as 
select   
CASE  
WHEN C.TipoComprobanteID = 1 THEN '0' WHEN C.TipoComprobanteID = 2 THEN '0'  
WHEN C.TipoComprobanteID = 4 THEN 'B' WHEN C.TipoComprobanteID = 5 THEN 'F'  END  +           
SUBSTRING(C.NumComprobante,3,3) + '-0' + RIGHT(C.NumComprobante,7) as Comprobante, TC.TipoSunat     
from  ventas.Comprobante as C    
inner JOIN VENTAS.TipoComprobante AS TC ON TC.TipoComprobanteID = C.TipoComprobanteID           
where GeneradoAltaId = @id   
go

alter PROCEDURE Ventas.ObtenerComprobantesGenerar    
(    
@EmpresaID char(2),    
@TipoComprobanteID int,     
@FechaIni date,    
@FechaFin date    
)    
as    
    
select ComprobanteId, NumComprobante from Ventas.Comprobante    
where TipoComprobanteID = @TipoComprobanteID and CONVERT(date,AudCrea) between @FechaIni and @FechaFin    
and EmpresaID = @EmpresaID and isnull(GeneradoTxt,0) = 0    
    
 update  Ventas.Comprobante set GeneradoTxt = 1    
where TipoComprobanteID = @TipoComprobanteID and CONVERT(date,AudCrea) between @FechaIni and @FechaFin    
and EmpresaID = @EmpresaID and isnull(GeneradoTxt,0)  = 0    
go