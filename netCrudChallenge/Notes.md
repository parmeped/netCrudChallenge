﻿# Objective
Migrate golang Crud solution to C#

# Analysis
Since previous solution was already working, what can be done is simply "copy" the logic into .Net core with the solutions that work best for the framework.

Given that the worst part of the API was testing, an emphasis should be made on it as to have a proper mock. 

# Steps
- Analyze all current endpoints, see if there's a better implementation (ie. all should be consistent)
- Search for a model .Net core + postgreSql project for best practices. 
- Given that postgreSql was previously used, the repository should stay the same. Connect to postgreSql
- Create a basic folder structure. Determine the best layout.
- Migrate project.
    Start exposing all endpoints and their returns. Validations should come later on. Work from the best case.     
    Work from a single endpoint up to the lower layer. 
    Unit Tests
    Docker
    SwaggerUI

# Deliverables Checklist
- Create contact record
- Retrieve contact record
- Update contact record
- Delete contact record
- Search for record by email or phone number
- Retrieve all records from the same state or city
- Check validations
- Unit Tests
- Docker
- SwaggerUI

# What was missing before
- Further Unit tests, with proper mocking
- Profile image.. should store as blob...maybe? 
- Write down assumptions
- The phone search was lacking.
- Something else? 


## Desirable improvements over current endpoints
- Phone search is lacking.. should return a paginated list with all contacts that match a portion of the number:    
    eg.
    {
        "Prefix": 549,
        "Number": 500
    }
    returns all contacts with 549 in some part of their number and 500 in some other part. Maybe a query param to search by prefix or by number? 
- When returning null value, should omit the field, or return something related.     
- Search by Location was great, but should return all phones too.
- Created, Updated and Deleted _at should not be returned. 





# Current endpoints 

## Analysis
Current inheritance from Base was alright. Should really implement the hook to make it save when created, updated and deleted. 
DB modeling was alright. 
Addresses could be unique, and they could be kept on another table... but should they? It would introduce a whole lot of other problems, such as validating if a contact and a company have the same assigned address_id. They shouldn't? No, since a contact has already a company_id, and given the contact has birthDate and profileImage, it's definitely not a company's contact. 
This would be something like:
    ID
    StreetName
    StreetNumber
    -- RelatedID -- This wouldn't be necessary since a company or contact would only refer to this address's ID.
    City
Given it's simpler to just keep the address within a contact or company, let's just do that. What about floor / appartment? 


### POST localhost:8080/v1/contacts

{
    "name": "dfsdsaaasd",
    "email": "testMail0s@email.com",
    "profile_image": "Image",
    "birth_date": "2000-01-01T00:00:00Z",
    "company_id": 10,
    "street_name": "Name Of Street",
    "street_number": 1100,
    "city_id": 10,
    "phones": [
        {
            "prefix": 911,
            "number": 0,
            "type_id": 1
        },
        {
            "prefix": 911,
            "number": 0,
            "type_id": 2
        }
    ]
}


#### -- Returns 200 OK [Created user]

{
  "ID": 24,
  "CreatedAt": "2020-03-27T11:33:43.0327014-03:00",
  "UpdatedAt": "2020-03-27T11:33:43.0727488-03:00",
  "DeletedAt": null,
  "Name": "dfsdsaaasd",
  "CompanyID": 10,
  "ProfileImage": "Image",
  "Email": "testMail0s@email.com",
  "BirthDate": "2000-01-01T00:00:00Z",
  "StreetName": "Name Of Street",
  "StreetNumber": 1100,
  "CityID": 10,
  "Phones": [
    {
      "ID": 47,
      "CreatedAt": "2020-03-27T11:33:43.0947015-03:00",
      "UpdatedAt": "2020-03-27T11:33:43.0947015-03:00",
      "DeletedAt": null,
      "prefix": 911,
      "number": 0,
      "type_id": 1,
      "ContactID": 24
    },
    {
      "ID": 48,
      "CreatedAt": "2020-03-27T11:33:43.0987005-03:00",
      "UpdatedAt": "2020-03-27T11:33:43.0987005-03:00",
      "DeletedAt": null,
      "prefix": 911,
      "number": 0,
      "type_id": 2,
      "ContactID": 24
    }
  ]
}

### GET localhost:8080/v1/contacts/:id

#### -- Returns 200 OK [Found contact]

