Imports System.Diagnostics.Eventing
Imports System.Dynamic
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.Devices
Public Class FormFiltro


    Dim Controler As New ControllerBusqueda
    Private Const ProfundidadMaxima As Integer = 4
    Public Property usuario As Usuario
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Function VerificarNodosMarcados(nodos As TreeNodeCollection) As Boolean
        For Each nodo As TreeNode In nodos
            If nodo.Checked Then
                Return True ' Si al menos un nodo está marcado, devuelve True
            End If
            ' Llama recursivamente a la función para los nodos hijos
            If VerificarNodosMarcados(nodo.Nodes) Then
                Return True ' Si un nodo hijo está marcado, devuelve True
            End If
        Next
        Return False ' Si no se encuentra ningún nodo marcado, devuelve False
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim alMenosUnNodoMarcado As Boolean = VerificarNodosMarcados(tvCategorias.Nodes)

        If alMenosUnNodoMarcado Then
            ' Resto del código para generar el informe
            Dim cantidadDias As Int32
            Dim tipofecha As Int16
            Dim tipoinforme As Int16
            Dim tipopackagin As Int32
            Dim cadena As String = ""
            Dim cadenaproductos As String = ""
            Dim fechadesde As String
            Dim fechahasta As String
            If (dtpFechaDesde.Value < dtpFechaHasta.Value) Then
                cantidadDias = (dtpFechaHasta.Value).Date.Subtract((dtpFechaDesde.Value).Date).TotalDays
                If (cantidadDias > 180) Then
                    MsgBox("Período de fechas invalido, no debe ser mayor a 180 días.", vbExclamation, "Advertencia")
                    dtpFechaHasta.Focus()
                Else
                    fechadesde = dtpFechaDesde.Value.ToShortDateString()
                    fechahasta = dtpFechaHasta.Value.ToShortDateString()

                    Try
                        ' Inicializa la cadena como vacía
                        Dim resultado As String = ""
                        ' Llama a la función para cada nodo raíz del TreeView
                        For Each nodoRaiz As TreeNode In tvCategorias.Nodes
                            ObtenerNodosSeleccionados(nodoRaiz, resultado)
                        Next

                        ' Muestra el resultado en el TextBox correspondiente o realiza ot TextBoxNodosRaices.Text = resultado.TrimEnd("+".ToCharArray())

                        ' ESTO VA A EL ARMADO DE LA CADENA DE LOS PRODUCTOS RELACIONADOS
                        cadena = resultado.TrimEnd("+".ToCharArray())

                        If cadena.Trim() <> "" Then
                            'Obtenemos la cadena con los productos
                            cadenaproductos = Controler.Buscarmatriz(cadena)
                            'TextBoxNodosHijos.Text = cadenaproductos
                            If (rbtCaja.Checked) Then
                                tipopackagin = 1 'por caja                               
                            Else
                                tipopackagin = 0 ' por tonelada
                            End If
                            If rbtFechaToma.Checked Then
                                tipofecha = 1 'por fecha de carga
                            Else
                                tipofecha = 0 'por fecha de toma
                            End If
                            If rbtResumen.Checked Then
                                tipoinforme = 1 'Resumen
                            Else
                                tipoinforme = 0 'detallado
                            End If
                            Dim familiasUnicas As New HashSet(Of String)()
                            ' Llama a la función para cada nodo raíz del TreeView
                            For Each nodoRaiz As TreeNode In tvCategorias.Nodes
                                buscarfamilia(nodoRaiz, familiasUnicas)
                            Next
                            ' Convertir el HashSet a una cadena
                            Dim familia As String = String.Join(",", familiasUnicas)

                            ' Obtener valores seleccionados del CheckListBox
                            'Dim itemsSeleccionados As New List(Of String)()
                            Dim itemsSeleccionados As New List(Of Integer)()

                            For i As Integer = 0 To ChkLTipoPedido.CheckedItems.Count - 1
                                ' Obtener la fila del DataTable relacionada con el elemento seleccionado
                                Dim fila As DataRowView = DirectCast(ChkLTipoPedido.CheckedItems(i), DataRowView)

                                ' Obtener el valor del campo Codestadopedido de la fila
                                Dim codEstadoPedido As Integer = Convert.ToInt32(fila("Codestadopedido"))
                                itemsSeleccionados.Add(codEstadoPedido)
                            Next
                            ' Convertir la lista de valores seleccionados en una cadena
                            Dim itemsSeleccionadosString As String = String.Join(",", itemsSeleccionados)

                            ' Realiza la búsqueda y asigna el resultado a frm.tabla
                            Dim resultadoBusqueda = Controler.BuscarResultado(cadenaproductos, tipopackagin, tipoinforme, tipofecha, fechadesde, fechahasta, itemsSeleccionadosString)
                            Dim resultadodetalle = Controler.buscarresultadodetalle(cadenaproductos, tipopackagin, tipoinforme, tipofecha, fechadesde, fechahasta, itemsSeleccionadosString)
                            ' En Form1 o donde recibas los datos del estado de los pedidos
                            Dim estadoPedidos As String = ObtenerEstadoPedidos() ' Debes tener una función para obtener el estado de los pedidos


                            ' Crea una nueva instancia del formulario FrmVisualizador y muestra los resultados
                            If (resultadoBusqueda.Rows.Count > 0) Then
                                Dim frm As New FrmVisualizador(resultadoBusqueda)
                                frm.EstadoPedidos = estadoPedidos
                                frm.tabla = resultadoBusqueda
                                frm.cadenaproductos = cadenaproductos
                                frm.FechaDesde = fechadesde
                                frm.FechaHasta = fechahasta
                                frm.tipopackagin = tipopackagin
                                frm.tipoinforme = tipoinforme
                                frm.familia = familia
                                frm.tabladetalle = resultadodetalle
                                frm.tipofecha = tipofecha
                                frm.itemsSeleccionadosString = itemsSeleccionadosString
                                If rbtCaja.Checked Then
                                    frm.Tipo = "Caja"
                                ElseIf rbtTonelada.Checked Then
                                    frm.Tipo = "Tonelada"
                                End If
                                If rbtFechaCarga.Checked Then
                                    frm.Seleccion = "Fecha de Carga"
                                ElseIf rbtFechaToma.Checked Then
                                    frm.Seleccion = "Fecha de Toma"
                                End If
                                ' frm.ShowDialog()
                                ' Llama al método MostrarFormularioHijoEnGPformularios del FormPrincipal para mostrar FrmVisualizador en GPformularios
                                FormPrincipal.GPformularios.Controls.Add(Me)
                                FormPrincipal.MostrarFormularioHijoEnGPformularios(frm)
                            Else
                                MsgBox("No se encontraron resultados que coincidan con los criterios de búsqueda proporcionados. Por favor, revise e intente nuevamente.", vbExclamation, "Advertencia")
                            End If
                        Else
                            MsgBox("No se encontraron resultados, llamar a sistemas", "Error al cargar Categorias", vbCritical)
                        End If


                    Catch ex As Exception
                        ' Maneja la excepción mostrando un mensaje de error
                        MessageBox.Show("Error al buscar resultados: " & ex.Message, "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            Else
                MessageBox.Show("Seleccione un período de fechas valido", "Opss! Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpFechaDesde.Focus()
            End If
        Else
            btnReporte.Enabled = False
            MsgBox("Por favor seleccione al menos una Familia de Productos")
        End If
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        For Each nodo As TreeNode In tvCategorias.Nodes
            If (nodo.Checked) Then
                nodo.Checked = False
            End If
            For Each nodoHijo As TreeNode In nodo.Nodes
                If (nodoHijo.Checked) Then
                    nodoHijo.Checked = False
                End If
            Next
            btnReporte.Enabled = False
        Next

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvCategorias.AfterSelect
        Dim nodoSeleccionado As TreeNode = e.Node

        ' Verificar si el nodo seleccionado es un nodo hijo o nieto
        If nodoSeleccionado.Level > 0 Then
            ' Obtener el nodo padre
            Dim nodoPadre As TreeNode = nodoSeleccionado.Parent

            ' Seleccionar el nodo padre
            nodoPadre.Checked = True
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Obtener la resolución de pantalla
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width

        ' Calcular la cantidad de píxeles a mover en función de la resolución de pantalla
        Dim pixelsToMove As Integer = CInt(screenWidth * 0.075) ' El 10% del ancho de la pantalla, ajusta según tus necesidades

        ' Mover cada control la cantidad de píxeles calculada
        For Each control As Control In Me.Controls
            control.Left += pixelsToMove
        Next
        ' Configurar la propiedad AutoScaleMode del formulario
        Me.AutoScaleMode = Windows.Forms.AutoScaleMode.Font
        Me.Size = FormPrincipal.GPformularios.Size
        Me.Location = New Point((FormPrincipal.GPformularios.Width - Me.Width) \ 2, (FormPrincipal.GPformularios.Height - Me.Height) \ 2)


        ' Establecer las propiedades Anchor para que el formulario se ajuste al tamaño del panel
        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        'FormPrincipal.GPformularios.Controls.Add(Me) 'aca comente
        FormPrincipal.GPformularios.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ' Establecer el tamaño y posición del formulario
        Me.Size = FormPrincipal.GPformularios.Size
        Me.Location = New Point((FormPrincipal.GPformularios.Width - Me.Width) \ 2, (FormPrincipal.GPformularios.Height - Me.Height) \ 2)

        ' Establecer las propiedades Anchor para que el formulario se ajuste al tamaño del panel
        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        'FormPrincipal.GPformularios.Controls.Add(Me) 'aca comente
        FormPrincipal.GPformularios.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        tvCategorias.CheckBoxes = True
        CargarArbol2()
        ExpandirNodosRaiz()
        cargarestadopedidos()
        ' Establecer dtpFechaDesde al primer día del mes pasado
        dtpFechaDesde.Value = New DateTime(Now.Year, Now.Month, 1).AddMonths(-1)

        ' Establecer dtpFechaHasta al último día del mes pasado
        dtpFechaHasta.Value = New DateTime(Now.Year, Now.Month, 1).AddDays(-1)
        ' Crea un nuevo botón Guna y personalízalo
        btnReporte.Enabled = False
        ' Recorrer todos los elementos del CheckedListBox y marcarlos como verificados
        For i As Integer = 0 To ChkLTipoPedido.Items.Count - 1
            ChkLTipoPedido.SetItemChecked(i, True)
        Next
    End Sub
    Private Sub ExpandirNodosRaiz()
        For Each nodo As TreeNode In tvCategorias.Nodes
            nodo.Expand()
        Next
    End Sub


    Private Function ObtenerEstadoPedidos() As String
        ' Verificar si todos los elementos del CheckListBox están marcados
        Dim todosMarcados As Boolean = True
        For i As Integer = 0 To ChkLTipoPedido.Items.Count - 1
            If Not ChkLTipoPedido.GetItemChecked(i) Then
                todosMarcados = False
                Exit For
            End If
        Next

        If todosMarcados Then
            Return "TODOS"
        Else
            Dim estadosSeleccionados As New List(Of String)()

            For Each item As DataRowView In ChkLTipoPedido.CheckedItems
                estadosSeleccionados.Add(item("DescEstadoPedido").ToString())
            Next

            ' Unir los elementos de la lista en una cadena separada por comas y saltos de línea cada 3 elementos
            Dim elementosPorLinea As Integer = 3
            Dim estadoPedidos As String = ""
            For i As Integer = 0 To estadosSeleccionados.Count - 1
                estadoPedidos += estadosSeleccionados(i)
                If (i + 1) Mod elementosPorLinea = 0 AndAlso i <> estadosSeleccionados.Count - 1 Then
                    estadoPedidos += Environment.NewLine
                ElseIf i <> estadosSeleccionados.Count - 1 Then
                    estadoPedidos += ", "
                End If
            Next

            Return estadoPedidos
        End If
    End Function




    Private Sub cargarestadopedidos()
        Try
            ChkLTipoPedido.DataSource = Controler.BuscarestadoPedidos()
            ChkLTipoPedido.ValueMember = "Codestadopedido"
            ChkLTipoPedido.DisplayMember = "DescEstadoPedido"
            ChkLTipoPedido.CheckOnClick = True ' Esto permite seleccionar múltiples elementos

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CargarArbol2()

        Try
            Dim tabla As New DataTable()
            tabla = Controler.BuscarArbol()
            Dim datareader As New DataTableReader(tabla)
            Dim nodosRaiz As New Dictionary(Of String, TreeNode)()
            Dim nodosHijos As New Dictionary(Of String, Dictionary(Of String, TreeNode))()

            While datareader.Read()
                Dim claveRaiz As String = "ZZA_" & datareader("codunegocio")
                Dim claveHijo As String = "ZZB_" & datareader("codunegocio") & "_" & datareader("codclaseproducto")
                Dim claveNieto As String = "ZZC_" & datareader("codunegocio") & "_" & datareader("codclaseproducto") & "_" & datareader("CodTipo")

                ' Verifica si este nodo raíz ya ha sido agregado
                If Not nodosRaiz.ContainsKey(claveRaiz) Then
                    ' Agrega el nodo raíz
                    Dim nodoRaiz As New TreeNode(datareader("descunegocio"))
                    nodoRaiz.Name = claveRaiz
                    nodoRaiz.Tag = datareader("codunegocio") ' Asigna el valor del Tag para el nodo raíz
                    tvCategorias.Nodes.Add(nodoRaiz)
                    ' Marca este nodo raíz como agregado
                    nodosRaiz.Add(claveRaiz, nodoRaiz)
                End If

                ' Verifica si este nodo hijo ya ha sido agregado
                If Not nodosHijos.ContainsKey(claveRaiz) Then
                    nodosHijos.Add(claveRaiz, New Dictionary(Of String, TreeNode)())
                End If

                If Not nodosHijos(claveRaiz).ContainsKey(claveHijo) Then
                    ' Agrega el nodo hijo
                    nodosRaiz(claveRaiz).Nodes.Add(claveHijo, datareader("descclaseproducto")).Tag = datareader("codclaseproducto") ' Asigna el valor del Tag para el nodo hijo
                    ' Marca este nodo hijo como agregado
                    nodosHijos(claveRaiz).Add(claveHijo, nodosRaiz(claveRaiz).Nodes(claveHijo))
                End If

                If Not IsDBNull(datareader("CodTipo")) Then
                    ' Verifica si este nodo nieto ya ha sido agregado
                    If Not nodosHijos(claveRaiz)(claveHijo).Nodes.ContainsKey(claveNieto) Then
                        ' Agrega el nodo nieto
                        nodosHijos(claveRaiz)(claveHijo).Nodes.Add(claveNieto, datareader("descTipo")).Tag = datareader("CodTipo") ' Asigna el valor del Tag para el nodo nieto
                    End If
                End If
            End While
            ' Manejar el evento AfterCheck del TreeView
            AddHandler tvCategorias.AfterCheck, AddressOf tvCategorias_AfterCheck

        Catch ex As Exception
            ' Manejo de excepciones
        End Try
    End Sub

    Private Sub MarcarNodoPadre(nodo As TreeNode)
        ' Verificar si el nodo tiene un nodo padre
        If nodo.Parent IsNot Nothing Then
            ' Marcar el nodo padre
            nodo.Parent.Checked = True

            ' Llamar recursivamente a la función para el nodo padre
            MarcarNodoPadre(nodo.Parent)
        End If
    End Sub

    Private Sub DesmarcarNodoPadre(nodo As TreeNode)
        ' Verificar si el nodo tiene un nodo padre
        If nodo.Parent IsNot Nothing Then
            ' Verificar si hay otros nodos hijos del mismo nodo abuelo que están marcados
            Dim otrosNodosMarcados As Boolean = False
            For Each nodoHijo As TreeNode In nodo.Parent.Nodes
                If nodoHijo.Checked AndAlso nodoHijo IsNot nodo Then
                    otrosNodosMarcados = True
                    Exit For
                End If
            Next

            ' Si no hay otros nodos hijos marcados, desmarcar el nodo padre y llamar recursivamente a la función para el nodo padre
            If Not otrosNodosMarcados Then
                nodo.Parent.Checked = False
                DesmarcarNodoPadre(nodo.Parent)
            End If
        End If
    End Sub

    Private Sub tvCategorias_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvCategorias.AfterCheck
        Dim nodoActual As TreeNode = e.Node

        ' Verificar si el evento fue desencadenado por una acción del usuario
        If e.Action = TreeViewAction.ByMouse OrElse e.Action = TreeViewAction.ByKeyboard Then
            If nodoActual.Checked Then
                ' Si el nodo fue marcado, marcar automáticamente todos los nodos hijos y nietos
                MarcarNodosHijos(nodoActual, 0)
                MarcarNodoPadre(nodoActual)
            Else
                ' Si el nodo fue desmarcado, desmarcar automáticamente todos los nodos hijos y nietos
                DesmarcarNodosHijos(nodoActual, 0)
                DesmarcarNodoPadre(nodoActual)
            End If
        End If
        ' Verificar si al menos un nodo está seleccionado
        Dim alMenosUnNodoSeleccionado As Boolean = VerificarNodosSeleccionados(tvCategorias.Nodes)

        ' Habilitar o deshabilitar el botón Imprimir según si hay nodos seleccionados
        btnReporte.Enabled = alMenosUnNodoSeleccionado
    End Sub

    Private Function VerificarNodosSeleccionados(nodos As TreeNodeCollection) As Boolean
        ' Verificar si al menos un nodo en la colección está seleccionado
        For Each nodo As TreeNode In nodos
            If nodo.Checked Then
                Return True ' Hay al menos un nodo seleccionado
            End If

            ' Verificar nodos hijos recursivamente
            If VerificarNodosSeleccionados(nodo.Nodes) Then
                Return True ' Hay al menos un nodo seleccionado en los nodos hijos
            End If
        Next

        Return False ' No hay nodos seleccionados
    End Function

    Private Sub btnMarcarTodos_Click(sender As Object, e As EventArgs) Handles btnMarcarTodos.Click
        For Each nodo As TreeNode In tvCategorias.Nodes
            nodo.Checked = True
            For Each nodoHijo As TreeNode In nodo.Nodes
                nodoHijo.Checked = True
            Next
            'Llamar manualmente al evento AfterCheck para cada nodo raíz
            Dim args As New TreeViewEventArgs(nodo, TreeViewAction.ByMouse)
            tvCategorias_AfterCheck(tvCategorias, args)
        Next
    End Sub

    Private Sub btnMarcarTodosNoInsu_Click(sender As Object, e As EventArgs) Handles btnMarcarTodosNoInsu.Click
        For Each nodo As TreeNode In tvCategorias.Nodes
            If nodo.Text.ToUpper() <> "PRODUCTOS INDUSTRIALES" Then
                nodo.Checked = True
                MarcarNodosHijos(nodo, 0) ' Marcar nodos hijos y nietos
            Else
                For Each nodoHijo As TreeNode In nodo.Nodes
                    If nodoHijo.Text.ToUpper() <> "INSUMOS" Then
                        nodoHijo.Checked = True
                        MarcarNodosHijos(nodoHijo, 1) ' Marcar nodos nietos
                    End If
                Next
            End If
        Next
    End Sub


    ' Uso de la función
    Private Sub ObtenerNodosSeleccionados(ByVal nodo As TreeNode, ByRef resultado As String)
        ' Verifica si el nodo está seleccionado o marcado como Checked
        If nodo.Checked Then
            ' Si es un nodo nieto
            If nodo.Parent IsNot Nothing AndAlso nodo.Parent.Parent IsNot Nothing Then
                ' Agrega el nodo nieto al resultado
                resultado &= nodo.Tag

                ' Agrega el nodo padre al resultado
                resultado &= nodo.Parent.Tag

                ' Agrega el nodo abuelo al resultado
                resultado &= nodo.Parent.Parent.Tag

                ' Agrega un separador entre los nodos
                resultado &= "+"
            End If
        End If

        ' Llama a la función recursivamente para los nodos hijos
        For Each nodoHijo As TreeNode In nodo.Nodes
            ObtenerNodosSeleccionados(nodoHijo, resultado)
        Next
    End Sub
    Private Sub MarcarNodosHijos(nodo As TreeNode, profundidad As Integer)

        If profundidad < ProfundidadMaxima Then
            ' Marcar los nodos hijos y nietos sin afectar el estado del nodo padre y abuelo
            For Each nodoHijo As TreeNode In nodo.Nodes
                nodoHijo.Checked = True
                MarcarNodosHijos(nodoHijo, profundidad + 1) ' Aumentar la profundidad en cada nivel de recursión
            Next
        End If
    End Sub

    Private Sub DesmarcarNodosHijos(nodo As TreeNode, profundidad As Integer)
        If profundidad >= ProfundidadMaxima Then
            Return ' Detener la recursión si se alcanza la profundidad máxima
        End If

        nodo.Checked = False
        For Each nodoHijo As TreeNode In nodo.Nodes
            DesmarcarNodosHijos(nodoHijo, profundidad + 1)
        Next
    End Sub

    Private Sub Cargararbol()
        Try
            ' Suponiendo que dataTable1 ya tiene datos
            Dim tabla As New DataTable()
            tabla = Controler.BuscarArbol()
            Dim datareader As New DataTableReader(tabla)
            Dim nodosRaiz As New Dictionary(Of String, TreeNode)()
            Dim nodosHijosAgregados As New Dictionary(Of String, Boolean)()

            While datareader.Read()
                Dim clave As String = ""

                If Not IsDBNull(datareader("codclaseproducto")) Then
                    clave = "ZZB_" & datareader("codunegocio") & "_" & datareader("codclaseproducto")

                    ' Verifica si este nodo hijo ya ha sido agregado
                    If Not nodosHijosAgregados.ContainsKey(clave) Then
                        ' Agrega el nodo hijo
                        If tvCategorias.Nodes.ContainsKey("ZZA_" & datareader("codunegocio")) Then
                            tvCategorias.Nodes("ZZA_" & datareader("codunegocio")).Nodes.Add(clave, datareader("descclaseproducto"))
                        Else
                            ' Si el nodo raíz no existe, crea uno nuevo
                            Dim nodoRaiz As New TreeNode(datareader("descunegocio"))
                            nodoRaiz.Name = "ZZA_" & datareader("codunegocio")
                            tvCategorias.Nodes.Add(nodoRaiz)
                            ' Agrega el nodo hijo
                            nodoRaiz.Nodes.Add(clave, datareader("descclaseproducto"))
                        End If
                        ' Marca este nodo hijo como agregado
                        nodosHijosAgregados.Add(clave, True)
                    End If
                End If

                If Not IsDBNull(datareader("CodTipo")) Then
                End If
            End While

            'Next
        Catch ex As Exception
        End Try
    End Sub



    Private Sub buscarfamilia(ByVal nodo As TreeNode, ByRef familiasUnicas As HashSet(Of String), Optional ByVal marcaAgregada As Boolean = False)
        ' Verifica si el nodo está seleccionado o marcado como Checked
        If nodo.Checked Then
            ' Si es un nodo nieto
            If nodo.Parent IsNot Nothing AndAlso nodo.Parent.Parent IsNot Nothing Then
                ' Obtén el nodo abuelo
                Dim nodoAbuelo As TreeNode = nodo.Parent.Parent
                ' Agrega "Familia: Marca: " seguido del nodo abuelo al conjunto HashSet para asegurarse de que sea único
                Dim familiaCompleta As String = nodoAbuelo.Text.Replace("MARCAS", "") ' Elimina la palabra "Marca" si está presente en el texto
                ' Agrega las palabras del nodo hijo al resultado
                For Each nodoHijo As TreeNode In nodo.Nodes
                    If nodoHijo.Checked Then
                        familiaCompleta &= " , " & nodoHijo.Text
                    End If
                Next
                ' Agrega el resultado al conjunto HashSet
                familiasUnicas.Add(familiaCompleta)
            End If
        End If

        ' Llama a la función recursivamente para los nodos hijos
        For Each nodoHijo As TreeNode In nodo.Nodes
            buscarfamilia(nodoHijo, familiasUnicas)
        Next
    End Sub

    Private Sub ChkLTipoPedido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChkLTipoPedido.SelectedIndexChanged

    End Sub

    Private Sub tvCategorias_Click(sender As Object, e As EventArgs) Handles tvCategorias.Click
        Focus()
    End Sub
End Class