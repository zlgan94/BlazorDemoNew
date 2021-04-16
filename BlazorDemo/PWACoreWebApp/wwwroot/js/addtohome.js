/*
 * If the "Add to Home Screen" criteria are met
 *   (as defined at https://developers.google.com/web/fundamentals/app-install-banners),
 *   the browser will raise the "beforeinstallprompt" event which can be used to indicate that the app can be
 *   "installed" by prompting the user to install it. By "install" we mean "add to home screen of the device".
 *  a. When the "beforeinstallprompt" event has fired, save a reference to the event
 *  b. Update the user interface to indicate that the user can add the app to the Home Screen.
 */

let objDeferredPrompt;
const addContainer = document.querySelector('#a2hs-container');
const addBtn = document.querySelector('#a2hs-button');
addContainer.style.display = 'none';

window.addEventListener('beforeinstallprompt', (e) => {

    // Prevent Chrome 67 and earlier from automatically showing the prompt
    e.preventDefault();

    // Stash the event so it can be triggered later.
    objDeferredPrompt = e;

    // Update UI to notify the user they can add to home screen
    addContainer.style.display = 'block';

    addBtn.addEventListener('click', (e) => {

        // Hide the user interface that shows the A2HS button
        addContainer.style.display = 'none';

        // Prompt the user to install the App.
        objDeferredPrompt.prompt();

        // Wait for the user to respond to the prompt shown by the browser.
        objDeferredPrompt
            .userChoice
            .then((choiceResult) => {
                if (choiceResult.outcome === 'accepted') {
                    console.log('User accepted the A2HS prompt');
                } else {
                    console.log('User dismissed the A2HS prompt');
                }
                objDeferredPrompt = null;
            });
    });
});