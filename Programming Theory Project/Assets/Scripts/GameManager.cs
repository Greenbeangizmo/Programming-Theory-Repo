using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int waterLevel;
    public static int potatoSeeds;
    public static int tomatoSeeds;
    public static int cornSeeds;
    public static int carrotSeeds;
    public static int watermelonSeeds;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeInventory(); //ABSTRACTION
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    private void InitializeInventory()
    {
        waterLevel = 100;
        potatoSeeds = 5;
        tomatoSeeds = 5;
        cornSeeds = 5;
        carrotSeeds = 5;
        watermelonSeeds = 5;
    }
}
