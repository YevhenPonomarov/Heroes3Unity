using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpObject : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _bodyText;
    [SerializeField] TextMeshProUGUI _validateText;
    [SerializeField] TextMeshProUGUI _cancelText;
    [SerializeField] TextMeshProUGUI _okText;
    
    [SerializeField] Button _validateButton;
    [SerializeField] Button _cancelButton;
    [SerializeField] Button _okButton;
    
    [SerializeField]  Animator _animatorPopup;

    private Callback _onValidate;
    private Callback _onCancel;
    private Callback _onOk;

    public enum PopupType
    {
        POP_UP_TYPE_T_B_V_C, // Title body Validate cancel
        POP_UP_TYPE_T_B_O, // Title body ok
        POP_UP_TYPE_T_V_C, // Title validate cancel
        POP_UP_TYPE_T_O, // Title ok
        POP_UP_TYPE_B_V_C, // body validate cancel
        POP_UP_TYPE_B_0 // body Validate cancel
    }

    [HideInInspector] public PopupType _popupType;

    public void ShowUpType(PopupType type)
    {
        _popupType = type;
        {
            switch (type)
            {
                case PopupType.POP_UP_TYPE_T_B_V_C:
                    _titleText.gameObject.SetActive(true);
                    _bodyText.gameObject.SetActive(true);
                    _validateButton.gameObject.SetActive(true);
                    _cancelButton.gameObject.SetActive(true);
                    _okButton.gameObject.SetActive(false);
                    break;
                case PopupType.POP_UP_TYPE_T_B_O:
                    _titleText.gameObject.SetActive(true);
                    _bodyText.gameObject.SetActive(true);
                    _validateButton.gameObject.SetActive(false);
                    _cancelButton.gameObject.SetActive(false);
                    _okButton.gameObject.SetActive(true);
                    break;
                case PopupType.POP_UP_TYPE_T_V_C:
                    _titleText.gameObject.SetActive(true);
                    _bodyText.gameObject.SetActive(false);
                    _validateButton.gameObject.SetActive(true);
                    _cancelButton.gameObject.SetActive(true);
                    _okButton.gameObject.SetActive(false);
                    break;
                case PopupType.POP_UP_TYPE_T_O:
                    _titleText.gameObject.SetActive(true);
                    _bodyText.gameObject.SetActive(false);
                    _validateButton.gameObject.SetActive(false);
                    _cancelButton.gameObject.SetActive(false);
                    _okButton.gameObject.SetActive(true);
                    break;
                case PopupType.POP_UP_TYPE_B_V_C:
                    _titleText.gameObject.SetActive(false);
                    _bodyText.gameObject.SetActive(true);
                    _validateButton.gameObject.SetActive(true);
                    _cancelButton.gameObject.SetActive(true);
                    _okButton.gameObject.SetActive(false);
                    break;
                case PopupType.POP_UP_TYPE_B_0:
                    _titleText.gameObject.SetActive(false);
                    _bodyText.gameObject.SetActive(true);
                    _validateButton.gameObject.SetActive(false);
                    _cancelButton.gameObject.SetActive(false);
                    _okButton.gameObject.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public void InitializePopup(PopupType type = PopupType.POP_UP_TYPE_T_B_V_C,
        string titleText = "myTitle",
        string bodyText = "myBodyText",
        string validateText = "Validate",
        string cancelText = "Cancel",
        string okText = "Ok",
        Callback validateCb = null,
        Callback cancelCb = null,
        Callback okCb = null)
    {
        ShowUpType(type);
        _titleText.text = titleText;
        _bodyText.text = bodyText;
        _validateText.text = validateText;
        _cancelText.text = cancelText;
        _okText.text = okText;
        _onValidate = validateCb;
        _onCancel = cancelCb;
        _onOk = okCb;
    }

    public void OnClickValidate()
    {
        if (_onValidate != null)
        {
            _onValidate();
        }
    }

    public void OnClickCancel()
    {
        if (_onCancel != null)
        {
            _onCancel();
        }
    }

    public void OnClickOk()
    {
        if (_okButton != null)
        {
            _onOk();
        }
    }

    public void ClosePopup()
    {
        _animatorPopup.Play("ClosePopup");
    }

    public void DestroyPopup()
    {
        Destroy(gameObject);
    }
}
