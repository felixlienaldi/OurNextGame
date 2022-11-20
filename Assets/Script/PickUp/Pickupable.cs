using UnityEngine;

public interface Pickupable : Interactable
{
    public void PickUp(Transform transform);

    public void Drop();

    public void Rotate(float rotationSpeed);

    public ItemGhost Visual();

}
