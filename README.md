
# REST API

-----------------------------------------------------------------
Retrieving the current status of a specific Battery

GET
https://rocketelev.azurewebsites.net/api/batteries/{id}

-----------------------------------------------------------------

Changing the status of a specific Battery

PUT
https://rocketelev.azurewebsites.net/api/batteries/{id}

IN THE BODY :

    {
        "status": "ENTER THE NEW STATUS"
    }

-----------------------------------------------------------------

Retrieving the current status of a specific Column

GET
https://rocketelev.azurewebsites.net/api/columns/{id}

-----------------------------------------------------------------
Changing the status of a specific Column

PUT
https://rocketelev.azurewebsites.net/api/columns/{id}

IN THE BODY : 

    {
        "status": "ENTER THE NEW STATUS"
    }


-----------------------------------------------------------------
Retrieving the current status of a specific Elevator

GET
https://rocketelev.azurewebsites.net/api/elevators/{id}

-----------------------------------------------------------------

Changing the status of a specific Elevator

PUT 
https://rocketelev.azurewebsites.net/api/elevator/{id}

IN THE BODY : 

    {
        
      "status":"ENTER THE NEW STATUS"
    }

-----------------------------------------------------------------

Retrieving a list of Elevators that are not in operation at the time of the request

GET 
https://rocketelev.azurewebsites.net/api/elevators/


-----------------------------------------------------------------
Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention

GET 

https://rocketelev.azurewebsites.net/api/buildings/intervention

-----------------------------------------------------------------
Retrieving a list of Leads created in the last 30 days who have not yet become customers.

https://rocketelev.azurewebsites.net/api/leads/listofleads


----------------------------------------------------------------- 

                          +++Extra+++
Retrieving a list of Employees with id, email and title

GET

https://rocketelev.azurewebsites.net/api/employees

----------------------------------------------------------------- 

Retrieving the current status of a specific Employee

GET
https://rocketelev.azurewebsites.net/api/employees/{id}

----------------------------------------------------------------- 
Changing the title of a specific Employee

PUT 
https://rocketelev.azurewebsites.net/api/employees/{id}

IN THE BODY : 

    {
        
      "job_title":"ENTER THE NEW STATUS"
    }


----------------------------------------------------------------- 

Retrieving all Elevators with an "Active" status
GET
https://rocketelev.azurewebsites.net/api/elevators/get/status/active
-----------------------------------------------------------------
Retrieving all Elevators with an "Inactive" status
GET
https://rocketelev.azurewebsites.net/api/elevators/get/status/inactive
----------------------------------------------------------------- 
Retrieving all Elevators with an "Intervention" status
GET
https://rocketelev.azurewebsites.net/api/elevators/get/status/intervention
-----------------------------------------------------------------
Retrieving all Elevators with an "Others" status
GET
https://rocketelev.azurewebsites.net/api/elevators/get/status/others
-----------------------------------------------------------------
Columns
-----------------------------------------------------------------
Retrieving all Columns with an "Active" status
GET
https://rocketelev.azurewebsites.net/api/columns/get/status/active
-----------------------------------------------------------------
Retrieving all Columns with an "Inactive" status
GET
https://rocketelev.azurewebsites.net/api/columns/get/status/inactive
-----------------------------------------------------------------
Retrieving all Columns with an "Intervention" status
GET
https://rocketelev.azurewebsites.net/api/columns/get/status/intervention
-----------------------------------------------------------------
Retrieving all Columns with an "Others" status
GET
https://rocketelev.azurewebsites.net/api/columns/get/status/others
-----------------------------------------------------------------

 
******************************************************************************************
# GraphQL & GraphIQL
http://rocketelevatorsjm.club/graphiql
To use GraphIQL you need to add the query on the left panel then press the play button on the top left.
----------------------------------------------------------------- 
You can retrieve the address of the building, the beginning and the end of the intervention for a specific intervention.
Change the id  
*interventions(id: )*
```
{
  interventions(id: 2) {
    building {
      address {
        id
        entity
        status
        addressType
        apartmentNumber
        streetNumberName
        city
        stateProvince
        country
        zipCode
        latitude
        longitude
        status
      }
    }
  }
}
```
----------------------------------------------------------------- 
You can retrieve customer information and the list of interventions that look place for a specific building.
Change the id  
*buildings(id: )*
```
{
  buildings(id: 1) {
    customer {
      id
      businessName
      contactFullName
      contactPhone
      contactEmail
    }
    interventions {
      id
      batteryId
      columnId
      elevatorId
      employeeId
      status
      startDateTimeIntervention
      result
      endDateTimeIntervention
      report
    }
  }
}
```
----------------------------------------------------------------- 
You can retrieve all interventions carried out by a specified employee with the buildings associated with these interventions including the details (Table BuildingDetails) associated with these buildings.
Change the id  
*employees(id: )*
```
{
  employees(id: 1) {
    id
    userId
    firstName
    lastName
    interventions {
      batteryId
      columnId
      elevatorId
      startDateTimeIntervention
      result
      status
      endDateTimeIntervention
      report
      building {
        buildingDetails {
          buildingId
          informationKey
          value
        }
      }
    }
  }
}
```

