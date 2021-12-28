using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace EasyProject.View.TabItemPage
{
    /// <summary>
    /// IncomingOutgoingList2Page.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class IncomingOutgoingList2Page : Page
    {
        public int i = 0;
        public IncomingOutgoingList2Page()
        {
            InitializeComponent();
            export_btn.Click += Export_btn_Click;
        }
        private void Export_btn_Click(object sender, RoutedEventArgs e)
        {
            dataGrid2.SelectAllCells();
            dataGrid2.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dataGrid2);
            dataGrid2.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

            string today = String.Format(DateTime.Now.ToString("yyyyMMddhhmmss"));
            string f_path = @"c:\temp\OutgoingData" + today + ".csv";
            File.AppendAllText(f_path, result, UnicodeEncoding.UTF8);

            // Get the Excel application object.
            Excel.Application excel_app = new Excel.Application();

            // Make Excel visible (optional).
            excel_app.Visible = true;

            // Open the file.
            excel_app.Workbooks.Open(
                f_path,               // Filename
                Type.Missing,
                Type.Missing,

                   Excel.XlFileFormat.xlCSV,   // Format
                   Type.Missing,
                   Type.Missing,
                   Type.Missing,
                   Type.Missing,

                   ",",          // Delimiter
                   Type.Missing,
                   Type.Missing,
                   Type.Missing,
                   Type.Missing,
                   Type.Missing,
                   Type.Missing
            );
        }
    }
    
}
