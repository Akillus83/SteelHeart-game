using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour 
{
   
    private PickupObject pickupObject;

   
    private void OnTriggerStay(Collider other)
    {
        // �������� ������ IPickupable
        IPickupable pickupable = other.GetComponent<IPickupable>();
        if (pickupable != null && Input.GetKeyDown(KeyCode.E))
        {
            
            pickupable.Pickup();
            pickupObject = other.GetComponent<PickupObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������ ����, �� �� �������� � �������
        if (pickupObject != null && pickupObject.isPickedUp)
        {
            pickupObject.transform.position = transform.position + transform.forward * 2;
        }
       
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            if (pickupObject != null && pickupObject.isPickedUp)
            {
                pickupObject.Drop();
                // �������� ������
                pickupObject = null;
            }
        }
    }
}
