using System;

namespace PopupSystem
{
    public interface IPopup
    {
        IPopupView View{ get; }
        void Open();
        void Close();
    }
}