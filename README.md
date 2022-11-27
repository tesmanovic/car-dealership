# SmyzeTask

# Function deployed on Azure

## Request
To run the function, the following request configuraiton can be used
URL: *https://fullcarspecification.azurewebsites.net/api/cars*
HTTP METHOD: *GET*
Query params:
- brand: mazda
- model: 3
- offer: 19832

Full url example: `GET: https://fullcarspecification.azurewebsites.net/api/cars?brand=mazda&model=3&offer=19832`

## Response
```
{
  "manufacturer": "mazda",
  "model": "3",
  "color": "Red",
  "hp": 200.0,
  "engine": 2.0,
  "fuel": "petrol"
}
```

# Local environment
To start the projecti in local environment, use `local.setting.json`.