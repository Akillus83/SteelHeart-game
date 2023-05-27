using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour, IPickupable
{
    
    public GameObject pickedUpObject;
     public bool isPickedUp;

    // ���������� ������ Pickup ���������� IPickupable
    public void Pickup()
    {
        // ������ ����
        isPickedUp = true;
        // ��������� ���������, ����� ������ �� �������
        pickedUpObject.GetComponent<Collider>().enabled = false;
        // ��������� ������, ����� ������ ����� ���� ���������� �������
        pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // ���������� ������ Drop ���������� IPickupable
    public void Drop()
    {
        if (isPickedUp)
        {
            // �������� ��������� � ������
            pickedUpObject.GetComponent<Collider>().enabled = true;
            pickedUpObject.GetComponent<Rigidbody>().isKinematic = false;
            // ��������� ���� ������� ������
            pickedUpObject.GetComponent<Rigidbody>().AddForce(transform.up * 10);
        }
    }
}
