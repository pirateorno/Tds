using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceScript : MonoBehaviour
{
    [Header("Mouse")]
    public Vector3 cursorPosition;

    [Header("Classic tower")]
    public Button classic_tower_button;
    public GameObject classic_tower;
    public GameObject classic_tower_placeholder;
    [Header("Other")]
    [SerializeField] private GameObject current_placeholder;
    [SerializeField] private GameObject current_range;
    public GameObject range_placeholder;
    public bool canPlace;
    public MoneySystem money_system;

    void Start()
    {
        classic_tower_button.onClick.AddListener(PlaceholderClassicTower);
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
            current_placeholder.transform.position = new Vector3(cursorPosition.x, cursorPosition.y + gameObject.transform.localScale.y /2, cursorPosition.z);
            current_range.transform.position = new Vector3(cursorPosition.x, cursorPosition.y, cursorPosition.z);
            current_range.transform.localScale = new Vector3(10, 1,10);
        }

        if (Input.GetButtonDown("Fire1") && current_placeholder != null && canPlace == true)
        {
            CreateTower();
        }
    }


    void PlaceholderClassicTower()
    {
        if (current_placeholder == null && money_system.money >= 1)
        {
            current_placeholder = Instantiate(classic_tower_placeholder, cursorPosition, gameObject.transform.rotation);
            current_range = Instantiate(range_placeholder, cursorPosition, gameObject.transform.rotation);
            money_system.money -= 1;
        }
    }

    void CreateTower()
    {
        Destroy(current_placeholder);
        Destroy(current_range);
        Instantiate(classic_tower, new Vector3(cursorPosition.x, cursorPosition.y + gameObject.transform.localScale.y / 2, cursorPosition.z), gameObject.transform.rotation);
    }
}