{
  "id": 2,
  "name": "Contact 2",
  "company_id": 1,
  "company_name": "Company 1",
  "profile_image": "ImageUrl",
  "email": "contactEmail2@mail.com",
  "birth_date": "0001-01-01T00:00:00Z",
  "street_name": "Street Name",
  "street_number": 4728,
  "city_id": 1,
  "city_name": "City 1",
  "state_name": "State 1",
  "phones": [
    {
      "ID": 2,
      "CreatedAt": "2020-03-24T17:55:34.884489-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.884489-03:00",
      "DeletedAt": null,
      "prefix": 549,
      "number": 93909335,
      "type_id": 1,
      "ContactID": 2
    },
    {
      "ID": 22,
      "CreatedAt": "2020-03-24T17:55:34.906437-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.906437-03:00",
      "DeletedAt": null,
      "prefix": 549,
      "number": 90759663,
      "type_id": 2,
      "ContactID": 2
    }
  ]
}

### DELETE localhost:8080/v1/contacts/:id

#### -- Returns 200 OK [Successful deletetion]

### PATCH localhost:8080/v1/contacts/:id

{
	"name" : "Testing Updatessssss",
	"email": "test@email.com",
	"profile_image": "TestImage",
	"birth_date": "2044-01-01T15:00:00Z",
	"company_id": 8,
	"street_name": "Name Of dedweeeet",
	"street_number": "1100",
	"city_id": 1,
	"state_id": 1
}

#### -- Returns 200 OK [Contact Updated, New contact info]

{
  "id": 12,
  "name": "Testing Updatessssss",
  "company_id": 8,
  "company_name": "Company 8",
  "profile_image": "TestImage",
  "email": "test@email.com",
  "birth_date": "0001-01-01T00:00:00Z",
  "street_name": "Name Of dedweeeet",
  "street_number": 1100,
  "city_id": 1,
  "city_name": "City 1",
  "state_name": "State 1",
  "phones": [
    {
      "ID": 12,
      "CreatedAt": "2020-03-24T17:55:34.895459-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.895459-03:00",
      "DeletedAt": null,
      "prefix": 549,
      "number": 20159127,
      "type_id": 1,
      "ContactID": 12
    },
    {
      "ID": 32,
      "CreatedAt": "2020-03-24T17:55:34.917399-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.917399-03:00",
      "DeletedAt": null,
      "prefix": 549,
      "number": 55512467,
      "type_id": 2,
      "ContactID": 12
    }
  ]
}

### GET localhost:8080/v1/contacts/listByLocation/:searchParam/:id

{
	"Limit": 5,
	"Page": 0
}

#### -- Returns 200 OK [List of found Contacts, paginated.]

{
  "contacts": [
    {
      "ID": 6,
      "CreatedAt": "2020-03-24T17:55:34.866536-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.866536-03:00",
      "DeletedAt": null,
      "Name": "Contact 6",
      "CompanyID": 3,
      "ProfileImage": "ImageUrl",
      "Email": "contactEmail6@mail.com",
      "BirthDate": "1968-12-27T22:00:00-03:00",
      "StreetName": "Street Name",
      "StreetNumber": 541,
      "CityID": 3,
      "Phones": null
    }
  ],
  "page": 0
}

### GET localhost:8080/v1/contacts/listByMail/:mail

{
	"Limit": 5,
	"Page": 0
}

#### -- Returns 200 OK [List of found Mails, paginated]

