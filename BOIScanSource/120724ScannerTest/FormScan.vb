'****************************************************************************
'
'   Scanner Control SDK Test Program
'
'   Copyright PFU LIMITED 2005-2011
'
'****************************************************************************
Public Class FormScan
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        Try
            InitializeComponent()
        Catch Exec As System.Runtime.InteropServices.COMException
            MsgBox("The class is not registered.")
            Environment.Exit(-1)
        End Try

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemScanner As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemStartScan As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelectSource As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemClearPage As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemOption As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemHelp As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVersion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemShowSourceUI As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCloseSourceUI As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSourceCurrentScan As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSilentMode As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReportOFF As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReportDisplay As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReportFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReportBoth As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonScan As System.Windows.Forms.Button
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ButtonReset As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboScanTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboOverwrite As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFileCounter As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCompType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboJpegQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPixelType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboResolution As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCustomResolution As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtScanCount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboPaperSupply As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkLongPage As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPaperSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboOrientation As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboBackgroundColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtCustomPaperWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtRegionLeft As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtRegionTop As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtRegionWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtRegionLength As System.Windows.Forms.TextBox
    Friend WithEvents chkUndefinedScanning As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtBrightness As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents hsbBrightness As System.Windows.Forms.HScrollBar
    Friend WithEvents hsbContrast As System.Windows.Forms.HScrollBar
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtContrast As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents hsbThreshold As System.Windows.Forms.HScrollBar
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtThreshold As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents chkReverse As System.Windows.Forms.CheckBox
    Friend WithEvents chkMirroring As System.Windows.Forms.CheckBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cboRotation As System.Windows.Forms.ComboBox
    Friend WithEvents cboBackground As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cboOutline As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cboAutoSeparation As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cboSEE As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cboHalftone As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cboGamma As System.Windows.Forms.ComboBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtHalftoneFile As System.Windows.Forms.TextBox
    Friend WithEvents txtGammaFile As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtCustomGamma As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cboThresholdCurve As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cboNoiseRemoval As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents chkSmoothing As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents chkPreFiltering As System.Windows.Forms.CheckBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents chkEndorser As System.Windows.Forms.CheckBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents txtEndorserCounter As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtEndorserString As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents txtEndorserOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents cboEndorserDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents cboEndorserCountStep As System.Windows.Forms.ComboBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents cboEndorserCountDirection As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cboJobControl As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents cboBinding As System.Windows.Forms.ComboBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents cboMultiFeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtSkipWhitePage As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtSkipBlackPage As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtCustomPaperLength As System.Windows.Forms.TextBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents MenuItemSIPCTemplate As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemTWAINTemplate As System.Windows.Forms.MenuItem
    Friend WithEvents chkAutoBorderDetection As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItemIndicator As System.Windows.Forms.MenuItem
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents txtHighlight As System.Windows.Forms.TextBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents hsbHighlight As System.Windows.Forms.HScrollBar
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents txtShadow As System.Windows.Forms.TextBox
    Friend WithEvents hsbShadow As System.Windows.Forms.HScrollBar
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents cboOverScan As System.Windows.Forms.ComboBox
    Friend WithEvents MenuItemSeparator4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFeederLoaded As System.Windows.Forms.MenuItem
    Friend WithEvents AxFiScn1 As AxFiScnLib.AxFiScn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormScan))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemFile = New System.Windows.Forms.MenuItem
        Me.MenuItemExit = New System.Windows.Forms.MenuItem
        Me.MenuItemScanner = New System.Windows.Forms.MenuItem
        Me.MenuItemStartScan = New System.Windows.Forms.MenuItem
        Me.MenuItemSeparator1 = New System.Windows.Forms.MenuItem
        Me.MenuItemSelectSource = New System.Windows.Forms.MenuItem
        Me.MenuItemSeparator2 = New System.Windows.Forms.MenuItem
        Me.MenuItemClearPage = New System.Windows.Forms.MenuItem
        Me.MenuItemSeparator4 = New System.Windows.Forms.MenuItem
        Me.MenuItemFeederLoaded = New System.Windows.Forms.MenuItem
        Me.MenuItemOption = New System.Windows.Forms.MenuItem
        Me.MenuItemShowSourceUI = New System.Windows.Forms.MenuItem
        Me.MenuItemCloseSourceUI = New System.Windows.Forms.MenuItem
        Me.MenuItemSourceCurrentScan = New System.Windows.Forms.MenuItem
        Me.MenuItemSilentMode = New System.Windows.Forms.MenuItem
        Me.MenuItemIndicator = New System.Windows.Forms.MenuItem
        Me.MenuItemReport = New System.Windows.Forms.MenuItem
        Me.MenuItemReportOFF = New System.Windows.Forms.MenuItem
        Me.MenuItemReportDisplay = New System.Windows.Forms.MenuItem
        Me.MenuItemReportFile = New System.Windows.Forms.MenuItem
        Me.MenuItemReportBoth = New System.Windows.Forms.MenuItem
        Me.MenuItemSeparator3 = New System.Windows.Forms.MenuItem
        Me.MenuItemSIPCTemplate = New System.Windows.Forms.MenuItem
        Me.MenuItemTWAINTemplate = New System.Windows.Forms.MenuItem
        Me.MenuItemHelp = New System.Windows.Forms.MenuItem
        Me.MenuItemVersion = New System.Windows.Forms.MenuItem
        Me.ButtonScan = New System.Windows.Forms.Button
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.ButtonReset = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboUnit = New System.Windows.Forms.ComboBox
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtRegionLength = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtRegionWidth = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtRegionTop = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtRegionLeft = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtCustomPaperLength = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCustomPaperWidth = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboBackgroundColor = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboOrientation = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.chkUndefinedScanning = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboPaperSize = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.chkLongPage = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboPaperSupply = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtScanCount = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCustomResolution = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboResolution = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboPixelType = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboJpegQuality = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCompType = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFileCounter = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboOverwrite = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFileType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboScanTo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkSmoothing = New System.Windows.Forms.CheckBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.chkPreFiltering = New System.Windows.Forms.CheckBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.cboNoiseRemoval = New System.Windows.Forms.ComboBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.cboThresholdCurve = New System.Windows.Forms.ComboBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.hsbShadow = New System.Windows.Forms.HScrollBar
        Me.txtShadow = New System.Windows.Forms.TextBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.hsbHighlight = New System.Windows.Forms.HScrollBar
        Me.Label74 = New System.Windows.Forms.Label
        Me.txtHighlight = New System.Windows.Forms.TextBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtCustomGamma = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtGammaFile = New System.Windows.Forms.TextBox
        Me.txtHalftoneFile = New System.Windows.Forms.TextBox
        Me.cboGamma = New System.Windows.Forms.ComboBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.cboHalftone = New System.Windows.Forms.ComboBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.cboSEE = New System.Windows.Forms.ComboBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.cboAutoSeparation = New System.Windows.Forms.ComboBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.cboOutline = New System.Windows.Forms.ComboBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.cboBackground = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.cboRotation = New System.Windows.Forms.ComboBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.chkMirroring = New System.Windows.Forms.CheckBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.chkReverse = New System.Windows.Forms.CheckBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.hsbThreshold = New System.Windows.Forms.HScrollBar
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtThreshold = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.hsbContrast = New System.Windows.Forms.HScrollBar
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtContrast = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.hsbBrightness = New System.Windows.Forms.HScrollBar
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtBrightness = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cboOverScan = New System.Windows.Forms.ComboBox
        Me.Label77 = New System.Windows.Forms.Label
        Me.chkAutoBorderDetection = New System.Windows.Forms.CheckBox
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.txtSkipBlackPage = New System.Windows.Forms.TextBox
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.txtSkipWhitePage = New System.Windows.Forms.TextBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.cboFilter = New System.Windows.Forms.ComboBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.cboMultiFeed = New System.Windows.Forms.ComboBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.cboBinding = New System.Windows.Forms.ComboBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.cboJobControl = New System.Windows.Forms.ComboBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cboEndorserCountDirection = New System.Windows.Forms.ComboBox
        Me.Label62 = New System.Windows.Forms.Label
        Me.cboEndorserCountStep = New System.Windows.Forms.ComboBox
        Me.Label61 = New System.Windows.Forms.Label
        Me.cboEndorserDirection = New System.Windows.Forms.ComboBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.txtEndorserOffset = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.txtEndorserString = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.txtEndorserCounter = New System.Windows.Forms.TextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.chkEndorser = New System.Windows.Forms.CheckBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.AxFiScn1 = New AxFiScnLib.AxFiScn
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.AxFiScn1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFile, Me.MenuItemScanner, Me.MenuItemOption, Me.MenuItemHelp})
        '
        'MenuItemFile
        '
        Me.MenuItemFile.Index = 0
        Me.MenuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemExit})
        Me.MenuItemFile.Text = "&File"
        '
        'MenuItemExit
        '
        Me.MenuItemExit.Index = 0
        Me.MenuItemExit.Text = "&Exit"
        '
        'MenuItemScanner
        '
        Me.MenuItemScanner.Index = 1
        Me.MenuItemScanner.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemStartScan, Me.MenuItemSeparator1, Me.MenuItemSelectSource, Me.MenuItemSeparator2, Me.MenuItemClearPage, Me.MenuItemSeparator4, Me.MenuItemFeederLoaded})
        Me.MenuItemScanner.Text = "&Scanner"
        '
        'MenuItemStartScan
        '
        Me.MenuItemStartScan.Index = 0
        Me.MenuItemStartScan.Text = "&StartScan"
        '
        'MenuItemSeparator1
        '
        Me.MenuItemSeparator1.Index = 1
        Me.MenuItemSeparator1.Text = "-"
        '
        'MenuItemSelectSource
        '
        Me.MenuItemSelectSource.Index = 2
        Me.MenuItemSelectSource.Text = "Se&lectSource..."
        '
        'MenuItemSeparator2
        '
        Me.MenuItemSeparator2.Index = 3
        Me.MenuItemSeparator2.Text = "-"
        '
        'MenuItemClearPage
        '
        Me.MenuItemClearPage.Index = 4
        Me.MenuItemClearPage.Text = "&ClearPage"
        '
        'MenuItemSeparator4
        '
        Me.MenuItemSeparator4.Index = 5
        Me.MenuItemSeparator4.Text = "-"
        '
        'MenuItemFeederLoaded
        '
        Me.MenuItemFeederLoaded.Index = 6
        Me.MenuItemFeederLoaded.Text = "&FeederLoaded"
        '
        'MenuItemOption
        '
        Me.MenuItemOption.Index = 2
        Me.MenuItemOption.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemShowSourceUI, Me.MenuItemCloseSourceUI, Me.MenuItemSourceCurrentScan, Me.MenuItemSilentMode, Me.MenuItemIndicator, Me.MenuItemReport, Me.MenuItemSeparator3, Me.MenuItemSIPCTemplate, Me.MenuItemTWAINTemplate})
        Me.MenuItemOption.Text = "&Option"
        '
        'MenuItemShowSourceUI
        '
        Me.MenuItemShowSourceUI.Checked = True
        Me.MenuItemShowSourceUI.Index = 0
        Me.MenuItemShowSourceUI.Text = "S&howSourceUI"
        '
        'MenuItemCloseSourceUI
        '
        Me.MenuItemCloseSourceUI.Checked = True
        Me.MenuItemCloseSourceUI.Index = 1
        Me.MenuItemCloseSourceUI.Text = "C&loseSourceUI"
        '
        'MenuItemSourceCurrentScan
        '
        Me.MenuItemSourceCurrentScan.Checked = True
        Me.MenuItemSourceCurrentScan.Index = 2
        Me.MenuItemSourceCurrentScan.Text = "Source&CurrentScan"
        '
        'MenuItemSilentMode
        '
        Me.MenuItemSilentMode.Checked = True
        Me.MenuItemSilentMode.Index = 3
        Me.MenuItemSilentMode.Text = "&SilentMode"
        '
        'MenuItemIndicator
        '
        Me.MenuItemIndicator.Checked = True
        Me.MenuItemIndicator.Index = 4
        Me.MenuItemIndicator.Text = "&Indicator"
        '
        'MenuItemReport
        '
        Me.MenuItemReport.Index = 5
        Me.MenuItemReport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemReportOFF, Me.MenuItemReportDisplay, Me.MenuItemReportFile, Me.MenuItemReportBoth})
        Me.MenuItemReport.Text = "&Report"
        '
        'MenuItemReportOFF
        '
        Me.MenuItemReportOFF.Checked = True
        Me.MenuItemReportOFF.Index = 0
        Me.MenuItemReportOFF.RadioCheck = True
        Me.MenuItemReportOFF.Text = "&OFF"
        '
        'MenuItemReportDisplay
        '
        Me.MenuItemReportDisplay.Index = 1
        Me.MenuItemReportDisplay.RadioCheck = True
        Me.MenuItemReportDisplay.Text = "&Display"
        '
        'MenuItemReportFile
        '
        Me.MenuItemReportFile.Index = 2
        Me.MenuItemReportFile.RadioCheck = True
        Me.MenuItemReportFile.Text = "&File"
        '
        'MenuItemReportBoth
        '
        Me.MenuItemReportBoth.Index = 3
        Me.MenuItemReportBoth.RadioCheck = True
        Me.MenuItemReportBoth.Text = "Display&&File(&B)"
        '
        'MenuItemSeparator3
        '
        Me.MenuItemSeparator3.Index = 6
        Me.MenuItemSeparator3.Text = "-"
        '
        'MenuItemSIPCTemplate
        '
        Me.MenuItemSIPCTemplate.Index = 7
        Me.MenuItemSIPCTemplate.Text = "SoftIPC &Template..."
        '
        'MenuItemTWAINTemplate
        '
        Me.MenuItemTWAINTemplate.Index = 8
        Me.MenuItemTWAINTemplate.Text = "T&WAIN Template..."
        '
        'MenuItemHelp
        '
        Me.MenuItemHelp.Index = 3
        Me.MenuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemVersion})
        Me.MenuItemHelp.Text = "&Help"
        '
        'MenuItemVersion
        '
        Me.MenuItemVersion.Index = 0
        Me.MenuItemVersion.Text = "&Version..."
        '
        'ButtonScan
        '
        Me.ButtonScan.Location = New System.Drawing.Point(595, 38)
        Me.ButtonScan.Name = "ButtonScan"
        Me.ButtonScan.Size = New System.Drawing.Size(72, 26)
        Me.ButtonScan.TabIndex = 2
        Me.ButtonScan.Text = "Scan"
        '
        'ButtonExit
        '
        Me.ButtonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonExit.Location = New System.Drawing.Point(595, 75)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(72, 26)
        Me.ButtonExit.TabIndex = 3
        Me.ButtonExit.Text = "Exit"
        '
        'ButtonReset
        '
        Me.ButtonReset.Location = New System.Drawing.Point(595, 139)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(72, 26)
        Me.ButtonReset.TabIndex = 4
        Me.ButtonReset.Text = "Reset"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(8, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(580, 486)
        Me.TabControl1.TabIndex = 5
        Me.TabControl1.Tag = ""
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(572, 460)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Standard"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboUnit)
        Me.GroupBox3.Controls.Add(Me.Label72)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.txtRegionLength)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.txtRegionWidth)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.txtRegionTop)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.txtRegionLeft)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.txtCustomPaperLength)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtCustomPaperWidth)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.cboBackgroundColor)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.cboOrientation)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.chkUndefinedScanning)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.cboPaperSize)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.chkLongPage)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.cboPaperSupply)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtScanCount)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 190)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.Items.AddRange(New Object() {"Inches", "Centimeters", "Pixels"})
        Me.cboUnit.Location = New System.Drawing.Point(435, 12)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(113, 23)
        Me.cboUnit.TabIndex = 4
        '
        'Label72
        '
        Me.Label72.Location = New System.Drawing.Point(320, 14)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(64, 15)
        Me.Label72.TabIndex = 3
        Me.Label72.Text = "Unit"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(481, 161)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 18)
        Me.Label29.TabIndex = 34
        Me.Label29.Text = "inch"
        '
        'txtRegionLength
        '
        Me.txtRegionLength.Location = New System.Drawing.Point(435, 158)
        Me.txtRegionLength.MaxLength = 6
        Me.txtRegionLength.Name = "txtRegionLength"
        Me.txtRegionLength.Size = New System.Drawing.Size(45, 21)
        Me.txtRegionLength.TabIndex = 33
        Me.txtRegionLength.Text = "0"
        Me.txtRegionLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(320, 160)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(118, 18)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "RegionLength"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(168, 163)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(36, 17)
        Me.Label31.TabIndex = 31
        Me.Label31.Text = "inch"
        '
        'txtRegionWidth
        '
        Me.txtRegionWidth.Location = New System.Drawing.Point(118, 159)
        Me.txtRegionWidth.MaxLength = 6
        Me.txtRegionWidth.Name = "txtRegionWidth"
        Me.txtRegionWidth.Size = New System.Drawing.Size(45, 21)
        Me.txtRegionWidth.TabIndex = 30
        Me.txtRegionWidth.Text = "0"
        Me.txtRegionWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(8, 161)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(106, 18)
        Me.Label32.TabIndex = 29
        Me.Label32.Text = "RegionWidth"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(481, 139)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 17)
        Me.Label27.TabIndex = 28
        Me.Label27.Text = "inch"
        '
        'txtRegionTop
        '
        Me.txtRegionTop.Location = New System.Drawing.Point(435, 135)
        Me.txtRegionTop.MaxLength = 6
        Me.txtRegionTop.Name = "txtRegionTop"
        Me.txtRegionTop.Size = New System.Drawing.Size(45, 21)
        Me.txtRegionTop.TabIndex = 27
        Me.txtRegionTop.Text = "0"
        Me.txtRegionTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(320, 138)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(118, 17)
        Me.Label28.TabIndex = 26
        Me.Label28.Text = "RegionTop"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(168, 140)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(36, 17)
        Me.Label26.TabIndex = 25
        Me.Label26.Text = "inch"
        '
        'txtRegionLeft
        '
        Me.txtRegionLeft.Location = New System.Drawing.Point(118, 137)
        Me.txtRegionLeft.MaxLength = 6
        Me.txtRegionLeft.Name = "txtRegionLeft"
        Me.txtRegionLeft.Size = New System.Drawing.Size(45, 21)
        Me.txtRegionLeft.TabIndex = 24
        Me.txtRegionLeft.Text = "0"
        Me.txtRegionLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(8, 139)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(106, 17)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "RegionLeft"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(481, 115)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(36, 17)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "inch"
        '
        'txtCustomPaperLength
        '
        Me.txtCustomPaperLength.Location = New System.Drawing.Point(435, 112)
        Me.txtCustomPaperLength.MaxLength = 6
        Me.txtCustomPaperLength.Name = "txtCustomPaperLength"
        Me.txtCustomPaperLength.Size = New System.Drawing.Size(45, 21)
        Me.txtCustomPaperLength.TabIndex = 21
        Me.txtCustomPaperLength.Text = ""
        Me.txtCustomPaperLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(320, 115)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(118, 17)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "CustomPaperLength"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(168, 115)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 17)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "inch"
        '
        'txtCustomPaperWidth
        '
        Me.txtCustomPaperWidth.Location = New System.Drawing.Point(118, 112)
        Me.txtCustomPaperWidth.MaxLength = 6
        Me.txtCustomPaperWidth.Name = "txtCustomPaperWidth"
        Me.txtCustomPaperWidth.Size = New System.Drawing.Size(45, 21)
        Me.txtCustomPaperWidth.TabIndex = 18
        Me.txtCustomPaperWidth.Text = ""
        Me.txtCustomPaperWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 115)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 17)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "CustomPaperWidth"
        '
        'cboBackgroundColor
        '
        Me.cboBackgroundColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBackgroundColor.Items.AddRange(New Object() {"OFF", "ON"})
        Me.cboBackgroundColor.Location = New System.Drawing.Point(435, 87)
        Me.cboBackgroundColor.Name = "cboBackgroundColor"
        Me.cboBackgroundColor.Size = New System.Drawing.Size(64, 23)
        Me.cboBackgroundColor.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(320, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 17)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "BackgroundColor"
        '
        'cboOrientation
        '
        Me.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrientation.Items.AddRange(New Object() {"Portrait", "Landscape"})
        Me.cboOrientation.Location = New System.Drawing.Point(118, 86)
        Me.cboOrientation.Name = "cboOrientation"
        Me.cboOrientation.Size = New System.Drawing.Size(105, 23)
        Me.cboOrientation.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 90)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 17)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Orientation"
        '
        'chkUndefinedScanning
        '
        Me.chkUndefinedScanning.Location = New System.Drawing.Point(435, 65)
        Me.chkUndefinedScanning.Name = "chkUndefinedScanning"
        Me.chkUndefinedScanning.Size = New System.Drawing.Size(17, 16)
        Me.chkUndefinedScanning.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(320, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 17)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "UndefinedScanning"
        '
        'cboPaperSize
        '
        Me.cboPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaperSize.ItemHeight = 15
        Me.cboPaperSize.Items.AddRange(New Object() {"A3(297x420mm)", "A4(210x297mm)", "A5(148x210mm)", "A6(105x148mm)", "B4(257x364mm)", "B5(182x257mm)", "B6(128x182mm)", "Letter(8.5x11inch)", "Legal(8.5x14inch)", "Executive(7.25x10.5inch)", "Double Letter(11x17inch)", "PostCard(100x149mm)", "Photo(89x127mm)", "Card(55x91mm)", "Custom"})
        Me.cboPaperSize.Location = New System.Drawing.Point(118, 62)
        Me.cboPaperSize.MaxDropDownItems = 15
        Me.cboPaperSize.Name = "cboPaperSize"
        Me.cboPaperSize.Size = New System.Drawing.Size(165, 23)
        Me.cboPaperSize.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 17)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "PaperSize"
        '
        'chkLongPage
        '
        Me.chkLongPage.Location = New System.Drawing.Point(526, 65)
        Me.chkLongPage.Name = "chkLongPage"
        Me.chkLongPage.Size = New System.Drawing.Size(17, 16)
        Me.chkLongPage.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(463, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 17)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "LongPage"
        '
        'cboPaperSupply
        '
        Me.cboPaperSupply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaperSupply.ItemHeight = 15
        Me.cboPaperSupply.Items.AddRange(New Object() {"Flatbed", "ADF", "ADF(Duplex)", "ADF(BackSide)", "ADF(CarrierSheet Spread A3)", "ADF(CarrierSheet Spread DL)", "ADF(CarrierSheet Spread B4)", "ADF(CarrierSheet Clipping)", "ADF(CarrierSheet Spread A3)", "ADF(CarrierSheet Spread DL)", "ADF(CarrierSheet Spread B4)", "ADF(CarrierSheet Spread Auto)", "ADF(CarrierSheet Clipping All)", "ADF(CarrierSheet Clipping A4)", "ADF(CarrierSheet Clipping A5)", "ADF(CarrierSheet Clipping A6)", "ADF(CarrierSheet Clipping POST)", "ADF(CarrierSheet Clipping B5)", "ADF(CarrierSheet Clipping B6)", "ADF(CarrierSheet Clipping LT)", "ADF(CarrierSheet Clipping CARD_T)", "ADF(CarrierSheet Clipping CARD_Y)", "ADF(CarrierSheet Clipping PHOTO_ET)", "ADF(CarrierSheet Clipping PHOTO_EY)", "ADF(CarrierSheet Clipping PHOTO_LT)", "ADF(CarrierSheet Clipping PHOTO_LY)", "ADF(CarrierSheet Clipping PHOTO_LLT)", "ADF(CarrierSheet Clipping PHOTO_LLY)", "ADF(CarrierSheet Clipping Auto)", "ADF(CarrierSheet Clipping Custom)", "ADF(CarrierSheet Clipping Duplex All)", "ADF(CarrierSheet Clipping Duplex A4)", "ADF(CarrierSheet Clipping Duplex A5)", "ADF(CarrierSheet Clipping Duplex A6)", "ADF(CarrierSheet Clipping Duplex POST)", "ADF(CarrierSheet Clipping Duplex B5)", "ADF(CarrierSheet Clipping Duplex B6)", "ADF(CarrierSheet Clipping Duplex LT)", "ADF(CarrierSheet Clipping Duplex CARD_T)", "ADF(CarrierSheet Clipping Duplex CARD_Y)", "ADF(CarrierSheet Clipping Duplex PHOTO_ET)", "ADF(CarrierSheet Clipping Duplex PHOTO_EY)", "ADF(CarrierSheet Clipping Duplex PHOTO_LT)", "ADF(CarrierSheet Clipping Duplex PHOTO_LY)", "ADF(CarrierSheet Clipping Duplex PHOTO_LLT)", "ADF(CarrierSheet Clipping Duplex PHOTO_LLY)", "ADF(CarrierSheet Clipping Duplex Auto)", "ADF(CarrierSheet Clipping Duplex Custom)"})
        Me.cboPaperSupply.Location = New System.Drawing.Point(118, 37)
        Me.cboPaperSupply.MaxDropDownItems = 50
        Me.cboPaperSupply.Name = "cboPaperSupply"
        Me.cboPaperSupply.Size = New System.Drawing.Size(305, 23)
        Me.cboPaperSupply.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 17)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "PaperSupply"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(168, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 18)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "(-1, 1-32767)"
        '
        'txtScanCount
        '
        Me.txtScanCount.Location = New System.Drawing.Point(118, 12)
        Me.txtScanCount.MaxLength = 5
        Me.txtScanCount.Name = "txtScanCount"
        Me.txtScanCount.Size = New System.Drawing.Size(45, 21)
        Me.txtScanCount.TabIndex = 1
        Me.txtScanCount.Text = ""
        Me.txtScanCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 17)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "ScanCount"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCustomResolution)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboResolution)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cboPixelType)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(555, 73)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(478, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 18)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "(50-1600dpi)"
        '
        'txtCustomResolution
        '
        Me.txtCustomResolution.Location = New System.Drawing.Point(435, 38)
        Me.txtCustomResolution.MaxLength = 4
        Me.txtCustomResolution.Name = "txtCustomResolution"
        Me.txtCustomResolution.Size = New System.Drawing.Size(45, 21)
        Me.txtCustomResolution.TabIndex = 11
        Me.txtCustomResolution.Text = ""
        Me.txtCustomResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(320, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 18)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "CustomResolution"
        '
        'cboResolution
        '
        Me.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResolution.Items.AddRange(New Object() {"200dpi", "240dpi", "300dpi", "400dpi", "500dpi", "600dpi", "700dpi", "800dpi", "Custom"})
        Me.cboResolution.Location = New System.Drawing.Point(118, 40)
        Me.cboResolution.MaxDropDownItems = 9
        Me.cboResolution.Name = "cboResolution"
        Me.cboResolution.Size = New System.Drawing.Size(105, 23)
        Me.cboResolution.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 18)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Resolution"
        '
        'cboPixelType
        '
        Me.cboPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPixelType.Items.AddRange(New Object() {"Black&White", "Grayscale", "RGB"})
        Me.cboPixelType.Location = New System.Drawing.Point(118, 14)
        Me.cboPixelType.Name = "cboPixelType"
        Me.cboPixelType.Size = New System.Drawing.Size(165, 23)
        Me.cboPixelType.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 18)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "PixelType"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboJpegQuality)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboCompType)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFileCounter)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboOverwrite)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFileName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboFileType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboScanTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 173)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboJpegQuality
        '
        Me.cboJpegQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJpegQuality.Items.AddRange(New Object() {"Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7"})
        Me.cboJpegQuality.Location = New System.Drawing.Point(118, 140)
        Me.cboJpegQuality.Name = "cboJpegQuality"
        Me.cboJpegQuality.Size = New System.Drawing.Size(103, 23)
        Me.cboJpegQuality.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "JpegQuality"
        '
        'cboCompType
        '
        Me.cboCompType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompType.Items.AddRange(New Object() {"No Compress", "CCITT G3(1D)", "CCITT G3(2D)(KFactor=2)", "CCITT G3(2D)(KFactor=4)", "CCITT G4", "JPEG", "Old JPEG"})
        Me.cboCompType.Location = New System.Drawing.Point(118, 115)
        Me.cboCompType.Name = "cboCompType"
        Me.cboCompType.Size = New System.Drawing.Size(165, 23)
        Me.cboCompType.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "CompressionType"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(478, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 18)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "(0-65535)"
        '
        'txtFileCounter
        '
        Me.txtFileCounter.Location = New System.Drawing.Point(435, 90)
        Me.txtFileCounter.MaxLength = 5
        Me.txtFileCounter.Name = "txtFileCounter"
        Me.txtFileCounter.Size = New System.Drawing.Size(45, 21)
        Me.txtFileCounter.TabIndex = 9
        Me.txtFileCounter.Text = "-1"
        Me.txtFileCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(320, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "FileCounter"
        '
        'cboOverwrite
        '
        Me.cboOverwrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOverwrite.Items.AddRange(New Object() {"OFF(Mode0)", "On", "Confirm(Mode0)", "OFF(Mode1)", "Confirm(Mode1)"})
        Me.cboOverwrite.Location = New System.Drawing.Point(118, 90)
        Me.cboOverwrite.Name = "cboOverwrite"
        Me.cboOverwrite.Size = New System.Drawing.Size(121, 23)
        Me.cboOverwrite.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Overwrite"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(118, 65)
        Me.txtFileName.MaxLength = 254
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(430, 21)
        Me.txtFileName.TabIndex = 5
        Me.txtFileName.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "FileName"
        '
        'cboFileType
        '
        Me.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileType.Items.AddRange(New Object() {"BMP", "TIFF", "MultipageTIFF", "JPEG", "PDF", "MultipagePDF", "Multi Image Output", "Auto Color Detection"})
        Me.cboFileType.Location = New System.Drawing.Point(118, 40)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(165, 23)
        Me.cboFileType.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FileType"
        '
        'cboScanTo
        '
        Me.cboScanTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScanTo.Enabled = False
        Me.cboScanTo.Items.AddRange(New Object() {"File", "Dib Handle", "RAW Image Handle"})
        Me.cboScanTo.Location = New System.Drawing.Point(118, 15)
        Me.cboScanTo.Name = "cboScanTo"
        Me.cboScanTo.Size = New System.Drawing.Size(121, 23)
        Me.cboScanTo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ScanTo"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabPage2.Size = New System.Drawing.Size(572, 460)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Image"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkSmoothing)
        Me.GroupBox5.Controls.Add(Me.Label52)
        Me.GroupBox5.Controls.Add(Me.chkPreFiltering)
        Me.GroupBox5.Controls.Add(Me.Label53)
        Me.GroupBox5.Controls.Add(Me.cboNoiseRemoval)
        Me.GroupBox5.Controls.Add(Me.Label51)
        Me.GroupBox5.Controls.Add(Me.cboThresholdCurve)
        Me.GroupBox5.Controls.Add(Me.Label50)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 336)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(555, 109)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'chkSmoothing
        '
        Me.chkSmoothing.Location = New System.Drawing.Point(113, 81)
        Me.chkSmoothing.Name = "chkSmoothing"
        Me.chkSmoothing.Size = New System.Drawing.Size(15, 15)
        Me.chkSmoothing.TabIndex = 42
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(8, 81)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(76, 18)
        Me.Label52.TabIndex = 41
        Me.Label52.Text = "Smoothing"
        '
        'chkPreFiltering
        '
        Me.chkPreFiltering.Location = New System.Drawing.Point(113, 64)
        Me.chkPreFiltering.Name = "chkPreFiltering"
        Me.chkPreFiltering.Size = New System.Drawing.Size(15, 15)
        Me.chkPreFiltering.TabIndex = 40
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(8, 64)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(76, 17)
        Me.Label53.TabIndex = 39
        Me.Label53.Text = "PreFiltering"
        '
        'cboNoiseRemoval
        '
        Me.cboNoiseRemoval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoiseRemoval.Items.AddRange(New Object() {"None", "Matrix2", "Matrix3", "Matrix4", "Matrix5"})
        Me.cboNoiseRemoval.Location = New System.Drawing.Point(113, 37)
        Me.cboNoiseRemoval.Name = "cboNoiseRemoval"
        Me.cboNoiseRemoval.Size = New System.Drawing.Size(70, 23)
        Me.cboNoiseRemoval.TabIndex = 38
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(8, 41)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(86, 18)
        Me.Label51.TabIndex = 37
        Me.Label51.Text = "NoiseRemoval"
        '
        'cboThresholdCurve
        '
        Me.cboThresholdCurve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThresholdCurve.Items.AddRange(New Object() {"Curve1", "Curve2", "Curve3", "Curve4", "Curve5", "Curve6", "Curve7", "Curve8"})
        Me.cboThresholdCurve.Location = New System.Drawing.Point(113, 12)
        Me.cboThresholdCurve.Name = "cboThresholdCurve"
        Me.cboThresholdCurve.Size = New System.Drawing.Size(70, 23)
        Me.cboThresholdCurve.TabIndex = 36
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(8, 16)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(95, 18)
        Me.Label50.TabIndex = 35
        Me.Label50.Text = "ThresholdCurve"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.hsbShadow)
        Me.GroupBox4.Controls.Add(Me.txtShadow)
        Me.GroupBox4.Controls.Add(Me.Label76)
        Me.GroupBox4.Controls.Add(Me.Label75)
        Me.GroupBox4.Controls.Add(Me.hsbHighlight)
        Me.GroupBox4.Controls.Add(Me.Label74)
        Me.GroupBox4.Controls.Add(Me.txtHighlight)
        Me.GroupBox4.Controls.Add(Me.Label73)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.txtCustomGamma)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.txtGammaFile)
        Me.GroupBox4.Controls.Add(Me.txtHalftoneFile)
        Me.GroupBox4.Controls.Add(Me.cboGamma)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.cboHalftone)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.cboSEE)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.cboAutoSeparation)
        Me.GroupBox4.Controls.Add(Me.Label44)
        Me.GroupBox4.Controls.Add(Me.cboOutline)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.cboBackground)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.cboRotation)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.chkMirroring)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.chkReverse)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.hsbThreshold)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.txtThreshold)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.hsbContrast)
        Me.GroupBox4.Controls.Add(Me.Label35)
        Me.GroupBox4.Controls.Add(Me.txtContrast)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Controls.Add(Me.hsbBrightness)
        Me.GroupBox4.Controls.Add(Me.Label34)
        Me.GroupBox4.Controls.Add(Me.txtBrightness)
        Me.GroupBox4.Controls.Add(Me.Label33)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(555, 327)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'hsbShadow
        '
        Me.hsbShadow.LargeChange = 1
        Me.hsbShadow.Location = New System.Drawing.Point(224, 111)
        Me.hsbShadow.Maximum = 254
        Me.hsbShadow.Name = "hsbShadow"
        Me.hsbShadow.Size = New System.Drawing.Size(138, 20)
        Me.hsbShadow.TabIndex = 19
        Me.hsbShadow.TabStop = True
        Me.hsbShadow.Value = 10
        '
        'txtShadow
        '
        Me.txtShadow.Location = New System.Drawing.Point(113, 111)
        Me.txtShadow.MaxLength = 3
        Me.txtShadow.Name = "txtShadow"
        Me.txtShadow.Size = New System.Drawing.Size(36, 21)
        Me.txtShadow.TabIndex = 17
        Me.txtShadow.Text = "10"
        Me.txtShadow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label76
        '
        Me.Label76.Location = New System.Drawing.Point(158, 115)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(49, 17)
        Me.Label76.TabIndex = 18
        Me.Label76.Text = "(0-254)"
        '
        'Label75
        '
        Me.Label75.Location = New System.Drawing.Point(8, 114)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(76, 17)
        Me.Label75.TabIndex = 16
        Me.Label75.Text = "Shadow"
        '
        'hsbHighlight
        '
        Me.hsbHighlight.LargeChange = 1
        Me.hsbHighlight.Location = New System.Drawing.Point(224, 87)
        Me.hsbHighlight.Maximum = 255
        Me.hsbHighlight.Minimum = 1
        Me.hsbHighlight.Name = "hsbHighlight"
        Me.hsbHighlight.Size = New System.Drawing.Size(138, 20)
        Me.hsbHighlight.TabIndex = 15
        Me.hsbHighlight.TabStop = True
        Me.hsbHighlight.Value = 230
        '
        'Label74
        '
        Me.Label74.Location = New System.Drawing.Point(158, 91)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(49, 17)
        Me.Label74.TabIndex = 14
        Me.Label74.Text = "(1-255)"
        '
        'txtHighlight
        '
        Me.txtHighlight.Location = New System.Drawing.Point(113, 87)
        Me.txtHighlight.MaxLength = 3
        Me.txtHighlight.Name = "txtHighlight"
        Me.txtHighlight.Size = New System.Drawing.Size(36, 21)
        Me.txtHighlight.TabIndex = 13
        Me.txtHighlight.Text = "230"
        Me.txtHighlight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label73
        '
        Me.Label73.Location = New System.Drawing.Point(8, 90)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(76, 17)
        Me.Label73.TabIndex = 12
        Me.Label73.Text = "Highlight"
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(157, 281)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(62, 17)
        Me.Label48.TabIndex = 42
        Me.Label48.Text = "(0.1-10.0)"
        '
        'txtCustomGamma
        '
        Me.txtCustomGamma.Location = New System.Drawing.Point(113, 276)
        Me.txtCustomGamma.MaxLength = 4
        Me.txtCustomGamma.Name = "txtCustomGamma"
        Me.txtCustomGamma.Size = New System.Drawing.Size(36, 21)
        Me.txtCustomGamma.TabIndex = 41
        Me.txtCustomGamma.Text = "2.2"
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(8, 280)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(93, 17)
        Me.Label49.TabIndex = 40
        Me.Label49.Text = "CustomGamma"
        '
        'txtGammaFile
        '
        Me.txtGammaFile.Location = New System.Drawing.Point(251, 251)
        Me.txtGammaFile.MaxLength = 254
        Me.txtGammaFile.Name = "txtGammaFile"
        Me.txtGammaFile.Size = New System.Drawing.Size(295, 21)
        Me.txtGammaFile.TabIndex = 39
        Me.txtGammaFile.Text = ""
        '
        'txtHalftoneFile
        '
        Me.txtHalftoneFile.Location = New System.Drawing.Point(251, 225)
        Me.txtHalftoneFile.MaxLength = 254
        Me.txtHalftoneFile.Name = "txtHalftoneFile"
        Me.txtHalftoneFile.Size = New System.Drawing.Size(295, 21)
        Me.txtHalftoneFile.TabIndex = 36
        Me.txtHalftoneFile.Text = ""
        '
        'cboGamma
        '
        Me.cboGamma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGamma.Items.AddRange(New Object() {"None", "Soft", "Sharp", "GammaPatternFile", "Custom"})
        Me.cboGamma.Location = New System.Drawing.Point(113, 250)
        Me.cboGamma.Name = "cboGamma"
        Me.cboGamma.Size = New System.Drawing.Size(135, 23)
        Me.cboGamma.TabIndex = 38
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(8, 255)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(76, 17)
        Me.Label47.TabIndex = 37
        Me.Label47.Text = "Gamma"
        '
        'cboHalftone
        '
        Me.cboHalftone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHalftone.Items.AddRange(New Object() {"None", "DitherPattern0", "DitherPattern1", "DitherPattern2", "DitherPattern3", "DitherPatternFile", "ErrorDiffusion"})
        Me.cboHalftone.Location = New System.Drawing.Point(113, 225)
        Me.cboHalftone.Name = "cboHalftone"
        Me.cboHalftone.Size = New System.Drawing.Size(135, 23)
        Me.cboHalftone.TabIndex = 35
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(8, 231)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(76, 17)
        Me.Label46.TabIndex = 34
        Me.Label46.Text = "Halftone"
        '
        'cboSEE
        '
        Me.cboSEE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSEE.Items.AddRange(New Object() {"OFF", "ON"})
        Me.cboSEE.Location = New System.Drawing.Point(389, 179)
        Me.cboSEE.Name = "cboSEE"
        Me.cboSEE.Size = New System.Drawing.Size(70, 23)
        Me.cboSEE.TabIndex = 31
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(284, 183)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(76, 17)
        Me.Label45.TabIndex = 30
        Me.Label45.Text = "SEE"
        '
        'cboAutoSeparation
        '
        Me.cboAutoSeparation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutoSeparation.Items.AddRange(New Object() {"OFF", "ON"})
        Me.cboAutoSeparation.Location = New System.Drawing.Point(113, 179)
        Me.cboAutoSeparation.Name = "cboAutoSeparation"
        Me.cboAutoSeparation.Size = New System.Drawing.Size(70, 23)
        Me.cboAutoSeparation.TabIndex = 29
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(8, 183)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(94, 17)
        Me.Label44.TabIndex = 28
        Me.Label44.Text = "AutoSeparation"
        '
        'cboOutline
        '
        Me.cboOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutline.Items.AddRange(New Object() {"None", "Outline Emphasis Low", "Outline Emphasis Mid", "Outline Emphasis High", "Outline Smooth", "Edge Extract"})
        Me.cboOutline.Location = New System.Drawing.Point(113, 202)
        Me.cboOutline.Name = "cboOutline"
        Me.cboOutline.Size = New System.Drawing.Size(152, 23)
        Me.cboOutline.TabIndex = 33
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(8, 205)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(76, 17)
        Me.Label43.TabIndex = 32
        Me.Label43.Text = "Outline"
        '
        'cboBackground
        '
        Me.cboBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBackground.Items.AddRange(New Object() {"OFF", "ON", "AUTO"})
        Me.cboBackground.Location = New System.Drawing.Point(389, 155)
        Me.cboBackground.Name = "cboBackground"
        Me.cboBackground.Size = New System.Drawing.Size(70, 23)
        Me.cboBackground.TabIndex = 27
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(284, 158)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(76, 18)
        Me.Label42.TabIndex = 26
        Me.Label42.Text = "Background"
        '
        'cboRotation
        '
        Me.cboRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRotation.Items.AddRange(New Object() {"None", "R90", "R180", "R270"})
        Me.cboRotation.Location = New System.Drawing.Point(113, 155)
        Me.cboRotation.Name = "cboRotation"
        Me.cboRotation.Size = New System.Drawing.Size(70, 23)
        Me.cboRotation.TabIndex = 25
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(8, 158)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(76, 18)
        Me.Label41.TabIndex = 24
        Me.Label41.Text = "Rotation"
        '
        'chkMirroring
        '
        Me.chkMirroring.Location = New System.Drawing.Point(389, 135)
        Me.chkMirroring.Name = "chkMirroring"
        Me.chkMirroring.Size = New System.Drawing.Size(15, 16)
        Me.chkMirroring.TabIndex = 23
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(284, 135)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(76, 18)
        Me.Label40.TabIndex = 22
        Me.Label40.Text = "Mirroring"
        '
        'chkReverse
        '
        Me.chkReverse.Location = New System.Drawing.Point(113, 135)
        Me.chkReverse.Name = "chkReverse"
        Me.chkReverse.Size = New System.Drawing.Size(15, 16)
        Me.chkReverse.TabIndex = 21
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(8, 135)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(76, 18)
        Me.Label39.TabIndex = 20
        Me.Label39.Text = "Reverse"
        '
        'hsbThreshold
        '
        Me.hsbThreshold.LargeChange = 1
        Me.hsbThreshold.Location = New System.Drawing.Point(224, 63)
        Me.hsbThreshold.Maximum = 255
        Me.hsbThreshold.Name = "hsbThreshold"
        Me.hsbThreshold.Size = New System.Drawing.Size(138, 20)
        Me.hsbThreshold.TabIndex = 11
        Me.hsbThreshold.TabStop = True
        Me.hsbThreshold.Value = 128
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(158, 67)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(49, 18)
        Me.Label37.TabIndex = 10
        Me.Label37.Text = "(0-255)"
        '
        'txtThreshold
        '
        Me.txtThreshold.Location = New System.Drawing.Point(113, 63)
        Me.txtThreshold.MaxLength = 3
        Me.txtThreshold.Name = "txtThreshold"
        Me.txtThreshold.Size = New System.Drawing.Size(36, 21)
        Me.txtThreshold.TabIndex = 9
        Me.txtThreshold.Text = "128"
        Me.txtThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(8, 66)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(76, 17)
        Me.Label38.TabIndex = 8
        Me.Label38.Text = "Threshold"
        '
        'hsbContrast
        '
        Me.hsbContrast.LargeChange = 1
        Me.hsbContrast.Location = New System.Drawing.Point(224, 39)
        Me.hsbContrast.Maximum = 255
        Me.hsbContrast.Minimum = 1
        Me.hsbContrast.Name = "hsbContrast"
        Me.hsbContrast.Size = New System.Drawing.Size(138, 21)
        Me.hsbContrast.TabIndex = 7
        Me.hsbContrast.TabStop = True
        Me.hsbContrast.Value = 128
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(158, 43)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(49, 18)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "(1-255)"
        '
        'txtContrast
        '
        Me.txtContrast.Location = New System.Drawing.Point(113, 39)
        Me.txtContrast.MaxLength = 3
        Me.txtContrast.Name = "txtContrast"
        Me.txtContrast.Size = New System.Drawing.Size(36, 21)
        Me.txtContrast.TabIndex = 5
        Me.txtContrast.Text = "128"
        Me.txtContrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(8, 42)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 18)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Contrast"
        '
        'hsbBrightness
        '
        Me.hsbBrightness.LargeChange = 1
        Me.hsbBrightness.Location = New System.Drawing.Point(224, 15)
        Me.hsbBrightness.Maximum = 255
        Me.hsbBrightness.Minimum = 1
        Me.hsbBrightness.Name = "hsbBrightness"
        Me.hsbBrightness.Size = New System.Drawing.Size(138, 21)
        Me.hsbBrightness.TabIndex = 3
        Me.hsbBrightness.TabStop = True
        Me.hsbBrightness.Value = 128
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(158, 20)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(49, 17)
        Me.Label34.TabIndex = 2
        Me.Label34.Text = "(1-255)"
        '
        'txtBrightness
        '
        Me.txtBrightness.Location = New System.Drawing.Point(113, 15)
        Me.txtBrightness.MaxLength = 3
        Me.txtBrightness.Name = "txtBrightness"
        Me.txtBrightness.Size = New System.Drawing.Size(36, 21)
        Me.txtBrightness.TabIndex = 1
        Me.txtBrightness.Text = "128"
        Me.txtBrightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 18)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(76, 18)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Brightness"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(572, 460)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Extension"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboOverScan)
        Me.GroupBox7.Controls.Add(Me.Label77)
        Me.GroupBox7.Controls.Add(Me.chkAutoBorderDetection)
        Me.GroupBox7.Controls.Add(Me.Label71)
        Me.GroupBox7.Controls.Add(Me.Label69)
        Me.GroupBox7.Controls.Add(Me.txtSkipBlackPage)
        Me.GroupBox7.Controls.Add(Me.Label70)
        Me.GroupBox7.Controls.Add(Me.Label67)
        Me.GroupBox7.Controls.Add(Me.txtSkipWhitePage)
        Me.GroupBox7.Controls.Add(Me.Label68)
        Me.GroupBox7.Controls.Add(Me.cboFilter)
        Me.GroupBox7.Controls.Add(Me.Label66)
        Me.GroupBox7.Controls.Add(Me.cboMultiFeed)
        Me.GroupBox7.Controls.Add(Me.Label65)
        Me.GroupBox7.Controls.Add(Me.cboBinding)
        Me.GroupBox7.Controls.Add(Me.Label64)
        Me.GroupBox7.Controls.Add(Me.cboJobControl)
        Me.GroupBox7.Controls.Add(Me.Label63)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 207)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(555, 212)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        '
        'cboOverScan
        '
        Me.cboOverScan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOverScan.Items.AddRange(New Object() {"OFF", "ON"})
        Me.cboOverScan.Location = New System.Drawing.Point(128, 182)
        Me.cboOverScan.Name = "cboOverScan"
        Me.cboOverScan.Size = New System.Drawing.Size(87, 23)
        Me.cboOverScan.TabIndex = 31
        '
        'Label77
        '
        Me.Label77.Location = New System.Drawing.Point(9, 184)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(99, 15)
        Me.Label77.TabIndex = 30
        Me.Label77.Text = "OverScan"
        '
        'chkAutoBorderDetection
        '
        Me.chkAutoBorderDetection.Location = New System.Drawing.Point(128, 161)
        Me.chkAutoBorderDetection.Name = "chkAutoBorderDetection"
        Me.chkAutoBorderDetection.Size = New System.Drawing.Size(18, 18)
        Me.chkAutoBorderDetection.TabIndex = 29
        '
        'Label71
        '
        Me.Label71.Location = New System.Drawing.Point(9, 160)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(121, 16)
        Me.Label71.TabIndex = 28
        Me.Label71.Text = "AutoBorderDetection"
        '
        'Label69
        '
        Me.Label69.Location = New System.Drawing.Point(188, 141)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(62, 15)
        Me.Label69.TabIndex = 27
        Me.Label69.Text = "(0-15)"
        '
        'txtSkipBlackPage
        '
        Me.txtSkipBlackPage.Location = New System.Drawing.Point(128, 138)
        Me.txtSkipBlackPage.MaxLength = 2
        Me.txtSkipBlackPage.Name = "txtSkipBlackPage"
        Me.txtSkipBlackPage.Size = New System.Drawing.Size(54, 21)
        Me.txtSkipBlackPage.TabIndex = 26
        Me.txtSkipBlackPage.Text = ""
        Me.txtSkipBlackPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label70
        '
        Me.Label70.Location = New System.Drawing.Point(9, 137)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(99, 15)
        Me.Label70.TabIndex = 25
        Me.Label70.Text = "SkipBlackPage"
        '
        'Label67
        '
        Me.Label67.Location = New System.Drawing.Point(187, 119)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(62, 15)
        Me.Label67.TabIndex = 24
        Me.Label67.Text = "(0-15)"
        '
        'txtSkipWhitePage
        '
        Me.txtSkipWhitePage.Location = New System.Drawing.Point(128, 114)
        Me.txtSkipWhitePage.MaxLength = 2
        Me.txtSkipWhitePage.Name = "txtSkipWhitePage"
        Me.txtSkipWhitePage.Size = New System.Drawing.Size(54, 21)
        Me.txtSkipWhitePage.TabIndex = 23
        Me.txtSkipWhitePage.Text = ""
        Me.txtSkipWhitePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label68
        '
        Me.Label68.Location = New System.Drawing.Point(9, 113)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(99, 15)
        Me.Label68.TabIndex = 22
        Me.Label68.Text = "SkipWhitePage"
        '
        'cboFilter
        '
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.Items.AddRange(New Object() {"Green", "Red", "Blue", "None", "White", "Custom1", "Custom2", "Custom3"})
        Me.cboFilter.Location = New System.Drawing.Point(128, 89)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(87, 23)
        Me.cboFilter.TabIndex = 21
        '
        'Label66
        '
        Me.Label66.Location = New System.Drawing.Point(9, 89)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(107, 15)
        Me.Label66.TabIndex = 20
        Me.Label66.Text = "Filter"
        '
        'cboMultiFeed
        '
        Me.cboMultiFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMultiFeed.Items.AddRange(New Object() {"None", "Mode0", "Mode1", "Mode2", "Mode3"})
        Me.cboMultiFeed.Location = New System.Drawing.Point(128, 64)
        Me.cboMultiFeed.Name = "cboMultiFeed"
        Me.cboMultiFeed.Size = New System.Drawing.Size(87, 23)
        Me.cboMultiFeed.TabIndex = 19
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(9, 65)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(107, 15)
        Me.Label65.TabIndex = 18
        Me.Label65.Text = "MultiFeed"
        '
        'cboBinding
        '
        Me.cboBinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBinding.Items.AddRange(New Object() {"Side", "Height"})
        Me.cboBinding.Location = New System.Drawing.Point(128, 39)
        Me.cboBinding.Name = "cboBinding"
        Me.cboBinding.Size = New System.Drawing.Size(87, 23)
        Me.cboBinding.TabIndex = 17
        '
        'Label64
        '
        Me.Label64.Location = New System.Drawing.Point(9, 41)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(107, 15)
        Me.Label64.TabIndex = 16
        Me.Label64.Text = "Binding"
        '
        'cboJobControl
        '
        Me.cboJobControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobControl.Items.AddRange(New Object() {"None", "Include and Continue", "Include and Stop", "Exclude and Continue", "Exclude and Stop"})
        Me.cboJobControl.Location = New System.Drawing.Point(128, 14)
        Me.cboJobControl.Name = "cboJobControl"
        Me.cboJobControl.Size = New System.Drawing.Size(149, 23)
        Me.cboJobControl.TabIndex = 15
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(9, 17)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(107, 16)
        Me.Label63.TabIndex = 14
        Me.Label63.Text = "JobControl"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboEndorserCountDirection)
        Me.GroupBox6.Controls.Add(Me.Label62)
        Me.GroupBox6.Controls.Add(Me.cboEndorserCountStep)
        Me.GroupBox6.Controls.Add(Me.Label61)
        Me.GroupBox6.Controls.Add(Me.cboEndorserDirection)
        Me.GroupBox6.Controls.Add(Me.Label60)
        Me.GroupBox6.Controls.Add(Me.Label58)
        Me.GroupBox6.Controls.Add(Me.txtEndorserOffset)
        Me.GroupBox6.Controls.Add(Me.Label59)
        Me.GroupBox6.Controls.Add(Me.txtEndorserString)
        Me.GroupBox6.Controls.Add(Me.Label57)
        Me.GroupBox6.Controls.Add(Me.Label56)
        Me.GroupBox6.Controls.Add(Me.txtEndorserCounter)
        Me.GroupBox6.Controls.Add(Me.Label55)
        Me.GroupBox6.Controls.Add(Me.chkEndorser)
        Me.GroupBox6.Controls.Add(Me.Label54)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 9)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(555, 195)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'cboEndorserCountDirection
        '
        Me.cboEndorserCountDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEndorserCountDirection.Items.AddRange(New Object() {"Add", "Del"})
        Me.cboEndorserCountDirection.Location = New System.Drawing.Point(150, 163)
        Me.cboEndorserCountDirection.Name = "cboEndorserCountDirection"
        Me.cboEndorserCountDirection.Size = New System.Drawing.Size(65, 23)
        Me.cboEndorserCountDirection.TabIndex = 15
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(8, 166)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(141, 15)
        Me.Label62.TabIndex = 14
        Me.Label62.Text = "EndorserCountDirection"
        '
        'cboEndorserCountStep
        '
        Me.cboEndorserCountStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEndorserCountStep.Items.AddRange(New Object() {"None", "1Step", "2Step"})
        Me.cboEndorserCountStep.Location = New System.Drawing.Point(128, 138)
        Me.cboEndorserCountStep.Name = "cboEndorserCountStep"
        Me.cboEndorserCountStep.Size = New System.Drawing.Size(87, 23)
        Me.cboEndorserCountStep.TabIndex = 13
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(8, 141)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(115, 15)
        Me.Label61.TabIndex = 12
        Me.Label61.Text = "EndorserCountStep"
        '
        'cboEndorserDirection
        '
        Me.cboEndorserDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEndorserDirection.Items.AddRange(New Object() {"ToUnder", "ToUpper"})
        Me.cboEndorserDirection.Location = New System.Drawing.Point(128, 113)
        Me.cboEndorserDirection.Name = "cboEndorserDirection"
        Me.cboEndorserDirection.Size = New System.Drawing.Size(87, 23)
        Me.cboEndorserDirection.TabIndex = 11
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(8, 116)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(115, 15)
        Me.Label60.TabIndex = 10
        Me.Label60.Text = "EndorserDirection"
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(189, 92)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(36, 17)
        Me.Label58.TabIndex = 9
        Me.Label58.Text = "inch"
        '
        'txtEndorserOffset
        '
        Me.txtEndorserOffset.Location = New System.Drawing.Point(128, 88)
        Me.txtEndorserOffset.MaxLength = 6
        Me.txtEndorserOffset.Name = "txtEndorserOffset"
        Me.txtEndorserOffset.Size = New System.Drawing.Size(54, 21)
        Me.txtEndorserOffset.TabIndex = 8
        Me.txtEndorserOffset.Text = ""
        Me.txtEndorserOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(8, 91)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(99, 15)
        Me.Label59.TabIndex = 7
        Me.Label59.Text = "EndorserOffset"
        '
        'txtEndorserString
        '
        Me.txtEndorserString.Location = New System.Drawing.Point(128, 63)
        Me.txtEndorserString.MaxLength = 35
        Me.txtEndorserString.Name = "txtEndorserString"
        Me.txtEndorserString.Size = New System.Drawing.Size(415, 21)
        Me.txtEndorserString.TabIndex = 6
        Me.txtEndorserString.Text = ""
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(8, 66)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(99, 15)
        Me.Label57.TabIndex = 5
        Me.Label57.Text = "EndorserString"
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(189, 42)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(113, 15)
        Me.Label56.TabIndex = 4
        Me.Label56.Text = "(-1, 0-99999)"
        '
        'txtEndorserCounter
        '
        Me.txtEndorserCounter.Location = New System.Drawing.Point(128, 38)
        Me.txtEndorserCounter.MaxLength = 9
        Me.txtEndorserCounter.Name = "txtEndorserCounter"
        Me.txtEndorserCounter.Size = New System.Drawing.Size(54, 21)
        Me.txtEndorserCounter.TabIndex = 3
        Me.txtEndorserCounter.Text = ""
        Me.txtEndorserCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(8, 41)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(99, 15)
        Me.Label55.TabIndex = 2
        Me.Label55.Text = "EndorserCounter"
        '
        'chkEndorser
        '
        Me.chkEndorser.Location = New System.Drawing.Point(128, 16)
        Me.chkEndorser.Name = "chkEndorser"
        Me.chkEndorser.Size = New System.Drawing.Size(18, 18)
        Me.chkEndorser.TabIndex = 1
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(8, 18)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(99, 16)
        Me.Label54.TabIndex = 0
        Me.Label54.Text = "Endorser"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 507)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(670, 24)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 6
        '
        'AxFiScn1
        '
        Me.AxFiScn1.Enabled = True
        Me.AxFiScn1.Location = New System.Drawing.Point(605, 415)
        Me.AxFiScn1.Name = "AxFiScn1"
        Me.AxFiScn1.OcxState = CType(resources.GetObject("AxFiScn1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFiScn1.Size = New System.Drawing.Size(48, 48)
        Me.AxFiScn1.TabIndex = 7
        '
        'FormScan
        '
        Me.AcceptButton = Me.ButtonScan
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.ButtonExit
        Me.ClientSize = New System.Drawing.Size(670, 531)
        Me.Controls.Add(Me.AxFiScn1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonScan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormScan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fiScanTest"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.AxFiScn1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared CurrentInstance As FormScan
    '----------------------------------------------------------------------------
    '   Function    : The form was loaded
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub FormScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CurrentInstance = Me
        Dim frmSplash As New FormSplash
        Dim lpFileName As String
        Dim lpFilePath As String

        frmSplash.Show()
        System.Windows.Forms.Application.DoEvents()

        blnFjtwn = True
        blnOpenScanner = True
        strTwainDS = ""

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

        'Reading of a configuration file
        Call InitialFileRead()

        frmSplash.Close()
        frmSplash.Dispose()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The form was closed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub FormScan_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Dim status As Integer
        Dim ErrorCode As Integer

        'Call "CloseScanner" method
        status = AxFiScn1.CloseScanner(Me.Handle.ToInt32)
        If status = RC_FAILURE Then
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("The ""CloseScanner"" function became an error." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
        End If

        'In FUJITSU TWAIN32 DRIVER, parameter information is saved at an ini file.
        If blnFjtwn = True Then
            Call WriteScanINIFile()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Exit" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExit.Click
        Me.Close()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "StartScan" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemStartScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemStartScan.Click
        Call StartScan()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "SelectSource" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelectSource.Click
        Dim status As Integer
        Dim ErrorCode As Integer

        'Call "SelectSource" method
        status = AxFiScn1.SelectSource(Me.Handle.ToInt32)

        'failure
        If status = RC_FAILURE Then
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("A scanner was not able to be selected." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
            ButtonScan.Enabled = False
            MenuItemStartScan.Enabled = False
            MenuItemClearPage.Enabled = False
            Exit Sub
        ElseIf status = RC_SUCCESS Then
            'A scanner is reopened
            If blnOpenScanner = True Then
                AxFiScn1.CloseScanner(Me.Handle.ToInt32)
            End If
            blnFjtwn = True
            blnOpenScanner = True
            Call OpenScanner()
        End If

    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "ClearPage" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemClearPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemClearPage.Click
        Dim status As Integer
        Dim ErrorCode As Integer

        'Call "ClearPage" method
        status = AxFiScn1.ClearPage(Me.Handle.ToInt32)
        If status = RC_FAILURE Then
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("The error occurred in discharge of a paper." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
            Exit Sub
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "ShowSourceUI" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemShowSourceUI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemShowSourceUI.Click
        If (cboPaperSupply.SelectedIndex = ADF_A3CS) Or _
            (cboPaperSupply.SelectedIndex = ADF_DLCS) Or _
            (cboPaperSupply.SelectedIndex = ADF_B4CS) Or _
            (cboPaperSupply.SelectedIndex = ADF_CS) Then
            If MenuItemShowSourceUI.Checked = True Then
                MenuItemShowSourceUI.Checked = False
            End If
        Else
            If MenuItemShowSourceUI.Checked = True Then
                MenuItemShowSourceUI.Checked = False
            Else
                MenuItemShowSourceUI.Checked = True
                MenuItemIndicator.Checked = True
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "CloseSource" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemCloseSourceUI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCloseSourceUI.Click
        If MenuItemCloseSourceUI.Checked = True Then
            MenuItemCloseSourceUI.Checked = False
        Else
            MenuItemCloseSourceUI.Checked = True
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "SourceCurrentScan" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemSourceCurrentScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSourceCurrentScan.Click
        If MenuItemSourceCurrentScan.Checked = True Then
            MenuItemSourceCurrentScan.Checked = False
        Else
            MenuItemSourceCurrentScan.Checked = True
        End If
        MenuItemTWAINTemplate.Enabled = MenuItemSourceCurrentScan.Checked
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "SilentMode" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemSilentMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSilentMode.Click
        If MenuItemSilentMode.Checked = True Then
            MenuItemSilentMode.Checked = False
        Else
            MenuItemSilentMode.Checked = True
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Report->OFF" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemReportOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemReportOFF.Click
        MenuItemReportOFF.Checked = True
        MenuItemReportDisplay.Checked = False
        MenuItemReportFile.Checked = False
        MenuItemReportBoth.Checked = False
        intReport = 0
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Report->Display" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemReportDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemReportDisplay.Click
        MenuItemReportOFF.Checked = False
        MenuItemReportDisplay.Checked = True
        MenuItemReportFile.Checked = False
        MenuItemReportBoth.Checked = False
        intReport = 1
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Report->File" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemReportFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemReportFile.Click
        MenuItemReportOFF.Checked = False
        MenuItemReportDisplay.Checked = False
        MenuItemReportFile.Checked = True
        MenuItemReportBoth.Checked = False
        intReport = 2
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Report->Display&File" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemReportBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemReportBoth.Click
        MenuItemReportOFF.Checked = False
        MenuItemReportDisplay.Checked = False
        MenuItemReportFile.Checked = False
        MenuItemReportBoth.Checked = True
        intReport = 3
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "SoftIPC Template..." menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemSIPCTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSIPCTemplate.Click
        Dim frmSoftIPC As New FormSoftIPC
        frmSoftIPC.ShowDialog()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "TWAIN Template..." menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemTWAINTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemTWAINTemplate.Click
        Dim frmTWAIN As New FormTWAIN
        frmTWAIN.ShowDialog()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Version..." menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemVersion.Click
        Dim frmAbout As New FormAbout
        frmAbout.ShowDialog()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Scan" button was pushed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScan.Click
        Call StartScan()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Exit" button was pushed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Reset" button was pushed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ButtonReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReset.Click
        Call DefaultSet()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Scanning is started
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub StartScan()
        Dim status As Integer
        Dim ErrorCode As Integer
        Dim frmCancelScan As New FormCancelScan

        'A scanning parameter is set as scanner control.
        Call ScanModeSet()

        frmCancelScan.StartPosition = FormStartPosition.Manual
        frmCancelScan.Top = Me.Top
        frmCancelScan.Left = Me.Left + Me.Width
        frmCancelScan.Owner = Me
        frmCancelScan.Show()

        'Scanning start
        status = AxFiScn1.StartScan(Me.Handle.ToInt32)
        'failure
        If status = RC_FAILURE Then
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("The scanning error occurred." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
            StatusBar1.Text = AxFiScn1.PageCount & "sheets were scanned."
            'cancel
        ElseIf status = RC_CANCEL Then
            MsgBox("The user canceled scanning." & Chr(13) & "Or the error which cannot continue scanning was detected.")
            StatusBar1.Text = AxFiScn1.PageCount & "sheets were scanned."
        Else
            StatusBar1.Text = AxFiScn1.PageCount & "sheets were scanned."
        End If

        'Update of FileCounter
        txtFileCounter.Text = AxFiScn1.FileCounter.ToString()

        frmCancelScan.Close()

    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Pretreatment
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
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
            ButtonScan.Enabled = False
            MenuItemStartScan.Enabled = False
            MenuItemClearPage.Enabled = False
        Else
            ButtonScan.Enabled = True
            MenuItemStartScan.Enabled = True
            MenuItemClearPage.Enabled = True
        End If

        'An image scanner name is displayed on a title.
        If Len(AxFiScn1.ImageScanner) > 0 Then
            Me.Text = "Visual Basic Sample fiScanTest(" & AxFiScn1.ImageScanner & ")"
        Else
            Me.Text = "Visual Basic Sample fiScanTest"
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The hexadecimal number character string of 8 figures is
    '                 generated.
    '   Argument    : ErrorCode
    '   Return code : String
    '----------------------------------------------------------------------------
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
    '----------------------------------------------------------------------------
    '   Function    : The parameter information set as scanner control
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub ScanModeSet()
        'Scanner parameter setting 
        AxFiScn1.Outline = NONE
        AxFiScn1.ScanTo = cboScanTo.SelectedIndex
        AxFiScn1.FileType = cboFileType.SelectedIndex
        AxFiScn1.FileName = txtFileName.Text
        AxFiScn1.Overwrite = cboOverwrite.SelectedIndex
        AxFiScn1.FileCounter = Integer.Parse(txtFileCounter.Text)
        AxFiScn1.CompressionType = cboCompType.SelectedIndex
        AxFiScn1.JpegQuality = cboJpegQuality.SelectedIndex
        AxFiScn1.PixelType = cboPixelType.SelectedIndex
        If cboResolution.SelectedIndex = 8 Then
            AxFiScn1.Resolution = RS_CUSTM
        Else
            AxFiScn1.Resolution = cboResolution.SelectedIndex
        End If
        AxFiScn1.CustomResolution = Short.Parse(txtCustomResolution.Text)
        AxFiScn1.Brightness = Short.Parse(txtBrightness.Text)
        AxFiScn1.Contrast = Short.Parse(txtContrast.Text)
        AxFiScn1.Threshold = Short.Parse(txtThreshold.Text)
        AxFiScn1.Reverse = chkReverse.Checked
        AxFiScn1.Mirroring = chkMirroring.Checked
        AxFiScn1.Rotation = cboRotation.SelectedIndex
        AxFiScn1.Background = cboBackground.SelectedIndex
        If cboPixelType.SelectedIndex = PIXEL_RGB And cboOutline.SelectedIndex > 3 Then
            AxFiScn1.Outline = cboOutline.SelectedIndex + 1
        Else
            AxFiScn1.Outline = cboOutline.SelectedIndex
        End If
        AxFiScn1.Halftone = cboHalftone.SelectedIndex
        AxFiScn1.HalftoneFile = txtHalftoneFile.Text
        AxFiScn1.Gamma = cboGamma.SelectedIndex.ToString()
        AxFiScn1.GammaFile = txtGammaFile.Text
        AxFiScn1.CustomGamma = Val(txtCustomGamma.Text)
        AxFiScn1.AutoSeparation = cboAutoSeparation.SelectedIndex
        AxFiScn1.SEE = cboSEE.SelectedIndex
        Dim iPaperSupply As Integer = 0
        If cboPaperSupply.SelectedIndex >= 8 And cboPaperSupply.SelectedIndex <= 47 Then
            iPaperSupply = 2
        End If
        AxFiScn1.PaperSupply = cboPaperSupply.SelectedIndex + iPaperSupply
        AxFiScn1.ScanCount = Short.Parse(txtScanCount.Text)
        If cboPaperSize.SelectedIndex = 14 Then
            AxFiScn1.PaperSize = PSIZE_CUSTOM
        Else
            AxFiScn1.PaperSize = cboPaperSize.SelectedIndex
        End If
        AxFiScn1.LongPage = chkLongPage.Checked
        AxFiScn1.Orientation = cboOrientation.SelectedIndex
        AxFiScn1.CustomPaperWidth = Single.Parse(txtCustomPaperWidth.Text)
        AxFiScn1.CustomPaperLength = Single.Parse(txtCustomPaperLength.Text)
        AxFiScn1.RegionLeft = Single.Parse(txtRegionLeft.Text)
        AxFiScn1.RegionTop = Single.Parse(txtRegionTop.Text)
        AxFiScn1.RegionWidth = Single.Parse(txtRegionWidth.Text)
        AxFiScn1.RegionLength = Single.Parse(txtRegionLength.Text)
        AxFiScn1.UndefinedScanning = chkUndefinedScanning.Checked
        AxFiScn1.BackgroundColor = cboBackgroundColor.SelectedIndex
        AxFiScn1.ThresholdCurve = cboThresholdCurve.SelectedIndex
        AxFiScn1.NoiseRemoval = cboNoiseRemoval.SelectedIndex
        AxFiScn1.PreFiltering = chkPreFiltering.Checked
        AxFiScn1.Smoothing = chkSmoothing.Checked
        AxFiScn1.Endorser = chkEndorser.Checked
        AxFiScn1.EndorserOffset = Single.Parse(txtEndorserOffset.Text)
        AxFiScn1.EndorserString = txtEndorserString.Text
        AxFiScn1.EndorserCounter = Integer.Parse(txtEndorserCounter.Text)
        If cboEndorserDirection.SelectedIndex = 1 Then
            AxFiScn1.EndorserDirection = 3
        Else
            AxFiScn1.EndorserDirection = 1
        End If
        AxFiScn1.EndorserCountStep = cboEndorserCountStep.SelectedIndex
        AxFiScn1.EndorserCountDirection = cboEndorserCountDirection.SelectedIndex
        AxFiScn1.JobControl = cboJobControl.SelectedIndex
        AxFiScn1.Binding = cboBinding.SelectedIndex
        AxFiScn1.MultiFeed = cboMultiFeed.SelectedIndex
        If cboFilter.SelectedIndex = 5 Then
            AxFiScn1.Filter = 99
        ElseIf cboFilter.SelectedIndex = 6 Then
            AxFiScn1.Filter = 100
        ElseIf cboFilter.SelectedIndex = 7 Then
            AxFiScn1.Filter = 101
        Else
            AxFiScn1.Filter = cboFilter.SelectedIndex
        End If
        AxFiScn1.SkipWhitePage = Short.Parse(txtSkipWhitePage.Text)
        AxFiScn1.SkipBlackPage = Short.Parse(txtSkipBlackPage.Text)
        AxFiScn1.AutoBorderDetection = chkAutoBorderDetection.Checked
        AxFiScn1.ShowSourceUI = MenuItemShowSourceUI.Checked
        AxFiScn1.CloseSourceUI = MenuItemCloseSourceUI.Checked
        AxFiScn1.SourceCurrentScan = MenuItemSourceCurrentScan.Checked
        AxFiScn1.SilentMode = MenuItemSilentMode.Checked
        AxFiScn1.Report = intReport
        AxFiScn1.ReportFile = strReportFile
        AxFiScn1.TwainDS = strTwainDS
        AxFiScn1.Indicator = MenuItemIndicator.Checked
        AxFiScn1.Highlight = Short.Parse(txtHighlight.Text)
        AxFiScn1.Shadow = Short.Parse(txtShadow.Text)
        AxFiScn1.OverScan = cboOverScan.SelectedIndex
        AxFiScn1.Unit = cboUnit.SelectedIndex

    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Reading of the parameter information stored in the ini file
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
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

        'Read configuration parameter
        cboScanTo.SelectedIndex = GetPrivateProfileInt("Scan", "ScanToType", TYPE_FILE, strFilePath)
        cboFileType.SelectedIndex = GetPrivateProfileInt("Scan", "FileType", FILE_TIF, strFilePath)
        strWork = New String(Chr(0), MAX_PATH)
        rcl = GetPrivateProfileString("Scan", "FileName", "", strWork, MAX_PATH, strFilePath)
        If rcl > 0 Then
            txtFileName.Text = strWork
        Else
            txtFileName.Text = strDirPath & "\image#####"
        End If
        cboOverwrite.SelectedIndex = GetPrivateProfileInt("Scan", "Overwrite", OW_CONFIRM, strFilePath)
        txtFileCounter.Text = GetPrivateProfileInt("Scan", "FileCounter", 1, strFilePath).ToString()
        cboCompType.SelectedIndex = GetPrivateProfileInt("Scan", "CompressionType", COMP_MMR, strFilePath)
        cboJpegQuality.SelectedIndex = GetPrivateProfileInt("Scan", "JpegQuality", COMP_JPEG4, strFilePath)
        cboPaperSupply.SelectedIndex = GetPrivateProfileInt("Scan", "PaperSupply", ADF, strFilePath)
        txtScanCount.Text = GetPrivateProfileInt("Scan", "ScanCount", -1, strFilePath).ToString()
        cboPaperSize.SelectedIndex = GetPrivateProfileInt("Scan", "PaperSize", PSIZE_A4, strFilePath)
        rcl = GetPrivateProfileInt("Scan", "LongPage", 0, strFilePath)
        If rcl = 1 Then
            chkLongPage.Checked = True
        Else
            chkLongPage.Checked = False
        End If
        cboOrientation.SelectedIndex = GetPrivateProfileInt("Scan", "Orientation", PORTRAIT, strFilePath)
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "CustomPaperWidth", "8.268", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtCustomPaperWidth.Text = strWork
        Else
            txtCustomPaperWidth.Text = "8.268"
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "CustomPaperLength", "11.693", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtCustomPaperLength.Text = strWork
        Else
            txtCustomPaperLength.Text = "11.693"
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "RegionLeft", "0", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtRegionLeft.Text = strWork
        Else
            txtRegionLeft.Text = "0"
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "RegionTop", "0", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtRegionTop.Text = strWork
        Else
            txtRegionTop.Text = "0"
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "RegionWidth", "0", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtRegionWidth.Text = strWork
        Else
            txtRegionWidth.Text = "0"
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "RegionLength", "0", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtRegionLength.Text = strWork
        Else
            txtRegionLength.Text = "0"
        End If
        rcl = GetPrivateProfileInt("Scan", "UndefinedScanning", 0, strFilePath)
        If rcl = 1 Then
            chkUndefinedScanning.Checked = True
        Else
            chkUndefinedScanning.Checked = False
        End If
        cboBackgroundColor.SelectedIndex = GetPrivateProfileInt("Scan", "BackgroundColor", 0, strFilePath)
        cboPixelType.SelectedIndex = GetPrivateProfileInt("Scan", "PixelType", PIXEL_BLACK_WHITE, strFilePath)
        cboResolution.SelectedIndex = GetPrivateProfileInt("Scan", "Resolution", RS_300, strFilePath)
        txtCustomResolution.Text = GetPrivateProfileInt("Scan", "CustomResolution", 300, strFilePath).ToString()
        txtBrightness.Text = GetPrivateProfileInt("Scan", "Brightness", 128, strFilePath).ToString()
        txtContrast.Text = GetPrivateProfileInt("Scan", "Contrast", 128, strFilePath).ToString()
        txtThreshold.Text = GetPrivateProfileInt("Scan", "Threshold", 128, strFilePath).ToString()
        rcl = GetPrivateProfileInt("Scan", "Reverse", 0, strFilePath)
        If rcl = 1 Then
            chkReverse.Checked = True
        Else
            chkReverse.Checked = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Mirroring", 0, strFilePath)
        If rcl = 1 Then
            chkMirroring.Checked = True
        Else
            chkMirroring.Checked = False
        End If
        cboRotation.SelectedIndex = GetPrivateProfileInt("Scan", "Rotation", RT_NONE, strFilePath)
        cboBackground.SelectedIndex = GetPrivateProfileInt("Scan", "Background", MODE_OFF, strFilePath)
        cboOutline.SelectedIndex = GetPrivateProfileInt("Scan", "Outline", NONE, strFilePath)
        cboHalftone.SelectedIndex = GetPrivateProfileInt("Scan", "Halftone", NONE, strFilePath)
        strWork = New String(Chr(0), MAX_PATH)
        rcl = GetPrivateProfileString("Scan", "HalftoneFile", "", strWork, MAX_PATH, strFilePath)
        If rcl > 0 Then
            txtHalftoneFile.Text = strWork
        End If
        cboGamma.SelectedIndex = GetPrivateProfileInt("Scan", "Gamma", NONE, strFilePath)
        strWork = New String(Chr(0), MAX_PATH)
        rcl = GetPrivateProfileString("Scan", "GammaFile", "", strWork, MAX_PATH, strFilePath)
        If rcl > 0 Then
            txtGammaFile.Text = strWork
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "CustomGamma", "2.2", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtCustomGamma.Text = strWork
        Else
            txtCustomGamma.Text = "2.2"
        End If
        cboAutoSeparation.SelectedIndex = GetPrivateProfileInt("Scan", "AutoSeparation", AS_OFF, strFilePath)
        cboSEE.SelectedIndex = GetPrivateProfileInt("Scan", "SEE", SEE_OFF, strFilePath)
        cboThresholdCurve.SelectedIndex = GetPrivateProfileInt("Scan", "ThresholdCurve", TH_CURVE1, strFilePath)
        cboNoiseRemoval.SelectedIndex = GetPrivateProfileInt("Scan", "NoiseRemoval", NONE, strFilePath)
        rcl = GetPrivateProfileInt("Scan", "PreFiltering", 0, strFilePath)
        If rcl = 1 Then
            chkPreFiltering.Checked = True
        Else
            chkPreFiltering.Checked = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Smoothing", 0, strFilePath)
        If rcl = 1 Then
            chkSmoothing.Checked = True
        Else
            chkSmoothing.Checked = False
        End If
        rcl = GetPrivateProfileInt("Scan", "Endorser", 0, strFilePath)
        If rcl = 1 Then
            chkEndorser.Checked = True
        Else
            chkEndorser.Checked = False
            txtEndorserCounter.Enabled = False
            txtEndorserString.Enabled = False
            txtEndorserOffset.Enabled = False
            cboEndorserDirection.Enabled = False
            cboEndorserCountStep.Enabled = False
            cboEndorserCountDirection.Enabled = False
        End If
        txtEndorserCounter.Text = GetPrivateProfileInt("Scan", "EndorserCounter", 0, strFilePath).ToString()
        strWork = New String(Chr(0), 50)
        rcl = GetPrivateProfileString("Scan", "EndorserString", "", strWork, 50, strFilePath)
        If rcl > 0 Then
            txtEndorserString.Text = strWork
        End If
        strWork = New String(Chr(0), 10)
        rcl = GetPrivateProfileString("Scan", "EndorserOffset", "0", strWork, 10, strFilePath)
        If rcl > 0 Then
            txtEndorserOffset.Text = strWork
        Else
            txtEndorserOffset.Text = "0"
        End If
        cboEndorserDirection.SelectedIndex = GetPrivateProfileInt("Scan", "EndorserDirection", 0, strFilePath)
        cboEndorserCountStep.SelectedIndex = GetPrivateProfileInt("Scan", "EndorserCountStep", 1, strFilePath)
        cboEndorserCountDirection.SelectedIndex = GetPrivateProfileInt("Scan", "EndorserCountDirection", 0, strFilePath)
        cboJobControl.SelectedIndex = GetPrivateProfileInt("Scan", "JobControl", 0, strFilePath)
        cboBinding.SelectedIndex = GetPrivateProfileInt("Scan", "Binding", 0, strFilePath)
        cboMultiFeed.SelectedIndex = GetPrivateProfileInt("Scan", "DoubleFeed", 0, strFilePath)
        cboFilter.SelectedIndex = GetPrivateProfileInt("Scan", "Filter", FILTER_GREEN, strFilePath)
        txtSkipWhitePage.Text = GetPrivateProfileInt("Scan", "SkipWhitePage", 0, strFilePath).ToString()
        txtSkipBlackPage.Text = GetPrivateProfileInt("Scan", "SkipBlackPage", 0, strFilePath).ToString()
        rcl = GetPrivateProfileInt("Scan", "AutoBorderDerection", 0, strFilePath)
        If rcl = 1 Then
            chkAutoBorderDetection.Checked = True
        Else
            chkAutoBorderDetection.Checked = False
        End If
        rcl = GetPrivateProfileInt("Scan", "ShowSourceUI", 0, strFilePath)
        If rcl = 1 Then
            MenuItemShowSourceUI.Checked = True
        Else
            MenuItemShowSourceUI.Checked = False
        End If
        rcl = GetPrivateProfileInt("Scan", "CloseSourceUI", 0, strFilePath)
        If rcl = 1 Then
            MenuItemCloseSourceUI.Checked = True
        Else
            MenuItemCloseSourceUI.Checked = False
        End If
        rcl = GetPrivateProfileInt("Scan", "SourceCurrentScan", 0, strFilePath)
        If rcl = 1 Then
            MenuItemSourceCurrentScan.Checked = True
        Else
            MenuItemSourceCurrentScan.Checked = False
        End If
        MenuItemTWAINTemplate.Enabled = MenuItemSourceCurrentScan.Checked
        rcl = GetPrivateProfileInt("Scan", "SilentMode", 0, strFilePath)
        If rcl = 1 Then
            MenuItemSilentMode.Checked = True
        Else
            MenuItemSilentMode.Checked = False
        End If
        intReport = GetPrivateProfileInt("Scan", "Report", RP_OFF, strFilePath)
        MenuItemReportOFF.Checked = False
        MenuItemReportDisplay.Checked = False
        MenuItemReportFile.Checked = False
        MenuItemReportBoth.Checked = False
        If intReport = 0 Then
            MenuItemReportOFF.Checked = True
        ElseIf intReport = 1 Then
            MenuItemReportDisplay.Checked = True
        ElseIf intReport = 2 Then
            MenuItemReportFile.Checked = True
        Else
            MenuItemReportBoth.Checked = True
        End If
        rcl = GetPrivateProfileInt("Scan", "Indicator", 0, strFilePath)
        If rcl = 1 Then
            MenuItemIndicator.Checked = True
        Else
            MenuItemIndicator.Checked = False
        End If
        txtHighlight.Text = GetPrivateProfileInt("Scan", "Highlight", 230, strFilePath).ToString()
        txtShadow.Text = GetPrivateProfileInt("Scan", "Shadow", 10, strFilePath).ToString()
        cboOverScan.SelectedIndex = GetPrivateProfileInt("Scan", "OverScan", 0, strFilePath)
        cboUnit.SelectedIndex = GetPrivateProfileInt("Scan", "Unit", 0, strFilePath)

        bInitialFileRead = True
        CarrierSheetSet()
        Exit Sub

ReadError:

        'A default value is used when reading of a ini file goes wrong.
        Call DefaultSet()

    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Writing to the ini file of parameter information
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub WriteScanINIFile()
        Dim strWork As String
        Dim rcl As Integer

        On Error GoTo WriteError
        If strFilePath = "" Then
            GoTo WriteError
        End If

        'Display position information on a dialog
        rcl = WritePrivateProfileString("Form", "Left", Me.Left.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Form", "Top", Me.Top.ToString(), strFilePath)

        'Write configuration parameter
        rcl = WritePrivateProfileString("Scan", "ScanToType", cboScanTo.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "FileType", cboFileType.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "FileName", txtFileName.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "Overwrite", cboOverwrite.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "FileCounter", txtFileCounter.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "CompressionType", cboCompType.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "JpegQuality", cboJpegQuality.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "PaperSupply", cboPaperSupply.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "ScanCount", txtScanCount.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "PaperSize", cboPaperSize.SelectedIndex.ToString(), strFilePath)
        If chkLongPage.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "LongPage", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "LongPage", "0", strFilePath)
        End If
        rcl = WritePrivateProfileString("Scan", "Orientation", cboOrientation.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "CustomPaperWidth", txtCustomPaperWidth.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "CustomPaperLength", txtCustomPaperLength.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "RegionLeft", txtRegionLeft.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "RegionTop", txtRegionTop.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "RegionWidth", txtRegionWidth.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "RegionLength", txtRegionLength.Text, strFilePath)
        If chkUndefinedScanning.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "UndefinedScanning", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "UndefinedScanning", "0", strFilePath)
        End If
        rcl = WritePrivateProfileString("Scan", "BackgroundColor", cboBackgroundColor.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "PixelType", cboPixelType.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Resolution", cboResolution.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "CustomResolution", txtCustomResolution.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "Brightness", txtBrightness.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "Contrast", txtContrast.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "Threshold", txtThreshold.Text, strFilePath)
        If chkReverse.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "Reverse", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "Reverse", "0", strFilePath)
        End If
        If chkMirroring.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "Mirroring", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "Mirroring", "0", strFilePath)
        End If
        rcl = WritePrivateProfileString("Scan", "Rotation", cboRotation.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Background", cboBackground.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Outline", cboOutline.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Halftone", cboHalftone.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "HalftoneFile", txtHalftoneFile.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "Gamma", cboGamma.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "GammaFile", txtGammaFile.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "CustomGamma", txtCustomGamma.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "AutoSeparation", cboAutoSeparation.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "SEE", cboSEE.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "ThresholdCurve", cboThresholdCurve.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "NoiseRemoval", cboNoiseRemoval.SelectedIndex.ToString(), strFilePath)
        If chkPreFiltering.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "PreFiltering", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "PreFiltering", "0", strFilePath)
        End If
        If chkSmoothing.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "Smoothing", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "Smoothing", "0", strFilePath)
        End If

        If chkEndorser.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "Endorser", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "Endorser", "0", strFilePath)
        End If
        rcl = WritePrivateProfileString("Scan", "EndorserCounter", txtEndorserCounter.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "EndorserString", txtEndorserString.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "EndorserOffset", txtEndorserOffset.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "EndorserDirection", cboEndorserDirection.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "EndorserCountStep", cboEndorserCountStep.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "EndorserCountDirection", cboEndorserCountDirection.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "JobControl", cboJobControl.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Binding", cboBinding.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "DoubleFeed", cboMultiFeed.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Filter", cboFilter.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "SkipWhitePage", txtSkipWhitePage.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "SkipBlackPage", txtSkipBlackPage.Text, strFilePath)
        If chkAutoBorderDetection.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "AutoBorderDerection", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "AutoBorderDerection", "0", strFilePath)
        End If

        If MenuItemShowSourceUI.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "ShowSourceUI", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "ShowSourceUI", "0", strFilePath)
        End If
        If MenuItemCloseSourceUI.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "CloseSourceUI", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "CloseSourceUI", "0", strFilePath)
        End If
        If MenuItemSourceCurrentScan.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "SourceCurrentScan", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "SourceCurrentScan", "0", strFilePath)
        End If
        If MenuItemSilentMode.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "SilentMode", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "SilentMode", "0", strFilePath)
        End If
        rcl = WritePrivateProfileString("Scan", "Report", intReport.ToString(), strFilePath)
        If MenuItemIndicator.Checked = True Then
            rcl = WritePrivateProfileString("Scan", "Indicator", "1", strFilePath)
        Else
            rcl = WritePrivateProfileString("Scan", "Indicator", "0", strFilePath)
        End If
        rcl = WritePrivateProfileString("Scan", "Highlight", txtHighlight.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "Shadow", txtShadow.Text, strFilePath)
        rcl = WritePrivateProfileString("Scan", "OverScan", cboOverScan.SelectedIndex.ToString(), strFilePath)
        rcl = WritePrivateProfileString("Scan", "Unit", cboUnit.SelectedIndex.ToString(), strFilePath)

        Exit Sub

