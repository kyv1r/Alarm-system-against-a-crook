using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Crook : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = _speed * direction * Time.deltaTime;
        transform.Translate(distance * Vector2.right);        
    }
}
