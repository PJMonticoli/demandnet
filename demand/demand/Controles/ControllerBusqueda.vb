Imports DocumentFormat.OpenXml.Office2010.Excel
Imports DocumentFormat.OpenXml.Office2013.Word
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class ControllerBusqueda
    Inherits ServidorSQl
    Dim query As String
    Dim tabla As DataTable
    Dim FiltroProducto(0 To 5000) As Boolean
    Public Function buscarProductos() As DataTable
        Try

        Catch ex As Exception

        End Try
    End Function

    Public Function BuscarArbol()
        Try
            query = "SELECT * FROM Matriz.dbo.VistaArbolFiltroProducto  ORDER BY  CodUnegocio,CodClaseProducto, CodTipo  "
            tabla = ServidorSQl.GetTabla(query)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function BuscarestadoPedidos() As DataTable
        Try
            query = "select * from Ventas.dbo.EstadoPedido"
            tabla = ServidorSQl.GetTabla(query)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Function Buscarmatriz(ByVal cadenarubros As String) As String
        Try
            Dim productos As String = ""
            Dim AuxRubro As String
            query = "select * from Matriz.dbo.matMatrizDeProductos Where cod2 = 0"
            tabla = ServidorSQl.GetTabla(query)

            ' Suponiendo que "tabla" es el nombre de tu DataTable
            For Each row As DataRow In tabla.Rows
                Dim Incluir As Boolean = False
                AuxRubro = Trim(If(Not IsDBNull(row("CodTipo")), row("CodTipo").ToString(), "") &
                            If(Not IsDBNull(row("codclaseproducto")), row("codclaseproducto").ToString(), "") &
                            If(Not IsDBNull(row("codunegocio")), row("codunegocio").ToString(), ""))

                If Len(AuxRubro) > 2 Then
                    If cadenarubros.Contains(AuxRubro) Then
                        Incluir = True
                    End If
                End If

                ' Guardar valor en FiltroProducto
                FiltroProducto(row("Cod1")) = Incluir
            Next

            For i As Integer = LBound(FiltroProducto) To UBound(FiltroProducto)
                If FiltroProducto(i) = True Then
                    If String.IsNullOrEmpty(productos) Then
                        productos = CStr(i)
                    Else
                        productos &= ", " & CStr(i)
                    End If
                End If
            Next i

            Return productos
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "" ' Puedes retornar una cadena vacía u algún otro valor para indicar un error
        End Try
    End Function
    Public Function buscarresultadodetalle(ByRef cadenaproductos, ByVal tipopackagin, ByVal tipoinforme, ByVal tipofecha, ByVal fechadesde, ByVal fechahasta, ByVal estadopedido) As DataTable
        Try
            Dim tabla As New DataTable
            Dim query2 As String
            If tipoinforme = 1 Then 'resumen
                If tipopackagin = 1 Then ' por caja
                    query = " select distinct depe.codproducto,  a.descripcion as descripción,
                         count(depe.codproducto) as 'c.pedidos',
                         round(sum(depe.cantidad),2) as 'c.cajas',
                ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0 "
                    If tipofecha = 1 Then 'fechatoma
                        query &= " where p.fechatoma between '" & fechadesde & "' and '" & fechahasta & "' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and codestadopedido in (" & estadopedido & ")", "")



                    Else 'fecha carga cuando se cargo efectivamente
                        query &= " where p.fechacarga between '" & fechadesde & "' and '" & fechahasta & "' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and codestadopedido in (" & estadopedido & ")", "")
                    End If
                    query &= " group by depe.codproducto, a.descripcion
                    order by [c.pedidos] desc"
                Else ' por tonelada
                    query = "select distinct depe.codproducto,  a.descripcion as descripción,
                    ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas',
                                                    round(sum(depe.cantidad),2) as 'c.cajas'
                                        from ventas.dbo.detallepedido depe
                                        inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                                        inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0"
                    If tipofecha = 1 Then 'fechatoma
                        query &= " where p.fechatoma between '" & fechadesde & "' and '" & fechahasta & "' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and codestadopedido in (" & estadopedido & ")", "")


                    Else 'fecha carga cuando se cargo efectivamente
                        query &= " where p.fechacarga between '" & fechadesde & "' and '" & fechahasta & "' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and codestadopedido in (" & estadopedido & ")", "")
                    End If
                    query &= "group by depe.codproducto, a.descripcion,a.pesobrutoestimado,p.fechatoma
                    order by [Toneladas] desc"
                End If
            Else 'detallado
                If tipofecha = 1 Then ' fecha toma
                    If tipopackagin = 1 Then 'por caja
                        query = "DECLARE @StartDate DATE = '" & fechadesde & "';
                            DECLARE @EndDate DATE = '" & fechahasta & "';

                            DECLARE @Columns NVARCHAR(MAX) = '';
                            DECLARE @Date DATE = @StartDate;

                            -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                            

                            WHILE @Date <= @EndDate
                            BEGIN
                                -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                BEGIN
                                    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                END
                                SET @Date = DATEADD(DAY, 1, @Date);
                            END
                            -- Eliminar la coma extra al final de la cadena de columnas
                            SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                            -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                            DECLARE @Sql NVARCHAR(MAX);
                            SET @Sql = N'
                            SELECT *
                            FROM (
                                SELECT
                                    distinct depe.codproducto,
                                    CASE 
                                        WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                        WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                        ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                    END AS Dia,
                                    a.descripcion AS descripción,
	                              SUM(depe.cantidad)AS ''Cant.Cajas''
                                    --COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                FROM
                                    ventas.dbo.detallepedido depe
                                    INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                    INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                        'fecha carga cuando se cargo efectivamente
                        query &= " where p.fechatoma between ''" & fechadesde & "'' and ''" & fechahasta & "'' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and codestadopedido in (" & estadopedido & ")", "")

                        query &= " GROUP BY  depe.codproducto,p.fechatoma,
                                            CASE 
                                                WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                                WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                                ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                            END,
                                            a.descripcion
                                    ) AS SourceTable
                                    PIVOT (
                                        SUM([Cant.Cajas]) FOR Dia IN (' + @Columns + ')
                                    ) AS PivotTable';

                                    -- Ejecutar la consulta dinámica
                                    EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    Else 'por tonelada
                        query = "DECLARE @StartDate DATE = '" & fechadesde & "';
                                        DECLARE @EndDate DATE = '" & fechahasta & "';
                                        DECLARE @Columns NVARCHAR(MAX) = '';
                                        DECLARE @Date DATE = @StartDate;

                                        -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                                        --WHILE @Date <= @EndDate
                                        --BEGIN
                                        --    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                        --    SET @Date = DATEADD(DAY, 1, @Date);
                                        --END

                                        WHILE @Date <= @EndDate
                                        BEGIN
                                            -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                            IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                            BEGIN
                                                SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                            END
                                            SET @Date = DATEADD(DAY, 1, @Date);
                                        END
                                        -- Eliminar la coma extra al final de la cadena de columnas
                                        SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                                        -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                                        DECLARE @Sql NVARCHAR(MAX);
                                        SET @Sql = N'
                                        SELECT *
                                        FROM (
                                            SELECT
                                            distinct depe.codproducto,
                                                CASE 
                                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                                END AS Dia,
                                                a.descripcion AS descripción,
                                                COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                            FROM
                                                ventas.dbo.detallepedido depe
                                                INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                                INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                        'agrego el where  de fecha por toma de pedido
                        query &= " where p.fechatoma between ''" & fechadesde & "''and ''" & fechahasta & "'' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and codestadopedido in (" & estadopedido & ")", "")



                        query &= "GROUP BY  depe.codproducto,p.fechatoma,
                                CASE 
                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                END,
                                a.descripcion
                        ) AS SourceTable
                        PIVOT (
                            SUM(ToneladasPedidas) FOR Dia IN (' + @Columns + ')
                        ) AS PivotTable';

                        -- Ejecutar la consulta dinámica
                        EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    End If

                Else ' fecha carga
                    If tipopackagin = 1 Then 'por caja
                        query = "DECLARE @StartDate DATE =' " & fechadesde & "';
                            DECLARE @EndDate DATE = '" & fechahasta & "';

                            DECLARE @Columns NVARCHAR(MAX) = '';
                            DECLARE @Date DATE = @StartDate;

                            -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                            

                            WHILE @Date <= @EndDate
                            BEGIN
                                -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                BEGIN
                                    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                END
                                SET @Date = DATEADD(DAY, 1, @Date);
                            END
                            -- Eliminar la coma extra al final de la cadena de columnas
                            SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                            -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                            DECLARE @Sql NVARCHAR(MAX);
                            SET @Sql = N'
                            SELECT *
                            FROM (
                                SELECT
                                    distinct depe.codproducto,
                                    CASE 
                                        WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                        WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                        ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                    END AS Dia,
                                    a.descripcion AS descripción,
	                              SUM(depe.cantidad)AS ''Cant.Cajas''
                                    --COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                FROM
                                    ventas.dbo.detallepedido depe
                                    INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                    INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0
                        inner join Ventas.dbo.EstadoPedido ep on ep.CodEstadoPedido = p.codEstadoPedido"
                        'fecha carga cuando se cargo efectivamente
                        query &= " where p.fechacarga between ''" & fechadesde & "'' and ''" & fechahasta & "'' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "")

                        query &= "  GROUP BY depe.codproducto,p.fechacarga,
                                            CASE 
                                                WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                                WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                                ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                            END,
                                            a.descripcion
                                    ) AS SourceTable
                                    PIVOT (
                                        SUM([Cant.Cajas]) FOR Dia IN (' + @Columns + ')
                                    ) AS PivotTable';

                                    -- Ejecutar la consulta dinámica
                                    EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    Else 'por tonelada
                        query = "DECLARE @StartDate DATE = '" & fechadesde & "';
                                        DECLARE @EndDate DATE = '" & fechahasta & "';
                                        DECLARE @Columns NVARCHAR(MAX) = '';
                                        DECLARE @Date DATE = @StartDate;

                                        -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                                        --WHILE @Date <= @EndDate
                                        --BEGIN
                                        --    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                        --    SET @Date = DATEADD(DAY, 1, @Date);
                                        --END

                                        WHILE @Date <= @EndDate
                                        BEGIN
                                            -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                            IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                            BEGIN
                                                SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                            END
                                            SET @Date = DATEADD(DAY, 1, @Date);
                                        END
                                        -- Eliminar la coma extra al final de la cadena de columnas
                                        SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                                        -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                                        DECLARE @Sql NVARCHAR(MAX);
                                        SET @Sql = N'
                                        SELECT *
                                        FROM (
                                            SELECT
                                             depe.codproducto,
                                                CASE 
                                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                                END AS Dia,
                                                a.descripcion AS descripción,
                                                COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                            FROM
                                                ventas.dbo.detallepedido depe
                                                INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                                INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0
                        inner join Ventas.dbo.EstadoPedido ep on ep.CodEstadoPedido = p.codEstadoPedido"
                        'agrego el where  de fecha por toma de pedido
                        query &= " where p.fechacarga between ''" & fechadesde & "'' and ''" & fechahasta & "'' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and ep.codestadopedido in (" & estadopedido & ")", "")

                        query &= "GROUP BY  depe.codproducto,p.fechacarga,
                                CASE 
                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                END,
                                a.descripcion
                        ) AS SourceTable
                        PIVOT (
                            SUM(ToneladasPedidas) FOR Dia IN (' + @Columns + ')
                        ) AS PivotTable';

                        -- Ejecutar la consulta dinámica
                        EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    End If
                End If
            End If
            Return ServidorSQl.GetTabla(query)
        Catch ex As Exception
            Throw ex
        End Try
        Dim resultado As SqlDataReader



    End Function
    Public Function BuscarResultado(ByRef cadenaproductos, ByVal tipopackagin, ByVal tipoinforme, ByVal tipofecha, ByVal fechadesde, ByVal fechahasta, ByVal estadopedido) As DataTable
        Try
            If tipofecha = 1 Then
                query = "SELECT
    CASE 
        WHEN DATEPART(dw, p.FechaToma) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaToma))
        ELSE CONVERT(date, p.FechaToma)
    END AS FechaToma,
    ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
