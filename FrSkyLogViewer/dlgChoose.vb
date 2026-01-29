Imports System.Windows.Forms

Public Class dlgChoose
    Dim dlg As dlgSettings
    Private Sub dlgChoose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dlg = CType(Me.Owner, dlgSettings)
        Dim frm As frmMain = CType(dlg.Owner, frmMain)
        Dim tab As DataTable = CType(frm.DataGridView1.DataSource, DataTable)
        If tab Is Nothing Then
            MessageBox.Show("No data loaded, please open a log file first...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If
        For Each col As DataColumn In tab.Columns
            lstColumns.Items.Add(col.ColumnName)
        Next
        If dlg.item = "GPS" Then
            lstColumns.SelectedItem = My.Settings.GPS_Source
        ElseIf dlg.item = "Altitude" Then
            lstColumns.SelectedItem = My.Settings.Altitude_Source
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If dlg.item = "GPS" Then
            My.Settings.GPS_Source = lstColumns.SelectedItem
        ElseIf dlg.item = "Altitude" Then
            My.Settings.Altitude_Source = lstColumns.SelectedItem
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
