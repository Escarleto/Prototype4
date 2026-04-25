using UnityEngine;

public class RotateCam : MonoBehaviour
{
    [SerializeField] private float RotationSpd;

    // Update is called once per frame
    void Update()
    {
        float RotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, RotationInput * RotationSpd * Time.deltaTime); 
    }
}
