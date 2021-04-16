/*
 * Registers the Service Worker
 * 
 * NOTE:
 * (a) ServiceWorkers work only if the site is served over HTTPS.
 *     The only exception to this rule is if the application is running from LocalHost.
 * (b) Since this application is running in HTTPS mode,
 *     you have to install the SSL Certificate on the Browser,
 *     otherwise the ServiceWorker will neve run (in both - Normal & Incognito modes)
 *
 *  For understanding the lifecycle of the ServiceWorker:
 *     https://developers.google.com/web/fundamentals/primers/service-workers/lifecycle
 *  For a great video explaining ServiceWorkers: 
 *     https://channel9.msdn.com/events/Build/2018/BRK2404
  *********************************************************/


// If the Browser supports ServiceWorker
//  Register the service worker (done asynchronously, hence with Promises)
//  So, if Promise is successful, do something
//  Or, if Promise is unsuccessful, do something here.
if ('serviceWorker' in navigator) {
    navigator.serviceWorker.register('/sw.js')
        .then(reg => {
            console.log('service worker registered successfully, with the scope: ' + reg.scope + '\n', reg)
        })
        .catch(err => {
            console.log('service worker registeration failed! Error:.\n', err)
        });
}