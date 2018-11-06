/* DirectedGraph.cs
 * Author: Rod Howell
 * Edit: Joe Webster
 * Date: 11/27/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.ShortestPaths
{
    /// <summary>
    /// A simple directed graph.
    /// </summary>
    /// <typeparam name="TNode">The type of the nodes in the graph.</typeparam>
    /// <typeparam name="TEdgeData">The type of data associated with the edged.</typeparam>
    public class DirectedGraph<TNode, TEdgeData>
    {
        /// <summary>
        /// The adjacency list for each node in the graph. Each node u is a key whose value is a list
        /// of nodes to which edges lead from u.
        /// </summary>
        private Dictionary<TNode, LinkedListCell<TNode>> _adjacencyLists = new Dictionary<TNode, LinkedListCell<TNode>>();

        /// <summary>
        /// second list for storing the edge data
        /// </summary>
        private Dictionary<Tuple<TNode, TNode>, TEdgeData> _edges = new Dictionary<Tuple<TNode, TNode>, TEdgeData>();

        /// <summary>
        /// Adds an edge from the given source to the given destination having the given value.
        /// If either node is not already in the graph, it is added. If either node is null, throws
        /// an ArgumentNullException. If the nodes are the same or if the graph already contains this
        /// edge, throws an ArgumentException
        /// </summary>
        /// <param name="source">The source node.</param>
        /// <param name="dest">The destination node.</param>
        /// <param name="value">The value associated with the edge.</param>
        public void AddEdge(TNode source, TNode dest, TEdgeData value)
        {
            Tuple<TNode, TNode> edge = new Tuple<TNode, TNode>(source, dest);

            //if the node items are null; maybe check source and dest directly
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            //if the nodes are the same or if the graph already contains...
            else if (source.Equals(dest) || _edges.ContainsKey(edge))
            {
                throw new ArgumentNullException();
            }
            //if the node is not in the _graph
            else
            {
                _edges.Add(edge, value);
                LinkedListCell<TNode> list = new LinkedListCell<TNode>();
                _adjacencyLists.TryGetValue(source, out list);
                LinkedListCell<TNode> newCell = new LinkedListCell<TNode>();
                newCell.Next = list;
                newCell.Data = dest;
                list = newCell;
                _adjacencyLists[source] = newCell;
                if (!_adjacencyLists.ContainsKey(dest))
                {
                    _adjacencyLists.Add(dest, null);
                }
            }
        }

        /// <summary>
        /// Determines whether this graph contains the given node. If node is null, throws an
        /// ArgumentNullException.
        /// </summary>
        /// <param name="node">The node to look for.</param>
        /// <returns>Whether this graph contains node.</returns>
        public bool ContainsNode(TNode node)
        {
            return _adjacencyLists.ContainsKey(node);
        }

        /// <summary>
        /// Gets an enumerable collection of the outgoing edges from the given node. 
        /// If source is null, throws an ArgumentNullException.
        /// </summary>
        /// <param name="source">The node whose outgoing edges we want to enumerate.</param>
        /// <returns>An enumerable collection of the outgoing edges from source.</returns>
        public IEnumerable<Edge<TNode, TEdgeData>> OutgoingEdges(TNode source)
        {
            return new AdjacencyList(this, source);
        }

        /// <summary>
        /// An enumerator for an adjacency list.
        /// </summary>
        public class AdjacencyListEnumerator : IEnumerator<Edge<TNode, TEdgeData>>
        {
            /// <summary>
            /// The start position in the enumeration.
            /// </summary>
            private LinkedListCell<TNode> _list = new LinkedListCell<TNode>();

            /// <summary>
            /// The current position in the enumeration.
            /// </summary>
            private LinkedListCell<TNode> _current;

            /// <summary>
            /// The directed graph containing the edges being enumerated.
            /// </summary>
            private DirectedGraph<TNode, TEdgeData> _graph;

            /// <summary>
            /// The source node.
            /// </summary>
            private TNode _source;

            /// <summary>
            /// Constructs an enumerator for the outgoing edges from the given source node.
            /// </summary>
            /// <param name="graph">The graph.</param>
            /// <param name="source">The source node for the outgoing edges.</param>
            public AdjacencyListEnumerator(DirectedGraph<TNode, TEdgeData> graph, TNode source)
            {
                LinkedListCell<TNode> node = graph._adjacencyLists[source];
                _list.Next = node;
                _current = _list;
                _graph = graph;
                _source = source;
            }

            /// <summary>
            /// Gets the edge at the current position. If the current position is either the starting position
            /// or the ending position, throws an InvalidOperationException.
            /// </summary>
            public Edge<TNode, TEdgeData> Current
            {
                get
                {
                    if(_current == null && _current.Equals(_source))
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        return new Edge<TNode, TEdgeData>(_source, _current.Data, _graph._edges[new Tuple<TNode, TNode>(_source, _current.Data)]);
                    }
                }
            }

            /// <summary>
            /// Disposes of any unmanaged resources (there are none).
            /// </summary>
            public void Dispose()
            {

            }

            /// <summary>
            /// Gets the edge at the current position. If the current position is either the starting position
            /// or the ending position, throws an InvalidOperationException.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Advances the current position to the next position.
            /// </summary>
            /// <returns>Whether the resulting position is valid.</returns>
            public bool MoveNext()
            {
                if(_current == null)
                {
                    return false;
                }
                else
                {
                    _current = _current.Next;
                    return _current != null;
                }
            }

            /// <summary>
            /// Not implemented.
            /// </summary>
            public void Reset()
            {
                throw new NotImplementedException();
            }
        } 

        /// <summary>
        /// An enumerable adjacency list.
        /// </summary>
        public class AdjacencyList : IEnumerable<Edge<TNode, TEdgeData>>
        {
            /// <summary>
            /// The graph.
            /// </summary>
            private DirectedGraph<TNode, TEdgeData> _graph;

            /// <summary>
            /// The source node for the edges.
            /// </summary>
            private TNode _source;

            /// <summary>
            /// Constructs a new AdjacencyList for the graph and node.
            /// </summary>
            /// <param name="graph">The graph.</param>
            /// <param name="source">The source node for the adjacency list.</param>
            public AdjacencyList(DirectedGraph<TNode, TEdgeData> graph, TNode source)
            {
                _graph = graph;
                _source = source;
            }

            /// <summary>
            /// Gets an enumerator for this adjacency list.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public IEnumerator<Edge<TNode, TEdgeData>> GetEnumerator()
            {
                return new AdjacencyListEnumerator(_graph, _source);
            }

            /// <summary>
            /// Gets an enumerator for this adjacency list.
            /// </summary>
            /// <returns>The enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
