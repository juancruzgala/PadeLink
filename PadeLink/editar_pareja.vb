Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class editar_pareja

    Private ReadOnly _torneo As Torneo
    Private ReadOnly _pareja As ParejaTorneo

    Private _idJ1 As Integer
    Private _idJ2 As Integer

    Public Sub New(t As Torneo, p As ParejaTorneo)
        InitializeComponent()
        _torneo = t
        _pareja = p
    End Sub

    ' === FORM LOAD ===
    Private Sub editar_pareja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Editar Pareja"
        Me.BackColor = Color.FromArgb(243, 245, 249)
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)
        Me.MinimumSize = New Size(900, 600)

        ' === PANEL CABECERA ===
        Panel1.Dock = DockStyle.Top
        Panel1.Height = 120
        Panel1.BackColor = Color.FromArgb(54, 88, 138) ' Azul elegante
        Panel1.BorderStyle = BorderStyle.None

        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Bahnschrift SemiBold", 22, FontStyle.Bold)
        Label4.TextAlign = ContentAlignment.MiddleCenter
        Label4.ForeColor = Color.White
        Label4.Text = "✎  Modificar Pareja  ✎ "
        Label4.Padding = New Padding(0, 8, 0, 0)

        ' === LÍNEA DECORATIVA BAJO PANEL ===
        Dim lineaDecorativa As New Panel With {
        .Height = 3,
        .Dock = DockStyle.Top,
        .BackColor = Color.FromArgb(220, 230, 245)
    }
        Me.Controls.Add(lineaDecorativa)
        lineaDecorativa.BringToFront()

        ' === COMBO ESTADO ===
        cboEstadoPago.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstadoPago.Items.Clear()
        cboEstadoPago.Items.AddRange(New Object() {"No pago", "Seña", "Pago Total"})
        cboEstadoPago.BackColor = Color.White
        cboEstadoPago.FlatStyle = FlatStyle.Flat

        ' === CAMPOS DE TEXTO ===
        For Each tb As TextBox In {txtJugador1, txtJugador2, txtDni1, txtDni2}
            tb.BorderStyle = BorderStyle.FixedSingle
            tb.BackColor = Color.White
            tb.ForeColor = Color.FromArgb(30, 30, 30)
            tb.Font = New Font("Bahnschrift", 10.5!, FontStyle.Regular)
        Next

        txtDni1.MaxLength = 9
        txtDni2.MaxLength = 9

        ' === BOTONES ===
        Dim colorPrincipal As Color = Color.FromArgb(54, 88, 138)
        Dim colorHover As Color = Color.FromArgb(80, 120, 180)

        For Each b As Button In {btnGuardar, btnCancelar}
            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = 0
            b.Font = New Font("Bahnschrift", 10, FontStyle.Bold)
            b.Size = New Size(150, 40)
            b.BackColor = Color.White
            b.ForeColor = colorPrincipal
            b.Cursor = Cursors.Hand
            b.Region = Nothing ' eliminamos región personalizada para evitar errores
        Next

        ' === EFECTO HOVER ===
        AddHandler btnGuardar.MouseEnter, Sub()
                                              btnGuardar.BackColor = colorPrincipal
                                              btnGuardar.ForeColor = Color.White
                                          End Sub
        AddHandler btnGuardar.MouseLeave, Sub()
                                              btnGuardar.BackColor = Color.White
                                              btnGuardar.ForeColor = colorPrincipal
                                          End Sub

        AddHandler btnCancelar.MouseEnter, Sub()
                                               btnCancelar.BackColor = colorHover
                                               btnCancelar.ForeColor = Color.White
                                           End Sub
        AddHandler btnCancelar.MouseLeave, Sub()
                                               btnCancelar.BackColor = Color.White
                                               btnCancelar.ForeColor = colorPrincipal
                                           End Sub


        ' === ETIQUETAS ===
        For Each lbl As Label In {lblNombre, Label3, Label5}
            lbl.Font = New Font("Bahnschrift SemiBold", 10.5!, FontStyle.Regular)
            lbl.ForeColor = Color.FromArgb(50, 50, 70)
        Next

        ' === PANEL FONDO DE EDICIÓN ===
        Dim fondoEdicion As New Panel With {
        .BackColor = Color.White,
        .BorderStyle = BorderStyle.None,
        .Size = New Size(Me.ClientSize.Width - 200, 300),
        .Top = Panel1.Bottom + 40,
        .Left = 100
    }
        fondoEdicion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' Sombra visual (efecto elevación)
        Dim sombra As New Panel With {
        .BackColor = Color.FromArgb(220, 225, 235),
        .Size = fondoEdicion.Size,
        .Top = fondoEdicion.Top + 4,
        .Left = fondoEdicion.Left + 4
    }
        sombra.Anchor = fondoEdicion.Anchor
        Me.Controls.Add(sombra)
        Me.Controls.Add(fondoEdicion)
        fondoEdicion.BringToFront()

        sombra.SendToBack()
        fondoEdicion.SendToBack()

        ' === CARGAR DATOS Y CENTRAR ===
        CargarDatosParejaYEstado()
        CentrarControles()
    End Sub


    ' === ADAPTABILIDAD ===
    Private Sub editar_pareja_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CentrarControles()
    End Sub

    Private Sub CentrarControles()
        ' === Calcular referencias base ===
        Dim centroX As Integer = Me.ClientSize.Width \ 2
        Dim margenSuperior As Integer = Panel1.Bottom + (Me.ClientSize.Height * 0.1)
        Dim espacioEntreCampos As Integer = 80

        ' === Panel encabezado ===
        Panel1.Width = Me.ClientSize.Width

        ' === Ancho total de campos nombre + DNI ===
        Dim anchoTotal As Integer = txtJugador1.Width + txtDni1.Width + espacioEntreCampos
        Dim inicioX As Integer = centroX - (anchoTotal \ 2)

        ' === Fila 1 (nombre + dni jugador 1) ===
        lblNombre.Left = inicioX - lblNombre.Width - 10
        lblNombre.Top = margenSuperior + ((txtJugador1.Height - lblNombre.Height) \ 2)

        txtJugador1.Left = inicioX
        txtJugador1.Top = margenSuperior
        txtDni1.Left = txtJugador1.Right + espacioEntreCampos
        txtDni1.Top = margenSuperior

        ' === Label DNIs alineado con el textbox de la derecha ===
        Label5.Top = lblNombre.Top
        Label5.Left = txtDni1.Left - (Label5.Width + 10)

        ' === Fila 2 (nombre + dni jugador 2) ===
        txtJugador2.Left = inicioX
        txtJugador2.Top = txtJugador1.Bottom + 20
        txtDni2.Left = txtJugador2.Right + espacioEntreCampos
        txtDni2.Top = txtDni1.Bottom + 20

        ' === Seña/Pago ===
        Label3.Left = centroX - ((Label3.Width + cboEstadoPago.Width + 10) \ 2)
        Label3.Top = txtJugador2.Bottom + 50
        cboEstadoPago.Left = Label3.Right + 10
        cboEstadoPago.Top = Label3.Top - 2

        ' === Botones principales ===
        Dim anchoBotones As Integer = btnGuardar.Width + 40 + btnCancelar.Width
        Dim inicioBotonX As Integer = centroX - (anchoBotones \ 2)
        btnGuardar.Left = inicioBotonX
        btnCancelar.Left = btnGuardar.Right + 40
        btnGuardar.Top = cboEstadoPago.Bottom + 60
        btnCancelar.Top = btnGuardar.Top
    End Sub


    ' === CARGA DE DATOS ===
    Private Sub CargarDatosParejaYEstado()
        Const sql As String =
