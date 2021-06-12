using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class falling : MonoBehaviour
{ 
    public List<Rigidbody2D> postacL;
    public List<Rigidbody2D> postacP;

    public float speed = 20f;
    public int kiedySzybciej = 2;
    public int pierwszeSzybciej = 2;
    public float oIleSzybciej = 5f;
    public float poczatkowaSzybkosc = 1f;
    
    private int czyTworzycInstance;
    public Collider2D pod;
    Rigidbody2D instance;
    private int points = 0;
    public Text pointText;
    public Collider2D DrzwiL;
    public Collider2D DrzwiP;
    private int czyWLewo;
    public GameObject gameOverPanel;
    public Text endScore;

    public float countdownTime=5;
    public Text countdownDisplay;

    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        czyTworzycInstance = 0;
    }

    void Update()
    {
        countdownTime -= Time.deltaTime*poczatkowaSzybkosc;
        countdownDisplay.text = countdownTime.ToString();
        int kt;
        if (czyTworzycInstance == 0)
        {
            kt = Random.Range(0, 100);
            if (kt > 50)
            {
                int postac = Random.Range(0, postacL.Count);

                instance = Instantiate(postacL[postac], transform);

                czyTworzycInstance = 1;
                instance.velocity = Vector2.down * speed;
                czyWLewo = 0;
            }
            if (kt <= 50)
            {
                int postac = Random.Range(0, postacP.Count);

                instance = Instantiate(postacP[postac], transform);


                czyTworzycInstance = 1;
                instance.velocity = Vector2.down * speed;
                czyWLewo = 1;
            }
        }

        if (instance.IsTouching(DrzwiL))
        {
            if (czyWLewo == 0) { 
                points += 1;
                countdownTime += 1;
                MoveSpeed();
            }
            else
            {
                koniec();
            }

            Destroy(instance.gameObject,1);
            czyTworzycInstance = 0;
            
        }

        if (instance.IsTouching(DrzwiP))
        {
            if (czyWLewo == 1)
            {
                points += 1;
                countdownTime += 1;
                MoveSpeed();
            }
            else
            {
                koniec();
            }

            Destroy(instance.gameObject, 1);
            czyTworzycInstance = 0;

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
        endScore.text = "Your score:\n"+points.ToString();
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
    private void MoveSpeed()
    {
        if (points == pierwszeSzybciej)
        {
            speed += 1;
            poczatkowaSzybkosc += oIleSzybciej;

            pierwszeSzybciej += kiedySzybciej;
        }
    }
}
