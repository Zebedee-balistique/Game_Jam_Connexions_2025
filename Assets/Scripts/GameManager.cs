using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// MonoBehaviour class
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Public Fields

    public GameObject roundManagerPrefab;

    #endregion

    #region Private Fields

    private int total_score;
    private int lives;
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
        lives = 3;

        Debug.Log("Start : GameManager");
        GameObject roundManager = Instantiate(roundManagerPrefab);
        my_rm = roundManager.GetComponent<RoundManager>();
        nextRound();
    }

    #endregion

    #region Private Methods

    void nextRound()
    {
        Debug.Log("nextRound : GameManager");
        int difficulty = 0;
        int nb_weapons = 0;
        List<int> nb_slots = new List<int>();

        int limit = num_round;
        int temp;

        while (difficulty < num_round)
        {
            temp = Random.Range(2, limit);

            Debug.Log("temp = " + temp.ToString());
            if(temp == limit-1) temp += 1;

            nb_slots.Add(temp);
            nb_weapons++;
            difficulty += temp;
            limit -= temp;
        }

        my_rm.nb_weapons = nb_weapons;
        my_rm.nb_slots = nb_slots;

        my_rm.beginNewRound();
    }

    void endRound()
    {
        Debug.Log("endRound : GameManager");
    }

    #endregion
}