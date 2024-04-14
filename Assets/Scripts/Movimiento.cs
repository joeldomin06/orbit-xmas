using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento en unidades por segundo
    public float distanciaDeMovimiento = 1.5f; // Distancia de movimiento en unidades
    public float duracionMovimiento = 0.1f; // Duración del movimiento en segundos

    private float limitUp; // Límite de altura de subida
    private float limitDown; // Límite de altura de bajada

    private bool enMovimiento = false; // Bandera para verificar si el objeto está en movimiento
    private Vector3 posicionInicial; // Posición inicial del objeto
    private Vector3 posicionFinal; // Posición final del objeto

    void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = posicionInicial;
        limitUp = posicionInicial.y + distanciaDeMovimiento*3;
        limitDown = posicionInicial.y - distanciaDeMovimiento;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoverArriba();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoverAbajo();
        }

        // Si el objeto está en movimiento, realizar la interpolación lineal
        if (enMovimiento)
        {
            float tiempoTranscurrido = (Time.time - tiempoInicioMovimiento) / duracionMovimiento;
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, tiempoTranscurrido);

            // Verificar si se completó el movimiento
            if (tiempoTranscurrido >= 1f)
            {
                enMovimiento = false;
            }
        }
    }

    private float tiempoInicioMovimiento; // Tiempo en que comenzó el movimiento

    void MoverArriba()
    {
        if (!enMovimiento)
        {
            posicionInicial = transform.position;
            if (posicionInicial.y + distanciaDeMovimiento <= limitUp){
                enMovimiento = true;
                posicionFinal = posicionInicial + Vector3.up * distanciaDeMovimiento;
                tiempoInicioMovimiento = Time.time;
            }
        }
    }

    void MoverAbajo()
    {
        if (!enMovimiento)
        {
            posicionInicial = transform.position;
            if (posicionInicial.y - distanciaDeMovimiento >= limitDown){
                enMovimiento = true;
                posicionFinal = posicionInicial - Vector3.up * distanciaDeMovimiento;
                tiempoInicioMovimiento = Time.time;
            }
        }
    }
}
