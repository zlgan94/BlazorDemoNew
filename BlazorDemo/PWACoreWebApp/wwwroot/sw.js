/*
 * The Service Worker
 * 
 * NOTE: Ensure that this file is in the Root folder, as the ServiceWorker object is "scoped" 
 *       (meaning that it has access to all the files) in the current folder and its child-folders.
 *       While registering the ServiceWorker (see app.js), we can register by providing the SCOPE. 
 *       For example:
 *              navigator.serviceWorker.register('/service-worker.js', { scope: '/pages/' });
 *       The path cannot contain the parent folder of the ServiceWorker File (sw.js)
 *       For understanding the lifecycle of the ServiceWorker:
 *          https://developers.google.com/web/fundamentals/primers/service-workers/lifecycle
 ***********************/

/*
 * The "install" event handler executed when the ServiceWorker is installed the first time,
 *   or whenever the service worker file is refreshed (when the ServiceWorker file is changed).
 */
self.addEventListener('install', e => {

    console.log('the install eventhandler was called.\n', e);

    // The ServiceWorker switches to "waiting" mode, awaiting for the "activate" event to be raised.
    // During an update, the existing ServiceWorker is running. So, even though the new ServiceWorker 
    // gets registered, it would remain "in waiting", until the application is exit. This is because 
    // the browser does not activate automatically.
    // To skip waiting, and activate immediately, the following call is being done.
    self.skipWaiting();
});


/*
 * The "activate" event handler executed when the ServiceWorker has been activated.
 */
self.addEventListener('activate', e => {

    console.log('the activate eventhandler was called.\n', e);

});


/*
 * The "fetch" event handler executed whenever any request is submitted by the browser to the server.
 * Very useful, to fetch locally cached content.
 */
self.addEventListener('fetch', e => {

    console.log('the fetch eventhandler was called.\n', e);

});
