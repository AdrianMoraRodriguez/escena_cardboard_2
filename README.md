# Práctica 6: Escena cardboard 2
## Scripts
1. Camera Rotation: Este Script se ha utilizado para probar el correcto funcionamiento de la práctica desde Unity. Obtiene los axis horizontales y verticales y realiza rotaciones pertinentes:
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Rotation : MonoBehaviour
{
     public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update() {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");
      float rotationX = vertical * rotationSpeed * Time.deltaTime;
      float rotationY = horizontal * rotationSpeed * Time.deltaTime;
      transform.Rotate(Vector3.right, -rotationX);
      transform.Rotate(Vector3.up, rotationY, Space.World);
    }
}
```
2. Controlador Objeto: Se ha utilizado el script de ObjectController de la escena de ejemplo del paquete cardboard. Se ha modificado la función OnPointerEnter para añadir los nuevos requisitos (movimiento final de los objetos). Además, se ha creado una función teleportar que teletransporta los objetos a un nuevo punto del plano cuando se les mire:
```cs
 void Teleportar() {
    Vector3 planeScale = plane.transform.localScale;
    float planeWidth = 10 * planeScale.x;
    float planeHeight = 10 * planeScale.z;
    Vector3 planePosition = plane.transform.position;
    float x = Random.Range(planePosition.x - planeWidth / 2, planePosition.x + planeWidth / 2);
    float z = Random.Range(planePosition.z - planeHeight / 2, planePosition.z + planeHeight / 2);
    this.GetComponent<Rigidbody>().MovePosition(new Vector3(x, 0, z));
  }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
        Teleportar();
        puntuacion = puntuacion + 50;
        OnPuntuacion(puntuacion);
        if (puntuacion == 100) {
            OnFinal();
        }
    }
```
3. Final: AL principio se suscribe al evento OnFinal que lanza el controlador de objeto cuando se obtenga una puntuación igual a 100. Este evento utiliza una corrutina para que se ejecute una vez por frame. El script obtiene la posición del cilindro y hace que ele objeto se mueva a dicha posición:
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
      Controlador_Objeto.OnFinal += Final;
    }

    // Update is called once per frame
    void Final() {
      StartCoroutine(Moving());
    }

    IEnumerator Moving() {
      GameObject cylinder = GameObject.Find("Cylinder");
      Vector3 pos = cylinder.transform.position;
      while (Vector3.Distance(transform.position, pos) > 0.1f) {
        transform.position = Vector3.Lerp(transform.position, pos, 0.1f * Time.deltaTime);
        yield return null;
      }
    }
}
```
