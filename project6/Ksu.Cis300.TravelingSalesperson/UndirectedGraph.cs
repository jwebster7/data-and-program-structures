/* Author: Joe Webster
 * Date: 11/29/2017 - 12/1/2017
 * Instructor: Dr. Weese
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TravelingSalesperson
{
    class UndirectedGraph
    {
        /// <summary>
        /// The row indices are the source nodes and the column indices are the edges
        /// </summary>
        private int[,] _adjMatrix;

        /// <summary>
        /// String representation of each node;
        /// Index corresponds to a node in the adjacency matrix
        /// </summary>
        private List<string> _nodes = new List<string>(0);

        /// <summary>
        /// Number of nodes in the graph
        /// </summary>
        private int _size;

        /// <summary>
        /// Default constructor for UndirectedGraph
        /// </summary>
        /// <param name="size">for initializing _size</param>
        public UndirectedGraph(int size)
        {
            _size = size;
            _adjMatrix = new int[size, size];
        }

        /// <summary>
        /// Private method for adding a string representation of a node to _nodes
        /// </summary>
        /// <param name="data">used for adding a string to _nodes</param>
        private void AddNode(string data)
        {
            if (_nodes.Count == _size)
            {
                throw new InvalidOperationException();
            }
            _nodes.Add(data);
        }

        /// <summary>
        /// Returns the string rep of a node at the given index
        /// </summary>
        /// <param name="index">index of the _nodes</param>
        /// <returns></returns>
        public string GetNode(int index)
        {
            return _nodes[index];
        }

        /// <summary>
        /// Adds an edge to the _adjMatrix
        /// </summary>
        /// <param name="source">the source</param>
        /// <param name="dest">the destination</param>
        /// <param name="weight">the weight</param>
        public void AddEdge(string source, string dest, int weight)
        {
            int sourceIndex = _nodes.IndexOf(source);
            int destIndex = _nodes.IndexOf(dest);
            if (sourceIndex < 0)
            {
                sourceIndex = _nodes.Count;
                AddNode(source);
            }
            if (destIndex < 0)
            {
                destIndex = _nodes.Count;
                AddNode(dest);
            }
            _adjMatrix[sourceIndex, destIndex] = weight;
            _adjMatrix[destIndex, sourceIndex] = weight;
        }

        /// <summary>
        /// Calculates the minimum cost spanning tree of the graph by using "Prim's Algorithm"
        /// </summary>
        /// <returns>MTSNode</returns>
        public MSTNode GetMinSpanningTree()
        {
            MSTNode[] tree = new MSTNode[_size];
            bool[] nodesAdded = new bool[_size];
            for (int i = 1; i < _size; i++)
            {
                tree[i] = new MSTNode(Int32.MaxValue, 0, _nodes[i]);
            }
            tree[0] = new MSTNode(0, -1, _nodes[0]);

            int minIndex = -1;
            for (int i = 0; i < _size; i++)
            {
                int min = Int32.MaxValue;
                for (int j = 0; j < _size; j++)
                {
                    if (!nodesAdded[j] && tree[j].Data < min)
                    {
                        min = tree[j].Data;
                        minIndex = j;
                    }
                }
                nodesAdded[minIndex] = true;
                if (i != 0)
                {
                    tree[tree[minIndex].Parent].AddChild(tree[minIndex]);
                }
                for (int k = 0; k < _size; k++)
                {
                    if (_adjMatrix[minIndex, k] != 0 && !nodesAdded[k] && _adjMatrix[minIndex, k] < tree[k].Data)
                    {
                        tree[k].Parent = minIndex;
                        tree[k].Data = _adjMatrix[minIndex, k];
                    }
                }
            }
            return tree[0];
        }
    }
}