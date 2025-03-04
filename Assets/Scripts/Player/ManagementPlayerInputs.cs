using UnityEngine;

public class ManagementPlayerInputs : MonoBehaviour
{
    public PlayerActions playerActions;
    public PlayerInputs playerInputs;

    void Awake()
    {
        playerActions = new PlayerActions();
        playerInputs = new PlayerInputs();
    }
    public void OnEnable()
    {
        playerActions.Enable();
    }
    void Update()
    {
        playerInputs.movement = playerActions.CharacterActions.Move.ReadValue<Vector2>();
    }
    public class PlayerInputs{
        public Vector2 movement;
    }
}
