using System;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public Animator anim;
    
    public void OpenDialogue()
    {
        anim.SetBool("isOpen", true);
    }
    public void CloseDialogue()
    {
        anim.SetBool("isOpen", false);
    }
}