[
  {
    "ID": 1,
    "CreatedAt": "2020-03-24T17:55:34.860551-03:00",
    "UpdatedAt": "2020-03-24T17:55:34.860551-03:00",
    "DeletedAt": null,
    "Name": "Contact 1",
    "CompanyID": 1,
    "ProfileImage": "ImageUrl",
    "Email": "contactEmail1@mail.com",
    "BirthDate": "1961-06-18T22:00:00-03:00",
    "StreetName": "Street Name",
    "StreetNumber": 694,
    "CityID": 1,
    "Phones": [
      {
        "ID": 1,
        "CreatedAt": "2020-03-24T17:55:34.882494-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.882494-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 15076654,
        "type_id": 1,
        "ContactID": 1
      },
      {
        "ID": 21,
        "CreatedAt": "2020-03-24T17:55:34.905433-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.905433-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 63699763,
        "type_id": 2,
        "ContactID": 1
      }
    ]
  },
  {
    "ID": 11,
    "CreatedAt": "2020-03-24T17:55:34.87252-03:00",
    "UpdatedAt": "2020-03-24T17:55:34.87252-03:00",
    "DeletedAt": null,
    "Name": "Contact 11",
    "CompanyID": 6,
    "ProfileImage": "ImageUrl",
    "Email": "contactEmail11@mail.com",
    "BirthDate": "1968-04-05T22:00:00-03:00",
    "StreetName": "Street Name",
    "StreetNumber": 1957,
    "CityID": 6,
    "Phones": [
      {
        "ID": 11,
        "CreatedAt": "2020-03-24T17:55:34.894475-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.894475-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 56189646,
        "type_id": 1,
        "ContactID": 11
      },
      {
        "ID": 31,
        "CreatedAt": "2020-03-24T17:55:34.916402-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.916402-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 17831058,
        "type_id": 2,
        "ContactID": 11
      }
    ]
  },
  {
    "ID": 16,
    "CreatedAt": "2020-03-24T17:55:34.877506-03:00",
    "UpdatedAt": "2020-03-24T17:55:34.877506-03:00",
    "DeletedAt": null,
    "Name": "Contact 16",
    "CompanyID": 8,
    "ProfileImage": "ImageUrl",
    "Email": "contactEmail16@mail.com",
    "BirthDate": "1985-03-22T22:00:00-03:00",
    "StreetName": "Street Name",
    "StreetNumber": 1563,
    "CityID": 8,
    "Phones": [
      {
        "ID": 16,
        "CreatedAt": "2020-03-24T17:55:34.899447-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.899447-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 16891341,
        "type_id": 1,
        "ContactID": 16
      },
      {
        "ID": 36,
        "CreatedAt": "2020-03-24T17:55:34.921391-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.921391-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 55999046,
        "type_id": 2,
        "ContactID": 16
      }
    ]
  },
  {
    "ID": 17,
    "CreatedAt": "2020-03-24T17:55:34.878504-03:00",
    "UpdatedAt": "2020-03-24T17:55:34.878504-03:00",
    "DeletedAt": null,
    "Name": "Contact 17",
    "CompanyID": 9,
    "ProfileImage": "ImageUrl",
    "Email": "contactEmail17@mail.com",
    "BirthDate": "1975-08-21T22:00:00-03:00",
    "StreetName": "Street Name",
    "StreetNumber": 447,
    "CityID": 9,
    "Phones": [
      {
        "ID": 17,
        "CreatedAt": "2020-03-24T17:55:34.901441-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.901441-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 12214521,
        "type_id": 1,
        "ContactID": 17
      },
      {
        "ID": 37,
        "CreatedAt": "2020-03-24T17:55:34.922389-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.922389-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 98097159,
        "type_id": 2,
        "ContactID": 17
      }
    ]
  },
  {
    "ID": 18,
    "CreatedAt": "2020-03-24T17:55:34.879501-03:00",
    "UpdatedAt": "2020-03-24T17:55:34.879501-03:00",
    "DeletedAt": null,
    "Name": "Contact 18",
    "CompanyID": 9,
    "ProfileImage": "ImageUrl",
    "Email": "contactEmail18@mail.com",
    "BirthDate": "1985-10-07T22:00:00-03:00",
    "StreetName": "Street Name",
    "StreetNumber": 2996,
    "CityID": 9,
    "Phones": [
      {
        "ID": 18,
        "CreatedAt": "2020-03-24T17:55:34.902448-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.902448-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 80695283,
        "type_id": 1,
        "ContactID": 18
      },
      {
        "ID": 38,
        "CreatedAt": "2020-03-24T17:55:34.923383-03:00",
        "UpdatedAt": "2020-03-24T17:55:34.923383-03:00",
        "DeletedAt": null,
        "prefix": 549,
        "number": 28478641,
        "type_id": 2,
        "ContactID": 18
      }
    ]
  }
]

### GET localhost:8080/v1/contacts/byPhone

{
	"prefix": 549,
	"number": 93909335
}

#### -- Returns 200 OK [Found Contact with phone number]

{
  "id": 2,
  "name": "Contact 2",
  "company_id": 1,
  "company_name": "Company 1",
  "profile_image": "ImageUrl",
  "email": "contactEmail2@mail.com",
  "birth_date": "0001-01-01T00:00:00Z",
  "street_name": "Street Name",
  "street_number": 4728,
  "city_id": 1,
  "city_name": "City 1",
  "state_name": "State 1",
  "phones": [
    {
      "ID": 2,
      "CreatedAt": "2020-03-24T17:55:34.884489-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.884489-03:00",
      "DeletedAt": null,
      "prefix": 549,
      "number": 93909335,
      "type_id": 1,
      "ContactID": 2
    },
    {
      "ID": 22,
      "CreatedAt": "2020-03-24T17:55:34.906437-03:00",
      "UpdatedAt": "2020-03-24T17:55:34.906437-03:00",
      "DeletedAt": null,
      "prefix": 549,
      "number": 90759663,
      "type_id": 2,
      "ContactID": 2
    }
  ]
}