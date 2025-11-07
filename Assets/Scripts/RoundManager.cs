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
    public double round_multiplier;

    public SlotsManager my_sm;

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

        scores.Clear();
        lives.Clear();

        round_multiplier *= 1.4;

        int i;
        int nb_weapons = weapons.Count;

        for (i = 0; i < nb_weapons ; i++)
        {
            newWeapon(i);
        }
    }

    #endregion

    #region Private Methods

    private void newWeapon(int num_weapon)
    {
        my_sm.target_symbol = weapons[num_weapon]; //Gets the id of the weapon
        
    }

    #endregion
}

