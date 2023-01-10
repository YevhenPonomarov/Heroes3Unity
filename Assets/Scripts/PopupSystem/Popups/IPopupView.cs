namespace PopupSystem
{
    public interface IPopupView
    {
        void Initialize(IPopup controller, IPopupModel model){}
        void Show();
        void Hide();
    }
}