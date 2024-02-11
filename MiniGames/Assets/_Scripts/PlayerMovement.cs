using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, Controls.IGameControlsActions
{
    Controls controls;

    private void Awake()
    {
        controls = new Controls();
        controls.GameControls.SetCallbacks(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.GameControls.Enable();
    }

    private void OnDestroy()
    {
        controls.GameControls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerLeft(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerRight(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
