using Windows.UI.Xaml.Controls;

namespace LogoFX.Client.Bootstrapping.Adapters.WinRTContainer
{
    //TODO: to be moved to a separate package LogoFX.Client.Bootstrapping.Adapters
    //this pkg will be platform-specific and will allow to add functionality
    //to NETFX_CORE-oriented bootstrappers.

    /// <summary>
    /// Represents an adapter to Navigation using Caliburn.Micro facilities.
    /// </summary>
    public interface INavigationAdapter
    {
        /// <summary>
        /// Sets the specified frame as the root frame of the navigation.
        /// </summary>
        /// <param name="frame">The root frame</param>
        void RegisterNavigationService(Frame frame);
    }
}