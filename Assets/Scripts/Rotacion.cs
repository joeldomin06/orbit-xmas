using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidadRotacion = 20f;

    void Update()
    {
        RotacionPlaneta();
    }
    void RotacionPlaneta()
    {
        float rotacion = velocidadRotacion * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotacion);
    }
}
