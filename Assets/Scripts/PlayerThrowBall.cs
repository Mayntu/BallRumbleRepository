using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] float maxPower;
    [SerializeField] float maxDistance;
    [SerializeField] float throwAngle;
    [SerializeField] private GameObject player;

    private bool isThrowing = false;
    private float currentPower = 0f;
    private float currentDistance = 0f;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isThrowing = true;
            currentPower = 0f;
            currentDistance = 0f;
        }

        if (Input.GetMouseButton(0) && isThrowing)
        {
            currentPower += Time.deltaTime * maxPower;
            currentPower = Mathf.Clamp(currentPower, 0f, maxPower);
            currentDistance = currentPower * maxDistance / maxPower;

            Quaternion throwRotation = Quaternion.LookRotation(player.transform.forward, player.transform.up);
            transform.rotation = throwRotation * Quaternion.Euler(throwAngle, 0f, 0f);
        }

        if (Input.GetMouseButtonUp(0) && isThrowing)
        {
            isThrowing = false;
            Vector3 throwDirection = transform.forward;
            Vector3 throwForce = throwDirection * currentPower;
            GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
        }
    }
}
