using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class SaveData
{
    public float playerX;
    public float playerY;
}

public class SaveSystem : MonoBehaviour
{
    public Transform player;

    public InputAction saveAction;
    public InputAction loadAction;

    string savePath;

    void OnEnable()
    {
        saveAction.Enable();
        loadAction.Enable();
    }

    void OnDisable()
    {
        saveAction.Disable();
        loadAction.Disable();
    }

    void Start()
    {
        savePath = Application.persistentDataPath + "/save.json";
        Debug.Log("Save path: " + savePath);
    }

    void Update()
    {
        if (saveAction.WasPressedThisFrame())
        {
            SaveGame();
        }

        if (loadAction.WasPressedThisFrame())
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.playerX = player.position.x;
        data.playerY = player.position.y;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Juego guardado");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            player.position = new Vector2(data.playerX, data.playerY);

            Debug.Log("Juego cargado");
        }
    }
}