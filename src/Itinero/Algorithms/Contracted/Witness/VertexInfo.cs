﻿/*
 *  Licensed to SharpSoftware under one or more contributor
 *  license agreements. See the NOTICE file distributed with this work for 
 *  additional information regarding copyright ownership.
 * 
 *  SharpSoftware licenses this file to you under the Apache License, 
 *  Version 2.0 (the "License"); you may not use this file except in 
 *  compliance with the License. You may obtain a copy of the License at
 * 
 *       http://www.apache.org/licenses/LICENSE-2.0
 * 
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

 using Itinero.Graphs.Directed;

namespace Itinero.Algorithms.Contracted.Witness
{
    /// <summary>
    /// A data structure to keep info about to be contracted vertices.
    /// </summary>
    public class VertexInfo
    {
        private readonly Itinero.Algorithms.Contracted.Witness.Shortcuts<float> _shortcuts;

        /// <summary>
        /// Creates a new vertex info.
        /// </summary>
        public VertexInfo()
        {

        }

        /// <summary>
        /// Gets or sets the vertex.
        /// </summary>
        public uint Vertex { get; set; }
        
        private int _edgesCount;
        private MetaEdge[] _edges;
        
        /// <summary>
        /// Gets the number of edges.
        /// </summary>
        public int Count
        {
            get
            {
                return _edgesCount;
            }
        }

        /// <summary>
        /// Adds a new edge.
        /// </summary>
        public void Add(MetaEdge edge)
        {
            _edgesCount++;
            if (_edgesCount >= _edges.Length)
            {
                System.Array.Resize(ref _edges, _edgesCount * 2);
            }
            _edges[_edgesCount - 1] = edge;
        }

        /// <summary>
        /// Gets the edge at the given index.
        /// </summary>
        public MetaEdge this[int i]
        {
            get
            {
                return _edges[i];
            }
        }

        /// <summary>
        /// Clears this vertex info.
        /// </summary>
        public void Clear()
        {
            _edgesCount = 0;
            _shortcuts.Clear();

            this.Vertex = Constants.NO_VERTEX;
        }
    }
}
