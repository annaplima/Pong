using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovePaddle : MonoBehaviour
{
    public float speed = 5.0f; // Velocidade de movimento do "paddle"
    public float boundY = 2.25f; // Limite superior e inferior para o "paddle"

    private Rigidbody2D rb2d;
    private GameObject ball; // Referência ao objeto da bola

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // Encontre o objeto da bola com base na tag "Ball"
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null) // Verifica se a referência da bola não é nula
        {
            // Calcula a direção da bola em relação ao "paddle"
            Vector2 directionToBall = ball.transform.position - transform.position;

            // Normaliza a direção para garantir que a velocidade seja constante
            directionToBall.Normalize();

            // Move o "paddle" na direção vertical da bola
            rb2d.velocity = new Vector2(0, directionToBall.y * speed);

            // Limita a posição do "paddle" para evitar que ele saia dos limites
            Vector3 currentPosition = transform.position;
            currentPosition.y = Mathf.Clamp(currentPosition.y, -boundY, boundY);
            transform.position = currentPosition;
        }
    }
}
