// Ignore Spelling: Nav Dest

namespace NavGraphTools
{
    public class Navigator
    {
        #region Variables
        private NavNode? Origin { get; set; }
        private NavNode? Destination { get; set; }
        private NavNode? CurrentLocation = null;

        //states
        private bool IsSFloor = false;
        private bool IsSBlock = false;
        private bool IsSGFloor = false;
        #endregion
    }
}
