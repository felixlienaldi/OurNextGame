using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour,Interactable {
    public void Interact() {
        DialogueDatabase.instance.SelectDialogue(0);
        Dialogue_Manager.instance.TriggerDialogue();
    }
}
