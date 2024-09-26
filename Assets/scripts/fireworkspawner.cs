using UnityEditor;
using UnityEngine;

public class ParticleAtMouseClick : MonoBehaviour
{
    // Drag your Particle System prefab here in the Inspector
    public GameObject particlePrefab;
    public audiomanager audiomanager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            audiomanager.playSFX(audiomanager.fireworks);
            SpawnParticleAtMousePosition();
        }
    }

    void SpawnParticleAtMousePosition()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert screen space to world space
        mousePos.z = Camera.main.nearClipPlane + 5.0f; // Set the distance from the camera
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Instantiate the particle system at the mouse click position
        Instantiate(particlePrefab, worldPos, Quaternion.identity);
        

    }
}
