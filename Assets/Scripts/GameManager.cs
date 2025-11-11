using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// MonoBehaviour class
/// </summary>
public class GameManager : MonoBehaviour
{
    //To make GameManager a Singleton
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    #region Public Fields

    public GameObject roundManagerPrefab; //To create the Round Manager
    public GameObject slotPrefab; //To create the slots
    public int nb_weapons; //The amount of weapons available

    #endregion

    #region Private Fields

    private int total_score; //To keep track of the score
    private int num_lives; //To keep track of the remaining lives
    private int num_round; //To keep track of the round number

    private RoundManager my_rm; //The Round Manager

    #endregion

    #region MonoBehaviour Callbacks

    #endregion

    #region Public Methods

    /*----------------------------------*/
    /*OnEnable : handles the event calls*/
    /*Entry :    nothing                */
    /*                                  */
    /*Exit :     nothing                */
    /*----------------------------------*/
    void OnEnable()
    {
        //Subscribes to the OnRoundEnded from Round Manager
        RoundManager.OnRoundEnded += endRound;
    }

    /*---------------------*/
    /*Start : set up method*/
    /*Entry : nothing      */
    /*                     */
    /*Exit :  nothing      */
    /*---------------------*/
    void Start()
    {
        Debug.Log("Start : GameManager");

        num_round = 2; //Begins at 2 for the difficulty level
        total_score = 0; //Set to 0
        num_lives = 3; //Maximum lives

        //Get the Round Manager
        GameObject roundManager = Instantiate(roundManagerPrefab);
        my_rm = roundManager.GetComponent<RoundManager>();

        nextRound(); //Begin the rounds
    }

    #endregion

    #region Private Methods

    /*----------------------------------------*/
    /*Awake : makes sure there is one instance*/
    /*Entry :    nothing                      */
    /*                                        */
    /*Exit :     nothing                      */
    /*----------------------------------------*/

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    /*------------------------------------------------*/
    /*nextRound : sets the Round Manager for the round*/
    /*Entry :    nothing                              */
    /*                                                */
    /*Exit :     nothing                              */
    /*------------------------------------------------*/

    private void nextRound()
    {
        Debug.Log("nextRound : GameManager");

        int difficulty = 0; //To track the difficulty level
        List<int> nb_slots = new List<int>(); //To keep track of the slot amounts
        List<int> weapons = new List<int>(); //To keep track of the selected weapon

        int limit = num_round; //The difficulty limit
        int temp; //Temporary variable

        while (difficulty < num_round) //While the difficulty isn't set
        {
            temp = Random.Range(2, limit); //Get random number

            Debug.Log("temp = " + temp);
            if(temp == limit-1) //Can't have only 1 slot
            {
                temp += 1; //Adjusts for this case
                Debug.Log("temp ajusted");
            }
            
            weapons.Add(Random.Range(0,nb_weapons)); //Add a targeted weapon
            nb_slots.Add(temp); //Adds the amount of slots
            difficulty += temp; //Increases the difficulty score
            limit -= temp; //Limits the remaining possible values
        }

        my_rm.nb_slots = nb_slots; //Set the list of the slot amounts
        my_rm.weapons = weapons; //Set the list of targeted weapons

        my_rm.beginNewRound(); //Starts the round in Round Manager
    }

    /*-----------------------------------*/
    /*endRound : checks the round results*/
    /*Entry :    nothing                 */
    /*                                   */
    /*Exit :     nothing                 */
    /*-----------------------------------*/

    private void endRound()
    {
        Debug.Log("endRound : GameManager");

        foreach(int score in my_rm.scores) //Gets each score
        {
            total_score += (int) (score * (1 + num_round*0.25)); //Adds the scores to the total
        }

        foreach(bool live in my_rm.lives) //Checks the lives
        {
            if (live) //If live lost
            {
                num_lives--; //Decrease
            }
        }
        if (num_lives > 0) //If player is still alive
        {
            num_round++;
            nextRound(); //Starts the next round
        }
        else //If player is dead
        {
            endGame(); //The game is over
        }
    }

    private void endGame() 
    {

    }

    #endregion
}
