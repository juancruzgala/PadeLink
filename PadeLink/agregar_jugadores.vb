Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class agregar_jugadores
    Private ReadOnly _torneo As Torneo

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneo = t
    End Sub

    Private Sub agregar_jugadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' === PANEL CABECERA ===
        Panel1.Dock = DockStyle.Top
        Panel1.Height = 110
        Panel1.BackColor = Color.FromArgb(54, 88, 138)
        Panel1.BorderStyle = BorderStyle.None

        Label4.Dock = DockStyle.Bottom
        Label4.Font = New Font("Bahnschrift SemiBold", 22, FontStyle.Bold)
        Label4.TextAlign = ContentAlignment.MiddleCenter
        Label4.ForeColor = Color.White
        Label4.Text = "📝 Inscribir Pareja 📝 "
        Label4.Padding = New Padding(0, 35, 0, 0)
        Label4.Anchor = AnchorStyles.None

        ' === LÍNEA DECORATIVA ===
        Dim lineaDecorativa As New Panel With {
            .Height = 3,
            .Dock = DockStyle.Top,
            .BackColor = Color.FromArgb(220, 230, 245)
        }
        Me.Controls.Add(lineaDecorativa)
        lineaDecorativa.BringToFront()

        ' === COMBO ===
        cboSeniaPago.DropDownStyle = ComboBoxStyle.DropDownList
        cboSeniaPago.Items.Clear()
        cboSeniaPago.Items.AddRange(New Object() {"Pendiente", "Seña", "Pago Total"})
        cboSeniaPago.BackColor = Color.White
        cboSeniaPago.FlatStyle = FlatStyle.Flat

        ' === TEXTBOXES ===
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

        For Each b As Button In {btnAgregar, btnVolver, btnListaInscriptos}
            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = 0
            b.Font = New Font("Bahnschrift", 10, FontStyle.Bold)
            b.Size = New Size(150, 28)
            b.BackColor = Color.White
            b.ForeColor = colorPrincipal
            b.Cursor = Cursors.Hand
        Next

        ' === EFECTO HOVER ===
        AddHandler btnAgregar.MouseEnter, Sub()
                                              btnAgregar.BackColor = colorPrincipal
                                              btnAgregar.ForeColor = Color.White
                                          End Sub
        AddHandler btnAgregar.MouseLeave, Sub()
                                              btnAgregar.BackColor = Color.White
                                              btnAgregar.ForeColor = colorPrincipal
                                          End Sub

        AddHandler btnListaInscriptos.MouseEnter, Sub()
                                                      btnListaInscriptos.BackColor = colorHover
                                                      btnListaInscriptos.ForeColor = Color.White
                                                  End Sub
        AddHandler btnListaInscriptos.MouseLeave, Sub()
                                                      btnListaInscriptos.BackColor = Color.White
                                                      btnListaInscriptos.ForeColor = colorPrincipal
                                                  End Sub

        AddHandler btnVolver.MouseEnter, Sub()
                                             btnVolver.BackColor = Color.FromArgb(230, 235, 245)
                                         End Sub
        AddHandler btnVolver.MouseLeave, Sub()
                                             btnVolver.BackColor = Color.White
                                         End Sub

        ' === ETIQUETAS ===
        For Each lbl As Label In {lblNombre, Label3, Label5}
            lbl.Font = New Font("Bahnschrift SemiBold", 10.5!, FontStyle.Regular)
            lbl.ForeColor = Color.FromArgb(50, 50, 70)
        Next

        ' === TARJETA CENTRAL ===
        Dim fondoEdicion As New Panel With {
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .Size = New Size(Me.ClientSize.Width - 260, 260),
            .Top = Panel1.Bottom + 50,
            .Left = (Me.ClientSize.Width - (Me.ClientSize.Width - 260)) \ 2
        }
        fondoEdicion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim sombra As New Panel With {
            .BackColor = Color.FromArgb(220, 225, 235),
            .Size = fondoEdicion.Size,
            .Top = fondoEdicion.Top + 4,
            .Left = fondoEdicion.Left + 4
        }
        sombra.Anchor = fondoEdicion.Anchor

        Me.Controls.Add(sombra)
        Me.Controls.Add(fondoEdicion)
        sombra.SendToBack()
        fondoEdicion.SendToBack()

        ' === CENTRAR TODO ===
        CentrarControles()
    End Sub

    Private Sub agregar_jugadores_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CentrarControles()
    End Sub

    Private Sub CentrarControles()
        Dim centroX As Integer = Me.ClientSize.Width \ 2
        Dim margenSuperior As Integer = Panel1.Bottom + (Me.ClientSize.Height * 0.12)
        Dim espacioCampos As Integer = 70

        ' === Centrado horizontal ===
        Dim anchoTotal As Integer = txtJugador1.Width + txtDni1.Width + espacioCampos
        Dim inicioX As Integer = centroX - (anchoTotal \ 2)

        lblNombre.Left = inicioX - lblNombre.Width - 10
        lblNombre.Top = margenSuperior + ((txtJugador1.Height - lblNombre.Height) \ 2)

        txtJugador1.Left = inicioX
        txtJugador1.Top = margenSuperior
        txtDni1.Left = txtJugador1.Right + espacioCampos
        txtDni1.Top = margenSuperior

        Label5.Top = lblNombre.Top
        Label5.Left = txtDni1.Left - (Label5.Width + 10)

        ' === Segunda fila ===
        txtJugador2.Left = inicioX
        txtJugador2.Top = txtJugador1.Bottom + 20
        txtDni2.Left = txtJugador2.Right + espacioCampos
        txtDni2.Top = txtDni1.Bottom + 20

        ' === Combo ===
        Label3.Left = centroX - ((Label3.Width + cboSeniaPago.Width + 10) \ 2)
        Label3.Top = txtJugador2.Bottom + 45
        cboSeniaPago.Left = Label3.Right + 10
        cboSeniaPago.Top = Label3.Top - 2

        ' === Botón Agregar ===
        btnAgregar.Left = centroX - (btnAgregar.Width \ 2)
        btnAgregar.Top = cboSeniaPago.Bottom + 45

        ' === Botones inferiores ===
        Dim anchoBotones As Integer = btnListaInscriptos.Width + 40 + btnVolver.Width
        Dim inicioBotonX As Integer = centroX - (anchoBotones \ 2)
        btnListaInscriptos.Left = inicioBotonX
        btnVolver.Left = btnListaInscriptos.Right + 40
        btnListaInscriptos.Top = btnAgregar.Bottom + 60
        btnVolver.Top = btnListaInscriptos.Top
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        FrmShell.ShowInShell(New lista_torneos())
    End Sub

    Private Sub btnListaInscriptos_Click(sender As Object, e As EventArgs) Handles btnListaInscriptos.Click
        FrmShell.ShowInShell(New lista_inscriptos(_torneo))
    End Sub
End Class
