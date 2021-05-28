using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class falling : MonoBehaviour
{
    public Rigidbody2D postacL1;
    public Rigidbody2D postacL2;

    public Rigidbody2D postacP1;
    public Rigidbody2D postacP2;
    public Rigidbody2D postacP3;

    private float speed = 10f;
    
    private int czy;
    public Collider2D pod;
    Rigidbody2D instance;
    private int points = 0;
    public Text pointText;
    public Collider2D DrzwiL;
    public Collider2D DrzwiP;
    private int takczynie;
    public GameObject gameOverPanel;
    public Text endScore;

    private float countdownTime=5;
    public Text countdownDisplay;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        czy = 0;
    }

    void Update()
    {
        countdownTime -= Time.deltaTime*(float)1.20;
        countdownDisplay.text = countdownTime.ToString();
        int kt;
        if (czy == 0)
        {
            kt = Random.Range(0, 100);
            if (kt > 50)
            {
                
                if (kt > 70)
                {
                    instance = Instantiate(postacL2, transform);
                }
                else
                {
                    instance = Instantiate(postacL1, transform);
                }
                czy = 1;
                instance.velocity = Vector2.down * speed;
                takczynie = 0;
            }
            if (kt <= 50)
            {
                if (kt > 35)
                {
                    instance = Instantiate(postacP2, transform);
                }
                else if(kt>15 && kt < 35)
                {
                    instance = Instantiate(postacP3, transform);

                }
                else
                {
                    instance = Instantiate(postacP1, transform);

                }
                czy = 1;
                instance.velocity = Vector2.down * speed;
                takczynie = 1;
            }
        }

        if (instance.IsTouching(DrzwiL))
        {
            if (takczynie == 0) { 
                points += 1;
                countdownTime += 1;
            }
            else
            {
                koniec();
            }

            Destroy(instance.gameObject,1);
            czy = 0;
            
        }

        if (instance.IsTouching(DrzwiP))
        {
            if (takczynie == 1)
            {
                points += 1;
                countdownTime += 1;
            }
            else
            {
                koniec();
            }

            Destroy(instance.gameObject, 1);
            czy = 0;

        }
        if(countdownTime < 0)
        {
            countdownDisplay.text = "0";
            koniec();
        }
        pointText.text = "score: " + points.ToString();
    }

    private void koniec()
    {
        endScore.text = "Your score:"+points.ToString();
        gameOverPanel.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    public void MoveLeft()
    {
        if (instance.IsTouching(pod))
        {
            instance.velocity = Vector2.left * speed;
            
        }
    }
    public void MoveRight()
    {
        if (instance.IsTouching(pod))
        {
            instance.velocity = Vector2.right * speed;
            
        }
    }
}
