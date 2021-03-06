/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Core.Utils;
using Aliyun.Acs.Ess.Transform;
using Aliyun.Acs.Ess.Transform.V20140828;

namespace Aliyun.Acs.Ess.Model.V20140828
{
    public class DetachVServerGroupsRequest : RpcAcsRequest<DetachVServerGroupsResponse>
    {
        public DetachVServerGroupsRequest()
            : base("Ess", "2014-08-28", "DetachVServerGroups", "ess", "openAPI")
        {
        }

		private string resourceOwnerAccount;

		private string scalingGroupId;

		private bool? forceDetach;

		private long? ownerId;

		private List<VServerGroup> vServerGroups;

		public string ResourceOwnerAccount
		{
			get
			{
				return resourceOwnerAccount;
			}
			set	
			{
				resourceOwnerAccount = value;
				DictionaryUtil.Add(QueryParameters, "ResourceOwnerAccount", value);
			}
		}

		public string ScalingGroupId
		{
			get
			{
				return scalingGroupId;
			}
			set	
			{
				scalingGroupId = value;
				DictionaryUtil.Add(QueryParameters, "ScalingGroupId", value);
			}
		}

		public bool? ForceDetach
		{
			get
			{
				return forceDetach;
			}
			set	
			{
				forceDetach = value;
				DictionaryUtil.Add(QueryParameters, "ForceDetach", value.ToString());
			}
		}

		public long? OwnerId
		{
			get
			{
				return ownerId;
			}
			set	
			{
				ownerId = value;
				DictionaryUtil.Add(QueryParameters, "OwnerId", value.ToString());
			}
		}

		public List<VServerGroup> VServerGroups
		{
			get
			{
				return vServerGroups;
			}

			set
			{
				vServerGroups = value;
				for (int i = 0; i < vServerGroups.Count; i++)
				{
					DictionaryUtil.Add(QueryParameters,"VServerGroup." + (i + 1) + ".LoadBalancerId", vServerGroups[i].LoadBalancerId);
					for (int j = 0; j < vServerGroups[i].VServerGroupAttributes.Count; j++)
					{
						DictionaryUtil.Add(QueryParameters,"VServerGroup." + (i + 1) + ".VServerGroupAttribute." +(j + 1), vServerGroups[i].VServerGroupAttributes[j]);
					}
				}
			}
		}

		public class VServerGroup
		{

			private string loadBalancerId;

			private List<VServerGroupAttribute> vServerGroupAttributes;

			public string LoadBalancerId
			{
				get
				{
					return loadBalancerId;
				}
				set	
				{
					loadBalancerId = value;
				}
			}

			public List<VServerGroupAttribute> VServerGroupAttributes
			{
				get
				{
					return vServerGroupAttributes;
				}
				set	
				{
					vServerGroupAttributes = value;
				}
			}

			public class VServerGroupAttribute
			{

				private string vServerGroupId;

				private int? port;

				public string VServerGroupId
				{
					get
					{
						return vServerGroupId;
					}
					set	
					{
						vServerGroupId = value;
					}
				}

				public int? Port
				{
					get
					{
						return port;
					}
					set	
					{
						port = value;
					}
				}
			}
		}

        public override DetachVServerGroupsResponse GetResponse(UnmarshallerContext unmarshallerContext)
        {
            return DetachVServerGroupsResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }
}
