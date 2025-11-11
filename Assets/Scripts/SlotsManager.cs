using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using System;


/// <summary>
/// MonoBehaviour class
/// </summary>
public class SlotsManager : MonoBehaviour
{
    #region Public Fields

    public List<Slot> slots; //Gets the Slots to display
    public List<int> selected_symbols; //Keeps track of the chosen symbols

    public static event Action OnWeaponForged; //Event for the end of the weapon

    #endregion

    #region Private Fields

    private List<int> random_symbols_id; //Shuffle the ids in a random order for the display
    private int current_slot_id; //The slot currently used
    private int nb_slots; //The amount of slot for this weapon
    private int current_symbol; //The symbol currently taken into account
    
    private bool is_Forging; //The boolean to know if a weapon is being forged

    #endregion

    #region MonoBehaviour Callbacks



    #endregion

    #region Public Methods

    /*---------------------------------------------------------------*/
    /*beginWeapon : initiliazes the weapon creation                  */
    /*Entry :       nb_slots, an int, number of slots for this weapon*/
    /*                                                               */
    /*Exit :        nothing                                          */
    /*---------------------------------------------------------------*/
    public void beginWeapon(int nb_slots)
    {
            shuffle(); //New order for the symbols to appear
            setSlots(nb_slots); //UI method
            current_slot_id = 0; //The slot is initialized at 0
            current_symbol = 0; //The symbol selected is initialized at 0

            is_Forging = true; //Sets the forging system
    }
    #endregion

    #region Private Methods

    /*----------------------------*/
    /*Update : handles the forging*/
    /*Entry :  nothing            */
    /*                            */
    /*Exit :   nothing            */
    /*----------------------------*/

    private void Update()
    {

        

        if(is_Forging) //Only if the forging is happening
        {
            //TO DO : Change current_symbol based on UI
            //TO DO : Scroll the images in the slots

            if (Input.GetKeyDown(KeyCode.Space)) //If the keybar is pressed
            {
                Forge(); //Forge the weapon
            }
            
        }
    }

    /*------------------------*/
    /*Forge : forge the weapon*/
    /*Entry : nothing         */
    /*                        */
    /*Exit :  nothing         */
    /*------------------------*/
    private void Forge()
    {
        selected_symbols[current_slot_id] = random_symbols_id[current_symbol]; //Get the selected symbol
        current_slot_id++; //Moving on to the next slot
        if(current_slot_id == nb_slots) //If the weapon is fully forged
        {
            is_Forging = false; //No more forging
            OnWeaponForged?.Invoke(); //Send the message to Round Manager
        }
    }

    /*------------------------------------------------*/
    /*shuffle : shuffles randomly the random_symbol_id*/
    /*Entry :  nothing                                */
    /*                                                */
    /*Exit :     nothing                              */
    /*------------------------------------------------*/

    private void shuffle()
    {
		int count = random_symbols_id.Count; //Get the number of elements
		int last = count - 1; //Get the max position

        int i; //Iterator for loop
        int r;
        int temp; //Temporary variables

		for (i = 0; i < last; ++i) 
        {
			r = UnityEngine.Random.Range(i, count); //Get random number
			temp = random_symbols_id[i]; //Get the symbol

			random_symbols_id[i] = random_symbols_id[r];
			random_symbols_id[r] = temp; //Switch the two
		}
	}

    //UI methods
    private void setSlots(int nb_slots)
    {
    }

    #endregion
}