# PremiumCalculatorSolution

*****Api project details*****

Swagger Url: https://mypremiumcalculatorapi.azurewebsites.net/swagger/index.html

*****To get all Occupations*****

Api endpoint: https://mypremiumcalculatorapi.azurewebsites.net/api/Occupation

Curl command: curl -X GET "https://mypremiumcalculatorapi.azurewebsites.net/api/Occupation" -H  "accept: text/plain"

*****To get specific Occupation*****

Api endpoint: https://mypremiumcalculatorapi.azurewebsites.net/api/Occupation/{id}

Curl command: curl -X GET "https://mypremiumcalculatorapi.azurewebsites.net/api/Occupation/1" -H  "accept: text/plain"

*****To calculate premium*****

Api endpoint: https://mypremiumcalculatorapi.azurewebsites.net/api/Calculator

Curl command: curl -X POST "https://mypremiumcalculatorapi.azurewebsites.net/api/Calculator" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"name\":\"string\",\"age\":38,\"dob\":\"05/01/1982\",\"occupationID\":1,\"deathSumInsured\":10000}"

*****UI project details*****
Url: https://mypremiumcalculatorweb.azurewebsites.net/
