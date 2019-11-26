using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite.Reports
{
    public partial class chartProductVsPrevSaleTotal : System.Web.UI.Page
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
            DataSetTableAdapters.ProductVsTotalSalesTableAdapter TA = new DataSetTableAdapters.ProductVsTotalSalesTableAdapter();
            TA.Fill(DS.ProductVsTotalSales);



            String chart = "";
            chart = "<canvas id=\"bar-chart\" width=\"100%\" height=\"55\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"bar-chart\"), { type: 'bar', data: {labels: [";

            String barColour = "#ff872b";//bar colour
            String xAxisBoxLabel = "Product";//same as x axis title
            String xAxisTitle = "Product";
            String yAxisLabel = "Previous Sales Total (ZAR)";
            String chartTitle = "Product Vs. Previous Sales Total (ZAR)";
            //X AXIS LABELS
            for (int i = 0; i < DS.ProductVsTotalSales.Rows.Count; i++)
            {
                String prod = DS.ProductVsTotalSales.Rows[i][0].ToString();

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
            chart += "],datasets: [{ data: [";

            // Y AXIS VALUES
            String value = "";
            for (int i = 0; i < DS.ProductVsTotalSales.Rows.Count; i++)
            {
                String v = DS.ProductVsTotalSales.Rows[i][1].ToString();
                v = v.Replace(",", ".");
                value += v + ",";
            }

            value = value.Substring(0, value.Length - 1);
            /////////////////////////////////////////////////////////////////////
            chart += value;

            chart += "],label: \"" + xAxisBoxLabel + "\",borderColor: \"#3e95cd\", backgroundColor: \"" + barColour + "\",fill: true}";
            chart += "]},options: { title: { display: true,text: '" + chartTitle + "'},scales: {xAxes: [{scaleLabel: {display: true, labelString: \'" + xAxisTitle + "\'},beginAtZero: true,ticks: {min: 0, autoSkip: false}}], yAxes: [{scaleLabel: {display: true, labelString: \'" + yAxisLabel + "\'},beginAtZero: true,ticks: {min: 0, autoSkip: false}}]} }"; // Chart title
            chart += "});";
            chart += "</script>";

            ltChart2.Text = chart;



        }
    }
}