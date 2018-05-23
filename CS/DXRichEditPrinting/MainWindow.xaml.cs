using System.Drawing.Printing;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Windows.Forms;

namespace DXRichEditPrinting
{
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrinterSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region #PrinterSettings
            if (layoutCheckItem.IsChecked == true) { ChangeDocumentLayout(); }
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.FromPage = 2;
            printerSettings.ToPage = 3;
            MessageBox.Show("Printing "+ printerSettings.Copies.ToString()+" copy(ies) of pages "+ printerSettings.FromPage+ "-"+ printerSettings.ToPage);
            richEditControl1.Print(printerSettings);
            #endregion #PrinterSettings
        }

        private void btnDefaultPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (layoutCheckItem.IsChecked == true) { ChangeDocumentLayout(); }
            richEditControl1.Print();
        }


        private void ChangeDocumentLayout()
        {

            #region #setprintoptions
            foreach (Section _section in richEditControl1.Document.Sections)
            {
                _section.Page.PaperKind = PaperKind.A3;
                _section.Page.Landscape = true;
                _section.Margins.Left = 500f;
                _section.Margins.Right = 500f;
                _section.Margins.Top = 200f;
                _section.Margins.Bottom = 200f;
                _section.PageNumbering.NumberingFormat = NumberingFormat.CardinalText;
                _section.PageNumbering.FirstPageNumber = 0;
            }
            #endregion #setprintoptions

        }
    }
}