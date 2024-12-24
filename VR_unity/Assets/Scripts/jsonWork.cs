using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class jsonWork : MonoBehaviour
{
    public Text nm; // текстовое поле
    public Text chns;
    public Slider datchik;
    public Text dat1;
    public string jsonURL; // пр€ма€ ссылка
    public Jsonclass jsData;

    void Start()
    {
        datchik.interactable = false;
        StartCoroutine(getData());
    }
    IEnumerator getData()
    {
        Debug.Log("„иназесинг...");
        var uwr = new UnityWebRequest(jsonURL); // запрашиваем по ссылке наши данные
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json"); // объ€вление пути
        var dh = new DownloadHandlerFile(resultFile); // запись данных из массива в файл
        dh.removeFileOnAbort = true; // при ошибке
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            nm.text = "ќсечка...";
        }
        else
        {
            Debug.Log("‘айл приземлен по пути:" + resultFile);
            jsData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json")); //чтение файла
            nm.text = jsData.Name.ToString();
            chns.text = jsData.Chenases.ToString();
            datchik.value = jsData.TestParam;
            dat1.text = jsData.TestParam.ToString();

            yield return StartCoroutine(getData());
        }
    }
    [System.Serializable]
    public class Jsonclass //объ€вл€ем все переменные
    {
        public string Name;
        public int Chenases;
        public int TestParam;
    }
    
}
