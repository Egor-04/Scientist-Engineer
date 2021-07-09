using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public bool CanZoom = true;
    public bool CanMove = true;
    public bool CanJump = true;
    public bool CanHold = true;
    public bool CanLook = true;

    public static PlayerStates PlayerStatesScript;

    private void Start()
    {
        PlayerStatesScript = GetComponent<PlayerStates>();
    }
}
