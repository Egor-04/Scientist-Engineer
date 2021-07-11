using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Transform _cameraPosition;

    [Header("Ray Length")]
    [SerializeField] private float _rayLength;

    [Header("UI Inventory")]
    [SerializeField] private Transform _content;

    [Header("Inventory List")]
    public List<Item> InventoryList;

    [Header("All Items")]
    public Item[] AllItems;

    private void Start()
    {
        for (int i = 0; i < _content.childCount; i++)
        {
            InventoryList.Add(new Item());
        }
    }

    private void Update()
    {
        TakeItem();
    }

    private void TakeItem()
    {
        Ray ray = new Ray(_cameraPosition.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            if (hit.collider.GetComponent<Item>())
            {
                Item currentItem = hit.collider.GetComponent<Item>();
                
            }
        }
    }

    private void DefineItem(Item currentItem)
    {
        for (int i = 0; i < AllItems.Length; i++)
        {
            if (currentItem.ID == AllItems[i].ID)
            {

            }
        }
    }

}
