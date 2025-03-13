using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laser;
    [SerializeField] RectTransform crosshair;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible=false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (GameObject laser in laser)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;

        }
    }
    void MoveCrosshair()
    {
        crosshair.position=Input.mousePosition;
    }

}
