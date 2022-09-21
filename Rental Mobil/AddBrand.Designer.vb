<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddBrand
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                TransparentBg.Close()
            End If
        Finally
            MyBase.Dispose(disposing)
            TransparentBg.Close()
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddBrand))
        Dim BorderEdges1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties2 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties3 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties4 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties5 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties6 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim BorderEdges2 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties7 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties8 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim BorderEdges3 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties9 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties10 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Me.lblCurTab = New System.Windows.Forms.Label()
        Me.btnUpdate = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.txtMerk = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox()
        Me.btnCancelMobil = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.btnAddContact = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.SuspendLayout()
        '
        'lblCurTab
        '
        Me.lblCurTab.AutoSize = True
        Me.lblCurTab.BackColor = System.Drawing.Color.Transparent
        Me.lblCurTab.Font = New System.Drawing.Font("Open Sans", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurTab.ForeColor = System.Drawing.Color.White
        Me.lblCurTab.Location = New System.Drawing.Point(269, 25)
        Me.lblCurTab.Name = "lblCurTab"
        Me.lblCurTab.Size = New System.Drawing.Size(209, 37)
        Me.lblCurTab.TabIndex = 27
        Me.lblCurTab.Text = "BRAND ENTRY"
        '
        'btnUpdate
        '
        Me.btnUpdate.AllowToggling = False
        Me.btnUpdate.AnimationSpeed = 200
        Me.btnUpdate.AutoGenerateColors = False
        Me.btnUpdate.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdate.BackColor1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.btnUpdate.ButtonText = "Update Data"
        Me.btnUpdate.ButtonTextMarginLeft = 0
        Me.btnUpdate.ColorContrastOnClick = 45
        Me.btnUpdate.ColorContrastOnHover = 45
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges1.BottomLeft = True
        BorderEdges1.BottomRight = True
        BorderEdges1.TopLeft = True
        BorderEdges1.TopRight = True
        Me.btnUpdate.CustomizableEdges = BorderEdges1
        Me.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnUpdate.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnUpdate.DisabledFillColor = System.Drawing.Color.Gray
        Me.btnUpdate.DisabledForecolor = System.Drawing.Color.White
        Me.btnUpdate.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.btnUpdate.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.IconLeftCursor = System.Windows.Forms.Cursors.Default
        Me.btnUpdate.IconMarginLeft = 11
        Me.btnUpdate.IconPadding = 10
        Me.btnUpdate.IconRightCursor = System.Windows.Forms.Cursors.Default
        Me.btnUpdate.IdleBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnUpdate.IdleBorderRadius = 35
        Me.btnUpdate.IdleBorderThickness = 1
        Me.btnUpdate.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnUpdate.IdleIconLeftImage = Nothing
        Me.btnUpdate.IdleIconRightImage = Nothing
        Me.btnUpdate.IndicateFocus = False
        Me.btnUpdate.Location = New System.Drawing.Point(305, 239)
        Me.btnUpdate.Name = "btnUpdate"
        StateProperties1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties1.BorderRadius = 35
        StateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties1.BorderThickness = 1
        StateProperties1.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties1.ForeColor = System.Drawing.Color.White
        StateProperties1.IconLeftImage = Nothing
        StateProperties1.IconRightImage = Nothing
        Me.btnUpdate.onHoverState = StateProperties1
        StateProperties2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties2.BorderRadius = 35
        StateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties2.BorderThickness = 1
        StateProperties2.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties2.ForeColor = System.Drawing.Color.White
        StateProperties2.IconLeftImage = Nothing
        StateProperties2.IconRightImage = Nothing
        Me.btnUpdate.OnPressedState = StateProperties2
        Me.btnUpdate.Size = New System.Drawing.Size(133, 45)
        Me.btnUpdate.TabIndex = 37
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnUpdate.TextMarginLeft = 0
        Me.btnUpdate.UseDefaultRadiusAndThickness = True
        '
        'txtMerk
        '
        Me.txtMerk.AcceptsReturn = False
        Me.txtMerk.AcceptsTab = False
        Me.txtMerk.AnimationSpeed = 200
        Me.txtMerk.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtMerk.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtMerk.BackColor = System.Drawing.Color.White
        Me.txtMerk.BackgroundImage = CType(resources.GetObject("txtMerk.BackgroundImage"), System.Drawing.Image)
        Me.txtMerk.BorderColorActive = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtMerk.BorderColorDisabled = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.txtMerk.BorderColorHover = System.Drawing.Color.DodgerBlue
        Me.txtMerk.BorderColorIdle = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.txtMerk.BorderRadius = 30
        Me.txtMerk.BorderThickness = 1
        Me.txtMerk.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMerk.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMerk.DefaultFont = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMerk.DefaultText = ""
        Me.txtMerk.FillColor = System.Drawing.Color.White
        Me.txtMerk.HideSelection = True
        Me.txtMerk.IconLeft = Nothing
        Me.txtMerk.IconLeftCursor = System.Windows.Forms.Cursors.Default
        Me.txtMerk.IconPadding = 10
        Me.txtMerk.IconRight = Nothing
        Me.txtMerk.IconRightCursor = System.Windows.Forms.Cursors.Default
        Me.txtMerk.Lines = New String(-1) {}
        Me.txtMerk.Location = New System.Drawing.Point(141, 143)
        Me.txtMerk.MaxLength = 32767
        Me.txtMerk.MinimumSize = New System.Drawing.Size(100, 35)
        Me.txtMerk.Modified = False
        Me.txtMerk.Multiline = False
        Me.txtMerk.Name = "txtMerk"
        StateProperties3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(145, Byte), Integer))
        StateProperties3.FillColor = System.Drawing.Color.Empty
        StateProperties3.ForeColor = System.Drawing.Color.Empty
        StateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.txtMerk.OnActiveState = StateProperties3
        StateProperties4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        StateProperties4.FillColor = System.Drawing.Color.White
        StateProperties4.ForeColor = System.Drawing.Color.Empty
        StateProperties4.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.txtMerk.OnDisabledState = StateProperties4
        StateProperties5.BorderColor = System.Drawing.Color.DodgerBlue
        StateProperties5.FillColor = System.Drawing.Color.Empty
        StateProperties5.ForeColor = System.Drawing.Color.Empty
        StateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.txtMerk.OnHoverState = StateProperties5
        StateProperties6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        StateProperties6.FillColor = System.Drawing.Color.White
        StateProperties6.ForeColor = System.Drawing.Color.Empty
        StateProperties6.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.txtMerk.OnIdleState = StateProperties6
        Me.txtMerk.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMerk.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.txtMerk.PlaceholderText = "Masukkan Nama Brand"
        Me.txtMerk.ReadOnly = False
        Me.txtMerk.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtMerk.SelectedText = ""
        Me.txtMerk.SelectionLength = 0
        Me.txtMerk.SelectionStart = 0
        Me.txtMerk.ShortcutsEnabled = True
        Me.txtMerk.Size = New System.Drawing.Size(464, 35)
        Me.txtMerk.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu
        Me.txtMerk.TabIndex = 36
        Me.txtMerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMerk.TextMarginBottom = 0
        Me.txtMerk.TextMarginLeft = 5
        Me.txtMerk.TextMarginTop = 0
        Me.txtMerk.TextPlaceholder = "Masukkan Nama Brand"
        Me.txtMerk.UseSystemPasswordChar = False
        Me.txtMerk.WordWrap = True
        '
        'btnCancelMobil
        '
        Me.btnCancelMobil.AllowToggling = False
        Me.btnCancelMobil.AnimationSpeed = 200
        Me.btnCancelMobil.AutoGenerateColors = False
        Me.btnCancelMobil.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelMobil.BackColor1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancelMobil.BackgroundImage = CType(resources.GetObject("btnCancelMobil.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelMobil.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.btnCancelMobil.ButtonText = "Cancel"
        Me.btnCancelMobil.ButtonTextMarginLeft = 0
        Me.btnCancelMobil.ColorContrastOnClick = 45
        Me.btnCancelMobil.ColorContrastOnHover = 45
        Me.btnCancelMobil.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges2.BottomLeft = True
        BorderEdges2.BottomRight = True
        BorderEdges2.TopLeft = True
        BorderEdges2.TopRight = True
        Me.btnCancelMobil.CustomizableEdges = BorderEdges2
        Me.btnCancelMobil.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCancelMobil.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnCancelMobil.DisabledFillColor = System.Drawing.Color.Gray
        Me.btnCancelMobil.DisabledForecolor = System.Drawing.Color.White
        Me.btnCancelMobil.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.btnCancelMobil.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelMobil.ForeColor = System.Drawing.Color.White
        Me.btnCancelMobil.IconLeftCursor = System.Windows.Forms.Cursors.Default
        Me.btnCancelMobil.IconMarginLeft = 11
        Me.btnCancelMobil.IconPadding = 10
        Me.btnCancelMobil.IconRightCursor = System.Windows.Forms.Cursors.Default
        Me.btnCancelMobil.IdleBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancelMobil.IdleBorderRadius = 35
        Me.btnCancelMobil.IdleBorderThickness = 1
        Me.btnCancelMobil.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancelMobil.IdleIconLeftImage = Nothing
        Me.btnCancelMobil.IdleIconRightImage = Nothing
        Me.btnCancelMobil.IndicateFocus = False
        Me.btnCancelMobil.Location = New System.Drawing.Point(472, 239)
        Me.btnCancelMobil.Name = "btnCancelMobil"
        StateProperties7.BorderColor = System.Drawing.Color.OrangeRed
        StateProperties7.BorderRadius = 35
        StateProperties7.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties7.BorderThickness = 1
        StateProperties7.FillColor = System.Drawing.Color.OrangeRed
        StateProperties7.ForeColor = System.Drawing.Color.White
        StateProperties7.IconLeftImage = Nothing
        StateProperties7.IconRightImage = Nothing
        Me.btnCancelMobil.onHoverState = StateProperties7
        StateProperties8.BorderColor = System.Drawing.Color.OrangeRed
        StateProperties8.BorderRadius = 35
        StateProperties8.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties8.BorderThickness = 1
        StateProperties8.FillColor = System.Drawing.Color.OrangeRed
        StateProperties8.ForeColor = System.Drawing.Color.White
        StateProperties8.IconLeftImage = Nothing
        StateProperties8.IconRightImage = Nothing
        Me.btnCancelMobil.OnPressedState = StateProperties8
        Me.btnCancelMobil.Size = New System.Drawing.Size(133, 45)
        Me.btnCancelMobil.TabIndex = 35
        Me.btnCancelMobil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCancelMobil.TextMarginLeft = 0
        Me.btnCancelMobil.UseDefaultRadiusAndThickness = True
        '
        'btnAddContact
        '
        Me.btnAddContact.AllowToggling = False
        Me.btnAddContact.AnimationSpeed = 200
        Me.btnAddContact.AutoGenerateColors = False
        Me.btnAddContact.BackColor = System.Drawing.Color.Transparent
        Me.btnAddContact.BackColor1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnAddContact.BackgroundImage = CType(resources.GetObject("btnAddContact.BackgroundImage"), System.Drawing.Image)
        Me.btnAddContact.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.btnAddContact.ButtonText = "Save Data"
        Me.btnAddContact.ButtonTextMarginLeft = 0
        Me.btnAddContact.ColorContrastOnClick = 45
        Me.btnAddContact.ColorContrastOnHover = 45
        Me.btnAddContact.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges3.BottomLeft = True
        BorderEdges3.BottomRight = True
        BorderEdges3.TopLeft = True
        BorderEdges3.TopRight = True
        Me.btnAddContact.CustomizableEdges = BorderEdges3
        Me.btnAddContact.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAddContact.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnAddContact.DisabledFillColor = System.Drawing.Color.Gray
        Me.btnAddContact.DisabledForecolor = System.Drawing.Color.White
        Me.btnAddContact.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.btnAddContact.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddContact.ForeColor = System.Drawing.Color.White
        Me.btnAddContact.IconLeftCursor = System.Windows.Forms.Cursors.Default
        Me.btnAddContact.IconMarginLeft = 11
        Me.btnAddContact.IconPadding = 10
        Me.btnAddContact.IconRightCursor = System.Windows.Forms.Cursors.Default
        Me.btnAddContact.IdleBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnAddContact.IdleBorderRadius = 35
        Me.btnAddContact.IdleBorderThickness = 1
        Me.btnAddContact.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnAddContact.IdleIconLeftImage = Nothing
        Me.btnAddContact.IdleIconRightImage = Nothing
        Me.btnAddContact.IndicateFocus = False
        Me.btnAddContact.Location = New System.Drawing.Point(141, 239)
        Me.btnAddContact.Name = "btnAddContact"
        StateProperties9.BorderColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties9.BorderRadius = 35
        StateProperties9.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties9.BorderThickness = 1
        StateProperties9.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties9.ForeColor = System.Drawing.Color.White
        StateProperties9.IconLeftImage = Nothing
        StateProperties9.IconRightImage = Nothing
        Me.btnAddContact.onHoverState = StateProperties9
        StateProperties10.BorderColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties10.BorderRadius = 35
        StateProperties10.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties10.BorderThickness = 1
        StateProperties10.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(172, Byte), Integer))
        StateProperties10.ForeColor = System.Drawing.Color.White
        StateProperties10.IconLeftImage = Nothing
        StateProperties10.IconRightImage = Nothing
        Me.btnAddContact.OnPressedState = StateProperties10
        Me.btnAddContact.Size = New System.Drawing.Size(133, 45)
        Me.btnAddContact.TabIndex = 34
        Me.btnAddContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddContact.TextMarginLeft = 0
        Me.btnAddContact.UseDefaultRadiusAndThickness = True
        '
        'AddBrand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(735, 341)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtMerk)
        Me.Controls.Add(Me.btnCancelMobil)
        Me.Controls.Add(Me.btnAddContact)
        Me.Controls.Add(Me.lblCurTab)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddBrand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblCurTab As Label
    Public WithEvents btnUpdate As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Public WithEvents btnCancelMobil As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Public WithEvents btnAddContact As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Public WithEvents txtMerk As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox
End Class
