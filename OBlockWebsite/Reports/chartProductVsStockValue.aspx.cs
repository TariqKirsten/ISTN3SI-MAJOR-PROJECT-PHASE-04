using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite.Reports
{
    public partial class chartProductVsStockValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();

            //if (!IsPostBack)
            //ShowData();
        }
        private void ShowData()
        {
            DataSet DS = new DataSet();
            DataSetTableAdapters.PRODUCTDISPLAYTableAdapter TA = new DataSetTableAdapters.PRODUCTDISPLAYTableAdapter();
            TA.Fill(DS.PRODUCTDISPLAY);




            String chart = "";
            chart = "<canvas id=\"bar-chart\" width=\"100%\" height=\"55\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"bar-chart\"), { type: 'bar', data: {labels: [";

            String barColour = "#de335e";//bar colour
            String xAxisBoxLabel = "Stock Value (Markup Price (ZAR))";//same as x axis title
            String xAxisTitle = "Product";
            String yAxisLabel = "Price (ZAR)";
            String chartTitle = "Product Vs. Stock Value (ZAR)"; String xAxisBoxLabel2 = "Stock Value (Cost Price (ZAR))";
            String barColour2 = "#47bfd1";
            //X AXIS LABELS
            for (int i = 0; i < DS.PRODUCTDISPLAY.Rows.Count; i++)
            {
                String prod = DS.PRODUCTDISPLAY.Rows[i][1].ToString();
                String p = "";
                for (int j = 0; j < prod.Length; j++)
                {
                    if (prod.Substring(j, 1).Equals("'"))////add \ character for ' character
                    {
                        p += "\\";

                    }
                    p += prod.Substring(j, 1);
                }

                chart += "'" + p + "',";


            }
            chart = chart.Substring(0, chart.Length - 1);
            ////////////////////////////////////////////////////////////////////////////////////////////
            //chart += "],datasets: [{ data: [";
            chart += "],datasets: [{label: \"" + xAxisBoxLabel + "\",borderColor: \"#3e95cd\", backgroundColor: \"" + barColour + "\", data: [";

            // Y AXIS VALUES
            String value = "";
            for (int i = 0; i < DS.PRODUCTDISPLAY.Rows.Count; i++)
            {
                String v = "";
                Double stockVal = Convert.ToDouble(DS.PRODUCTDISPLAY.Rows[i][3].ToString()) * Convert.ToDouble(DS.PRODUCTDISPLAY.Rows[i][2].ToString());
                v = stockVal.ToString();
                v = v.Replace(",", ".");
                value += v + ",";
            }

            value = value.Substring(0, value.Length - 1);
            /////////////////////////////////////////////////////////////////////
            chart += value;

            //chart += "],label: \""+xAxisBoxLabel+"\",borderColor: \"#3e95cd\", backgroundColor: \""+barColour+"\",fill: true}";
            chart += "]}";
            //chart += ", { data: [";

            chart += ", {label: \"" + xAxisBoxLabel2 + "\",borderColor: \"#3e95cd\", backgroundColor: \"" + barColour2 + "\", data: [";

            /////////////////////////
            value = "";
            for (int i = 0; i < DS.PRODUCTDISPLAY.Rows.Count; i++)
            {
                String v = "";
                Double cpVal = Convert.ToDouble(DS.PRODUCTDISPLAY.Rows[i][3].ToString()) * Convert.ToDouble(DS.PRODUCTDISPLAY.Rows[i][6].ToString());
                v = cpVal.ToString();
                v = v.Replace(",", ".");
                //v = "10";
                value += v + ",";
            }

            value = value.Substring(0, value.Length - 1);
            chart += value;
            /////////////////////////////////////////////////////////////////////


            //chart += "],label: \"" + xAxisBoxLabel2 + "\",borderColor: \"#3e95cd\", backgroundColor: \"" + barColour2 + "\",fill: true}";
            chart += "]}";
            chart += "]},options: { title: { display: true,text: '" + chartTitle + "'},scales: {xAxes: [{scaleLabel: {display: true, labelString: \'" + xAxisTitle + "\'},beginAtZero: true,ticks: { autoSkip: false}}], yAxes: [{scaleLabel: {display: true, labelString: \'" + yAxisLabel + "\'}}]} }"; // Chart title
            chart += "});";
            chart += "</script>";

            ltChart.Text = chart;



        }
    }
}