// Ignore Spelling: Nav UID Deserialise

using System.Text.Json.Serialization;

namespace NavGraphTools;

public abstract class Graph<T>
{
    //InternalNode so *Navigator* has access to it but nothing outside this assembly does        
    [JsonInclude]
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
    /// Attempts to retrieve the node
    /// </summary>
    /// <param name="_UID">Unique ID of the node to get</param>
    /// <returns>Returns the node with the UID or null if it doesn't exist</returns>
    /// <exception cref="NotImplementedException"></exception>
    public T? TryGetNode(int _UID)
    {
        _UID = Math.Abs(_UID);

        if (DoesNodeExist(_UID))
        { return Nodes[_UID]; }
        else
        { return default; } //null equivalent for generic methods??            
    }

    /// <summary>
    /// Attempts to retrieve a node of a specific kind
    /// </summary>
    /// <typeparam name="D"></typeparam>
    /// <param name="_UID"></param>
    /// <returns></returns>
    public D? TryGetNode<D>(int _UID) where D : class
    {
        _UID = Math.Abs(_UID);

        if (DoesNodeExist(_UID) && Nodes[_UID] is D)
        { return Nodes[_UID] as D; }
        else
        { return default; }
    }


    /// <summary>
    /// Attempts to retrieve the node
    /// </summary>
    /// <param name="_UID">Unique ID of the node to get</param>
    /// <returns>Returns the node with the UID or null if it doesn't exist</returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool TryGetNode(int _UID, out T? _Node)
    {
        if (DoesNodeExist(_UID))
        {
            _Node = Nodes[_UID];
            return true;
        }
        else
        {
            _Node = default;
            return false;
        }
    }


    /// <summary>
    /// Gets all the nodes in the graph with their UID
    /// </summary>
    /// <returns>a list of all nodes int the Graph</returns>
    public Dictionary<int, T> GetAllNodes()
    { return Nodes; }


    /// <summary>
    /// Gets the node with the inputted UID, if it doesn't exit, returns null
    /// </summary>
    /// <param name="_UID">UID of node to return</param>
    /// <returns>Either the node or <see langword="null"/>if it doesn't exist</returns>
    public T? this[int _UID]
    {
        get
        {
            if (DoesNodeExist(_UID))
            { return Nodes[_UID]; }
            else
            { return default; }
        }
    }

    #endregion

    #region Node Checking
    /// <summary>
    /// Checks if a node with the specified UI exists
    /// </summary>
    /// <param name="_UID">UID of the node to check</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(int _UID)
    {
        if (IsValidUID(_UID) && Nodes.ContainsKey(_UID))
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

    #region Checks
    public bool IsValidUID(int _UID)
    { return NavNode.IsValidUID(_UID); }
    #endregion

    #region Serialising stuff
    /// <summary>
    /// Takes an input stream and writes data to it
    /// </summary>
    /// <param name="_InputStream">Stream data is to be written to</param>
    public abstract void Deserialise(Stream _InputStream);
    #endregion
}
