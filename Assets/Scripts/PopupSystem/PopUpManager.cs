using System;
using PopupSystem;
using PopupSystem.Popups.CommonPopup;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] public GameObject mainCanvas;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioShowPopup;
    [SerializeField] private AudioClip audioClosePopup;

    private IPopup _currentPopup;

    private static PopUpManager _instance;
    public static PopUpManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(PopUpManager)) as PopUpManager;
            }

            return _instance;
        }
    }

    public void ShowCommonPopup(CommonPopupModel popupModel)
    {
        if (_currentPopup == null)
        {
            _currentPopup = new CommonPopup(popupModel);
            _currentPopup.Open();
        }
    }

    public void CloseCurrentPopup()
    {
        if (_currentPopup != null)
        {
            _currentPopup.Close();
            
        }
    }

    public void OnCloseFinished(IPopup popup)
    {
        if (_currentPopup == popup)
        {
            _currentPopup = null;
        }
    }

    public void PlayAudioShowPopup()
    {
        audioSource.PlayOneShot(audioShowPopup);
    }

    public void PlayAudioClosePopup()
    {
        audioSource.PlayOneShot(audioClosePopup);
    }
}
