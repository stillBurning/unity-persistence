using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoresManager : MonoBehaviour
{
    public GameObject prefab;
    public float yOffset;
    public float yStep;

    private GameObject highscoreTable;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Highscores: Start");
        highscoreTable = GameObject.Find("HighscoreTable");

        foreach (var hs in PlayerSettings.Instance.Highscores)
        {
            var hsStr = $"{hs.Name} : {hs.Score}";
            var t = Instantiate(
                prefab, 
                highscoreTable.transform);

            var tmeshPro = t.GetComponent<TextMeshProUGUI>();
            tmeshPro.text = hsStr;

            //t.GetComponent<TextMeshPro>().text = hsStr;
            //t.transform.SetParent(highscoreTable.transform);
        }
    }

    private void Awake()
    {
        Debug.Log("Highscores: Awake");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
