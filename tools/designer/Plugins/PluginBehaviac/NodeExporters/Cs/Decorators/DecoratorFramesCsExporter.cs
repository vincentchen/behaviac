﻿/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Tencent is pleased to support the open source community by making behaviac available.
//
// Copyright (C) 2015 THL A29 Limited, a Tencent company. All rights reserved.
//
// Licensed under the BSD 3-Clause License (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at http://opensource.org/licenses/BSD-3-Clause
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and limitations under the License.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Behaviac.Design;
using Behaviac.Design.Nodes;
using PluginBehaviac.Nodes;
using PluginBehaviac.DataExporters;

namespace PluginBehaviac.NodeExporters
{
    public class DecoratorFramesCsExporter : DecoratorCsExporter
    {
        protected override bool ShouldGenerateClass(Node node)
        {
            DecoratorFrames decoratorFrames = node as DecoratorFrames;
            return (decoratorFrames != null);
        }

        protected override void GenerateMethod(Node node, StreamWriter stream, string indent)
        {
            base.GenerateMethod(node, stream, indent);

            DecoratorFrames decoratorFrames = node as DecoratorFrames;
            if (decoratorFrames == null)
                return;

            if (decoratorFrames.Frames != null)
            {
                stream.WriteLine("{0}\t\tprotected override int GetFrames(Agent pAgent)", indent);
                stream.WriteLine("{0}\t\t{{", indent);

                string retStr = RightValueCsExporter.GenerateCode(decoratorFrames.Frames, stream, indent + "\t\t\t", string.Empty, string.Empty, string.Empty);

                stream.WriteLine("{0}\t\t\treturn {1};", indent, retStr);
                stream.WriteLine("{0}\t\t}}", indent);
            }
        }
    }
}
