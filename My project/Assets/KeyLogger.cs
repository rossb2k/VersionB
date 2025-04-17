using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class KeyLogger : MonoBehaviour
{
    private int wKeyCount = 0;
    private int aKeyCount = 0;
    private int sKeyCount = 0;
    private int dKeyCount = 0;

    void Update()
    {
        bool keyPressed = false;

        // Track key presses for WASD
        if (Input.GetKeyDown(KeyCode.W))
        {
            wKeyCount++;
            Debug.Log("W Key Pressed");
            keyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aKeyCount++;
            Debug.Log("A Key Pressed");
            keyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sKeyCount++;
            Debug.Log("S Key Pressed");
            keyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dKeyCount++;
            Debug.Log("D Key Pressed");
            keyPressed = true;
        }

        // Send event when a key is pressed
        if (keyPressed)
        {
            SendKeyPressEvent();
        }
    }

    // Send key press event to Unity Analytics
    void SendKeyPressEvent()
    {
        try
        {
            // Create the custom event instance and set parameters
            KeyPressedEvent keyPressedEvent = new KeyPressedEvent
            {
                WKey = wKeyCount,
                AKey = aKeyCount,
                SKey = sKeyCount,
                DKey = dKeyCount
            };

            // Send the custom event to Unity Analytics
            AnalyticsService.Instance.RecordEvent(keyPressedEvent);

            // Debugging: Output the sent data
            Debug.Log($"Key Press Event Sent - W: {wKeyCount}, A: {aKeyCount}, S: {sKeyCount}, D: {dKeyCount}");
        }
        catch (System.Exception e)
        {
            // Error handling if event recording fails
            Debug.LogError($"Error sending analytics event: {e}");
        }
    }
}
