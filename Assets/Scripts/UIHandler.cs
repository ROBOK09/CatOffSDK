using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField challengeNameInput;
    [SerializeField]
    private TMP_InputField challengeDescriptionInput;
    [SerializeField]
    private TMP_InputField startDateInput;
    [SerializeField]
    private TMP_InputField endDateInput;
    [SerializeField]
    private TMP_InputField creatorNameInput;
    [SerializeField]
    private TMP_InputField gameIDInput;
    [SerializeField]
    private TMP_InputField wagerInput;
    [SerializeField]
    private TMP_InputField targetInput;
    [SerializeField]
    private TMP_InputField maxParticipantsInput;
    [SerializeField]
    private TMP_InputField sideBetsWagerInput;
    [SerializeField]
    private Toggle allowSideBetsToggle;
    [SerializeField]
    private TMP_Dropdown currencyDropdown;
    [SerializeField]
    private TMP_Dropdown categoryDropdown;
    [SerializeField]
    private Button submitButton;  

    
    private ChallengeSDK challengeSDK;

    private string jwtToken = "your_jwt_token";

    void Start()
    {
        challengeSDK = GetComponent<ChallengeSDK>();
        submitButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    private void OnSubmitButtonClicked()
    {
        // Read the input values from the UI elements
        string challengeName = challengeNameInput.text;
        string challengeDescription = challengeDescriptionInput.text;
        string challengeCreatorName = creatorNameInput.text;
        int gameID = int.Parse(gameIDInput.text);
        long startDate = long.Parse(startDateInput.text);
        long endDate = long.Parse(endDateInput.text);
        int wager = int.Parse(wagerInput.text);
        int target = int.Parse(targetInput.text);
        int maxParticipants = int.Parse(maxParticipantsInput.text);
        bool allowSideBets = allowSideBetsToggle.isOn;
        int sideBetsWager = int.Parse(sideBetsWagerInput.text);

        // Get the selected currency from the dropdown (e.g., USDC, SOL)
        string selectedCurrency = currencyDropdown.options[currencyDropdown.value].text;

        // Get the selected category from the dropdown (e.g., FITNESS, GAMING)
        string selectedCategory = categoryDropdown.options[categoryDropdown.value].text;

        // Create a new CreateChallengeDto with the values provided by the user
        CreateChallengeDto newChallenge = new CreateChallengeDto
        {
            ChallengeName = challengeName,
            ChallengeDescription = challengeDescription,
            StartDate = startDate,
            EndDate = endDate,
            GameID = gameID,
            MaxParticipants = maxParticipants,
            Wager = wager,
            Target = target,
            ChallengeCreator = challengeCreatorName,
            AllowSideBets = allowSideBets,
            SideBetsWager = sideBetsWager,
            Unit = "pushups",
            IsPrivate = false,
            Currency = (VERIFIED_CURRENCY)System.Enum.Parse(typeof(VERIFIED_CURRENCY), selectedCurrency),
            ChallengeCategory = (CHALLENGE_CATEGORIES)System.Enum.Parse(typeof(CHALLENGE_CATEGORIES), selectedCategory),
            NFTMedia = "https://example.com/nft.png",
            Media = "https://example.com/media.mp4",
            ActualStartDate = startDate + 10000,
            UserAddress = "0xabcdef1234567890abcdef1234567890abcdef12"
        };

        // Call the SDK method to create the challenge using the newChallenge object and JWT token
        StartCoroutine(challengeSDK.CreateChallenge(newChallenge, jwtToken));
    }
}
