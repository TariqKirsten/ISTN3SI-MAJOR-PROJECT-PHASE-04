﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite.Reports
{
    public partial class chartDateVsAccProfit : System.Web.UI.Page
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
            DataSetTableAdapters.SaleDateVsAccProfitTableAdapter TA = new DataSetTableAdapters.SaleDateVsAccProfitTableAdapter();
            TA.Fill(DS.SaleDateVsAccProfit);



            String chart = "";
            chart = "<canvas id=\"bar-chart\" width=\"100%\" height=\"55\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"bar-chart\"), { type: 'line', data: {labels: [";

            String barColour = "#74fc98";//bar colour
            String xAxisBoxLabel = "Date";//same as x axis title
            String xAxisTitle = "Date";
            String yAxisLabel = "Accumulated Profit (ZAR)";
            String chartTitle = "Date Vs. Accumulated Profit (ZAR)";
            //X AXIS LABELS
            for (int i = 0; i < DS.SaleDateVsAccProfit.Rows.Count; i++)
            {
                String prod = DS.SaleDateVsAccProfit.Rows[i][0].ToString();
                DateTime date = Convert.ToDateTime(prod);
                prod = date.ToString("dd/MM/yyyy");
                /* String p = "";
                 for(int j=0; j< prod.Length; j++)
                 {
                     if (prod.Substring(j, 1).Equals("'"))////add \ character for ' character
                     {
                         p += "\\";

                     }
                     p += prod.Substring(j, 1);
                 }
                 */
                chart += "'" + prod + "',";


            }
            chart = chart.Substring(0, chart.Length - 1);
            ////////////////////////////////////////////////////////////////////////////////////////////
            chart += "],datasets: [{ data: [";

            // Y AXIS VALUES
            String value = "";
            Double profit = 0;
            for (int i = 0; i < DS.SaleDateVsAccProfit.Rows.Count; i++)
            {
                profit += (Convert.ToDouble(DS.SaleDateVsAccProfit.Rows[i][2].ToString()) - Convert.ToDouble(DS.SaleDateVsAccProfit.Rows[i][1].ToString()));
                String v = profit.ToString();
                v = v.Replace(",", ".");
                value += v + ",";
            }

            value = value.Substring(0, value.Length - 1);
            /////////////////////////////////////////////////////////////////////
            chart += value;

            chart += "],label: \"" + xAxisBoxLabel + "\",borderColor: \"#008a25\", backgroundColor: \"" + barColour + "\",fill: true}";
            chart += "]},options: { title: { display: true,text: '" + chartTitle + "'},scales: {xAxes: [{scaleLabel: {display: true, labelString: \'" + xAxisTitle + "\'},beginAtZero: true,ticks: {min: 0, autoSkip: false}}], yAxes: [{scaleLabel: {display: true, labelString: \'" + yAxisLabel + "\'},beginAtZero: true,ticks: {min: 0, autoSkip: false}}]} }"; // Chart title
            chart += "});";
            chart += "</script>";

            ltChart3.Text = chart;



        }
    }
}