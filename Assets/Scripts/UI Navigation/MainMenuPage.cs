
/// <summary>
/// Basic Class
/// </summary>
public class MainMenuPage : APage
{
    #region Public Fields



    #endregion

    #region Private Fields

    private void OnDisable()
    {
        PageNavManager.Instance.LoadAdditivePage(2);
    }

    #endregion

    #region Public Methods



    #endregion

    #region Private Methods


    #endregion
}
