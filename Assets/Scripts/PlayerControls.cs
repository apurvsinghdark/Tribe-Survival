using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class PlayerControls : MonoBehaviour
{
    private void Update() {
        
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        PlayerInteraction();
    }

    private void PlayerInteraction()
    {
        
    }
}
