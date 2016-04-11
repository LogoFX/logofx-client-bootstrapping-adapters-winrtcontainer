using Windows.UI.Xaml.Controls;

namespace LogoFX.Client.Bootstrapping.Adapters.WinRTContainer
{
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