using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// MonoBehaviour class
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Public Fields

    public GameObject roundManagerPrefab;
    public GameObject slotsManagerPrefab;
    public GameObject slotPrefab;
    public int nb_weapons;

    #endregion

    #region Private Fields

    private int total_score;
    private int num_lives;
    private int num_round;

    
    private RoundManager my_rm;

    #endregion

    #region MonoBehaviour Callbacks



    #endregion

    #region Public Methods

    void OnEnable()
    {
        RoundManager.OnRoundEnded += endRound;
    }

    void Start()
    {
        num_round = 2;
        total_score = 0;
        num_lives = 3;

        Debug.Log("Start : GameManager");
        GameObject roundManager = Instantiate(roundManagerPrefab);
        my_rm = roundManager.GetComponent<RoundManager>();

        GameObject slotsManager = Instantiate(slotsManagerPrefab);
        my_rm.my_sm = slotsManager.GetComponent<SlotsManager>();

        nextRound();
    }

    #endregion

    #region Private Methods

    void nextRound()
    {
        Debug.Log("nextRound : GameManager");
        int difficulty = 0;
        List<int> nb_slots = new List<int>();
        List<int> weapons = new List<int>();

        int limit = num_round;
        int temp;

        while (difficulty < num_round)
        {
            temp = Random.Range(2, limit);

            Debug.Log("temp = " + temp);
            if(temp == limit-1)
            {
                temp += 1;
                Debug.Log("temp ajusted");
            }
            
            weapons.Add(Random.Range(0,nb_weapons));
            nb_slots.Add(temp);
            difficulty += temp;
            limit -= temp;
        }

        my_rm.nb_slots = nb_slots;
        my_rm.weapons = weapons;

        my_rm.beginNewRound();
    }

    void endRound()
    {
        Debug.Log("endRound : GameManager");

        foreach(int score in my_rm.scores)
        {
            total_score += score;
        }

        foreach(bool live in my_rm.lives)
        {
            if (live)
            {
                num_lives--;
            }
        }
        if (num_lives > 0)
        {
            nextRound();
        }
        else
        {
            endGame();
        }
    }

    private void endGame()
    {

    }

    #endregion
}
