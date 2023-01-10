using System;

namespace PopupSystem.Popups.CommonPopup
{
    public class CommonPopupModel : BasePopupModel
    {
        public enum PopupType
        {
            POP_UP_TYPE_T_B_V_C, // Title body Validate cancel
            POP_UP_TYPE_T_B_O, // Title body ok
            POP_UP_TYPE_T_V_C, // Title validate cancel
            POP_UP_TYPE_T_O, // Title ok
            POP_UP_TYPE_B_V_C, // body validate cancel
            POP_UP_TYPE_B_0 // body Validate cancel
        }

        public PopupType Type { get; }
        public string TitleText { get; }
        public string BodyText { get; }
        public string ValidateText { get; }
        public string CancelText { get; }
        public string OkText { get; }

        public Action ValidateCb;
        public Action CancelCb;
        public Action OkCb;

        public CommonPopupModel(PopupType type,
        string titleText = "myTitle",
        string bodyText = "myBodyText",
        string validateText = "Validate",
        string cancelText = "Cancel",
        string okText = "Ok",
        Action validateCb = null,
        Action cancelCb = null,
        Action okCb = null)
        {
            Type = type;
            TitleText = titleText;
            BodyText = bodyText;
            ValidateText = validateText;
            CancelText = cancelText;
            OkText = okText;
            ValidateCb = validateCb;
            CancelCb = cancelCb;
            OkCb = okCb;
        }
    }
}