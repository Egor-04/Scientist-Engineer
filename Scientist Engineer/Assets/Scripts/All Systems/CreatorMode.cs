using UnityEngine;

public class CreatorMode : MonoBehaviour
{
    [Header("Items Panel")]
    [SerializeField] private GameObject _itemsPanel;

    [Header("Buttons")]
    [SerializeField] private KeyCode _buttonOpenPanelItems = KeyCode.I;

    private void Start()
    {

    }

    private void Update()
    {
        OpenItemsPanel();
    }

    private void OpenItemsPanel()
    {
        if (Input.GetKeyDown(_buttonOpenPanelItems))
        {
            if (_itemsPanel.activeSelf)
            {
                _itemsPanel.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                PlayerStates.PlayerStatesScript.CanLook = true;
            }
            else
            {
                _itemsPanel.SetActive(true);
                Time.timeScale = 0f; 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PlayerStates.PlayerStatesScript.CanLook = false;
            }
        }
    }
}
