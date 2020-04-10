using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    Vector3 direcaoParaMovimentar;
    public Transform player;
    public float velocidade = 0.5f;
    public int capacidadePerfurativa = 1;
    public int capacidadeReflexiva = 3;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        player = GameObject.FindWithTag("Player").transform;

        direcaoParaMovimentar = (mousePosition - player.position).normalized * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direcaoParaMovimentar);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            bool morreuOuNao = other.GetComponent<Inimigo>().DecreaseLife(damage);
            if (morreuOuNao == true)
                Destroy(other.gameObject);

            capacidadePerfurativa = capacidadePerfurativa - 1;//capacidadePerfurativa--;
            if (capacidadePerfurativa < 0)
                Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            capacidadeReflexiva = capacidadeReflexiva - 1;
            direcaoParaMovimentar = -1 * direcaoParaMovimentar;
            if (capacidadeReflexiva < 0)
                Destroy(this.gameObject);
        }
    }

}
