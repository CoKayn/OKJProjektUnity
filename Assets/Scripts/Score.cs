using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private float combostart = 0;
    private int CurrentCombo = 0;
    private const int TWOTIMESCOMBO = 4;
    private const int THREETIMESCOMBO = 3;
    private const int FOURTIMESCOMBO = 2;
    private const int FIVETIMESCOMBO = 1;
    
    [SerializeField] private Text ScoreText;
    private int ScoreValue;

    // Start is called before the first frame update
    void Start()
    {
        ScoreValue = 0;
        ScoreText.text = "SCORE: " + ScoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentCombo > 0)
        {
            if (combostart == 0)
            {
                combostart = Time.time;
            }
            else
            {
                if (Time.time - combostart > CurrentCombo)
                {
                    CurrentCombo = 0;
                    combostart = 0;
                }
                
            }
        }
        ScoreText.text = $"SCORE: {DisplayCombo()} {ScoreValue}";
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            switch (CurrentCombo)
            {
                default: CurrentCombo = TWOTIMESCOMBO;
                     ScoreValue += 100;
                    break;
                case TWOTIMESCOMBO:
                    ScoreValue += 100 * 2;
                    CurrentCombo = THREETIMESCOMBO;
                    break;
                case THREETIMESCOMBO:
                    ScoreValue += 100 * 3;
                    CurrentCombo = FOURTIMESCOMBO;
                    break;
                case FOURTIMESCOMBO:
                    ScoreValue += 100 * 4;
                    CurrentCombo = FIVETIMESCOMBO;
                    break;
                case FIVETIMESCOMBO:
                    ScoreValue += 100 * 5;
                    break;
            }
            combostart = 0;
            ScoreText.transform.Rotate(0, 0, -20);
            ScoreText.fontSize = 45;
            StartCoroutine(ExecuteAfterTime(0.1f));
        }
    }
    private string DisplayCombo() 
    {
        string combo;
        switch (CurrentCombo)
        {
            default:
                combo = "";
                break;
            case TWOTIMESCOMBO:
                combo = "2X";
                break;
            case THREETIMESCOMBO:
                combo = "3X";         
                break;
            case FOURTIMESCOMBO:
                combo = "4X";         
                break;
            case FIVETIMESCOMBO:
                combo = "5X";           
                break;
        }
        return combo;
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        ScoreText.transform.Rotate(0, 0, 20);
        ScoreText.fontSize = 40;
    }
}
