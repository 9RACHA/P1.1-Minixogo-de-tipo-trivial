using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

    public Preguntas preguntas;

    public int numPregunta;

    //public GameObject pregunta;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(GetRequest("https://opentdb.com/api.php?amount=5"));
    }

    IEnumerator GetRequest(string uri) {
        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result){
                case UnityWebRequest.Result.Success:
                break;
            }

                preguntas = JsonUtility.FromJson<Preguntas>(webRequest.downloadHandler.text);
            }
            
        }
        public Preguntas getJSON(){
            return preguntas;
            
        }
    }

   

