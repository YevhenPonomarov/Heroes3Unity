using System;
using UnityEngine;

public class Npc : MonoBehaviour
{
    GameObject dial;   
    public Dialog dialog;

    public void NPCDialog()
    {
       dial = GameObjectManager.instance.allObject[0];
       dial.GetComponent<DialogManager>().StartDialog(dialog);
    }
}

