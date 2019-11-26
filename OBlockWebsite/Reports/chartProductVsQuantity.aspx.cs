using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite.Reports
{
    public partial class chartProductVsQuantity : System.Web.UI.Page
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

            String barColour = "#ffe04a";//bar colour
            String xAxisBoxLabel = "Product";//same as x axis title
            String xAxisTitle = "Product";
            String yAxisLabel = "Quantity";
            String chartTitle = "Product Vs. Quantity in Stock";
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
            chart += "],datasets: [{ data: [";

            // Y AXIS VALUES
            String value = "";
            for (int i = 0; i < DS.PRODUCTDISPLAY.Rows.Count; i++)
            {
                value += DS.PRODUCTDISPLAY.Rows[i]["product_quantity"].ToString() + ",";
            }

            value = value.Substring(0, value.Length - 1);
            /////////////////////////////////////////////////////////////////////
            chart += value;

            chart += "],label: \"" + xAxisBoxLabel + "\",borderColor: \"#3e95cd\", backgroundColor: \"" + barColour + "\",fill: true}";
            chart += "]},options: { title: { display: true,text: '" + chartTitle + "'},scales: {xAxes: [{scaleLabel: {display: true, labelString: \'" + xAxisTitle + "\'},beginAtZero: true,ticks: { autoSkip: false}}], yAxes: [{scaleLabel: {display: true, labelString: \'" + yAxisLabel + "\'}}]} }"; // Chart title
            chart += "});";
            chart += "</script>";

            ltChart.Text = chart;



        }
    }
}