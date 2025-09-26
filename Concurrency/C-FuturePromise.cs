/*
    it is used to handle operations that are performed asynchronously and
    allow the program to continue executing without waiting for each operation to complete.

    key concepts
    Future
        represents a placeholder for a value that is initially unknown but will be available at some point in the future
    Promise
        is an object that is used to fulfill or reject a future.
        when promise is created it is in pending state, resolved (finsihed succefully), rejected (operation failed)
    
    In Javascript - we have Promise and then()
    In C# - Task and Async Await is close to Promise future
*/