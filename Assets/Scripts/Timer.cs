using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 0;

    //public Text textTimer;
    public TextMeshProUGUI textTimer;

    void Update()
    {
        timer += Time.deltaTime;
        textTimer.text = "" + timer.ToString("f1");
    }
}
