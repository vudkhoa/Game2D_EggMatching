using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Egg")]
    public GameObject eggPrefab;
    public Transform panelParent;
    private float speedFall = 600f;
    public Eggs eggs;
    private int timeInitEgg = 6;
    private int indexInitEgg = -1;
    public Queue<int> q = new Queue<int>();

    [Header("Basket")]
    public GameObject basketPrefab;
    public static int distanceBasket = 150;
    public Basket basket;

    [Header("Matrix")]
    public Matrix matrix;

    [Header("ObjectPool")]
    public EggPool eggPool;
    public EggModelPool eggModelPool = new EggModelPool();

    [Header("Score")]
    public GameObject scorePrefab;
    public _Score score;

    [Header("Live")]
    public GameObject livePrefab;
    public _Live live;
    private int liveMax = 5;

    private int matrixCol = 5;
    private int matrixRow = 11;

    private void Start()
    {
        _UIManager.instance.StartGame();
        this.panelParent = _UIManager.instance.GetTrasformMainMenu();
        InitMatrix();
        InitBasket();
        InitEggs();
        InitEgg();
        InitScore();
        InitLive();
    }

    private void FixedUpdate()
    {
        if (live.Getlive() == 0) return;
        //Debug.Log(eggs.lst.Count);

        while (q.Count > 0)
        {
            int i = q.Dequeue();
            if (i < indexInitEgg)
            {
                indexInitEgg--;
            }
            
            eggModelPool.ReturnObject(eggs.lst[i]);
            eggs.lst.RemoveAt(i);
        }
        if (eggs != null)
        {
            bool checkInitEgg = false;
            int count = -1;
            foreach (Egg egg in eggs.lst)
            {
                count++;
                if (eggs.lst[count].row == 1)
                {
                    q.Enqueue(count);
                }

                int xFirst = egg.row;
                egg.UpdateYPos(Time.deltaTime * speedFall, speedFall);
                int xSecond = egg.row;

                if (xSecond == timeInitEgg && !checkInitEgg)
                {
                    if (indexInitEgg == -1)
                    {
                        checkInitEgg = true;
                        indexInitEgg = count;
                    }
                    else
                    {
                        //Debug.Log("SinhTrung" + " " + indexInitEgg + " " + eggs.lst[indexInitEgg].row + " " + timeInitEgg);
                        if (eggs.lst[indexInitEgg].row != timeInitEgg)
                        {
                            checkInitEgg = true;
                            indexInitEgg = count;
                        }
                    }
                }

                //Debug.Log(xFirst + " " + xSecond);
                int y = egg.col;
                if (xFirst != xSecond && xSecond >= 1 && y >= 0 && xSecond <= 10 && y <= 4)
                {
                    matrix.SetValue(xSecond, y, 1);
                    if (xSecond == 1)
                    {
                        //Debug.Log(y);
                        if (!CheckBasket(y))
                        {
                            Debug.Log("Roi");
                            live.DecreaseLive();
                            if (live.Getlive() == 0)
                            {
                                _UIManager.instance.GameOver();
                                //Debug.Log("GameOver");
                                //uiManager.ShowGameOver("GameOver", score.GetScore(), 1000);  
                            }
                        }
                        else
                        {
                            Debug.Log("HungDuoc");
                            score.AddScore(10);
                        }

                        eggPool.ReturnObject(egg.eggView.gameObject);
                    }
                    //Debug.Log(xSecond + " " + y + " " + matrix.GetValue(xSecond, y) + egg.yPos);
                }
            }
            if (checkInitEgg)
            {
                //Debug.Log("Sinh");
                InitEgg();
            }
        }
    }

    private void InitEggs()
    {
        eggs = new Eggs();
    }

    private void Update()
    {
        if (live.Getlive() == 0) return;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (basket.col > 0)
            {
                matrix.SetValue(0, basket.col, 0);
                basket.SetCol(basket.col - 1);
                MoveBasket(basket.col);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (basket.col < 4)
            {
                matrix.SetValue(0, basket.col, 0);
                basket.SetCol(basket.col + 1);
                MoveBasket(basket.col);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _UIManager.instance.PauseGame(this.score.GetScore());
        }
    }

    private void InitEgg()
    {
        int col = Random.Range(0, 5);
        Vector2 vc2 = GetPositionEgg(col);

        GameObject eggGO = eggPool.GetObject();
        EggView ev = eggGO.GetComponent<EggView>();

        ev.transform.SetParent(panelParent);
        RectTransform rect = ev.GetComponent<RectTransform>();
        rect.localScale = Vector3.one;
        rect.anchoredPosition = vc2;

        Egg egg = eggModelPool.GetEggModel();
        egg.InitEgg(col, ev, speedFall);
        eggs.AddEgg(egg);
    }

    private Vector2 GetPositionEgg(int col)
    {
        return new Vector2(-300 + col * 150, 600);
    }

    private void InitBasket()
    {
        int col = 0;
        Vector2 vc2 = GetPositionBasket(col);
        GameObject basketGO = Instantiate(basketPrefab, panelParent);

        RectTransform rect = basketGO.GetComponent<RectTransform>();
        rect.anchoredPosition = vc2;

        basket = new Basket();
        basket.InitBasket(col, basketGO.GetComponent<BasketView>());
        //basket.InitBasket(col);
        matrix.SetValue(0, col, 2);
        //matrix.PrintMatrix();
    }

    private void MoveBasket(int col)
    {
        Vector2 vc2 = GetPositionBasket(col);
        basket.basketView.rect.anchoredPosition = vc2;
        matrix.SetValue(0, col, 2);
        for (int i = 0; i < 4; i++)
        {
            if (matrix.GetValue(0, i) == 2)
            {
                Debug.Log("Basket" + " " + i);
                break;
            }
        }
        //matrix.PrintMatrix(); 
    }

    private Vector2 GetPositionBasket(int col)
    {
        //Debug.Log(-300 + col * distanceBasket);
        return new Vector2(-300 + col * distanceBasket, -600);
    }

    private bool CheckBasket(int col)
    {
        if (matrix.GetValue(0, col) == 0)
        {
            return false;
        }
        return true;
    }

    private void InitMatrix()
    {
        matrix = new Matrix(matrixRow, matrixCol);
        //PrintMatrix();
    }

    private void InitScore()
    {
        scorePrefab = Instantiate(scorePrefab, panelParent);
        score = new _Score();
        _ScoreView scoreView = scorePrefab.GetComponent<_ScoreView>();
        score.InitScore(0, scoreView);
    }

    private void InitLive()
    {
        livePrefab = Instantiate(livePrefab, panelParent);
        live = new _Live();
        _LiveView liveView = livePrefab.GetComponent<_LiveView>();
        live.InitLive(liveMax, liveView);
    }

    //public void PrintMatrix()
    //{
    //    matrix.PrintMatrix();
    //}
}