"SELECT  p.id_jugador1, j1.nombre AS n1, j1.dni AS d1,
         p.id_jugador2, j2.nombre AS n2, j2.dni AS d2,
         i.estado_validacion AS estado
  FROM dbo.Parejas p
  JOIN dbo.Jugador j1 ON j1.id_jugador = p.id_jugador1
  JOIN dbo.Jugador j2 ON j2.id_jugador = p.id_jugador2
  JOIN dbo.Inscripcion i ON i.id_pareja = p.id_pareja AND i.id_torneo = @idTorneo
 WHERE p.id_pareja = @idPareja;"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@idPareja", SqlDbType.Int).Value = _pareja.id_pareja
            cmd.Parameters.Add("@idTorneo", SqlDbType.Int).Value = _torneo.id_torneo
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    _idJ1 = CInt(rd("id_jugador1"))
                    _idJ2 = CInt(rd("id_jugador2"))
                    txtJugador1.Text = rd("n1").ToString()
                    txtJugador2.Text = rd("n2").ToString()
                    txtDni1.Text = rd("d1").ToString()
                    txtDni2.Text = rd("d2").ToString()

                    Dim estado As String = If(rd("estado") Is DBNull.Value, "No pago", rd("estado").ToString())
                    Dim idx = cboEstadoPago.FindStringExact(estado)
                    cboEstadoPago.SelectedIndex = If(idx >= 0, idx, 0)
                End If
            End Using
        End Using
    End Sub

    ' === VALIDACIONES Y GUARDADO ===
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim n1 = txtJugador1.Text.Trim()
        Dim n2 = txtJugador2.Text.Trim()
        Dim d1 = txtDni1.Text.Trim()
        Dim d2 = txtDni2.Text.Trim()
        Dim estadoSel As String = If(cboEstadoPago.SelectedItem Is Nothing, "No pago", cboEstadoPago.SelectedItem.ToString())

        ' Validaciones simples
        If String.IsNullOrWhiteSpace(n1) OrElse String.IsNullOrWhiteSpace(n2) Then
            MessageBox.Show("Completá los nombres de ambos jugadores.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(d1) OrElse String.IsNullOrWhiteSpace(d2) Then
            MessageBox.Show("El DNI de ambos jugadores es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If d1 = d2 Then
            MessageBox.Show("Los DNIs no pueden ser iguales.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Actualización
        Const sql As String =
"BEGIN TRY
    BEGIN TRAN;
    UPDATE dbo.Jugador SET nombre=@n1, dni=@d1 WHERE id_jugador=@idj1;
    UPDATE dbo.Jugador SET nombre=@n2, dni=@d2 WHERE id_jugador=@idj2;
    UPDATE dbo.Inscripcion SET estado_validacion=@estado WHERE id_torneo=@idTorneo AND id_pareja=@idPareja;
    COMMIT TRAN;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK TRAN;
    THROW;
END CATCH;"

        Try
            Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@n1", SqlDbType.VarChar, 100).Value = n1
                cmd.Parameters.Add("@n2", SqlDbType.VarChar, 100).Value = n2
                cmd.Parameters.Add("@d1", SqlDbType.VarChar, 15).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.VarChar, 15).Value = d2
                cmd.Parameters.Add("@idj1", SqlDbType.Int).Value = _idJ1
                cmd.Parameters.Add("@idj2", SqlDbType.Int).Value = _idJ2
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estadoSel
                cmd.Parameters.Add("@idTorneo", SqlDbType.Int).Value = _torneo.id_torneo
                cmd.Parameters.Add("@idPareja", SqlDbType.Int).Value = _pareja.id_pareja
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using

            _pareja.Jugador1 = n1
            _pareja.Jugador2 = n2
            _pareja.SeniaOPago = estadoSel
            MessageBox.Show("Pareja actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al guardar los cambios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        FrmShell.ShowInShell(New lista_inscriptos(_torneo))
    End Sub

    Private Sub txtDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDni1.KeyPress, txtDni2.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        FrmShell.ShowInShell(New lista_inscriptos(_torneo))
        Me.Close()
    End Sub

End Class
