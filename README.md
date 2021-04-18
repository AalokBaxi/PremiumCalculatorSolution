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


*****Run application on local machine*****

PremiumCalculatorSolutions - Collection of projects

 PremiumCalculatorApi - API project using ASP.NET API Core 5.0

 PremiumCalculatorCore - Business object which are shared between all projects

 PremiumCalculatorService - Service layer

 PremiumCalculatorWeb - UI project using ASP.NET MVC Core 5.0

 PremiumCalculatorTest - Test methods using Moq framework
   
To run the solution on local, set multiple project(PremiumCalculatorApi and PremiumCalculatorWeb) as startup.
