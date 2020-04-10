using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionaArma : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        float angulo;
        Vector3 direction = (mousePosition - transform.position).normalized;

        angulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0,0, angulo);

    }
}
