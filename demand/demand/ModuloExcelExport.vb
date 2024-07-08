
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.CompilerServices
Imports Excel = Microsoft.Office.Interop.Excel


Module ModuloExcelExport


    Sub ExportarChartYDGV(chart As System.Windows.Forms.DataVisualization.Charting.Chart, dgv As DataGridView, fechaDesde As Date, fechaHasta As Date, progressBar As ProgressBar, familia As String, Tipo As String, Seleccion As String)

        Dim excelApp As New Application()
        Dim workbook As Workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet)
        Dim worksheet As Worksheet = CType(workbook.Worksheets(1), Worksheet)

        ' Obtener la fecha y hora actual
        Dim fechaActual As DateTime = DateTime.Now

        ' Formatear las fechas según el formato "yyyy-MM-dd"
        Dim formatoFecha As String = "yyyy-MM-dd"
        Dim fechaDesdeFormateada As String = fechaDesde.ToString(formatoFecha)
        Dim fechaHastaFormateada As String = fechaHasta.ToString(formatoFecha)

        ' Formatear la hora actual según el formato "HH:mm"
        Dim formatoHora As String = "HH-mm"
        Dim horaActualFormateada As String = fechaActual.ToString(formatoHora)

        ' Concatenar las fechas y la hora formateadas al nombre del archivo Excel
        Dim nombreArchivo As String = $"Analisis de demanda {fechaDesdeFormateada} a {fechaHastaFormateada} solicitado {fechaActual.ToString(formatoFecha)} a las {horaActualFormateada} hs.xls"

        ' Establecer la ruta completa del archivo de Excel
        Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo)


        ' En el método para generar el archivo Excel
        worksheet.Rows("1:2").Insert(Shift:=XlInsertShiftDirection.xlShiftDown, CopyOrigin:=XlInsertFormatOrigin.xlFormatFromLeftOrAbove)

        ' Agregar el título "Análisis de Demanda" y centrarlo
        worksheet.Cells(1, 1) = "Análisis de Demanda"
        worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(1, dgv.Columns.Count)).Merge()
        worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(1, dgv.Columns.Count)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(1, dgv.Columns.Count)).Font.Bold = True

        ' Utiliza String.IsNullOrEmpty para manejar el caso en el que Tipo sea nulo
        worksheet.Cells(2, 1) = $"Familia: {familia} - Tipo: {If(String.IsNullOrEmpty(Tipo), "N/A", Tipo)} - Selección: {If(String.IsNullOrEmpty(Seleccion), "N/A", Seleccion)} - Fecha Desde: {fechaDesde.ToShortDateString()} - Fecha Hasta: {fechaHasta.ToShortDateString()}"

        ' Fusionar las celdas para que abarque toda la fila
        worksheet.Range(worksheet.Cells(2, 1), worksheet.Cells(2, dgv.Columns.Count)).Merge()
        worksheet.Range(worksheet.Cells(2, 1), worksheet.Cells(2, dgv.Columns.Count)).Font.Bold = True

        ' Exportar títulos de columnas del DataGridView a Excel con fondo gris
        For colIndex As Integer = 1 To dgv.Columns.Count - 1 ' Omitir la columna de "Selección"
            worksheet.Cells(3, colIndex) = dgv.Columns(colIndex).HeaderText
            worksheet.Cells(3, colIndex).Interior.Color = RGB(192, 192, 192) ' Fondo gris
        Next

        ' Establecer la máxima cantidad de progreso en el ProgressBar
        progressBar.Maximum = dgv.Rows.Count

        ' Exportar datos del DataGridView a Excel
        For rowIndex As Integer = 0 To dgv.Rows.Count - 1
            For cellIndex As Integer = 1 To dgv.Columns.Count - 1 ' Omitir la columna de "Selección"
                worksheet.Cells(rowIndex + 4, cellIndex) = dgv.Rows(rowIndex).Cells(cellIndex).Value
                ' Ajustar el ancho de la columna automáticamente
                worksheet.Cells(rowIndex + 4, cellIndex).EntireColumn.AutoFit()
            Next
            ' Actualizar el progreso en el ProgressBar
            progressBar.Value = rowIndex + 1

            ' Permitir que la aplicación se actualice y muestre el progreso
            System.Windows.Forms.Application.DoEvents()
        Next

        ' Encontrar la última fila ocupada en la hoja de Excel
        Dim lastRow As Integer = worksheet.UsedRange.Rows.Count

        ' Restablecer el valor del progreso al valor máximo para ocultar el ProgressBar
        progressBar.Value = progressBar.Maximum

        ' Guardar el archivo de Excel
        workbook.SaveAs(filePath)
        workbook.Close(False)
        excelApp.Quit()

        ' Liberar recursos
        ReleaseObject(worksheet)
        ReleaseObject(workbook)
        ReleaseObject(excelApp)

        ' Abrir el archivo con la aplicación predeterminada
        Try
            Process.Start(filePath)
        Catch ex As Exception
            MessageBox.Show("Error al abrir el archivo Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ReleaseObject(obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    <Extension()>
    Public Function ToImage(chart As System.Windows.Forms.DataVisualization.Charting.Chart) As Image
        Dim stream As New MemoryStream()
        chart.SaveImage(stream, ChartImageFormat.Png)
        Dim image As Image = Image.FromStream(stream)
        Return image
    End Function



End Module
