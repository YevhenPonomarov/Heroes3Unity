using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabPopUpObject;
    [SerializeField] private GameObject mainCanvas;

    private PopUpObject _popUpObject;

    public const string defaultTextValidate = "Validate";
    public const string defaultTextCancel = "Cancel";
    public const string defaultTextOk = "Ok";
    
    // Start is called before the first frame update
    void Start()
    {
        InstancePopUp();
    }

    public void InstancePopUp(PopUpObject.PopupType type = PopUpObject.PopupType.POP_UP_TYPE_T_B_V_C,
        string titleText = "myTitle",
        string bodyText = "myBodyText",
        string validateText = defaultTextValidate,
        string cancelText = defaultTextCancel,
        string okText = defaultTextOk,
        Callback validateCb = null,
        Callback cancelCb = null,
        Callback okCb = null)
    {
        if (_popUpObject == null)
        {
            _popUpObject = Instantiate(prefabPopUpObject, mainCanvas.transform).GetComponent<PopUpObject>();
            _popUpObject.InitializePopup(type, titleText, bodyText, validateText, cancelText, okText, validateCb, cancelCb, okCb);
        }
    }
}
