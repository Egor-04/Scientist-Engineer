using UnityEngine;
using System;

public class PanelSwitcher : MonoBehaviour
{
    [Header("Button ID")]
    [SerializeField] private int _buttonID;

    [Header("Panel for Activation")]
    [SerializeField] private GameObject _currentPanel;

    [Header("All Panels")]
    [SerializeField] private UIPanel[] _allUIPanels;

    [Serializable]
    public class UIPanel
    {
        public int PanelID;
        public GameObject Panel;
    }

    public void Switch()
    {
        if (!_currentPanel.activeSelf)
        {
            _currentPanel.SetActive(true);

            for (int i = 0; i < _allUIPanels.Length; i++)
            {
                if (_allUIPanels[i].PanelID != _buttonID)
                {
                    _allUIPanels[i].Panel.SetActive(false);
                }
            }
        }
    }
}
