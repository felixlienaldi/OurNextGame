using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour, Interactable
{

    public float lerpSpeed = 100f;
    public float rotationLimit = 180f;
    public float rotationSnapDegree = 90f;
    public ItemGhost itemGhost;

    private Vector3 newPosition;
    private Transform originParent;
    private Rigidbody rb;
    private Collider col;
    private Transform pickUpPointTransform;
    private bool rotate;
    private float rotateIndex;
    private Quaternion rotationEnd;
    void Awake() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        originParent = transform.parent;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pickUpPointTransform != null) {
            newPosition = Vector3.Lerp(transform.position, pickUpPointTransform.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPosition);
        }

        if (rotate) {
            if (rotateIndex == -1f) {
                transform.localRotation = Quaternion.Slerp(transform.localRotation,  rotationEnd ,lerpSpeed * Time.deltaTime);
                
                if (Quaternion.Angle(transform.localRotation, rotationEnd) <= 0.1f) {
                    rotate = false;
                }
            } else {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationEnd, lerpSpeed * Time.deltaTime);
                if (Quaternion.Angle(transform.localRotation, rotationEnd) <= 0.1f) {
                    rotate = false;
                }
            }
        }
    }


    public void PickUp(Transform transform) {
        this.pickUpPointTransform = transform;
       // rb.useGravity = false;
        rb.isKinematic = true;
        col.isTrigger = true;
        ItemUI.instance.SetActive(this);
        //this.transform.parent = transform.parent;
    }

    public void Drop() {
        
        //rb.useGravity = true;
        if(itemGhost.canDrop) {
            this.pickUpPointTransform = null;
            transform.position = itemGhost.transform.position;
            rb.isKinematic = false;
            col.isTrigger = false;
            itemGhost.UnFollow();
            ItemUI.instance.Deactivate();
           // transform.SetParent(originParent);
        }

    }

    public ItemGhost Visual() {
        return itemGhost;
    }

    public void Rotate(float rotationSpeed) {
        if(rotationSpeed == -1f) {
            rotate = true;
            rotateIndex = rotationSpeed;

            rotationEnd = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y - rotationSnapDegree, transform.localEulerAngles.z);
        } else if(rotationSpeed == 1f) {
            rotate = true;
            rotateIndex = rotationSpeed;
            rotationEnd = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + rotationSnapDegree, transform.localEulerAngles.z);
        } else {
            transform.localEulerAngles = new Vector3(0, rotationSpeed * rotationLimit, 0);
        }
    }
}
