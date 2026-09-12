using UnityEngine;
using TMPro;

public class EnemyVision : MonoBehaviour
{
    public Transform player;
    public float visionRange = 10f;
    public float visionAngle = 90f;
    public LayerMask obstructionLayer;

    public TextMeshPro textMeshPro;

    private bool playerDetected = false;

    void Update()
    {
        if (CanSeePlayer())
        {   
            playerDetected = true;
            Debug.Log("Player detected! :)");
            textMeshPro.SetText("Detected!");
        }
        else
        {
            Debug.Log("Player not detected :(");
            textMeshPro.SetText("Hidden");
            playerDetected = false;
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        // Too far away
        if (directionToPlayer.magnitude > visionRange)
            return false;

        // Outside vision angle
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        if (angle > visionAngle / 2f)
            return false;

        // Check for walls/obstacles
        if (Physics.Raycast(
            transform.position,
            directionToPlayer.normalized,
            out RaycastHit hit,
            visionRange,
            obstructionLayer))
        {
            // Something is blocking the enemy's view
            return false;
        }

        // Nothing is blocking the view
        return true;
    }

    public bool canSeePlayer()
    {
        return playerDetected;
    }

}
