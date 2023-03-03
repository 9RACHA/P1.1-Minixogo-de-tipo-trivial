using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

    private Preguntas preguntas;

    public GameObject pregunta;

    public GameObject respuesta1;
    public GameObject respuesta2;
    public GameObject respuesta3;
    public GameObject respuesta4;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(GetRequest($"https://opentdb.com/api.php?amount={pregunta}"));
    }

    IEnumerator GetRequest(string uri) {
        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result){
                case UnityWebRequest.Result.Success:

                preguntas = JsonUtility.FromJson<Preguntas>(webRequest.downloadHandler.text);
                break;
            }
        }
    }

   
}
