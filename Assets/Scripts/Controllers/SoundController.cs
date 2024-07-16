using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource allSoundsSource;
    public AudioSource gameSoundsSource;
    public AudioSource backgroundSoundsSource;

    [Header("UI Elements")]
    public Slider allSoundsSlider;
    public Slider gameSoundsSlider;
    public Slider backgroundSoundsSlider;

    [SerializeField] Button close, apply;
    [SerializeField] List<Button> openButtonsSettingPanel = new List<Button>();
    [SerializeField] GameObject settingPanel;

    private float allSoundsVolume = 1f;
    private float gameSoundsVolume = 1f;
    private float backgroundSoundsVolume = 1f;

    private float tempAllSoundsVolume;
    private float tempGameSoundsVolume;
    private float tempBackgroundSoundsVolume;

    private void Awake()
    {
        close.onClick.AddListener(() =>
        {
            settingPanel.SetActive(false);
        });

        openButtonsSettingPanel.ForEach(button =>
        {
            button.onClick.AddListener(() =>
            {
                settingPanel.SetActive(true);
                InitializeSliders();
            });
        });

        apply.onClick.AddListener(ApplyChanges);
    }

    private void Start()
    {
        InitializeSliders();
    }

    private void InitializeSliders()
    {
        // Initialize temporary volumes to current volumes
        tempAllSoundsVolume = allSoundsVolume;
        tempGameSoundsVolume = gameSoundsVolume;
        tempBackgroundSoundsVolume = backgroundSoundsVolume;

        // Initialize sliders with temporary volumes
        allSoundsSlider.value = tempAllSoundsVolume;
        gameSoundsSlider.value = tempGameSoundsVolume;
        backgroundSoundsSlider.value = tempBackgroundSoundsVolume;

        allSoundsSlider.onValueChanged.AddListener(OnAllSoundsVolumeChanged);
        gameSoundsSlider.onValueChanged.AddListener(OnGameSoundsVolumeChanged);
        backgroundSoundsSlider.onValueChanged.AddListener(OnBackgroundSoundsVolumeChanged);
    }

    private void OnAllSoundsVolumeChanged(float value)
    {
        tempAllSoundsVolume = value;
    }

    private void OnGameSoundsVolumeChanged(float value)
    {
        tempGameSoundsVolume = value;
    }

    private void OnBackgroundSoundsVolumeChanged(float value)
    {
        tempBackgroundSoundsVolume = value;
    }

    private void ApplyChanges()
    {
        allSoundsVolume = tempAllSoundsVolume;
        gameSoundsVolume = tempGameSoundsVolume;
        backgroundSoundsVolume = tempBackgroundSoundsVolume;

        UpdateVolumes();
    }

    private void UpdateVolumes()
    {
        allSoundsSource.volume = allSoundsVolume;

        // Assuming gameSoundsSource and backgroundSoundsSource are children of allSoundsSource
        gameSoundsSource.volume = allSoundsVolume * gameSoundsVolume;
        backgroundSoundsSource.volume = allSoundsVolume * backgroundSoundsVolume;
    }
}
