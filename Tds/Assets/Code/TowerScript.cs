using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Settings")]
    public int damage;
    public int fireRate; // �������� �������� � ��������
    public int searchRadius;

    private GameObject closestObject;

    void Start()
    {
        InvokeRepeating("MakeDamage", 0f, fireRate); // �������� MakeDamage ������ fireRate ������, ������� ����� ��
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);

        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag != "Enemy") continue;

            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = collider.gameObject;
            }
        }
    }

    void MakeDamage()
    {
        if (closestObject != null)
        {
            closestObject.GetComponent<EnemyScript>().health -= damage;
        }
    }
}
