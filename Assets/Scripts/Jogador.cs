using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public float velocidade = 0.1f;
    public GameObject projetilShotgunPrefab ,projetilMachineGunPrefab, swordGameObject;
    public CharacterController controller;
    public Animator animator;
    public Text lifeText;
    bool movimentandoNesseFrame;
    int life = 5;
    bool morreu = false;
    float contadorDeTempoDeMorte = 2;
    public float tempoDeInvulnerabilidade = 0.5f;
    float contadorDeInvulnerabilidade = -1;
    int armaEquipadaAgora = 1;
    public SpriteRenderer visualArmas;
    float cooldownArmaAtual = -1;
    //arma 1
    public Sprite spriteShotgun;
    public float cooldownShotgun = 3.0f;

    //arma 2
    public Sprite spriteMachinegun;
    public float cooldownMachinegun = 0.2f;

    //arma 3
    public Sprite spriteSword;



    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(morreu == true)
        {
            contadorDeTempoDeMorte -= Time.deltaTime;
            life = life - 1;
            lifeText.text = life.ToString();
            if (contadorDeTempoDeMorte < 0)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            contadorDeInvulnerabilidade -= Time.deltaTime;

            movimentandoNesseFrame = false;

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                armaEquipadaAgora = 1;
                visualArmas.sprite = spriteShotgun;
                swordGameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                armaEquipadaAgora = 2;
                visualArmas.sprite = spriteMachinegun;
                swordGameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                armaEquipadaAgora = 3;
                visualArmas.sprite = null;
                swordGameObject.SetActive(true);
            }

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

            cooldownArmaAtual -= Time.deltaTime;
            switch(armaEquipadaAgora)
            {
                case 1://shotgun                    
                    if(cooldownArmaAtual < 0)
                    {
                        if (Input.GetMouseButtonDown(0))//0 é o botão esquerdo do mouse
                        {
                            cooldownArmaAtual = cooldownShotgun;
                            Instantiate(projetilShotgunPrefab, transform.position, transform.rotation);
                        }
                    }                   
                    break;
                case 2://machinegun                    
                    if (cooldownArmaAtual < 0)
                    {
                        if (Input.GetMouseButton(0))//0 é o botão esquerdo do mouse
                        {
                            cooldownArmaAtual = cooldownMachinegun;
                            Instantiate(projetilMachineGunPrefab, transform.position, transform.rotation);
                        }
                    }
                    break;
                case 3:
                    //aqui
                    break;
                default:
                    break;
            }                  
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {            
            ComportamentoQuandoEncostaNoInimigo();                                 
        }
        if(other.gameObject.tag == "Wall")
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    void ComportamentoQuandoEncostaNoInimigo()
    {
        if (contadorDeInvulnerabilidade < 0)
        {
            life = life - 1;
            lifeText.text = life.ToString();
            contadorDeInvulnerabilidade = tempoDeInvulnerabilidade;
            if (life <= 0)
            {
                animator.Play("death");
                morreu = true;
            }
        }
    }
}
