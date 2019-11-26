using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite.Reports
{
    public partial class chartProductVsQuantitySoldRate : System.Web.UI.Page
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
            DataSetTableAdapters.ProductVsQSoldRateTableAdapter TA = new DataSetTableAdapters.ProductVsQSoldRateTableAdapter();
            TA.Fill(DS.ProductVsQSoldRate);



            String chart = "";
            chart = "<canvas id=\"bar-chart\" width=\"100%\" height=\"55\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"bar-chart\"), { type: 'bar', data: {labels: [";

            String barColour = "#d89eff";//bar colour
            String xAxisBoxLabel = "Product";//same as x axis title
            String xAxisTitle = "Product";
            String yAxisLabel = "Quantity Sold Rate (%)";
            String chartTitle = "Product Vs. Quantity Sold Rate (%)";
            //X AXIS LABELS
            Double totalQuantity = 0;
            for (int k = 0; k < DS.ProductVsQSoldRate.Rows.Count; k++)
            {
                totalQuantity += Convert.ToDouble(DS.ProductVsQSoldRate.Rows[k][1].ToString());
            }
            for (int i = 0; i < DS.ProductVsQSoldRate.Rows.Count; i++)
            {
                String prod = DS.ProductVsQSoldRate.Rows[i][0].ToString();

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
            for (int i = 0; i < DS.ProductVsQSoldRate.Rows.Count; i++)
            {
                String v = DS.ProductVsQSoldRate.Rows[i][1].ToString();
                Double percent = Math.Round((Convert.ToDouble(v) / totalQuantity * 100), 2);
                v = percent.ToString();
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