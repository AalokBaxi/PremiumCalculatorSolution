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


*****Solution details*****

PremiumCalculatorSolutions - Collection of all projects

 PremiumCalculatorApi - API project using ASP.NET Core Web API 5.0 to provide resources to calculate premium. 

 PremiumCalculatorCore - Business object which are shared between all projects.

 PremiumCalculatorService - Service layer which has core logic to calculate premium.

 PremiumCalculatorWeb - UI project using ASP.NET Core MVC 5.0 which is integrated with API.

 PremiumCalculatorTest - Test methods using Moq framework
 
 *****Run application on local machine*****
   
To run the solution on local, set multiple project(PremiumCalculatorApi and PremiumCalculatorWeb) as startup.
