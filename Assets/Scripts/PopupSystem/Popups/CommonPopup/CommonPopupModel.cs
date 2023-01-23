using System;

namespace PopupSystem.Popups.CommonPopup
{
    public class CommonPopupModel : BasePopupModel
    {
        public enum PopupType
        {
            PopUpTypeTBVC, // Title body Validate cancel
            PopUpTypeTBO, // Title body ok
            PopUpTypeTVC, // Title validate cancel
            PopUpTypeTO, // Title ok
            PopUpTypeBVC, // body validate cancel
            PopUpTypeB0 // body Validate cancel
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