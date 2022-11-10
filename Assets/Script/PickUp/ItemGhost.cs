using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGhost : MonoBehaviour {
    private Transform CrossHairPoint;
    public Collider collision;
    public bool canDrop;
    [SerializeField] Material red, green;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (collision.isTrigger) {
            if (canDrop) {
                GetComponent<Renderer>().material = green;
            } else {
                GetComponent<Renderer>().material = red;
            }
        }
    }

    public void Follow(Vector3 destination) {
        Vector3 tempPosition;
        transform.localEulerAngles = Vector3.zero;

        if (destination.y <= collision.bounds.extents.y) {
            tempPosition.y = destination.y - collision.bounds.extents.y - 0.05f;
        } else {
            tempPosition.y = destination.y + collision.bounds.extents.y + 0.05f;
        }

        tempPosition.x = destination.x;
        tempPosition.z = destination.z;
        transform.position = tempPosition;
        gameObject.SetActive(true);
    }

    public void UnFollow() {
        gameObject.SetActive(false);
        CrossHairPoint = null;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 6) {
            canDrop = false;
        } else {
            canDrop = true;
        }
    }
    private void OnTriggerExit(Collider other) {

        if (other.gameObject.layer == 6) {
            canDrop = true;
        }
    }


}
