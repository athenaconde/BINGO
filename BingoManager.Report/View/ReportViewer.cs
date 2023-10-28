using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

using BingoManager.SystemManager.Engine;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Reports;

namespace BingoManager.SystemManager.View
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
            this.Load += new EventHandler(ReportViewer_Load);
        }

        void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = ConnectionProvider.Connection())
                {
                    string sqlCommand = "Select SerialNumber,B,I,N,G,O From PlayingCards;";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(sqlCommand, connection))
                    {
                        bingoDataSet ds = new bingoDataSet();
                       da.Fill(ds, "PlayingCards");
                        CrystalReport1 report = new CrystalReport1();
                        report.SetDataSource(ds);
                        crystalReportViewer1.ReportSource = report;
                        crystalReportViewer1.Refresh();
                    }
                }
            }
            catch (Exception) { }
        }

    }
}
