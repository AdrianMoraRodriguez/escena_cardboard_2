using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ej5 : MonoBehaviour
{
    GameObject[] huevost1;
    GameObject[] huevost2;
    public delegate void Puntuacion(int puntuacion);
    public static event Puntuacion OnPuntuacion;
    public delegate void Colisionado(GameObject objetoColisionado);
    public static event Colisionado OnColisionado;
    public delegate void Recompensa(int puntuacion);
    public static event Recompensa OnRecompensa;
    int puntuacion = 0;
    int prevRecompensa = 0;
    void Start() {
      huevost1 = GameObject.FindGameObjectsWithTag("Eggt1");
      huevost2 = GameObject.FindGameObjectsWithTag("Eggt2");
    }

    void OnCollisionEnter(Collision collision) {
      Debug.Log("Colisionado con: " + collision.gameObject.tag);
      if (collision.gameObject.tag == "Eggt1") {
        puntuacion = puntuacion + 5;
        OnColisionado(collision.gameObject);
        Debug.Log("Puntuación: " + puntuacion);
        OnPuntuacion(puntuacion);
      } else if (collision.gameObject.tag == "Eggt2") {
        puntuacion = puntuacion + 50;
        OnColisionado(collision.gameObject);
        Debug.Log("Puntuación: " + puntuacion);
        OnPuntuacion(puntuacion);
      }
      if (puntuacion / 100 > prevRecompensa) {
        prevRecompensa = puntuacion / 100;
        OnRecompensa(puntuacion);
      }
    }
}
