using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    public SimpleObjectPool optionButtonObjectPool;
    public Transform optionButtonParent;
    public GameObject panel;
    public string scene = "Combat";

    private DataController dataController;
    private RoundData currentRound;
    private PhaseData[] currentPhasePool;

    private int phaseIndex;
    //private bool activeRound;
    
    private int currentPhaseNumber;

    private List<GameObject> optionsButtonsGameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRound = dataController.GetCurrentRoundData();
        currentPhasePool = currentRound.phases;

        phaseIndex = 0;
        currentPhaseNumber = 0;
        showQuestion();
        // //activeRound = True

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void showQuestion()
    {
        RemoveOptionsButtons();

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
        while(optionsButtonsGameObjects.Count > 0)
        {
            optionButtonObjectPool.ReturnObject(optionsButtonsGameObjects[0]);
            optionsButtonsGameObjects.RemoveAt(0);
        }
    }

    public void OptionClicked(bool rightOption)
    {
        if(rightOption){
            phaseIndex++;
        }
        if(phaseIndex > currentPhasePool.Length){
            phaseIndex = 0;
            SceneManager.LoadScene("SampleScene");
            showQuestion();
        }else{
            SceneManager.LoadScene(scene);
            showQuestion();
        }
        
    }
}
