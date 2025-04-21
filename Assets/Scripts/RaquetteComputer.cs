//using UnityEditor.AnimatedValues;
using UnityEngine;

public class RaquetteComputer : MonoBehaviour
{
    public Transform ball;
    [SerializeField]
    public  float speed = 5f, marginOfError = 0.1f, followDistance = 2f;
    private float BornesMax = 4.24f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(ball.position.x - transform.position.x) < followDistance)
        {
            if (Random.value > marginOfError)
            {
                Vector3 targetPosition = new Vector3(transform.position.x,
                                                    ball.position.y,
                                                    transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position,
                                                targetPosition,
                                                speed * Time.deltaTime);
                transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, -BornesMax, +BornesMax));
            }
        }
    }
}
