using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Settings")]
    public int speed;
    public float health;
    public int kill_money;

    [Header("Other")]
    public int paths_dot;
    public GameObject script_service;
    public BaseSystem base_system;
    public MoneySystem money_system;

    [Header("Paths")]
    public List<GameObject> goList;



    void Start()
    {
        goList[0] = GameObject.Find("Start");
        goList[1] = GameObject.Find("2");
        goList[2] = GameObject.Find("3");
        goList[3] = GameObject.Find("4");
        goList[4] = GameObject.Find("5");
        goList[5] = GameObject.Find("6");
        script_service = GameObject.Find("SCRIPTSERVICE");
        base_system = script_service.GetComponent<BaseSystem>();
        money_system = script_service.GetComponent<MoneySystem>();
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
            paths_dot = 4;
        }
        if (Vector3.Distance(transform.position, goList[4].transform.position) <= 0.1)
        {
            paths_dot = 5;
        }
        if (Vector3.Distance(transform.position, goList[5].transform.position) <= 0.1)
        {
            Destroy(transform.parent.gameObject);
            if (base_system)
            {
                base_system.health -= health;
            }
        }
        if (health<=0)
        {
            Destroy(transform.parent.gameObject);
            if (money_system)
            {
                money_system.money += kill_money;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, goList[paths_dot].transform.position, speed * Time.deltaTime);
    }
}
