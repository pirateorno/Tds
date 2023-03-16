using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Settings")]
    public int damage;
    public int cooldown;

    public GameObject closestObject;

    public float searchRadius = 10f;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);

        float closestDistance = Mathf.Infinity;
        GameObject closestObject = null;

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

        if (closestObject != null)
        {
            closestObject.GetComponent<EnemyScript>().health -= damage;
        }
    }
}
