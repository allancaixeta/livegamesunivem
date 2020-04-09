using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade = 0.1f;
    public GameObject projetilPrefab;
    public CharacterController controller;
    public Animator animator;
    bool movimentandoNesseFrame;
    int life = 5;
    bool morreu = false;
    float contadorDeTempoDeMorte = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(morreu == true)
        {
            contadorDeTempoDeMorte -= Time.deltaTime;
            if(contadorDeTempoDeMorte < 0)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            movimentandoNesseFrame = false;

            if (Input.GetKey(KeyCode.D))
            {
                //transform.Translate(velocidade, 0, 0);
                controller.Move(new Vector3(velocidade, 0, 0));
                movimentandoNesseFrame = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                // transform.Translate(-velocidade, 0, 0);
                controller.Move(new Vector3(-velocidade, 0, 0));
                movimentandoNesseFrame = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                //transform.Translate(0, velocidade, 0);
                controller.Move(new Vector3(0, velocidade, 0));
                movimentandoNesseFrame = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                //transform.Translate(0, -velocidade, 0);
                controller.Move(new Vector3(0, -velocidade, 0));
                movimentandoNesseFrame = true;
            }

            if (movimentandoNesseFrame == true)
            {
                animator.Play("walk");
            }
            else
            {
                animator.Play("idle");
            }



            if (Input.GetKeyDown(KeyCode.Space))
            {
                //programe aqui oque fazer quando apertar espaço

            }

            if (Input.GetMouseButtonDown(0))//0 é o botão esquerdo do mouse
            {
                Instantiate(projetilPrefab, transform.position, transform.rotation);
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            life = life - 1;
            if(life <= 0)
            {
                animator.Play("death");
                morreu = true;
            }               
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
