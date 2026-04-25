using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject FocalPoint;
    [SerializeField] private float MoveSpd = 5.0f;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    private void FixedUpdate()
    {
        float MoveInput = Input.GetAxis("Vertical");
        RB.AddForce(FocalPoint.transform.forward * MoveSpd * MoveInput);
    }
}
