alter procedure Producto.ObtenerImpresion  
(  
 @ProductoID varchar(20),   
 @EmpresaID char(2),  
 @SedeID char(5)   
)  
as  
 
begin  
 
 select  p.Alias, p.ProductoID, '*' + pe.ProductoIDVentas + '*' as ProductoIDVentas, lp.PrecioUnitario, p.UnidadMedidaID from Producto.Producto as p  
 inner join Producto.Equivalencia as pe on pe.ProductoID = p.ProductoID  
 inner join Producto.ListaPrecio as lp on lp.ProductoID = p.ProductoID  
   
 where p.ProductoID = @ProductoID and lp.SedeID = @SedeID and lp.EmpresaID = @EmpresaID  
  
end  
 
go

