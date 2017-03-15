using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class pScreenManager : MonoBehaviour
{
    #region singleton
    private static pScreenManager _instance;

    public static pScreenManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region nameScreen
    public static string SCREEN_GAME = "DemoScene";
    #endregion

    #region private
    [SerializeField]
    private GameObject goLoading;
    [SerializeField]
    private tk2dSprite sprLoading;
    [SerializeField]
    private tk2dTextMesh txtLoading;
    private int countDotLoading;
  
    private bool isAllowSetUnLockScreenAuto;
    private GameObject currentScreenObject;
    private string currSceneName;
    private string currScreenName;
    private string oldScreenName;
    private float cdr;
    [SerializeField]
    private bool isLockScreen;
    [SerializeField]
    private bool isQueueUnlock;
    #endregion

    #region public

    #endregion



    // Use this for initialization
    void Start()
    {

        if (isAllowSetUnLockScreenAuto)
        {
            SetQueueUnlockScreen();
        }
    }

    public void ReloadLevel(string nameLevel)
    {
        if (!isLockScreen)
        {
            SetLockScreen();
            if (nameLevel == SCREEN_GAME)
            {
                isAllowSetUnLockScreenAuto = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void ReloadLevel()
    {
        ReloadLevel(currScreenName);

    }

    public void LoadLevel(string nameLevel)
    {
        if (!isLockScreen)
        {
            SetLockScreen();
            if (nameLevel == SCREEN_GAME)
            {
                isAllowSetUnLockScreenAuto = false;

                oldScreenName = currScreenName;
                currScreenName = SCREEN_GAME;
                SceneManager.LoadScene(SCREEN_GAME);
            }
        }
    }

    public void LoadBackScreen()
    {
        if (oldScreenName != "")
        {
            LoadLevel(oldScreenName);
        }
    }

    IEnumerator IELoadScreen(string namePrefab)
    {
        yield return null;
        sprLoading.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isLockScreen)
        {
            cdr += Time.deltaTime;
            if (cdr >= 1)
            {
                cdr = 0;
                countDotLoading++;
                if (countDotLoading == 4)
                {
                    countDotLoading = 0;
                }
                if (countDotLoading == 0)
                {
                    txtLoading.text = "Loading";
                }
                else if (countDotLoading == 1)
                {
                    txtLoading.text = "Loading.";
                }
                else if (countDotLoading == 2)
                {
                    txtLoading.text = "Loading..";
                }
                else if (countDotLoading == 3)
                {
                    txtLoading.text = "Loading...";
                }

                if (isQueueUnlock)
                {
                    SetDirectUnlock();
                }
            }


        }
    }

    public bool IsLockScreen()
    {
        return isLockScreen;
    }

    private void setQueueUnlockScreenPri()
    {
        isQueueUnlock = true;
    }

    private void SetDirectUnlock()
    {
        goLoading.gameObject.SetActive(false);
        isLockScreen = false;
        currSceneName = SceneManager.GetActiveScene().name;
        isQueueUnlock = false;
    }

    public void SetQueueUnlockScreen()
    {
        if (!isAllowSetUnLockScreenAuto)
        {
            isQueueUnlock = true;
        }
    }

    public void SetLockScreen()
    {
        goLoading.gameObject.SetActive(true);
        isLockScreen = true;
    }
}
