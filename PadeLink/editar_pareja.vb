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

    Private Sub editar_pareja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Editar Pareja"
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)

        lblTitulo.Text = "Editar Pareja"
        lblTitulo.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold)
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 40

        If txtDni1 IsNot Nothing Then txtDni1.MaxLength = 9
        If txtDni2 IsNot Nothing Then txtDni2.MaxLength = 9

        ' Opciones fijas (deben coincidir con el CHECK de la BD)
        cboEstadoPago.Items.Clear()
        cboEstadoPago.Items.AddRange(New Object() {"No pago", "Seña", "Pago Total"})
        cboEstadoPago.DropDownStyle = ComboBoxStyle.DropDownList

        CargarDatosParejaYEstado()
    End Sub

    ' Trae jugadores + estado actual de Inscripcion
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
                    ' Seleccionar en el combo; si por algún motivo viene diferente, default a "No pago"
                    Dim idx = cboEstadoPago.FindStringExact(estado)
                    cboEstadoPago.SelectedIndex = If(idx >= 0, idx, 0)
                End If
            End Using
        End Using
    End Sub

    ' Solo números en DNI
    Private Sub txtDni_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles txtDni1.KeyPress, txtDni2.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' --- Validaciones UI ---
        Dim n1 = txtJugador1.Text.Trim()
        Dim n2 = txtJugador2.Text.Trim()
        Dim d1 = txtDni1.Text.Trim()
        Dim d2 = txtDni2.Text.Trim()
        Dim estadoSel As String = If(cboEstadoPago.SelectedItem Is Nothing, "No pago", cboEstadoPago.SelectedItem.ToString())

        If String.IsNullOrWhiteSpace(n1) OrElse String.IsNullOrWhiteSpace(n2) Then
            MessageBox.Show("Completá los nombres de ambos jugadores.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(d1) OrElse String.IsNullOrWhiteSpace(d2) Then
            MessageBox.Show("El DNI de ambos jugadores es obligatorio.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim re As New System.Text.RegularExpressions.Regex("^\d{7,9}$")
        If Not re.IsMatch(d1) Then
            MessageBox.Show("DNI del Jugador 1 inválido (7 a 9 dígitos).", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not re.IsMatch(d2) Then
            MessageBox.Show("DNI del Jugador 2 inválido (7 a 9 dígitos).", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If d1 = d2 Then
            MessageBox.Show("Los DNIs no pueden ser iguales (no es la misma persona).", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validar estado con los 3 permitidos
        If Not (estadoSel = "No pago" OrElse estadoSel = "Seña" OrElse estadoSel = "Pago Total") Then
            MessageBox.Show("Estado inválido. Debe ser: No pago / Seña / Pago Total.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Guardar en BD (transacción) ---
        Const sql As String =
"BEGIN TRY
    BEGIN TRAN;

    UPDATE dbo.Jugador
       SET nombre = @n1, dni = @d1
     WHERE id_jugador = @idj1;

    UPDATE dbo.Jugador
       SET nombre = @n2, dni = @d2
     WHERE id_jugador = @idj2;

    UPDATE dbo.Inscripcion
       SET estado_validacion = @estado
     WHERE id_torneo = @idTorneo AND id_pareja = @idPareja;

    COMMIT TRAN;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRAN;
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

            ' refrescar objeto para el caller
            _pareja.Jugador1 = n1
            _pareja.Jugador2 = n2
            _pareja.SeniaOPago = estadoSel

            MessageBox.Show("Pareja actualizada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException When ex.Number = 2627 OrElse ex.Number = 2601
            MessageBox.Show("Ese DNI ya está registrado para otro jugador. Verificá los DNIs.",
                            "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al guardar los cambios." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