WriteError:
        MsgBox(ERRORMSG2)

    End Sub

    '----------------------------------------------------------------------------
    '   Function    : A default value is used when reading of a ini file goes wrong
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub DefaultSet()

        cboScanTo.SelectedIndex = TYPE_FILE
        cboFileType.SelectedIndex = FILE_TIF
        txtFileName.Text = strDirPath & "\image#####"
        cboOverwrite.SelectedIndex = OW_CONFIRM
        txtFileCounter.Text = "1"
        cboCompType.SelectedIndex = COMP_MMR
        cboJpegQuality.SelectedIndex = COMP_JPEG4

        cboPaperSupply.SelectedIndex = ADF
        txtScanCount.Text = "-1"
        cboPaperSize.SelectedIndex = PSIZE_A4
        chkLongPage.Checked = False
        cboOrientation.SelectedIndex = PORTRAIT
        txtCustomPaperWidth.Text = "8.268"
        txtCustomPaperLength.Text = "11.693"
        txtRegionLeft.Text = "0"
        txtRegionTop.Text = "0"
        txtRegionWidth.Text = "0"
        txtRegionLength.Text = "0"
        chkUndefinedScanning.Checked = False
        cboBackgroundColor.SelectedIndex = NONE

        cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE
        cboResolution.SelectedIndex = RS_300
        txtCustomResolution.Text = "300"

        txtBrightness.Text = 128
        txtContrast.Text = 128
        txtThreshold.Text = 128
        chkReverse.Checked = False
        chkMirroring.Checked = False
        cboRotation.SelectedIndex = RT_NONE
        cboBackground.SelectedIndex = MODE_OFF
        cboOutline.SelectedIndex = NONE
        cboHalftone.SelectedIndex = NONE
        txtHalftoneFile.Text = ""
        cboGamma.SelectedIndex = NONE
        txtGammaFile.Text = ""
        txtCustomGamma.Text = "2.2"
        cboAutoSeparation.SelectedIndex = AS_OFF
        cboSEE.SelectedIndex = SEE_OFF

        cboThresholdCurve.SelectedIndex = TH_CURVE1
        cboNoiseRemoval.SelectedIndex = 0
        chkPreFiltering.Checked = False
        chkSmoothing.Checked = False

        chkEndorser.Checked = False
        txtEndorserCounter.Text = "0"
        txtEndorserString.Text = ""
        txtEndorserOffset.Text = "0"
        cboEndorserDirection.SelectedIndex = 1
        cboEndorserCountStep.SelectedIndex = 1
        cboEndorserCountDirection.SelectedIndex = 0

        cboJobControl.SelectedIndex = NONE
        cboBinding.SelectedIndex = 0
        cboMultiFeed.SelectedIndex = 0
        cboFilter.SelectedIndex = FILTER_GREEN
        txtSkipWhitePage.Text = 0
        txtSkipBlackPage.Text = 0
        chkAutoBorderDetection.Checked = False

        MenuItemShowSourceUI.Checked = False
        MenuItemCloseSourceUI.Checked = False
        MenuItemSourceCurrentScan.Checked = False
        MenuItemTWAINTemplate.Enabled = MenuItemSourceCurrentScan.Checked
        MenuItemSilentMode.Checked = False
        intReport = NONE
        MenuItemReportOFF.Checked = False
        MenuItemReportDisplay.Checked = False
        MenuItemReportFile.Checked = False
        MenuItemReportBoth.Checked = False
        If intReport = 0 Then
            MenuItemReportOFF.Checked = True
        ElseIf intReport = 1 Then
            MenuItemReportDisplay.Checked = True
        ElseIf intReport = 2 Then
            MenuItemReportFile.Checked = True
        Else
            MenuItemReportBoth.Checked = True
        End If

        MenuItemIndicator.Checked = True
        If txtShadow.Text >= 230 Then
            txtShadow.Text = 10
            txtHighlight.Text = 230
        Else
            txtHighlight.Text = 230
            txtShadow.Text = 10
        End If
        txtHighlight.Enabled = False
        txtShadow.Enabled = False
        cboOverScan.SelectedIndex = OVERSCAN_OFF
        cboUnit.SelectedIndex = UNIT_INCHES
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "FileType" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboFileType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedIndexChanged

        'The following properties are adjusted according to specified FileType.
        '- PixelType
        '- CompressionType
        '- JpegQuality

        If cboFileType.SelectedIndex = FILE_MULTIIMAGE_OUTPUT Or cboFileType.SelectedIndex = FILE_AUTO_COLOR_DETECTION Then
            cboCompType.SelectedIndex = COMP_MMR
            cboCompType.Enabled = False
            cboJpegQuality.Enabled = True
            cboPixelType.SelectedIndex = PIXEL_RGB
            cboPixelType.Enabled = False
        Else
            cboCompType.Enabled = True
            cboPixelType.Enabled = True
        End If

        If cboFileType.SelectedIndex = FILE_BMP Then
            cboCompType.SelectedIndex = NO_COMP
            cboCompType.Enabled = False
            cboJpegQuality.Enabled = False
        ElseIf cboFileType.SelectedIndex = FILE_TIF Or cboFileType.SelectedIndex = FILE_MULTIF Then
            If cboCompType.SelectedIndex = COMP_JPEG Or cboCompType.SelectedIndex = COMP_OLDJPEG Then
                If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE Then
                    cboPixelType.SelectedIndex = PIXEL_GRAYSCALE
                End If
                cboJpegQuality.Enabled = True
            Else
                cboJpegQuality.Enabled = False
            End If
            If cboCompType.SelectedIndex <> NO_COMP And cboCompType.SelectedIndex <> COMP_JPEG And cboCompType.SelectedIndex <> COMP_OLDJPEG Then
                cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE
            End If
            If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE Then
                cboCompType.Enabled = True
            Else
                cboCompType.Enabled = False
            End If
        ElseIf cboFileType.SelectedIndex = FILE_JPEG Then
            cboCompType.SelectedIndex = COMP_JPEG
            cboCompType.Enabled = False
            cboJpegQuality.Enabled = True
            'The following properties are adjusted according to specified PixelType.
            '- Mirroring
            '- Threshold
            '- Halftone
            '- HalftoneFile
            '- AutoSeparation
            '- SEE
            '- ThresholdCurve
            '- NoiseRemoval
            '- PreFiltering
            '- Smoothing
            If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE Then
                cboPixelType.SelectedIndex = PIXEL_RGB
                chkMirroring.Enabled = False
                txtThreshold.Enabled = False
                hsbThreshold.Enabled = False
                cboHalftone.Enabled = False
                txtHalftoneFile.Enabled = False
                cboAutoSeparation.Enabled = False
                cboSEE.Enabled = False
                chkPreFiltering.Enabled = False
                chkSmoothing.Enabled = False
                cboThresholdCurve.Enabled = False
                cboNoiseRemoval.Enabled = False
            End If
        ElseIf cboFileType.SelectedIndex = FILE_PDF Or cboFileType.SelectedIndex = FILE_MULPDF Then
            If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE Then
                If cboCompType.SelectedIndex = COMP_JPEG Then
                    cboCompType.SelectedIndex = COMP_MMR
                End If
                cboJpegQuality.Enabled = False
            Else
                cboCompType.SelectedIndex = COMP_JPEG
                cboCompType.Enabled = False
                cboJpegQuality.Enabled = True
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "FileCounter" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtFileCounter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileCounter.TextChanged
        Dim count As Integer

        'An initial value is set to 0
        If Len(txtFileCounter.Text) = 0 Then
            txtFileCounter.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtFileCounter.Text)
        If count < 1 Then
            txtFileCounter.Text = "0"
        ElseIf count > 65535 Then
            txtFileCounter.Text = "65535"
        Else
            txtFileCounter.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "PixelType" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboPixelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPixelType.SelectedIndexChanged

        'Adjustment with the following property
        '- FileType
        '- CompressionType
        '- JpegQuality
        '- Mirroring
        '- Threshold
        '- Halftone
        '- HalftoneFile
        '- AutoSeparation
        '- SEE
        '- PixelType
        '- ThresholdCurve
        '- NoiseRemoval
        '- PreFiltering
        '- Smoothing
        '- Outline
        '- Highlight
        '- Shadow
        If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE Then
            If cboFileType.SelectedIndex = FILE_JPEG Then
                cboFileType.SelectedIndex = FILE_TIF
            End If
            If cboCompType.SelectedIndex = COMP_JPEG Or cboCompType.SelectedIndex = COMP_OLDJPEG Then
                cboCompType.SelectedIndex = COMP_MMR
            End If
            If cboFileType.SelectedIndex = FILE_BMP Then
                cboCompType.SelectedIndex = NO_COMP
                cboCompType.Enabled = False
            Else
                cboCompType.Enabled = True
            End If
            cboJpegQuality.Enabled = False
            chkMirroring.Enabled = True
            If cboHalftone.SelectedIndex = NONE Then
                txtThreshold.Enabled = True
                hsbThreshold.Enabled = True
            Else
                txtThreshold.Enabled = False
                hsbThreshold.Enabled = False
            End If
            If cboHalftone.SelectedIndex = DITHER_PATTERN_FILE Then
                txtHalftoneFile.Enabled = True
            End If
            cboHalftone.Enabled = True
            cboAutoSeparation.Enabled = True
            cboSEE.Enabled = True
            If cboHalftone.SelectedIndex = NONE And Len(txtThreshold.Text) > 0 And Val(txtThreshold.Text) = 0 Then
                chkPreFiltering.Enabled = True
                chkSmoothing.Enabled = True
                cboThresholdCurve.Enabled = True
                cboNoiseRemoval.Enabled = True
            Else
                chkPreFiltering.Enabled = False
                chkSmoothing.Enabled = False
                cboThresholdCurve.Enabled = False
                cboNoiseRemoval.Enabled = False
            End If
            cboOutline.Enabled = True
            Dim i As Integer
            For i = 4 To cboOutline.Items.Count - 1
                cboOutline.Items.RemoveAt(4)
            Next
            cboOutline.Items.Add("Outline Smooth")
            cboOutline.Items.Add("Edge Extract")
            cboOutline.SelectedIndex = 0

            If (cboFileType.SelectedIndex = FILE_JPEG) Or _
                (cboFileType.SelectedIndex = FILE_PDF) Or _
                (cboFileType.SelectedIndex = FILE_MULPDF) Then
                cboCompType.Enabled = True
            End If

            txtHighlight.Enabled = False
            hsbHighlight.Enabled = False
            txtShadow.Enabled = False
            hsbShadow.Enabled = False
        Else
            If cboFileType.SelectedIndex = FILE_JPEG Then
                cboCompType.Enabled = False
                cboCompType.SelectedIndex = COMP_JPEG
                cboJpegQuality.Enabled = True
            ElseIf cboFileType.SelectedIndex = FILE_PDF Or cboFileType.SelectedIndex = FILE_MULPDF Then
                cboCompType.Enabled = False
                cboCompType.SelectedIndex = COMP_JPEG
                cboJpegQuality.Enabled = True
            ElseIf cboFileType.SelectedIndex = FILE_MULTIIMAGE_OUTPUT Or cboFileType.SelectedIndex = FILE_AUTO_COLOR_DETECTION Then
                cboCompType.Enabled = False
                cboCompType.SelectedIndex = COMP_MMR
                cboJpegQuality.Enabled = True
            ElseIf (cboFileType.SelectedIndex = FILE_TIF Or cboFileType.SelectedIndex = FILE_MULTIF) And _
                    (cboCompType.SelectedIndex = COMP_JPEG Or cboCompType.SelectedIndex = COMP_OLDJPEG) Then
                cboJpegQuality.Enabled = True
                cboCompType.Enabled = False
            Else
                cboCompType.Enabled = False
                cboCompType.SelectedIndex = NO_COMP
                cboJpegQuality.Enabled = False
            End If
            chkMirroring.Enabled = False
            txtThreshold.Enabled = False
            hsbThreshold.Enabled = False
            cboHalftone.Enabled = False
            txtHalftoneFile.Enabled = False
            cboAutoSeparation.Enabled = False
            cboSEE.Enabled = False
            chkPreFiltering.Enabled = False
            chkSmoothing.Enabled = False
            cboThresholdCurve.Enabled = False
            cboNoiseRemoval.Enabled = False
            If cboPixelType.SelectedIndex = PIXEL_GRAYSCALE Then
                cboOutline.Enabled = False
                cboOutline.SelectedIndex = 0
            Else
                Dim i As Integer
                For i = 4 To cboOutline.Items.Count - 1
                    cboOutline.Items.RemoveAt(4)
                Next
                cboOutline.Items.Add("De-Screen Level1")
                cboOutline.Items.Add("De-Screen Level2")
                cboOutline.Items.Add("De-Screen Level3")
                cboOutline.Items.Add("De-Screen Level4")
                cboOutline.SelectedIndex = 0
                cboOutline.Enabled = True
                cboOutline.SelectedIndex = 0
            End If
            txtHighlight.Enabled = True
            hsbHighlight.Enabled = True
            txtShadow.Enabled = True
            hsbShadow.Enabled = True
        End If

        If (cboPaperSupply.SelectedIndex = ADF_A3CS) Or _
            (cboPaperSupply.SelectedIndex = ADF_DLCS) Or _
            (cboPaperSupply.SelectedIndex = ADF_B4CS) Or _
            (cboPaperSupply.SelectedIndex = ADF_CS) Then
            cboOutline.Enabled = False
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "Resolution" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboResolution_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResolution.SelectedIndexChanged

        UpdateUnit()
        PreviousReso = cboResolution.SelectedIndex
        'When Resolution is "custom-made", CustomResolution is confirmed and an initial value is set up.
        If cboResolution.SelectedIndex = (cboResolution.Items.Count - 1) Then
            txtCustomResolution.Enabled = True
            Exit Sub
        Else
            txtCustomResolution.Enabled = False
        End If
        Select Case cboResolution.SelectedIndex
            Case RS_200
                txtCustomResolution.Text = "200"
            Case RS_240
                txtCustomResolution.Text = "240"
            Case RS_300
                txtCustomResolution.Text = "300"
            Case RS_400
                txtCustomResolution.Text = "400"
            Case RS_500
                txtCustomResolution.Text = "500"
            Case RS_600
                txtCustomResolution.Text = "600"
            Case RS_700
                txtCustomResolution.Text = "700"
            Case RS_800
                txtCustomResolution.Text = "800"
            Case Else
                txtCustomResolution.Enabled = True
        End Select
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "CustomResolution" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtCustomResolution_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomResolution.TextChanged
        Dim count As Integer

        'An initial value is set to 300
        If Len(txtCustomResolution.Text) = 0 Then
            txtCustomResolution.Text = "300"
            Exit Sub
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtCustomResolution.Text)
        If count > 1600 Then
            txtCustomResolution.Text = "1600"
        ElseIf count < 50 Then
            txtCustomResolution.Text = "50"
        Else
            txtCustomResolution.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "ScanCount" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtScanCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanCount.TextChanged
        Dim count As Integer

        'An initial value is set to 1
        If Len(txtScanCount.Text) = 0 Then
            txtScanCount.Text = "1"
            Exit Sub
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtScanCount.Text)
        If count > 32767 Then
            txtScanCount.Text = "32767"
        ElseIf count < 1 Then
            txtScanCount.Text = "-1"
        Else
            txtScanCount.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "PaperSupply" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboPaperSupply_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaperSupply.SelectedIndexChanged
        CarrierSheetSet()
        UpdateUnit()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "PaperSize" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboPaperSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaperSize.SelectedIndexChanged
        Dim strWork As String

        If (cboPaperSupply.SelectedIndex = ADF_CS) And _
            ((cboPaperSize.SelectedIndex = PSIZE_A3) Or (cboPaperSize.SelectedIndex = PSIZE_B4) Or (cboPaperSize.SelectedIndex = PSIZE_DOUBLELETTER)) Then
            cboPaperSize.SelectedIndex = PSIZE_A4
        End If
        'CustomWidth and CustomLength is enabled when PaperSize is a "custom".
        If cboPaperSize.SelectedIndex = (cboPaperSize.Items.Count - 1) Then
            txtCustomPaperWidth.Enabled = True
            txtCustomPaperLength.Enabled = True
            Exit Sub
        Else
            txtCustomPaperWidth.Enabled = False
            txtCustomPaperLength.Enabled = False
        End If

        'The initial value of CustomWidth and CustomLength is adjusted
        'according to specified PaperSize.
        UpdateUnit()

        If cboOrientation.SelectedIndex = LANDSCAPE Then
            strWork = txtCustomPaperWidth.Text
            txtCustomPaperWidth.Text = txtCustomPaperLength.Text
            txtCustomPaperLength.Text = strWork
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "Orientation" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboOrientation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrientation.SelectedIndexChanged
        Dim strWork As String
        Dim Index As Short

        'According to the value of Orientation, the CustomWidth and the CustomLength are replaced.
        Index = cboOrientation.SelectedIndex
        If (Index = LANDSCAPE And intOrientation = PORTRAIT) Or (Index = PORTRAIT And intOrientation = LANDSCAPE) Then
            strWork = txtCustomPaperWidth.Text
            txtCustomPaperWidth.Text = txtCustomPaperLength.Text
            txtCustomPaperLength.Text = strWork
        End If
        intOrientation = Index
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "CustomPaperWidth" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtCustomPaperWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomPaperWidth.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtCustomPaperWidth.Text) = 0 Then
            txtCustomPaperWidth.Text = "0"
            Exit Sub
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtCustomPaperWidth.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtCustomPaperWidth.Text = "0"
        Else
            txtCustomPaperWidth.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "CustomPaperLength" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtCustomPaperLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomPaperLength.TextChanged

        'An initial value is set to 0
        Dim count As Double
        If Len(txtCustomPaperLength.Text) = 0 Then
            txtCustomPaperLength.Text = "0"
            Exit Sub
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtCustomPaperLength.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtCustomPaperLength.Text = "0"
        Else
            txtCustomPaperLength.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "RegionLeft" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtRegionLeft_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegionLeft.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtRegionLeft.Text) = 0 Then
            txtRegionLeft.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtRegionLeft.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtRegionLeft.Text = "0"
        Else
            txtRegionLeft.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "RegionTop" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtRegionTop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegionTop.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtRegionTop.Text) = 0 Then
            txtRegionTop.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtRegionTop.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtRegionTop.Text = "0"
        Else
            txtRegionTop.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "RegionWidth" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtRegionWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegionWidth.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtRegionWidth.Text) = 0 Then
            txtRegionWidth.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtRegionWidth.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtRegionWidth.Text = "0"
        Else
            txtRegionWidth.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "RegionLength" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtRegionLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegionLength.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtRegionLength.Text) = 0 Then
            txtRegionLength.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtRegionLength.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtRegionLength.Text = "0"
        Else
            txtRegionLength.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Brightness" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtBrightness_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrightness.TextChanged
        Dim count As Integer

        'An initial value is set to 1
        If Len(txtBrightness.Text) = 0 Then
            txtBrightness.Text = "1"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtBrightness.Text)
        If count > 255 Then
            txtBrightness.Text = "255"
        ElseIf count < 1 Then
            txtBrightness.Text = "1"
        Else
            txtBrightness.Text = count.ToString()
        End If
        hsbBrightness.Value = Val(txtBrightness.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Brightness" horizontal scroll bar was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub hsbBrightness_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsbBrightness.Scroll
        txtBrightness.Text = e.NewValue.ToString()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Contrast" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtContrast_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContrast.TextChanged
        Dim count As Integer

        'An initial value is set to 1
        If Len(txtContrast.Text) = 0 Then
            txtContrast.Text = "1"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtContrast.Text)
        If count > 255 Then
            txtContrast.Text = "255"
        ElseIf count < 1 Then
            txtContrast.Text = "1"
        Else
            txtContrast.Text = count.ToString()
        End If
        hsbContrast.Value = Val(txtContrast.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Contrast" horizontal scroll bar was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub hsbContrast_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsbContrast.Scroll
        txtContrast.Text = e.NewValue.ToString()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Threshold" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtThreshold_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtThreshold.TextChanged
        Dim count As Integer

        'An initial value is set to 0
        If Len(txtThreshold.Text) = 0 Then
            txtThreshold.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtThreshold.Text)
        If count > 255 Then
            txtThreshold.Text = "255"
        ElseIf count < 0 Then
            txtThreshold.Text = "0"
        Else
            txtThreshold.Text = count.ToString()
        End If

        'Adjustment with the following property
        '- Halftone
        '- PixelType
        '- ThresholdCurve
        '- NoiseRemoval
        '- PreFiltering
        '- Smoothing
        If Val(txtThreshold.Text) = 0 And cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE And cboHalftone.SelectedIndex = NONE Then
            chkPreFiltering.Enabled = True
            chkSmoothing.Enabled = True
            cboThresholdCurve.Enabled = True
            cboNoiseRemoval.Enabled = True
        Else
            chkPreFiltering.Enabled = False
            chkSmoothing.Enabled = False
            cboThresholdCurve.Enabled = False
            cboNoiseRemoval.Enabled = False
        End If
        hsbThreshold.Value = Val(txtThreshold.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Threshold" horizontal scroll bar was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub hsbThreshold_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsbThreshold.Scroll
        txtThreshold.Text = e.NewValue.ToString()
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "Halftone" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboHalftone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHalftone.SelectedIndexChanged

        'HalftoneFile is enabled when Halftone is a "dither pattern file."
        If cboHalftone.SelectedIndex = DITHER_PATTERN_FILE Then
            txtHalftoneFile.Enabled = True
        Else
            txtHalftoneFile.Enabled = False
        End If

        'Threshold is enabled when Halftone is a "nothing".
        'And the following properties are adjusted according to specified Threshold.
        '- ThresholdCurve
        '- NoiseRemoval
        '- PreFiltering
        '- Smoothing
        If cboHalftone.SelectedIndex = NONE Then
            txtThreshold.Enabled = True
            hsbThreshold.Enabled = True
            If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE And Len(txtThreshold.Text) > 0 And Val(txtThreshold.Text) = 0 Then
                chkPreFiltering.Enabled = True
                chkSmoothing.Enabled = True
                cboThresholdCurve.Enabled = True
                cboNoiseRemoval.Enabled = True
            Else
                chkPreFiltering.Enabled = False
                chkSmoothing.Enabled = False
                cboThresholdCurve.Enabled = False
                cboNoiseRemoval.Enabled = False
            End If
        Else
            txtThreshold.Enabled = False
            hsbThreshold.Enabled = False
            chkPreFiltering.Enabled = False
            chkSmoothing.Enabled = False
            cboThresholdCurve.Enabled = False
            cboNoiseRemoval.Enabled = False
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "Gamma" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboGamma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGamma.SelectedIndexChanged

        'Gamma pattern file or other
        If cboGamma.SelectedIndex = GAMMA_PATTERN_FILE Then
            txtGammaFile.Enabled = True
        Else
            txtGammaFile.Enabled = False
        End If

        'Custom gamma or other
        If cboGamma.SelectedIndex = GAMMA_CUSTOM Then
            txtCustomGamma.Enabled = True
        Else
            txtCustomGamma.Enabled = False
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "CustomGamma" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtCustomGamma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomGamma.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtCustomGamma.Text) = 0 Then
            txtCustomGamma.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtCustomGamma.Text.Replace(","c, "."c)
        count = Val(value)
        If count > 10 Then
            txtCustomGamma.Text = "10"
        ElseIf count < 0.1 Then
            txtCustomGamma.Text = "0.1"
        Else
            txtCustomGamma.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Endorser" check box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub chkEndorser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEndorser.CheckedChanged

        '1) When an endorser is used
        '     Enable all parameter items.
        '2) When an endorser is not used
        '     Disable all paramter items.
        If chkEndorser.CheckState = 1 Then
            txtEndorserCounter.Enabled = True
            txtEndorserString.Enabled = True
            txtEndorserOffset.Enabled = True
            cboEndorserDirection.Enabled = True
            cboEndorserCountStep.Enabled = True
            cboEndorserCountDirection.Enabled = True
        Else
            txtEndorserCounter.Enabled = False
            txtEndorserString.Enabled = False
            txtEndorserOffset.Enabled = False
            cboEndorserDirection.Enabled = False
            cboEndorserCountStep.Enabled = False
            cboEndorserCountDirection.Enabled = False
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "EndorserCounter" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtEndorserCounter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndorserCounter.TextChanged
        Dim count As Integer
        Dim iEndorserCounter As Integer
        Dim strEndorserCounter As String
        Dim strEndorserString As String = txtEndorserString.Text

        'An initial value is set to 0
        If Len(txtEndorserCounter.Text) = 0 Then
            txtEndorserCounter.Text = "0"
        End If

        'If "%08ud" is included in the "EndorserString", change the valid setting range for "EndorserCounter".
        count = strEndorserString.IndexOf("%08ud")
        If count >= 0 Then
            iEndorserCounter = 16777215
            strEndorserCounter = "16777215"
        Else
            iEndorserCounter = 99999
            strEndorserCounter = "99999"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtEndorserCounter.Text)
        If count > iEndorserCounter Then
            txtEndorserCounter.Text = strEndorserCounter
        ElseIf count < -1 Then
            txtEndorserCounter.Text = "0"
        Else
            txtEndorserCounter.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "EndorserOffset" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtEndorserOffset_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndorserOffset.TextChanged
        Dim count As Double

        'An initial value is set to 0
        If Len(txtEndorserOffset.Text) = 0 Then
            txtEndorserOffset.Text = "0"
            Exit Sub
        End If

        'An input value is checked and an invalid value is stored within effective limits
        Dim value As String = txtEndorserOffset.Text.Replace(","c, "."c)
        count = Val(value)
        If count < 0 Then
            txtEndorserOffset.Text = "0"
        Else
            txtEndorserOffset.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "SkipWhitePage" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtSkipWhitePage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSkipWhitePage.TextChanged
        Dim count As Integer

        'An initial value is set to 0
        If Len(txtSkipWhitePage.Text) = 0 Then
            txtSkipWhitePage.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtSkipWhitePage.Text)
        If count > 15 Then
            txtSkipWhitePage.Text = "15"
        ElseIf count < 0 Then
            txtSkipWhitePage.Text = "0"
        Else
            txtSkipWhitePage.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "SkipBlackPage" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtSkipBlackPage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSkipBlackPage.TextChanged
        Dim count As Integer

        'An initial value is set to 0
        If Len(txtSkipBlackPage.Text) = 0 Then
            txtSkipBlackPage.Text = "0"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtSkipBlackPage.Text)
        If count > 15 Then
            txtSkipBlackPage.Text = "15"
        ElseIf count < 0 Then
            txtSkipBlackPage.Text = "0"
        Else
            txtSkipBlackPage.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : It notifies having detected the special paper by the message.
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub AxFiScn1_DetectJobSeparator(ByVal sender As Object, ByVal e As System.EventArgs) Handles AxFiScn1.DetectJobSeparator
        MsgBox("The special paper was detected.")
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : CarrierSheet Setting
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub CarrierSheetSet()
        If (cboPaperSupply.SelectedIndex = ADF_A3CS) Or _
            (cboPaperSupply.SelectedIndex = ADF_DLCS) Or _
            (cboPaperSupply.SelectedIndex = ADF_B4CS) Or _
            (cboPaperSupply.SelectedIndex = ADF_CS) Then

            If (cboFileType.SelectedIndex = FILE_JPEG) Or _
                (cboFileType.SelectedIndex = FILE_PDF) Or _
                (cboFileType.SelectedIndex = FILE_MULPDF) Then
                cboCompType.SelectedIndex = COMP_JPEG
            Else
                cboCompType.SelectedIndex = NO_COMP
                cboJpegQuality.Enabled = False
            End If
            chkAutoBorderDetection.Checked = 0
            chkAutoBorderDetection.Enabled = False
            cboAutoSeparation.Enabled = False
            cboBackgroundColor.SelectedIndex = 0
            cboBackgroundColor.Enabled = False
            cboBinding.SelectedIndex = 0
            cboBinding.Enabled = False
            txtBrightness.Text = "128"
            txtBrightness.Enabled = False
            hsbBrightness.Value = "128"
            hsbBrightness.Enabled = False
            cboCompType.Enabled = False
            txtContrast.Text = "128"
            txtContrast.Enabled = False
            hsbContrast.Value = "128"
            hsbContrast.Enabled = False
            chkEndorser.Checked = 0
            chkEndorser.Enabled = False
            txtEndorserCounter.Enabled = False
            txtEndorserString.Enabled = False
            txtEndorserOffset.Enabled = False
            cboEndorserDirection.Enabled = False
            cboEndorserCountStep.Enabled = False
            cboEndorserCountDirection.Enabled = False
            cboGamma.Enabled = False
            txtGammaFile.Enabled = False
            txtCustomGamma.Enabled = False
            cboHalftone.Enabled = False
            txtHalftoneFile.Enabled = False
            chkLongPage.Checked = 0
            chkLongPage.Enabled = False
            chkMirroring.Enabled = False
            cboMultiFeed.SelectedIndex = 0
            cboMultiFeed.Enabled = False
            cboOrientation.SelectedIndex = PORTRAIT
            cboOrientation.Enabled = False
            cboOutline.SelectedIndex = NONE
            cboOutline.Enabled = False
            If cboPaperSupply.SelectedIndex = ADF_CS Then
                If cboPaperSize.SelectedIndex = 14 Then
                    txtCustomPaperWidth.Enabled = True
                    txtCustomPaperLength.Enabled = True
                Else
                    If (cboPaperSize.SelectedIndex = PSIZE_A3) Or _
                        (cboPaperSize.SelectedIndex = PSIZE_B4) Or _
                        (cboPaperSize.SelectedIndex = PSIZE_DOUBLELETTER) Then
                        cboPaperSize.SelectedIndex = PSIZE_A4
                    End If
                    txtCustomPaperWidth.Enabled = False
                    txtCustomPaperLength.Enabled = False
                End If
                cboPaperSize.Enabled = True
            Else
                cboPaperSize.SelectedIndex = 14
                cboPaperSize.Enabled = False
                txtCustomPaperWidth.Enabled = False
                txtCustomPaperLength.Enabled = False
            End If
            cboPixelType.SelectedIndex = PIXEL_RGB
            cboPixelType.Enabled = False
            txtRegionLeft.Text = "0"
            txtRegionLeft.Enabled = False
            txtRegionTop.Text = "0"
            txtRegionTop.Enabled = False
            txtRegionWidth.Text = "0"
            txtRegionWidth.Enabled = False
            txtRegionLength.Text = "0"
            txtRegionLength.Enabled = False
            chkReverse.Checked = 0
            chkReverse.Enabled = False
            cboRotation.SelectedIndex = RT_NONE
            cboRotation.Enabled = False
            txtScanCount.Text = "2"
            txtScanCount.Enabled = False
            cboSEE.Enabled = False
            txtSkipBlackPage.Text = "0"
            txtSkipBlackPage.Enabled = False
            txtSkipWhitePage.Text = "0"
            txtSkipWhitePage.Enabled = False
            MenuItemShowSourceUI.Checked = False
            txtThreshold.Enabled = False
            hsbThreshold.Enabled = False
            chkUndefinedScanning.Checked = 1
            chkUndefinedScanning.Enabled = False
            cboFilter.SelectedIndex = FILTER_GREEN
            cboFilter.Enabled = False
            cboJobControl.SelectedIndex = 0
            cboJobControl.Enabled = False
            txtHighlight.Text = 230
            txtHighlight.Enabled = False
            hsbHighlight.Enabled = False
            txtShadow.Text = 10
            txtShadow.Enabled = False
            hsbShadow.Enabled = False
            cboOverScan.SelectedIndex = 0
            cboOverScan.Enabled = False
        Else

            If cboPaperSupply.SelectedIndex = FLATBED Then
                txtScanCount.Enabled = False
            Else
                txtScanCount.Enabled = True
            End If
            chkAutoBorderDetection.Enabled = True
            cboBackgroundColor.Enabled = True
            cboBinding.Enabled = True
            txtBrightness.Enabled = True
            hsbBrightness.Enabled = True
            txtContrast.Enabled = True
            hsbContrast.Enabled = True
            chkEndorser.Enabled = True
            If chkEndorser.Checked = 1 Then
                txtEndorserCounter.Enabled = True
                txtEndorserString.Enabled = True
                txtEndorserOffset.Enabled = True
                cboEndorserDirection.Enabled = True
                cboEndorserCountStep.Enabled = True
                cboEndorserCountDirection.Enabled = True
            End If
            cboGamma.Enabled = True
            If (cboGamma.SelectedIndex = GAMMA_CUSTOM) Then
                txtCustomGamma.Enabled = True
            Else
                txtCustomGamma.Enabled = False
            End If
            If (cboGamma.SelectedIndex = GAMMA_PATTERN_FILE) Then
                txtGammaFile.Enabled = True
            Else
                txtGammaFile.Enabled = False
            End If
            chkLongPage.Enabled = True
            cboMultiFeed.Enabled = True
            cboOrientation.Enabled = True
            If cboPixelType.SelectedIndex = PIXEL_GRAYSCALE Then
                cboOutline.Enabled = False
            Else
                cboOutline.Enabled = True
            End If
            cboPaperSize.Enabled = True
            If cboPaperSize.SelectedIndex = 14 Then
                txtCustomPaperWidth.Enabled = True
                txtCustomPaperLength.Enabled = True
            Else
                txtCustomPaperWidth.Enabled = False
                txtCustomPaperLength.Enabled = False
            End If
            cboPixelType.Enabled = True
            txtRegionLeft.Enabled = True
            txtRegionTop.Enabled = True
            txtRegionWidth.Enabled = True
            txtRegionLength.Enabled = True
            chkReverse.Enabled = True
            cboRotation.Enabled = True
            txtSkipBlackPage.Enabled = True
            txtSkipWhitePage.Enabled = True
            chkUndefinedScanning.Enabled = True
            cboFilter.Enabled = True
            cboJobControl.Enabled = True
            If cboPixelType.SelectedIndex = PIXEL_BLACK_WHITE Then
                txtHighlight.Enabled = False
                hsbHighlight.Enabled = False
                txtShadow.Enabled = False
                hsbShadow.Enabled = False
            Else
                txtHighlight.Enabled = True
                hsbHighlight.Enabled = True
                txtShadow.Enabled = True
                hsbShadow.Enabled = True
            End If
            cboOverScan.Enabled = True
            cboBackground.Enabled = True
        End If

        If cboPaperSupply.SelectedIndex >= 8 And cboPaperSupply.SelectedIndex <= 47 Then
            chkEndorser.Checked = 0
            chkEndorser.Enabled = False
            txtEndorserCounter.Enabled = False
            txtEndorserString.Enabled = False
            txtEndorserOffset.Enabled = False
            cboEndorserDirection.Enabled = False
            cboEndorserCountStep.Enabled = False
            cboEndorserCountDirection.Enabled = False
            chkAutoBorderDetection.Checked = False
            chkAutoBorderDetection.Enabled = False
            cboOverScan.SelectedIndex = 0
            cboOverScan.Enabled = False
            cboBackground.SelectedIndex = 0
            cboBackground.Enabled = False
            cboBackgroundColor.SelectedIndex = 0
            cboBackgroundColor.Enabled = False
            cboGamma.SelectedIndex = GAMMA_CUSTOM
            cboGamma.Enabled = False
            txtCustomGamma.Enabled = True
            chkLongPage.Checked = False
            chkLongPage.Enabled = False
            txtRegionLeft.Text = "0"
            txtRegionLeft.Enabled = False
            txtRegionTop.Text = "0"
            txtRegionTop.Enabled = False
            txtRegionWidth.Text = "0"
            txtRegionWidth.Enabled = False
            txtRegionLength.Text = "0"
            txtRegionLength.Enabled = False
            chkUndefinedScanning.Checked = False
            chkUndefinedScanning.Enabled = False
            If cboPaperSupply.SelectedIndex = 29 Or cboPaperSupply.SelectedIndex = 47 Then
                cboPaperSize.SelectedIndex = 14
                cboPaperSize.Enabled = False
                txtCustomPaperLength.Enabled = True
                txtCustomPaperWidth.Enabled = True
            Else
                cboPaperSize.SelectedIndex = PSIZE_A4
                cboPaperSize.Enabled = False
                txtCustomPaperLength.Enabled = False
                txtCustomPaperWidth.Enabled = False
            End If

        End If

    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The "Indicator" menu was chosen
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemIndicator_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemIndicator.Click
        If MenuItemIndicator.Checked = True And MenuItemShowSourceUI.Checked = False Then
            MenuItemIndicator.Checked = False
        Else
            MenuItemIndicator.Checked = True
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Highlight" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtHighlight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHighlight.TextChanged
        Dim countHighlight As Integer
        Dim countShadow As Integer

        'An initial value is set to 230
        If Len(txtHighlight.Text) = 0 Then
            txtHighlight.Text = "230"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        countHighlight = Val(txtHighlight.Text)
        countShadow = Val(txtShadow.Text)
        If countHighlight > 255 Then
            txtHighlight.Text = "255"
        ElseIf countHighlight < 1 Then
            txtHighlight.Text = "1"
        ElseIf countHighlight <= countShadow Then
            txtHighlight.Text = countShadow + 1
        Else
            txtHighlight.Text = countHighlight.ToString()
        End If
        hsbHighlight().Value = Val(txtHighlight.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Highlight" horizontal scroll bar was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub hsbHighlight_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsbHighlight.Scroll
        txtHighlight().Text = e.NewValue.ToString()
        e.NewValue = Val(txtHighlight.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Shadow" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtShadow_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShadow.TextChanged
        Dim countHighlight As Integer
        Dim countShadow As Integer

        'An initial value is set to 10
        If Len(txtShadow.Text) = 0 Then
            txtShadow.Text = "10"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        countHighlight = Val(txtHighlight.Text)
        countShadow = Val(txtShadow.Text)
        If countShadow > 254 Then
            txtShadow.Text = "254"
        ElseIf countShadow < 0 Then
            txtShadow.Text = "0"
        ElseIf countShadow >= countHighlight Then
            If countHighlight - 1 = -1 Then
                txtShadow.Text = "0"
            Else
                txtShadow.Text = countHighlight - 1
            End If
        Else
            txtShadow.Text = countShadow.ToString()
        End If
        hsbShadow().Value = Val(txtShadow.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : The state of a "Shadow" horizontal scroll bar was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub hsbShadow_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsbShadow.Scroll
        txtShadow().Text = e.NewValue.ToString()
        e.NewValue = Val(txtShadow.Text)
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Selection of a "Unit" list box was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub cboUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnit.SelectedIndexChanged
        Dim strUnit As String

        UpdateUnit()
        PreviousUnit = cboUnit.SelectedIndex
        If cboUnit.SelectedIndex = UNIT_INCHES Then
            strUnit = "inch"
        ElseIf cboUnit.SelectedIndex = UNIT_CENTIMETERS Then
            strUnit = "cm"
        Else
            strUnit = "pixel"
        End If
        Label22.Text = strUnit
        Label23.Text = strUnit
        Label26.Text = strUnit
        Label27.Text = strUnit
        Label29.Text = strUnit
        Label31.Text = strUnit
        Label58.Text = strUnit
    End Sub

    '----------------------------------------------------------------------------
    '   Function: Rounds off numerical values.
    '   Argument: Target numerical value
    '           :Valid digits
    '   Return value: Rounded-off numerical value
    '----------------------------------------------------------------------------
    Public Shared Function RoundOff(ByVal dValue As Double, ByVal iFigure As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iFigure)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function

    '----------------------------------------------------------------------------
    '   Function: Returns a resolution value.
    '   Argument: Selected resolution
    '   Return value: Resolution value (dpi)
    '----------------------------------------------------------------------------
    Public Function ResolutionValue(ByVal reso As Integer) As Integer
        Select Case reso
            Case RS_200
                Return 200
            Case RS_240
                Return 240
            Case RS_300
                Return 300
            Case RS_400
                Return 400
            Case RS_500
                Return 500
            Case RS_600
                Return 600
            Case RS_700
                Return 700
            Case RS_800
                Return 800
            Case Else
                Return Val(txtCustomResolution.Text)
        End Select
    End Function

    '----------------------------------------------------------------------------
    '   Function: Unit conversion
    '   Argument: Nothing
    '   Return code: Nothing
    '----------------------------------------------------------------------------
    Private Sub UpdateUnit()
        Dim dValue As Double
        Dim iRreso As Integer
        Dim iFigure As Integer
        If bInitialFileRead = True Then
            iRreso = ResolutionValue(cboResolution.SelectedIndex)

            If cboUnit.SelectedIndex = UNIT_INCHES Then
                dValue = 1
            ElseIf cboUnit.SelectedIndex = UNIT_CENTIMETERS Then
                iFigure = 1
                dValue = INCH254
            Else
                iFigure = 0
                dValue = iRreso
            End If

            If (cboPaperSupply.SelectedIndex <> ADF_A3CS) And _
               (cboPaperSupply.SelectedIndex <> ADF_DLCS) And _
              (cboPaperSupply.SelectedIndex <> ADF_B4CS) Then
                Select Case cboPaperSize.SelectedIndex
                    Case PSIZE_A3
                        txtCustomPaperWidth.Text = 11.693 * dValue
                        txtCustomPaperLength.Text = 16.536 * dValue
                    Case PSIZE_A4
                        txtCustomPaperWidth.Text = 8.268 * dValue
                        txtCustomPaperLength.Text = 11.693 * dValue
                    Case PSIZE_A5
                        txtCustomPaperWidth.Text = 5.827 * dValue
                        txtCustomPaperLength.Text = 8.268 * dValue
                    Case PSIZE_A6
                        txtCustomPaperWidth.Text = 4.134 * dValue
                        txtCustomPaperLength.Text = 5.827 * dValue
                    Case PSIZE_B4
                        txtCustomPaperWidth.Text = 10.119 * dValue
                        txtCustomPaperLength.Text = 14.331 * dValue
                    Case PSIZE_B5
                        txtCustomPaperWidth.Text = 7.166 * dValue
                        txtCustomPaperLength.Text = 10.119 * dValue
                    Case PSIZE_B6
                        txtCustomPaperWidth.Text = 5.04 * dValue
                        txtCustomPaperLength.Text = 7.166 * dValue
                    Case PSIZE_LETTER
                        txtCustomPaperWidth.Text = 8.5 * dValue
                        txtCustomPaperLength.Text = 11.0 * dValue
                    Case PSIZE_LEGAL
                        txtCustomPaperWidth.Text = 8.5 * dValue
                        txtCustomPaperLength.Text = 14.0 * dValue
                    Case PSIZE_EXECUTIVE
                        txtCustomPaperWidth.Text = 7.25 * dValue
                        txtCustomPaperLength.Text = 10.5 * dValue
                    Case PSIZE_DOUBLELETTER
                        txtCustomPaperWidth.Text = 11.0 * dValue
                        txtCustomPaperLength.Text = 17.0 * dValue
                    Case PSIZE_POSTCARD
                        txtCustomPaperWidth.Text = 3.938 * dValue
                        txtCustomPaperLength.Text = 5.866 * dValue
                    Case PSIZE_PHOTO
                        txtCustomPaperWidth.Text = 3.504 * dValue
                        txtCustomPaperLength.Text = 5.0 * dValue
                    Case PSIZE_CARD
                        txtCustomPaperWidth.Text = 2.166 * dValue
                        txtCustomPaperLength.Text = 3.583 * dValue
                    Case Else
                        txtCustomPaperWidth.Text = ConvertUnit(Val(txtCustomPaperWidth.Text), iRreso)
                        txtCustomPaperLength.Text = ConvertUnit(Val(txtCustomPaperLength.Text), iRreso)
                End Select
            Else
                Select Case cboPaperSupply.SelectedIndex
                    Case ADF_A3CS
                        txtCustomPaperWidth.Text = 11.693 * dValue
                        txtCustomPaperLength.Text = 16.536 * dValue
                    Case ADF_B4CS
                        txtCustomPaperWidth.Text = 10.119 * dValue
                        txtCustomPaperLength.Text = 14.331 * dValue
                    Case ADF_DLCS
                        txtCustomPaperWidth.Text = 11.0 * dValue
                        txtCustomPaperLength.Text = 17.0 * dValue
                End Select
            End If

            If (cboPaperSupply.SelectedIndex <> ADF_A3CS) And _
               (cboPaperSupply.SelectedIndex <> ADF_DLCS) And _
              (cboPaperSupply.SelectedIndex <> ADF_B4CS) And _
              (cboPaperSupply.SelectedIndex <> ADF_CS) Then
                txtRegionLeft.Text = ConvertUnit(Val(txtRegionLeft.Text), iRreso)
                txtRegionTop.Text = ConvertUnit(Val(txtRegionTop.Text), iRreso)
                txtRegionWidth.Text = ConvertUnit(Val(txtRegionWidth.Text), iRreso)
                txtRegionLength.Text = ConvertUnit(Val(txtRegionLength.Text), iRreso)
            End If
            txtEndorserOffset.Text = ConvertUnit(Val(txtEndorserOffset.Text), iRreso)
            If cboUnit.SelectedIndex <> UNIT_INCHES Then
                txtCustomPaperWidth.Text = RoundOff(Val(txtCustomPaperWidth.Text), iFigure)
                txtCustomPaperLength.Text = RoundOff(Val(txtCustomPaperLength.Text), iFigure)
                txtRegionLeft.Text = RoundOff(Val(txtRegionLeft.Text), iFigure)
                txtRegionTop.Text = RoundOff(Val(txtRegionTop.Text), iFigure)
                txtRegionWidth.Text = RoundOff(Val(txtRegionWidth.Text), iFigure)
                txtRegionLength.Text = RoundOff(Val(txtRegionLength.Text), iFigure)
                txtEndorserOffset.Text = RoundOff(Val(txtEndorserOffset.Text), iFigure)
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function: Converts into another unit.
    '   Argument: Value to be converted into another unit
    '             Resolution (dpi)
    '   Return value: Result of unit conversion
    '----------------------------------------------------------------------------
    Public Function ConvertUnit(ByVal dValue As Double, ByVal iReso As Integer) As Double
        If cboUnit.SelectedIndex = UNIT_INCHES Then
            If PreviousUnit = UNIT_CENTIMETERS Then
                Return dValue / INCH254
            ElseIf PreviousUnit = UNIT_PIXELS Then
                Return dValue / iReso
            End If
        ElseIf cboUnit.SelectedIndex = UNIT_CENTIMETERS Then
            If PreviousUnit = UNIT_INCHES Then
                Return dValue * INCH254
            ElseIf PreviousUnit = UNIT_PIXELS Then
                Return dValue / iReso * INCH254
            End If
        ElseIf cboUnit.SelectedIndex = UNIT_PIXELS Then
            If PreviousUnit = UNIT_INCHES Then
                Return dValue * iReso
            ElseIf PreviousUnit = UNIT_CENTIMETERS Then
                Return dValue * iReso / INCH254
            End If
            If PreviousReso <> cboResolution.SelectedIndex Then
                Return dValue * iReso / ResolutionValue(PreviousReso)
            End If
        End If
        Return dValue
    End Function

    '----------------------------------------------------------------------------
    '   Function    : The state of a "EndorserString" input value was changed
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub txtEndorserString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEndorserString.TextChanged
        Dim count As Integer
        Dim iEndorserCounter As Integer
        Dim strEndorserCounter As String
        Dim strEndorserString As String = txtEndorserString.Text

        'If "%08ud" is included in the "EndorserString", the value for "EndorserCounter" is changed.
        count = strEndorserString.IndexOf("%08ud")
        If count >= 0 Then
            Label56.Text = "(-1, 0-16777215)"
            iEndorserCounter = 16777215
            strEndorserCounter = "16777215"
        Else
            Label56.Text = "(-1, 0-99999)"
            iEndorserCounter = 99999
            strEndorserCounter = "99999"
        End If

        'An input value is checked and an invalid value is stored within effective limits
        count = Val(txtEndorserCounter.Text)
        If count > iEndorserCounter Then
            txtEndorserCounter.Text = strEndorserCounter
        ElseIf count < -1 Then
            txtEndorserCounter.Text = "0"
        Else
            txtEndorserCounter.Text = count.ToString()
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : ScanToFile Event
    '   Argument    : Scanning image count
    '                 Scanning image file name
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub AxFiScn1_ScanToFile(ByVal sender As Object, ByVal e As AxFiScnLib._DFiScnEvents_ScanToFileEvent) Handles AxFiScn1.ScanToFile
        If bCancelScan Then
            AxFiScn1.CancelScan()
            bCancelScan = False
        End If
    End Sub

    '----------------------------------------------------------------------------
    '   Function    : Menu click event to notify whether or not a document is loaded on the ADF
    '   Argument    : Nothing
    '   Return code : Nothing
    '----------------------------------------------------------------------------
    Private Sub MenuItemFeederLoaded_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFeederLoaded.Click
        Dim ErrorCode As Integer

        'Process of notifying whether or not a document is loaded on the ADF
        If AxFiScn1.FeederLoaded(Me.Handle.ToInt32) Then
            MsgBox("The scanner is available.")
        Else
            ErrorCode = AxFiScn1.ErrorCode
            MsgBox("The scanner is unavailable, or an error ocurred." & Chr(13) & Chr(9) & "error code : " & HexString(ErrorCode))
            Exit Sub
        End If

    End Sub
End Class
