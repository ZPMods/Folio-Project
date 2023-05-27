using UnityEngine;
using System.Collections;

public abstract class Singleton<Instance>: MonoBehaviour where Instance : Singleton<Instance>
{
    private static Instance _instance;

    public static Instance instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(Instance)) as Instance;
                if (_instance == null) throw new System.Exception("No Singleton of type " + typeof(Instance).Name + " found.");
            }

            return _instance;
        }

        private set { _instance = value; }
    }

    protected static bool permanent;

    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = this as Instance;
        }

        else if (_instance != this as Instance)
        {
            Destroy(this.gameObject);
        }

        if (_instance != null && permanent)
        {
            Debug.Log("Permanent");
            DontDestroyOnLoad(gameObject);
        }

        else if (_instance != null && !permanent)
        {
            Debug.Log("Not permanent");
        }

        OnInit();
    }

    public virtual void OnInit()
    {

    }
}

public class ScriptableSingleton<Instance> : ScriptableObject where Instance : ScriptableSingleton<Instance>
{
    private static Instance _instance;

    public static Instance instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Instantiate");

                Instance[] assets = Resources.LoadAll<Instance>("");
                if (assets == null || assets.Length < 1)
                {
                    Debug.LogError("Could not find any singleton scriptable object of type " + typeof(Instance).Name + " in the resources.");
                    return CreateInstance(typeof(Instance)) as Instance;
                }

                else if (assets.Length > 1)
                {
                    Debug.LogWarning("Multiple instances of the singleton scriptable object of type " + typeof(Instance).Name + " found in the resources.");
                }

                _instance = assets[0];
            }

            return _instance;
        }
    }
    protected static bool permanent;
}