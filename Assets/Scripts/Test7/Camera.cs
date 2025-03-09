using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform[] targets; 
    [SerializeField] private float transitionSpeed = 2f; 

    private int currentTargetIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }

        if (targets.Length > 0)
        {
            transform.position = Vector3.Lerp(transform.position, targets[currentTargetIndex].position + Vector3.back, transitionSpeed * Time.deltaTime);
        }
    }
}