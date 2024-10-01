Public Class FrmPuntoVenta
    Private productos As List(Of Producto)

    Private Sub FrmPuntoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InitializeComponent()

        ' Inicializar la lista de productos
        productos = New List(Of Producto)()
        productos.Add(New Producto With {.Nombre = "ASPIRINA 500MG - FARMA INDUSTRIA 5.4MG", .Precio = 10.99, .Imagen = My.Resources.alma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})
        productos.Add(New Producto With {.Nombre = "ARCOOXIA 125MG - DROGUERIA FARMA ", .Precio = 19.99, .Imagen = My.Resources.farma})



        For Each producto In productos
            Dim button As New Button()
            button.TextImageRelation = TextImageRelation.ImageAboveText
            button.AutoSize = True

            ' Ajustar el tamaño de la imagen y asignarla al botón
            Dim imageWidth As Integer = 150
            Dim imageHeight As Integer = 150
            Dim resizedImage As Image = ResizeImage(producto.Imagen, imageWidth, imageHeight)

            ' Agregar la imagen al botón
            button.Image = resizedImage

            ' Crear un panel para la superposición semitransparente
            Dim overlayPanel As New Panel()
            overlayPanel.BackColor = Color.FromArgb(150, Color.Black)
            overlayPanel.Dock = DockStyle.Bottom
            overlayPanel.Height = 40 ' Altura de la franja semitransparente

            ' Crear etiquetas para el nombre del producto y el precio
            Dim nameLabel As New Label()
            ' nameLabel.Text = TruncateText(producto.Nombre, 15) ' Truncar el nombre si es muy largo
            nameLabel.Text = TruncateText(producto.Nombre, 20) & vbCrLf & $"${producto.Precio:N2}"
            nameLabel.Font = New Font("Arial", 10, FontStyle.Bold) ' Cambia el tamaño de fuente según tus necesidades

            nameLabel.AutoSize = True
            nameLabel.Dock = DockStyle.Top
            nameLabel.ForeColor = Color.White

            ' Agregar las etiquetas al panel de superposición
            overlayPanel.Controls.Add(nameLabel)



            ' Agregar el panel de superposición al botón
            button.Controls.Add(overlayPanel)

            AddHandler button.Click, AddressOf ProductoButton_Click
            FlowLayoutPanel1.Controls.Add(button)
        Next




        'For Each producto In productos
        '    Dim button As New Button()
        '    button.TextImageRelation = TextImageRelation.ImageAboveText
        '    button.AutoSize = True

        '    ' Ajustar el tamaño de la imagen y asignarla al botón
        '    Dim imageWidth As Integer = 100
        '    Dim imageHeight As Integer = 100
        '    Dim resizedImage As Image = ResizeImage(producto.Imagen, imageWidth, imageHeight)

        '    ' Agregar la franja semitransparente con el nombre y precio
        '    Dim overlayedImg As Image = AddSemitransparentOverlay(resizedImage, $"{producto.Nombre}{vbCrLf}${producto.Precio:N2}")

        '    button.Image = overlayedImg
        '    AddHandler button.Click, AddressOf ProductoButton_Click
        '    FlowLayoutPanel1.Controls.Add(button)
        'Next




    End Sub
    Private Function TruncateText(text As String, maxLength As Integer) As String
        If text.Length <= maxLength Then
            Return text
        Else
            Return text.Substring(0, maxLength - 3) & "..."
        End If
    End Function
    Private Sub ProductoButton_Click(sender As Object, e As EventArgs)
        ' Aquí puedes manejar el evento Click del botón del producto
        Dim clickedButton As Button = DirectCast(sender, Button)
        Dim buttonText As String = clickedButton.Text
        ' Realizar acciones adicionales según sea necesario
    End Sub
    Private Function ResizeImage(ByVal image As Image, ByVal width As Integer, ByVal height As Integer) As Image
        Dim resizedImage As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.DrawImage(image, 0, 0, width, height)
        End Using
        Return resizedImage
    End Function

    Public Class Producto
        Public Property Nombre As String
        Public Property Precio As Decimal
        Public Property Imagen As Image
    End Class
    Private Function AddSemitransparentOverlay(image As Image, overlayText As String) As Image
        Dim bmp As New Bitmap(image.Width, image.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(image, 0, 0)

            Dim overlayHeight As Integer = CInt(image.Height * 0.3) ' Ajusta la altura de la franja
            Dim overlayRect As New Rectangle(0, image.Height - overlayHeight, image.Width, overlayHeight)
            Using brush As New SolidBrush(Color.FromArgb(150, Color.Black)) ' Color semitransparente
                g.FillRectangle(brush, overlayRect)
            End Using

            Dim font As New Font("Arial", 10, FontStyle.Bold)
            Dim textRect As New Rectangle(0, image.Height - overlayHeight, image.Width, overlayHeight)
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            Using brush As New SolidBrush(Color.White)
                g.DrawString(overlayText, font, brush, textRect, format)
            End Using
        End Using

        Return bmp
    End Function

End Class