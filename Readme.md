# --  netCrudChallenge --

# Tech Stack
c# .NetCore
EF
postgresql
Docker

# Quick Start
1) To create the db from visual studio, first change the connection strings
 --> WebApi proj --> appsettings.Development.json --> ConnectionStrings

2) From visual studio, 
 --> Tools --> NuGet Package Manager --> Package Manager Console 

3) Execute command on Package Manager Console 
 --> update-database

4) Change to launch from IIS Express and start

This starts a server on https://localhost:44345/

# Assumptions
For the address: StreetName and StreetNumber, City and state.
Companies also have streetName and streetNumber.
A City has companies & Contacts.
A state has Cities.

# Endpoints
The following endpoints are available: 

## Create
POST https://localhost:44345/api/v1/contacts/

JSON:
{
	"Name" : "Testing" ,
	"CompanyID" : 1 ,
	"ProfileImage" : "https://tinyurl.com/y3e33v5m" ,
	"Email" : "TeapotEmail@email.com",
	"BirthDate" : "1990-01-01" ,
	"StreetName" : "Teapot Main Street",
	"StreetNumber" : 418,
	"CityID" : 1 ,
	"Phones": [
		{
			"Prefix" : 549,
			"Number" : 15585587,
			"PhoneTypeID" : 2
		}]
}

Returns a 200 ok if saved correctly. 

Otherwise, a 400 if already exists or wrong requests.

## View
GET https://localhost:44345/api/v1/contacts/:id

Returns a 200 ok with the contact info if found.

A 204 NoContent if request was processed but no info was found.

A 400 BadRequest for unvalid Id's (text)

## Delete 
DELETE https://localhost:44345/api/v1/contacts/:id

Returns a 200 ok if deleted. Performs a soft delete on the contact and phone numbers. 

A 204 if processed but not found, a 400 upon bad request.

## Update
PATCH https://localhost:44345/api/v1/contacts/:id

JSON: 
{
	"Name" : "TestUpdatng" ,
	"CompanyID" : 1 ,
	"ProfileImage" : "https://tinyurl.com/y3e33v5m" ,
	"Email" : "TestEmailUpdate@email.com",
	"BirthDate" : "1990-01-01" ,
	"StreetName" : "Test Street Update",
	"StreetNumber" : 3000 ,
	"CityID" : 1 ,
	"phones": [
          {
            "id": 2,
            "contactID": 2,
            "prefix": 549,
            "number": 19243518,
            "phoneTypeID": 1
        },
        {
            "id": 22,
            "contactID": 2,
            "prefix": 549,
            "number": 81764730,
            "phoneTypeID": 2
        }
    ]
}

A phone can be updated, removed or added as desired. When removed, a soft delete is performed.
Returns a 200 ok if updated, and the new data is shown.

A 204 if not found or 400 upon bad request.

# List by Location (State or City)
GET https://localhost:44345/api/v1/contacts/byLocation/:searchParam/:locationId

JSON: 
{
	"Limit": 5,
	"Page": 0
}

Returns a 200 ok with the paginated data when found. The available searchParams are City and State.
A 204 when no data is found and a 400 upon bad request.

# List by email 
GET https://localhost:44345/api/v1/contacts/byMail/:mail

JSON: 
{
	"Limit": 5,
	"Page": 0
}

Returns a 200 ok with the paginated data when found.

# List By Phone
GET https://localhost:44345/api/v1/contacts/byPhone/

JSON: 
{
	"pagination": {
		"Limit": 5,
		"Page": 0
	},
	"prefix": 20, 
	"number": 57663493
}

The min for the number is 1111, max 99999999.

Returns a 200 ok with the data, when found. 
Returns a 204 Internal Server Error when not found.
Returns a 400 upon bad request. 
