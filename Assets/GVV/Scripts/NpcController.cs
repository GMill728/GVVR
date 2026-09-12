using UnityEngine;
using UnityEngine.InputSystem;

public class NpcController : MonoBehaviour
{
    public float turnSpeed = 120;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float turnDirection = 0;

        if (Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            turnDirection = -1;
        }
        else if (Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            turnDirection = 1;
        }

        transform.Rotate(Vector3.up, turnDirection * turnSpeed * Time.deltaTime);

    }
}
