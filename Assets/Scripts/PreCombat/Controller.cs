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

    public GameObject entirePanel;
    public string scene = "Combat";

    private DataController dataController;
    private RoundData currentRound;
    private PhaseData[] currentPhasePool;

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
            ImTheOne.panel.SetActive(true);
            ImTheOne.entirePanel.SetActive(true);
            ImTheOne.ShowOptions();
            Debug.Log(ImTheOne);
            Debug.Log("Vou me destruir Ok?");
            Destroy(this.gameObject);
            return;
        }



        Debug.Log("ENTROU Start");

        sceneLoad = new SceneLoad();
       

        dataController = FindObjectOfType<DataController>();
        currentRound = dataController.GetCurrentRoundData();
        currentPhasePool = currentRound.phases; 
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

            //Debug.Log(optionButtonObjectPool);
        }

    }

    private void ShowOptions()
    {
        Debug.Log("ENTROU ShowOptions");

        RemoveOptionsButtons();

        Debug.Log(currentPhaseNumber);
        
        if(optionButtonObjectPool == null)
        {
            optionButtonObjectPool = FindObjectOfType<SimpleObjectPool>();
        }
        PhaseData phasedata = currentPhasePool[currentPhaseNumber];
        
        for (int i = 0; i < phasedata.options.Length; i++)
        {
            //Debug.Log(phasedata.options[i]);
            

            GameObject optionButtonObject = optionButtonObjectPool.GetObject();

            Debug.Log(i+" "+phasedata.options.Length);
            optionButtonObject.transform.SetParent(optionButtonParent);

            optionsButtonsGameObjects.Add(optionButtonObject);

            OptionsButtons optionbutton = optionButtonObject.GetComponent<OptionsButtons>();
            optionbutton.Setup(phasedata.options[i]);

        }
    }

    private void RemoveOptionsButtons()
    {
        //Debug.Log("ENTROU RemoveOptionsButtons");
        while (optionsButtonsGameObjects.Count > 0)
        {
            
            optionButtonObjectPool.ReturnObject(optionsButtonsGameObjects[0]);
            optionsButtonsGameObjects.RemoveAt(0);
        }
    }


    public void OptionClicked(bool rightOption)
    {
        Debug.Log("ENTROU OptionClicked");
        panel.SetActive(false);
        entirePanel.SetActive(false);
        if(rightOption){
            currentPhaseNumber++;
        }
        if(currentPhaseNumber >= currentPhasePool.Length){
            Debug.Log("ENTROU");
            currentPhaseNumber = 0;
            RemoveOptionsButtons();
            sceneLoad.LoadScene("SampleScene");
        }else{
            
            sceneLoad.LoadScene(scene);
            ShowOptions();
        }
        
        
        
    }
}
