using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Localize : MonoBehaviour
{
    #region Public Fields

    public string localizationKey;

    #endregion Public Fields

    #region Private Fields

    const string STR_LOCALIZATION_KEY = "locale";
    const string STR_LOCALIZATION_PREFIX = "localization/";
    static string currentLanguage;
    static bool currentLanguageFileHasBeenFound = false;
    static bool currentLanguageHasBeenSet = false;
    public static Dictionary<string, string> CurrentLanguageStrings = new Dictionary<string, string>();
    static TextAsset currentLocalizationText;
    private Text text;

    #endregion Private Fields

    #region Public Properties

    public static bool CurrentLanguageHasBeenSet
    {
        get
        {
            return currentLanguageHasBeenSet;
        }
    }

    public static SystemLanguage PlayerLanguage
    {
        get
        {
            return (SystemLanguage)PlayerPrefs.GetInt(STR_LOCALIZATION_KEY, (int)Application.systemLanguage);
        }
        set
        {
            PlayerPrefs.SetInt(STR_LOCALIZATION_KEY, (int)value);
            PlayerPrefs.Save();
        }
    }

    #endregion Public Properties

    #region Private Properties

    public static string CurrentLanguage
    {
        get { return currentLanguage; }
        set
        {
            if (value != null && value.Trim() != string.Empty)
            {
                currentLanguage = value;
                currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                if (currentLocalizationText == null)
                {
                    Debug.LogWarningFormat("Missing locale '{0}', loading English.", currentLanguage);
                    currentLanguage = SystemLanguage.English.ToString();
                    currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                }
                if (currentLocalizationText != null)
                {
                    currentLanguageFileHasBeenFound = true;
                    // We wplit on newlines to retrieve the key pairs
                    string[] lines = currentLocalizationText.text.Split(new string[] { "\r\n", "\n\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                    CurrentLanguageStrings.Clear();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] pairs = lines[i].Split(new char[] { '\t', '=' }, 2);
                        if (pairs.Length == 2)
                        {
                            CurrentLanguageStrings.Add(pairs[0].Trim(), pairs[1].Trim());
                        }
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Locale Language '{0}' not found!", currentLanguage);
                }
            }
        }
    }

    #endregion Private Properties

    #region Public Methods

    public static string GetLocalizedString(string key)
    {
        if (CurrentLanguageStrings.ContainsKey(key))
            return CurrentLanguageStrings[key];
        else
            return string.Empty;
    }

    /// <summary>
    /// This is to set the language by code. It also update all the Text components in the scene.
    /// </summary>
    /// <param name="language">The new language</param>
    public static void SetCurrentLanguage(SystemLanguage language)
    {
        CurrentLanguage = language.ToString();
        PlayerLanguage = language;
        Localize[] allTexts = GameObject.FindObjectsOfType<Localize>();
        for (int i = 0; i < allTexts.Length; i++)
            allTexts[i].UpdateLocale();
    }

    /// <summary>
    /// Update the value of the Text we are attached to.
    /// </summary>
    public void UpdateLocale()
    {
        if (!text) return; // catching race condition
        if (!System.String.IsNullOrEmpty(localizationKey) && CurrentLanguageStrings.ContainsKey(localizationKey))
            text.text = CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n');
    }

    #endregion Public Methods

    #region Private Methods

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
        
        if(!currentLanguageHasBeenSet)
        {
            currentLanguageHasBeenSet = true;
            SetCurrentLanguage(PlayerLanguage);
        }
        UpdateLocale();
    }

    #endregion Private Methods
}