using NavGraphTools.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NavGraphTools.Src
{
    public abstract class Graph<T>
    {
        //Internal so *Navigator* has access to it but nothing outside this assembly does        
        internal Dictionary<int, T> Nodes = new Dictionary<int, T>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="GenerateNewGraph">[true] if you're creating a new graph, [false] if you're going to read in data</param>
        public Graph(bool GenerateNewGraph)
        { }

        public Graph()
        { }

        #region Getting Nodes
        /// <summary>
        /// Attempts to retreive the node
        /// </summary>
        /// <param name="_UID">Unique ID of the node to get</param>
        /// <returns>Returns the node with the UID or null if it doesn't exist</returns>
        /// <exception cref="NotImplementedException"></exception>
        public T? TryGetNode(int _UID)
        {
            if (DoesNodeExist(_UID))
            { return Nodes[_UID]; }
            else
            { return default; } //null equivalent for generic methods??            
        }

        /// <summary>
        /// Gets all the nodes in the graph with their UID
        /// </summary>
        /// <returns>a list of all nodes int the Graph</returns>
        public Dictionary<int, T> GetAllNodes()
        { return Nodes; }

        #endregion

        #region Node Checking
        /// <summary>
        /// Checks if a node with the specified UI exists
        /// </summary>
        /// <param name="_UID">UID of the node to check</param>
        /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
        public bool DoesNodeExist(int _UID)
        {
            if (Nodes.ContainsKey(_UID))
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Gets how many active connections a node has
        /// </summary>
        /// <param name="_UID">UID of the base node to check</param>
        /// <returns>How many active connections the base node has</returns>
        public abstract int NumberOfConnections(int _UID);

        /// <summary>
        /// Returns the number of nodes in the internal dictionary
        /// </summary>
        /// <returns>An integer of the count</returns>
        public int CountNodes()
        { return Nodes.Count; }
        #endregion

        #region Serialising stuff
        /// <summary>
        /// Takes an input stream and writes data to it
        /// </summary>
        /// <param name="_InputStream">Stream data is to be written to</param>
        public abstract void Deserialise(Stream _InputStream);
        #endregion
    }
}
