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
