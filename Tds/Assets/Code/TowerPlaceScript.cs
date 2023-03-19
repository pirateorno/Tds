using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceScript : MonoBehaviour
{
    public Vector3 cursorPosition;

    [Header("Towers button")]
    public Button classic_tower_button;
    public Button sniper_tower_button;
    public Button minigunner_tower_button;

    public List<GameObject> towers;
    public int tower_id;

    [Header("Other")]
    private GameObject current_placeholder;
    private GameObject current_range;
    private bool canPlace;
    public GameObject range_placeholder;
    public MoneySystem money_system;
    public GameObject tower_placeholder;


    void Start()
    {
        classic_tower_button.onClick.AddListener(() => CreatePlaceholderTower(0));
        sniper_tower_button.onClick.AddListener(() => CreatePlaceholderTower(1));
        minigunner_tower_button.onClick.AddListener(() => CreatePlaceholderTower(2));
    }

    void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Tower"); // определение маски слоя

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerMask))
        {
            if (hit.collider.tag == "Grass")
            {
                canPlace= true;
            } else
            {
                canPlace= false;
            }
            cursorPosition = hit.point;
        }


        if (current_placeholder != null)
        {
            current_placeholder.transform.position = new Vector3(cursorPosition.x, cursorPosition.y + gameObject.transform.localScale.y / 2, cursorPosition.z);
            current_range.transform.position = new Vector3(cursorPosition.x, cursorPosition.y, cursorPosition.z);
            if (tower_id == 0) { current_range.transform.localScale = new Vector3(10, 1, 10);  }
            if (tower_id == 1) { current_range.transform.localScale = new Vector3(30, 1, 30);  }
            if (tower_id == 2) { current_range.transform.localScale = new Vector3(4, 1, 4);  }
        }

        if (Input.GetButtonDown("Fire1") && current_placeholder != null && canPlace == true)
        {
            CreateTower();
        }
    }


    void CreatePlaceholderTower(int id)
    {
        if (current_placeholder == null)
        {
            if (id == 0 && money_system.money >= 50)
            {
                current_placeholder = Instantiate(tower_placeholder, cursorPosition, gameObject.transform.rotation);
                current_range = Instantiate(range_placeholder, cursorPosition, gameObject.transform.rotation);
                money_system.money -= 50;
                tower_id = id;
            }
            if (id == 1 && money_system.money >= 150)
            {
                current_placeholder = Instantiate(tower_placeholder, cursorPosition, gameObject.transform.rotation);
                current_range = Instantiate(range_placeholder, cursorPosition, gameObject.transform.rotation);
                money_system.money -= 150;
                tower_id = id;
            }
            if (id == 2 && money_system.money >= 100)
            {
                current_placeholder = Instantiate(tower_placeholder, cursorPosition, gameObject.transform.rotation);
                current_range = Instantiate(range_placeholder, cursorPosition, gameObject.transform.rotation);
                money_system.money -= 100;
                tower_id = id;
            }
        }
    }

    void CreateTower()
    {
        Destroy(current_placeholder);
        Destroy(current_range);
        Instantiate(towers[tower_id], new Vector3(cursorPosition.x, cursorPosition.y + gameObject.transform.localScale.y / 2, cursorPosition.z), gameObject.transform.rotation);
    }
}