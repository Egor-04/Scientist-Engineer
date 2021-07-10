using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCellID : MonoBehaviour
{
    [Header("Content")]
    [SerializeField] private Transform _cellContent;

    [Header("Cells for Touch")]
    [SerializeField] private List<TouchCell> _touchCellList;

    private void Start()
    {
        _cellContent = GetComponent<Transform>();

        for (int i = 0; i < _cellContent.childCount; i++)
        {
            _touchCellList.Add(new TouchCell());

            TouchCell touchCell = _cellContent.GetChild(i).GetComponent<TouchCell>();
            _touchCellList[i] = touchCell;
            touchCell.CellID = i;
        }
    }
}
