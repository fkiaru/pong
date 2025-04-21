using System;
using UnityEngine;

public class RaquettePlayer : MonoBehaviour
{
    [Header("Paramètre du joueur")]
    [Tooltip("vitesse de la raquette"),Range(0f,30f),SerializeField]
    private float speed = 20f;
    private float BornesMax = 4.24f;

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.up * v * speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, -BornesMax, +BornesMax));

        

    }
}