FROM
    ventas.dbo.DetallePedido depe
INNER JOIN
    ventas.dbo.Pedidos p ON p.NroPedido = depe.NroPedido
INNER JOIN
    productos.dbo.Articulos a ON a.cod1 = depe.CodProducto AND a.cod2 = 0
inner join Ventas.dbo.EstadoPedido ep on ep.CodEstadoPedido = p.codEstadoPedido
 where p.FechaToma between '" & fechadesde & "' and '" & fechahasta & "' and depe.codproducto in (" & cadenaproductos & " )  " &
                      IIf(estadopedido.trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & "
    
GROUP BY
    CASE 
        WHEN DATEPART(dw, p.FechaToma) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaToma))
        ELSE CONVERT(date, p.FechaToma)
    END
ORDER BY
    FechaToma;"
            Else
                query = "SELECT
    CASE 
        WHEN DATEPART(dw, p.FechaCarga) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaCarga))
        ELSE CONVERT(date, p.FechaCarga)
    END AS FechaCarga,
    ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
FROM
    ventas.dbo.DetallePedido depe
INNER JOIN
    ventas.dbo.Pedidos p ON p.NroPedido = depe.NroPedido
INNER JOIN
    productos.dbo.Articulos a ON a.cod1 = depe.CodProducto AND a.cod2 = 0
