using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Settings")]
    public float damage; // tower damage
    public float fireRate; // tower fire rate
    public float searchRadius; // tower range

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

            // Получаем направление на ближайший объект, ограничивая его только по оси Y
            Vector3 direction = new Vector3(closestObject.transform.position.x - transform.position.x, 0f, closestObject.transform.position.z - transform.position.z);

            // Поворачиваем башню в заданном направлении
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

}