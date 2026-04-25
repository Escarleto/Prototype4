using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject FocalPoint;
    private bool HasPowerup = false;
    private float PowerupForce = 15.0f;
    [SerializeField] private float MoveSpd = 5.0f;
    [SerializeField] private GameObject PowerupIndicator;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
        if (PowerupIndicator != null) PowerupIndicator.SetActive(false);
    }

    private void FixedUpdate()
    {
        float MoveInput = Input.GetAxis("Vertical");
        RB.AddForce(FocalPoint.transform.forward * MoveSpd * MoveInput);

        PowerupIndicator.transform.position = transform.position + Vector3.down * 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            HasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupDuration());
            PowerupIndicator.SetActive(true);
        }
    }

    private IEnumerator PowerupDuration()
    {
        yield return new WaitForSeconds(7f);
        HasPowerup = false;
        PowerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && HasPowerup)
        {
            Rigidbody EnemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayFromPlayer = collision.gameObject.transform.position - transform.position;

            EnemyRB.AddForce(AwayFromPlayer * PowerupForce, ForceMode.Impulse);
        }
    }
}
