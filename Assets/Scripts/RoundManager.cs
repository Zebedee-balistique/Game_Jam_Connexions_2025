using UnityEngine;
using System.Collections.Generic;
using System;


public class RoundManager : MonoBehaviour
{
    #region Public Fields

    public List<int> weapons;
    public List<int> nb_slots;
    public List<int> scores;
    public List<bool> lives;
    public float round_multiplier;

    public static event Action OnRoundEnded; //Event for the end of the round

    #endregion

    #region Private Fields


    void OnEnable() //Start gets called after beginNewRound
    {
        Debug.Log("OnEnable : RoundManager");
        round_multiplier = 1;
    }

    #endregion

    #region MonoBehaviour Callbacks



    #endregion

    #region Public Methods

    public void beginNewRound()
    {
        Debug.Log("beginNewRound : RoundManager");
    }

    #endregion

    #region Private Methods

    #endregion
}

