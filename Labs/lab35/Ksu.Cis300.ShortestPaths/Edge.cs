/* Edge.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ShortestPaths
{
    /// <summary>
    /// A single edge of a directed graph.
    /// <typeparam name="TNode">The type of the nodes.</typeparam>
    /// <typeparam name="TEdgeData">The type of the data associated with an edge.</typeparam>
    /// </summary>
    public struct Edge<TNode, TEdgeData>
    {
        /// <summary>
        /// The source node.
        /// </summary>
        private TNode _source;

        /// <summary>
        /// Gets the source node.
        /// </summary>
        public TNode Source
        {
            get
            {
                return _source;
            }
        }

        /// <summary>
        /// The destination node.
        /// </summary>
        private TNode _destination;

        /// <summary>
        /// Gets the destination node.
        /// </summary>
        public TNode Destination
        {
            get
            {
                return _destination;
            }
        }

        /// <summary>
        /// The data associated with the edge.
        /// </summary>
        private TEdgeData _data;

        /// <summary>
        /// Gets the data associated with the edge.
        /// </summary>
        public TEdgeData Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// Constructs an edge from the given source node to the given destination node having
        /// the given data.
        /// </summary>
        /// <param name="source">The source node.</param>
        /// <param name="dest">The destination node.</param>
        /// <param name="data">The data associated with the edge.</param>
        public Edge(TNode source, TNode dest, TEdgeData data)
        {
            _source = source;
            _destination = dest;
            _data = data;
        }
    }
}
