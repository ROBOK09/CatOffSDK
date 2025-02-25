using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;

public class ChallengeSDK : MonoBehaviour
{
    private const string ApiUrl = "https://example.com/challenge";

    public IEnumerator CreateChallenge(CreateChallengeDto challenge, string jwtToken)
    {
        string jsonPayload = JsonUtility.ToJson(challenge);

        using (UnityWebRequest request = new UnityWebRequest(ApiUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Adding the JWT token in the Authorization header
            request.SetRequestHeader("Authorization", "Bearer " + jwtToken);
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Challenge Created Successfully: " + request.downloadHandler.text);
                // Handle success response, parse the response as needed
            }
            else
            {
                Debug.LogError("Error Creating Challenge: " + request.error);
                // Handle error, display message, etc.
            }
        }
    }
}
