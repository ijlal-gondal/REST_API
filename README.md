
# Updated REST_API

-----------------------------------------------------------------
Retrieving the current status of all interventions that do not have a start date and are in "Pending" status.

GET
https://ijlal.azurewebsites.net/api/interventions/get/Status/Pending

-----------------------------------------------------------------

Changing the status of a specific intervetion  to "InProgress" and add a start date and time (Timestamp).

PUT
https://localhost:5001/api/interventions/{id}/start

IN THE BODY :

    {
      
    "status": "InProgress",
    "started_at": "2020-11-01T23:28:56.782Z"
    

    }

-----------------------------------------------------------------


Changing the status of a specific intervention to "Completed" and add an end date and time (Timestamp).

PUT
https://localhost:5001/api/interventions/{id}/end

IN THE BODY : 

    {
      
    "status": "Completed",
    "ended_at": "2020-11-01T23:28:56.782Z"
  
    }



