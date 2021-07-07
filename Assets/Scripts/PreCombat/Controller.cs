using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{

    private SceneLoad sceneLoad;
    public SimpleObjectPool optionButtonObjectPool;
    public Transform optionButtonParent;
    public GameObject panel;
    public Image clown;
    public Image text_box;
    public Text text_phase;

    private DataController dataController;
    private RoundData currentRound;
    private PhaseData[] currentPhasePool;

    private CombatData[] combatData;
    private int combatControl = 0;

    private int phaseIndex = 0;
    private bool activeRound;
    
    private int currentPhaseNumber = 0;

    private List<GameObject> optionsButtonsGameObjects = new List<GameObject>();


    static Controller ImTheOne;


    // Start is called before the first frame update
    void Start()
    {

        
        if(ImTheOne != null)
        {
            ImTheOne.text_phase.enabled = true;
            ImTheOne.clown.enabled = true;
            ImTheOne.text_box.enabled = true;
            ImTheOne.panel.SetActive(true);
            ImTheOne.ShowOptions();
            Destroy(this.gameObject);
            return;
        }

        sceneLoad = new SceneLoad();

        dataController = FindObjectOfType<DataController>();
        currentRound = dataController.GetCurrentRoundData();
        currentPhasePool = currentRound.phases;
        combatData = dataController.combatData;

        text_phase.text = combatData[combatControl].text_pre_Combat;

        text_phase.enabled = true;
        clown.enabled = true;
        text_box.enabled = true;

        ImTheOne = this;
        
        GameObject.DontDestroyOnLoad(gameObject);

        ShowOptions();
        

      
        
        //activeRound = True

    }

    // Update is called once per frame
    void Update()
    {

        if (optionButtonObjectPool == null)
        {

            optionButtonObjectPool = FindObjectOfType<SimpleObjectPool>();

        }

    }

    private void ShowOptions()
    {

        RemoveOptionsButtons();

        
        if(optionButtonObjectPool == null)
        {
            optionButtonObjectPool = FindObjectOfType<SimpleObjectPool>();
        }
        PhaseData phasedata = currentPhasePool[currentPhaseNumber];
        
        for (int i = 0; i < phasedata.options.Length; i++)
        {
            

            GameObject optionButtonObject = optionButtonObjectPool.GetObject();

            optionButtonObject.transform.SetParent(optionButtonParent);

            optionsButtonsGameObjects.Add(optionButtonObject);

            OptionsButtons optionbutton = optionButtonObject.GetComponent<OptionsButtons>();
            optionbutton.Setup(phasedata.options[i]);

        }
    }

    private void RemoveOptionsButtons()
    {
        while (optionsButtonsGameObjects.Count > 0)
        {
            optionButtonObjectPool.ReturnObject(optionsButtonsGameObjects[0]);
            optionsButtonsGameObjects.RemoveAt(0);
        }
    }


    public void OptionClicked(bool rightOption)
    {
        panel.SetActive(false);
        if(rightOption){
            currentPhaseNumber++;
        }
        if(currentPhaseNumber >= currentPhasePool.Length){
            currentPhaseNumber = 0;
            RemoveOptionsButtons();
            sceneLoad.LoadScene("SampleScene");
        }else{
            text_phase.enabled = false;
            clown.enabled = false;
            text_box.enabled = false;
            string scene = combatData[combatControl].sceneName;
            sceneLoad.LoadScene(scene);
            combatControl++;
            text_phase.text = combatData[combatControl].text_pre_Combat;
            ShowOptions();
        }
        if(combatControl == 4)
        {
            combatControl = 0;
        }
        
        
    }
}
