Imports System.Drawing
Imports System.Windows.Forms

Public Class frmBienvenida
    Inherits Form

    Private TableLayout As TableLayoutPanel
    Private lblTitulo As Label
    Private lblDescripcion As Label
    Private pnlAcciones As FlowLayoutPanel

    Private Sub frmBienvenida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Pantalla de Bienvenida"
        Me.Size = New Size(1000, 500)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.FromArgb(245, 248, 255)
        Me.Dock = DockStyle.Fill
        Me.DoubleBuffered = True

        InicializarLayout()
        MostrarBienvenidaPorRol(SessionInfo.CurrentRole)
    End Sub
    Private Sub InicializarLayout()
        ' === TableLayout general ===
        TableLayout = New TableLayoutPanel() With {
        .Dock = DockStyle.Fill,
        .ColumnCount = 1,
        .RowCount = 3,
        .BackColor = Color.Transparent
    }

        ' Asignar alturas en porcentajes
        TableLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 20)) ' título
        TableLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 20)) ' descripción
        TableLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 60)) ' botones

        ' === Título ===
        lblTitulo = New Label() With {
        .Font = New Font("Segoe UI", 28, FontStyle.Bold),
        .ForeColor = Color.SteelBlue,
        .Dock = DockStyle.Fill,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Padding = New Padding(0, 40, 0, 0)
    }

        ' === Descripción ===
        lblDescripcion = New Label() With {
        .Font = New Font("Segoe UI", 12),
        .ForeColor = Color.FromArgb(70, 70, 70),
        .Dock = DockStyle.Fill,
        .TextAlign = ContentAlignment.MiddleCenter,
        .MaximumSize = New Size(1000, 0),
        .AutoSize = False
    }

        ' === Panel de botones centrado ===
        pnlAcciones = New FlowLayoutPanel() With {
        .Dock = DockStyle.None,
        .FlowDirection = FlowDirection.LeftToRight,
        .WrapContents = True,
        .AutoSize = True,
        .AutoSizeMode = AutoSizeMode.GrowAndShrink,
        .Margin = New Padding(0),
        .Padding = New Padding(0),
        .Anchor = AnchorStyles.None,
        .BackColor = Color.Transparent
    }

        ' === Contenedor centrador ===
        Dim pnlContenedor As New Panel() With {
        .Dock = DockStyle.Fill,
        .BackColor = Color.Transparent
    }
        pnlContenedor.Controls.Add(pnlAcciones)

        ' Centramos manualmente el FlowLayoutPanel
        AddHandler pnlContenedor.Resize, Sub()
                                             pnlAcciones.Left = (pnlContenedor.Width - pnlAcciones.Width) \ 2
                                             pnlAcciones.Top = (pnlContenedor.Height - pnlAcciones.Height) \ 2
                                         End Sub

        ' Agregar controles al layout
        TableLayout.Controls.Add(lblTitulo, 0, 0)
        TableLayout.Controls.Add(lblDescripcion, 0, 1)
        TableLayout.Controls.Add(pnlContenedor, 0, 2)

        Me.Controls.Add(TableLayout)
    End Sub


    Private Sub MostrarBienvenidaPorRol(rol As String)
        Dim colorPrincipal As Color
        pnlAcciones.Controls.Clear()

        Select Case rol
            Case "Administrador"
                lblTitulo.Text = "👑 Bienvenido, Administrador 👑"
                lblDescripcion.Text = "Desde este perfil podés gestionar usuarios, obtener reportes y gestionar backups. 
                En el menu superior selecciona la accion que desees realizar o mediante el boton de abajo visualiza los Usuarios loggeados!"
                colorPrincipal = Color.MediumSlateBlue
                pnlAcciones.Controls.Add(CrearBoton("👥 Lista de Usuarios", Color.SteelBlue, AddressOf AbrirUsuarios))

            Case "Canchero"
                lblTitulo.Text = "🎾 Bienvenido, Canchero 🎾"
                lblDescripcion.Text = "Desde este perfil podés crear torneos, gestionar inscripciones y controlar el avance de las competiciones.
                En el menu superior selecciona la accion que desees realizar o mediante el boton de abajo genera un nuevo torneo!"
                colorPrincipal = Color.MediumSeaGreen
                pnlAcciones.Controls.Add(CrearBoton("➕ Crear Torneo", colorPrincipal, AddressOf AbrirCrearTorneo))

            Case "Fiscal"
                lblTitulo.Text = "⚖️ Bienvenido, Fiscal ⚖️"
                lblDescripcion.Text = "Desde este perfil, tu función es supervisar torneos, validar resultados y garantizar el cumplimiento de las reglas.
                En el menu superior selecciona la accion que desees realizar o mediante el boton de abajo visualiza los torneos vigentes!"
                colorPrincipal = Color.CornflowerBlue
                pnlAcciones.Controls.Add(CrearBoton("👁️ lista de torneos", colorPrincipal, AddressOf AbrirListaFiscal))

            Case Else
                lblTitulo.Text = "👋 Bienvenido al sistema"
                lblDescripcion.Text = "Seleccioná una opción en el menú superior para comenzar."
        End Select
    End Sub

    Private Function CrearBoton(texto As String, color As Color, handler As EventHandler) As Button
        Dim btn As New Button() With {
            .Text = texto,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = color,
            .FlatStyle = FlatStyle.Flat,
            .Width = 260,
            .Height = 90,
            .Margin = New Padding(20)
        }
        btn.FlatAppearance.BorderSize = 0
        AddHandler btn.Click, handler
        Return btn
    End Function

    ' === Acciones ===
    Private Sub AbrirReporte(sender As Object, e As EventArgs)
        FrmShell.ShowInShell(New FrmReportes())
    End Sub

    Private Sub AbrirUsuarios(sender As Object, e As EventArgs)
        FrmShell.ShowInShell(New frmListaUsuarios())
    End Sub

    Private Sub AbrirCrearTorneo(sender As Object, e As EventArgs)
        FrmShell.ShowInShell(New crear_torneo())
    End Sub

    Private Sub AbrirListaTorneos(sender As Object, e As EventArgs)
        FrmShell.ShowInShell(New lista_torneos())
    End Sub

    Private Sub AbrirListaFiscal(sender As Object, e As EventArgs)
        FrmShell.ShowInShell(New lista_torneos() With {.Modo = ModoLista.VerInscriptosFiscal})
    End Sub
End Class
