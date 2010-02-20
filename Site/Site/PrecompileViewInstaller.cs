// Copyright 2008 Louis DeJardin - http://whereslou.com
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.IO;
using System.Reflection;
using Nerddinner.Controllers;
using Site.Controllers;
using Spark;
using Spark.FileSystem;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Site
{
    /// <summary>
    /// This installer is invoked in the post-build step of the csproj
    /// </summary>
    [RunInstaller(true)]
    public partial class PrecompileViewInstaller : Installer
    {
        public PrecompileViewInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            precompileInstaller1.Install(stateSaver);
        }

        public override void Commit(IDictionary savedState)
        {
        }

        private void precompileInstaller1_DescribeBatch(object sender, Spark.Web.Mvc.Install.DescribeBatchEventArgs e)
        {
            FindControllers().ForEach(t=>e.Batch.For(t));               
        }

        private List<Type> FindControllers()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                   where typeof(Controller).IsAssignableFrom(t)
                   select t).ToList();
        }
    }
}