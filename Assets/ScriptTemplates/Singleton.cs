using UnityEngine;

/// <summary>
/// Singleton class
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Component
{
    #region Public Fields

    public static T Instance { get; private set; }

    #endregion

    #region Private Fields

    /// <summary>
    /// Activate the persistence of the instance.
    /// </summary>
    [SerializeField]
    [Tooltip("Activate the persistence of the instance.")]
    private bool activatePersistent = false;

    #endregion

    #region MonoBehaviour Callbacks

    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else if (Instance != this)
        {
            Debug.Log($"[{nameof(T)}]: Instance already existing");
            Destroy(this.gameObject);
            return;
        }

        if (activatePersistent)
        {
            DontDestroyOnLoad(Instance);
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    #endregion
}
