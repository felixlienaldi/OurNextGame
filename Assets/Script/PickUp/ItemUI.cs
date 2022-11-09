using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public static ItemUI instance;

    public GameObject itemUI;
    public Interactable activeItem;

    private void Awake() {
        instance = this;
    }

    public void Rotate(float rotationSpeed) {
        
        activeItem.Rotate(rotationSpeed);
    }

    public void SetActive(Interactable activeItem) {
        this.activeItem = activeItem;
        itemUI.SetActive(true);
    }

    public void Deactivate() {
        this.activeItem = null;
        itemUI.SetActive(false);
    }


}
