using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class jsonWork : MonoBehaviour
{
    public Text nm; // ��������� ����
    public Text chns;
    public Slider datchik;
    public Text dat1;
    public string jsonURL; // ������ ������
    public Jsonclass jsData;

    void Start()
    {
        datchik.interactable = false;
        StartCoroutine(getData());
    }
    IEnumerator getData()
    {
        Debug.Log("����������...");
        var uwr = new UnityWebRequest(jsonURL); // ����������� �� ������ ���� ������
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json"); // ���������� ����
        var dh = new DownloadHandlerFile(resultFile); // ������ ������ �� ������� � ����
        dh.removeFileOnAbort = true; // ��� ������
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            nm.text = "������...";
        }
        else
        {
            Debug.Log("���� ��������� �� ����:" + resultFile);
            jsData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json")); //������ �����
            nm.text = jsData.Name.ToString();
            chns.text = jsData.Chenases.ToString();
            datchik.value = jsData.TestParam;
            dat1.text = jsData.TestParam.ToString();

            yield return StartCoroutine(getData());
        }
    }
    [System.Serializable]
    public class Jsonclass //��������� ��� ����������
    {
        public string Name;
        public int Chenases;
        public int TestParam;
    }
    
}
