# CatOffSDK
## Project Overview
### Project Version Details -
Project Made in Unity 6 (Version 6000.0.26f1) in Universal Render Pipeline.

### Setup Guidelines -
You can clone the above github repository and Open the CatOffSDK Assignment folder with the appropriate version through Unity Hub or by downloading the appropriate version manually.
You can also download the unity package from the repository and import that to a new unity project. After installing the package and waiting for the scripts to compile, then switch to the DemoScene from the package and after a while try to open the UI in hierarchy it should then prompt you to install TextMeshPro Unity Package and after playing the scene once the text should be visible.

### Project Details
- The SDK exposes a public class ChallengeSDK that allows Unity developers to create challenges using the provided API schema and that is what is being used when all the right values are put in the input field.
- The SDK includes error handling, authentication, and request validation.
- A basic Unity UI demo to test the SDK's functionality ("DemoScene").
- Enums are used for currency and categories.
- The API endpoint can also be modified from the ChallengeSDK class, in place of the default ApiUrl - https://example.com/challenge.
- Please refer to the Inline Comments in the script files for more details.
