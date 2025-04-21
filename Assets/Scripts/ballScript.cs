using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    private Rigidbody2D rb;
    public scoreManager scoreManager;
    private bool Launched = false;
    private AudioSource audioSource;
    public AudioClip SfxRacket, SfxWalls, SfxLoose;
    private float curSpeed;
    public RaquetteComputer raquetteComputer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); 
        LaunchBall();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !Launched)
        {
            Launched = true;
            LaunchBall();
        }
    }
    void LaunchBall()
    {
        if (scoreManager.EndGame) // Recharge la scene
            SceneManager.LoadScene("Pong");
        curSpeed = speed;
        // tirage au hasard des vitesses initiales
        float vx = Random.Range(0, 2) == 0 ? -1f : 1f;
        float vy = Random.Range(0, 2) == 0 ? -1f : 1f;
        rb.linearVelocity = new Vector2 (vx, vy)*speed; 
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * curSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide Ball with"+ collision.collider.tag);
        switch (collision.collider.tag)
        {            
            case "P1collide":
                HandleScoreAndReinit(2);                
                break;
            case "P2collide":
                HandleScoreAndReinit(1);
                break;
            case "racket":
                audioSource.PlayOneShot(SfxRacket);
                
                break;
            case "walls":
                audioSource.PlayOneShot(SfxWalls);
                curSpeed += 0.5f;
                break;
        }
    }
    void HandleScoreAndReinit(int p)
    {
        audioSource.PlayOneShot(SfxLoose);
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        scoreManager.AddScore(p);
        Launched = false;
        raquetteComputer.speed = Random.Range(10f, 15f);
        raquetteComputer.marginOfError = Random.Range(0.05f, 0.15f);
        raquetteComputer.followDistance = Random.Range(3f, 6f);
    }
}
