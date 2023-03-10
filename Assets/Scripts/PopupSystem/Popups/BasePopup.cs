using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PopupSystem.Popups
{
    public abstract class BasePopup<TModel> : IPopup where TModel : BasePopupModel
    {
        protected virtual string PREFAB_PATH{ get; }
        public TModel Model { get; }
        public IPopupView View{ get; private set; }

        protected virtual IPopupView CreateView(Object res)
        {
            return null;
        }

        protected BasePopup(TModel model)
        {
            Model = model;
            var viewRes = Resources.Load(PREFAB_PATH);
            if (viewRes == null)
            {
                throw new ArgumentNullException(nameof(viewRes));
            }

            View = CreateView(viewRes);
            if (View == null)
            {
                throw new ArgumentNullException(nameof(View));
            }
            View.Initialize(this, Model);
        }

        public void Open()
        {
            PopUpManager.Instance.PlayAudioShowPopup();
            View.Show();
        }

        public void Close()
        {
            PopUpManager.Instance.PlayAudioClosePopup();
            View.Hide();
        }

        public void OnCloseFinished()
        {
            PopUpManager.Instance.OnCloseFinished(this);
        }
    }
}