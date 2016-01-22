
Imports System.IO
Public Class FormPreview
    Dim tff As TiffImage
    Dim totalimg As Short
    Dim currentimg As Short
    Dim Scanfilename As String
    Dim Scanfilecount As Short
    Dim Scancount As Short
    Public Shared CurrentInstance As FormPreview

    Private Sub FormPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CurrentInstance = Me

        Dim lpFileName As String
        Dim lpFilePath As String

        blnFjtwn = True
        blnOpenScanner = True
        strTwainDS = ""

        cboPaperSupply.SelectedIndex = 0
        Scancount = 1
        Scanfilecount = GetPrivateProfileInt("Scan", "FileCounter", 1, strFilePath).ToString()
        'Generation of a file path
        lpFileName = Application.ExecutablePath
        lpFilePath = Application.StartupPath
        If (IsNothing(lpFilePath) = False) And (IsNothing(lpFileName) = False) Then
            strFilePath = lpFilePath & "\fiScanTest.ini"
            strDirPath = lpFilePath
            strReportFile = lpFilePath & "\Report.txt"
        Else
            strFilePath = ""
            strDirPath = ""
            strReportFile = ""
        End If

        'Scanner pretreatment
        Call OpenScanner()

        Call InitialFileRead()

        'Reading of a configuration file

        'totalimg = tff.PageCount
        'currentimg = 0
        'tff = New TiffImage("")
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If currentimg <> totalimg - 1 Then
            currentimg += 1
        End If
        Try
            PictureBox1.Image = PreviewTiff(currentimg)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If currentimg <> 0 Then
            currentimg -= 1
        End If
        Try
            PictureBox1.Image = PreviewTiff(currentimg)
        Catch ex As Exception

        End Try

    End Sub
    Private Function PreviewTiff(ByVal currentindex As Short) As Image
        Try
            Return tff.GetSpecificPage(currentindex)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub OpenScanner()
        Dim status As Integer
        Dim ErrorCode As Integer

        'Call "OpenScanner" method
        status = AxFiScn1.OpenScanner(Me.Handle.ToInt32)
        If status = RC_FAILURE Then
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("The ""OpenScanner"" function became an error." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
            blnFjtwn = False
            blnOpenScanner = False
        ElseIf status = RC_NOT_DS_FJTWAIN Then
            MsgBox("It is not ""FUJITSU TWAIN32 Driver.""")
            blnFjtwn = False
        End If

        'A "Scan" button is disabled when "OpenScanner" failed.
        If blnOpenScanner = False Then
            btnScan.Enabled = False

        Else
            btnScan.Enabled = True

        End If

        'An image scanner name is displayed on a title.
        If Len(AxFiScn1.ImageScanner) > 0 Then
            Me.Text = "Visual Basic Sample fiScanTest(" & AxFiScn1.ImageScanner & ")"
        Else
            Me.Text = "Visual Basic Sample fiScanTest"
        End If
    End Sub

    Private Sub InitialFileRead()
        Dim topWnd As Long
        Dim leftWnd As Long
        Dim widthWnd As Long
        Dim heightWnd As Long
        Dim strWork As String
        Dim rcl As Integer

        On Error GoTo ReadError
        If strFilePath = "" Then
            GoTo ReadError
        End If

        'Display position information on a dialog
        leftWnd = GetPrivateProfileInt("Form", "Left", -1, strFilePath)
        topWnd = GetPrivateProfileInt("Form", "Top", -1, strFilePath)
        If topWnd <> -1 Then
            Me.Top = topWnd
        End If
        If leftWnd <> -1 Then
            Me.Left = leftWnd
        End If

        'cboPaperSupply.SelectedIndex = GetPrivateProfileInt("Scan", "PaperSupply", ADF, strFilePath)


        ''Read configuration parameter
        'cboScanTo.SelectedIndex = GetPrivateProfileInt("Scan", "ScanToType", TYPE_FILE, strFilePath)
        'cboFileType.SelectedIndex = GetPrivateProfileInt("Scan", "FileType", FILE_TIF, strFilePath)
        'strWork = New String(Chr(0), MAX_PATH)
        'rcl = GetPrivateProfileString("Scan", "FileName", "", strWork, MAX_PATH, strFilePath)
        'If rcl > 0 Then
        '    txtFileName.Text = strWork
        'Else
        '    txtFileName.Text = strDirPath & "\image#####"
        'End If
        'cboOverwrite.SelectedIndex = GetPrivateProfileInt("Scan", "Overwrite", OW_CONFIRM, strFilePath)
        'txtFileCounter.Text = GetPrivateProfileInt("Scan", "FileCounter", 1, strFilePath).ToString()
        'cboCompType.SelectedIndex = GetPrivateProfileInt("Scan", "CompressionType", COMP_MMR, strFilePath)
        'cboJpegQuality.SelectedIndex = GetPrivateProfileInt("Scan", "JpegQuality", COMP_JPEG4, strFilePath)
        'cboPaperSupply.SelectedIndex = GetPrivateProfileInt("Scan", "PaperSupply", ADF, strFilePath)
        'txtScanCount.Text = GetPrivateProfileInt("Scan", "ScanCount", -1, strFilePath).ToString()
        'cboPaperSize.SelectedIndex = GetPrivateProfileInt("Scan", "PaperSize", PSIZE_A4, strFilePath)
        'rcl = GetPrivateProfileInt("Scan", "LongPage", 0, strFilePath)
        'If rcl = 1 Then
        '    chkLongPage.Checked = True
        'Else
        '    chkLongPage.Checked = False
        'End If
        'cboOrientation.SelectedIndex = GetPrivateProfileInt("Scan", "Orientation", PORTRAIT, strFilePath)
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "CustomPaperWidth", "8.268", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtCustomPaperWidth.Text = strWork
        'Else
        '    txtCustomPaperWidth.Text = "8.268"
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "CustomPaperLength", "11.693", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtCustomPaperLength.Text = strWork
        'Else
        '    txtCustomPaperLength.Text = "11.693"
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "RegionLeft", "0", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtRegionLeft.Text = strWork
        'Else
        '    txtRegionLeft.Text = "0"
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "RegionTop", "0", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtRegionTop.Text = strWork
        'Else
        '    txtRegionTop.Text = "0"
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "RegionWidth", "0", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtRegionWidth.Text = strWork
        'Else
        '    txtRegionWidth.Text = "0"
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "RegionLength", "0", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtRegionLength.Text = strWork
        'Else
        '    txtRegionLength.Text = "0"
        'End If
        'rcl = GetPrivateProfileInt("Scan", "UndefinedScanning", 0, strFilePath)
        'If rcl = 1 Then
        '    chkUndefinedScanning.Checked = True
        'Else
        '    chkUndefinedScanning.Checked = False
        'End If
        'cboBackgroundColor.SelectedIndex = GetPrivateProfileInt("Scan", "BackgroundColor", 0, strFilePath)
        'cboPixelType.SelectedIndex = GetPrivateProfileInt("Scan", "PixelType", PIXEL_BLACK_WHITE, strFilePath)
        'cboResolution.SelectedIndex = GetPrivateProfileInt("Scan", "Resolution", RS_300, strFilePath)
        'txtCustomResolution.Text = GetPrivateProfileInt("Scan", "CustomResolution", 300, strFilePath).ToString()
        'txtBrightness.Text = GetPrivateProfileInt("Scan", "Brightness", 128, strFilePath).ToString()
        'txtContrast.Text = GetPrivateProfileInt("Scan", "Contrast", 128, strFilePath).ToString()
        'txtThreshold.Text = GetPrivateProfileInt("Scan", "Threshold", 128, strFilePath).ToString()
        'rcl = GetPrivateProfileInt("Scan", "Reverse", 0, strFilePath)
        'If rcl = 1 Then
        '    chkReverse.Checked = True
        'Else
        '    chkReverse.Checked = False
        'End If
        'rcl = GetPrivateProfileInt("Scan", "Mirroring", 0, strFilePath)
        'If rcl = 1 Then
        '    chkMirroring.Checked = True
        'Else
        '    chkMirroring.Checked = False
        'End If
        'cboRotation.SelectedIndex = GetPrivateProfileInt("Scan", "Rotation", RT_NONE, strFilePath)
        'cboBackground.SelectedIndex = GetPrivateProfileInt("Scan", "Background", MODE_OFF, strFilePath)
        'cboOutline.SelectedIndex = GetPrivateProfileInt("Scan", "Outline", NONE, strFilePath)
        'cboHalftone.SelectedIndex = GetPrivateProfileInt("Scan", "Halftone", NONE, strFilePath)
        'strWork = New String(Chr(0), MAX_PATH)
        'rcl = GetPrivateProfileString("Scan", "HalftoneFile", "", strWork, MAX_PATH, strFilePath)
        'If rcl > 0 Then
        '    txtHalftoneFile.Text = strWork
        'End If
        'cboGamma.SelectedIndex = GetPrivateProfileInt("Scan", "Gamma", NONE, strFilePath)
        'strWork = New String(Chr(0), MAX_PATH)
        'rcl = GetPrivateProfileString("Scan", "GammaFile", "", strWork, MAX_PATH, strFilePath)
        'If rcl > 0 Then
        '    txtGammaFile.Text = strWork
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "CustomGamma", "2.2", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtCustomGamma.Text = strWork
        'Else
        '    txtCustomGamma.Text = "2.2"
        'End If
        'cboAutoSeparation.SelectedIndex = GetPrivateProfileInt("Scan", "AutoSeparation", AS_OFF, strFilePath)
        'cboSEE.SelectedIndex = GetPrivateProfileInt("Scan", "SEE", SEE_OFF, strFilePath)
        'cboThresholdCurve.SelectedIndex = GetPrivateProfileInt("Scan", "ThresholdCurve", TH_CURVE1, strFilePath)
        'cboNoiseRemoval.SelectedIndex = GetPrivateProfileInt("Scan", "NoiseRemoval", NONE, strFilePath)
        'rcl = GetPrivateProfileInt("Scan", "PreFiltering", 0, strFilePath)
        'If rcl = 1 Then
        '    chkPreFiltering.Checked = True
        'Else
        '    chkPreFiltering.Checked = False
        'End If
        'rcl = GetPrivateProfileInt("Scan", "Smoothing", 0, strFilePath)
        'If rcl = 1 Then
        '    chkSmoothing.Checked = True
        'Else
        '    chkSmoothing.Checked = False
        'End If
        'rcl = GetPrivateProfileInt("Scan", "Endorser", 0, strFilePath)
        'If rcl = 1 Then
        '    chkEndorser.Checked = True
        'Else
        '    chkEndorser.Checked = False
        '    txtEndorserCounter.Enabled = False
        '    txtEndorserString.Enabled = False
        '    txtEndorserOffset.Enabled = False
        '    cboEndorserDirection.Enabled = False
        '    cboEndorserCountStep.Enabled = False
        '    cboEndorserCountDirection.Enabled = False
        'End If
        'txtEndorserCounter.Text = GetPrivateProfileInt("Scan", "EndorserCounter", 0, strFilePath).ToString()
        'strWork = New String(Chr(0), 50)
        'rcl = GetPrivateProfileString("Scan", "EndorserString", "", strWork, 50, strFilePath)
        'If rcl > 0 Then
        '    txtEndorserString.Text = strWork
        'End If
        'strWork = New String(Chr(0), 10)
        'rcl = GetPrivateProfileString("Scan", "EndorserOffset", "0", strWork, 10, strFilePath)
        'If rcl > 0 Then
        '    txtEndorserOffset.Text = strWork
        'Else
        '    txtEndorserOffset.Text = "0"
        'End If
        'cboEndorserDirection.SelectedIndex = GetPrivateProfileInt("Scan", "EndorserDirection", 0, strFilePath)
        'cboEndorserCountStep.SelectedIndex = GetPrivateProfileInt("Scan", "EndorserCountStep", 1, strFilePath)
        'cboEndorserCountDirection.SelectedIndex = GetPrivateProfileInt("Scan", "EndorserCountDirection", 0, strFilePath)
        'cboJobControl.SelectedIndex = GetPrivateProfileInt("Scan", "JobControl", 0, strFilePath)
        'cboBinding.SelectedIndex = GetPrivateProfileInt("Scan", "Binding", 0, strFilePath)
        'cboMultiFeed.SelectedIndex = GetPrivateProfileInt("Scan", "DoubleFeed", 0, strFilePath)
        'cboFilter.SelectedIndex = GetPrivateProfileInt("Scan", "Filter", FILTER_GREEN, strFilePath)
        'txtSkipWhitePage.Text = GetPrivateProfileInt("Scan", "SkipWhitePage", 0, strFilePath).ToString()
        'txtSkipBlackPage.Text = GetPrivateProfileInt("Scan", "SkipBlackPage", 0, strFilePath).ToString()
        'rcl = GetPrivateProfileInt("Scan", "AutoBorderDerection", 0, strFilePath)
        'If rcl = 1 Then
        '    chkAutoBorderDetection.Checked = True
        'Else
        '    chkAutoBorderDetection.Checked = False
        'End If
        'rcl = GetPrivateProfileInt("Scan", "ShowSourceUI", 0, strFilePath)
        'If rcl = 1 Then
        '    MenuItemShowSourceUI.Checked = True
        'Else
        '    MenuItemShowSourceUI.Checked = False
        'End If
        'rcl = GetPrivateProfileInt("Scan", "CloseSourceUI", 0, strFilePath)
        'If rcl = 1 Then
        '    MenuItemCloseSourceUI.Checked = True
        'Else
        '    MenuItemCloseSourceUI.Checked = False
        'End If
        'rcl = GetPrivateProfileInt("Scan", "SourceCurrentScan", 0, strFilePath)
        'If rcl = 1 Then
        '    MenuItemSourceCurrentScan.Checked = True
        'Else
        '    MenuItemSourceCurrentScan.Checked = False
        'End If
        'MenuItemTWAINTemplate.Enabled = MenuItemSourceCurrentScan.Checked
        'rcl = GetPrivateProfileInt("Scan", "SilentMode", 0, strFilePath)
        'If rcl = 1 Then
        '    MenuItemSilentMode.Checked = True
        'Else
        '    MenuItemSilentMode.Checked = False
        'End If
        'intReport = GetPrivateProfileInt("Scan", "Report", RP_OFF, strFilePath)
        'MenuItemReportOFF.Checked = False
        'MenuItemReportDisplay.Checked = False
        'MenuItemReportFile.Checked = False
        'MenuItemReportBoth.Checked = False
        'If intReport = 0 Then
        '    MenuItemReportOFF.Checked = True
        'ElseIf intReport = 1 Then
        '    MenuItemReportDisplay.Checked = True
        'ElseIf intReport = 2 Then
        '    MenuItemReportFile.Checked = True
        'Else
        '    MenuItemReportBoth.Checked = True
        'End If
        'rcl = GetPrivateProfileInt("Scan", "Indicator", 0, strFilePath)
        'If rcl = 1 Then
        '    MenuItemIndicator.Checked = True
        'Else
        '    MenuItemIndicator.Checked = False
        'End If
        'txtHighlight.Text = GetPrivateProfileInt("Scan", "Highlight", 230, strFilePath).ToString()
        'txtShadow.Text = GetPrivateProfileInt("Scan", "Shadow", 10, strFilePath).ToString()
        'cboOverScan.SelectedIndex = GetPrivateProfileInt("Scan", "OverScan", 0, strFilePath)
        'cboUnit.SelectedIndex = GetPrivateProfileInt("Scan", "Unit", 0, strFilePath)

        bInitialFileRead = True
        'CarrierSheetSet()
        Exit Sub

ReadError:

        'A default value is used when reading of a ini file goes wrong.
        'Call DefaultSet()

    End Sub

    Private Function HexString(ByRef ErrorCode As Integer) As String
        Dim strWork As Object
        strWork = Hex(ErrorCode)
        If Len(strWork) = 1 Then
            strWork = "0x0000000" & strWork
        ElseIf Len(strWork) = 2 Then
            strWork = "0x000000" & strWork
        ElseIf Len(strWork) = 3 Then
            strWork = "0x00000" & strWork
        ElseIf Len(strWork) = 4 Then
            strWork = "0x0000" & strWork
        ElseIf Len(strWork) = 5 Then
            strWork = "0x000" & strWork
        ElseIf Len(strWork) = 6 Then
            strWork = "0x00" & strWork
        ElseIf Len(strWork) = 7 Then
            strWork = "0x0" & strWork
        Else
            strWork = "0x" & strWork
        End If
        HexString = strWork
    End Function

    Private Sub ScanModeSet(ByVal Filename As String)
        'Scanner parameter setting 
        Dim strWork As String
        Dim rcl As Integer


        Dim ScanLongPage As Boolean
        Dim ScanUndefinedScanning As Boolean
        Dim ScanReverse As Boolean
        Dim ScanMirroring As Boolean
        Dim ScanPreFiltering As Boolean
        Dim ScanSmoothing As Boolean
        Dim ScanEndorser As Boolean
        Dim ScanIndicator As Boolean
        Dim ScanAutoBorderDerection As Boolean
        Dim ScanShowSourceUI As Boolean
        Dim ScanCloseSourceUI As Boolean
        Dim ScanSourceCurrentScan As Boolean
        Dim ScanSilentMode As Boolean


        AxFiScn1.Outline = NONE
        AxFiScn1.ScanTo = GetPrivateProfileInt("Scan", "ScanToType", TYPE_FILE, strFilePath)
        AxFiScn1.FileType = GetPrivateProfileInt("Scan", "FileType", FILE_TIF, strFilePath)
        strWork = New String(Chr(0), MAX_PATH)
        AxFiScn1.FileName = Application.StartupPath & "\Temp\" & Filename
        AxFiScn1.Overwrite = GetPrivateProfileInt("Scan", "Overwrite", OW_ON, strFilePath)
        AxFiScn1.FileCounter = Integer.Parse(GetPrivateProfileInt("Scan", "FileCounter", 1, strFilePath).ToString())
        AxFiScn1.CompressionType = GetPrivateProfileInt("Scan", "CompressionType", COMP_MMR, strFilePath)
        AxFiScn1.JpegQuality = GetPrivateProfileInt("Scan", "JpegQuality", COMP_JPEG4, strFilePath)
        AxFiScn1.PixelType = GetPrivateProfileInt("Scan", "PixelType", PIXEL_BLACK_WHITE, strFilePath)
        AxFiScn1.Resolution = GetPrivateProfileInt("Scan", "Resolution", RS_300, strFilePath)
        AxFiScn1.Brightness = Short.Parse(GetPrivateProfileInt("Scan", "Brightness", 128, strFilePath).ToString())
        AxFiScn1.Contrast = Short.Parse(GetPrivateProfileInt("Scan", "Contrast", 128, strFilePath).ToString())
        AxFiScn1.Threshold = Short.Parse(GetPrivateProfileInt("Scan", "Threshold", 128, strFilePath).ToString())
        AxFiScn1.Rotation = GetPrivateProfileInt("Scan", "Rotation", RT_NONE, strFilePath)
        AxFiScn1.Background = GetPrivateProfileInt("Scan", "Background", MODE_OFF, strFilePath)
        AxFiScn1.Outline = GetPrivateProfileInt("Scan", "Outline", NONE, strFilePath)
        AxFiScn1.Halftone = GetPrivateProfileInt("Scan", "Halftone", NONE, strFilePath)
        AxFiScn1.HalftoneFile = GetPrivateProfileString("Scan", "HalftoneFile", "", strWork, MAX_PATH, strFilePath)
        AxFiScn1.Gamma = GetPrivateProfileInt("Scan", "Gamma", NONE, strFilePath)
        strWork = New String(Chr(0), MAX_PATH)
        AxFiScn1.GammaFile = GetPrivateProfileString("Scan", "GammaFile", "", strWork, MAX_PATH, strFilePath)
        AxFiScn1.CustomGamma = GetPrivateProfileString("Scan", "CustomGamma", "2.2", strWork, 10, strFilePath)
        AxFiScn1.AutoSeparation = GetPrivateProfileInt("Scan", "AutoSeparation", AS_OFF, strFilePath)
        AxFiScn1.SEE = GetPrivateProfileInt("Scan", "SEE", SEE_OFF, strFilePath)

        AxFiScn1.PaperSupply = cboPaperSupply.SelectedIndex + 1

        AxFiScn1.ScanCount = Short.Parse(GetPrivateProfileInt("Scan", "ScanCount", -1, strFilePath).ToString())
        AxFiScn1.PaperSize = GetPrivateProfileInt("Scan", "PaperSize", PSIZE_A4, strFilePath)

        AxFiScn1.Orientation = GetPrivateProfileInt("Scan", "Orientation", PORTRAIT, strFilePath)
        AxFiScn1.CustomPaperWidth = Single.Parse(GetPrivateProfileString("Scan", "CustomPaperWidth", "8.268", strWork, 10, strFilePath))
        AxFiScn1.CustomPaperLength = Single.Parse(GetPrivateProfileString("Scan", "CustomPaperLength", "11.693", strWork, 10, strFilePath))
        AxFiScn1.RegionLeft = Single.Parse(GetPrivateProfileString("Scan", "RegionLeft", "0", strWork, 10, strFilePath))
        AxFiScn1.RegionTop = Single.Parse(GetPrivateProfileString("Scan", "RegionTop", "0", strWork, 10, strFilePath))
        AxFiScn1.RegionWidth = Single.Parse(GetPrivateProfileString("Scan", "RegionWidth", "0", strWork, 10, strFilePath))
        AxFiScn1.RegionLength = Single.Parse(GetPrivateProfileString("Scan", "RegionLength", "0", strWork, 10, strFilePath))
        AxFiScn1.BackgroundColor = GetPrivateProfileInt("Scan", "BackgroundColor", 0, strFilePath)
        AxFiScn1.ThresholdCurve = GetPrivateProfileInt("Scan", "ThresholdCurve", TH_CURVE1, strFilePath)
        AxFiScn1.NoiseRemoval = GetPrivateProfileInt("Scan", "NoiseRemoval", NONE, strFilePath)
        strWork = New String(Chr(0), 10)
        AxFiScn1.EndorserOffset = Single.Parse(GetPrivateProfileString("Scan", "EndorserOffset", "0", strWork, 10, strFilePath))
        AxFiScn1.EndorserString = GetPrivateProfileString("Scan", "EndorserString", "", strWork, 50, strFilePath)
        AxFiScn1.EndorserCounter = Integer.Parse(GetPrivateProfileInt("Scan", "EndorserCounter", 0, strFilePath).ToString())
        AxFiScn1.EndorserCountStep = GetPrivateProfileInt("Scan", "EndorserCountStep", 1, strFilePath)
        AxFiScn1.EndorserCountDirection = GetPrivateProfileInt("Scan", "EndorserCountDirection", 0, strFilePath)
        AxFiScn1.JobControl = GetPrivateProfileInt("Scan", "JobControl", 0, strFilePath)
        AxFiScn1.Binding = GetPrivateProfileInt("Scan", "Binding", 0, strFilePath)
        AxFiScn1.MultiFeed = GetPrivateProfileInt("Scan", "DoubleFeed", 0, strFilePath)
        AxFiScn1.Filter = GetPrivateProfileInt("Scan", "Filter", FILTER_GREEN, strFilePath)
        AxFiScn1.SkipWhitePage = Short.Parse(GetPrivateProfileInt("Scan", "SkipWhitePage", 0, strFilePath).ToString())
        AxFiScn1.SkipBlackPage = Short.Parse(GetPrivateProfileInt("Scan", "SkipBlackPage", 0, strFilePath).ToString())

        AxFiScn1.Report = GetPrivateProfileInt("Scan", "Report", RP_OFF, strFilePath)
        AxFiScn1.ReportFile = strReportFile
        AxFiScn1.TwainDS = strTwainDS
        AxFiScn1.Highlight = Short.Parse(GetPrivateProfileInt("Scan", "Highlight", 230, strFilePath).ToString())
        AxFiScn1.Shadow = Short.Parse(GetPrivateProfileInt("Scan", "Shadow", 10, strFilePath).ToString())
        AxFiScn1.OverScan = GetPrivateProfileInt("Scan", "OverScan", 0, strFilePath)
        AxFiScn1.Unit = GetPrivateProfileInt("Scan", "Unit", 0, strFilePath)



        rcl = GetPrivateProfileInt("Scan", "LongPage", 0, strFilePath)
        If rcl = 1 Then
            ScanLongPage = True
        Else
            ScanLongPage = False
        End If
        rcl = GetPrivateProfileInt("Scan", "UndefinedScanning", 0, strFilePath)
        If rcl = 1 Then
            ScanUndefinedScanning = True
        Else
            ScanUndefinedScanning = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Reverse", 0, strFilePath)
        If rcl = 1 Then
            ScanReverse = True
        Else
            ScanReverse = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Mirroring", 0, strFilePath)
        If rcl = 1 Then
            ScanMirroring = True
        Else
            ScanMirroring = False
        End If

        rcl = GetPrivateProfileInt("Scan", "PreFiltering", 0, strFilePath)
        If rcl = 1 Then
            ScanPreFiltering = True
        Else
            ScanPreFiltering = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Smoothing", 0, strFilePath)
        If rcl = 1 Then
            ScanSmoothing = True
        Else
            ScanSmoothing = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Endorser", 0, strFilePath)
        If rcl = 1 Then
            ScanEndorser = True
        Else
            ScanEndorser = False

        End If

        rcl = GetPrivateProfileInt("Scan", "AutoBorderDerection", 0, strFilePath)
        If rcl = 1 Then
            ScanAutoBorderDerection = True
        Else
            ScanAutoBorderDerection = False
        End If
        rcl = GetPrivateProfileInt("Scan", "ShowSourceUI", 0, strFilePath)
        If rcl = 1 Then
            ScanShowSourceUI = True
        Else
            ScanShowSourceUI = False
        End If
        rcl = GetPrivateProfileInt("Scan", "CloseSourceUI", 0, strFilePath)
        If rcl = 1 Then
            ScanCloseSourceUI = True
        Else
            ScanCloseSourceUI = False
        End If
        rcl = GetPrivateProfileInt("Scan", "SourceCurrentScan", 0, strFilePath)
        If rcl = 1 Then
            ScanSourceCurrentScan = True
        Else
            ScanSourceCurrentScan = False
        End If
        rcl = GetPrivateProfileInt("Scan", "SilentMode", 0, strFilePath)
        If rcl = 1 Then
            ScanSilentMode = True
        Else
            ScanSilentMode = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Indicator", 0, strFilePath)
        If rcl = 1 Then
            ScanIndicator = True
        Else
            ScanIndicator = False
        End If

        AxFiScn1.Reverse = ScanReverse
        AxFiScn1.Mirroring = ScanMirroring
        AxFiScn1.LongPage = ScanLongPage
        AxFiScn1.UndefinedScanning = ScanUndefinedScanning
        AxFiScn1.PreFiltering = ScanPreFiltering
        AxFiScn1.Smoothing = ScanSmoothing
        AxFiScn1.Endorser = ScanEndorser
        AxFiScn1.AutoBorderDetection = ScanAutoBorderDerection
        AxFiScn1.ShowSourceUI = ScanShowSourceUI
        AxFiScn1.CloseSourceUI = ScanCloseSourceUI
        AxFiScn1.SourceCurrentScan = ScanSourceCurrentScan
        AxFiScn1.SilentMode = ScanSilentMode
        AxFiScn1.Indicator = ScanIndicator
    End Sub

    Private Sub WriteScanINIFile()
        Dim strWork As String
        Dim rcl As Integer

        'On Error GoTo WriteError
        'If strFilePath = "" Then
        '    GoTo WriteError
        'End If

        'Display position information on a dialog
        rcl = WritePrivateProfileString("Form", "Left", Me.Left.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Form", "Top", Me.Top.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "FileCounter", Scanfilecount, strFilePath)

        'Write configuration parameter
        '        rcl = WritePrivateProfileString("Scan", "ScanToType", cboScanTo.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "FileType", cboFileType.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "FileName", txtFileName.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Overwrite", cboOverwrite.SelectedIndex.ToString(), strFilePath)
        '        
        '        rcl = WritePrivateProfileString("Scan", "CompressionType", cboCompType.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "JpegQuality", cboJpegQuality.SelectedIndex.ToString(), strFilePath)

        '        rcl = WritePrivateProfileString("Scan", "ScanCount", txtScanCount.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "PaperSize", cboPaperSize.SelectedIndex.ToString(), strFilePath)
        '        If chkLongPage.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "LongPage", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "LongPage", "0", strFilePath)
        '        End If
        '        rcl = WritePrivateProfileString("Scan", "Orientation", cboOrientation.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "CustomPaperWidth", txtCustomPaperWidth.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "CustomPaperLength", txtCustomPaperLength.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "RegionLeft", txtRegionLeft.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "RegionTop", txtRegionTop.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "RegionWidth", txtRegionWidth.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "RegionLength", txtRegionLength.Text, strFilePath)
        '        If chkUndefinedScanning.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "UndefinedScanning", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "UndefinedScanning", "0", strFilePath)
        '        End If
        '        rcl = WritePrivateProfileString("Scan", "BackgroundColor", cboBackgroundColor.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "PixelType", cboPixelType.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Resolution", cboResolution.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "CustomResolution", txtCustomResolution.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Brightness", txtBrightness.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Contrast", txtContrast.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Threshold", txtThreshold.Text, strFilePath)
        '        If chkReverse.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "Reverse", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "Reverse", "0", strFilePath)
        '        End If
        '        If chkMirroring.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "Mirroring", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "Mirroring", "0", strFilePath)
        '        End If
        '        rcl = WritePrivateProfileString("Scan", "Rotation", cboRotation.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Background", cboBackground.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Outline", cboOutline.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Halftone", cboHalftone.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "HalftoneFile", txtHalftoneFile.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Gamma", cboGamma.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "GammaFile", txtGammaFile.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "CustomGamma", txtCustomGamma.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "AutoSeparation", cboAutoSeparation.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "SEE", cboSEE.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "ThresholdCurve", cboThresholdCurve.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "NoiseRemoval", cboNoiseRemoval.SelectedIndex.ToString(), strFilePath)
        '        If chkPreFiltering.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "PreFiltering", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "PreFiltering", "0", strFilePath)
        '        End If
        '        If chkSmoothing.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "Smoothing", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "Smoothing", "0", strFilePath)
        '        End If

        '        If chkEndorser.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "Endorser", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "Endorser", "0", strFilePath)
        '        End If
        '        rcl = WritePrivateProfileString("Scan", "EndorserCounter", txtEndorserCounter.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "EndorserString", txtEndorserString.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "EndorserOffset", txtEndorserOffset.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "EndorserDirection", cboEndorserDirection.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "EndorserCountStep", cboEndorserCountStep.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "EndorserCountDirection", cboEndorserCountDirection.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "JobControl", cboJobControl.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Binding", cboBinding.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "DoubleFeed", cboMultiFeed.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Filter", cboFilter.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "SkipWhitePage", txtSkipWhitePage.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "SkipBlackPage", txtSkipBlackPage.Text, strFilePath)
        '        If chkAutoBorderDetection.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "AutoBorderDerection", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "AutoBorderDerection", "0", strFilePath)
        '        End If

        '        If MenuItemShowSourceUI.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "ShowSourceUI", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "ShowSourceUI", "0", strFilePath)
        '        End If
        '        If MenuItemCloseSourceUI.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "CloseSourceUI", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "CloseSourceUI", "0", strFilePath)
        '        End If
        '        If MenuItemSourceCurrentScan.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "SourceCurrentScan", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "SourceCurrentScan", "0", strFilePath)
        '        End If
        '        If MenuItemSilentMode.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "SilentMode", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "SilentMode", "0", strFilePath)
        '        End If
        '        rcl = WritePrivateProfileString("Scan", "Report", intReport.ToString(), strFilePath)
        '        If MenuItemIndicator.Checked = True Then
        '            rcl = WritePrivateProfileString("Scan", "Indicator", "1", strFilePath)
        '        Else
        '            rcl = WritePrivateProfileString("Scan", "Indicator", "0", strFilePath)
        '        End If
        '        rcl = WritePrivateProfileString("Scan", "Highlight", txtHighlight.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Shadow", txtShadow.Text, strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "OverScan", cboOverScan.SelectedIndex.ToString(), strFilePath)
        '        rcl = WritePrivateProfileString("Scan", "Unit", cboUnit.SelectedIndex.ToString(), strFilePath)

        '        Exit Sub

        'WriteError:
        '        MsgBox(ERRORMSG2)

    End Sub
    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Dim filename As String = "TEST"

        PictureBox1.Image = Nothing

        Call StartScan(filename & Scancount & "###")


        PictureBox1.Image = LoadImageFromStream(Application.StartupPath & "\Temp\" & filename & Scancount & Scanfilecount.ToString("000") & ".tif")
        tff = New TiffImage(Application.StartupPath & "\Temp\" & filename & Scancount & Scanfilecount.ToString("000") & ".tif")

        'If tff.PageCount > 1 Then
        '    btnPrevious.Enabled = True
        '    btnNext.Enabled = True
        'Else
        '    btnPrevious.Enabled = False
        '    btnNext.Enabled = False
        'End If

        Scancount += 1

        Call WriteScanINIFile()

    End Sub
    Private Sub StartScan(ByVal Filename As String)
        Dim status As Integer
        Dim ErrorCode As Integer
        Dim frmCancelScan As New FormCancelScan

        'A scanning parameter is set as scanner control.
        Call ScanModeSet(Filename)

        'frmCancelScan.StartPosition = FormStartPosition.Manual
        'frmCancelScan.Top = Me.Top
        'frmCancelScan.Left = Me.Left + Me.Width
        'frmCancelScan.Owner = Me
        'frmCancelScan.Show()

        'Scanning start
        status = AxFiScn1.StartScan(Me.Handle.ToInt32)
        'failure
        If status = RC_FAILURE Then
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("The scanning error occurred." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
            'cancel
        ElseIf status = RC_CANCEL Then
            MsgBox("The user canceled scanning." & Chr(13) & "Or the error which cannot continue scanning was detected.")
        Else
        End If

        'Update of FileCounter
        'txtFileCounter.Text = AxFiScn1.FileCounter.ToString()

        'frmCancelScan.Close()

    End Sub

    Private Function LoadImageFromStream(ByVal Filename As String) As Image
        Dim img As Image = Nothing
        Try
            Dim fs As FileStream
            Dim br As BinaryReader

            fs = New FileStream(Filename, FileMode.Open)
            br = New BinaryReader(fs)
            Dim arrBytes As Byte() = New Byte() {}
            arrBytes = br.ReadBytes(fs.Length)
            fs.Close()
            br.Close()
            fs.Dispose()

            Dim hStream As New MemoryStream(arrBytes)
            Dim hImage As Image = Image.FromStream(hStream)
            If (Not hImage Is Nothing) Then
                img = hImage
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return img
    End Function

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If UploadFile(Scanfilename) Then

        End If
    End Sub
    Private Function UploadFile(ByVal Filename As String) As Boolean
        Dim Result As Boolean
        Dim strFilename As String
        'Dim ScannerUpload As New BOIWebservice.WebServiceDms
        strFilename = System.IO.Path.GetFileName(Filename)
        Dim Finfo As New FileInfo(strFilename)
        Dim NumBytes As Long = Finfo.Length
        Dim dLen As Double = Convert.ToDouble(Finfo.Length / 1000000)

        If dLen < 4 Then
            Dim fStream As FileStream = New FileStream(Filename, FileMode.Open, FileAccess.Read)
            Dim ByteRead As New BinaryReader(fStream)
            Dim bytedata As Byte() = ByteRead.ReadBytes(CInt(NumBytes))
            ByteRead.Close()

            'If ScannerUpload.UploadScanFiles(bytedata, Filename) Then
            '    Result = True
            'Else
            '    Result = False
            'End If
            fStream.Close()
            fStream.Dispose()

        End If

        Return Result

    End Function
   
End Class