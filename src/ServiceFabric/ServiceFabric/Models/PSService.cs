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

using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    class PSService : ServiceResource
    {
        public PSService(ServiceResource service)
            : base(
                  id: service.Id,
                  name: service.Name,
                  type: service.Type,
                  location: service.Location,
                  placementConstraints: service.PlacementConstraints,
                  correlationScheme: service.CorrelationScheme,
                  serviceLoadMetrics: service.ServiceLoadMetrics,
                  servicePlacementPolicies: service.ServicePlacementPolicies,
                  defaultMoveCost: service.DefaultMoveCost,
                  provisioningState: service.ProvisioningState,
                  serviceTypeName: service.ServiceTypeName,
                  partitionDescription: service.PartitionDescription)
        {
        }
    }
}
