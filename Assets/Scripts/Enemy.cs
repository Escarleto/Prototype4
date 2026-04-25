using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MoveSpd = 5.0f;
    private Rigidbody RB;
    private GameObject Player;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        Vector3 MoveDir = (Player.transform.position - transform.position).normalized;
        RB.AddForce(MoveDir * MoveSpd);
    }
}
