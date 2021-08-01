# MAGO
This project small recommends parking spaces for Airplanes

For this, the Strategy Pattern is used to create the various classes and carry out the functionality for
recommending a parking slot for airplanes.

I have created a Factory class in the Core project within the 'Factory' folder called PlaneFactory which 
could have been used to create the classes instead.

In the MAGO.Api project the Plane controller accepts a Post request with JSON body which then calls the
IPlaneService to determine the request type and orchestrates the creation of the appropriate class and 
carry out the work. 

Tests were done using Postman: https://localhost:[Post_Number]/plane

Below is the JSON for testing for the various pnae types: Jumbo, Jet and Prop.

Jumbo:
{
    "plane": {
		"flightname": "A380270",
		"id": "A380",
		"planetype": 380
    },
    "startdate": "2021-08-03T00:00:00",
	"hourofarrival": 14,
	"totalnumberofhoursrequired": 6
}

Jet:
{
    "plane": {
		"flightname": "B777425",
		"id": "B777",
		"planetype": 330
    },
    "startdate": "2021-08-03T00:00:00",
	"hourofarrival": 14,
	"totalnumberofhoursrequired": 4
}

Prop:
{
    "plane": {
		"flightname": "E195306",
		"id": "E195",
		"planetype": 195
    },
    "startdate": "2021-08-03T00:00:00",
	"hourofarrival": 14,
	"totalnumberofhoursrequired": 4
}

