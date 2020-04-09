using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform player;
    public float velocidade = 0.05f;
    public CharacterController controller;
    // Update is called once per frame
    void Update()
    {
        Vector3 direcaoInimigoParaJogador;
        direcaoInimigoParaJogador = (player.position - transform.position);
        direcaoInimigoParaJogador = direcaoInimigoParaJogador.normalized;
        direcaoInimigoParaJogador = direcaoInimigoParaJogador * velocidade;
        direcaoInimigoParaJogador.z = 0;
        //transform.Translate(direcaoInimigoParaJogador);
        controller.Move(direcaoInimigoParaJogador);
    }    
}
