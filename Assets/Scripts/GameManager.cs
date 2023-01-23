using PopupSystem.Popups.CommonPopup;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            return _instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode.Escape)))
        {
            PopUpManager.Instance.CloseCurrentPopup();
        }
    }

    public void OnClickButton1()
    {
        
        var model = new CommonPopupModel(CommonPopupModel.PopupType.POP_UP_TYPE_T_B_V_C,
            "It's a title",
            "Add description here",
            "Yes",
            "No",
            "Ok", 
            () =>
            {
                
            });
        PopUpManager.Instance.ShowCommonPopup(model);
    }

    public void OnClickButton2()
    {
        var model = new CommonPopupModel(CommonPopupModel.PopupType.POP_UP_TYPE_T_B_O,
            "It's a title",
            "Add description here",
            "Yes",
            "No",
            "Ok", 
            null,
            null,
            () =>
            {
                
            });
        PopUpManager.Instance.ShowCommonPopup(model);
    }

    public void OnClickButton3()
    {
        var model = new CommonPopupModel(CommonPopupModel.PopupType.POP_UP_TYPE_T_O,
            "It's a title",
            "",
            "Yes",
            "No",
            "Ok", 
            null,
            null,
            () =>
            {
                
            });
        PopUpManager.Instance.ShowCommonPopup(model);
    }
}
