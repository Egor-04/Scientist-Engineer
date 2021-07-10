using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchCell : MonoBehaviour, IPointerDownHandler
{
    [Header("Cell ID")]
    public int CellID;

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
