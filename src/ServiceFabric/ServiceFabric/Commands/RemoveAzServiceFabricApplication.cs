﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ServiceFabric;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplication")]
    public class RemoveAzServiceFabricApplication : ProxyResourceCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true,
                   HelpMessage = "Specify the name of the application")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Remove without prompt")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            var resourceMessage = string.Format("Application '{0}' in resource group '{1}', cluster name {2}", this.Name, this.ResourceGroupName, this.ClusterName);
            ConfirmAction(Force.IsPresent,
                "Do you want to remove the application? This will remove all services under this resource",
                "Removing application.",
                resourceMessage,
                () =>
                {
                    try
                    {
                        this.SFRPClient.Applications.Delete(this.ResourceGroupName, this.ClusterName, this.Name);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.PrintSdkExceptionDetail(ex);
                        throw;
                    }
                });
        }
    }
}
