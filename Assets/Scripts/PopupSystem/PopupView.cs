using UnityEngine;

namespace PopupSystem
{
    public class PopupView  : MonoBehaviour, IPopupView
    {
        public IPopup Controller { get; private set; }
        public IPopupModel Model { get; private set; }
        
        public virtual void Initialize(IPopup controller, IPopupModel model)
        {
            Controller = controller;
            Model = model;
        }
        
        public virtual void Show() { }
        public virtual void Hide() { }
    }
}