using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Settings")]
    public int damage; // tower damage
    public int fireRate; // tower fire rate
    public int searchRadius; // tower range

    private GameObject closestObject; // closest object (we find it in update function)

    void Start()
    {
        InvokeRepeating("MakeDamage", 0f, fireRate); // repeat function "MakeDamage" function every "fireRate" seconds
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