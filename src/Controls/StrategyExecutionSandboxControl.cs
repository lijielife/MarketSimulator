﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarketSimulator.Core;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarketSimulator.Controls
{
    /// <summary>
    /// StrategyExecutionSandboxControl
    /// </summary>
    public partial class StrategyExecutionSandboxControl : UserControl
    {
        /// <summary>
        /// StrategyExecutionSandboxControl
        /// </summary>
        /// <param name="sandbox">the execution sandbox tied to this control</param>
        public StrategyExecutionSandboxControl(StrategyExecutionSandbox sandbox)
        {
            InitializeComponent();
            StrategyExecutionSandbox = sandbox;
            propertyGridSandbox.SelectedObject = StrategyExecutionSandbox;
        }

        /// <summary>
        /// StrategyExecutionSandbox
        /// </summary>
        public StrategyExecutionSandbox StrategyExecutionSandbox { get; set; }

        /// <summary>
        /// StrategyExecutionSandboxControl_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void StrategyExecutionSandboxControl_Load(object sender, EventArgs e)
        {
            #region Sandbox cash

            var sandboxSeries = new Series(StrategyExecutionSandbox.Name)
            {
                ChartType = SeriesChartType.Line,
                YAxisType = AxisType.Secondary,
                XAxisType = AxisType.Secondary,
            };

            foreach (var cash in StrategyExecutionSandbox.CashHistory)
            {
                sandboxSeries.Points.Add(cash);
            }

            chartSandbox.Series.Add(sandboxSeries);

            #endregion

            foreach (var securityMaster in StrategyExecutionSandbox.StrategyExecutor.SecurityMaster)
            {
                var mktSeries = new Series(securityMaster.Key)
                {
                    ChartType = SeriesChartType.Line,
                    YAxisType = AxisType.Secondary,
                    XAxisType = AxisType.Secondary,
                };

                foreach (var marketData in securityMaster.Value)
                {
                    mktSeries.Points.Add(marketData.Close);
                }

                chartSandbox.Series.Add(mktSeries);
            }
        }

        /// <summary>
        /// removeToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
