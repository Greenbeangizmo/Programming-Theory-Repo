using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static int waterLevel = 100;
    public static int WaterLevel //ENCAPSULATION
    { get => waterLevel; set { if (value >= 0) waterLevel = value; } }

    private static int potatoSeeds = 5;
    public static int PotatoSeeds //ENCAPSULATION
    { get => potatoSeeds; set { if (value >= 0) potatoSeeds = value; } }

    private static int totatoSeeds = 5;
    public static int TomatoSeeds //ENCAPSULATION
    { get => totatoSeeds; set { if (value >= 0) totatoSeeds = value; } }

    private static int cornSeeds = 5;
    public static int CornSeeds //ENCAPSULATION
    { get => cornSeeds; set { if (value >= 0) cornSeeds = value; } }

    private static int carrotSeeds = 5;
    public static int CarrotSeeds //ENCAPSULATION
    { get => carrotSeeds; set { if (value >= 0) carrotSeeds = value; } }

    private static int watermelonSeeds = 5;
    public static int WatermelonSeeds //ENCAPSULATION
    { get => watermelonSeeds; set { if (value >= 0) watermelonSeeds = value; } }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //InitializeInventory(); //ABSTRACTION
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    //private void InitializeInventory()
    //{
    //    waterLevel = 100;
    //    potatoSeeds = 5;
    //    tomatoSeeds = 5;
    //    cornSeeds = 5;
    //    carrotSeeds = 5;
    //    watermelonSeeds = 5;
    //}
}
