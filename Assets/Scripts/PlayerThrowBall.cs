using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float maxPower = 10f;  // Максимальная сила броска
    public float maxDistance = 10f;  // Максимальное расстояние полета
    public float throwAngle = 45f;  // Угол броска

    private bool isThrowing = false;
    private float currentPower = 0f;
    private float currentDistance = 0f;

    [SerializeField] private GameObject player;

    private void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // При нажатии левой кнопки мыши
        {
            isThrowing = true;
            currentPower = 0f;
            currentDistance = 0f;
        }

        if (Input.GetMouseButton(0) && isThrowing)  // При удержании левой кнопки мыши
        {
            currentPower += Time.deltaTime * maxPower;
            currentPower = Mathf.Clamp(currentPower, 0f, maxPower);
            currentDistance = currentPower * maxDistance / maxPower;

            // Поворот объекта в направлении полета, учитывая направление игрока
            Quaternion throwRotation = Quaternion.LookRotation(player.transform.forward, player.transform.up);
            transform.rotation = throwRotation * Quaternion.Euler(throwAngle, 0f, 0f);
        }

        if (Input.GetMouseButtonUp(0) && isThrowing)  // При отпускании левой кнопки мыши
        {
            isThrowing = false;
            // Применение силы броска к объекту
            Vector3 throwDirection = transform.forward;
            Vector3 throwForce = throwDirection * currentPower;
            GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
        }
    }
}
