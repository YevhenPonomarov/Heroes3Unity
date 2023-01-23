using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem.Popups.CommonPopup
{

public class CommonPopupView : PopupView
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

    private Action _onValidate;
    private Action _onCancel;
    private Action _onOk;
    private Action _closedFinished;
        
    public override void Initialize(IPopup controller, IPopupModel popupModel)
    {
        base.Initialize(controller, popupModel);
        
        var model = (CommonPopupModel) Model;
        ShowUpType(model.Type);
        
        _titleText.text = model.TitleText;
        _bodyText.text = model.BodyText;
        _validateText.text = model.ValidateText;
        _cancelText.text = model.CancelText;
        _okText.text = model.OkText;
        _onValidate += model.ValidateCb;
        _onCancel += model.CancelCb;
        _onOk += model.OkCb;
        _closedFinished += ((CommonPopup) Controller).OnCloseFinished;
    }
    
    public void ShowUpType(CommonPopupModel.PopupType type)
    {
        switch (type)
        {
            case CommonPopupModel.PopupType.PopUpTypeTBVC:
                _titleText.gameObject.SetActive(true);
                _bodyText.gameObject.SetActive(true);
                _validateButton.gameObject.SetActive(true);
                _cancelButton.gameObject.SetActive(true);
                _okButton.gameObject.SetActive(false);
                break;
            case CommonPopupModel.PopupType.PopUpTypeTBO:
                _titleText.gameObject.SetActive(true);
                _bodyText.gameObject.SetActive(true);
                _validateButton.gameObject.SetActive(false);
                _cancelButton.gameObject.SetActive(false);
                _okButton.gameObject.SetActive(true);
                break;
            case CommonPopupModel.PopupType.PopUpTypeTVC:
                _titleText.gameObject.SetActive(true);
                _bodyText.gameObject.SetActive(false);
                _validateButton.gameObject.SetActive(true);
                _cancelButton.gameObject.SetActive(true);
                _okButton.gameObject.SetActive(false);
                break;
            case CommonPopupModel.PopupType.PopUpTypeTO:
                _titleText.gameObject.SetActive(true);
                _bodyText.gameObject.SetActive(false);
                _validateButton.gameObject.SetActive(false);
                _cancelButton.gameObject.SetActive(false);
                _okButton.gameObject.SetActive(true);
                break;
            case CommonPopupModel.PopupType.PopUpTypeBVC:
                _titleText.gameObject.SetActive(false);
                _bodyText.gameObject.SetActive(true);
                _validateButton.gameObject.SetActive(true);
                _cancelButton.gameObject.SetActive(true);
                _okButton.gameObject.SetActive(false);
                break;
            case CommonPopupModel.PopupType.PopUpTypeB0:
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

    public void OnClickValidate()
    {
        if (_onValidate != null)
        {
            _onValidate();
        }
        Controller.Close();
    }

    public void OnClickCancel()
    {
        if (_onCancel != null)
        {
            _onCancel();
        }
        Controller.Close();
    }

    public void OnClickOk()
    {
        if (_okButton != null)
        {
            _onOk();
        }
        Controller.Close();
    }

    public override void Show()
    {
        _animatorPopup.Play("OpenPopup");
    }

    public override void Hide()
    {
        _animatorPopup.Play("ClosePopup");
    }

    public void OnCloseAnimationFinished()
    {
        Destroy(gameObject);
        if (_closedFinished != null)
        {
            _closedFinished();
        }
    }
}
}
