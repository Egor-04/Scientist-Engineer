using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public bool CanZoom = true;
    public bool CanMove = true;
    public bool CanJump = true;

    public static PlayerStates PlayerStatesScript;

    private void Start()
    {
        PlayerStatesScript = GetComponent<PlayerStates>();
    }
}
