using Unity.VisualScripting;
using UnityEngine;

namespace PopupSystem.Popups.CommonPopup
{
    public class CommonPopup : BasePopup<CommonPopupModel>
    {
        protected override string PREFAB_PATH => "Prefabs/Popup/CommonPopup";

        protected override IPopupView CreateView(Object res)
        {
            return GameObject.Instantiate(res, PopUpManager.instance.mainCanvas.transform).GetComponent<CommonPopupView>();
        }

        public CommonPopup(CommonPopupModel model) : base(model)
        {
        }

        public void OnCloseFinished()
        {
            PopUpManager.instance.onCloseFinished(this);
        }
        
    }
}