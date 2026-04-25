using UnityEngine;

public class RotateCam : MonoBehaviour
{
    [SerializeField] private float RotationSpd;

    private void Update()
    {
        float RotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, RotationInput * RotationSpd * Time.deltaTime); 
    }
}
