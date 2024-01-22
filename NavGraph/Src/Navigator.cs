// Ignore Spelling: Nav Dest

namespace NavGraphTools
{
    /*public class Navigator
    {
        #region Variables
        private NavNode? Origin { get; set; }
        private NavNode? Destination { get; set; }
        private NavNode? CurrentLocation = null;

        //states
        private bool IsSFloor = false;
        private bool IsSBlock = false;
        private bool IsSGFloor = false;

        //A* stuff
        private List<int> Path = new List<int>();
        private List<int> VisitedNodes = new List<int>();
        #endregion

        /// <summary>
        /// Starts navigation
        /// </summary>
        /// <param name="StartNodeUID">The UID of the node to start from</param>
        /// <param name="DestNodeUID">The UID of the destination node</param>
        /// <param name="_NG">The navgraph object to navigate</param>
        /// <returns>A list of nodes in order to travel from Start to End</returns>
        public List<int>? StartNavigation(int _StartNodeUID, int _DestNodeUID, ref NavGraph _NG)
        {
            //navigate

            return Path;
        }

        public List<int>? StartNavigation(int _DestNode, ref NavGraph _NG)
        {


            return Path;
        }

        public List<int> Nearest<T>(ref NavGraph _NG) where T : ISpecialNode
        {
            List<int> Path = new List<int>();

            //if (typeof(T) == typeof(ElevationNode) && CurrentLocation.ElvNodeDirection != null)
            //{ return ElvFlowFollower(ref _NG); }
            //else if (typeof(T) == typeof(GatewayNode) && CurrentLocation.GatewayNodeDirection != null)
            //{ return GateFlowFollower(ref _NG); }

            return new List<int>();
        }

        private List<int> ElvFlowFollower(ref NavGraph _NG)
        {
            NavNode Step = CurrentLocation;
            List<int> Path = new List<int>();

            while (Step.ElvNodeDirection != null)
            {
                Path.Add(Step.UID);

                Step = _NG.TryGetNode(Step.GetNode((NodeDirection)Step.ElvNodeDirection));
            }

            return Path;
        }

        private List<int> GateFlowFollower(ref NavGraph _NG)
        {
            NavNode Step = CurrentLocation;
            List<int> Path = new List<int>();

            while (Step.GatewayNodeDirection != null)
            {
                Path.Add(Step.UID);

                Step = _NG.TryGetNode(Step.GetNode((NodeDirection)Step.GatewayNodeDirection));
            }

            return Path;
        }

        public void Navigate(ref NavGraph _NG)
        {

        }
    }*/
}
