using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FP_PickUp : MonoBehaviour
{
    public Button pickUpButton;
    public Transform playerPickUpPointTransform;


    public ItemGhost visual;
    

    public void Visualization(Vector3 crossHair, ItemGhost itemGhost) {
        RefreshVisual();
        
        if(visual == null) {
            visual = itemGhost;
        }

        visual.Follow(crossHair);
    }

    public void RefreshVisual() {
        visual = null;
    }

}
 