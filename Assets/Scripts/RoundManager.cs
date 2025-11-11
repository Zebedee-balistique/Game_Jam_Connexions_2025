using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;


public class RoundManager : MonoBehaviour
{
    #region Public Fields

    public GameObject slotsManagerPrefab; //To create the Slots Manager

    public List<int> weapons; //List of weapons to create
    public List<int> nb_slots; //Amount of slots per weapon
    public List<int> scores; //Score got for each weapon
    public List<bool> lives;

    public SlotsManager my_sm;

    public static event Action OnRoundEnded; //Event for the end of the round

    #endregion

    #region Private Fields

    private int current_weapon;

    /*---------------------------------------------------------------------*/
    /*OnEnable : handles the event calls and some variables initiliazations*/
    /*Entry :    nothing                                                   */
    /*                                                                     */
    /*Exit :     nothing                                                   */
    /*---------------------------------------------------------------------*/
    private void OnEnable() //Start gets called after beginNewRound
    {
        Debug.Log("OnEnable : RoundManager");

        GameObject slotsManager = Instantiate(slotsManagerPrefab);
        my_sm = slotsManager.GetComponent<SlotsManager>(); //Get the Slot Manager

        SlotsManager.OnWeaponForged += endWeapon; //Subscribes to the event
    }

    #endregion

    #region MonoBehaviour Callbacks



    #endregion

    #region Public Methods

    /*---------------------------------------*/
    /*beginNewRound : initializes a new round*/
    /*Entry :    nothing                     */
    /*                                       */
    /*Exit :     nothing                     */
    /*---------------------------------------*/

    public void beginNewRound()
    {
        Debug.Log("beginNewRound : RoundManager");

        scores.Clear(); 
        lives.Clear(); //Resets the Lists

        int nb_weapons = weapons.Count; //Get the amount of weapons for the round
        current_weapon = 0; //Sets the iterator to 0.

        newWeapon(); //Starts the weapon
    }

    #endregion

    #region Private Methods

    /*-------------------------------------*/
    /*newWeapon : handles a weapon creation*/
    /*Entry :     nothing                  */
    /*                                     */
    /*Exit :      nothing                  */
    /*-------------------------------------*/
    private void newWeapon()
    {
        my_sm.beginWeapon(nb_slots[current_weapon]);
    }

    /*-------------------------------------------*/
    /*endWeapon : gets the results for the weapon*/
    /*Entry :     nothing                        */
    /*                                           */
    /*Exit :      nothing                        */
    /*-------------------------------------------*/
    private void endWeapon()
    {
        //Calculates the score
        scores[current_weapon] = my_sm.selected_symbols.Count(x => x == weapons[current_weapon]) * nb_slots[current_weapon];
        //Get the amount of targeted symbol in the ones selected, multiply it by the amount of slots

        if(scores[current_weapon] < nb_slots[current_weapon] / 2) //If half the symbols are wrong
        {
            lives[current_weapon] = true; //Life is lost
        }
        else
        {
            lives[current_weapon] = false;
        }

        if(current_weapon < weapons.Count - 1) //If not all weapons are done
        {
            current_weapon++;
            newWeapon(); //Move to the next one
        }
        else
        {
            OnRoundEnded?.Invoke(); //All weapons done
        }
        
    }

    #endregion
}

