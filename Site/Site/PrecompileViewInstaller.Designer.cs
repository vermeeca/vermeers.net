﻿namespace Site
{
    partial class PrecompileViewInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.precompileInstaller1 = new Spark.Web.Mvc.Install.PrecompileInstaller();
            // 
            // precompileInstaller1
            // 
            this.precompileInstaller1.SettingsInstantiator = null;
            this.precompileInstaller1.TargetAssemblyFile = null;
            this.precompileInstaller1.DescribeBatch += new Spark.Web.Mvc.Install.DescribeBatchHandler(this.precompileInstaller1_DescribeBatch);
            // 
            // PrecompileViewInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.precompileInstaller1});

        }

        #endregion

        private Spark.Web.Mvc.Install.PrecompileInstaller precompileInstaller1;
    }
}