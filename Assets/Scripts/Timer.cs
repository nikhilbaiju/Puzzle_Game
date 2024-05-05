using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 20f;

    // public GameObject gameoverPanel;


    TextMeshProUGUI countTimer;
    Color color = Color.red;


    void Start()
    {
        countTimer = this.GetComponent<TextMeshProUGUI>();

        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;


        countTimer.text = currentTime.ToString("0");

        if (currentTime <= 0f)
        {
            countTimer.text = "0";
            Debug.Log("Timeup");
            Time.timeScale = 0f;
            GameEvent.OnEvent.Active_GameOver();

        }
    }
}
