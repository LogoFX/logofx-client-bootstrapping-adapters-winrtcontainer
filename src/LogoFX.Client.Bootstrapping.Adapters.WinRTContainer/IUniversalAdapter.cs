using Windows.UI.Xaml.Controls;

namespace LogoFX.Client.Bootstrapping.Adapters.WinRTContainer
{
    public interface IUniversalAdapter
    {
        void RegisterNavigationService(Frame frame);
    }
}