inner join Ventas.dbo.EstadoPedido ep on ep.CodEstadoPedido = p.codEstadoPedido
 where p.fechaCarga between '" & fechadesde & "' and '" & fechahasta & "' and depe.codproducto in (" & cadenaproductos & " )  " &
                           IIf(estadopedido.trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & "
    
GROUP BY
    CASE 
        WHEN DATEPART(dw, p.FechaCarga) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaCarga))
        ELSE CONVERT(date, p.FechaCarga)
    END
ORDER BY
    FechaCarga;"

            End If
            Return ServidorSQl.GetTabla(query)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function FiltrarBusqueda(ByRef FechaDesde As Date, ByRef FechaHasta As Date, ByRef CadenaProductos As String, ByRef Filtro As String, ByVal tipopackagin As Int16, ByVal tipoinforme As Int16, ByVal tipofecha As Int16, ByVal estadopedido As String) As DataTable
        Dim filtro2 As String
        Try
            If FechaDesde > "01/01/1999" Then
                If tipoinforme = 1 Then 'resumen
                    If (IsNumeric(Filtro)) Then
                        filtro2 = "depe.CodProducto='" & Filtro & "'"
                    Else
                        filtro2 = "a.Descripcion like '%" & Filtro & "%'"
                    End If
                Else ' detallado
                    If (IsNumeric(Filtro)) Then
                        filtro2 = "depe.CodProducto=''" & Filtro & "''"
                    Else
                        filtro2 = "a.Descripcion like ''%" & Filtro & "%''"
                    End If
                End If

                Dim tabla As New DataTable
                Dim query2 As String
                If tipoinforme = 1 Then 'resumen
                    If tipopackagin = 1 Then ' por caja
                        query = " select distinct depe.codproducto,  a.descripcion as descripción,
                         count(depe.codproducto) as 'c.pedidos',
                         round(sum(depe.cantidad),2) as 'c.cajas',
                        ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0 
                    inner join Ventas.dbo.EstadoPedido ep on ep.CodEstadoPedido = p.codEstadoPedido"
                        If tipofecha = 1 Then 'fechatoma
                            query &= " where p.fechatoma between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2


                        Else 'fecha carga cuando se cargo efectivamente
                            query &= " where p.fechacarga between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2
                        End If
                        query &= " group by depe.codproducto, a.descripcion
                    order by [c.pedidos] desc"
                    Else ' por tonelada
                        query = "select distinct depe.codproducto,  a.descripcion as descripción,                         
                         round(((sum(depe.cantidad)* a.pesobrutoestimado)/1000),2) as 'Toneladas',
                         round(sum(depe.cantidad),2) as 'c.cajas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0"
                        If tipofecha = 1 Then 'fechatoma
                            query &= "where p.fechatoma between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " )   " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2

                        Else 'fecha carga cuando se cargo efectivamente
                            query &= " where p.fechacarga between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " ) " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2
                        End If
                        query &= "group by depe.codproducto, a.descripcion,a.pesobrutoestimado
                    order by [Toneladas] desc"
                    End If
                Else 'detallado
                    If tipofecha = 1 Then ' fecha toma
                        If tipopackagin = 1 Then 'por caja
                            query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                            DECLARE @EndDate DATE = '" & FechaHasta & "';

                            DECLARE @Columns NVARCHAR(MAX) = '';
                            DECLARE @Date DATE = @StartDate;

                            -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                            

                            WHILE @Date <= @EndDate
                            BEGIN
                                -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                BEGIN
                                    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                END
                                SET @Date = DATEADD(DAY, 1, @Date);
                            END
                            -- Eliminar la coma extra al final de la cadena de columnas
                            SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                            -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                            DECLARE @Sql NVARCHAR(MAX);
                            SET @Sql = N'
                            SELECT *
                            FROM (
                                SELECT distinct depe.codproducto,
                                    CASE 
                                        WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                        WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                        ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                    END AS Dia,
                                    a.descripcion AS descripción,
	                              SUM(depe.cantidad)AS ''Cant.Cajas''
                                    --COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                FROM
                                    ventas.dbo.detallepedido depe
                                    INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                    INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                            'fecha carga cuando se cargo efectivamente
                            query &= " where p.fechatoma between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2

                            query &= " GROUP BY  depe.codproducto,p.fechatoma,
                                            CASE 
                                                WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                                WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                                ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                            END,
                                            a.descripcion
                                    ) AS SourceTable
                                    PIVOT (
                                        SUM([Cant.Cajas]) FOR Dia IN (' + @Columns + ')
                                    ) AS PivotTable';

                                    -- Ejecutar la consulta dinámica
                                    EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                        Else 'por tonelada
                            query = "DECLARE @StartDate DATE ='" & FechaDesde & "';
                                        DECLARE @EndDate DATE = '" & FechaHasta & "';
                                        DECLARE @Columns NVARCHAR(MAX) = '';
                                        DECLARE @Date DATE = @StartDate;

                                        -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                                        --WHILE @Date <= @EndDate
                                        --BEGIN
                                        --    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                        --    SET @Date = DATEADD(DAY, 1, @Date);
                                        --END

                                        WHILE @Date <= @EndDate
                                        BEGIN
                                            -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                            IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                            BEGIN
                                                SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                            END
                                            SET @Date = DATEADD(DAY, 1, @Date);
                                        END
                                        -- Eliminar la coma extra al final de la cadena de columnas
                                        SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                                        -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                                        DECLARE @Sql NVARCHAR(MAX);
                                        SET @Sql = N'
                                        SELECT *
                                        FROM (
                                            SELECT distinct depe.codproducto,
                                                CASE 
                                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                                END AS Dia,
                                                a.descripcion AS descripción,
                                                COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                            FROM
                                                ventas.dbo.detallepedido depe
                                                INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                                INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                            'agrego el where  de fecha por toma de pedido
                            query &= "where p.fechatoma between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2



                            query &= "GROUP BY  depe.codproducto, p.fechatoma,
                                CASE 
                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                END,
                                a.descripcion
                        ) AS SourceTable
                        PIVOT (
                            SUM(ToneladasPedidas) FOR Dia IN (' + @Columns + ')
                        ) AS PivotTable';

                        -- Ejecutar la consulta dinámica
                        EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                        End If

                    Else ' fecha carga
                        If tipopackagin = 1 Then 'por caja
                            query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                            DECLARE @EndDate DATE = '" & FechaHasta & "';

                            DECLARE @Columns NVARCHAR(MAX) = '';
                            DECLARE @Date DATE = @StartDate;

                            -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                            

                            WHILE @Date <= @EndDate
                            BEGIN
                                -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                BEGIN
                                    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                END
                                SET @Date = DATEADD(DAY, 1, @Date);
                            END
                            -- Eliminar la coma extra al final de la cadena de columnas
                            SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                            -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                            DECLARE @Sql NVARCHAR(MAX);
                            SET @Sql = N'
                            SELECT *
                            FROM (
                                SELECT distinct depe.codproducto,
                                    CASE 
                                        WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                        WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                        ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                    END AS Dia,
                                    a.descripcion AS descripción,
	                              SUM(depe.cantidad)AS ''Cant.Cajas''
                                    --COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                FROM
                                    ventas.dbo.detallepedido depe
                                    INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                    INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                            'fecha carga cuando se cargo efectivamente
                            query &= " where p.fechacarga between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2

                            query &= "  GROUP BY  depe.codproducto,p.fechacarga,
                                            CASE 
                                                WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                                WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                                ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                            END,
                                            a.descripcion
                                    ) AS SourceTable
                                    PIVOT (
                                        SUM([Cant.Cajas]) FOR Dia IN (' + @Columns + ')
                                    ) AS PivotTable';

                                    -- Ejecutar la consulta dinámica
                                    EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                        Else 'por tonelada
                            query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                                        DECLARE @EndDate DATE = '" & FechaHasta & "';
                                        DECLARE @Columns NVARCHAR(MAX) = '';
                                        DECLARE @Date DATE = @StartDate;

                                        -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                                        --WHILE @Date <= @EndDate
                                        --BEGIN
                                        --    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                        --    SET @Date = DATEADD(DAY, 1, @Date);
                                        --END

                                        WHILE @Date <= @EndDate
                                        BEGIN
                                            -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                            IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                            BEGIN
                                                SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                            END
                                            SET @Date = DATEADD(DAY, 1, @Date);
                                        END
                                        -- Eliminar la coma extra al final de la cadena de columnas
                                        SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                                        -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                                        DECLARE @Sql NVARCHAR(MAX);
                                        SET @Sql = N'
                                        SELECT *
                                        FROM (
                                            SELECT distinct depe.codproducto,
                                                CASE 
                                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                                END AS Dia,
                                                a.descripcion AS descripción,
                                                COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                            FROM
                                                ventas.dbo.detallepedido depe
                                                INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                                INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                            'agrego el where  de fecha por toma de pedido
                            query &= "where p.fechacarga between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )   " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2



                            query &= "GROUP BY  depe.codproducto,p.fechacarga,
                                CASE 
                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                END,
                                a.descripcion
                        ) AS SourceTable
                        PIVOT (
                            SUM(ToneladasPedidas) FOR Dia IN (' + @Columns + ')
                        ) AS PivotTable';

                        -- Ejecutar la consulta dinámica
                        EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                        End If
                    End If
                End If

                Return ServidorSQl.GetTabla(query)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '    Dim query As String = "SELECT depe.CodProducto,  a.Descripcion AS Producto,
        '        COUNT(depe.Codproducto) AS 'c.pedidos', SUM(depe.cantidad) AS 'Cantidad de Unidades'
        '        FROM ventas.dbo.DetallePedido depe 
        '        INNER JOIN ventas.dbo.Pedidos p ON p.NroPedido = depe.NroPedido
        '        INNER JOIN productos.dbo.Articulos a ON a.cod1 = depe.CodProducto AND a.cod2 = 0 WHERE p.FechaCarga 
        '        BETWEEN '" & FechaDesde & "' AND '" & FechaHasta & "' 
        '        AND depe.CodProducto IN (" & CadenaProductos & ") AND " & filtro2 &
        '        " GROUP BY depe.CodProducto, a.Descripcion
        '        ORDER BY  [Cantidad de Unidades] DESC"
        '    Return ServidorSQl.GetTabla(query)
        'Catch ex As Exception
        '    ' Manejar la excepción aquí
        '    Return Nothing ' O devolver un valor predeterminado o lanzar una excepción según el caso
        'End Try
    End Function

    Function FiltrarBusquedaGrid(ByRef FechaDesde As Date, ByRef FechaHasta As Date, ByRef CadenaProductos As String, ByRef Filtro As String, ByVal tipopackagin As Int16, ByVal tipoinforme As Int16, ByVal tipofecha As Int16, ByVal estadopedido As String) As DataTable
        Dim filtro2 As String
        Try
            filtro2 = "depe.CodProducto in (" & Filtro & ")"
            Dim tabla As New DataTable
            Dim query2 As String
            If tipoinforme = 1 Then 'resumen
                If tipopackagin = 1 Then ' por caja
                    If tipofecha = 1 Then 'fecha toma
                        query = " select distinct 
                            CASE 
                            WHEN DATEPART(dw, p.Fechatoma) = 6 THEN DATEADD(day, 2, CONVERT(date, p.Fechatoma))
                            ELSE CONVERT(date, p.Fechatoma)
                            END AS FechaToma,
                            ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0 "

                        query &= " where p.fechatoma between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", "and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2
                        query &= " GROUP BY
                        CASE 
                         WHEN DATEPART(dw, p.Fechatoma) = 6 THEN DATEADD(day, 2, CONVERT(date, p.Fechatoma))
                         ELSE CONVERT(date, p.Fechatoma)
                         END
                        ORDER BY
                        Fechatoma;"
                    Else 'fecha carga cuando se cargo efectivamente
                        query = " select distinct 
                            CASE 
                            WHEN DATEPART(dw, p.FechaCarga) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaCarga))
                            ELSE CONVERT(date, p.FechaCarga)
                            END AS FechaCarga,
                            ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0 "
                        query &= " where p.fechatoma between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " )   " &
                           IIf(estadopedido.Trim() <> "", " and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2
                        query &= " GROUP BY
                        CASE 
                         WHEN DATEPART(dw, p.FechaCarga) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaCarga))
                         ELSE CONVERT(date, p.FechaCarga)
                         END
                        ORDER BY
                        FechaCarga;"
                    End If
                Else ' por tonelada
                    If tipofecha = 1 Then 'fechatoma
                        query = "select distinct 
                            CASE 
                            WHEN DATEPART(dw, p.FechaToma) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaToma))
                            ELSE CONVERT(date, p.FechaToma)
                            END AS FechaToma,
                            ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0"
                        query &= "where p.FechaToma between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " )   " &
                           IIf(estadopedido.Trim() <> "", " and codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2

                        query &= "GROUP BY
                        CASE 
                         WHEN DATEPART(dw, p.FechaToma) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaToma))
                         ELSE CONVERT(date, p.FechaToma)
                         END
                        ORDER BY
                        FechaToma;"
                    Else 'fecha carga cuando se cargo efectivamente
                        query = "select distinct 
                            CASE 
                            WHEN DATEPART(dw, p.Fechacarga) = 6 THEN DATEADD(day, 2, CONVERT(date, p.Fechacarga))
                            ELSE CONVERT(date, p.Fechacarga)
                            END AS FechaCarga,
                            ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2) AS 'Toneladas'
                    from ventas.dbo.detallepedido depe
                    inner join ventas.dbo.pedidos p on p.nropedido = depe.nropedido
                    inner join productos.dbo.articulos a on a.cod1 = depe.codproducto and a.cod2 = 0"
                        query &= " where p.fechaCarga between '" & FechaDesde & "' and '" & FechaHasta & "' and depe.codproducto in (" & CadenaProductos & " ) " &
                           IIf(estadopedido.Trim() <> "", " and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2
                        query &= "GROUP BY
                        CASE 
                         WHEN DATEPART(dw, p.FechaCarga) = 6 THEN DATEADD(day, 2, CONVERT(date, p.FechaCarga))
                         ELSE CONVERT(date, p.FechaCarga)
                         END
                        ORDER BY
                        FechaCarga;"
                    End If
                End If
            Else 'detallado
                If tipofecha = 1 Then ' fecha toma
                    If tipopackagin = 1 Then 'por caja
                        query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                            DECLARE @EndDate DATE = '" & FechaHasta & "';

                            DECLARE @Columns NVARCHAR(MAX) = '';
                            DECLARE @Date DATE = @StartDate;

                            -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                            

                            WHILE @Date <= @EndDate
                            BEGIN
                                -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                BEGIN
                                    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                END
                                SET @Date = DATEADD(DAY, 1, @Date);
                            END
                            -- Eliminar la coma extra al final de la cadena de columnas
                            SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                            -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                            DECLARE @Sql NVARCHAR(MAX);
                            SET @Sql = N'
                            SELECT *
                            FROM (
                                SELECT distinct depe.codproducto,
                                    CASE 
                                        WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                        WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                        ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                    END AS Dia,
                                    a.descripcion AS descripción,
	                              SUM(depe.cantidad)AS ''Cant.Cajas''
                                    --COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                FROM
                                    ventas.dbo.detallepedido depe
                                    INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                    INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                        'fecha carga cuando se cargo efectivamente
                        query &= " where p.fechatoma between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " ) " &
                           IIf(estadopedido.Trim() <> "", " and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2

                        query &= " GROUP BY  depe.codproducto, p.fechatoma,
                                            CASE 
                                                WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                                WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                                ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                            END,
                                            a.descripcion
                                    ) AS SourceTable
                                    PIVOT (
                                        SUM([Cant.Cajas]) FOR Dia IN (' + @Columns + ')
                                    ) AS PivotTable';

                                    -- Ejecutar la consulta dinámica
                                    EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    Else 'por tonelada
                        query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                                        DECLARE @EndDate DATE = '" & FechaHasta & "';
                                        DECLARE @Columns NVARCHAR(MAX) = '';
                                        DECLARE @Date DATE = @StartDate;

                                        -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                                        --WHILE @Date <= @EndDate
                                        --BEGIN
                                        --    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                        --    SET @Date = DATEADD(DAY, 1, @Date);
                                        --END

                                        WHILE @Date <= @EndDate
                                        BEGIN
                                            -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                            IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                            BEGIN
                                                SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                            END
                                            SET @Date = DATEADD(DAY, 1, @Date);
                                        END
                                        -- Eliminar la coma extra al final de la cadena de columnas
                                        SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                                        -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                                        DECLARE @Sql NVARCHAR(MAX);
                                        SET @Sql = N'
                                        SELECT *
                                        FROM (
                                            SELECT
                                            distinct depe.codproducto,
                                                CASE 
                                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                                END AS Dia,
                                                a.descripcion AS descripción,
                                                COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                            FROM
                                                ventas.dbo.detallepedido depe
                                                INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                                INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                        'agrego el where  de fecha por toma de pedido
                        query &= "where p.fechatoma between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", " and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2


                        query &= "GROUP BY  depe.codproducto,p.fechatoma,
                                CASE 
                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechatoma), 103)
                                    WHEN DATEPART(WEEKDAY, p.fechatoma) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechatoma), 103)
                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechatoma), '' '', CONVERT(NVARCHAR(10), p.fechatoma, 103))
                                END,
                                a.descripcion
                        ) AS SourceTable
                        PIVOT (
                            SUM(ToneladasPedidas) FOR Dia IN (' + @Columns + ')
                        ) AS PivotTable';

                        -- Ejecutar la consulta dinámica
                        EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    End If

                Else ' fecha carga
                    If tipopackagin = 1 Then 'por caja
                        query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                            DECLARE @EndDate DATE = '" & FechaHasta & "';

                            DECLARE @Columns NVARCHAR(MAX) = '';
                            DECLARE @Date DATE = @StartDate;

                            -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                            

                            WHILE @Date <= @EndDate
                            BEGIN
                                -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                BEGIN
                                    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                END
                                SET @Date = DATEADD(DAY, 1, @Date);
                            END
                            -- Eliminar la coma extra al final de la cadena de columnas
                            SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                            -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                            DECLARE @Sql NVARCHAR(MAX);
                            SET @Sql = N'
                            SELECT *
                            FROM (
                                SELECT
                                    distinct depe.codproducto,
                                    CASE 
                                        WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                        WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                        ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                    END AS Dia,
                                    a.descripcion AS descripción,
	                              SUM(depe.cantidad)AS ''Cant.Cajas''
                                    --COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                FROM
                                    ventas.dbo.detallepedido depe
                                    INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                    INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                        'fecha carga cuando se cargo efectivamente
                        query &= " where p.fechacarga between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", " and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2

                        query &= "  GROUP BY  depe.codproducto,p.fechacarga,
                                            CASE 
                                                WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                                WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                                ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                            END,
                                            a.descripcion
                                    ) AS SourceTable
                                    PIVOT (
                                        SUM([Cant.Cajas]) FOR Dia IN (' + @Columns + ')
                                    ) AS PivotTable';

                                    -- Ejecutar la consulta dinámica
                                    EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    Else 'por tonelada
                        query = "DECLARE @StartDate DATE = '" & FechaDesde & "';
                                        DECLARE @EndDate DATE = '" & FechaHasta & "';
                                        DECLARE @Columns NVARCHAR(MAX) = '';
                                        DECLARE @Date DATE = @StartDate;

                                        -- Construir dinámicamente los nombres de las columnas basados en el período proporcionado
                                        --WHILE @Date <= @EndDate
                                        --BEGIN
                                        --    SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                        --    SET @Date = DATEADD(DAY, 1, @Date);
                                        --END

                                        WHILE @Date <= @EndDate
                                        BEGIN
                                            -- Excluir sábado (1) y domingo (7) y acumular en lunes (2)
                                            IF DATEPART(WEEKDAY, @Date) NOT IN (6, 7)
                                            BEGIN
                                                SET @Columns += QUOTENAME(DATENAME(WEEKDAY, @Date) + ' ' + CONVERT(NVARCHAR(10), @Date, 103)) + ', ';
                                            END
                                            SET @Date = DATEADD(DAY, 1, @Date);
                                        END
                                        -- Eliminar la coma extra al final de la cadena de columnas
                                        SET @Columns = LEFT(@Columns, LEN(@Columns) - 1);

                                        -- Consulta principal utilizando PIVOT con nombres de columnas dinámicos
                                        DECLARE @Sql NVARCHAR(MAX);
                                        SET @Sql = N'
                                        SELECT *
                                        FROM (
                                            SELECT distinct depe.codproducto,
                                                CASE 
                                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                                END AS Dia,
                                                a.descripcion AS descripción,
                                                COALESCE(ROUND(SUM(depe.cantidad * a.PesoBrutoEstimado / 1000), 2), 0) AS ToneladasPedidas
                                            FROM
                                                ventas.dbo.detallepedido depe
                                                INNER JOIN ventas.dbo.pedidos p ON p.nropedido = depe.nropedido
                                                INNER JOIN productos.dbo.articulos a ON a.cod1 = depe.codproducto AND a.cod2 = 0"
                        'agrego el where  de fecha por toma de pedido
                        query &= "where p.fechacarga between ''" & FechaDesde & "'' and ''" & FechaHasta & "'' and depe.codproducto in (" & CadenaProductos & " )  " &
                           IIf(estadopedido.Trim() <> "", " and p.codestadopedido in (" & estadopedido & ")", "") & " And " & filtro2



                        query &= "GROUP BY  depe.codproducto,p.fechacarga,
                                CASE 
                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 7 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 1, p.fechacarga), 103)
                                    WHEN DATEPART(WEEKDAY, p.fechacarga) = 6 THEN ''Lunes '' + CONVERT(NVARCHAR(10), DATEADD(DAY, 2, p.fechacarga), 103)
                                    ELSE CONCAT(DATENAME(WEEKDAY, p.fechacarga), '' '', CONVERT(NVARCHAR(10), p.fechacarga, 103))
                                END,
                                a.descripcion
                        ) AS SourceTable
                        PIVOT (
                            SUM(ToneladasPedidas) FOR Dia IN (' + @Columns + ')
                        ) AS PivotTable';

                        -- Ejecutar la consulta dinámica
                        EXEC sp_executesql @Sql, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate;"
                    End If
                End If
            End If

            Return ServidorSQl.GetTabla(query)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
