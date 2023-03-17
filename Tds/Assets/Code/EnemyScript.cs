using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Settings")]
    public int speed;
    public int health;
    public int kill_money;

    [Header("Other")]
    public int paths_dot;
    public GameObject script_service;
    public BaseSystem base_system;

    [Header("Paths")]
    public List<GameObject> goList;



    void Start()
    {
        goList[0] = GameObject.Find("Start");
        goList[1] = GameObject.Find("2");
        goList[2] = GameObject.Find("3");
        goList[3] = GameObject.Find("4");
        script_service = GameObject.Find("SCRIPTSERVICE");
        base_system = script_service.GetComponent<BaseSystem>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, goList[0].transform.position) <= 0.5)
        {
            paths_dot = 1;
        }
        if (Vector3.Distance(transform.position, goList[1].transform.position) <= 0.1)
        {
            paths_dot = 2;
        }
        if (Vector3.Distance(transform.position, goList[2].transform.position) <= 0.1)
        {
            paths_dot = 3;
        }
        if (Vector3.Distance(transform.position, goList[3].transform.position) <= 0.1)
        {
            Destroy(transform.parent.gameObject);
            base_system.health -= health;
        }
        if (health<=0)
        {
            Destroy(transform.parent.gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, goList[paths_dot].transform.position, speed * Time.deltaTime);
    }
}
