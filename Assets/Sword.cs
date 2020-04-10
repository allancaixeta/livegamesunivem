using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damageSword = 1;
    public float cooldownDamage = 0.5f;
    float cooldownCounter = -1;
    public Transform arma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCounter -= Time.deltaTime;
        transform.position = arma.position;
        transform.rotation = arma.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if(cooldownCounter< 0)
            {
                bool morreuOuNao = other.GetComponent<Inimigo>().DecreaseLife(damageSword);
                if (morreuOuNao == true)
                    Destroy(other.gameObject);
                cooldownCounter = cooldownDamage;
            }            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }
}
