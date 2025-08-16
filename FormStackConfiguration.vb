Public Class FormStackConfiguration

    Public Property FMain As Form_Main
    Public Property StackConfiguration As StackConfigurationConstants

    Public Sub New(_FMain As Form_Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.FMain = _FMain

    End Sub

    Public Enum StackConfigurationConstants

        '  F Fastener
        ' CO Clamped Object
        '  N Nut
        ' FW Flat Washer
        ' LW Lock Washer
        ' TT Thread Thru
        ' TB Thread Blind

        F_CO_N
        F_CO_FW_N
        F_CO_LW_N
        F_CO_FW_LW_N
        F_FW_CO_N
        F_FW_CO_FW_N
        F_FW_CO_LW_N
        F_FW_CO_FW_LW_N
        F_CO_TT
        F_FW_CO_TT
        F_LW_CO_TT
        F_LW_FW_CO_TT
        F_CO_TB
        F_FW_CO_TB
        F_LW_CO_TB
        F_LW_FW_CO_TB
    End Enum

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.OK
    End Sub

    Private Sub FormStackConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button_F_CO_N_Click(sender As Object, e As EventArgs) Handles Button_F_CO_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_CO_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_CO_FW_N_Click(sender As Object, e As EventArgs) Handles Button_F_CO_FW_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_CO_FW_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_CO_LW_N_Click(sender As Object, e As EventArgs) Handles Button_F_CO_LW_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_CO_LW_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_CO_FW_LW_N_Click(sender As Object, e As EventArgs) Handles Button_F_CO_FW_LW_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_CO_FW_LW_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_FW_CO_N_Click(sender As Object, e As EventArgs) Handles Button_F_FW_CO_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_FW_CO_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_FW_CO_FW_N_Click(sender As Object, e As EventArgs) Handles Button_F_FW_CO_FW_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_FW_CO_FW_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_FW_CO_LW_N_Click(sender As Object, e As EventArgs) Handles Button_F_FW_CO_LW_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_FW_CO_LW_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_FW_CO_FW_LW_N_Click(sender As Object, e As EventArgs) Handles Button_F_FW_CO_FW_LW_N.Click
        Me.StackConfiguration = StackConfigurationConstants.F_FW_CO_FW_LW_N
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_CO_TT_Click(sender As Object, e As EventArgs) Handles Button_F_CO_TT.Click
        Me.StackConfiguration = StackConfigurationConstants.F_CO_TT
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_FW_CO_TT_Click(sender As Object, e As EventArgs) Handles Button_F_FW_CO_TT.Click
        Me.StackConfiguration = StackConfigurationConstants.F_FW_CO_TT
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_LW_CO_TT_Click(sender As Object, e As EventArgs) Handles Button_F_LW_CO_TT.Click
        Me.StackConfiguration = StackConfigurationConstants.F_LW_CO_TT
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_LW_FW_CO_TT_Click(sender As Object, e As EventArgs) Handles Button_F_LW_FW_CO_TT.Click
        Me.StackConfiguration = StackConfigurationConstants.F_LW_FW_CO_TT
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_CO_TB_Click(sender As Object, e As EventArgs) Handles Button_F_CO_TB.Click
        Me.StackConfiguration = StackConfigurationConstants.F_CO_TB
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_FW_CO_TB_Click(sender As Object, e As EventArgs) Handles Button_F_FW_CO_TB.Click
        Me.StackConfiguration = StackConfigurationConstants.F_FW_CO_TB
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_LW_CO_TB_Click(sender As Object, e As EventArgs) Handles Button_F_LW_CO_TB.Click
        Me.StackConfiguration = StackConfigurationConstants.F_LW_CO_TB
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_F_LW_FW_CO_TB_Click(sender As Object, e As EventArgs) Handles Button_F_LW_FW_CO_TB.Click
        Me.StackConfiguration = StackConfigurationConstants.F_LW_FW_CO_TB
        DialogResult = DialogResult.OK
    End Sub
End Class