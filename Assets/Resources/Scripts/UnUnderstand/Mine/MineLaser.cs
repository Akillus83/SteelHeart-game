using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MineLaser : MonoBehaviour
{
    //public GameObject explosionPrefab; // ������ ������� ������
    [SerializeField] public float explosionRadius = 5f; // ������ ������

    // ���������� �����
    LineRenderer line;
    RaycastHit hit;

    public void Start(){
        // �������� ��������� LineRenderer
        line = GetComponent<LineRenderer>();
    }

    public void Update(){
        // ���������� ��������� � �������� ����� �����
        Vector3 startPoint = transform.position;
        Vector3 endPoint = transform.forward * 50f; // ����� ���� ������ �� ����� ������

        // ������������ �����
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);

        // ���������, ���� �� ����������� ����� � ������� ���������
        if (Physics.Linecast(startPoint, endPoint, out hit))
        {
            // ���� ����������� ����������, ������� ����
            Explode();
        }

         void Explode(){
            // ������� ������ ������ � ������� ������� �������
           // GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            // �������� ��� ������� � ������� ������
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            // ���������� �� ���� ��������� �������� � ������� �� ����
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rigidbody = nearbyObject.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(100f, transform.position, explosionRadius);
                    if (hit.collider.CompareTag("Player"))
                    {
                        hit.collider.GetComponent<Player>().Health.Kill();
                    }
                }
            }

            // ���������� ������
            Destroy(gameObject);
        }
    }
}