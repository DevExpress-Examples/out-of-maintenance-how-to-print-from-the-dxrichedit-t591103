Imports System.Drawing.Printing
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.RichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Windows.Forms

Namespace DXRichEditPrinting
    Partial Public Class MainWindow
        Inherits DXRibbonWindow

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnPrinterSettings_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            '            #Region "#PrinterSettings"
            If layoutCheckItem.IsChecked = True Then
                ChangeDocumentLayout()
            End If
            Dim printerSettings As New PrinterSettings()
            printerSettings.FromPage = 2
            printerSettings.ToPage = 3
            MessageBox.Show("Printing " & printerSettings.Copies.ToString() & " copy(ies) of pages " & printerSettings.FromPage & "-" & printerSettings.ToPage)
            richEditControl1.Print(printerSettings)
            '            #End Region ' #PrintSettings
        End Sub

        Private Sub btnDefaultPrint_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            If layoutCheckItem.IsChecked = True Then
                ChangeDocumentLayout()
            End If
            richEditControl1.Print()
        End Sub


        Private Sub ChangeDocumentLayout()

            '            #Region "#setprintoptions"
            For Each _section As Section In richEditControl1.Document.Sections
                _section.Page.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A3
                _section.Page.Landscape = True
                _section.Margins.Left = 500.0F
                _section.Margins.Right = 500.0F
                _section.Margins.Top = 200.0F
                _section.Margins.Bottom = 200.0F
                _section.PageNumbering.NumberingFormat = NumberingFormat.CardinalText
                _section.PageNumbering.FirstPageNumber = 0
            Next _section
            '            #End Region ' #setprintoptions

        End Sub
    End Class
End Namespace