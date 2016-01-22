Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class TiffImage

    Public Sub New(ByVal fileName As String)
        _fileName = fileName
    End Sub

    Private _fileName As String
    Public ReadOnly Property FileName() As String
        Get
            Return _fileName
        End Get
    End Property

    Public ReadOnly Property PageCount() As Integer
        Get
            ' Get the frame dimension list from the image of the file and 

            Dim fsImage As System.IO.FileStream = Nothing

            fsImage = System.IO.File.Open(Me.FileName, FileMode.Open, FileAccess.Read)
            Dim bArrImage(fsImage.Length) As Byte
            fsImage.Read(bArrImage, 0, Convert.ToInt32(fsImage.Length))
            fsImage.Close()

            Dim ms As New MemoryStream(bArrImage)

            'Dim image As Image = image.FromFile(Me.FileName)
            Dim image As Image = image.FromStream(ms)
            ' Get the globally unique identifier (GUID) 
            Dim objGuid As Guid = image.FrameDimensionsList(0)

            ' Create the frame dimension 
            Dim frameDimension As New FrameDimension(objGuid)

            'Gets the total number of frames in the .tiff file 
            Return image.GetFrameCount(frameDimension)
            'ms.Dispose()

        End Get
    End Property

    ' Return the memory stream of a specific page 
    Public Function GetSpecificPage(ByVal pageNumber As Integer) As Image

        Dim fsImage As System.IO.FileStream = Nothing

        fsImage = System.IO.File.Open(Me.FileName, FileMode.Open, FileAccess.Read)
        Dim bArrImage(fsImage.Length) As Byte
        fsImage.Read(bArrImage, 0, Convert.ToInt32(fsImage.Length))
        fsImage.Close()

        Dim ms As New MemoryStream(bArrImage)


        'Dim image As Image = image.FromFile(Me.FileName)
        Dim image As Image = image.FromStream(ms)
        ''ms.Dispose()

        Using ms1 As New MemoryStream()
            Dim objGuid As Guid = image.FrameDimensionsList(0)

            Dim objDimension As New FrameDimension(objGuid)

            image.SelectActiveFrame(objDimension, pageNumber)

            image.Save(ms1, ImageFormat.Bmp)

            Dim retImage As Image = image.FromStream(ms1)

            'ms.Dispose()

            Return retImage
        End Using
    End Function

End Class
